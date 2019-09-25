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
            ChangeStatus(student, Student.Status.Studing);
            student.GroupName = Name;

        }

        public void ChangeStatus (Student student, Student.Status newStatus)
        {
            student.StudentStatus = newStatus;
        }

        public void RemoveStudent (Student student, Student.Status newStatus)
        {
            foreach (Student element in students)
            {
                if (element==student)
                {
                    ChangeStatus(student, newStatus);
                    students.Remove(element);
                    student.GroupName = "none";
                    break;
                }
            }
        }

 

        public void Print()
        {
            foreach (Student element in students)
            {
                Console.WriteLine(element);
            }
          
        }

  
    }
}
