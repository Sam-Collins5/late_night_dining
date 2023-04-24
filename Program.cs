using Project_5;

//Mock program to demo the method
Player player = new Player();
Monster monster = new Monster();
Battle battle = new Battle(player, monster);
Battling(battle);

//Method for running a battle
static void Battling(Battle battle)
{
    Console.WriteLine($"You ran into {battle.Monster.name}! - {battle.Monster.desc}");
    Console.WriteLine($"A battle has begun!");
    battle.Turn = battle.InitativeRoll();
    if (battle.Turn == 0)
    {
        Console.WriteLine($"{battle.Player.name} goes first.");
    }
    else
    {
        Console.WriteLine($"{battle.Monster.name} goes first.");
    }
    
    while (battle.IsBattling == true)
    {
        if (battle.Turn == 0)
        {
            Console.WriteLine("It's your turn.");
            Console.WriteLine($"You attack {battle.Monster.name}.");
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
                Console.WriteLine($"Your attack hits dealing {battle.GetPlayerDamage(battle.Weapon, battle.Player.power, battle.IsCrit)} damage.");
                Console.WriteLine($"{battle.Monster.name} has {battle.Monster.health} health remaining");
                battle.ChangeTurn();
            }
        }
        else
        {
            Console.WriteLine($"It's {battle.Monster.name}'s turn.");
            Console.WriteLine($"{battle.Monster.name} attacks you with {battle.Monster.attack}!");
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
                Console.WriteLine($"The attack hits dealing {battle.GetMonsterDamage(battle.Monster.power, battle.IsCrit)} damage.");
                Console.WriteLine($"You have {battle.Player.health} health remaining.");
                battle.ChangeTurn();
            }
        }

        if (battle.Player.health <= 0)
        {
            Console.WriteLine("You died! Game Over!");
            battle.IsBattling = false;
        }
        else if (battle.Monster.health <= 0)
        {
            Console.WriteLine($"You defeated {battle.Monster.name}!");
            battle.IsBattling = false;
        }
    }
}