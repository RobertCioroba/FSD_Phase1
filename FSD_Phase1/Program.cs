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
        static readonly string context = "C:/Users/robert_mihai/source/repos/FSD_Phase1/FSD_Phase1/Input.txt";

        class Teacher
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public string Section { get; set; }
        }

        static void Main(string[] args)
        {
            List<Teacher> teachers = new List<Teacher>();

            if(File.Exists(context))
            {
                using(StreamReader file = new StreamReader(context))
                {
                    string teacherLine;
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

                    file.Close();
                }
            }

            foreach (var teacher in teachers)
                Console.WriteLine(teacher.Id + " " + teacher.Name + " " + teacher.Class + " " + teacher.Section);

            Console.ReadLine();
        }
    }
}
