using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppet.Services
{
    /// <summary>
    /// Connection service classes are used to interface directly with
    /// a websocket connection
    /// </summary>
    public abstract class ConnectionService : IDisposable
    {
        public abstract void Initialize(WebSocketConnection connection);

        public virtual void Dispose()
        {
        }
    }
}
