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
        public LabelPoint[,,] matrix;

        public int x;
        public int y;
        public int z;

        public int m;
        public int n;
        public int k;

        private double SCALE_X;
        private double SCALE_Y;
        private double SCALE_Z;

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
            Console.WriteLine(SCALE_Z);

            matrix = new LabelPoint[m * 2 + 1, n * 2 + 1, k * 2 + 1];

            createSkelteon();
            fillGaps();
            numberThem();
        }

        private void createSkelteon()
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
        private void fillGaps()
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
        private void numberThem()
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
                            matrix[deltaX, deltaY, deltaZ].number = counter;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
            for (int deltaZ = 0; deltaZ < 1; deltaZ++)
            {
                for (int deltaY = 0; deltaY < n * 2 + 1; deltaY++)
                {
                    for (int deltaX = 0; deltaX < m * 2 + 1; deltaX++)
                    {
                        if (matrix[deltaX, deltaY, deltaZ] != null)
                        {
                            Console.Write(String.Format("{0,15}", matrix[deltaX, deltaY, deltaZ]));
                        }
                        else
                        {
                            Console.Write("{0,15}", " ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
