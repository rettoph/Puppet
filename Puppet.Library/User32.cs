using Puppet.Library.Structs;
using System;
using System.Runtime.InteropServices;

namespace Puppet.Library
{
    /// <summary>
    /// Simple implementation of some User32 functions
    /// developed for easy interfacing
    /// </summary>
    public static class User32
    {
        [DllImport("User32.Dll")]
        public static extern UInt32 SendInput(UInt32 cInputs, Input[] pInputs, int cbSize);

        [DllImport("User32.Dll")]
        public static extern IntPtr GetMessageExtraInfo();

        public static UInt32 SendInput(Input pInput)
        {
            return User32.SendInput(
                1,
                new Input[] { pInput },
                Marshal.SizeOf(typeof(Input)));
        }
    }
}
