using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalsInherit
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Talk();
            Console.WriteLine(dog.NoOfLegs);
            Console.ReadLine();
        }
    }
}
