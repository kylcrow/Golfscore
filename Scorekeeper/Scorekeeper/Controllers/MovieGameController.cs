using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Scorekeeper.Models;

namespace Scorekeeper.Controllers
{
    public class MovieGameController : Controller
    {
        public ActionResult Index()
        {
            MovieGameModel model = new MovieGameModel();
            model.FirstLoad = true;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, MovieGameModel model)
        {
            model.FirstLoad = false;

            Movie movie = new Movie();
            movie = model.GetMovieWithCast(model.Movie);

            if (movie != null)
            {
                model.Total = 1;
                model.Title = movie.title;
                model.Thumbnail = movie.posters.thumbnail;
            }
            Cast c = new Cast();
            c = movie.abridged_cast.Where(x => x.name == model.Actor).FirstOrDefault();
            if (c != null)
            {
                model.isIn = true;
                model.CharacterName = c.characters.FirstOrDefault();
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult UsingJavascript()
        {
            return View();
        }

    }
}
