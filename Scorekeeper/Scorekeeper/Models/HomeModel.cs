using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scorekeeper.Models
{
    public class HomeModel
    {
        public SelectList Courses { get; set; }
        public string FinalScore { get; set; }
        public string message { get; set; }

        public HomeModel()
        {
            ScorekeeperDBEntities s = new ScorekeeperDBEntities();
            List<Course> courses = new List<Course>();
            courses = s.Courses.ToList();
            Courses = new SelectList(courses, "CourseId", "Name");
            FinalScore = "0";
        }
    }
}