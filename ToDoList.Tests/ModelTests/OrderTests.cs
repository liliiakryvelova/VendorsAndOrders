using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class OrderTests
  {

    [TestMethod]
    public void OrderConstructor_CreatesInstanceOfOrder_Order()
    {
      string title = "Bread.";
      string orderDescription = "Sell apples";
      string price = "10";
      Order newOrder = new Order(title, orderDescription, price);
      Assert.AreEqual(typeof(Order), newOrder.GetType());
    }

    [TestMethod]
    public void SetTitle_ReturnsTitle_String()
    {
      //Arrange
      string title = "Bread.";
      string orderDescription = "Sell apples";
      string price = "10";

      //Act
      
      Order newOrder = new Order(title, orderDescription, price);
      string result = newOrder.Title;

      //Assert
      Assert.AreEqual(title, result);
    }

      [TestMethod]
      public void GetAll_ReturnsEmptyList_OrderList()
      {
        // Arrange
        string vendorname = "Vendor 1";
        string description = "Sell apples";
        Vendor newVendor1 = new Vendor(vendorname, description);
        

        // Act
        List<Order> result = newVendor1.GetAllOrders();

        // Assert
        Assert.AreEqual(0, result.Count);
      }

      [TestMethod]
      public void GetAllOrders_ReturnsOrders_OrderList()
      {
        //Arrange
        string vendorname = "Vendor 1";
        string description = "Sell apples";
        Vendor newVendor1 = new Vendor(vendorname, description);
        string title1 = "Bread.";
        string orderDescription1 = "Sell apples";
        string price1 = "10";
        Order newOrder1 = new Order(title1, orderDescription1, price1);
        string title2 = "Bread.";
        string orderDescription2 = "Sell apples";
        string price2 = "10";
        Order newOrder2 = new Order(title2, orderDescription2, price2);
        newVendor1.AddOrder(newOrder1);
        newVendor1.AddOrder(newOrder2);


        //Act
        List<Order> result = newVendor1.GetAllOrders();

        //Assert
        CollectionAssert.AreEqual(newVendor1.Orders, result);
      }

    [TestMethod]
    public void GetId_OrderssInstantiateWithAnIdAndGetterReturns_Int()
    {
      //Arrange
      string vendorname = "Vendor 1";
      string description = "Sell apples";
      Vendor newVendor1 = new Vendor(vendorname, description);

      string title1 = "Bread.";
      string orderDescription1 = "Sell apples";
      string price1 = "10";
      Order newOrder1 = new Order(title1, orderDescription1, price1);
      newVendor1.AddOrder(newOrder1);

      string title2 = "Bread.";
      string orderDescription2 = "Sell apples";
      string price2 = "10";
      Order newOrder2 = new Order(title2, orderDescription2, price2);
      newVendor1.AddOrder(newOrder2);

      //Act
      Order result = Order.Find(newVendor1, newOrder1.Id);

      //Assert
      Assert.AreEqual(newOrder1, result);
    }

//     [TestMethod]
//     public void Find_ReturnsCorrectItem_Item()
//     {
//       //Arrange
//       string description01 = "Walk the dog";
//       string description02 = "Wash the dishes";
//       Item newItem1 = new Item(description01);
//       Item newItem2 = new Item(description02);

//       //Act
//       Item result = Item.Find(2);

//       //Assert
//       Assert.AreEqual(newItem2, result);
//     }
  }
}