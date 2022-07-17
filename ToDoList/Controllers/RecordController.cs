using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/records/{id}")]
    public ActionResult Show(int id)
    {
      Record foundRecord = Record.Find(id);
      return View(foundRecord);
    }

    [HttpPost("/records/delete")]
    public ActionResult DeleteAll()
    {
      Record.ClearAll();
      return View();
    }

    [HttpGet("/records")]
    public ActionResult Index()
    {
      List<Record> allRecords = Record.GetAll();
      return View(allRecords);
    }

    [HttpGet("/records/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/records")]
    public ActionResult Create(string title, string artist)
    {
      Record myRecords = new Record(title, artist);
      return RedirectToAction("Index");
    }

  }
}