using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scorekeeper.Models;
using System.Text;

namespace Scorekeeper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to Kyle Crow's score keeper app.";

            HomeModel m = new HomeModel();

            return View(m);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection, HomeModel model)
        {
            ViewBag.Message = "Welcome to Kyle Crow's score keeper app.";

            if (collection["ddlCourses"] == null || collection["ddlCourses"] == "")
            {
                HomeModel m = new HomeModel();
                m.message = "You must select a course to enter a quick score.";
                return View(m);
            }
            
            if (model.FinalScore == null || model.FinalScore == "")
            {
                HomeModel m = new HomeModel();
                m.message = "You must eneter a score to enter a quick score.";
                return View(m);
            }

            ScorekeeperDBEntities s = new ScorekeeperDBEntities();
            string name = ((System.Web.HttpContext.Current.User).Identity).Name;

            User User = new User();
            ScorekeeperDBEntities userContext = new ScorekeeperDBEntities();
            User = userContext.Users.Where(x => x.Username == name).FirstOrDefault();

            try
            {
                RoundFinalScore f = new RoundFinalScore();
                f.RoundFinalScoreId = Guid.NewGuid();
                f.CourseId = Guid.Parse(collection["ddlCourses"]);
                f.UserId = User.UserId;
                f.PlayedDate = DateTime.Now;
                f.FinalScore = Int32.Parse(model.FinalScore);

                s.AddToRoundFinalScore(f);
                s.SaveChanges();
            }
            catch (Exception e)
            {
                HomeModel m = new HomeModel();
                m.message = "An error has ocurred: \n\n" + e.Message;
                return View(m);
            }

            HomeModel m2 = new HomeModel();
            m2.message = "Quick score entered successfully";
            ModelState.Clear();
            return View(m2);
        }

        public ActionResult About()
        {

            string userList = "";

            ScorekeeperDBEntities userContext = new ScorekeeperDBEntities();
            var userQuery = from u in userContext.Users
                            orderby u.LastName
                            select u;

            foreach (var item in userQuery)
            {
                if (userList == "")
                    userList = item.LastName;
                else
                    userList += ", " + item.LastName;
            }

            ViewBag.Message = userList;

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
                        int j = i + 1;
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
