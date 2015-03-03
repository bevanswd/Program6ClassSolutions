using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStudentExamples();

            /*
            Student student1 = new Student("Awesome McBigglesworth");
            student1.CourseList.Add(new Course());

            var students = new List<Student>();
            List<string> names = students.Select(x => x.Name).ToList();
            IEnumerable<Student> enrolledStudents = students.Where(x => x.CourseList.Count > 0);

            ShowCourseConstructors();
            */

            Console.ReadKey();
        }

        /// <summary>
        /// Student Properties
        /// </summary>
        static void DoStudentExamples()
        {
            //declare student name
            Student student1 = new Student("John McClary");
            //set info to student1
            //(the object is responsible for printing-out its own data)
            student1.CourseList.Add(new Course("Professional Development", "B"));
            student1.CourseList.Add(new Course("Programming", "D"));
            student1.CourseList.Add(new Course("Hockey History 101", "A"));
            student1.CourseList.Add(new Course("Being named John", "F"));
        }

        /// <summary>
        /// call various courses from the new class
        /// </summary>
        static void ShowCourseConstructors()
        {
            Course course1 = new Course();
            Course course2 = new Course("Biology");
            Course course3 = new Course("Math 101", "A");

            course1.PrintCourseInfo();
            course2.PrintCourseInfo();
            course3.PrintCourseInfo();
        }
    }

    //NEW CLASSES!!
    public class Course
    { 
        //STEP 1: DEFINING PROPERTIES
        
        //CREATING PROPERTIES

        /// <summary>
        /// NAME
        /// </summary>
        //Step 1: Create the hide-behind variable 
        //(use underscore to clarify that it's returning a value of a property)
        private string _name;
        //Step 2: Create property layer that sits on top of that variable.
        //(it controls the interaction with the variable)
        public string Name
        {
            get 
            { 
                //Getter: whenever the property is on the right side of an equation, this code is run
                //e.g. myString = myObject.Name;
                return _name.ToUpper();
            }
            set
            { 
                //Setter: whenever the property is on the left side of an equation, this code is run
                //e.g. myObject.Name = "Nickleback";
                _name = value;
                //(value is a special keyword)
            }
        }

        /// <summary>
        /// LETTER GRADE
        /// </summary>
        private string _letterGrade;
        public string LetterGrade
        {
            get { return _letterGrade;  }
            set { _letterGrade = value.ToUpper(); } //be sure to set letter to uppercase
        }

        /// <summary>
        /// GRADE POINTS 
        /// (for the Grade Points, we're gonna do a READ-ONLY property)
        /// </summary>
        public double GradePoints
        {
            get
            {
                switch (this.LetterGrade) //can exclude "this." for this example
                {
                    case "A":
                        return 4.0;
                    case "B":
                        return 3.0;
                    case "C":
                        return 2.0;
                    case "D":
                        return 1.0;
                    default:
                        return 0.0;
                }
            }
        }

        //STEP 2: DEFINING CONSTRUCTORS

        //CREATING CONSTRUCTORS

        /// <summary>
        /// Parameter-less constructor, think of it as the "default constructor"
        /// </summary>
        public Course()
        {
            this.Name = "Undefined";
            this.LetterGrade = "I";
        }

        /// <summary>
        /// Parameter-full constructor (more common), this is the constructor you'll usually be using
        /// </summary>
        /// <param name="name"></param>
        public Course(string name)
        {
            this.Name = name;
            this.LetterGrade = "I";
        }

        /// <summary>
        /// Multi-Parameter constructor
        /// </summary>
        /// <param name="name"></param>
        /// <param name="letterGrade"></param>
        public Course(string name, string letterGrade)
        {
            this.Name = name;
            this.LetterGrade = letterGrade;
        }

        //STEP 3: DEFINING METHODS (actions)

        //CREATING METHODS
        public void PrintCourseInfo()
        {
            Console.WriteLine("{0, 15} {1, 2} {2, 3}", this.Name, this.LetterGrade, this.GradePoints);
        }
    }

    public class Student
    {
        //Step 1: define properties
        //(use hide-behind variable to store the property value)
        private string _name;
        private string Name
        {
            get
            {
                return _name; //e.g. cw(myObj.Name);
            }
            set
            {
                _name = value; //e.g. myObj.Name = "Awesome McBigglesworth";
            }
        }

        //create list hide-behind var (private)
        private List<Course> _courseList;
        //create list (public)
        public List<Course> CourseList
        {
            get
            {
                return _courseList; //return _courselist
            }
            set
            {
                _courseList = value; //set value to _courselist
            }
        }

        //Make a read-only property for the GPA
        public double GPA
        {
            get 
            {
                //total grade points, divided by # of classes
                return this.CourseList.Average(x => x.GradePoints);

                //the .Average extension will do something like this...
                /*
                double totalSum = 0.0;
                for (int i = 0; i < this.CourseList.Count; i++)
                {
                    Course x = this.CourseList[i];
                    totalSum += x.GradePoints;
                }
                return totalSum / this.CourseList.Count;
                 */
            }
            set
            { 
            
            }
        }

        //(other properties might include: age, studentID, DOB, major, ClassRank, Gender, Beer Drinker, etc.

        //STEP 2: CONSTRUCTORS!!!
        public Student(string name) //it's best practice to fill constructors with all the info you need
        {
            this.Name = name; //set name property from passed parameter
            this.CourseList = new List<Course>(); //initialize course list (property on the left-hand side)
            //make sure to initialize ANY lists
        }

        //STEP 3: METHODS
        public void PrintStudentInfo()
        {
            Console.WriteLine("Name: {0}", this.Name);
            foreach (Course course in this.CourseList)
            {
                Console.WriteLine(course.Name);
                // or
                //course.PrintCourseInfo();
            }
            //or (using Lambda Expression instead of foreach loop)
            //this.CourseList.ForEach(x => x.PrintCourseInfo());

            Console.WriteLine("GPA: {0}", this.GPA);
        }
    }
}

//*****************************************************************
//prop + tab + tab (shorthand to write-out initial property syntax)
//propfull + tab + tab (shorthand to write-out full property syntax)