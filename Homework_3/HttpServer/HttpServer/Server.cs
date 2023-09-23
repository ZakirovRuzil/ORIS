using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace HttpServer
{
    public class Server
    {
        private HttpListener _server;
        private readonly Appsetings _appsetings;

        public Server()
        {
            _appsetings = ServerAppsettings._appsetings;
            _server = new HttpListener();
            _server.Prefixes.Add($"http://{_appsetings.Address}:{_appsetings.Port}/");
        }

        public void Start()
        { 
            if (!Directory.Exists(_appsetings.StaticFilesPath))
            {
                Directory.CreateDirectory(_appsetings.StaticFilesPath);
            }

            Console.WriteLine("Сервер запущен");
            _server.Start();

            while (true)
            {
                var context = _server.GetContextAsync();
                ProcessRequest(context.Result);
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {
            var uri = context.Request.Url;
            string filePath;

            if (uri.LocalPath == "/")
            {
                filePath = Path.Combine(_appsetings.StaticFilesPath, "index.html");
            }
            else
            {
                filePath = Path.Combine(_appsetings.StaticFilesPath, uri.LocalPath.TrimStart('/'));
            }

            if (filePath.EndsWith("/"))
            {
                filePath = Path.Combine(filePath, "index.html");
            }

            var fileHandler = new FileHandler();
            var contentType = fileHandler.GetContentType(filePath);

            if (File.Exists(filePath))
            {
                fileHandler.ServeFile(context, filePath, contentType);
            }
            else
            {
                fileHandler.Serve404(context);
            }
        }
    }
}
