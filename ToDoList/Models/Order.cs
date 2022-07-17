using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Order
  {
    public string Title { get; set; }
    public string OrderDescription { get; set; }
    public string Price { get; set; }
    public int Id { get; set; }
    public DateTime Date { get; private set; }

    public Order(string title, string orderDescription, string price)
    {
      Title = title;
      OrderDescription = orderDescription;
      this.Date = DateTime.Now;
      Price =price;
    }

    public static Order Find(Vendor vendor, int orderId)
    {
      foreach(var order in vendor.Orders)
      {
        if(order.Id == orderId)
          return order;
      }

      return null;
    }

  
  }
}
