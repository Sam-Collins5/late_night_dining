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

namespace Project_5
{
    public class Score
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        public string Name { get; set; }
        public int Points { get; set; }
        //------------------------------------------------------------------------------------------------------

        //constructors
        //------------------------------------------------------------------------------------------------------
        public Score()
        {
            this.Name = "Player";
            this.Points = 0;
        }

        public Score(string name, int points)
        {
            this.Name = name;
            this.Points = points;
        }

        public Score(Player another)
        {
            this.Name = another.Name;
            this.Points = another.Score;
        }
        //------------------------------------------------------------------------------------------------------
    }
}
