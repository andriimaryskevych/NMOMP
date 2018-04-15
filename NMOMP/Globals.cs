using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMOMP
{
    class Globals
    {
        // sooo... here I define magic Disctinary that will evaluate some integer in range from
        // 1 to 20 including both to some point
        // Example: magicDictionary[1] -> (0,0,0)
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
    }
}
