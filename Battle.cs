﻿/**
*--------------------------------------------------------------------
* File name: Battle.cs
* Project name: Project 5
*--------------------------------------------------------------------
* Author’s name and email: Logan Flaherty   Personal: loganoflaherty@outlook.com    School: flahertyl@etsu.edu
* Course-Section: 1260-002
* Creation Date: 4/18/2023
* -------------------------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_5.Weapon_Classes;
using static System.Net.Mime.MediaTypeNames;

namespace Project_5
{
    public class Battle
    {
        //Properties
        public bool IsBattling { get; set; }
        
        public BaseWeapon? Weapon { get; set; }
        public Player Player { get; private set; }
        public Monster Monster { get; private set; }
        
        //The Turn property is suppose to either have a value of 0 or 1.
        //0 means that it is the player's turn, and a 1 means the monster's turn.
        //Note in the driver you are suppose to roll for whoever opens up the battle.
        //The player doesn't always go first, but the default value is 0.
        public int Turn { get; set; }
        
        public bool IsCrit { get; set; }

        //Constructor to initiate a battle if player has weapon.
        public Battle(Player player, Monster monster)
        {
            this.Player = player;
            this.Monster = monster;
            this.Weapon = player.Hand;
            this.IsBattling = true;
        }

        //Copy constructor with weapon parameterization so that the player can switch weapons.
        public Battle(Battle other)
        {
            this.Player = other.Player;
            this.Monster = other.Monster;
            this.Weapon = other.Player.Hand;
            this.IsBattling = true;
        }

        //Methods
        public void PlayerAttack()
        {
            if (Weapon is Gun)
            {
                Monster.Health -= GetPlayerDamageWithGun((Gun)Weapon, Player.Power, IsCrit);
            }
            else if (Weapon is PepperSpray)
            {
                Monster.Health -= GetPlayerDamageWithPepperSpray((PepperSpray)Weapon, Player.Power, IsCrit);
            }
            else
            {
                Monster.Health -= GetPlayerDamage(Weapon, Player.Power, IsCrit);
            }
        }

        public void MonsterAttack()
        {
            Player.Health -= GetMonsterDamage(Monster.Power, IsCrit);
        }

        public int GetPlayerDamage(BaseWeapon weapon, int power, bool isCrit)
        {
            if (isCrit == true && Weapon != null)
            {
                power = (Player.Power + weapon.BonusDamage) * 2;
            }
            if (isCrit == true)
            {
                power = Player.Power * 2;
            }
            else if (Weapon != null)
            {
                power = Player.Power + Weapon.BonusDamage;
            }
            return power;
        }

        public int GetPlayerDamageWithGun(Gun weapon, int power, bool isCrit)
        {
            if (isCrit == true && Weapon != null)
            {
                power = (Player.Power + weapon.BonusDamage) * 2;
                weapon.UsedAmmo();
            }
            if (isCrit == true)
            {
                power = (Player.Power + weapon.BonusDamage) * 2;
                weapon.UsedAmmo();
            }
            else if (Weapon != null)
            {
                power = Player.Power + weapon.BonusDamage;
                weapon.UsedAmmo();

            }
            return power;
        }

        public int GetGunAmmo(Gun gun)
        {
            return gun.Ammo;
        }

        public int GetPlayerDamageWithPepperSpray(PepperSpray weapon, int power, bool isCrit)
        {
            if (isCrit == true && Weapon != null)
            {
                power = (Player.Power + weapon.BonusDamage) * 2;
                weapon.AttackedWithSpray();
            }
            if (isCrit == true)
            {
                power = Player.Power * 2;
                weapon.AttackedWithSpray();
            }
            else if (Weapon != null)
            {
                power = Player.Power + Weapon.BonusDamage;
                weapon.AttackedWithSpray();

            }
            return power;
        }

        public bool GetPepperSprayLeft(PepperSpray spray)
        {
            return spray.SprayLeft;
        }

        public int GetMonsterDamage(int power, bool isCrit)
        {
            if (isCrit == true)
            {
                power = Monster.Power * 2;
            }
            else
            {
                
            }
            return power;
        }

        public int AttackRoll()
        {
            Random r = new Random();
            int rand = r.Next(1, 21);
            if (rand == 20)
            {
                IsCrit = true;
            }
            return rand;
        }

        public int InitativeRoll()
        {
            Random r = new Random();
            int rand = r.Next(0, 2);
            return rand;
        }

        public int ChangeTurn()
        {
            if (Turn == 0)
            {
                Turn = 1;
                return Turn;
            }
            else
            {
                Turn = 0;
                return Turn;
            }
        }
    }
}
