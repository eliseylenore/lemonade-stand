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
            Game testGame = new Game(1);
            int temp = testGame.GetTemperature();

            bool result = (temp >= 30 && temp < 100);
            Assert.Equal(true, result);
        }

        [Fact]
        public static void GetForecast_ReturnsRandomValueFromForecastArray_true()
        {
            Game testGame = new Game(1);

            string forecast = testGame.GetForecast();
            string[] forecastArray = Game.GetForecastArray();

            bool result = (forecastArray.Contains(forecast));

            Assert.Equal(true, result);
        }

        [Fact]
        public static void Play_CupsSoldPositiveInteger_true()
        {
            Game testGame = new Game(1);
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();
            Dictionary<string, object> testDictionary = testGame.Play(5, 10, testPlayer);

            var cupsSold = testDictionary["cupsSold"];
            bool result = ((int)cupsSold >= 0);
            Assert.Equal(true, result);
        }

        //TODO: write tests to test distribution of cupsSold and remainingMoney
        [Fact]
        public static void Play_MaxBoughtIsWeatherDividedByPricePerCup_true()
        {
            Game testGame = new Game(1);
            decimal pricePerCup = 5m;
            int numberOfPitchers = 10;
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();
            Dictionary<string, object> testDictionary = testGame.Play(pricePerCup, numberOfPitchers, testPlayer);

            string forecast = testGame.GetForecast();
            string[] Forecasts = Game.GetForecastArray();
            int forecastNumber = Array.IndexOf(Forecasts, forecast);
            int temperature = testGame.GetTemperature();

            int pricePerCupInt = Convert.ToInt32(pricePerCup * 100);

            int maxBought = (forecastNumber*temperature)/pricePerCupInt;

            int cupsPerPitcher = testGame.GetCupsPerPitcher();
            int totalCupsMade = cupsPerPitcher*numberOfPitchers;

            int cupsSold = 0;
            if(totalCupsMade <= maxBought)
            {
                cupsSold = totalCupsMade;
            }
            else
            {
                cupsSold = maxBought;
            }

            var actual = testDictionary["cupsSold"];
            Assert.Equal(cupsSold, actual);
        }

        [Fact]
        public static void Find_ReturnsGameBasedOnId()
        {
            Game testGame = new Game(1);

            Game result = Game.Find(testGame.GetId());

            Assert.Equal(testGame, result);
        }

        [Fact]
        public void Play_PlayerGame_RemainingMoneyLessThanStartingMoney()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();
            decimal startingMoney = testPlayer.GetMoney();

            Game playerGame = testPlayer.AddGame();
            Dictionary<string, object> results = playerGame.Play(20m, 8, testPlayer);

            decimal endingMoney = testPlayer.GetMoney();

            bool testBool = (startingMoney > endingMoney);
            Assert.Equal(true, testBool);
        }

        [Fact]
        public void GetPlayer_PlayerMaintainsCount_CorrectCount()
        {
            Player testPlayer = new Player("coolgurl123", "password123");
            testPlayer.Save();

            Game playerGame1 = testPlayer.AddGame();
            playerGame1.Play(0.6m, 5, testPlayer);
            Game playerGame2 = testPlayer.AddGame();
            playerGame2.Play(0.6m, 5, testPlayer);
            Game playerGame3 = testPlayer.AddGame();
            playerGame3.Play(0.6m, 5, testPlayer);

            int expected = testPlayer.GetCount();

            Player foundPlayer = playerGame3.GetPlayer();
            int actual = foundPlayer.GetCount();

            Assert.Equal(expected, actual);
        }

        public void Dispose()
        {

        }
    }
}
