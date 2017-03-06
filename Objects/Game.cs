using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace LemonadeStand
{
    public class Game
    {
        private static List<Game> _games = new List<Game> {};
        private int _id;
        private int _temperature;
        private int _pitcherPrice;
        private int _cupsPerPitcher;
        private string _forecast;
        public static string[] Forecasts = new string[] {"sunny", "partly cloudy", "cloudy", "rain"};
        Random rnd = new Random();

        public Game()
        {
            _id = _games.Count;
            _games.Add(this);
            _temperature = rnd.Next(30,100);
            _forecast = Forecasts[rnd.Next(0, Forecasts.Length)];
            _pitcherPrice = rnd.Next(1,3);
            _cupsPerPitcher = 10;
        }

        public int GetId()
        {
            return _id;
        }

        public int GetTemperature()
        {
            return _temperature;
        }
        public int GetPitcherPrice()
        {
            return _pitcherPrice;
        }
        public int GetCupsPerPitcher()
        {
            return _cupsPerPitcher;
        }
        public string GetForecast()
        {
            return _forecast;
        }
        public static string[] GetForecastArray()
        {
            return Forecasts;
        }

        public static Game Find(int searchId)
        {
            return _games[searchId];
        }

        // public static string[] GetForecastArray()
        // {
        //   return _forecasts;
        // }

        // public static DeleteAll()
        // {
        //
        // }

    }
}
