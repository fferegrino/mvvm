using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;
using Xamarin.Forms;

namespace ToDo.Abstractions
{
    public class ToDoSaveManager
    {
        IFileManager _fileManager;
        const string file = "todos.txt";
        public ToDoSaveManager()
        {
            _fileManager = DependencyService.Get<IFileManager>();
        }

        public List<ToDoItem> GetToDoItems()
        {
            string r = _fileManager.LoadText(file);
            return JsonConvert.DeserializeObject(r) as List<ToDoItem>;
        }

        public void SetToDoItems(List<ToDoItem> items)
        {
            string r = JsonConvert.SerializeObject(items);
            _fileManager.SaveText(file, r);
        }
    }
}
