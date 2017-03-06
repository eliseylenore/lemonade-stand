using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LemonadeStand
{
    public class GameTest : IDisposable
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
            Assert.Equal(true, result);
        }

        [Fact]
        public static void GetForecast_ReturnsRandomValueFromForecastArray_true()
        {
            Game testGame = new Game();

            string forecast = testGame.GetForecast();
            string[] forecastArray = Game.GetForecastArray();

            bool result = (forecastArray.Contains(forecast));

            Assert.Equal(true, result);
        }

        [Fact]
        public static void Find_ReturnsGameBasedOnId()
        {
            Game testGame = new Game();
            Console.WriteLine(testGame.GetId());
            
            Game result = Game.Find(testGame.GetId());

            Assert.Equal(testGame, result);
        }

        public void Dispose()
        {

        }
    }
}
