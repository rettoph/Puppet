using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppet.Library.Enums
{
    /// <summary>
    /// The type of the input event. This member can be one of the following values.
    /// 
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-taginput
    /// </summary>
    public enum InputType : UInt32
    {
        /// <summary>
        /// The event is a mouse event. Use the mi structure of the union.
        /// </summary>
        INPUT_MOUSE = 0,

        /// <summary>
        /// The event is a keyboard event. Use the ki structure of the union.
        /// </summary>
        INPUT_KEYBOARD = 1,

        /// <summary>
        /// The event is a hardware event. Use the hi structure of the union.
        /// </summary>
        INPUT_HARDWARE = 2
    }
}
