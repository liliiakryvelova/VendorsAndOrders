using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Vendor
  {
    private static List<Vendor> _instances = new List<Vendor> {};
    public string VendorName { get; set; }
    public string Description { get; set; }
    public int Id { get; }
    public List<Order> Orders { get; set; }

    public Vendor(string vendorName, string description)
    {
      VendorName = vendorName;
      Description = description;
      Id = _instances.Count+1;
      Orders = new List<Order>{};
      _instances.Add(this);
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Vendor> GetAll()
    {
      return _instances;
    }

     public void ClearAllOrders()
    {
      Orders.Clear();
    }

    public void DeleteOrder(int orderId)
    {
      var order = Order.Find(this, orderId);
      Orders.Remove(order);    
    }

    public List<Order> GetAllOrders()
    {

      return Orders;
    }

    public static Vendor Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddOrder(Order order)
    {
        order.Id = Orders.Count+1;
        Orders.Add(order);
    }

  }
}