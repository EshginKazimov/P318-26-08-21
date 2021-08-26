using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractise.Models
{
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; }

        private static int _id = 0;

        public Student()
        {
            _id++;
            Id = _id;
        }

        public Student(string name, string surname) : this()
        {
            Name = name;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Id} - {Name} {Surname}";
        }
    }
}
