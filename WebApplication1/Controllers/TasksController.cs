using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

public class TasksController : Controller
{
    private static List<TaskModel> _tasks = new List<TaskModel>();

    public IActionResult Index()
    {
        return View(_tasks);
    }

    [HttpPost]
    public IActionResult AddTask(string title)
    {
        var newTask = new TaskModel
        {
            Id = _tasks.Count + 1,
            Title = title,
            IsCompleted = false
        };

        _tasks.Add(newTask);

        return RedirectToAction("Index");
    }

    public IActionResult ToggleTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = !task.IsCompleted;
        }

        return RedirectToAction("Index");
    }

    public IActionResult DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            _tasks.Remove(task);
        }

        return RedirectToAction("Index");
    }
}
