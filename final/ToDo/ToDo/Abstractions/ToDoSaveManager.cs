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

    public class Helper
    {
        public ToDoItem[] Items
        {
            get;
            set;
        }
    }
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
            var obj = JsonConvert.DeserializeObject<Helper>(r);// as ToDoItem[];
            if (obj != null)
            {
                return new List<ToDoItem>(obj.Items);
            }
            else
            {
                return new List<ToDoItem>();
            }
        }

        public void SetToDoItems(List<ToDoItem> items)
        {
            var array = items.ToArray();
            var heloer = new Helper { Items = items.ToArray() };
            string r = JsonConvert.SerializeObject(heloer);
            _fileManager.SaveText(file, r);
        }
    }
}
