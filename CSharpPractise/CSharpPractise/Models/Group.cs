using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractise.Models
{
    partial class Group
    {
        public string Name { get; set; }

        public int MaxCount { get; set; }

        public int Id { get; }

        private static int _id = 0;

        private List<Student> _students;

        public Group()
        {
            _id++;
            Id = _id;
            _students = new List<Student>();
        }

        public Group(string name, int maxCount) : this()
        {
            Name = name;
            MaxCount = maxCount;
        }
    }
}
