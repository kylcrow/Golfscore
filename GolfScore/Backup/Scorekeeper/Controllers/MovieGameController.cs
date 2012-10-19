using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;

namespace Scorekeeper.Controllers
{
    public class MovieGameController : Controller
    {
        //
        // GET: /MovieGame/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            string temp = "";

            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("http://api.rottentomatoes.com/api/public/v1.0/movies.json?apikey=[apikey]");

        
            temp = response.Content.ReadAsString();




            return View();
        }

    }
}
