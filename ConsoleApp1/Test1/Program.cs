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
            Student karmo = new Student("Karmo", "Kiima");
            Student karl = new Student("Karl", "Karimõisa");
            Student kevin = new Student("Kevin", "Saar");

            Group targe = new Group("TARge18");

            targe.AddStudent(karmo);
            targe.AddStudent(karl);
            targe.AddStudent(kevin);

            targe.Print();

            Console.ReadLine();
        }
    }
}
