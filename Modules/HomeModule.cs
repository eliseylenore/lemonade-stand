using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace LemonadeStand
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/game"] = _ => {
                Game newGame = new Game();
                return View["Game.cshtml", newGame];
            };

            Get["/results"] = _ => View["results.cshtml"];

            Post["/results"] = _ => {
              Game newGame = new Game();
              Dictionary<string, object> model = newGame.Play(Request.Form["cup"], Request.Form["pitcher"]);
              return View["results.cshtml", model];

            };



        }


    }
}
