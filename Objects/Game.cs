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
