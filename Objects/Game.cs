using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace LemonadeStand
{
    public class Game
    {
        private int _temperature;
        private int _pitcherPrice;
        private int _cupsPerPitcher;
        private string _forecast;
        public static string[] Forecasts = new string[] {"sunny", "partly cloudy", "cloudy", "rain"};
        Random rnd = new Random();

        public Game()
        {
            _temperature = rnd.Next(30,100);
            _forecast = Forecasts[rnd.Next(0, Forecasts.Length)];
            _pitcherPrice = rnd.Next(1,3);
            _cupsPerPitcher = 10;
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

        public Dictionary<string, int> Play(int pricePerCup, int numberOfPitchers)
        {
            int totalAmountSpent = numberOfPitchers*_pitcherPrice;

            int totalCupsMade = numberOfPitchers*_cupsPerPitcher;

            int forecastNumber = Array.IndexOf(Forecasts, _forecast);

            int maxBought = (forecastNumber*_temperature)/pricePerCup;

            int cupsSold = 0;
            if(totalCupsMade <= maxBought)
            {
                cupsSold = totalCupsMade;
            }
            else
            {
                cupsSold = maxBought;
            }

            int totalAmountMade = cupsSold*pricePerCup;

            int remainingMoney = totalAmountMade - totalAmountSpent;
            Dictionary<string, int> play = new Dictionary<string, int> {};
            Console.WriteLine(cupsSold);
            play.Add("cupsSold", cupsSold);
            play.Add("remainingMoney", remainingMoney);
            return play;
        }

        // public static DeleteAll()
        // {
        //
        // }

    }
}
