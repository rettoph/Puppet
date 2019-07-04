using Newtonsoft.Json.Linq;
using Puppet.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Puppet.Services
{
    public class MouseConnectionService : ConnectionService
    {
        [DllImport("User32.Dll")]
        public static extern Boolean SetCursorPos(int x, int y);

        [DllImport("User32.Dll")]
        public static extern Boolean GetCursorPos(ref Point pont);

        private Point _position;

        public override void Initialize(WebSocketConnection connection)
        {
            _position = new Point();

            connection.Bind("mouse:move", this.HandleMouseMoveAction);
        }

        private void HandleMouseMoveAction(JToken value)
        {
            var data = value.ToObject<Point>();

            MouseConnectionService.GetCursorPos(ref _position);
            _position.x += data.x;
            _position.y += data.y;
            MouseConnectionService.SetCursorPos(_position.x, _position.y);
        }
    }
}
