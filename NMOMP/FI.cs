using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class FI
    {
        // sooo... here I define magic Disctinary that will evaluate some integer in range from
        // 1 to 20 including both to some point
        // Example: magicDictionary[1] -> (0,0,0)
        // Than I take this point and paste it to ALPHA_BETA_GAMMA_VALUE
        // ALPHA_BETA_GAMMA_VALUE[0][0][0] will evaluate to -1, 1, -1
        // these are needed coordinates for PHIi function where alpaha_i is -1 and so on))
        public static Dictionary<int, _3DPoint> magicDictionary = new Dictionary<int, _3DPoint> {
            {1, new _3DPoint(0,0,0) },
            {2, new _3DPoint(2,0,0) },
            {3, new _3DPoint(2,2,0) },
            {4, new _3DPoint(0,2,0) },

            {5, new _3DPoint(0,0,2) },
            {6, new _3DPoint(2,0,2) },
            {7, new _3DPoint(2,2,2) },
            {8, new _3DPoint(0,2,2) },

            {9,  new _3DPoint(1,0,0) },
            {10, new _3DPoint(2,1,0) },
            {11, new _3DPoint(1,2,0) },
            {12, new _3DPoint(0,1,0) },

            {13, new _3DPoint(0,0,1) },
            {14, new _3DPoint(2,0,1) },
            {15, new _3DPoint(2,2,1) },
            {16, new _3DPoint(0,2,1) },

            {17, new _3DPoint(1,0,2) },
            {18, new _3DPoint(2,1,2) },
            {19, new _3DPoint(1,2,2) },
            {20, new _3DPoint(0,1,2) },
        };
        public static _3DPoint[,,] ALPHA_BETA_GAMMA_VALUE = new SquareGenerator(-1, 0, 1).getMatrix();

        public static double ONE_EIGHT = (double)1 / 8;
        public static double ONE_FOURTH = (double)1 / 4;
        
        private static double firstFi(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_EIGHT * 
                (1 + alpha * coord.X) * 
                (1 + beta * coord.Y) * 
                (1 + gamma * coord.Z) * 
                (alpha * coord.X + beta * coord.Y + gamma * coord.Z - 2);

            return result;
        }
        private static double secondFi(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_FOURTH *
                (1 + alpha * coord.X) *
                (1 + beta * coord.Y) *
                (1 + gamma * coord.Z) *
                ( 1 - Math.Pow( ( alpha * coord.Y * coord.Z) , 2) - Math.Pow((beta * coord.X * coord.Z), 2) - Math.Pow((gamma * coord.X * coord.Y), 2) );

            return result;
        }
        // calculates PHIi(A,B,G)
        public static double getFi(int i, double alpha, double beta, double gamma)
        {
            return i < 9 ? firstFi(i, alpha, beta, gamma) : secondFi(i, alpha, beta, gamma);
        }

        // functions that calculated deriviates 
        public static double diAlphaFirst(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_EIGHT * 
                coord.X * 
                (1 + beta * coord.Y) * 
                (1 + gamma * coord.Z) * 
                (2 * alpha * coord.X + beta * coord.Y + gamma * coord.Z - 1);

            return result;
        }
        public static double diBetaFirst(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_EIGHT *
                (1 + alpha * coord.X) *
                coord.Y *
                (1 + gamma * coord.Z) *
                (alpha * coord.X + 2 * beta * coord.Y + gamma * coord.Z - 1);

            return result;
        }
        public static double diGammaFirst(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_EIGHT *
                (1 + alpha * coord.X) *
                (1 + beta * coord.Y) *
                coord.Z *
                (alpha * coord.X + beta * coord.Y + 2 * gamma * coord.Z - 1);

            return result;
        }
        public static double diAlphaSecond(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_FOURTH *
                (1 + beta * coord.Y) *
                (1 + gamma * coord.Z) *
                ( coord.X * (1 - Math.Pow((alpha * coord.Y * coord.Z), 2) - Math.Pow((beta * coord.X * coord.Z), 2) - Math.Pow((gamma * coord.X * coord.Y), 2)) -
                  2 * alpha * Math.Pow((coord.Y * coord.Z), 2) * (1 + alpha * coord.X) );

            return result;
        }
        public static double diBetaSecond(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_FOURTH *
                (1 + alpha * coord.X) *
                (1 + gamma * coord.Z) *
                (coord.Y * (1 - Math.Pow((alpha * coord.Y * coord.Z), 2) - Math.Pow((beta * coord.X * coord.Z), 2) - Math.Pow((gamma * coord.X * coord.Y), 2)) -
                  2 * beta * Math.Pow((coord.X * coord.Z), 2) * (1 + beta * coord.Y));

            return result;
        }
        public static double diGammaSecond(int i, double alpha, double beta, double gamma)
        {
            double result;
            _3DPoint point = magicDictionary[i];
            _3DPoint coord = ALPHA_BETA_GAMMA_VALUE[(int)point.X, (int)point.Y, (int)point.Z];
            result = ONE_FOURTH *
                (1 + alpha * coord.X) *
                (1 + beta * coord.Y) *
                (coord.Z * (1 - Math.Pow((alpha * coord.Y * coord.Z), 2) - Math.Pow((beta * coord.X * coord.Z), 2) - Math.Pow((gamma * coord.X * coord.Y), 2)) -
                  2 * gamma * Math.Pow((coord.X * coord.Y), 2) * (1 + gamma * coord.Z));

            return result;
        }

        // functinons delegate calculation to more specified functions depending on their index 
        private static double diAlpha(int i, double alpha, double beta, double gamma)
        {
            return i < 9 ? diAlphaFirst(i, alpha, beta, gamma) : diAlphaSecond(i, alpha, beta, gamma);
        }
        private static double diBeta(int i, double alpha, double beta, double gamma)
        {
            return i < 9 ? diBetaFirst(i, alpha, beta, gamma) : diBetaSecond(i, alpha, beta, gamma);
        }
        private static double diGamma(int i, double alpha, double beta, double gamma)
        {
            return i < 9 ? diGammaFirst(i, alpha, beta, gamma) : diGammaSecond(i, alpha, beta, gamma);
        }

        // calculates ( Di PHIi(A,B,G) ) / ( Di variable )
        // variable 1 is Aplha and so on
        // it delegates execution depending on alpha beta gamma
        public static double getDiFi(int variable, int i, double alpha, double beta, double gamma)
        {
            double result = 0;

            switch (variable)
            {
                case 1: result = diAlpha(i, alpha, beta, gamma); break;
                case 2: result = diBeta(i, alpha, beta, gamma); break;
                case 3: result = diGamma(i, alpha, beta, gamma); break;
            }

            return result;
        }
    }
}
