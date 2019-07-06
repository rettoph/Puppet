using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Puppet.Library.Structs
{
    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)]
        public MouseInput mi;

        [FieldOffset(0)]
        public KeyBoardInput ki;
    }
}
