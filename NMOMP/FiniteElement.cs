using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class FiniteElement
    {
        public LabelPoint[,,] matrix;
        public double[,,] DXYZABG;
        public double[] DJ;
        public int number;

        public FiniteElement(LabelPoint[,,] matrix, int number)
        {
            this.matrix = matrix;
        }
    }
}
