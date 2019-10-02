using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalsInherit
{
    public class Bird : Animal
    {
        public override void Talk()
        {
            Console.WriteLine("Chirp!");
        }
    }
}
