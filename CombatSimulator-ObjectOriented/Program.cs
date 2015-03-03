using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game();
            myGame.PlayGame();
            //keep it open
            Console.ReadKey();
        }
    }

    class Actor
    { 
        //PROPERTIES
        //player name
        public string Name { get; set; }
        //health
        public int HP { get; set; }
        //check if HP is greater than 0
        public bool IsAlive { get {return this.HP > 0;} }
        //random number generator
        public Random rng = new Random();

        //CONSTRUCTOR
        public Actor(string name, int initialHP)
        { 
            //create players
            this.Name = name; this.HP = initialHP;
        }
        //METHODS
        //function to choose attack
        public virtual void DoAttack(Actor actor)
        {
            
        }

    }
    class Enemy : Actor
    {
        //CONSTRUCTOR
        public Enemy(string name, int initialHP) : base(name, initialHP) //takes paramaters from the base class
        { 
            //bass class handles all the work, nothing needed here
        }

        //METHODS
        //attacking
        public override void DoAttack(Actor actor)
        { 
            //hit 80% chance
            if (rng.Next(0, 11) > 2)
            {
                //random damage amount 5-15
                int damage = rng.Next(5, 16);
                actor.HP -= damage;
                Console.WriteLine("{0} shot some bullets at you for {1} damage!\n", this.Name, damage);
            }
            else
            {
                //miss
                Console.WriteLine("you deflected the bullets by warping time and space!\n");
            }
        }
    }
    class Player : Actor
    {
        //ENNUM
        public enum AttackType
        {
            kungFuKick = 1,
            bendReality,
            concentrate
        }

        //CONSTRUCTOR
        public Player(string name, int initialHP) : base(name, initialHP)
        { 
            //create our player
            this.HP = initialHP; this.Name = name;
        }

        //METHODS
        //attacking
        public override void DoAttack(Actor actor)
        {
            //set damage var
            int damage;
            //choose attack type
            switch (ChooseAttack())
            {
                case AttackType.kungFuKick:
                    //hit 80% chance
                    if (this.rng.Next(0, 11) > 2)
                    {
                        //random damage amount 5-30
                        damage = rng.Next(5, 31);
                        //hit
                        actor.HP -= damage;
                        Console.WriteLine("\nYou Kung-Fu Kicked {0} in the face! NICE", this.Name, damage);
                    }
                    else
                    {
                        //miss
                        Console.WriteLine("\nYou missed!");
                    }
                    break;
                case AttackType.bendReality:
                    //random damage amount 5-15 (hit every time)
                    damage = rng.Next(5, 16);
                    actor.HP -= damage;
                    Console.WriteLine("\nYou broke through the matrix and hit Mr. Smith for {0} damage!", damage);
                    break;
                case AttackType.concentrate:
                    //heal
                    int heal = rng.Next(10, 21);
                    this.HP += heal;
                    Console.WriteLine("\nYou focused your energy and restored {0} health!", heal);
                    break;
                default:
                    break;
            }
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
        private AttackType ChooseAttack()
        {
            //validate user input
            bool validInput = false;
            int input = 0;
            do{
            Console.WriteLine(@"
Choose Your Destiny!
1. Kung-Fu Kick
2. Bend Reality
3. Concentrate");
            //get input

            //////VALIDATE INPUT HERE
            //define validInput
            validInput = int.TryParse(Console.ReadLine(), out input) && (input > 0 && input < 4);
            //if user input is invalid
            if (validInput == false)
            {
                Console.Clear();
                //return "Invalid input" message
                Console.WriteLine("Invalid input");
            }
            } while (validInput == false); //while invalid input
            //return correct attack type
            return (AttackType)input;
        }
    }
    class Game
    {
        //PROPERTIES
        public Player Player { get; set; }
        public Enemy Enemy { get; set; }

        //CONSTRUCTOR
        public Game()
        {
            this.Player = new Player("Neo", 100);
            this.Enemy = new Enemy("Mr. Smith", 200);
        }

        //Methods!
        private void DisplayCombatInfo()
        {
            //display stats
            Console.WriteLine("{0} {1} HP \n {2} {3} HP", Player.Name, Player.HP, Enemy.Name, Enemy.HP);
        }

        public void PlayGame()
        {
            //while game is still playing
            while (Player.IsAlive && Enemy.IsAlive)
            {   
                //display HP
                DisplayCombatInfo();
                //player attack
                this.Player.DoAttack(this.Enemy);
                //enemy attack
                this.Enemy.DoAttack(this.Player); 
            }
            //game over
            if (Player.IsAlive)
            {
                Console.WriteLine("{0} along with his millions of clones have been killed! You saved Zion!", this.Enemy.Name);
            }
            else
            {
                Console.WriteLine("You have merged with the collective consciousness. you didn't save Zion. \nGAME OVER");
            }
        }
    }
}