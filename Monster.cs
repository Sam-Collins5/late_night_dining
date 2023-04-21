/**
*--------------------------------------------------------------------
* File name: Monster.cs
* Project name: 1260-002-CrumpNick-CollinsSam-FlahertyLogan-Project5
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 4/18/2023
* -------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MidnightDining
{
    internal class Monster : Beings
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        public Names name { get; set; }
        public string type { get; set; }
        public string attack { get; set; }

        //------------------------------------------------------------------------------------------------------


        //constructors
        //------------------------------------------------------------------------------------------------------

        public Monster()
        {

            Random random = new Random();
            int randName = random.Next(0, Enum.GetNames(typeof(Names)).Length);
            int randType = random.Next(1, 42);

            this.name = (Names)Enum.Parse(typeof(Names), Convert.ToString(randName));
            this.pos = new int[2];

            //reads from the Monster.txt file to get the data of the random monster
            //each line is as follows Type,Power,Health,Desc,Attack
            //attack is used for flavor text when an enemy attacks you all in the form of
            //player was attacked by a monster using {Monster.attack}!
            try
            {
                StreamReader rdr = new StreamReader($@"..\..\..\data\Monsters.txt");

                for(int i = 1; i < randType; i++)
                {
                    rdr.ReadLine();
                }

                string monsterData = rdr.ReadLine();

                string[] monsterDataArr = monsterData.Split(";");

                this.type = monsterDataArr[0];
                this.power = Convert.ToInt32(monsterDataArr[1]);
                this.health = Convert.ToInt32(monsterDataArr[2]);
                this.desc = monsterDataArr[3];
                this.attack = monsterDataArr[4];

                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Default monster values set");
                this.type = "Ork";
                this.desc = "Default Monster";
                this.health = 20;
                this.power = 4;
                this.attack = "it's body";
            }

            
        }

        public Monster(Monster another)
        {
            this.name = another.name;
            this.type = another.type;
            this.desc = another.desc;
            this.health = another.health;
            this.power = another.power;
            this.pos = another.pos;
        }
        //------------------------------------------------------------------------------------------------------

        //Methods
        //------------------------------------------------------------------------------------------------------

        //gets monsters name
        public string nameToString()
        {
            //Takes Name enum and converts it into a name with spaces instead of _
            char[] nameArr = Convert.ToString(name).ToCharArray();
            string newName = "";
            foreach (char item in nameArr)
            {
                if (item != '_')
                {
                    newName += item;
                }
                else
                {
                    newName += " ";
                }
            }

            return newName;
        }
        
        //displays monsters info
        public string ToString()
        {
            return $"Name: {nameToString()} the {type}\nHP: {health}\nATK: {power}\nDesc: {desc}";
        }

    }
}
