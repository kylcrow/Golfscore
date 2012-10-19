using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GolfScore.Models;
using System.Text;

namespace GolfScore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Kyle's MVC Mobile App";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your quintessential app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your quintessential contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult TurtleCreek()
        {
            TurtleCreekModel m = new TurtleCreekModel();
            return View(m);
        }

        [HttpPost]
        public ActionResult TurtleCreek(FormCollection c, TurtleCreekModel m)
        {
            if (m == null)
                m = new TurtleCreekModel();
            else
            {
                StringBuilder p1 = new StringBuilder();
                if (m.Player1Scores != null && m.Player1Scores.Count() > 0)
                {
                    for (int i = 0; i < m.Player1Scores.Count(); i++)
                    {
                        int j = i+1;
                        p1.AppendLine("Hole " + j.ToString() + ": " + m.Player1Scores[i]);
                    }
                }

                StringBuilder p2 = new StringBuilder();
                if (m.Player2Scores != null && m.Player2Scores.Count() > 0)
                {
                    for (int i = 0; i < m.Player2Scores.Count(); i++)
                    {
                        int j = i + 1;
                        p2.AppendLine("Hole " + j.ToString() + ": " + m.Player2Scores[i]);
                    }
                }

                StringBuilder p3 = new StringBuilder();
                if (m.Player3Scores != null && m.Player3Scores.Count() > 0)
                {
                    for (int i = 0; i < m.Player3Scores.Count(); i++)
                    {
                        int j = i + 1;
                        p3.AppendLine("Hole " + j.ToString() + ": " + m.Player3Scores[i]);
                    }
                }

                StringBuilder p4 = new StringBuilder();
                if (m.Player4Scores != null && m.Player4Scores.Count() > 0)
                {
                    for (int i = 0; i < m.Player4Scores.Count(); i++)
                    {
                        int j = i + 1;
                        p4.AppendLine("Hole " + j.ToString() + ": " + m.Player4Scores[i]);
                    }
                }
                try
                {
                    System.IO.File.WriteAllText(string.Format(@"c:\Websites\Player1--{0}--{1}--{2}.log", DateTime.Now.Date.DayOfYear, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes), p1.ToString());
                    System.IO.File.WriteAllText(string.Format(@"c:\Websites\Player2--{0}--{1}--{2}.log", DateTime.Now.Date.DayOfYear, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes), p2.ToString());
                    System.IO.File.WriteAllText(string.Format(@"c:\Websites\Player3--{0}--{1}--{2}.log", DateTime.Now.Date.DayOfYear, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes), p3.ToString());
                    System.IO.File.WriteAllText(string.Format(@"c:\Websites\Player4--{0}--{1}--{2}.log", DateTime.Now.Date.DayOfYear, DateTime.Now.TimeOfDay.Hours, DateTime.Now.TimeOfDay.Minutes), p4.ToString());
                }
                catch (Exception e)
                {
                    m.errorMessage = "An error has occured.";
                }
            }
            
            return View(m);
        }
    }
}
