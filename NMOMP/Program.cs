using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NMOMP
{
    class Program
    {
        static void Main(string[] args)
        {
            //_3DPoint[,,] matrix = new SquareGenerator(-1, 0, 1).getMatrix();
            //Dictionary<int, _3DPoint> magicDictionary = Globals.magicDictionary;

            //_3DPoint p = magicDictionary[3];
            //Console.WriteLine(matrix[(int)p.X, (int)p.Y, (int)p.Z]);

            //for (int i = 1; i <= 20; i++)
            //{
            //    _3DPoint point = FI.magicDictionary[i];
            //    _3DPoint coord = FI.ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            //    for (int j = 1; j <= 20; j++)
            //    {
            //        Console.Write(FI.getFi(j, coord.X, coord.Y, coord.Z));
            //    }
            //    Console.WriteLine();
            //}

            //double[,,] result = DFIABG.Generate();

            //for (int i = 0; i < 27; i++)
            //{
            //    Console.WriteLine(result[i, 0, 0]);
            //}

            //Divider a = new Divider(4, 4, 4, 4, 4, 4);
            //foreach (FiniteElement item in a.finiteElement)
            //{
            //    double[,,] dxyzabg = DXYZABG.Generate(item.matrix);
            //    item.DXYZABG = dxyzabg;
            //    item.DJ = DJ.Generate(dxyzabg);
            //}

            Divider a = new Divider(4, 4, 4, 4, 4, 4);

            double[,,] result = DXYZABG.Generate(a.finiteElement[0].matrix);

            double[] dj = DJ.Generate(result);

            for (int i = 0; i < 27; i++)
            {
                Console.WriteLine(dj[i]);
            }

            ////Console.Write("{0,-5}", "data");
            ////Console.Write("Hello");

            ////List<int> a = new List<int>();
            ////a.Add(1);
            ////a.Add(2);
            ////a.Add(3);
            ////Console.WriteLine(a[a.Count - 1]);
        }
    }
}
