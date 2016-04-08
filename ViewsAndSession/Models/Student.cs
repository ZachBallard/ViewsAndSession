using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewsAndSession
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public Student()
        {

        }
        public Student(string first, string last, string gender, int age)
        {
            FirstName = first;
            LastName = last;
            Gender = gender;
            Age = age;
        }

    }
}