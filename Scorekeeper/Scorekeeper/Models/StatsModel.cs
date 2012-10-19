using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scorekeeper.Models
{
    public class StatsModel
    {
        public User User { get; set; }
        public Round Round { get; set; }
        public List<RoundDetail> RoundList { get; set; }

        public StatsModel()
        {
            string name = ((System.Web.HttpContext.Current.User).Identity).Name;

            User = new User();
            ScorekeeperDBEntities userContext = new ScorekeeperDBEntities();
            User = userContext.Users.Where(x => x.Username == name).FirstOrDefault();
            RoundList = new List<RoundDetail>();
            foreach (var item in userContext.Rounds.Where(x => x.UserId == User.UserId).OrderBy(x => x.Course.Name).ThenByDescending(x => x.PlayedDate))
            {
                RoundDetail rd = new RoundDetail();
                rd.Round = item;
                rd.FinalScore = (int)item.RoundScore.Sum(x => x.Strokes);
                rd.QuickScore = false;
                RoundList.Add(rd);
            }

            foreach (var item in userContext.RoundFinalScore)
            {
                RoundDetail rd = new RoundDetail();
                rd.FinalScore = (int)item.FinalScore;
                rd.Round = new Round();
                rd.Round.Users = item.Users;
                rd.Round.PlayedDate = item.PlayedDate;
                rd.Round.Course = item.Course;
                rd.QuickScore = true;
                RoundList.Add(rd);
            }
        }
    }

    public class RoundDetail
    {
        public Round Round { get; set; }
        public int FinalScore { get; set; }
        public bool QuickScore { get; set; }
    }
}