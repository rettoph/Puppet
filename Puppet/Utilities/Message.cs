using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puppet.Utilities
{
    public struct Message
    {
        public readonly String type;
        public readonly Object data;

        public Message(String type, Object data)
        {
            this.type = type;
            this.data = data;
        }
    }
}
