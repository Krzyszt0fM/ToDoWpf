using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using ToDoLogic.Model;

namespace WPFToDolist.VievModel
{

    public class TasksViewModels : ObservedObj
    {
        public ToDoLogic.Model.Calendar model;
        public ObservableCollection<TaskViewModel> TasksList { get; } = new ObservableCollection<TaskViewModel>();
        private void CopyTasksFromModel()
        {
            TasksList.CollectionChanged -= ModelSync;
            TasksList.Clear();
            foreach(TaskModel taskModel in model)
            {
                TasksList.Add(new TaskViewModel(taskModel));
            }
            TasksList.CollectionChanged += ModelSync;
        }

        //public TasksViewModels()
        //{
        //    //model = new Calendar(model);


        //    //model.AddTask(new("sto dwadziescia piemc", DateTime.MinValue, PriorityLevel.High));
        //    //model.AddTask(new("dwa",  DateTime.MaxValue, PriorityLevel.Medium));
        //    //model.AddTask(new("trzy", DateTime.MinValue, PriorityLevel.Low));



        //    CopyTasksFromModel();
        //}

        public void ModelSync(object? sender , NotifyCollectionChangedEventArgs e)
        {
            switch(e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    TaskViewModel newTask = (TaskViewModel)e.NewItems[0];
                    if(newTask != null)
                    {
                        model.AddTask(newTask.GetModel());
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    TaskViewModel deletedTask = (TaskViewModel)e.OldItems[0];
                    if(deletedTask != null)
                    {
                        model.RemoveTask(deletedTask.GetModel());
                    }
                    break;
            }
        }

        private ICommand deleteTask;

        public ICommand DeleteTask
        {
            get
            {
                if(deleteTask == null) deleteTask = new ViewModelCommand(
                o =>
                {
                    int id = (int)o;
                    TaskViewModel task = TasksList[id];
                    TasksList.Remove(task);
                } ,
                o =>
                {
                    if(o == null) return false;
                    int id = (int)o;
                    return id >= 0;
                }
                );
                return deleteTask;
            }
        }

        private ICommand addTask;

        public ICommand AddTask
        {
            get
            {
                if(addTask == null) addTask = new ViewModelCommand(
                o =>
                {

                    TaskViewModel duty = o as TaskViewModel;
                    if(duty != null) TasksList.Add(duty);

                } ,
                o =>
                {
                    return (o as TaskViewModel) != null;
                }
                );
                return addTask;
            }
        }

        private ICommand sortCommand;
        public ICommand SortCommand
        {
            get
            {
                if(sortCommand == null)
                {
                    sortCommand = new ViewModelCommand(
                        o =>
                        {
                            string sortType = o as string;
                            if(sortType != null)
                            {
                                IEnumerable<TaskViewModel> sortedTasks = null;
                                switch(sortType)
                                {
                                    case "DateAsc":
                                        sortedTasks = TasksList.OrderBy(t => t.Date);
                                        break;
                                    case "DateDesc":
                                        sortedTasks = TasksList.OrderByDescending(t => t.Date);
                                        break;
                                    case "PriorityAsc":
                                        sortedTasks = TasksList.OrderBy(t => t.Priority);
                                        break;
                                    case "PriorityDesc":
                                        sortedTasks = TasksList.OrderByDescending(t => t.Priority);
                                        break;
                                }
                                if(sortedTasks != null)
                                {
                                    var tempTasksList = new ObservableCollection<TaskViewModel>(sortedTasks);
                                    for(int i = 0;i < tempTasksList.Count;i++)
                                    {
                                        int oldIndex = TasksList.IndexOf(tempTasksList[i]);
                                        if(oldIndex != i)
                                            TasksList.Move(oldIndex , i);
                                    }
                                }
                            }
                        } ,
                        o => (o as string) != null
                    );
                }
                return sortCommand;
            }
        }

        private ICommand changePriorityCommand;
        public ICommand ChangePriorityCommand
        {
            get
            {
                if(changePriorityCommand == null)
                {
                    changePriorityCommand = new ViewModelCommand(
                        o =>
                        {
                            var parameters = o as object[];
                            if(parameters != null && parameters.Length == 2)
                            {
                                var task = parameters[0] as TaskViewModel;
                                var priority = (PriorityLevel)parameters[1];
                                if(task != null)
                                {
                                    task.Priority = priority;
                                }
                            }
                        } ,
                        o => true
                    );
                }
                return changePriorityCommand;
            }
        }
    }
}