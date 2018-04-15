using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class SquareGenerator
    {
        double[] value;
        // c-tor accepts 3 parameters: lower, middle and higher bounds
        // -1 , 0 , 1 will create 27 nodes [3][3][3]
        // [0][0][0] of which would be equal to new Point(-1,1,-1)
        public SquareGenerator(double lower, double middle, double higher)
        {
            value = new double[] { lower, middle, higher };
        }

        public _3DPoint[, , ] getMatrix()
        {
            _3DPoint[,,] matrix = new _3DPoint[3, 3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        matrix[i, j, k] = new _3DPoint(value[k], value[2 - j], value[i]);
                        //Console.WriteLine($"{value[k]}, {value[2 - j]}, {value[i]}");
                    }
                }
            }
            return matrix;
        }
    }
}
