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

#### Código  
Archivo `ToDoListPage.cs`

### Parte 2.2 - Detalle de la tarea
Lo que queremos ver en esta vista es el detalle de la tarea. Será una interfaz sencilla, por eso se usarán principalmente `Label` en conjunto con `StackLayout`.

#### Código  
Archivo `ToDoDetailPage.xaml` y `ToDoDetailPage.xaml.cs`

### Parte 2.3 - Establecer una pantalla de inicio  
Para establecer la pantalla desde la que vamos a iniciar, es necesario modificar el archivo `App.cs` y cambiar la propiedad `MainPage` pro la pantalla desde la que queremos que nuestra aplicación inice  

#### Código  
Archivo `App.cs`

## Parte 3 - El ViewModel
Esta es la parte “nueva”, como ya vimos, el el ViewModel es la capa intermedia entre la vista y la lógica de la aplicación para esta aplicación existirá un mapeo 1:1, una vista, un viewmodel.  

### Parte 3.1 - La base  
Para ahorrarnos código todos nuestros viewmodels heredarán de una clase que ya implementa `INotifyPropertyChanged` y otorga algunos métodos útiles. Esta es una práctica común.

#### Código
Archivo `BaseViewModel.cs`

### Parte 3.2 - Detalle
Este viewmodel será bastante sencillo, únicamente es una envoltura para el modelo, debe ser un mapeo 1:1 con las propiedades de este.  

#### Código  
Archivo `ToDoItemViewModel.cs`

### Parte 3.3 - Lista
Este viewmodel contendrá una lista de `ToDoItemViewModels`, sin embargo no será una lista normal sino una 


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
