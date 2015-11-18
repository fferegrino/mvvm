using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using ToDo.Models;
//
using Xamarin.Forms;
using ToDo.Abstractions;

namespace ToDo.ViewModels
{
    public class ToDoListViewModel : BaseViewModel
    {

        public ToDoListViewModel()
        {
            ToDoItems.Add(new ToDoItem { Name = "Practice for presentation", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc dapibus magna ac quam imperdiet dignissim. In vulputate sapien vel nisl luctus, non rhoncus nunc rhoncus. Quisque cursus vulputate dolor vitae." });
            ToDoItems.Add(new ToDoItem { Name = "Do present", Description = "Duis fringilla, est eu mollis pretium, sem dolor blandit quam, quis sollicitudin velit est eget libero. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus." });
            ToDoItems.Add(new ToDoItem { Name = "Go to Estadio Azteca", Description = "Nulla eros felis, mattis nec dolor dictum, cursus tincidunt ante." });
        }


        private ObservableCollection<ToDoItem> _toDoItems;

        public ObservableCollection<ToDoItem> ToDoItems
        {
            get { return _toDoItems ?? (_toDoItems = new ObservableCollection<ToDoItem>()); }
            set { _toDoItems = value; base.RaisePropertyChanged("ToDoItems"); }
        }

        private ToDoItem _selectedToDoItem;

        public ToDoItem SelectedToDoItem
        {
            get { return _selectedToDoItem; }
            set { _selectedToDoItem = value; base.RaisePropertyChanged(); }
        }

		private Command _saveToDosCommand;

		public Command SaveToDosCommand 
		{
			get 
			{
				return _saveToDosCommand ?? 
					( _saveToDosCommand = new Command(()=>{
						var manager = new ToDoSaveManager();
						List<ToDoItem> lista = ToDoItems.ToList();
						manager.SetToDoItems(lista);
					}));
			}
		}

		private Command _loadToDosCommad;

		public Command LoadToDosCommad {
			get 
			{
				return _loadToDosCommad ?? 
					( _loadToDosCommad = new Command(()=>{
						var manager = new ToDoSaveManager();
						var list = manager.GetToDoItems();
						foreach(var item in list){
							ToDoItems.Add(item);
						}
					}));
			}
			
		}


    }
}
