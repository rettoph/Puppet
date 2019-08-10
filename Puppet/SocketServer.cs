using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppet
{
    class SocketServer
    {
        private WebSocketServer _tcp;
        private Dictionary<IWebSocketConnection, WebSocketConnection> _connections;

        public SocketServer()
        {
            _connections = new Dictionary<IWebSocketConnection, WebSocketConnection>();

            _tcp = new WebSocketServer("ws://0.0.0.0:8081");
            _tcp.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    _connections.Add(socket, new WebSocketConnection(socket));
                };
                socket.OnClose = () =>
                {
                    _connections[socket].Dispose();
                    _connections.Remove(socket);
                };
            });
        }
    }
}
