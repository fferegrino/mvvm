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
Archivo `ToDoItem.cs`

## Parte 2 - La vista  
Para la app, contaremos con dos vistas: 
 1. La primera: en la que veremos una lista de tareas registradas
 2. La segunda: en la que veremos el detalle de las tareas, además de que en ella podremos agregar nuevas tareas.

### Parte 2.1 - Lista de tareas registradas  
Usaremos un control del tipo `ListView` para las tareas y cada elemento de la celda será un `TextCell` que solo mostrará el título de la actividad.  
  
Además añadiremos algunos botones para permitir darle funcionalidad a la aplicación, para esto usaremos tres `ToolBarItem` que se renderizan en las barras de las aplicaciones para darle así una mejor experiencia al usuario.  

Añadiremos dos: uno para guardar las tareas y otro para crear una nueva. Este es el código necesario para crear y añadir un nuevo `ToolBarItem` a la vista:  

```
var saveButton = new ToolbarItem { Text = "Save" };
ToolbarItems.Add(saveButton);
```

#### Código  
Archivo `ToDoListPage.cs`

### Parte 2.2 - Detalle de la tarea
Lo que queremos ver en esta vista es el detalle de la tarea. Será una interfaz sencilla, por eso se usarán principalmente `Entry` que permiten ver y editar el texto que contienen en conjunto con varios `StackLayout` para acomodar mejor los elementos.  

Esta pantalla está escrita con XAML, que no es más que un lenguaje muy parecido al XML que nos sirve para crear interfaces de usuario. Para definir un campo de entrada de texto, un `Entry` se usa este código:
```
<Entry></Entry>
```

#### Código  
Archivos `ToDoDetailPage.xaml` y `ToDoDetailPage.xaml.cs`

### Parte 2.3 - Establecer una pantalla de inicio  
Para establecer la pantalla desde la que vamos a iniciar, es necesario modificar el archivo `App.cs` y cambiar la propiedad `MainPage` pro la pantalla desde la que queremos que nuestra aplicación inicie.  
  
Para esta app, deseamos que la aplicación inicie con la lista de tareas, para lo cual es necesario algo como esto:  
```
MainPage = new NavigationPage(new ToDoListPage());
```

#### Código  
Archivo `App.cs`

## Parte 3 - El ViewModel
Esta es la parte “nueva”, como ya vimos, el el ViewModel es la capa intermedia entre la vista y la lógica de la aplicación para esta aplicación existirá un mapeo 1:1, una vista, un viewmodel.  

### Parte 3.1 - La base  
Para ahorrarnos código todos nuestros viewmodels heredarán de una clase que ya implementa `INotifyPropertyChanged` y otorga algunos métodos útiles. Esta es una práctica común que muchas librerías ofrecen un view model base como el de la clase `BaseViewModel`.  

#### Código
Archivo `BaseViewModel.cs`

### Parte 3.2 - Detalle
Este viewmodel será bastante sencillo, únicamente es una envoltura para el modelo (`ToDoItem`), debe ser un mapeo 1:1 con las propiedades de este. Nuestro viewmodel deberá contener una propiedad que haga referencia al modelo:
```
private ToDoItem _model;
```  

Y posteriormente debemos mapear todas las propiedades de este mismo, por poner un ejemplo:  
```
public string Name
{
    get { return _model.Name; }
    set { _model.Name = value; base.RaisePropertyChanged(); }
}
```

#### Código  
Archivo `ToDoItemViewModel.cs`

### Parte 3.3 - Lista
Este viewmodel contendrá:  

- Una colección de `ToDoItemViewModel` llamada Items, usaremos la clase `ObservableCollection<T>` donde se almacenarán las tareas pendientes  
- Una propiedad `ToDoItemViewModel` que contendrá el detalle de una tarea seleccionada, que para nuestro caso llamaremos `SelectedToDoItem`.

#### Código  
Archivo `ToDoListViewModel.cs`  


## Parte 4 - Conexión View-VeiwModel  
Una vez que tenemos el ViewModel, es necesario conectarlo de algún modeo en neustra vista, para eso usaremos el propiedad `BindingContext` de las páginas de Xamarin.Forms. En esta etapa, también estableceremos los *bindings* (o enlaces) a las propiedades del *ViewModel*.  

### Parte 4.1 - Lista de tareas pendientes  
Para hacer esto, es necesario establecer el contexto de cada elemento a través de su propiedad `BindingContext`, por ejemplo, en nuestro caso es necesario establecer la propiedad de la página al viewmodel de la lista.
```
BindingContext = new ToDoListViewModel();
```  

Ahora, cada control tiene varias propiedades que podemos establecer a través de estos *bindings*, por poner un ejemplo digamos que queremos establecer la propiedad `ItemsSource` de un control `ListView`:
```
listView.SetBinding(ListView.ItemsSourceProperty, "ToDoItems");
```  

En este caso, le estamos indicando que dentro de nuestro *BindingContext* busque una propiedad llamada `ToDoItems` y de ahí extraiga los valores para `ItemsSource` de nuestra `ListView`.

#### Código  
Archivo `ToDoListPage.cs`

### Parte 4.2 - Detalle de cada tarea  
En este caso, al ser una vista escrita en XAML, estableceremos los *bindings* ahí mismo. Además debemos recordar que esta vista de detalle también nos permitirá editar las tareas, así que debemos establecer enlaces de dos vías, esto se hace así en XAML:  

```
<Entry Text="{Binding Name, Mode=TwoWay}"></Entry>
``` 
En la línea anterior estamos indicando que el texto debe ser igual a la propiedad `Name` de nuestro contexto y que el enlace es de dos vías, es decir que tanto la vista como el viewmodel pueden cambiar el valor de la propiedad.

Por otro lado, el contexto (`BindingContext`) también puede ser establecido vía XAML, pero por simplicidad utilizaremos el *code behind* de nuestra vista. Para esto debemos modificar el código para que reciba un `ToDoItemViewModel` y lo establezca como su contexto.  

```
public ToDoDetailPage (ToDoItemViewModel viewModel)
{
    BindingContext = viewModel;
```

#### Código  
Archivos `ToDoDetailPage.xaml` y `ToDoDetailPage.xaml.cs`