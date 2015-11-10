using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool HasDueDate { get; set; }
        public Nullable<DateTime> DueDate { get; set; }
    }
}
