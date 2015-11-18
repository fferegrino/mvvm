using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class ToDoItemViewModel : BaseViewModel
    {
        private ToDoItem _model;

        public ToDoItemViewModel(ToDoItem model)
        {
            _model = model;
        }

        public ToDoItem Item
        {
            get { return _model; }
        }

        public string Name
        {
            get { return _model.Name; }
            set { _model.Name = value; base.RaisePropertyChanged(); }
        }
        public string Description
        {
            get { return _model.Description; }
            set { _model.Description = value; base.RaisePropertyChanged(); }
        }
        public bool IsDone
        {
            get { return _model.Done; }
            set { _model.Done = value; base.RaisePropertyChanged(); }
        }
        public bool HasDueDate
        {
            get { return _model.HasDueDate; }
            set { _model.HasDueDate = value; base.RaisePropertyChanged(); }
        }
        public DateTime? DueDate
        {
            get { return _model.DueDate; }
            set { _model.DueDate = value; base.RaisePropertyChanged(); }
        }
    }
}
