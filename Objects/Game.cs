using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace LemonadeStand
{
    public class Game
    {
        private static List<Game> _games = new List<Game> {};
        private int _id;
        private int _playerId;
        private int _temperature;
        private decimal _pitcherPrice;
        private int _cupsPerPitcher;
        private string _forecast;
        public static string[] Forecasts = new string[] {"sunny", "partly cloudy", "cloudy", "rain"};
        Random rnd = new Random();

        public Game(int PlayerId)
        {
            _id = _games.Count;
            _playerId = PlayerId;
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
        public int GetPlayerId()
        {
            return _playerId;
        }
        public int GetTemperature()
        {
            return _temperature;
        }
        public decimal GetPitcherPrice()
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

        public Dictionary<string, object> Play(decimal pricePerCup, int numberOfPitchers)
        {
            decimal totalAmountSpent = numberOfPitchers*_pitcherPrice;

            int totalCupsMade = numberOfPitchers*_cupsPerPitcher;

            int forecastNumber = Array.IndexOf(Forecasts, _forecast);

            int pricePerCupInt = Convert.ToInt32(pricePerCup * 100);

            int maxBought = (forecastNumber*_temperature)/pricePerCupInt;

            int cupsSold = 0;
            if(totalCupsMade <= maxBought)
            {
                cupsSold = totalCupsMade;
            }
            else
            {
                cupsSold = maxBought;
            }

            decimal totalAmountMade = cupsSold*pricePerCup;

            decimal remainingMoney = totalAmountMade - totalAmountSpent;
            Dictionary<string, object> play = new Dictionary<string, object> {};
            play.Add("cupsSold", cupsSold);
            play.Add("remainingMoney", remainingMoney);
            return play;
        }

        //Save method that saves player's money into score table in database
    }
}
