namespace WPFToDolist
{
    class readclasses
    {
        //        Sure! Here's an example of how you can implement sorting in your `TasksViewModel` class:

        //```csharp
        //        public ICommand SortByDateCommand { get; set; }
        //        public ICommand SortByPriorityCommand { get; set; }
        //        private bool _isDateDescending;
        //        private bool _isPriorityDescending;

        //        public TasksViewModel()
        //        {
        //            SortByDateCommand = new RelayCommand(SortByDate);
        //            SortByPriorityCommand = new RelayCommand(SortByPriority);
        //        }

        //        private void SortByDate()
        //        {
        //            if(_isDateDescending)
        //                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderByDescending(t => t.Date));
        //            else
        //                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderBy(t => t.Date));
        //            _isDateDescending = !_isDateDescending;
        //        }
        //        private void SortByPriority()
        //        {
        //            if(_isPriorityDescending)
        //                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderByDescending(t => t.Priority));
        //            else
        //                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderBy(t => t.Priority));
        //            _isPriorityDescending = !_isPriorityDescending;
        //        }
        //```

        //This code adds two `ICommand` properties to your `TasksViewModel` class: `SortByDateCommand` and `SortByPriorityCommand`.
        //These commands can be bound to buttons in your view.When the user clicks the button, the corresponding command will be executed and the `TaskList` will be sorted accordingly.
        //        The sorting is done using LINQ's `OrderBy` and `OrderByDescending` methods. The `_isDateDescending` and `_isPriorityDescending` fields are used to keep track of the current sorting order.
        //        Each time the user clicks the button, the sorting order is toggled between ascending and descending.

        //You can then bind these commands to buttons in your view like this:

        //```xaml
        //<Button Content="Sort by Date" Command="{Binding SortByDateCommand}" />
        //<Button Content = "Sort by Priority" Command= "{Binding SortByPriorityCommand}" />
        //```

        //I hope this helps! Let me know if you have any questions or need further assistance.
        //    }
    }
}
