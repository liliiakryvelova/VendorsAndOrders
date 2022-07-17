using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
  public class VendorsController : Controller
  {
    [HttpGet("/vendors")]
    public ActionResult Index()
    {
      List<Vendor> allVendors = Vendor.GetAll();
      return View(allVendors);
    }

    [HttpPost("/vendors")]
    public ActionResult Create(string vendorName, string description)
    {
      Vendor newVendor = new Vendor(vendorName, description);
      return RedirectToAction("Index");
    }

    [HttpPost("/vendors/{vendorId}/orders")]
    public ActionResult Create(string ordername, string orderdescription, string price, int vendorId)
    {
      Vendor selectedVendor = Vendor.Find(vendorId);
      Order myOrder = new Order(ordername, orderdescription, price);
      selectedVendor.AddOrder(myOrder);
      return View("Show", selectedVendor);
    }

    [HttpGet("/vendors/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpGet("/vendors/{id}")]
    public ActionResult Show(int id)
    {
      Vendor selectedVendor = Vendor.Find(id);
       return View(selectedVendor);
    }

  }
}