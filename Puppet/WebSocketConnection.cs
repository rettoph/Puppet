using Fleck;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Puppet.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using Puppet.Services;

namespace Puppet
{
    public class WebSocketConnection : IDisposable
    {
        private IWebSocketConnection _socket;
        private Dictionary<String, Action<JToken>> _handlers;
        private ConnectionService[] _services;

        public WebSocketConnection(IWebSocketConnection socket)
        {
            Console.WriteLine("New connection established.");

            _handlers = new Dictionary<String, Action<JToken>>();

            // Load all connection service instances
            _services = Assembly.GetEntryAssembly()
                .GetTypes()
                .Where(t => !t.IsAbstract && typeof(ConnectionService).IsAssignableFrom(t))
                .Select(t => Activator.CreateInstance(t) as ConnectionService)
                .ToArray();

            // Initialize all the services
            foreach (ConnectionService service in _services)
                service.Initialize(this);

            _socket = socket;
            socket.OnMessage = this.HandleMessage;

            this.Send("system", "Welcome.");
        }

        public void Send(String type, Object data)
        {
            var message = JsonConvert.SerializeObject(new Message(type, data));
            _socket.Send(message);
        }

        public void Bind(String type, Action<JToken> handler)
        {
            _handlers.Add(type, handler);
        }

        private void HandleMessage(string raw)
        {
            var message = JsonConvert.DeserializeObject(raw) as JObject;
            var type = message.Properties().First(p => p.Name == "type").Value.ToObject(typeof(String)) as String;
            var data = message.Properties().First(p => p.Name == "data").Value;

            _handlers[type].Invoke(data);
        }

        public void Dispose()
        {
            _handlers.Clear();

            foreach (ConnectionService service in _services)
                service.Dispose();

            Console.WriteLine("Connection closed.");
        }
    }
}
