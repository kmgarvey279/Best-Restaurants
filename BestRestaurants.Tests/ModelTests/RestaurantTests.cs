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
  }
}
