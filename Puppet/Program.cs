using Fleck;
using Puppet.Library;
using Puppet.Library.Enums;
using Puppet.Library.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Puppet
{
    class Program
    {
        static void Main(string[] args)
        {
            User32.SendInput(InputFactory.CreateMouseInput(
                100,
                0,
                MouseInputDwFlag.MOUSEEVENTF_MOVE));

            Int32 i = 10;

            while (i> 0)
            {
                Console.WriteLine(i);
                i--;

                Thread.Sleep(500);
            }

            Console.WriteLine(User32.SendInput(InputFactory.CreateKeyboardInput(KeyCode.VK_W, KeyBoardInputDwFlag.KEYEVENTF_KEYDOWN)));

            Console.ReadLine();
        }
    }
}
