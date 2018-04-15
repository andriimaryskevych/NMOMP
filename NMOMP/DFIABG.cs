using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class DFIABG
    {
        public static double[,,] Generate()
        {
            double[,,] result = new double[27, 3, 20];
            _3DPoint[,,] matrix = new SquareGenerator(-1 , 0, 1).getMatrix();
            List<_3DPoint> lst = new List<_3DPoint>();

            for (int z = 0; z < 3; z++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        lst.Add(matrix[x, y, z]);
                    }
                }
            }

            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 20; k++)
                    {
                        result[i, j, k] = FI.getDiFi(j + 1, k + 1, lst[i].X, lst[i].Y, lst[i].Z);
                    }
                }
            }

            return result;
        }
    }
}
