using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

  [TestMethod]
  public void GetName_ReturnsName_String()
  {
    //Arrange
    string vendorname = "Vendor 1";
    string description = "Sell apples";
    Vendor newVendor = new Vendor(vendorname, description);

    //Act
    string result = newVendor.VendorName;

    //Assert
    Assert.AreEqual(vendorname, result);
  }

  //Test that we can retrieve Vendor IDs
  [TestMethod]
  public void GetId_ReturnsVendorId_Int()
  {
    //Arrange
    string vendorname = "Vendor 1";
    string description = "Sell apples";
    Vendor newVendor = new Vendor(vendorname, description);

    //Act
    int result = newVendor.Id;

    //Assert
    Assert.AreEqual(1, result);
  }

  [TestMethod]
  public void GetAll_ReturnsAllVendorObjects_VendortList()
  {
    //Arrange
    string vendorname = "Vendor 1";
    string description = "Sell apples";
    Vendor newVendor1 = new Vendor(vendorname, description);
    string vendorname2 = "Vendor 1";
    string description2 = "Sell apples";
    Vendor newVendor2 = new Vendor(vendorname2, description2);
    List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

    //Act
    List<Vendor> result = Vendor.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }

  [TestMethod]
  public void Find_ReturnsCorrectVendor_Vendor()
  {
    //Arrange
    string vendorname = "Vendor 1";
    string description = "Sell apples";
    Vendor newVendor1 = new Vendor(vendorname, description);
    string vendorname2 = "Vendor 1";
    string description2 = "Sell apples";
    Vendor newVendor2 = new Vendor(vendorname2, description2);

    //Act
    Vendor result = Vendor.Find(2);

    //Assert
    Assert.AreEqual(newVendor2, result);
  }

  [TestMethod]
  public void AddOrder_AssociatesOrderWithVendor_List()
  {

    //Arrange
    string vendorname = "Vendor 1";
    string description = "Sell apples";
    Vendor newVendor1 = new Vendor(vendorname, description);
    string title = "Bread.";
    string orderDescription = "Sell apples";
    string price = "10";
    Order newOrder = new Order(title, orderDescription, price);
    List<Order> newList = new List<Order> { newOrder };
    newVendor1.AddOrder(newOrder);
    

    //Act
    List<Order> result = newVendor1.Orders;

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }

  }
}