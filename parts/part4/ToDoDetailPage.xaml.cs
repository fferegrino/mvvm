using ToDo.ViewModels;
using Xamarin.Forms;

namespace ToDo.Views
{
	public partial class ToDoDetailPage : ContentPage
	{
		public ToDoDetailPage (ToDoItemViewModel viewModel)
		{
            BindingContext = viewModel;
			InitializeComponent ();
		}
	}
}

