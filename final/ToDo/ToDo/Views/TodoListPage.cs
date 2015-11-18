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
			listView.SetBinding (ListView.ItemsSourceProperty, "ToDoItems");

            // Binding para los items de la lista
            BindingContext = new ToDoListViewModel();

            // Bindings para definir la información que se muestra por cada fila
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
			listView.ItemTemplate.SetBinding(TextCell.DetailProperty, "Description");

			var saveButton = new Button { Text = "Save" };
			saveButton.SetBinding (Button.CommandProperty, "SaveToDosCommand");

			var loadButton = new Button { Text = "Load" };
			loadButton.SetBinding (Button.CommandProperty, "LoadToDosCommad");

			Content = new StackLayout {
				Children = {
					saveButton,
					loadButton,
					listView
				}
			};


        }
    }
}
