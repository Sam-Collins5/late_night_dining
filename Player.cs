/**
*--------------------------------------------------------------------
* File name: Player.cs
* Project name: 1260-002-CrumpNick-CollinsSam-FlahertyLogan-Project5
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
* Course-Section: CSCI 1260-002
* Creation Date: 4/18/2023
* -------------------------------------------------------------------
*/


using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Project_5.Weapon_Classes;

namespace Project_5
{
    public class Player : Beings
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        public BaseWeapon Hand { get; set; }
        public List<BaseWeapon> Inventory { get; set; }
        public int Score { get; set; }

        //------------------------------------------------------------------------------------------------------

        //constructors
        //------------------------------------------------------------------------------------------------------
        public Player()
        {
            this.Name = "Player";
            this.Desc = "Default Player Description";
            this.Health = 100;
            this.Power = 5;
            this.Score = 0;

            this.Hand = null;
            this.Inventory = new List<BaseWeapon>();
        }

        public Player(string name)
        {
            this.Name = name;
            this.Desc = "Fully clean and healhty traveler, not a scratch on yourself!";
            this.Health = 100;
            this.Power = 5;
            this.Score = 0;

            this.Hand = null;
            this.Inventory = new List<BaseWeapon>();
        }

        public Player(Player another)
        {
            this.Name = another.Name;
            this.Desc = another.Desc;
            this.Health = another.Health;
            this.Power = another.Power;
            this.Hand = another.Hand;
            this.Inventory = another.Inventory;
            this.Score = another.Score;
        }
        //------------------------------------------------------------------------------------------------------


        //methods
        //------------------------------------------------------------------------------------------------------

        //this command does not check to see if room exists
        public string Move(string direction, DungeonMap dungeonMap)
        {
            //check to see if player moved
            (int, int) playerPos = dungeonMap.GetPlayerPos();
            bool moveFlag = false;
            bool boundFlag = false;

            if (direction.ToLower() == "north")
            {
                dungeonMap.MovePlayer(playerPos.Item1 - 1, playerPos.Item2);
                if (dungeonMap.GetPlayerPos() == playerPos)
                {
                    boundFlag = true;
                }
                else
                {
                    moveFlag = true;
                }
            }
            else if (direction.ToLower() == "east")
            {
                dungeonMap.MovePlayer(playerPos.Item1, playerPos.Item2 + 1);
                if (dungeonMap.GetPlayerPos() == playerPos)
                {
                    boundFlag = true;
                }
                else
                {
                    moveFlag = true;
                }
            }
            else if (direction.ToLower() == "south")
            {
                dungeonMap.MovePlayer(playerPos.Item1 + 1, playerPos.Item2);
                if (dungeonMap.GetPlayerPos() == playerPos)
                {
                    boundFlag = true;
                }
                else
                {
                    moveFlag = true;
                }
            }
            else if (direction.ToLower() == "west")
            {
                dungeonMap.MovePlayer(playerPos.Item1, playerPos.Item2 - 1);
                if (dungeonMap.GetPlayerPos() == playerPos)
                {
                    boundFlag = true;
                }
                else
                {
                    moveFlag = true;
                }
            }

            if (moveFlag == true)
            {
                return $"Moved {direction}.";
            }
            else if (boundFlag == true)
            {
                return $"{direction} is out of bounds";
            }
            else
            {
                return $"{direction} is not a valid direction.";
            }
        }

        //picks up an item if its an actual item
        //this command doesn't check to see if said item is present
        public string PickUp(BaseWeapon item)
        {
            Inventory.Add(item);
            return $"Picked up {item.Name}.";
        }

        //displays inventory
        public string DisplayInventory()
        {
            string invString = "Inventory:\n";
            foreach (BaseWeapon item in Inventory)
            {
                invString += $"{item.Name}" + ",\n";
            }
            return invString;
        }

        //saves player score
        public string SaveScore()
        {
            Score[] scores = new Score[5];
            int dataLength = -1;
            try
            {
                StreamReader rdr = new StreamReader($@"..\..\..\data\Scores.txt");

                for(int i = 0; i < 5; i++)
                {
                    string nextLine = rdr.ReadLine();

                    string[] scoreData = nextLine.Split(";");

                    Score highScore = new Score(scoreData[0], Convert.ToInt32(scoreData[1]));
                    scores[dataLength += 1] = highScore;
                }

                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            string tempName = "";
            int tempScore = 0;
            string tempName2 = "";
            int tempScore2 = 0;
            bool check = true;
            //int counter = scores.Length - 1;
            for (int i = scores.Length - 1; i >= 0; i--)
            {
                if (scores[i].Points < this.Score)
                {
                    for (int e = i; i >= 0; i--)
                    {
                        if (check == true)
                        {
                            tempName = scores[i].Name;
                            tempScore = scores[i].Points;
                            scores[i].Name = this.Name;
                            scores[i].Points = this.Score;
                            check = false;
                        }
                        else if (i == 0)
                        {
                            
                            scores[i].Name = tempName;
                            scores[i].Points = tempScore;
                        }
                        else
                        {
                            tempName2 = scores[i].Name;
                            tempScore2 = scores[i].Points;
                            scores[i].Name = tempName;
                            scores[i].Points = tempScore;
                            tempName = tempName2;
                            tempScore = tempScore2;
                        }
                        
                    }
                    break;
                }
                //counter--;
            }

            try
            {
                StreamWriter rwr = new StreamWriter($@"..\..\..\data\Scores.txt");

                for (int i = 0; i <= dataLength; i++)
                {
                    rwr.WriteLine($"{scores[i].Name};{scores[i].Points}");
                }

                rwr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Data was saved succesfully.";
        }

        //displays score
        public string DisplayHighScores()
        {
            string highString = "";
            int dataLength = -1;
            int place = 5;
            try
            {
                StreamReader rdr = new StreamReader($@"..\..\..\data\Scores.txt");

                while (rdr.Peek() != -1)
                {
                    string nextLine = rdr.ReadLine();

                    string[] scoreData = nextLine.Split(";");

                    highString = $"{place}. {scoreData[0]}: {scoreData[1]}\n" + highString;
                    place--;
                }

                rdr.Close();
                return highString;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "Failed to display score board.";
        }

        //displays players info
        public string ToString()
        {
            //changes player description based on health.
            if (Health == 100)
            {
                Desc = "Fully clean and healhty traveler, not a scratch on yourself!";
            }
            else if (Health < 100 && Health >= 90)
            {
                Desc = "Clean and healthy traveler, a few bruises.";
            }
            else if (Health < 90 && Health >= 80)
            {
                Desc = "Dirty but mostly healthy traveler, a few cuts and bruises.";
            }
            else if (Health < 80 && Health >= 75)
            {
                Desc = "Slightly wounded traveler, badly bruised and cut.";
            }
            else if (Health < 75 && Health >= 50)
            {
                Desc = "Wounded traveler, badly bruised and minor fractures in legs.";
            }
            else if (Health < 50 && Health >= 25)
            {
                Desc = "Badly wounded traveler, broken arm with minor fractures in legs";
            }
            else if (Health< 25 && Health> 0)
            {
                Desc = "critically wounded traveler, broken arm and multiple fractured bones.";
            }
            else
            {
                Desc = "Traveler was critically wounded and has fainted.";
            }

            return $"Name: {Name}\nHolding: {Hand}\nHP: {Health}\nATK: {Power}\nDesc: {Desc}\n{DisplayInventory()}";
        }
        //------------------------------------------------------------------------------------------------------


    }
}
