using Newtonsoft.Json;
using ToDoLogic.Model;

namespace ConsoleToDos
{

    public static class FileWr
    {

        public static void Serialize(this Calendar model)
        {
            string filePath = @"taskList.json";
            List<TaskModel> taskList = new List<TaskModel>();
            DeserializeTasks();
            string json = JsonConvert.SerializeObject(taskList);
            File.WriteAllText(filePath , json);

        }

        public static List<TaskModel> DeserializeTasks()
        {
            string filePath = "taskList.json";
            List<TaskModel> taskList = new List<TaskModel>();
            if(File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                taskList = JsonConvert.DeserializeObject<List<TaskModel>>(json);
            }
            return taskList;
        }

    }
}