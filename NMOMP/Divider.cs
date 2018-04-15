using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NMOMP
{
    class Divider
    {
        // this one holds all the points
        // when i devide a kube in 2x2x2 parts it's size beacames 5x5x5
        public LabelPoint[,,] matrix;
        // in case above, lists Count is equal 8
        public List<FiniteElement> finiteElement;

        public int x;
        public int y;
        public int z;

        public int m;
        public int n;
        public int k;

        private double SCALE_X;
        private double SCALE_Y;
        private double SCALE_Z;


        // After constructor executing I will have whole figure dividet into finite elements and strored into list of finite elements
        // Each such list item is represented as a 3-dimensional matrix of LabelPoints, it's some kind of point structure but with additional important propperties like:
        // lacal: it's local nnumber; global: global number in matrix()
        public Divider(int _x, int _y, int _z, int _m, int _n, int _k) {
            x = _x;
            y = _y;
            z = _z;

            m = _m;
            n = _n;
            k = _k;

            SCALE_X = (double)x / m;
            SCALE_Y = (double)y / n;
            SCALE_Z = (double)z / k;

            matrix = new LabelPoint[m * 2 + 1, n * 2 + 1, k * 2 + 1];
            finiteElement = new List<FiniteElement>();
            

            fillMatrixWithMainVertexes();
            fillMatrixWithIntermidiateVertexes();
            setGlobalNumeration();
            divideInFiniteElements();
            setLocalNumeration();
            
            //LabelPoint[,,] test = finiteElement[7];
            //for (int deltaY = 2; deltaY >= 0; deltaY--)
            //{
            //    for (int deltaX = 0; deltaX < 3; deltaX++)
            //    {
            //        if (test[deltaX, deltaY, 0] != null)
            //        {
            //            Console.Write(test[deltaX, deltaY, 0].local + " ");
            //        }
            //        else
            //        {
            //            Console.Write("  ");
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine(new string('-', 10));
            //for (int deltaY = 2; deltaY >= 0; deltaY--)
            //{
            //    for (int deltaX = 0; deltaX < 3; deltaX++)
            //    {
            //        if (test[deltaX, deltaY, 1] != null)
            //        {
            //            Console.Write(test[deltaX, deltaY, 1].local + " ");
            //        }
            //        else
            //        {
            //            Console.Write("  ");
            //        }
            //    }
            //    Console.WriteLine();
            //}
            //Console.WriteLine(new string('-', 10));
            //for (int deltaY = 2; deltaY >= 0; deltaY--)
            //{
            //    for (int deltaX = 0; deltaX < 3; deltaX++)
            //    {
            //        if (test[deltaX, deltaY, 2] != null)
            //        {
            //            Console.Write(test[deltaX, deltaY, 2].local + " ");
            //        }
            //        else
            //        {
            //            Console.Write("  ");
            //        }
            //    }
            //    Console.WriteLine();
            //}

        }

        private void fillMatrixWithMainVertexes()
        {
            for (int deltaZ = 0; deltaZ < k + 1; deltaZ++)
            {
                for (int deltaY = 0; deltaY < n + 1; deltaY++)
                {
                    for (int deltaX = 0; deltaX < m + 1; deltaX++)
                    {
                        matrix[deltaX * 2, deltaY * 2, deltaZ * 2] = new LabelPoint(SCALE_X * deltaX, SCALE_Y * deltaY, SCALE_Z * deltaZ); 
                    }
                }
            }
        }
        private void fillMatrixWithIntermidiateVertexes()
        {
            for (int deltaZ = 0; deltaZ < k + 1; deltaZ++)
            {
                for (int deltaY = 0; deltaY < n + 1; deltaY++)
                {
                    for (int deltaX = 0; deltaX < m + 1; deltaX++)
                    {
                        LabelPoint current = matrix[deltaX * 2, deltaY * 2, deltaZ * 2];
                        if (deltaX != m)
                        {
                            matrix[deltaX * 2 + 1, deltaY * 2, deltaZ * 2] = new LabelPoint(current.x + SCALE_X / 2, current.y, current.z);
                        }

                        if (deltaY != n)
                        {
                            matrix[deltaX * 2, deltaY * 2 + 1, deltaZ * 2] = new LabelPoint(current.x, current.y + SCALE_Y/2, current.z);
                        }

                        if (deltaZ != k)
                        {
                            matrix[deltaX * 2, deltaY * 2, deltaZ * 2 + 1] = new LabelPoint(current.x, current.y, current.z + SCALE_Z/2);
                        }
                    }
                }
            }
        }
        private void setGlobalNumeration()
        {
            int counter = 0;
            for(int deltaZ = 0; deltaZ < k * 2 + 1; deltaZ++)
            {
                for (int deltaY = 0; deltaY < n * 2 + 1; deltaY++)
                {
                    for (int deltaX = 0; deltaX < m * 2 + 1; deltaX++)
                    {
                        if (matrix[deltaX, deltaY, deltaZ] != null)
                        {
                            counter++;
                            matrix[deltaX, deltaY, deltaZ].global = counter;
                        }
                    }
                }
            }
            Console.WriteLine("Total node number: {0}", counter);
            //for (int deltaZ = 0; deltaZ < 1; deltaZ++)
            //{
            //    for (int deltaY = 0; deltaY < n * 2 + 1; deltaY++)
            //    {
            //        for (int deltaX = 0; deltaX < m * 2 + 1; deltaX++)
            //        {
            //            if (matrix[deltaX, deltaY, deltaZ] != null)
            //            {
            //                Console.Write(String.Format("{0,15}", matrix[deltaX, deltaY, deltaZ]));
            //            }
            //            else
            //            {
            //                Console.Write("{0,15}", " ");
            //            }
            //        }
            //        Console.WriteLine();
            //    }
            //}
        }
        private void divideInFiniteElements()
        {
            int ELEMENTS_COUNT = m * n * k;
            for (int figure = 0; figure < ELEMENTS_COUNT; figure++)
            {
                int current_element = figure;
                int Z_COOORDINATE = (int)(figure / (m * n));
                current_element %= (m * n);
                int Y_COORDINATE = (int)(current_element / m);
                current_element %= (m);
                int X_COORDINATE = current_element;

                createIndependentElements(X_COORDINATE * 2, Y_COORDINATE * 2, Z_COOORDINATE * 2, figure);
            }
        }
        private void createIndependentElements(int x, int y, int z, int belongElementNumber)
        {
            LabelPoint[,,] finite_element = new LabelPoint[3, 3, 3];
            for (int deltaZ = 0; deltaZ < 3; deltaZ++)
            {
                for (int deltaY = 0; deltaY < 3; deltaY++)
                {
                    for (int deltaX = 0; deltaX < 3; deltaX++)
                    {
                        if (matrix[x + deltaX, y + deltaY, z + deltaZ] != null)
                        {
                            finite_element[deltaX, deltaY, deltaZ] = new LabelPoint(matrix[x + deltaX, y + deltaY, z + deltaZ]);
                            finite_element[deltaX, deltaY, deltaZ].belongElementNumber = belongElementNumber;
                        }
                        else {
                            finite_element[deltaX, deltaY, deltaZ] = null;
                        }
                    }
                }
            }
            FiniteElement item = new FiniteElement(finite_element, belongElementNumber);
            finiteElement.Add(item);
        }

        private void setLocalNumeration()
        {
            Dictionary<int, _3DPoint> magicDictionary = Globals.magicDictionary;
            _3DPoint p = null;
            foreach (FiniteElement item in finiteElement)
            {
                for (int i = 1; i <= 20; i++)
                {
                    p = magicDictionary[i];
                    item.matrix[(int)p.X, (int)p.Y, (int)p.Z].local = i;
                }                
            }
        }
    }
}
