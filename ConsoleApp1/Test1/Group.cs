using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Group
    {
        public string Name { get; set; }
        public List<Student> students;

        public Group (string name)
        {
            Name = name;
            students = new List<Student>();
        }

        public void AddStudent (Student student)
        {
            students.Add(student);
            student.IsStudying = true;
        }

        public void Print()
        {
            Console.WriteLine(Name);
            Console.WriteLine("---------------------");
            foreach (Student element in students)
            {
                Console.WriteLine($"{element.FirstName} {element.LastName}");
            }
        }

  
    }
}
