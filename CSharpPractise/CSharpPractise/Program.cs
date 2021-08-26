using CSharpPractise.Models;
using CSharpPractise.Utils;
using System;
using System.Collections.Generic;

namespace CSharpPractise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groups = new List<Group>();

            while (true)
            {
                Helper.Print(ConsoleColor.Yellow, "1 - Qrup yaratmaq, 2 - Telebe elave etmek, 3 - Telebeni silmek," +
                    "4 - Telebelerin siyahisini gostermek, 5 - Axtarish etmek, 6 - Chixish");

                string result = Console.ReadLine();
                bool isInt = int.TryParse(result, out int menu);
                if (isInt && (menu >= 1 && menu <= 6))
                {
                    if (menu == 6)
                    {
                        break;
                    }

                    switch (menu)
                    {
                        case 1:
                            Helper.Print(ConsoleColor.DarkBlue, "Qrup adini daxil edin");
                            string groupName = Console.ReadLine();
                            selectMaxCount:
                            Helper.Print(ConsoleColor.DarkBlue, "Qrupun tutumunu daxil edin");
                            result = Console.ReadLine();
                            isInt = int.TryParse(result, out int maxCount);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, "Eded daxil edin");
                                goto selectMaxCount;
                            }

                            bool isExistGroup = groups.Exists(x => x.Name.ToLower() == groupName.ToLower());
                            if (isExistGroup)
                            {
                                Helper.Print(ConsoleColor.Red, $"{groupName} bu adda qrup movcuddur");
                                goto case 1;
                            }

                            Group newGroup = new Group(groupName, maxCount);
                            groups.Add(newGroup);
                            Helper.Print(ConsoleColor.Green, $"{groupName} qrupu yaradildi");
                            break;
                        case 2:
                            Helper.Print(ConsoleColor.DarkBlue, "Telebenin adini daxil edin");
                            string name = Console.ReadLine();
                            Helper.Print(ConsoleColor.DarkBlue, "Telebenin soyadini daxil edin");
                            string surname = Console.ReadLine();

                            selectGroup:

                            Helper.Print(ConsoleColor.Yellow, "Movcud qruplardan sechin");
                            foreach (Group group in groups)
                            {
                                Helper.Print(ConsoleColor.Green, group.ToString());
                            }

                            string selectedGroup = Console.ReadLine();
                            Group existGroup = groups.Find(x => x.Name.ToLower() == selectedGroup.ToLower());
                            if (existGroup == null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{selectedGroup} qrup yoxdur.");
                                goto selectGroup;
                            }

                            Student newStudent = new Student(name, surname);
                            bool isAdded = existGroup.AddStudentToGroup(newStudent);
                            if (!isAdded)
                            {
                                Helper.Print(ConsoleColor.Red, $"Qrup limitini kechmisiz.");
                                goto selectGroup;
                            }

                            Helper.Print(ConsoleColor.Green, $"{newStudent} {existGroup} qrupuna elave olundu");

                            break;
                        case 3:
                            Helper.Print(ConsoleColor.Yellow, "Movcud qruplardan sechin");
                            foreach (Group group in groups)
                            {
                                Helper.Print(ConsoleColor.Green, group.ToString());
                            }
                            chooseGroup:
                            selectedGroup = Console.ReadLine();
                            existGroup = groups.Find(x => x.Name.ToLower() == selectedGroup.ToLower());
                            if (existGroup == null)
                            {
                                Helper.Print(ConsoleColor.Red, $"{selectedGroup} qrup yoxdur.");
                                goto chooseGroup;
                            }

                            selectStudent:

                            Helper.Print(ConsoleColor.Yellow, "Telebelerden silmek istediyinizi sechin.");
                            existGroup.ShowAllStudents();

                            result = Console.ReadLine();
                            isInt = int.TryParse(result, out int studentId);
                            if (!isInt)
                            {
                                Helper.Print(ConsoleColor.Red, $"Id-ni duzgun daxil edin.");
                                goto selectStudent;
                            }

                            bool isDeleted = existGroup.RemoveStudentFromGroup(studentId);
                            if (!isDeleted)
                            {
                                Helper.Print(ConsoleColor.Red, $"Movcud student sechin.");
                                goto selectStudent;
                            }

                            Helper.Print(ConsoleColor.Green, $"{studentId} id-li student silindi.");

                            break;
                        case 4:
                            Helper.Print(ConsoleColor.Yellow, "Telebelerin siyahisi:");
                            foreach (Group group in groups)
                            {
                                group.ShowAllStudents();
                            }
                            break;
                        case 5:
                            Helper.Print(ConsoleColor.Yellow, "Telebenin adini daxil edin.");
                            name = Console.ReadLine();

                            foreach (Group group in groups)
                            {
                                List<Student> foundStudents = group.Search(name);
                                foreach (Student student in foundStudents)
                                {
                                    Helper.Print(ConsoleColor.Green, student.ToString());
                                }
                            }

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Helper.Print(ConsoleColor.Red, "Gosterilen ededlerden sechin.");
                }
            }
        }
    }
}
