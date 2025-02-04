using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Tracker
{
    enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }

    class Task
    {
        public int Id;
        public string Title;
        public string Description;
        public DateTime DueDate;
        public string Priority;
        public TaskStatus Status = TaskStatus.Pending;
    }

    class TaskTracker
    {
        static List<Task> tasks = new List<Task>();
        static int taskIdCounter = 1;

        static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nTask Tracker");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. Update Task");
                Console.WriteLine("3. View Tasks");
                Console.WriteLine("4. Delete Task");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                if (choice == "1") AddTask();
                else if (choice == "2") UpdateTask();
                else if (choice == "3") ViewTasks();
                else if (choice == "4") DeleteTask();
                else if (choice == "5") running = !ConfirmExit();
                else Console.WriteLine("Invalid choice. Please try again.");
            }
        }

        static void AddTask()
        {
            Task newTask = new Task();
            newTask.Id = taskIdCounter++;

            Console.Write("Enter Task Title: ");
            newTask.Title = Console.ReadLine();
            Console.Write("Enter Task Description: ");
            newTask.Description = Console.ReadLine();
            Console.Write("Enter Due Date (yyyy-mm-dd): ");
            newTask.DueDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter Priority (Low/Medium/High): ");
            newTask.Priority = Console.ReadLine();

            tasks.Add(newTask);
            Console.WriteLine("Task added successfully!");
        }

        static void UpdateTask()
        {
            Console.Write("Enter Task ID to update: ");
            int id = int.Parse(Console.ReadLine());

            foreach (Task task in tasks)
            {
                if (task.Id == id)
                {
                    Console.Write("Enter new status (Pending/InProgress/Completed): ");
                    if (Enum.TryParse(Console.ReadLine(), out TaskStatus newStatus))
                    {
                        task.Status = newStatus;
                        Console.WriteLine("Task updated successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Invalid status. Please enter Pending, InProgress, or Completed.");
                    }
                    return;
                }
            }
            Console.WriteLine("Task not found.");
        }

        static void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            Console.WriteLine("\nTasks List:");
            foreach (Task task in tasks)
            {
                Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Due: {task.DueDate:yyyy-MM-dd}, Priority: {task.Priority}, Status: {task.Status}");
            }
        }

        static void DeleteTask()
        {
            Console.Write("Enter Task ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].Id == id)
                {
                    tasks.RemoveAt(i);
                    Console.WriteLine("Task deleted successfully!");
                    return;
                }
            }
            Console.WriteLine("Task not found.");
        }

        static bool ConfirmExit()
        {
            Console.Write("Are you sure you want to exit? (y/n): ");
            return Console.ReadLine().ToLower() == "y";
        }
    }
}
