using System;
using MySql.Data.MySqlClient;
using WorldDatabase;
using System.Collections.Generic;

namespace WorldDatabase.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}
