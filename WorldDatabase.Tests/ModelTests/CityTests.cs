using Microsoft.VisualStudio.TestTools.UnitTesting;
using WorldDatabase.Models;
using System.Collections.Generic;
using System;

namespace WorldDatabase.Tests
{
  [TestClass]
  public class CityTest : IDisposable
  {

    public void Dispose()
    {
      City.ClearAll();
    }

    public CityTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=world_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyList_CityList()
    {
      //Arrange
      List<City> newList = new List<City> { };

      //Act
      List<City> result = City.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsCitys_CityList()
    {
      //Arrange
      City newCity1 = new City("portland", "USA", 60);
      newCity1.Save();
      City newCity2 = new City("seattle", "USA", 602);
      newCity2.Save();
      List<City> expectedResult = new List<City> { newCity1, newCity2 };

      //Act
      List<City> actualResult = City.GetAll();

      //Assert
      CollectionAssert.AreEqual(expectedResult, actualResult);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfNameAreTheSame_City()
    {
      // Arrange, Act
      City firstCity = new City("Ohio", "555", 666);
      City secondCity = new City("Ohio", "555", 666);

      // Assert
      Assert.AreEqual(firstCity, secondCity);
    }

    [TestMethod]
    public void Save_SavesToDatabase_CityList()
    {
      //Arrange
      City testCity = new City("Anaheim", "USA", 45);
      testCity.Save();

      //Act
      List<City> result = City.GetAll();
      List<City> testList = new List<City>{testCity};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }

    [TestMethod]
    public void Save_AssignsIdToObject_Id()
    {
      //Arrange
      City testCity = new City("Anaheim", "USA", 45);

      //Act
      testCity.Save();
      City savedCity = City.GetAll()[0];

      int result = savedCity.Id;
      int testId = testCity.Id;

      //Assert
      Assert.AreEqual(testId, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectCity_City()
    {
      //Arrange
      City testCity = new City("Cincinnati", "USA", 45);
      testCity.Save();

      //Act
      City foundCity = City.Find(testCity.Id);

      //Assert
      Assert.AreEqual(testCity, foundCity);
    }
    //This doesnt work yet
    // [TestMethod]
    // public void Edit_UpdateCityPopulationInDatabase_int()
    // {
    //   int firstPopulation = 10000;
    //   City lilTown = new City("Hanover", "HNR", firstPopulation);
    //   lilTown.Save();
    //   int secondPopulation = 190312442;
    //
    //   lilTown.EditCity("Population", secondPopulation);
    //   int result = City.Find(lilTown.Id).Population;
    //   Assert.AreEqual(secondPopulation, result);
    // }

    // [TestMethod]
    // public void ItemConstructor_CreatesInstanceOfItem_Item()
    // {
    //   Item newItem = new Item("test");
    //   Assert.AreEqual(typeof(Item), newItem.GetType());
    // }
    //
    // [TestMethod]
    // public void GetDescription_ReturnsDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //
    //   //Act
    //   string result = newItem.GetDescription();
    //
    //   //Assert
    //   Assert.AreEqual(description, result);
    // }
    //
    // [TestMethod]
    // public void SetDescription_SetDescription_String()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //
    //   //Act
    //   string updatedDescription = "Do the dishes";
    //   newItem.SetDescription(updatedDescription);
    //   string result = newItem.GetDescription();
    //
    //   //Assert
    //   Assert.AreEqual(updatedDescription, result);
    // }

    // [TestMethod]
    // public void GetId_CityInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);
    //
    //   //Act
    //   int result = newItem.GetId();
    //
    //   //Assert
    //   Assert.AreEqual(1, result);
    // }
    //

  }
}
