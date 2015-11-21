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

            var saveButton = new ToolbarItem { Text = "Save" };

			var loadButton = new ToolbarItem { Text = "Load" };

			var addButton = new ToolbarItem { Text = "Add" };

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
