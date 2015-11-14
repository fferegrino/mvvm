using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ToDo.Views
{
    public class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
			var listView = new ListView();

			Content = listView;
        }
    }
}
