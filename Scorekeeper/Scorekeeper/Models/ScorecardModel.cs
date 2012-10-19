using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scorekeeper.Models
{
    public class ScorecardModel
    {
        public User User { get; set; }
        public Round Round { get; set; }
        public List<Course> CourseList { get; set; }
        public Guid SelectedCourseValue { get; set; }
        public Course SelectedCourse { get; set; }
        public string message { get; set; }

        public ScorecardModel()
        {
            message = "";
            string name = ((System.Web.HttpContext.Current.User).Identity).Name;

            User = new User();
            ScorekeeperDBEntities userContext = new ScorekeeperDBEntities();
            User = userContext.Users.Where(x => x.Username == name).FirstOrDefault();

            CourseList = new List<Course>();
            CourseList = userContext.Courses.ToList();
        }
    }
}