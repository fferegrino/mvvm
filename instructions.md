ToDo
=

# Taller de Xamarin.Forms y MVVM  
## Parte 1 - El modelo  
Nuestra aplicación de tareas por hacer requiere de tener una clase que represente los datos de cada tarea. Añade una clase que contenga:  

 - Un nombre para la tarea
 - Una descripción
 - Un indicador de si la tarea ya fue realizada
 - Un indicador de si la tarea tiene una fecha límite
 - Una fecha límite

#### Código
```
namespace ToDo.Models
{
    public class ToDoItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
        public bool HasDueDate { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
```

## Parte 2 - La vista  
Para la app, contaremos con dos vistas: 
 1. La primera: en la que veremos una lista de tareas registradas
 2. La segunda: en la que veremos el detalle de las tareas, además de que en ella podremos agregar nuevas tareas.

### Parte 2.1 - Lista de tareas registradas
Usaremos un control del tipo `ListView` para las tareas y cada elemento de la celda será un `TextCell` que solo mostrará el título de la actividad.

#### Código

```
namespace ToDo.Views
{
    public class TodoListPage : ContentPage
    {
        public TodoListPage()
        {
            var listView = new ListView();
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            Content = listView;
        }
    }
}
```

### Parte 2.2 - Detalle de la tarea
Lo que queremos ver en esta vista es el detalle de la tarea. Será una interfaz sencilla, por eso se usarán principalmente `Label` en conjunto con `StackLayout`.

#### Código

```
<?xml version="1.0" encoding="UTF-8"?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms" xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml" x:Class="ToDo.Views.ToDoDetailPage">
	<ContentPage.Content>
		<StackLayout>
			<Label FontSize="Large"></Label>
			<Label FontSize="Small"></Label>
			<StackLayout Orientation="Horizontal">
				<Label Text="Done"></Label>
				<Switch></Switch>
			</StackLayout>
			<StackLayout Orientation="Horizontal">
				<Label Text="¿Límite?"></Label>
				<Switch></Switch>
			</StackLayout>
			<DatePicker></DatePicker>
		</StackLayout>
	</ContentPage.Content>
</ContentPage>
```

### Parte 2.3 - Establecer una pantalla de inicio  
Para establecer la pantalla desde la que vamos a iniciar, es necesario modificar el archivo `App.cs` y cambiar la propiedad `MainPage` pro la pantalla desde la que queremos que nuestra aplicación inice  

#### Código  
```
            // The root page of your application
            MainPage = new ToDoListPage();
```

## Parte 3 - El ViewModel
Esta es la parte “nueva”, como ya vimos, el el ViewModel es la capa intermedia  

## Parte 4 - Conexión View-VeiwModel  
Una vez que tenemos el ViewModel, es necesario conectarlo de algún modeo en neustra vista, para eso usaremos el propiedad `BindingContext` de las páginas de Xamarin.Forms. En esta etapa, también estableceremos los *bindings* a las propiedades del *ViewModel*.

### Parte 4.1 - Lista de tareas pendientes
#### Código  
Para establecer el contexto:
```			
			// ...
            BindingContext = new ToDoViewModel();
			// ...
```
Para establecer los *bindings*:
```			
			// ...
            BindingContext = new ToDoViewModel();
			// ...
```
