using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redacted
{
    public class Student
    {
        //TimeSpan?
        private int age = 0;
        public Guid Id
        {
            get; //readonly
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get { return age; } }
        public List<string> CourseSignups { get; set; }
        public List<(string Classname, int grade)> Coursegrades { get; set; }

        public Student(string firstName, string lastname, DateTime birthday)
        {
            Id = Guid.NewGuid();
            Firstname = firstName;
            Lastname = lastname;
            Birthday = birthday;
            age = DateTime.Now.Year - Birthday.Year;
            CourseSignups = new List<string>();
            Coursegrades = new List<(string Classname, int grade)> { };

        }
        public override string ToString()
        {
            return $"This student's name is {Firstname} {Lastname}, their age is {Age} and they have completed the following classes:";
        }

        public string SignUpStudentToClass(string course)
        {  
            CourseSignups.Add(course);          
            return $"The student has been added to {course}";
        }
        public string AddStudentGrade(string course, int grade)
        {
            Coursegrades.Add((course, grade));
            return $"You have successfully added the grade {grade} to class {course}";
        }

    }//Student
    internal class T10Student
    {
        public static void TestT10(Student student) 
        {

        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string[] firstnames = { "Helene", "Turbo", "Sammy", "Vinny", "Hercules", "Emily", "Matthew" };
            string[] lastnames = { "Schjerfbeck", "Soaker", "Trevor", "Gonzales", "Poirot", "Morgenthal", "Murdock" };
            DateTime[] birthdays = { new DateTime(1989,2,2), new DateTime(1989, 9,9), new DateTime(1989, 2, 2), new DateTime(1999, 8,21), new DateTime(2005, 7, 7), new DateTime(2002,4, 30), new DateTime(2000, 4, 3) };
            string[] courses = {"Physics", "Programming 1", "Programming 2", "Physics 2", "Math 1", "English 3", "Spanish 4" };
            for (int i = 0; i < 7;i++)
            {
                Student student = new Student(firstnames[i], lastnames[i], birthdays[i]);
                string add = student.SignUpStudentToClass(courses[i]);
                Console.WriteLine(add);
                TestT10(student);
                students.Add(student);
            }

            students[3].AddStudentGrade(courses[3], 5);
            students[4].AddStudentGrade(courses[2], 2);

            foreach (Student student in students)
            {
                Console.WriteLine(student);

            }

            Console.ReadKey();

        }//Main
    }
}
