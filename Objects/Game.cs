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
    private string[] _forecasts = ["sunny", "partly cloudy", "cloudy", "rain" ];

    public Game()
    {
      _temperature = Random.Next(30,100);
      _forecast = _forecasts[Random.Next(0, forecasts.length)];
      _pitcherPrice = Random.Next(1,3);
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
    public string[] GetForecast()
    {
      return _forecast;
    }

    // public static DeleteAll()
    // {
    //
    // }

  }
}
