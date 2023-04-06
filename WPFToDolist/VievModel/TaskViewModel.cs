using System;
using System.Windows.Input;
using ToDoLogic.Model;

namespace WPFToDolist.VievModel
{
    //KLASA TESTOWA DO SPRAWDZENIA JAK TO ZADZIALA




    public class TaskViewModel : ObservedObj
    {
        //TA KLASA JEST DO OBLSUGI POJEDYNCZEGO WYBRANEGO ZADANIA, NP DO EDYCJI!!!!!

        private readonly ToDoLogic.Model.TaskModel model;

        #region properties
        public string Duty
        {

            get
            {
                return model.Duty;
            }
        }

        public DateTime CreationDate
        {
            get
            {
                return model.CreationDate;
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

        public bool IsStayedUndone
        {
            get
            {
                return !IsDone && (DateTime.Now > Date);
            }
        }
        #endregion
        public TaskViewModel(TaskModel model)
        {
            this.model = model;
        }

        public TaskViewModel(string duty , DateTime creationDate , DateTime date , PriorityLevel priority , bool isDone)
        {
            model = new TaskModel(duty , creationDate , date , priority , isDone);
        }



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
                    OnPropertyChanged(nameof(MarkAsDone) , nameof(IsStayedUndone));
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
                if(markAsUnDone == null) markAsUnDone = new ViewModelCommand
                (o =>
                {
                    model.IsDone = false;
                    OnPropertyChanged(nameof(MarkAsUnDone) , nameof(IsStayedUndone));
                } ,
                o =>
                {
                    return model.IsDone;
                }
                );
                return markAsUnDone;
            }
        }
        #endregion
    }

    //    public class MainWindowViewModel
    //    {
    //        public ICommand BtnStartCommand { get; set; }
    //        public ICommand WindowMouseDownCommand { get; set; }
    //        public ICommand BtnMinimizeCommand { get; set; }
    //        public ICommand BtnCloseCommand { get; set; }
    //        public ICommand TaskListSelectionChangedCommand { get; set; }
    //        public ICommand CmEditCommand { get; set; }

    //        public MainWindowViewModel()
    //        {
    //            BtnStartCommand = new ViewModelCommand(BtnStart);
    //            WindowMouseDownCommand = new ViewModelCommand<MouseEventArgs>(Window_MouseDown);
    //            BtnMinimizeCommand = new ViewModelCommand(BtnMinimize);
    //            BtnCloseCommand = new ViewModelCommand(BtnClose);
    //            TaskListSelectionChangedCommand = new ViewModelCommand<SelectionChangedEventArgs>(TaskList_SelectionChanged);
    //            CmEditCommand = new ViewModelCommand(CmEdit);

    //        }
    //        private void BtnStart()
    //        {
    //            // Navigate to MainWindow

    //            var MainWindow = new MainWindow();
    //            MainWindow.Show();
    //            Close();
    //        }

    //        private void Window_MouseDown(MouseEventArgs e)
    //        {
    //            if(e.LeftButton == MouseButtonState.Pressed)
    //                DragMove();
    //        }

    //        private void BtnMinimize()
    //        {
    //            WindowState = WindowState.Minimized;
    //        }

    //        private void BtnClose()
    //        {
    //            Application.Current.Shutdown();
    //        }

    //        private void TaskList_SelectionChanged(SelectionChangedEventArgs e)
    //        {

    //        }

    //        private void CmEdit()
    //        {

    //        }
    //    }
    //}
}
