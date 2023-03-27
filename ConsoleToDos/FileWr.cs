using Newtonsoft.Json;
using ToDoLogic.Model;

namespace ConsoleToDos
{

    public static class FileWr
    {
        public static void Serialize()
        {
            List<TaskModel> tasks = new List<TaskModel>(); ;
            DeserializeTasks();
            string json = JsonConvert.SerializeObject(tasks);
            File.WriteAllText(@"taskList.json" , json);

        }

        public static List<TaskModel> DeserializeTasks()
        {
            List<TaskModel> tasks = new List<TaskModel>();
            if(File.Exists(@"taskList.json"))
            {
                string json = File.ReadAllText(@"taskList.json");
                tasks = JsonConvert.DeserializeObject<List<TaskModel>>(json);
            }
            return tasks;
        }

    }
}