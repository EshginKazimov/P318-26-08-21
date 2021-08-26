using CSharpPractise.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPractise.Models
{
    partial class Group
    {
        public override string ToString()
        {
            return Name;
        }

        public void ShowAllStudents()
        {
            if (_students.Count == 0)
            {
                return;
            }

            Helper.Print(ConsoleColor.Cyan, $"{Name} qrupun telebeleri:");
            foreach (Student student in _students)
            {
                Helper.Print(ConsoleColor.Green, student.ToString());
            }
        }

        public bool AddStudentToGroup(Student student)
        {
            //if (_students.Count == MaxCount)
            //{
            //    return false;
            //}

            //_students.Add(student);
            //return true;

            if (_students.Count < MaxCount)
            {
                _students.Add(student);
                return true;
            }

            return false;
        }

        public bool RemoveStudentFromGroup(int id)
        {
            Student existStudent = _students.Find(x => x.Id == id);
            if (existStudent == null)
            {
                return false;
            }

            _students.Remove(existStudent);
            return true;
        }

        public List<Student> Search(string name)
        {
            //List<Student> searchedStudents = _students.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
            //return searchedStudents;
            return _students.FindAll(x => x.Name.ToLower().Contains(name.ToLower()));
        }
    }
}
