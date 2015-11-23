using System;
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

			// Bindings para los items de la lista
            listView.SetBinding(ListView.ItemsSourceProperty, "ToDoItems");
            listView.SetBinding(ListView.SelectedItemProperty, "SelectedToDoItem");

            // Bindings para definir la información que se muestra por cada fila
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Description");

            var saveButton = new ToolbarItem { Text = "Save" };

			var addButton = new ToolbarItem { Text = "Add" };

			Content = new StackLayout {
				Children = {
					listView
				}
			};

			ToolbarItems.Add(saveButton);
			ToolbarItems.Add(addButton);
        }
    }
}
