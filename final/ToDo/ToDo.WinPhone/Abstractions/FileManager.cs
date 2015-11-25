using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Abstractions;
using ToDo.WinPhone.Abstractions;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileManager))]
namespace ToDo.WinPhone.Abstractions
{
    public class FileManager : IFileManager
    {
        public string LoadText(string filename)
        {
            var task = LoadTextAsync(filename);
            task.Wait(); // HACK: to keep Interface return types simple (sorry!)
            return task.Result;
        }
        async Task<string> LoadTextAsync(string filename)
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            if (local != null)
            {
                try
                {
                    var file = await local.GetItemAsync(filename);
                    using (StreamReader streamReader = new StreamReader(file.Path))
                    {
                        var text = streamReader.ReadToEnd();
                        return text;
                    }
                }
                catch (FileNotFoundException x)
                {
                }
            }
            return "";
        }
        public async void SaveText(string filename, string text)
        {
            StorageFolder local = Windows.Storage.ApplicationData.Current.LocalFolder;
            var file = await local.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            using (StreamWriter writer = new StreamWriter(await file.OpenStreamForWriteAsync()))
            {
                writer.Write(text);
            }
        }
    }
}