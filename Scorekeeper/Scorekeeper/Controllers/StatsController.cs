using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scorekeeper.Models;

namespace Scorekeeper.Controllers
{
    public class StatsController : Controller
    {
        public ActionResult Stats()
        {
            return View("Stats", new StatsModel());
        }

        [HttpPost]
        public ActionResult Stats(FormCollection collection, StatsModel model)
        {
            return View("Stats", model);
        }

        public ActionResult Round(Guid id)
        {
            ScorekeeperDBEntities s = new ScorekeeperDBEntities();
            Round r = new Round();
            r = s.Rounds.Where(x => x.RoundId == id).FirstOrDefault();
            return View("Round", r);
        }
    }
}
