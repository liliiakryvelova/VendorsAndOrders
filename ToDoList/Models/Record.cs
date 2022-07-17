using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Record
  {
    public string Title { get; set; }
    public string Artist { get; set; }
    public int Id { get; }

    private static List<Record> _instances = new List<Record> { };


    public Record(string title, string artist)
    {
      Title = title;
      Artist = artist;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static List<Record> GetAll()
    {
      return _instances;
    }

    public static Record Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public static List<Artist> GetAllArtists()
    {
      List<Artist> artists = new List<Artist>  {};
      foreach (var item in _instances)
      {
        
        var artist = new Artist(item.Artist);
        artists.Add(artist);
      }

      return artists;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}
