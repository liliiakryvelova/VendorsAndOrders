using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ArtistsController : Controller
  {
    [HttpGet("/artists")]
    public ActionResult Index()
    {
      List<Artist> allArtists = Record.GetAllArtists();
      return View(allArtists);
    }

    [HttpPost("/artists")]
    public ActionResult Create(string ArtistName)
    {
      Artist newArtist = new Artist(ArtistName);
      return RedirectToAction("Index");
    }

    [HttpGet("/artists/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Artist selectedArtist = Artist.Find(id);
      List<Record> artistRecords = selectedArtist.Records;
      model.Add("artist", selectedArtist);
      model.Add("records", artistRecords);
      return View(model);
    }

  }
}