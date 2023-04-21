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

namespace MidnightDining
{
    internal class Player : Beings
    {
        //attributes
        //------------------------------------------------------------------------------------------------------
        //change these to Weapon objects
        public string hand { get; set; }
        public List<string> inventory { get; set; }
        public int score { get; set; }
        //-------------------------------
        //------------------------------------------------------------------------------------------------------

        //constructors
        //------------------------------------------------------------------------------------------------------
        public Player()
        {
            this.name = "Player";
            this.desc = "Default Player Description";
            this.health = 100;
            this.power = 5;
            this.score = 0;

            this.pos = new int[2];
            this.pos[0] = 0;
            this.pos[1] = 0;

            //change these to Weapon objects
            hand = "fists";
            inventory = new List<string>();
            //-------------------------------
        }

        public Player(string name)
        {
            this.name = name;
            this.desc = "Fully clean and healhty traveler, not a scratch on yourself!";
            this.health = 100;
            this.power = 5;
            this.score = 0;

            this.pos = new int[2];
            this.pos[0] = 0;
            this.pos[1] = 0;

            //change these to Weapon objects
            this.hand = "fists";
            this.inventory = new List<string>();
            //-------------------------------
        }

        public Player(Player another)
        {
            this.name = another.name;
            this.desc = another.desc;
            this.health = another.health;
            this.power = another.power;
            this.pos = another.pos;
            this.hand = another.hand;
            this.inventory = another.inventory;
            this.score = another.score;
        }
        //------------------------------------------------------------------------------------------------------


        //methods
        //------------------------------------------------------------------------------------------------------

        //this command does not check to see if room exists
        public string Move(string direction)
        {
            //check to see if player moved
            bool moveFlag = false;

            if (direction.ToLower() == "north")
            {
                this.pos[1] += 1;
                moveFlag = true;
            }
            else if (direction.ToLower() == "east")
            {
                this.pos[0] += 1;
                moveFlag = true;
            }
            else if (direction.ToLower() == "south")
            {
                this.pos[1] -= 1;
                moveFlag = true;
            }
            else if (direction.ToLower() == "west")
            {
                this.pos[0] -= 1;
                moveFlag = true;
            }

            if (moveFlag == true)
            {
                return $"Moved {direction}.";
            }

            return $"{direction} is not a valid direction.";
        }

        //picks up an item if its an actual item
        //this command doesn't check to see if said item is present
        public string PickUp(string item)
        {
            inventory.Add(item);
            return $"Picked up {item}.";
        }

        //displays inventory
        public string DisplayInventory()
        {
            string invString = "Inventory:\n";
            foreach (string item in inventory)
            {
                invString += item + ",\n";
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
                if (scores[i].score < this.score)
                {
                    for (int e = i; i >= 0; i--)
                    {
                        if (check == true)
                        {
                            tempName = scores[i].name;
                            tempScore = scores[i].score;
                            scores[i].name = this.name;
                            scores[i].score = this.score;
                            check = false;
                        }
                        else if (i == 0)
                        {
                            
                            scores[i].name = tempName;
                            scores[i].score = tempScore;
                        }
                        else
                        {
                            tempName2 = scores[i].name;
                            tempScore2 = scores[i].score;
                            scores[i].name = tempName;
                            scores[i].score = tempScore;
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
                    rwr.WriteLine($"{scores[i].name};{scores[i].score}");
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
            if (health == 100)
            {
                desc = "Fully clean and healhty traveler, not a scratch on yourself!";
            }
            else if (health < 100 && health >= 90)
            {
                desc = "Clean and healthy traveler, a few bruises.";
            }
            else if (health < 90 && health >= 80)
            {
                desc = "Dirty but mostly healthy traveler, a few cuts and bruises.";
            }
            else if (health < 80 && health >= 75)
            {
                desc = "Slightly wounded traveler, badly bruised and cut.";
            }
            else if (health < 75 && health >= 50)
            {
                desc = "Wounded traveler, badly bruised and minor fractures in legs.";
            }
            else if (health < 50 && health >= 25)
            {
                desc = "Badly wounded traveler, broken arm with minor fractures in legs";
            }
            else if (health< 25 && health> 0)
            {
                desc = "critically wounded traveler, broken arm and multiple fractured bones.";
            }
            else
            {
                desc = "Traveler was critically wounded and has fainted.";
            }

            return $"Name: {name}\nHolding: {hand}\nHP: {health}\nATK: {power}\nDesc: {desc}\n{DisplayInventory()}";
        }
        //------------------------------------------------------------------------------------------------------


    }
}
