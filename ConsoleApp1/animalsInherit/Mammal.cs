using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalsInherit
{
    public class Mammal : Animal
    {
        public override int NoOfLegs { get { return 4; } }
        public override void Talk(){ }
    }
}
