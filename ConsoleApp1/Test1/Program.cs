using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Student karmo = new Student("Karmo", "Kiima", 1);
            Student karl = new Student("Karl", "Karimõisa", 2);
            Student kevin = new Student("Kevin", "Saar", 3);

            Group targe = new Group("TARge18");

            targe.AddStudent(karmo);
            targe.AddStudent(karl);
            targe.AddStudent(kevin);

            targe.Print();

            targe.RemoveStudent(kevin, Student.Status.Exmatriculated);

            Console.WriteLine();
            targe.Print();

            Console.WriteLine();
            Console.WriteLine(kevin);

            Console.ReadLine();
        }
    }
}
