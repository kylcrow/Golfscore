using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GolfScore.Models
{
    public class TurtleCreekModel
    {
        public int[] Player1Scores { get; set; }
        public int[] Player2Scores { get; set; }
        public int[] Player3Scores { get; set; }
        public int[] Player4Scores { get; set; }
        public string errorMessage { get; set; }
    
        public TurtleCreekModel()
        {
            Player1Scores = new int[18] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
            Player2Scores = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Player3Scores = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Player4Scores = new int[18] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        }
    }
}