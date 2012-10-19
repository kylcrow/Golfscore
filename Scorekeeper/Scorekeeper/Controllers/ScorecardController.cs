using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Scorekeeper.Models;

namespace Scorekeeper.Controllers
{
    public class ScorecardController : Controller
    {
        public ActionResult Scorecard()
        {
            return View(new ScorecardModel());
        }

        [HttpPost]
        public ActionResult Scorecard(FormCollection collection, ScorecardModel model)
        {
            ScorekeeperDBEntities s = new ScorekeeperDBEntities();
            model.SelectedCourse = s.Courses.Where(x => x.CourseId == model.SelectedCourseValue).FirstOrDefault();
            return PartialView("_ScorecardDetail", model);
        }

        [HttpPost]
        public ActionResult ScorecardDetail(FormCollection collection, ScorecardModel model)
        {
            ScorecardModel m = new ScorecardModel();
            ScorekeeperDBEntities s = new ScorekeeperDBEntities();
            m.SelectedCourseValue = model.SelectedCourseValue;
            m.SelectedCourse = s.Courses.Where(x => x.CourseId == model.SelectedCourseValue).FirstOrDefault();
            int? highestRoundNum = 0;
            if (s.Rounds.Where(x => x.UserId == m.User.UserId).Count() > 0)
                highestRoundNum = s.Rounds.Where(x => x.UserId == m.User.UserId).OrderByDescending(x => x.RoundNumber).FirstOrDefault().RoundNumber;

            Round round = new Round();
            round.RoundId = Guid.NewGuid();
            round.CourseId = m.SelectedCourse.CourseId;
            round.UserId = m.User.UserId;
            round.RoundNumber = highestRoundNum + 1;
            round.PlayedDate = DateTime.Now;
            s.AddToRounds(round);
            
            for (int i = 0; i < m.SelectedCourse.Hole.Count(); i++)
            {
                RoundScore rs = new RoundScore();
                rs.RoundScoreId = Guid.NewGuid();
                rs.RoundId = round.RoundId;
                var g = (from h in s.Hole
                            where h.HoleNumber == i+1 && h.CourseId == m.SelectedCourse.CourseId
                            select h.HoleId);
                rs.HoleId = g.FirstOrDefault();
                string holeNum = "Hole" + (i+1).ToString();
                rs.Strokes = Int32.Parse(collection[holeNum]);
                s.AddToRoundScore(rs);
            }
            s.SaveChanges();
            m.message = "Round Saved Successfully";
            m.SelectedCourse = null;
            return View("Scorecard", m);
        }
    }
}
