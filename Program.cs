/**
*--------------------------------------------------------------------
* File name: Program.cs
* Project name: 1260-002-CrumpNick-CollinsSam-FlahertyLogan-Project5
*--------------------------------------------------------------------
* Author’s name and email: Nick Crump, CRUMPNA@ETSU.EDU
*                          Logan Flaherty   Personal: loganoflaherty@outlook.com    School: flahertyl@etsu.edu
*                          Sam Collins (collinss5@etsu.edu)
* Course-Section: CSCI 1260-002
* Creation Date: 4/27/2023
* -------------------------------------------------------------------
*/

using Project_5;
using Project_5.Weapon_Classes;
using System.Diagnostics.Metrics;

Console.WriteLine("Enter a username:");
string username = Console.ReadLine();

Player player = new Player(username);
Monster monster = new Monster();
DungeonMap dungeonMap = new DungeonMap();

bool check = true;

while (check == true)
{
    int intInput = -1;
    string stringInput = "";
    Console.WriteLine($"\n{dungeonMap.GetMapDisplay()}\nYour position is: {dungeonMap.GetPlayerPos()}");
    Console.WriteLine("--------------COMMANDS--------------\n[1] Move\n[2] Display Player Info\n[3] Equip a weapon\n[4] Throw away a weapon\n[5] Pickup a weapon");
    try
    {
        intInput = Convert.ToInt32(Console.ReadLine());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    switch (intInput)
    {
        //Move
        case 1:
            stringInput = Console.ReadLine();
            Console.WriteLine($"{player.Move(stringInput, dungeonMap)}\nPress Enter to continue:");
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            if (dungeonMap.GetPlayerCell().monster != null)
            {
                Battle battle = new Battle(player, dungeonMap.GetPlayerCell().monster);
                Battling(battle);
                player.Score = player.Score + 500;
                if (player.Health > 0)
                {
                    Console.WriteLine($"{player.Name} earned 500 points for defeating {dungeonMap.GetPlayerCell().monster.nameToString()}!");
                    dungeonMap.GetPlayerCell().monster = null;
                    Console.WriteLine("Press Enter to continue:");
                    Console.ReadLine();
                    Console.WriteLine("--------------------------------------------------------");
                }
                else
                {
                    check = false;
                }
            }
            if (dungeonMap.GetPlayerCell().cellType == (CellType)Enum.Parse(typeof(CellType), "Exit"))
            {
                player.Score = player.Score + 2000;
                Console.WriteLine($"Found the Exit!\n{player.Name} earned 2000 points for completing a dungeon!");
                dungeonMap = new DungeonMap();
                Console.WriteLine("Press Enter to continue:");
                Console.ReadLine();
                Console.WriteLine("--------------------------------------------------------");
            }
            break;
        //Pickup Weapon
        case 5:
            Console.WriteLine($"{player.PickUp(dungeonMap.GetPlayerCell())}\nPress Enter to continue.");
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------"); 
            break;
        //Display Inventory
        case 2:
            Console.WriteLine($"{player.ToString()}\nPress Enter to continue:");
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            break;
        //Equip Weapon
        case 3:
            Console.WriteLine(player.DisplayInventory());
            stringInput = Console.ReadLine();
            Console.WriteLine($"{player.Equip(stringInput)}\n\nPress Enter to continue:");
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            break;
        case 4:
            Console.WriteLine(player.DisplayInventory());
            stringInput = Console.ReadLine();
            Console.WriteLine($"{player.ThrowAway(stringInput)}\n\nPress Enter to continue:");
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------");
            break;
        default:
            break;
    }
}
player.SaveScore();
Console.WriteLine(player.DisplayHighScores());


//Method for running a battle
static void Battling(Battle battle)
{
    Console.WriteLine($"You ran into {battle.Monster.nameToString()} the {battle.Monster.Type}! - {battle.Monster.Desc}");
    Console.WriteLine($"A battle has begun!");
    battle.Turn = battle.InitativeRoll();
    if (battle.Turn == 0)
    {
        Console.WriteLine($"{battle.Player.Name} goes first.");
    }
    else
    {
        Console.WriteLine($"{battle.Monster.nameToString()} goes first.");
    }
    
    while (battle.IsBattling == true)
    {
        //Thread.Sleep(700);
        if (battle.Turn == 0)
        {
            Console.WriteLine("It's your turn.");
            if (battle.Player.Hand is Gun)
            {
                if (battle.GetGunAmmo((Gun)battle.Player.Hand) > 0)
                {
                    Console.WriteLine($"You attack {battle.Monster.nameToString()}.");
                    int attack = battle.AttackRoll();
                    if (attack < 3)
                    {
                        Console.WriteLine("Your attack misses.");
                        battle.ChangeTurn();
                    }
                    else
                    {
                        battle.PlayerAttack();
                        if (attack == 20)
                        {
                            Console.WriteLine("CRITICAL HIT!");
                        }
                        Console.WriteLine($"Your attack hits dealing {battle.GetPlayerDamageWithGun((Gun)battle.Weapon, battle.Player.Power, battle.IsCrit)} damage.");
                        Console.WriteLine($"{battle.Monster.nameToString()} has {battle.Monster.Health} health remaining");
                        battle.ChangeTurn();
                    }
                }
                else
                {
                    Console.WriteLine("No ammo left. Switch your weapon...");
                    bool userVal = false;
                    while (userVal == false)
                    {
                        Console.WriteLine(battle.Player.DisplayInventory());
                        Console.WriteLine("Pick a weapon.");
                        string userPick = Console.ReadLine();
                        battle.Player.Equip(userPick);
                        battle.Weapon = battle.Player.Hand;
                        Console.Write("Would you like to continue (yes or no)? ");
                        string userInput = Console.ReadLine().ToLower();
                        if (userInput == "yes")
                        {
                            userVal = true;
                        }
                    }
                }
            }
            else if (battle.Player.Hand is PepperSpray)
            {
                bool checkUses = battle.GetPepperSprayLeft((PepperSpray)battle.Player.Hand);
                if (checkUses) 
                {
                    Console.WriteLine($"You attack {battle.Monster.nameToString()}.");
                    int attack = battle.AttackRoll();
                    if (attack < 3)
                    {
                        Console.WriteLine("Your attack misses.");
                        battle.ChangeTurn();
                    }
                    else
                    {
                        battle.PlayerAttack();
                        if (attack == 20)
                        {
                            Console.WriteLine("CRITICAL HIT!");
                        }
                        Console.WriteLine($"Your attack hits dealing {battle.GetPlayerDamageWithPepperSpray((PepperSpray)battle.Weapon, battle.Player.Power, battle.IsCrit)} damage.");
                        Console.WriteLine($"{battle.Monster.nameToString()} has {battle.Monster.Health} health remaining");
                        battle.ChangeTurn();
                    }

                }
                else
                {
                    Console.WriteLine("No spray left. Switch your weapon...");
                    bool userVal = false;
                    while (userVal == false)
                    {
                        Console.WriteLine(battle.Player.DisplayInventory());
                        Console.WriteLine("Pick a weapon.");
                        string userPick = Console.ReadLine();
                        battle.Player.Equip(userPick);
                        battle.Weapon = battle.Player.Hand;
                        Console.Write("Would you like to continue (yes or no)? ");
                        string userInput = Console.ReadLine().ToLower();
                        if (userInput == "yes")
                        {
                            userVal = true;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine($"You attack {battle.Monster.nameToString()}.");
                int attack = battle.AttackRoll();
                if (attack < 3)
                {
                    Console.WriteLine("Your attack misses.");
                    battle.ChangeTurn();
                }
                else
                {
                    battle.PlayerAttack();
                    if (attack == 20)
                    {
                        Console.WriteLine("CRITICAL HIT!");
                    }
                    Console.WriteLine($"Your attack hits dealing {battle.GetPlayerDamage(battle.Weapon, battle.Player.Power, battle.IsCrit)} damage.");
                    Console.WriteLine($"{battle.Monster.nameToString()} has {battle.Monster.Health} health remaining");
                    battle.ChangeTurn();
                }
            } 
        }
        else
        {
            Console.WriteLine($"It's {battle.Monster.nameToString()}'s turn.");
            Console.WriteLine($"{battle.Monster.nameToString()} attacks you with {battle.Monster.Attack}!");
            int attack = battle.AttackRoll();
            if (attack < 5) 
            {
                Console.WriteLine($"The attack misses.");
                battle.ChangeTurn();
            }
            else
            {
                battle.MonsterAttack();
                if (attack == 20)
                {
                    Console.WriteLine("CRITICAL HIT!");
                }
                Console.WriteLine($"The attack hits dealing {battle.GetMonsterDamage(battle.Monster.Power, battle.IsCrit)} damage.");
                Console.WriteLine($"You have {battle.Player.Health} health remaining.");
                battle.ChangeTurn();
            }
        }

        if (battle.Player.Health <= 0)
        {
            Console.WriteLine("You died! Game Over!");
            battle.IsBattling = false;
        }
        else if (battle.Monster.Health <= 0)
        {
            Console.WriteLine($"You defeated {battle.Monster.nameToString()}!");
            battle.IsBattling = false;
        }
    }
}