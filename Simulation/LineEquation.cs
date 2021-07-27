using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public static class LineEquation
    {
        public static void GetKfsByTwoDotsA(float x1, float y1, float x2, float y2, out float B, out float C)
        {
            B = -(x2 - x1) / (y1 - y2);
            C = -(x1 * y2 - x2 * y1) / (y1 - y2);
        }
        public static void GetKfsByTwoDotsB(float x1, float y1, float x2, float y2, out float A, out float C)
        {
            A = -(y1 - y2) / (x2 - x1);
            C = -(x1 * y2 - x2 * y1) / (x2 - x1);
        }
    }
}
