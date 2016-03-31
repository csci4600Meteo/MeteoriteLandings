using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnnotationLibrary
{
    class Loc
    {
        private double coordX;
        private double coordY;

        public Loc()
        {
            coordX = 0.0;
            coordY = 0.0;
        }

        public Loc(double x, double y)
        {
            coordX = x;
            coordY = y;
        }
    }
}
