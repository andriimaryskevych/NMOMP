using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class DJ
    {
        // for simplicity I rename dxyzabg to m
        public static double[] Generate(double[,,] m)
        {
            double[] result = new double[27];
            

            for (int i = 0; i < 27; i++)
            {
                // j stands for jakobian
                double[,] j = new double[3, 3] {
                    { m[0,0,i], m[1,0,i], m[2,0,i] },
                    { m[0,1,i], m[1,1,i], m[2,1,i] },
                    { m[0,2,i], m[1,2,i], m[2,2,i] }
                };
                result[i] = (
                                j[0, 0] * j[1, 1] * j[2, 2] +
                                j[0, 1] * j[1, 2] * j[2, 0] +
                                j[0, 2] * j[1, 0] * j[2, 1]
                            ) -
                            (
                                j[0, 2] * j[1, 1] * j[2, 0] +
                                j[0, 1] * j[1, 0] * j[2, 2] +
                                j[0, 0] * j[1, 2] * j[2, 1]
                            );
            }

            return result;
        }
    }
}
