using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidnightDining
{
    internal class Score
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        public string name { get; set; }
        public int score { get; set; }
        //------------------------------------------------------------------------------------------------------

        //constructors
        //------------------------------------------------------------------------------------------------------
        public Score()
        {
            this.name = "Player";
            this.score = 0;
        }

        public Score(string name, int score)
        {
            this.name = name;
            this.score = score;
        }

        public Score(Player another)
        {
            this.name = another.name;
            this.score = another.score;
        }
        //------------------------------------------------------------------------------------------------------
    }
}
