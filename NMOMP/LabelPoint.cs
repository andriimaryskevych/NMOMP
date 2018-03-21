using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class LabelPoint
    {
        public double x;
        public double y;
        public double z;

        public int global;
        public int local;
        public int belongElementNumber;

        public LabelPoint(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", x, y, z);
        }
    }
}
