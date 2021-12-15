using AkinaSpeedStars.ApplicationServices.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AkinaSpeedStars.ApplicationServices
{
    /// <summary>
    /// It is supposed that FileManager download image by url and return relative path
    /// Thic class can work with any type of image through bitmap
    /// </summary>
    internal class FileManager : IFileManager
    {
        private readonly string _path;

        public FileManager(string path) => _path = path;

        public string GetImage(string url)
        {
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(url);
            Bitmap bitmap = new Bitmap(stream);
            var fullPath = _path + Guid.NewGuid().ToString();

            if (bitmap != null)
            {
                bitmap.Save(fullPath, ImageFormat.Png);
            }

            stream.Flush();
            stream.Close();
            client.Dispose();

            return fullPath;
        }
    }
}
