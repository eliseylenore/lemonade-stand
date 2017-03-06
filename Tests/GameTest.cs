using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace LemonadeStand
{
  public class GameTest
  {
    public GameTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=lemonade_stand_test;Integrated Security=SSPI;";
    }

    [Fact]
    public static void GetTemperature_ReturnsARandomValueBetween30And100_true()
    {
      Game testGame = new Game();
      int temp = testGame.GetTemperature();

      bool result = (temp >= 30 && temp < 100);
      Console.WriteLine(temp);
      Assert.Equal(true, result);
    }

  }
}
