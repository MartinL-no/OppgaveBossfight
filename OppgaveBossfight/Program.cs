using System;
using System.ComponentModel;

namespace OppgaveBossfight;
class Program
{
    static void Main(string[] args)
    {
        var rand = new Random();
        var randomStrength = rand.Next(31);
        
        var Hero = new GameCharacter("Hero", 100, 20, 40);
        var Boss = new GameCharacter("Boss", 400, randomStrength, 10);

        RunGame(Hero, Boss);
    }
    static void RunGame(GameCharacter Hero, GameCharacter Boss)
    {
        var rand = new Random();
        bool isHeroesTurn = rand.Next(2) == 1;

        while (true)
        {
            CharacterTurn(isHeroesTurn, Hero, Boss);

            if (Hero.Health == 0)
            {
                Console.WriteLine($"{Boss.Name} is the winner!");
                break;
            }
            else if (Boss.Health == 0)
            {
                Console.WriteLine($"{Hero.Name} is the winner!");
                break;
            }
            isHeroesTurn = !isHeroesTurn;
        }
    }
    static void CharacterTurn(bool isHeroesTurn, GameCharacter hero, GameCharacter boss)
    {
        if (isHeroesTurn)
        {
            hero.Fight(boss);
        }
        else
        {
            boss.Fight(hero);
        }
    }
}