using Microsoft.VisualStudio.TestTools.UnitTesting;
using BestRestaurants.Models;
using System.Collections.Generic;
using System;

namespace BestRestaurants.TestTools
{
  [TestClass]
  public class CuisineTest : IDisposable
  {

    public CuisineTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=best-restaurants-tests;";
    }

    public void Dispose()
    {
      Cuisine.ClearAll();
    }

    [TestMethod]
    public void CuisineConstructor_CreatesInstanceOfCuisine_Cuisine()
    {
      Cuisine newCuisine = new Cuisine("name", 1);
      Assert.AreEqual(typeof(Cuisine), newCuisine.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Test Cuisine";
      Cuisine newCuisine = new Cuisine(name, 1);
      string result = newCuisine.GetName();
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllCuisineObjects_CuisineList()
    {
      string name01 = "Thai";
      string name02 = "Italian";
      Cuisine newCuisine1 = new Cuisine(name01, 1);
      newCuisine1.Save();
      Cuisine newCuisine2 = new Cuisine(name02, 2);
      newCuisine2.Save();
      List<Cuisine> newList = new List<Cuisine> { newCuisine1, newCuisine2 };
      List<Cuisine> result = Cuisine.GetAll();
      // Console.WriteLine("hi");
      // Console.WriteLine("this line " +newList.Count + " " + result.Count);
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCuisineInDatabase_Cuisine()
    {
      Cuisine testCuisine = new Cuisine("Chinese", 1);
      testCuisine.Save();
      Cuisine foundCuisine = Cuisine.Find(testCuisine.GetId());
      Assert.AreEqual(testCuisine, foundCuisine);
    }

    [TestMethod]
    public void GetRestaurants_ReturnsEmptyRestaurantList_RestaurantList()
    {
      string name = "Thai";
      Cuisine newCuisine = new Cuisine(name, 1);
      List<Restaurant> newList = new List<Restaurant> { };
      List<Restaurant> result = newCuisine.GetRestaurants();
      CollectionAssert.AreEqual(newList, result);
    }

    // [TestMethod]
    // public void GetRestaurants_RetrievesAllRestaurantsWithCuisine_RestaurantList()
    // {
    //   //Arrange, Act
    //   Cuisine testCuisine = new Cuisine("Thai", 1);
    //   testCuisine.Save();
    //   Restaurant firstRestaurant = new Restaurant("Thai Yum", testCuisine.GetId());
    //   firstRestaurant.Save();
    //   Restaurant secondRestaurant = new Restaurant("Thai Spice", testCuisine.GetId());
    //   secondRestaurant.Save();
    //   List<Restaurant> testRestaurantList = new List<Restaurant> {firstRestaurant, secondRestaurant};
    //   List<Restaurant> resultRestaurantList = testCuisine.GetRestaurants();
    //
    //   //Assert
    //   CollectionAssert.AreEqual(testRestaurantList, resultRestaurantList);
    // }

    [TestMethod]
    public void Equals_ReturnsTrueIfArgumentsAreTheSame_Cuisine()
    {
      Cuisine firstCuisine = new Cuisine("Thai", 1);
      Cuisine secondCuisine = new Cuisine("Thai", 1);
      Assert.AreEqual(firstCuisine, secondCuisine);
    }

    [TestMethod]
    public void Save_SavesCuisineToDatabase_CuisineList()
    {
      Cuisine testCuisine = new Cuisine("Thai", 1);
      testCuisine.Save();
      List<Cuisine> result = Cuisine.GetAll();
      List<Cuisine> testList = new List<Cuisine>{testCuisine};
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
