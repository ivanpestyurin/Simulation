using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// For the equation of a straight line
    /// </summary>
    public static class LineEquation
    {
        /// <summary>
        /// Ax + By + C = 0
        /// x = -By/A - C/A
        /// getting -B and -C coefficients
        /// </summary>
        public static void GetKfsByTwoDotsA(double x1, double y1, double x2, double y2, 
            out double B, out double C)
        {
            B = - (x2 - x1) / (y1 - y2);
            C = - (x1 * y2 - x2 * y1) / (y1 - y2);
        }
        /// <summary>
        /// Ax + By + C = 0
        /// y = -Ay/B - C/B
        /// getting -A and -C coefficients
        /// </summary>
        public static void GetKfsByTwoDotsB(double x1, double y1, double x2, double y2, 
            out double A, out double C)
        {
            A = - (y1 - y2) / (x2 - x1);
            C = - (x1 * y2 - x2 * y1) / (x2 - x1);
        }
    }
}
