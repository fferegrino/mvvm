using System;

namespace ToDo.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool HasDueDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
