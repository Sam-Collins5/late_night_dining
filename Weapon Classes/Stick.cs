/**
*--------------------------------------------------------------------
* File name: Stick.cs
* Project name: Project 5
*--------------------------------------------------------------------
* Author’s name and email: Logan Flaherty   Personal: loganoflaherty@outlook.com    School: flahertyl@etsu.edu
* Course-Section: 1260-002
* Creation Date: 4/18/2023
* -------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_5.Weapon_Classes
{
    public class Stick : BaseWeapon
    {
        //Constructors
        //Default
        public Stick() : base (1, "Stick", "It's just a stick.")
        {

        }

        //Parameterized
        public Stick(string name, string description) : base (1, name, description)
        {

        }

        //Copy
        public Stick(Stick other) : base (other.BonusDamage, other.Name, other.Description)
        {

        }

        //Methods
        public override string ToString()
        {
            string StickStr = string.Empty;
            StickStr += $"\nName: {Name}";
            StickStr += $"\nBonus Damage: {BonusDamage}";
            StickStr += $"\nDescription: {Description}";
            return StickStr;
        }
    }
}
