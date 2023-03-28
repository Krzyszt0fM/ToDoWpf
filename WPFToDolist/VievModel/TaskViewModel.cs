using System;
using System.Windows.Input;
using ToDoLogic.Model;

namespace WPFToDolist.VievModel
{
    public class TaskViewModel : ObservedObj
    {
        private readonly ToDoLogic.Model.TaskModel model;

        #region properties
        public string Duty
        {

            get
            {
                return model.Duty;
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
            set
            {
                if(model.Priority != value)
                {
                    model.Priority = value;
                    OnPropertyChanged(nameof(Priority));
                }
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

        public TaskViewModel(string duty , DateTime date , PriorityLevel priority , bool isDone)
        {
            model = new TaskModel(duty , date , priority , isDone);
        }

        //public taskviewmodel(string duty, datetime value, prioritylevel priority, bool v)
        //{
        //    duty1 = duty;
        //    value = value;
        //    priority1 = priority;
        //    v = v;
        //}

        public TaskModel GetModel()
        {
            return model;
        }
        public override string ToString()
        {
            return model.ToString();
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

        private readonly ICommand markAsUnDone;

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
        //public string Duty1 { get; }
        //public DateTime Value { get; }
        //public PriorityLevel Priority1 { get; }
        //public bool V { get; }
        #endregion


    }
}
