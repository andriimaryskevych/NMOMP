using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class DXYZABG
    {
        public static double[,,] Generate(LabelPoint[,,] finiteElement)
        {
            double[,,] result = new double[3, 3, 27];
            _3DPoint[,,] matrix = new SquareGenerator(-1 * Math.Sqrt(0.6), 0, Math.Sqrt(0.6)).getMatrix();
            Dictionary<int, _3DPoint> magicDictionary = Globals.magicDictionary;

            //// to delete
            //double[] oksana = new double[] { -1 * Math.Sqrt(0.6), 0, Math.Sqrt(0.6) };
            //// to delete
            //for (int i = 0; i < 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        for (int k = 0; k < 3; k++)
            //        {
            //            lst.Add(new _3DPoint(oksana[i], oksana[j], oksana[k]));
            //        }
            //    }
            //}

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

            _3DPoint p = null;
            double globalCoordinate = 0;
            double diFi = 0;
            double sum = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 27; k++)
                    {
                        sum = 0;
                        for (int l = 1; l <= 20; l++)
                        {
                            p = magicDictionary[l];
                            globalCoordinate = finiteElement[(int)p.X, (int)p.Y, (int)p.Z].value[i];
                            diFi = FI.getDiFi(j + 1, l, lst[k].X, lst[k].Y, lst[k].Z);
                            sum += globalCoordinate * diFi;
                        }
                        result[i, j, k] = sum;
                    }
                }
            }

            return result;
        }
    }
}
