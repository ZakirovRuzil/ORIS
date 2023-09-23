using System;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Text;

namespace HttpServer

{
    public class FileHandler
    {
        public string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            switch (extension)
            {
                case ".html":
                    return "text/html; charset=utf-8";
                case ".css":
                    return "text/css";
                case ".js":
                    return "application/javascript";
                case ".jpg":
                    return "image/jpeg";
                case ".jpeg":
                case ".png":
                case ".gif":
                    return "image/" + extension.Substring(1);
                case ".svg":
                    return "image/svg+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public void ServeFile(HttpListenerContext context, string filePath, string contentType)
        {
            var response = context.Response;
            response.AddHeader("Content-Type", contentType);
            byte[] buffer = File.ReadAllBytes(filePath);
            response.ContentLength64 = buffer.Length;

            using (Stream output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }

            Console.WriteLine(filePath);
        }

        public void Serve404(HttpListenerContext context)
        {
            context.Response.StatusCode = 404;
            byte[] buffer = Encoding.UTF8.GetBytes("Файл не найден");
            context.Response.ContentLength64 = buffer.Length;

            using (Stream output = context.Response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
            Console.WriteLine($"Файл не найден: {context.Request.Url}");
        }
    }
}