using System.Collections.ObjectModel;
using ToDo.Models;
using ToDo.Abstractions;
using System.Collections.Generic;
using System.Linq;
using ToDo.Views;

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

        private ToDoCommand _saveToDosCommand;

        public ToDoCommand SaveToDosCommand
        {
            get
            {
                return _saveToDosCommand ??
                    (_saveToDosCommand = new ToDoCommand(
                        () =>
                        {
                            var manager = new ToDoSaveManager();
                            List<ToDoItem> lista = ToDoItems.Select(vm => vm.Item).ToList();
                            manager.SetToDoItems(lista);
                        },
                        () => true));
            }
        }

        private ToDoCommand _loadToDosCommad;

        public ToDoCommand LoadToDosCommad
        {
            get
            {
                return _loadToDosCommad ??
                    (_loadToDosCommad = new ToDoCommand(
                        () =>
                        {
                            var manager = new ToDoSaveManager();
                            var list = manager.GetToDoItems();
                            foreach (var item in list)
                            {
                                ToDoItems.Add(new ToDoItemViewModel(item));
                            }
                        },
                        () => true));
            }

        }

		private ToDoCommand _addToDoCommad;

		public ToDoCommand AddToDoCommad
		{
			get
			{
				return _addToDoCommad ?? (_addToDoCommad = new ToDoCommand(
					() =>
					{
						var item= new ToDoItemViewModel(new ToDoItem { Name = "Edit me", Description = "Edit me" });
						ToDoItems.Add(item);
						SelectedToDoItem = item;
						// Xamarin.Forms reference. VIEWMODEL POLICE DEPARTMENT
						App.Current.MainPage.Navigation.PushAsync(new ToDoDetailPage(SelectedToDoItem));
					},
					() => true));
			}
		}

        private ToDoCommand _viewDetailCommand;

        public ToDoCommand ViewDetailCommand
        {
            get
            {
                return _viewDetailCommand ?? (_viewDetailCommand = new ToDoCommand(
                    () =>
                    {
						// Xamarin.Forms reference. VIEWMODEL POLICE DEPARTMENT
                        App.Current.MainPage.Navigation.PushAsync(new ToDoDetailPage(SelectedToDoItem));
                    },
                    () => true));
            }
        }

    }
}
