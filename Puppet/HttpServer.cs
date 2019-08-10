using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Puppet
{
    public class HttpServer
    {
        private HttpListener _listener;
        private Dictionary<String, Stream> _pages;
        private Dictionary<String, String> _mimeTypes;

        public HttpServer()
        {
            _mimeTypes = new Dictionary<String, String>();
            _mimeTypes.Add("html", "text/html");
            _mimeTypes.Add("css", "text/css");
            _mimeTypes.Add("js", "application/javascript");
            _mimeTypes.Add("png", "image/png");
            _mimeTypes.Add("jpeg", "image/jpeg");


            // Load all resources in the public directory, for HTTP response returning...
            var prefix = "Puppet.public.";
            var assembly = Assembly.GetExecutingAssembly();
            _pages = assembly
                .GetManifestResourceNames()
                .Where(n => n.StartsWith(prefix))
                .ToDictionary(
                    keySelector: n => n.Replace(prefix, ""),
                    elementSelector: n => assembly.GetManifestResourceStream(n));

            _listener = new HttpListener();
            _listener.Prefixes.Add("http://+:8080/");
            _listener.Start();

            ThreadPool.QueueUserWorkItem(this.ListenLoop);

            Console.WriteLine("Http server listening at http://localhost:8080/");
        }

        private void ListenLoop(object state)
        {
            while (true)
            {
                HttpListenerContext ctx = _listener.GetContext();

                ThreadPool.QueueUserWorkItem((__) =>
                {
                    var requestPath = ctx.Request.RawUrl;
                    if(requestPath.EndsWith("/"))
                        requestPath += "index.html";
                    requestPath = requestPath.TrimStart('/').Replace('/', '.');

                    if (_pages.ContainsKey(requestPath))
                    {
                        var response = _pages[requestPath];

                        lock (response)
                        {
                            ctx.Response.ContentType = _mimeTypes[requestPath.Split('.').Last()];
                            response.Position = 0;
                            response.CopyTo(ctx.Response.OutputStream);
                            ctx.Response.OutputStream.Close();
                        }
                    }
                    else
                    {
                        ctx.Response.ContentType = "text/html";
                        ctx.Response.StatusCode = 404;

                        using (StreamWriter writer = new StreamWriter(ctx.Response.OutputStream))
                        {
                            writer.Write($"<h1>404!</h1><p>Unable to find resource for '{ctx.Request.RawUrl}' under '{requestPath}'.</p>");
                            writer.Flush();
                            ctx.Response.OutputStream.Close();
                        }
                    }

                });
            }
        }
    }
}
