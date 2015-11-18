using System;
using System.Collections.Generic;
using System.Text;
using ToDo.Abstractions;
using ToDo.iOS.Abstractions;
using Xamarin.Forms;


[assembly: Dependency(typeof(FileManager))]
namespace ToDo.iOS.Abstractions
{
    public class FileManager : IFileManager
    {
        public void SaveText(string filename, string text)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            System.IO.File.WriteAllText(filePath, text);
        }
        public string LoadText(string filename)
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = System.IO.Path.Combine(documentsPath, filename);
            return System.IO.File.ReadAllText(filePath);
        }
    }
}