using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    public static class LineEquation
    {
        public static void GetKfsByTwoDotsA(double x1, double y1, double x2, double y2, out double B, out double C)
        {
            B = -(x2 - x1) / (y1 - y2);
            C = -(x1 * y2 - x2 * y1) / (y1 - y2);
        }
        public static void GetKfsByTwoDotsB(double x1, double y1, double x2, double y2, out double A, out double C)
        {
            A = -(y1 - y2) / (x2 - x1);
            C = -(x1 * y2 - x2 * y1) / (x2 - x1);
        }
    }
}
