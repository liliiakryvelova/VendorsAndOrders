using Microsoft.AspNetCore.Mvc;
using System;
using ToDoList.Models;
using System.Collections.Generic;


namespace ToDoList.Controllers
{
  public class OrdersController : Controller
  {
    [HttpGet("/vendors/{vendorId}/orders/{id}")]
    public ActionResult Show(int vendorId, int id)
    {
      Vendor vendor = Vendor.Find(vendorId);
      Order order = Order.Find(vendor, id);
      return View(order);
    }

    [HttpGet("vendors/{vendorId}/orders/new")]
    public ActionResult New(int vendorId)
    {
      Vendor selectedVendor = Vendor.Find(vendorId);
      return View(selectedVendor);
    }

    [HttpPost("vendors/{vendorId}/orders/delete")]
    public ActionResult DeleteAll(int vendorId)
    {
      Vendor selectedVendor = Vendor.Find(vendorId);
      selectedVendor.ClearAllOrders();
      return View();
    }

    [HttpPost("vendors/{vendorId}/orders/{id}/delete")]
    public ActionResult Delete(int vendorId, int id)
    {
      Vendor selectedVendor = Vendor.Find(vendorId);
      selectedVendor.DeleteOrder(id);
      return RedirectToAction("Index", selectedVendor);
    }
  }
}