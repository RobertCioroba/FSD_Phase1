using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSD_Phase1
{
    public class Program
    {
        //path of the textFile
        static readonly string context = "C:/Users/robert_mihai/source/repos/FSD_Phase1/FSD_Phase1/Input.txt";

        //class for teacher properties
        class Teacher
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public string Section { get; set; }
        }

        static List<Teacher> GetTeachers() 
        {
            //declare an empty teachers list
            List<Teacher> teachers = new List<Teacher>();

            //verify if the file exists
            if (File.Exists(context))
            {
                //open the file
                using (StreamReader file = new StreamReader(context))
                {
                    string teacherLine;
                    //read the file line by line and create object with specified properties
                    while ((teacherLine = file.ReadLine()) != null)
                    {
                        string[] teacherInfo = teacherLine.Split(',');
                        Teacher teacher = new Teacher();
                        teacher.Id = teacherInfo[0];
                        teacher.Name = teacherInfo[1];
                        teacher.Class = teacherInfo[2];
                        teacher.Section = teacherInfo[3];

                        teachers.Add(teacher);
                    }

                    //close the file
                    file.Close();
                }
            }

            //return the final list
            return teachers;
        }

        //write all the objects properties after populating the list
        static void GetAll()
        {
            List<Teacher> teachers = GetTeachers();

            Console.WriteLine();
            foreach (var teacher in teachers)
            {
                Console.WriteLine("Id: " + teacher.Id);
                Console.WriteLine("Name: " + teacher.Name);
                Console.WriteLine("Class: " + teacher.Class);
                Console.WriteLine("Section: " + teacher.Section);
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void UpdateUser()
        {
            //getting the user id
            Console.WriteLine("\nEnter an existing user id: ");
            var id = Console.ReadLine();

            //fetch all the data from the file and find the selected one
            List<Teacher> teachers = GetTeachers();
            Teacher teacher = teachers.FirstOrDefault(x => x.Id.Equals(id));

            //wrong id
            if(teacher == null)
            {
                Console.WriteLine("\nUser not found. Returning to menu...");
                return;
            }

            //menu for pick what property the user want to change
            Console.WriteLine("What property do you want to change?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Class");
            Console.WriteLine("3. Section");
            Console.WriteLine("4. Return to menu");

            var option = Console.ReadKey().KeyChar;

            //pick the new value
            Console.WriteLine("\nEnter the new value: ");
            var newValue = Console.ReadLine();

            //make the change
            if (option.Equals('1'))
                teacher.Name = newValue;
            else if (option.Equals('2'))
                teacher.Class = newValue;
            else if (option.Equals('3'))
                teacher.Section = newValue;
            else if (option.Equals('4'))
                return;
            else
                Console.WriteLine("Wrong option!");

            //set the content of the file to empty
            File.WriteAllText(context, String.Empty);

            //rewrite the objects with the updated property
            using (StreamWriter writeText = new StreamWriter(context))
            {
                foreach (var user in teachers)
                {

                    writeText.WriteLine(user.Id + "," + user.Name + "," + user.Class + "," + user.Section);
                }
            }

            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            //simple menu for the final user
            while (true)
            {
                Console.WriteLine("Teacher Management Data System");
                Console.WriteLine();
                Console.WriteLine("Options:");
                Console.WriteLine("1. View all data");
                Console.WriteLine("2. Update a specific user");
                Console.WriteLine("3. Quit");

                var option = Console.ReadKey().KeyChar;

                if (option.Equals('1'))
                    GetAll();
                else if (option.Equals('2'))
                    UpdateUser();
                else if (option.Equals('3'))
                    break;
                else
                    Console.WriteLine("Wrong option!");
            }
        }
    }
}
