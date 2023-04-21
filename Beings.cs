/**
*--------------------------------------------------------------------
* File name: Beings.cs
* Project name: 1260-002-CrumpNick-CollinsSam-FlahertyLogan-Project5
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 4/18/2023
* -------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MidnightDining
{
    internal class Beings
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        public string name { get; set; }
        public string desc { get; set; }
        public int health { get; set; }
        public int power { get; set; }
        public int[] pos { get; set; }
        //------------------------------------------------------------------------------------------------------


        //constructors
        //------------------------------------------------------------------------------------------------------

        public Beings()
        {
            this.name = "Entity 0";
            this.desc = "A being that is not suppose to be here.";
            this.health = 1;
            this.power = 0;
            this.pos = new int[2];
        }

        public Beings(string name, string desc)
        {
            this.name = name;
            this.desc = desc;
            this.health = 1;
            this.power = 0;
            this.pos = new int[2];
        }

        public Beings(Beings another)
        {
            this.name = another.name;
            this.desc = another.desc;
            this.health = another.health;
            this.power = another.power;
            this.pos = another.pos;
        }
        //------------------------------------------------------------------------------------------------------

        //methods
        //------------------------------------------------------------------------------------------------------

        //displays beings's info
        public string ToString()
        {
            return $"Name: {name}\nHP: {health}\nATK: {power}\nDesc: {desc}";
        }
        //------------------------------------------------------------------------------------------------------


    }
}
