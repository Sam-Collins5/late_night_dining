/**
*--------------------------------------------------------------------
* File name: BaseWeapon.cs
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
    public class BaseWeapon
    {
        //Properties
        public int BonusDamage { get;  private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        //Base constructor to be used for child classes
        public BaseWeapon(int bonusDamage, string name, string description)
        {
            BonusDamage = bonusDamage;
            Name = name;
            Description = description;
        }
    }
}
