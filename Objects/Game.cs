using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace LemonadeStand
{
    public class Game
    {
        private static List<Game> _games = new List<Game> {};
        private int _id;
        private Player _player;
        private int _playerId;
        private int _temperature;
        private decimal _pitcherPrice;
        private int _cupsPerPitcher;
        private string _forecast;
        public static string[] Forecasts = new string[] {"rain", "cloudy", "partly cloudy", "sunny"};
        Random rnd = new Random();

        public Game(int PlayerId)
        {
            _id = _games.Count;
            _playerId = PlayerId;
            _player = Player.Find(PlayerId);
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
        //Must call Player.Find in this method as opposed to just once, when the game object is created, to get most updated version of player object
        public Player GetPlayer()
        {
            _player = Player.Find(_playerId);
            return _player;
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
        // public int GetGameCount(Player selectedPlayer)
        // {
        //     count = 0;
        //     foreach(Game game in _games)
        //     {
        //         if(game.GetPlayer == selectedPlayer)
        //         {
        //             count++;
        //         }
        //     }
        //     return count;
        // }

        public Dictionary<string, object> Play(decimal pricePerCup, int numberOfPitchers, Player gamePlayer)
        {
            decimal startingMoney = gamePlayer.GetMoney();

            decimal totalAmountSpent = numberOfPitchers*_pitcherPrice;

            int totalCupsMade = numberOfPitchers*_cupsPerPitcher;

            int forecastNumber = Array.IndexOf(Forecasts, _forecast);

            int pricePerCupInt = Convert.ToInt32(pricePerCup * 100);

            int maxBought = (int)(((((forecastNumber * forecastNumber) * 1.9) + 1.5)*(_temperature * 2.7))/(0.9 * pricePerCupInt));

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

            decimal profit = totalAmountMade - totalAmountSpent;
            string profitString = String.Format("{0:C}", profit);

            decimal remainingMoney = startingMoney - totalAmountSpent;
            gamePlayer.SetMoney(remainingMoney);

            decimal availableFunds = startingMoney + profit;
            gamePlayer.SetMoney(availableFunds);
            string availableString = String.Format("{0:C}", availableFunds);

            string youlose = "You Lose!";

            Dictionary<string, object> play = new Dictionary<string, object> {};
            play.Add("cupsSold", cupsSold);
            play.Add("profit", profit);
            play.Add("profitString", profitString);
            play.Add("remainingMoney", remainingMoney);
            play.Add("availableFunds", availableFunds);
            play.Add("availableString", availableString);
            play.Add("you-lose", youlose);

            return play;
        }

        public static void ClearAll()
        {
          _games.Clear();
        }

        //Save method that saves player's money into score table in database
    }
}
