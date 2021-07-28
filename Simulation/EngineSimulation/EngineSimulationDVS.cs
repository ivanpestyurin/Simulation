using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class EngineSimulationDVS : EngineSimulation
    {
        private readonly double I; // Момент инерции двигателя
        private readonly double[] M; // Крутящий момент
        private readonly double[] V; // Cкорость вращения
        private readonly double Hm; // Коэффициент зависимости скорости нагрева
                                    // от крутящего момента
        private readonly double Hv; // Коэффициент зависимости скорости нагрева
                                    // от скорости вращения коленвала
        private readonly double C; // Коэффициент зависимости скорости охлаждения
                                   // от температуры двигателя и окружающей среды

        private double m; // текущий крутящий момент
        private double v; // текущая скорость вращения коленвала
        private double a; // ускорение
        private double Vh; // скорость нагрева двигателя
        private double Vc; // скорость охлаждения двигателя

        private double Tprevious; // температура двигателя, нужно для случаев,
                                  // когда до заданной температуры нельзя дойти
        private TimeSpan lambda = new TimeSpan(0, 0, 0, 0, 1); // частота замеров
        private double t;// время в секундах, зависит от lambda

        public EngineSimulationDVS(double I, double[] M, double[] V, double Toverheating,
            double Hm, double Hv, double C)
        {
            if (I <= 0)
                throw new Exception("I должно быть больше 0!");
            this.I = I;
            this.M = M;
            this.V = V;
            this.Toverheating = Toverheating;
            this.Hm = Hm;
            this.Hv = Hv;
            this.C = C;
            totalTime = new TimeSpan(0, 0, 0, 0, 0);

            m = M[0];
            v = V[0];

            t = lambda.TotalMilliseconds / 1000;
        }

        public override void StartSimulation()
        {
            Console.Write("Темература на улице: ");
            try
            {
                Tenvironment = double.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw new FormatException("Нужно ввести число!");
            }

            Tengine = Tenvironment;
            Process();
            //ShowReport();
        }

        private void Process()
        {
            int x = 0; // index

            double A; // Ax + By + C = 0
            double C; 
            LineEquation.GetKfsByTwoDotsB(V[x], M[x], V[x + 1], M[x + 1], out A, out C);

            while (Tengine <= Toverheating)
            {
                if (x < V.Length - 1 && v >= V[x + 1])
                {
                    x++;
                    LineEquation.GetKfsByTwoDotsB(V[x], M[x], V[x + 1], M[x + 1], out A, out C);
                }

                a = m / I;

                v += a * t;
                m = A * v + C; // уравнение прямой

                Tprevious = Tengine;

                EngineHeating();
                EngineCooling();

                if (Tprevious == Tengine)
                    throw new Exception("Невозможно достичь перегрева в таких условиях!");

                totalTime = totalTime.Add(lambda);
            }
        }

        private void ShowReport()
        {
            Console.WriteLine($"{totalTime.TotalSeconds} секунд");
        }

        protected override void EngineHeating()
        {
            Vh = (m * Hm + v * v * Hv) * t;
            Tengine += Vh;
        }
        protected override void EngineCooling()
        {
            Vc = (C * (Tenvironment - Tengine)) * t;
            Tengine += Vc;
        }

    }
}
