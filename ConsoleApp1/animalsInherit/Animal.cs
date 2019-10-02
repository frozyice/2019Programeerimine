using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace animalsInherit
{
    public abstract class Animal
    {
        public virtual int NoOfLegs { get; set; }
        public abstract void Talk();
    }
}
