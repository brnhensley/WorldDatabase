using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace WorldDatabase.Models
{
  public class City
  {
    public string Name {get; set;}
    public string CountryCode {get; set;}
    public int Population {get; set;}
    public int Id {get; set;}

    public City (string name, string countryCode, int population, int id = 0)
    {
      Name = name;
      CountryCode = countryCode;
      Population = population;
      Id = id;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM city;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string countryCode = rdr.GetString(2);
        int population = rdr.GetInt32(4);

        City newCity = new City(name, countryCode, population, id);
        allCities.Add(newCity);
      }
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static string FindCityName(int id)
    {
      string varName = "none";
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand getCapital = conn.CreateCommand() as MySqlCommand;
      getCapital.CommandText = @"SELECT name FROM city WHERE id='" + id +"';";
      MySqlDataReader rdr = getCapital.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        varName = rdr.GetString(0);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return varName;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM city";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public override bool Equals(System.Object otherCity)
    {
      if (!(otherCity is City))
      {
        return false;
      }
      else
      {
        City newCity = (City) otherCity;
        bool idEquality = (this.Id == newCity.Id);
        bool nameEqaulity = (this.Name == newCity.Name);
        return (nameEqaulity);
      }
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `city` (`name`, `countryCode`, `population`) VALUES (@CityName, @CityCountryCode, @CityPopulation);";

      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@CityName";
      name.Value = this.Name;

      MySqlParameter countryCode = new MySqlParameter();
      countryCode.ParameterName = "@CityCountryCode";
      countryCode.Value = this.CountryCode;

      MySqlParameter population = new MySqlParameter();
      population.ParameterName = "@CityPopulation";
      population.Value = this.Population;

      cmd.Parameters.Add(name);
      cmd.Parameters.Add(countryCode);
      cmd.Parameters.Add(population);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      // more logic will go here in a moment

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static City Find(int id)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `city` WHERE id = @thisId;";
      MySqlParameter thisId = new MySqlParameter();
      thisId.ParameterName = "@thisId";
      thisId.Value = id;
      cmd.Parameters.Add(thisId);
      var rdr = cmd.ExecuteReader() as MySqlDataReader;
      string cityName = "";
      string cityCountryCode = "";
      int cityId = 0;
      int cityPopulation = 0;

      while (rdr.Read())
      {
        cityName = rdr.GetString(1);
        cityCountryCode = rdr.GetString(2);
        cityPopulation = rdr.GetInt32(4);
        cityId = rdr.GetInt32(0);
      }

      City foundCity = new City(cityName, cityCountryCode, cityPopulation, cityId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundCity;
    }

  }
}
