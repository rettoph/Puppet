using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fleck;
using Newtonsoft.Json;
using Puppet.Library;
using Puppet.Library.Structs;

namespace Puppet
{
    public class WebSocketConnection : IDisposable
    {
        private IWebSocketConnection _socket;

        public WebSocketConnection(IWebSocketConnection socket)
        {
            _socket = socket;
            _socket.OnMessage = this.HandleSocketMessage;
        }

        private void HandleSocketMessage(string raw)
        {
            User32.SendInput(
                JsonConvert.DeserializeObject<Input>(raw));
        }

        public void Dispose()
        {
        }
    }
}
