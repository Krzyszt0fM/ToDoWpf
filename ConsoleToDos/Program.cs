using ConsoleToDos;
using ToDoLogic.Model;

class Program
{
    static void Main(string[] args)
    {

        int id = 1;

        FileWr.DeserializeTasks();

        while(true)
        {
            Console.WriteLine("Press 1 to add task:\n" +
            "Press 2 to remove task:\n" +
            "Press 3 to show all tasks:\n" +
            "Press 4 to move task to another date:\n" +
            "Press 5 to change mark task as done or undone:\n" +
            "Press 6 to change prirority\n" +
            "Press 7 to sort tasks:\n" +
            "Press 8 to exit");

            string? choice = Console.ReadLine();
            Console.Clear();
            switch(choice)
            {
                case "1":
                {
                    Console.Write("Enter task description: ");
                    string? task = Console.ReadLine();
                    Console.Write("Enter task date (yyyy-mm-dd): ");
                    DateOnly date = DateOnly.Parse(Console.ReadLine());
                    bool IsDone = false;
                    Console.Write("Enter task priority 0 - Low 1 - Medium 2 - High: ");
                    PriorityLevel priority = (PriorityLevel)Enum.Parse(typeof(PriorityLevel) , Console.ReadLine());
                    //myTaskModel.AddTask();
                    id++;
                    break;
                }

                case "2":
                {
                    //myTaskModel.ShowTasks();
                    Console.WriteLine("Enter a task index from the list above:");
                    int idd = int.Parse(Console.ReadLine());
                    //myTaskModel.DeleteTask(idd);
                    Console.ReadKey();
                    break;
                }


                case "3":
                {
                    Console.WriteLine("There are all of yours tasks");
                    Console.WriteLine("Press 1 to show all tasks, 2 to show done tasks only, or 3 to show undone tasks only:");
                    string showOption = Console.ReadLine();
                    bool showDoneTasks;
                    switch(showOption)
                    {
                        case "1":
                            break;
                        case "2":
                            showDoneTasks = true;
                            break;
                        case "3":
                            showDoneTasks = false;
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;

                    }
                    //myTaskModel.ShowTasks();
                    break;
                }

                //case "4":
                //{
                //    myTaskModel.ShowTasks();
                //    Console.WriteLine("Enter a task index from list above");
                //    int taskId = int.Parse(Console.ReadLine());
                //    myTaskModel.MoveTask(taskId);
                //    break;
                //}

                case "5":
                {
                    Console.Write("Enter task ID: ");
                    int taskId = int.Parse(Console.ReadLine());
                    Console.Write("Is task done? (Y/N): ");
                    //bool isDone = Console.ReadLine().ToLower() == "y";
                    //myTaskModel.IsDone(taskId , isDone);
                    break;
                }

                case "6":
                {
                    //myTaskModel.ShowTasks();
                    Console.WriteLine("Enter the ID of the task you want to change the priority for:");
                    int taskId = int.Parse(Console.ReadLine());
                    PriorityLevel priority = (PriorityLevel)Enum.Parse(typeof(PriorityLevel) , Console.ReadLine());
                    //myTaskModel.changePriority(taskId , priority);
                    break;
                }

                case "7":
                {
                    ;
                    Console.WriteLine("Press 1 to sort by ID ascending\n" +
                    "Press 2 to sort by ID descending\n" +
                    "Press 3 to sort by priority ascending\n" +
                    "Press 4 to sort by priority descending\n" +
                    "Press 5 to sort by date ascending\n" +
                    "Press 6 to sort by date descending");
                    string? sortChoice = Console.ReadLine();
                    //myTaskModel.SortTasks(sortChoice);
                    break;

                }

                case "8":
                {
                    Console.WriteLine("Thank you For using this app! \nPress any key to exit.");
                    Environment.Exit(0);
                    Console.ReadKey();
                    break;
                }


                default:
                {
                    Console.WriteLine("Invalid key, try again but this time use correct. From 1-7.");
                    continue;

                }
            }
            //FileWr.Serialize();
        }
    }
}





