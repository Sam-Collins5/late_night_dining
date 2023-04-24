/**
*--------------------------------------------------------------------
* File name: Gun.cs
* Project name: Project 5
*--------------------------------------------------------------------
* Author’s name and email: Logan Flaherty   Personal: loganoflaherty@outlook.com    School: flahertyl@etsu.edu
* Course-Section: 1260-002
* Creation Date: 4/18/2023
* -------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_5.Weapon_Classes
{
    public class Gun : BaseWeapon
    {
        //Ammo property for tracking ammo left.
        public int Ammo { get; private set; }

        //Constructors
        //Default
        public Gun() : base (6, "Gun", " A standard issue 9mm. Point and shoot.")
        {
            Ammo = 0;
        }

        //Partly parameterized
        public Gun(int ammo) : base(6, "Gun", " A standard issue 9mm. Point and shoot.")
        {
            Ammo = ammo;
        }

        //Fully parameterized
        public Gun(int ammo, int bonusDamage, string name, string description) : base (bonusDamage, name, description)
        {
            Ammo = ammo;
        }

        //Copy constructor
        public Gun(Gun other) : base (other.BonusDamage, other.Name, other.Description)
        {
            Ammo = other.Ammo;
        }

        //Method for lowering the ammo value. Assuming it was used to attack aka shoot.
        public void UsedAmmo()
        {
            Ammo--;
        }
        public override string ToString()
        {
            string GunStr = string.Empty;
            GunStr += $"\nName: {Name}";
            GunStr += $"\nBonus Damage: {BonusDamage}";
            GunStr += $"\nDescription: {Description}";
            GunStr += $"\nAmmo Left: {Ammo}";
            return GunStr;
        }
    }
}
