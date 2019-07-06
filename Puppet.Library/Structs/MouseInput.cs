﻿using Puppet.Library.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Puppet.Library.Structs
{
    /// <summary>
    /// Contains information about a simulated mouse event.
    /// 
    /// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-mouseinput
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last 
        /// mouse event was generated, depending on the value of the dwFlags member. 
        /// Absolute data is specified as the x coordinate of the mouse; relative data 
        /// is specified as the number of pixels moved.
        /// </summary>
        public Int32 dx { get; set; }

        /// <summary>
        /// The absolute position of the mouse, or the amount of motion since the last
        /// mouse event was generated, depending on the value of the dwFlags member. 
        /// Absolute data is specified as the y coordinate of the mouse; relative data 
        /// is specified as the number of pixels moved.
        /// </summary>
        public Int32 dy { get; set; }

        /// <summary>
        /// If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of 
        /// wheel movement. A positive value indicates that the wheel was rotated forward, 
        /// away from the user; a negative value indicates that the wheel was rotated backward, 
        /// toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// 
        /// Windows Vista: If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies 
        /// the amount of wheel movement.A positive value indicates that the wheel was 
        /// rotated to the right; a negative value indicates that the wheel was rotated 
        /// to the left.One wheel click is defined as WHEEL_DELTA, which is 120.
        /// 
        /// If dwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or 
        /// MOUSEEVENTF_XUP, then mouseData should be zero.
        /// 
        /// If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies 
        /// which X buttons were pressed or released. This value may be any combination of the 
        /// following flags.
        /// </summary>
        public Int32 mouseData { get; set; }

        /// <summary>
        /// A set of bit flags that specify various aspects of mouse motion and button clicks. 
        /// The bits in this member can be any reasonable combination of the following values.
        /// 
        /// The bit flags that specify mouse button status are set to indicate changes in status,
        /// not ongoing conditions.For example, if the left mouse button is pressed and held down, 
        /// MOUSEEVENTF_LEFTDOWN is set when the left button is first pressed, but not for 
        /// subsequent motions.Similarly, MOUSEEVENTF_LEFTUP is set only when the button is first
        /// released.
        /// 
        /// You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or 
        /// MOUSEEVENTF_XUP flags simultaneously in the dwFlags parameter, because they both 
        /// require use of the mouseData field.
        /// </summary>
        public MouseInputDwFlag dwFlags { get; set; }

        /// <summary>
        /// The time stamp for the event, in milliseconds. If this parameter is 0, the system 
        /// will provide its own time stamp.
        /// </summary>
        public UInt32 time { get; set; }

        /// <summary>
        /// An additional value associated with the mouse event. An application calls 
        /// GetMessageExtraInfo to obtain this extra information.
        /// </summary>
        public IntPtr dwExtraInfo { get; set; }
    }
}
