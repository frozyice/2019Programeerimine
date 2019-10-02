using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalsInherit
{
    public class Dog : Mammal
    {
        public override void Talk()
        {
            Console.WriteLine("Whow!");
        }
    }
}
