using Fleck;
using Newtonsoft.Json;
using Puppet.Library;
using Puppet.Library.Enums;
using Puppet.Library.Factories;
using Puppet.Library.Structs;
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
            try
            {
                var tcp = new SocketServer();
                var http = new HttpServer();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{e.GetType().Name} => {e.Message}");
            }


            Console.ReadLine();
            // InputFactory.CreateMouseInput(0, 0, MouseInputDwFlag.le);
        }
    }
}
