using Fleck;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Puppet
{
    class Program
    {
        private static WebSocketServer tcp;
        private static HttpListener http;
        private static Stream page;
        private static Stream script;
        private static Stream style;
        private static Dictionary<IWebSocketConnection, WebSocketConnection> sockets;

        static void Main(string[] args)
        {
            if (!HttpListener.IsSupported)
                throw new Exception("Unable to create web server, HTTPListener is not supported!");
            else
            {
                // Fetch the embeded resources for HTTP responses...
                var assembly = Assembly.GetExecutingAssembly();
                page = assembly.GetManifestResourceStream("Puppet.public.index.html");
                script = assembly.GetManifestResourceStream("Puppet.public.app.js");
                style = assembly.GetManifestResourceStream("Puppet.public.app.css");

                // Create a new TCP Listener and start the server...
                sockets = new Dictionary<IWebSocketConnection, WebSocketConnection>();
                tcp = new WebSocketServer("ws://0.0.0.0:8081");
                tcp.Start(socket =>
                {
                    socket.OnOpen = () => sockets.Add(socket, new WebSocketConnection(socket));
                    socket.OnClose = () =>
                    {
                        sockets[socket].Dispose();
                        sockets.Remove(socket);
                    };
                });

                // Open a new HTTP Listener and start the server...
                Console.WriteLine("Starting HTTP listener...");
                http = new HttpListener();
                http.Prefixes.Add("http://+:8080/");
                http.Start();
                ThreadPool.QueueUserWorkItem(HttpListenLoop);
                

                // Alert the local address...
                Console.WriteLine("Http server listening at http://localhost:8080/");
                Console.ReadLine();
            }
        }

        /// <summary>
        /// Main listen loop that recieves &
        /// handles http requests.
        /// </summary>
        /// <param name="_"></param>
        private static void HttpListenLoop(Object _)
        {
            while (true)
            {
                HttpListenerContext ctx = http.GetContext();

                ThreadPool.QueueUserWorkItem((__) =>
                {
                    Stream response;

                    switch (ctx.Request.RawUrl)
                    {
                        case "/app.js":
                            ctx.Response.ContentType = "text/javascript";

                            response = script;
                            break;
                        case "/app.css":
                            ctx.Response.ContentType = "text/css";

                            response = style;
                            break;
                        default:
                            ctx.Response.ContentType = "text/html";

                            response = page;
                            break;
                    }


                    lock (response)
                    {
                        response.Position = 0;
                        response.CopyTo(ctx.Response.OutputStream);
                        ctx.Response.OutputStream.Close();
                    }
                });
            }
        }
    }
}
