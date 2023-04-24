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

namespace Project_5
{
    public class Monster : Beings
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        public Names Name { get; set; }
        public string Type { get; set; }
        public string Attack { get; set; }

        //------------------------------------------------------------------------------------------------------


        //constructors
        //------------------------------------------------------------------------------------------------------

        public Monster()
        {

            Random random = new Random();
            int randName = random.Next(0, Enum.GetNames(typeof(Names)).Length);
            int randType = random.Next(1, 42);

            this.Name = (Names)Enum.Parse(typeof(Names), Convert.ToString(randName));
            this.Pos = new int[2];

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

                this.Type = monsterDataArr[0];
                this.Power = Convert.ToInt32(monsterDataArr[1]);
                this.Health = Convert.ToInt32(monsterDataArr[2]);
                this.Desc = monsterDataArr[3];
                this.Attack = monsterDataArr[4];

                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Default monster values set");
                this.Type = "Ork";
                this.Desc = "Default Monster";
                this.Health = 20;
                this.Power = 4;
                this.Attack = "it's body";
            }

            
        }

        public Monster(Monster another)
        {
            this.Name = another.Name;
            this.Type = another.Type;
            this.Desc = another.Desc;
            this.Health = another.Health;
            this.Power = another.Power;
            this.Attack = another.Attack;
            this.Pos = another.Pos;
        }
        //------------------------------------------------------------------------------------------------------

        //Methods
        //------------------------------------------------------------------------------------------------------

        //gets monsters name
        public string nameToString()
        {
            //Takes Name enum and converts it into a name with spaces instead of _
            char[] nameArr = Convert.ToString(Name).ToCharArray();
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
            return $"Name: {nameToString()} the {Type}\nHP: {Health}\nATK: {Power}\nDesc: {Desc}";
        }

    }
}
