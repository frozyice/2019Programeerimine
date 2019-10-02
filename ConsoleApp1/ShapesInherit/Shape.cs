using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInherit
{
    public abstract class Shape
    {
        public abstract double Wide { get; set; }
        public abstract double Height { get; set; }
        public abstract double SurfaceArea();
        public abstract double Perimeter();
    }
}
