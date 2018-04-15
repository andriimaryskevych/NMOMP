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
        public double[] value;

        public int global;
        public int local;
        public int belongElementNumber;

        public LabelPoint(double _x, double _y, double _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
            value = new double[] { x, y, z };
        }

        public LabelPoint(LabelPoint point)
        {
            this.x = point.x;
            this.y = point.y;
            this.z = point.z;
            this.global = point.global;
            this.belongElementNumber = point.belongElementNumber;

            value = new double[] { x, y, z };
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}", x, y, z);
        }
    }
}
