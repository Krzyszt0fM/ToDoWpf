namespace WPFToDolist
{
    class readclasses
    {
        /*Sure! Here's an example of how you can implement sorting in your `TasksViewModel` class:

        ```csharp
                public ICommand SortByDateCommand { get; set; }
        public ICommand SortByPriorityCommand { get; set; }
        private bool _isDateDescending;
        private bool _isPriorityDescending;

        public TasksViewModel()
        {
            SortByDateCommand = new RelayCommand(SortByDate);
            SortByPriorityCommand = new RelayCommand(SortByPriority);
        }

        private void SortByDate()
        {
            if(_isDateDescending)
                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderByDescending(t => t.Date));
            else
                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderBy(t => t.Date));
            _isDateDescending = !_isDateDescending;
        }
        private void SortByPriority()
        {
            if(_isPriorityDescending)
                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderByDescending(t => t.Priority));
            else
                TaskList = new ObservableCollection<TaskModel>(TaskList.OrderBy(t => t.Priority));
            _isPriorityDescending = !_isPriorityDescending;
        }
        ```

        This code adds two `ICommand` properties to your `TasksViewModel` class: `SortByDateCommand` and `SortByPriorityCommand`.
        These commands can be bound to buttons in your view.When the user clicks the button, the corresponding command will be executed and the `TaskList` will be sorted accordingly.
                The sorting is done using LINQ's `OrderBy` and `OrderByDescending` methods. The `_isDateDescending` and `_isPriorityDescending` fields are used to keep track of the current sorting order.
                Each time the user clicks the button, the sorting order is toggled between ascending and descending.

        You can then bind these commands to buttons in your view like this:

        ```xaml
        <Button Content="Sort by Date" Command="{Binding SortByDateCommand}" />
        <Button Content = "Sort by Priority" Command= "{Binding SortByPriorityCommand}" />
        ```

        I hope this helps! Let me know if you have any questions or need further assistance.
            }

















        Sure! Here’s the complete example of the TaskViewModel class and the MainViewModel class that contains the ChangePriorityCommand and the properties for binding to the view:

public class TaskViewModel : INotifyPropertyChanged
{
    private PriorityLevel _priority;
    public PriorityLevel Priority
    {
        get => _priority;
        set
        {
            if (_priority != value)
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<TaskViewModel> TasksList { get; } = new ObservableCollection<TaskViewModel>();

    private TaskViewModel? _selectedTask;
    public TaskViewModel? SelectedTask
    {
        get => _selectedTask;
        set
        {
            if (_selectedTask != value)
            {
                _selectedTask = value;
                OnPropertyChanged(nameof(SelectedTask));
            }
        }
    }

    private ICommand? _changePriorityCommand;
    public ICommand ChangePriorityCommand
    {
        get
        {
            if (_changePriorityCommand == null)
            {
                _changePriorityCommand = new RelayCommand(
                    param =>
                    {
                        if (param is PriorityLevel newPriority && SelectedTask != null)
                        {
                            SelectedTask.Priority = newPriority;
                        }
                    },
                    param => SelectedTask != null
                );
            }
            return _changePriorityCommand;
        }
    }

    public IEnumerable<PriorityLevel> PriorityLevels => Enum.GetValues(typeof(PriorityLevel)).Cast<PriorityLevel>();

    private PriorityLevel _selectedPriority;
    public PriorityLevel SelectedPriority
    {
        get => _selectedPriority;
        set
        {
            if (_selectedPriority != value)
            {
                _selectedPriority = value;
                OnPropertyChanged(nameof(SelectedPriority));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
And here’s the complete example of the XAML code for the view:

<ListView ItemsSource="{Binding TasksList}" SelectedItem="{Binding SelectedTask}">
    <ListView.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding Priority}" />
        </DataTemplate>
    </ListView.ItemTemplate>
</ListView>
<ComboBox SelectedItem="{Binding SelectedPriority}" ItemsSource="{Binding PriorityLevels}">
    <ComboBox.ItemTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding}" />
        </DataTemplate>
    </ComboBox.ItemTemplate>
</ComboBox>
<Button Content="Change Priority" Command="{Binding ChangePriorityCommand}" CommandParameter="{Binding SelectedPriority}" />
This will display a list of tasks with their priorities and allow the user to select a task and change its priority using a ComboBox and a Button. The ChangePriorityCommand takes the selected priority as a parameter and sets the Priority property of the SelectedTask to the new priority. When the Priority property changes, the view will automatically update to reflect the change.

Is this what you were looking for?
        */
    }
}
