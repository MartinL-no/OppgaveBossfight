using System;

namespace OppgaveBossfight
{
    
    public class GameCharacter
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Stamina { get; private set; }
        public int InitialStamina { get; private set; }
        public bool Invulnerable { get; private set; }

        public GameCharacter(string name, int health, int strength, int stamina)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Stamina = stamina;
            InitialStamina = stamina;
            Invulnerable = false;
        }
        public void Fight(GameCharacter opponent)
        {
            if (opponent.Invulnerable)
            {
                /* 
                 * I have not reduced the attackers stamina while the other character is invulnerable
                 * as the Boss always one with that algorithm.
                 */
                Console.WriteLine($"{opponent.Name} is invulnerable, {Name}'s attack caused no damage");
                opponent.Invulnerable = false;
            }
            else if (Stamina == 0)
            {
                Console.WriteLine($"{Name} has no stamina, {opponent.Name} was not attacked");
                Recharge();
            }
            else
            {
                opponent.Health = (opponent.Health - Strength) < 0 ? 0 : (opponent.Health - Strength);
                Stamina  = (Stamina - 10) < 0 ? 0 : (Stamina - 10);

                Console.WriteLine($"{Name} hit {opponent.Name} with {Strength} damage, {opponent.Name} now has {opponent.Health} health left.");
            }
        }
        public void Recharge()
        {
            Stamina = InitialStamina;
            Invulnerable = true;
            Console.WriteLine($"{Name}'s stamina has been restored to what it was at the start of the fight ({InitialStamina}), {Name} will take no damage during the next attack)");
        }
    }
}

