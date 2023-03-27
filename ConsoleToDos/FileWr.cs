using Newtonsoft.Json;
using ToDoLogic.Model;

namespace ConsoleToDos
{

    public static class FileWr
    {
        public static void Serialize(this TaskModel model)
        {
            List<TaskModel> taskList = new List<TaskModel>();
            DeserializeTasks();
            string json = JsonConvert.SerializeObject(taskList);
            File.WriteAllText(@"taskList.json" , json);

        }

        public static List<TaskModel> DeserializeTasks()
        {
            List<TaskModel> taskList = new List<TaskModel>();
            if(File.Exists(@"taskList.json"))
            {
                string json = File.ReadAllText(@"taskList.json");
                taskList = JsonConvert.DeserializeObject<List<TaskModel>>(json);
            }
            return taskList;
        }

    }
}