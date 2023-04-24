/**
*--------------------------------------------------------------------
* File name: Chair.cs
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
    public class Chair : BaseWeapon
    {
        //Properties
        public bool IsSittingInChair { get; private set; }

        //Constructors
        //Default
        public Chair() : base (2, "Chair", "Oh look a chair.")
        {
            IsSittingInChair = false;
        }

        ////Parameterized
        public Chair(int bonusDamage, string name, string description) : base(bonusDamage, name, description)
        {
            IsSittingInChair = false;
        }

        //Copy
        public Chair(Chair other) : base(other.BonusDamage, other.Name, other.Description)
        {
            IsSittingInChair = other.IsSittingInChair;
        }

        //Super Important Method
        public void InteractWithChair()
        {
            if (IsSittingInChair == true)
            {
                IsSittingInChair = false;
            }
            else
            {
                IsSittingInChair = true;
            }
        }

        public override string ToString()
        {
            string chairStr = string.Empty;
            chairStr += $"\nName: {Name}";
            chairStr += $"\nBonus Damage: {BonusDamage}";
            chairStr += $"\nDescription: {Description}";
            return chairStr;
        }
    }
}
