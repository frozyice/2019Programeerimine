using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesInherit
{
    public class Rectangle : Shape2d
    {
        public override double Wide { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override double Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override double Perimeter()
        {
            return 2*(Wide+Height);
        }

        public override double SurfaceArea()
        {
            throw new NotImplementedException();
        }
    }
}
