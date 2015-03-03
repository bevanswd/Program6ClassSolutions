using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritancesAndInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee TheDude = new Employee("John", "McClary", "Known Liar");
            TheDude.Talk();

            Janitor jeff = new Janitor("jeff", "macco");
            jeff.Sweep();
            jeff.Clean();
            jeff.Talk();

            Musician Laura = new Musician("Laura", "Boyd", "Piano");
            Laura.Jam();

            Bird bird = new Bird();

            List<ISing> listOfThingsThatSing = new List<ISing>();
            listOfThingsThatSing.Add(Laura);
            listOfThingsThatSing.Add(bird);

            foreach (ISing somethingThatSings in listOfThingsThatSing)
            {
                somethingThatSings.Sing();
            }
            Console.ReadKey();
        }
    }

//regions are great for hiding stuff
#region "Inheritence Stuff / Classes"

    //abstract class: canNOT be instantiated (this will be our BASE-class) (gives a model/framework)
    public abstract class Person
    { 
        //PROPERTIES
        public string FirstName { get; set; }
        public string LastName { get; set; }

        //CONSTRUCTOR
        public Person(string fname, string lname)
        {
            //instantiate properties (can do within constructor)
            this.FirstName = fname; this.LastName = lname;
        }

        //methods (must go in base class)
        public void Walk()
        {
            Console.WriteLine("whistling sounds");
        }

        //we need to use virtual cuz we're overriding the behavior of this method in a child class
        public virtual void Talk()
        {
            Console.WriteLine("hey howsit goin");
        }

        //*** we can only write methods that inherit from within that class (unless we override it)
    }

    //new class "Employee" inherits the person class (with ':')
    public class Employee : Person
    {
        //property
        public string JobTitle { get; set; }

        //constructor
        public Employee(string fname, string lname, string jobTitle) : base(fname, lname)
        {
            this.JobTitle = jobTitle; //represent paramater, pass it to the property
        }

        //methods
        //override the base class method (this will allows us to grab methods from other classes)
        public override void Talk()
        { 
            //if we want to include the bass class behavior
            // (base will reference the person class, cuz that's the base class. now you can talk about other stuff)
            base.Talk();
            //talk about job
            Console.WriteLine("I'm a {0}. Synergize the paradigm.", this.JobTitle);
            
        }
    }

    //create another new class (inherit from "employee")
    public class Janitor : Employee
    {
        //property
        public int NumberOfBrooms { get; set; }

        //constructor -> pass down to constructor
        public Janitor(string fname, string lname) : base(fname, lname, "Janitor")
        { 
            //nothing needs to go in the constructor, cuz the base classes handle it for us
            this.NumberOfBrooms = 3; //we could do this i guess
        }

        //methods
        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("yo yo i'm a janitor");
        }

        public void Sweep()
        {
            Console.WriteLine("sweep sweep sweep");
        }

        public void Clean()
        {
            Console.WriteLine("damn this spill is dank");
        }
    }

    //another class inheriting from "employee"
    public class Musician : Employee, ISing //will inherit from 'ISing' interface
    { 
        //set property
        public string Instrument {get; set; }
        //set constructor
        public Musician(string fname, string lname, string instrument) : base(fname, lname, "Musician")
        {
            this.Instrument = instrument;
        }

        //methods
        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("i like to wail on my {0}", this.Instrument);
        }

        public void Jam()
        {
            Console.WriteLine("jammin on my {0}", this.Instrument);
        }

        public void Sing()
        {
            Console.WriteLine("lalalala");
        }
    }

//end region
#endregion

#region "Interfaces"

    interface ISing
    { 
        //framework for describing something that sings
        //provides no information on how it sings (doesn't implement how it sings)

        //create function called 'sing' (will return void, & automatically implement all containing information)
        void Sing();
    }

    class Bird : ISing
    {
        public void Sing()
        {
            Console.WriteLine("peep peep");
        }
    }

    interface ICombustionEngine //'I' stands for interface
    {
        //set property
        int FuelLevel { get; set; }
        //fuel level
        void Refuel(int fuel);
        //go
        void Go();
    }

    public class Jet : ICombustionEngine
    { 
        //property
        public int FuelLevel { get; set; }
        //function
        public void Refuel(int fuel)
        {
            this.FuelLevel += fuel;
        }

        //implement "Go" function
        public void Go()
        {
            if (FuelLevel > 25)
            {
            Console.WriteLine("VRRrooooommm");
            this.FuelLevel -= 25;
            }
            else
            {
                Console.WriteLine("woops, out of gas...");
            }
        }
        //Jet with fuel level
        public Jet()
        {
            this.FuelLevel = 20;
        }
    }

    public class Generator : ICombustionEngine 
    {
        public int FuelLevel { get; set; }
        public Generator()
        {
            this.FuelLevel = 20;
        }
        public void Refuel(int fuel)
        {
            this.FuelLevel = 20;
        }
        public void Go()
        {
            if (this.FuelLevel > 10)
            {
                Console.WriteLine("I'm producint 25 kw");
                this.FuelLevel -= 10;
            }
            else 
            {
                Console.WriteLine("out of gas");
            }
        }
    }
    
#endregion
}
