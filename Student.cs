using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redacted
{
    public class Student
    {
        private int age = 0;
        public Guid Id
        {
            get; //readonly
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }

        public Student(string firstName, string lastname, DateTime birthday)
        {
            Id = Guid.NewGuid();
            Firstname = firstName;
            Lastname = lastname;
            Birthday = birthday;
            age = DateTime.Now.Year - Birthday.Year;

        }
    }//Student
    internal class T10Student
    {
        public static void TestT10(Student student) 
        {

        }
        static void Main(string[] args)
        {
            string[] firstnames = { "Helene", "Turbo", "Sammy", "Vinny", "Hercules", "Emily", "Matthew" };
            string[] lastnames = { "Schjerfbeck", "Soaker", "Trevor", "Gonzales", "Poirot", "Morgenthal", "Murdock" };
            DateTime[] birthdays = { new DateTime(1989,2,2), new DateTime(1989, 9,9), new DateTime(1989, 2, 2), new DateTime(1999, 21, 8), new DateTime(2005, 7, 7), new DateTime(2002, 31,4), new DateTime(2000, 4, 3) };
            for (int i = 0; i < 7;i++)
            {
                Student student = new Student(firstnames[i], lastnames[i], birthdays[i]);
                TestT10(student);
            }
            
        }//Main
    }
}
