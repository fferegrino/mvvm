using System.Collections.ObjectModel;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {

        public ToDoListViewModel()
        {
			// Sample items:
            ToDoItems.Add(new ToDoItemViewModel(new ToDoItem { Name = "Practice for presentation", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc dapibus magna ac quam imperdiet dignissim." }));
            ToDoItems.Add(new ToDoItemViewModel(new ToDoItem { Name = "Do present", Description = "Duis fringilla, est eu mollis pretium, sem dolor blandit quam, quis sollicitudin velit est eget libero." }));
            ToDoItems.Add(new ToDoItemViewModel(new ToDoItem { Name = "Go to Estadio Azteca", Description = "Nulla eros felis, mattis nec dolor dictum, cursus tincidunt ante." }));
        }
			
        private ObservableCollection<ToDoItemViewModel> _toDoItems;

        public ObservableCollection<ToDoItemViewModel> ToDoItems
        {
            get { return _toDoItems ?? (_toDoItems = new ObservableCollection<ToDoItemViewModel>()); }
            set { _toDoItems = value; base.RaisePropertyChanged("ToDoItems"); }
        }

        private ToDoItemViewModel _selectedToDoItem;

        public ToDoItemViewModel SelectedToDoItem
        {
            get { return _selectedToDoItem; }
            set { _selectedToDoItem = value; base.RaisePropertyChanged(); }
        }
	}
}