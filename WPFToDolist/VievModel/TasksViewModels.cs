using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using ToDoLogic.Model;

namespace WPFToDolist.VievModel
{

    public class TasksViewModels
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

        public TasksViewModels()
        {
            model = new Calendar(model);


            model.AddTask(new("sto dwadziescia piemc" , 1 , DateOnly.MinValue , PriorityLevel.High));
            model.AddTask(new("dwa" , 2 , DateOnly.MaxValue , PriorityLevel.Medium));
            model.AddTask(new("trzy" , 3 , DateOnly.MinValue , PriorityLevel.Low));



            CopyTasksFromModel();
        }

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


    }
}
