using System;

class Program
{
    static void Main(string[] args)
    {
        var manager = new TodoListManager();
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Todo List:");
            manager.ViewTodoItems();
            Console.WriteLine("\nOptions:");
            Console.WriteLine("1. Add a todo item");
            Console.WriteLine("2. Delete a todo item");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter the description of the new todo item: ");
                    var description = Console.ReadLine();
                    manager.AddTodoItem(description);
                    break;
                case "2":
                    Console.Write("Enter the ID of the todo item to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        manager.DeleteTodoItem(id);
                    }
                    else
                    {
                        Console.WriteLine("Invalid ID.");
                    }
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
