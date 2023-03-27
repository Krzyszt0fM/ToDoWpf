namespace ToDoLogic.Model
{

    public enum PriorityLevel
    {
        Low,
        Medium,
        High
    }

    public class TaskModel
    {
        //private TaskModel taskModel;

        public string? Duty { get; set; }
        public int ID { get; set; }
        public DateOnly Date { get; set; }
        public PriorityLevel Priority { get; set; }
        public bool IsDone { get; set; }

        public TaskModel(string duty , int id , DateOnly date , PriorityLevel priority , bool isDone = false)
        {
            this.Duty = duty;
            this.ID = id;
            this.Date = date;
            this.Priority = priority;
            this.IsDone = isDone;
        }

        public TaskModel(TaskModel taskModel)
        {
        }

        //public TaskModel(TaskModel taskModel)
        //{
        //    this.taskModel = taskModel;
        //}

        public override string ToString()
        {
            return ID.ToString() + Duty + ", Date: " + Date.ToString() + ", priority: " + Priority + ", is task done: " + (IsDone ? "done" : "undone");
        }
    }
}



//    public class Calendar
//    {
//        public string fileName = @"taskList.json";
//        public List<TaskModel> Task { get; set; }
//        public Calendar()
//        {
//            Task = new List<TaskModel>();
//        }

//        public void AddTask(/*bool isDone , int id , DateOnly date , PriorityLevel priority , string? task ,*/ TaskModel taskModel)
//        {
//            Task.Add(taskModel);
//        }

//        public void DeleteTask(int idd)
//        {
//            var taskToRemove = Task.FirstOrDefault(t => t.ID == idd);
//            if(taskToRemove != null)
//            {
//                Task.Remove(taskToRemove);

//            }
//        }

//        public void ShowTasks(bool showDoneTasks = false)
//        {

//            var tasks = Task;

//            if(showDoneTasks)
//            {
//                tasks = tasks.Where(t => t.IsDone).ToList();
//            }

//            if(!tasks.Any())
//            {
//                return;
//            }
//        }

//        //public void MoveTask(int taskId)
//        //{
//        //    //deserializacja listy z pliku
//        //    var json = File.ReadAllText(fileName);
//        //    var taskList = JsonConvert.DeserializeObject<List<TaskModel>>(json);

//        //    //wybranie taska z odpowienim id
//        //    var taskToMove = taskList.FirstOrDefault(task => task.ID == taskId);


//        //}

//        public void IsDone(int taskId , bool isDone)
//        {
//            var taskToUpdate = Task.FirstOrDefault(t => t.ID == taskId);

//            if(taskToUpdate == null)
//            {
//                return;
//            }

//            taskToUpdate.IsDone = isDone;

//            // Serialize the updated task list
//        }

//        public void SortTasks(string sortChoice)
//        {

//            switch(sortChoice)
//            {
//                case "1":
//                    Task = Task.OrderBy(t => t.ID).ToList();
//                    break;
//                case "2":
//                    Task = Task.OrderByDescending(t => t.ID).ToList();
//                    break;
//                case "3":
//                    Task = Task.OrderBy(t => t.Priority).ToList();
//                    break;
//                case "4":
//                    Task = Task.OrderByDescending(t => t.Priority).ToList();
//                    break;
//                case "5":
//                    Task = Task.OrderBy(t => t.Date).ToList();
//                    break;
//                case "6":
//                    Task = Task.OrderByDescending(t => t.Date).ToList();
//                    break;
//                default:
//                    return;
//            }
//        }

//        public void changePriority(int taskId , PriorityLevel priority)
//        {
//            var taskToUpdate = Task.FirstOrDefault(t => t.ID == taskId);

//            if(taskToUpdate == null)
//            {
//                return;
//            }
//            int newPriority = int.Parse(Console.ReadLine());

//            taskToUpdate.Priority = priority;
//        }
//    }
//}