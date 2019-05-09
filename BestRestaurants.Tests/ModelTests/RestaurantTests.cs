using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurants.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurants.TestTools
{
  [TestClass]
  public class RestaurantTest : IDisposable
  {
    public void Dispose()
    {
      Restaurant.ClearAll();
    }

    public RestaurantTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best-restaurants-tests;";
    }

    [TestMethod]
    public void RestaurantConstructor_CreatesInstanceOfRestaurant_Restaurant()
    {
      Restaurant newRestaurant = new Restaurant("test", 1);
      Assert.AreEqual(typeof(Restaurant), newRestaurant.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnsName_String()
    {
      string name = "Best Thai";
      Restaurant newRestaurant = new Restaurant(name, 1);
      string result = newRestaurant.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_RestaurantList()
    {
      List<Restaurant> newList = new List<Restaurant> { };
      List<Restaurant> result = Restaurant.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRestaurants_RestaurantList()
    {
      string name01 = "Walk the dog";
      string name02 = "Wash the dishes";
      Restaurant newRestaurant1 = new Restaurant(name01, 1);
      newRestaurant1.Save();
      Restaurant newRestaurant2 = new Restaurant(name02, 2);
      newRestaurant2.Save();
      List<Restaurant> newList = new List<Restaurant> { newRestaurant1, newRestaurant2 };
      List<Restaurant> result = Restaurant.GetAll();
      Console.WriteLine("hi");
      Console.WriteLine("this line " +newList[0].GetCuisineId() + " " + result[0].GetCuisineId());
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectRestaurantFromDatabase_Restaurant()
    {
      Restaurant testRestaurant = new Restaurant("Burger King", 1);
      testRestaurant.Save();
      Restaurant foundRestaurant = Restaurant.Find(testRestaurant.GetId());
      Assert.AreEqual(testRestaurant, foundRestaurant);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNamesAreTheSame_Restaurant()
    {
      Restaurant firstRestaurant = new Restaurant("Chipotle", 1);
      Restaurant secondRestaurant = new Restaurant("Chipotle", 1);
      Assert.AreEqual(firstRestaurant, secondRestaurant);
    }

    [TestMethod]
    public void Save_SavesToDatabase_RestaurantList()
    {
      Restaurant testRestaurant = new Restaurant("Chipotle", 1);
      testRestaurant.Save();
      List<Restaurant> result = Restaurant.GetAll();
      List<Restaurant> testList = new List<Restaurant>{testRestaurant};
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Chipotle", 1);

      //Act
      testRestaurant.Save();
      Restaurant savedRestaurant = Restaurant.GetAll()[0];

      int result = savedRestaurant.GetId();
      int testId = testRestaurant.GetId();

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Edit_UpdatesRestaurantInDatabase_String()
    {
      //Arrange
      Restaurant testRestaurant = new Restaurant("Chipotle", 1);
      testRestaurant.Save();
      string secondName = "Panda Express";
      testRestaurant.Edit(secondName);
      string result = Restaurant.Find(testRestaurant.GetId()).GetName();
      Assert.AreEqual(secondName, result);
    }
  }
}
