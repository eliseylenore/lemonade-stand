using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System;

namespace LemonadeStand
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => {
                return View["index.cshtml"];
            };
            //if player is a new user:
            Post["/new-user/game"] = _ => {
                Dictionary<string, object> model = new Dictionary<string, object>{};
                Player newPlayer = new Player(Request.Form["username"], Request.Form["password"]);
                newPlayer.Save();
                Game playerGame = newPlayer.AddGame();
                decimal pricePerPitcher = playerGame.GetPitcherPrice();
                decimal playerMoney = newPlayer.GetMoney();
                int limit = Convert.ToInt32(playerMoney/pricePerPitcher);
                model.Add("limit", limit);
                model.Add("game", playerGame);
                model.Add("player", newPlayer);
                model.Add("count", newPlayer.GetCount());
                return View["Game.cshtml", model];
            };
            //if player is returning player
            Post["/returning-user/game"] = _ => {
                //TODO: fix this code so that page only displays and game is only created if foundPlayer exists; maybe catch certain cases
                Dictionary<string, object> model = new Dictionary<string, object>{};
                Player foundPlayer = Player.Search(Request.Form["username"], Request.Form["password"]);
                foundPlayer.ResetMoneyAndCount();
                Game playerGame = foundPlayer.AddGame();
                decimal pricePerPitcher = playerGame.GetPitcherPrice();
                decimal playerMoney = foundPlayer.GetMoney();
                int limit = Convert.ToInt32(playerMoney/pricePerPitcher);
                model.Add("limit", limit);
                model.Add("game", playerGame);
                model.Add("player", foundPlayer);
                model.Add("count", foundPlayer.GetCount());
                return View["Game.cshtml", model];
            };

            Post["/results"] = _ => {
              Game foundGame = Game.Find(Request.Form["game-id"]);
              Player foundGamePlayer = foundGame.GetPlayer();
              Dictionary<string, object> model = foundGame.Play(Request.Form["cup"], Request.Form["pitcher"], foundGamePlayer);
              model.Add("game", foundGame);
              model.Add("count", foundGamePlayer.GetCount());
              return View["results.cshtml", model];
            };

            Post["/another/game"] = _ => {
                Dictionary<string, object> model = new Dictionary<string, object>{};
                Player foundPlayer = Player.Find(Request.Form["player-id"]);
                Console.WriteLine("another game count: "+foundPlayer.GetCount());
                if(foundPlayer.GetCount() >= 7)
                {
                  foundPlayer.SaveScore();
                  foundPlayer.ResetMoneyAndCount();
                  Game playerGame = foundPlayer.AddGame();
                  model.Add("count", foundPlayer.GetCount());
                  decimal pricePerPitcher = playerGame.GetPitcherPrice();
                  decimal playerMoney = foundPlayer.GetMoney();
                  int limit = Convert.ToInt32(playerMoney/pricePerPitcher);
                  model.Add("limit", limit);
                  model.Add("game", playerGame);
                  model.Add("player", foundPlayer);
                  return View["Game.cshtml", model];
                }
                else
                {
                  Game playerGame = foundPlayer.AddGame();
                  decimal pricePerPitcher = playerGame.GetPitcherPrice();
                  decimal playerMoney = foundPlayer.GetMoney();
                  int limit = Convert.ToInt32(playerMoney/pricePerPitcher);
                  model.Add("limit", limit);
                  model.Add("game", playerGame);
                  model.Add("player", foundPlayer);
                  model.Add("count", foundPlayer.GetCount());
                  return View["Game.cshtml", model];
                }
            };

            Post["/start-over"] = _ => {
                Dictionary<string, object> model = new Dictionary<string, object>{};
                Player foundPlayer = Player.Find(Request.Form["player-id"]);
                foundPlayer.ResetMoneyAndCount();
                Game playerGame = foundPlayer.AddGame();
                decimal pricePerPitcher = playerGame.GetPitcherPrice();
                decimal playerMoney = foundPlayer.GetMoney();
                int limit = Convert.ToInt32(playerMoney/pricePerPitcher);
                model.Add("limit", limit);
                model.Add("game", playerGame);
                model.Add("player", foundPlayer);
                model.Add("count", foundPlayer.GetCount());
                return View["Game.cshtml", model];
            };

        }


    }
}
