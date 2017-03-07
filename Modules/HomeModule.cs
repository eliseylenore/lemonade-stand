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
        }


    }
}
