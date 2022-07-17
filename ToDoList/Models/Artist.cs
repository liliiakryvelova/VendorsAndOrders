using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Artist
  {
    private static List<Artist> _instances = new List<Artist> {};
    public string ArtistName { get; set; }
    public int Id { get; }
    public List<Record> Records { get; set; }

    public Artist(string artistName)
    {
      ArtistName = artistName;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }


  }
}