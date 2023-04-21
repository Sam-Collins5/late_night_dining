/**
*--------------------------------------------------------------------
* File name: Score.cs
* Project name: 1260-002-CrumpNick-CollinsSam-FlahertyLogan-Project5
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 4/20/2023
* -------------------------------------------------------------------
*/﻿

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
