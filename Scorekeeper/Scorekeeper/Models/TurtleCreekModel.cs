using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scorekeeper.Models
{
    public class TurtleCreekModel
    {
        public List<int> Player1Scores { get; set; }
        public List<int> Player2Scores { get; set; }
        public List<int> Player3Scores { get; set; }
        public List<int> Player4Scores { get; set; }
        public string errorMessage { get; set; }
    
        public TurtleCreekModel()
        {
            Player1Scores = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Player2Scores = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Player3Scores = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Player4Scores = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}