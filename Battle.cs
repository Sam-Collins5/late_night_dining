/**
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
        
        public BaseWeapon? Weapon { get; private set; }
        public Player Player { get; private set; }
        public Monster Monster { get; private set; }
        
        //The Turn property is suppose to either have a value of 0 or 1.
        //0 means that it is the player's turn, and a 1 means the monster's turn.
        //Note in the driver you are suppose to roll for whoever opens up the battle.
        //The player doesn't always go first, but the default value is 0.
        public int Turn { get; set; }
        
        public bool IsCrit { get; set; }

        //Constructor to initiate a battle if player has weapon.
        public Battle(Player player, Monster monster, BaseWeapon weapon)
        {
            this.Player = player;
            this.Monster = monster;
            this.Weapon = weapon;
            this.IsBattling = true;
        }

        //Constructor to initate a battle if player does not have a weapon.
        public Battle(Player player, Monster monster)
        {
            this.Player = player;
            this.Monster = monster;
            this.Weapon = null;
            this.IsBattling = true;
        }

        //Copy constructor with weapon parameterization so that the player can switch weapons.
        public Battle(Battle other, BaseWeapon weapon)
        {
            this.Player = other.Player;
            this.Monster = other.Monster;
            this.Weapon = weapon;
            this.IsBattling = true;
        }

        //Methods
        public void PlayerAttack()
        {
            if (Weapon is Gun)
            {
                Monster.health -= GetPlayerDamageWithGun((Gun)Weapon, Player.power, IsCrit);
            }
            else if (Weapon is PepperSpray)
            {
                Monster.health -= GetPlayerDamageWithPepperSpray((PepperSpray)Weapon, Player.power, IsCrit);
            }
            else
            {
                Monster.health -= GetPlayerDamage(Weapon, Player.power, IsCrit);
            }
        }

        public void MonsterAttack()
        {
            Player.health -= GetMonsterDamage(Monster.power, IsCrit);
        }

        public int GetPlayerDamage(BaseWeapon weapon, int power, bool isCrit)
        {
            if (isCrit == true && Weapon != null)
            {
                power = (Player.power + weapon.BonusDamage) * 2;
            }
            if (isCrit == true)
            {
                power = Player.power * 2;
            }
            else if (Weapon != null)
            {
                power = Player.power + Weapon.BonusDamage;
            }
            else
            {

            }
            return power;
        }

        public int GetPlayerDamageWithGun(Gun weapon, int power, bool isCrit)
        {
            if (isCrit == true && Weapon != null)
            {
                power = (Player.power + weapon.BonusDamage) * 2;
                weapon.UsedAmmo();
            }
            if (isCrit == true)
            {
                power = Player.power * 2;
            }
            else if (Weapon != null)
            {
                power = Player.power + Weapon.BonusDamage;
                weapon.UsedAmmo();

            }
            else
            {

            }
            return power;
        }

        public int GetPlayerDamageWithPepperSpray(PepperSpray weapon, int power, bool isCrit)
        {
            if (isCrit == true && Weapon != null)
            {
                power = (Player.power + weapon.BonusDamage) * 2;
                weapon.AttackedWithSpray();
            }
            if (isCrit == true)
            {
                power = Player.power * 2;
            }
            else if (Weapon != null)
            {
                power = Player.power + Weapon.BonusDamage;
                weapon.AttackedWithSpray();

            }
            else
            {

            }
            return power;
        }

        public int GetMonsterDamage(int power, bool isCrit)
        {
            if (isCrit == true)
            {
                power = Monster.power * 2;
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
