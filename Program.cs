using System;
using System.Collections.Generic;

class Program
{
     static int taskIdCounter = 1;
    // Enum para as opções do usuário
    enum UserChoice
    {
        AddTask = 1,
        DeleteTask = 2,
        ListTasks = 3,
        Exit
    }

    static void Main(string[] args)
    {
        // Lista de tarefas
        List<(int Id, string Task)> todDoList = new List<(int, string)>();

        while (true)
        {
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Delete Task");
            Console.WriteLine("3. List Tasks");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");

            // Tentar fazer o parsing da escolha do usuário
            int choice;
            bool isValidChoice = int.TryParse(Console.ReadLine(), out choice);

            // Verifica se a escolha é válida
            if (!isValidChoice)
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            // Se a escolha for para adicionar uma tarefa
            if (choice == (int)UserChoice.AddTask)
            {
                Console.WriteLine("Enter task: ");
                string task = Console.ReadLine();
                todDoList.Add((taskIdCounter++, task));
                Console.Clear();
                Console.WriteLine("Task added successfully!");
            }

            else if (choice == (int)UserChoice.DeleteTask)
            {
                Console.Write("Enter the ID of the task to delete: ");
                if (int.TryParse(Console.ReadLine(), out int taskId))
                {
                    var taskToDelete = todDoList.FirstOrDefault(t => t.Id == taskId);

                    if (taskToDelete != default)
                    {
                        todDoList.Remove(taskToDelete);
                        Console.Clear();
                        Console.WriteLine("Task deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Task not found!");
                    }

                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                
                Console.WriteLine("\n Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }

            else if (choice == (int)UserChoice.ListTasks)
            {
                Console.Clear();
                Console.WriteLine("Your Tasks:");

                if (todDoList.Count == 0)
                {
                    Console.WriteLine("No tasks available");
                }
                else
                {
                    foreach (var task in todDoList)
                    {
                         Console.WriteLine($"ID: {task.Id}, Task: {task.Task}");

                    }
                }

                Console.WriteLine("\n Press any key to continue...");
                Console.ReadKey();
                Console.Clear();

            }


            // Se a escolha for para sair
            else if (choice == (int)UserChoice.Exit)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid option, please choose again.");
            }


        }

        //     // Opcionalmente, mostrar as tarefas quando o programa terminar
        //     Console.WriteLine("Your Tasks:");
        //     foreach (var task in todDoList)
        //     {
        //         Console.WriteLine($"- {task}");
        //     }
    }
}
