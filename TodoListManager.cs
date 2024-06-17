using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TodoListManager
{
    private List<TodoItem> _todoItems;
    private const string FilePath = "todoItems.txt";

    public TodoListManager()
    {
        _todoItems = LoadTodoItems();
    }

    public void AddTodoItem(string description)
    {
        int newId = _todoItems.Any() ? _todoItems.Max(item => item.Id) + 1 : 1;
        _todoItems.Add(new TodoItem { Id = newId, Description = description });
        SaveTodoItems();
    }

    public void DeleteTodoItem(int id)
    {
        _todoItems = _todoItems.Where(item => item.Id != id).ToList();
        SaveTodoItems();
    }

    public void ViewTodoItems()
    {
        foreach (var item in _todoItems)
        {
            Console.WriteLine(item);
        }
    }

    private void SaveTodoItems()
    {
        var lines = _todoItems.Select(item => $"{item.Id}|{item.Description}|{item.IsCompleted}");
        File.WriteAllLines(FilePath, lines);
    }

    private List<TodoItem> LoadTodoItems()
    {
        if (!File.Exists(FilePath))
        {
            return new List<TodoItem>();
        }

        var lines = File.ReadAllLines(FilePath);
        return lines.Select(line =>
        {
            var parts = line.Split('|');
            return new TodoItem
            {
                Id = int.Parse(parts[0]),
                Description = parts[1],
                IsCompleted = bool.Parse(parts[2])
            };
        }).ToList();
    }
}
