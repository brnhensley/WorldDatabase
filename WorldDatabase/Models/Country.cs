using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;


namespace WorldDatabase.Models
{
  public class Country
  {
    public string CountryName {get; set;}
    public float Indepenence {get; set;}
    public string Capital {get; set;}
    public string Continent {get; set;}
    public string Code {get; set;}

    public Country (string countryName, float independence, string capital,  string continent, string code)
    {
      CountryName = countryName;
      Indepenence = independence;
      Capital = capital;
      Continent = continent;
      Code = code;
    }

    public static List<Country> GetAll()
    {
      List<Country> allCountries = new List<Country> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM country;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

      while(rdr.Read())
      {
        string code = rdr.GetString(0);
        string countryName = rdr.GetString(1);
        Int16 independence = 0;
        if (!rdr.IsDBNull(5))
        {
          independence = rdr.GetInt16(5);
        }
        //int capital = rdr.GetInt32(13);
        int capitalId = 0;
        string capital = "non-existant";
        if (!rdr.IsDBNull(13))
        {
          capitalId = rdr.GetInt32(13);
          capital = City.FindCityName(capitalId);
        }

        string continent = rdr.GetString(2);
        Country newCountry = new Country(countryName, independence, capital, continent, code);
        allCountries.Add(newCountry);
      }
      conn.Close();

      if (conn != null)
      {
        conn.Dispose();
      }
      return allCountries;
    }

  }
}
