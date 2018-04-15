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
            //_3DPoint[,,] matrix = new SquareGenerator(-1 * Math.Sqrt(0.6), 0, Math.Sqrt(0.6)).getMatrix();


            //for(int i = 1; i <= 20; i++)
            //{
            //    _3DPoint point = FI.magicDictionary[i];
            //    _3DPoint coord = FI.ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            //    for (int j = 1; j <= 20; j++)
            //    {
            //        Console.Write(FI.getFi(j, coord.X, coord.Y, coord.Z));
            //    }
            //    Console.WriteLine();
            //}

            double[,,] result = DFIABG.Generate();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(result[15,2,i]);
            }


            //_3DPoint point = FI.magicDictionary[1];
            //Console.WriteLine($"{point.X} {point.Y} {point.Z}");

            
            //Console.WriteLine($"{coord.X} {coord.Y} {coord.Z}");

            //Console.WriteLine(FI.get(1, coord.X, coord.Y, coord.Z));
            //Divider a = new Divider(10, 10, 10, 2, 2, 2);

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
