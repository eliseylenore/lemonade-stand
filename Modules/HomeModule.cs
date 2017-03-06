using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace LemonadeStand
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/results"] = _ => View["Game.cshtml"];
        }


    }
}
