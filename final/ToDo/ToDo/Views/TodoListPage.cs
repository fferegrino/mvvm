using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Views
{
    public class ToDoListPage : ContentPage
    {
        public ToDoListPage()
        {
            BindingContext = new ToDoListViewModel();

			var listView = new ListView();
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.SetBinding(ListView.ItemsSourceProperty, "ToDoItems");
            listView.SetBinding(ListView.SelectedItemProperty, "SelectedToDoItem");
            listView.ItemSelected += (s, a) =>
            {
                (BindingContext as ToDoListViewModel).ViewDetailCommand.Execute(null);
            };

            // Binding para los items de la lista
            BindingContext = new ToDoListViewModel();

            // Bindings para definir la información que se muestra por cada fila
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Description");

            var saveButton = new ToolbarItem { Text = "Save" };
			saveButton.SetBinding(ToolbarItem.CommandProperty, "SaveToDosCommand");

			var loadButton = new ToolbarItem { Text = "Load" };
			loadButton.SetBinding(ToolbarItem.CommandProperty, "LoadToDosCommad");

			var addButton = new ToolbarItem { Text = "Add" };
			addButton.SetBinding(ToolbarItem.CommandProperty, "AddToDoCommad");

			Content = new StackLayout {
				Children = {
					listView
				}
			};

			ToolbarItems.Add(saveButton);
			ToolbarItems.Add(loadButton);
			ToolbarItems.Add(addButton);
        }
    }
}
