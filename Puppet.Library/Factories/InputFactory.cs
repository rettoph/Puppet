using Puppet.Library.Enums;
using Puppet.Library.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Puppet.Library.Factories
{
    public static class InputFactory
    {
        /// <summary>
        /// Returns information about a simulated mouse event.
        /// </summary>
        /// <param name="dx">The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as the number of pixels moved.</param>
        /// <param name="dy">The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value of the dwFlags member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as the number of pixels moved.</param>
        /// <param name="dwFlags">A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this member can be any reasonable combination of the following values.
        /// 
        /// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions. For example, if the left mouse button is pressed and held down, MOUSEEVENTF_LEFTDOWN is set when the left button is first pressed, but not for subsequent motions. Similarly, MOUSEEVENTF_LEFTUP is set only when the button is first released.
        /// 
        /// You cannot specify both the MOUSEEVENTF_WHEEL flag and either MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP flags simultaneously in the dwFlags parameter, because they both require use of the mouseData field.</param>
        /// <param name="mouseData">If dwFlags contains MOUSEEVENTF_WHEEL, then mouseData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel was rotated backward, toward the user. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// 
        /// Windows Vista: If dwFlags contains MOUSEEVENTF_HWHEEL, then dwData specifies the amount of wheel movement. A positive value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left. One wheel click is defined as WHEEL_DELTA, which is 120.
        /// 
        /// If dwFlags does not contain MOUSEEVENTF_WHEEL, MOUSEEVENTF_XDOWN, or MOUSEEVENTF_XUP, then mouseData should be zero.
        /// 
        /// If dwFlags contains MOUSEEVENTF_XDOWN or MOUSEEVENTF_XUP, then mouseData specifies which X buttons were pressed or released. This value may be any combination of the following flags.</param>
        /// <param name="time">The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp.</param>
        /// <param name="dwExtraInfo">An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.</param>
        /// <returns></returns>
        public static Input CreateMouseInput(Int32 dx, Int32 dy, MouseInputDwFlag dwFlags, MouseData mouseData = 0, UInt32 time = 0, IntPtr dwExtraInfo = default(IntPtr))
        {
            if (dwExtraInfo == default(IntPtr))
                dwExtraInfo = User32.GetMessageExtraInfo();

            return new Input() {
                type = InputType.INPUT_MOUSE,
                u = new InputUnion()
                {
                    mi = new MouseInput() {
                        dx = dx,
                        dy = dy,
                        mouseData = mouseData,
                        dwFlags = dwFlags,
                        time = time,
                        dwExtraInfo = dwExtraInfo
                    }
                }
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wvk">A virtual-key code. The code must be a value in the range 1 to 254. If the dwFlags member specifies KEYEVENTF_UNICODE, wVk must be 0.</param>
        /// <param name="dwFlags">A hardware scan code for the key. If dwFlags specifies KEYEVENTF_UNICODE, wScan specifies a Unicode character which is to be sent to the foreground application.</param>
        /// <param name="wScan">Specifies various aspects of a keystroke.</param>
        /// <param name="time">The time stamp for the event, in milliseconds. If this parameter is zero, the system will provide its own time stamp.</param>
        /// <param name="dwExtraInfo">An additional value associated with the keystroke. Use the GetMessageExtraInfo function to obtain this information.</param>
        /// <returns></returns>
        public static Input CreateKeyboardInput(KeyCode wvk, KeyBoardInputDwFlag dwFlags, UInt16 wScan = 0, UInt32 time = 0, IntPtr dwExtraInfo = default(IntPtr))
        {
            if (dwExtraInfo == default(IntPtr))
                dwExtraInfo = User32.GetMessageExtraInfo();

            return new Input()
            {
                type = InputType.INPUT_KEYBOARD,
                u = new InputUnion()
                {
                    ki = new KeyBoardInput()
                    {
                        wvk = wvk,
                        dwFlags = dwFlags,
                        wScan = wScan,
                        time = time,
                        dwExtraInfo = dwExtraInfo
                    }
                }
            };
        }
    }
}
