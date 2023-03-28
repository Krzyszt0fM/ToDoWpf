using System;
using System.Windows.Input;
using ToDoLogic.Model;

namespace WPFToDolist.VievModel
{
    public class TaskViewModel : ObservedObj
    {
        private ToDoLogic.Model.TaskModel model;

        #region properties
        public string Duty
        {

            get
            {
                return model.Duty;
            }
        }
        public int ID
        {
            get
            {
                return model.ID;
            }
        }
        public DateTime Date
        {
            get
            {
                return model.Date;
            }
        }
        public PriorityLevel Priority
        {
            get
            {
                return model.Priority;
            }
        }
        public bool IsDone
        {
            get
            {
                return model.IsDone;
            }
        }
        #endregion
        public TaskViewModel(TaskModel model)
        {
            this.model = model;
        }

        public TaskViewModel(string duty , int id , DateTime date , PriorityLevel priority , bool isDone)
        {
            model = new TaskModel(duty , id , date , priority , isDone);
        }

        public TaskViewModel(string duty , DateTime value , PriorityLevel priority , bool v)
        {
            Duty1 = duty;
            Value = value;
            Priority1 = priority;
            V = v;
        }

        public TaskModel GetModel()
        {
            return model;
        }
        #region commands
        private ICommand markAsDone;

        public ICommand MarkAsDone
        {
            get
            {
                if(markAsDone == null) markAsDone = new ViewModelCommand
                (o =>
                {
                    model.IsDone = true;
                    OnPropertyChanged(nameof(MarkAsDone));
                } ,
                o =>
                {
                    return !model.IsDone;
                }
                );
                return markAsDone;
            }
        }

        private ICommand markAsUnDone;

        public ICommand MarkAsUnDone
        {
            get
            {
                if(markAsDone == null) markAsDone = new ViewModelCommand
                (o =>
                {
                    model.IsDone = false;
                    OnPropertyChanged(nameof(MarkAsUnDone));
                } ,
                o =>
                {
                    return model.IsDone;
                }
                );
                return markAsUnDone;
            }
        }

        public string Duty1 { get; }
        public DateTime Value { get; }
        public PriorityLevel Priority1 { get; }
        public bool V { get; }
        #endregion

        public override string ToString()
        {
            return model.ToString();
        }
    }
}
