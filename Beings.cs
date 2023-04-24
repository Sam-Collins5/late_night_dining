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

namespace Project_5
{
    public class Beings
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        public string Name { get; set; }
        public string Desc { get; set; }
        public int Health { get; set; }
        public int Power { get; set; }
        public int[] Pos { get; set; }
        //------------------------------------------------------------------------------------------------------


        //constructors
        //------------------------------------------------------------------------------------------------------

        public Beings()
        {
            this.Name = "Entity 0";
            this.Desc = "A being that is not suppose to be here.";
            this.Health = 1;
            this.Power = 0;
            this.Pos = new int[2];
        }

        public Beings(string name, string desc)
        {
            this.Name = name;
            this.Desc = desc;
            this.Health = 1;
            this.Power = 0;
            this.Pos = new int[2];
        }

        public Beings(Beings another)
        {
            this.Name = another.Name;
            this.Desc = another.Desc;
            this.Health = another.Health;
            this.Power = another.Power;
            this.Pos = another.Pos;
        }
        //------------------------------------------------------------------------------------------------------

        //methods
        //------------------------------------------------------------------------------------------------------

        //displays beings's info
        public string ToString()
        {
            return $"Name: {Name}\nHP: {Health}\nATK: {Power}\nDesc: {Desc}";
        }
        //------------------------------------------------------------------------------------------------------


    }
}
