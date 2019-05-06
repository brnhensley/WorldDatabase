using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace WorldDatabase.Models
{
  public class City
  {
    public string CityName {get; set;}
    public string CountryCode {get; set;}
    public int Population {get; set;}
    public int Id {get; set;}

    public City (string cityName, string countryCode, int population, int id)
    {
      CityName = cityName;
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
        string cityName = rdr.GetString(1);
        string countryCode = rdr.GetString(2);
        int population = rdr.GetInt32(4);

        City newCity = new City(cityName, countryCode, population, id);
        allCities.Add(newCity);
      }
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

  }
}
