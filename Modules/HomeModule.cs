using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

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
                model.Add("game", playerGame);
                model.Add("player", newPlayer);
                return View["Game.cshtml", model];
            };
            //if player is returning player
            Post["/returning-user/game"] = _ => {
                //TODO: fix this code so that page only displays and game is only created if foundPlayer exists; maybe catch certain cases
                Dictionary<string, object> model = new Dictionary<string, object>{};
                Player foundPlayer = Player.Search(Request.Form["username"], Request.Form["password"]);
                Game playerGame = foundPlayer.AddGame();
                model.Add("game", playerGame);
                model.Add("player", foundPlayer);
                return View["Game.cshtml", model];
            };

            Post["/results"] = _ => {
              Game foundGame = Game.Find(Request.Form["game-id"]);
              Player foundGamePlayer = foundGame.GetPlayer();
              Dictionary<string, object> model = foundGame.Play(Request.Form["cup"], Request.Form["pitcher"], foundGamePlayer);
              return View["results.cshtml", model];
            };



        }


    }
}
