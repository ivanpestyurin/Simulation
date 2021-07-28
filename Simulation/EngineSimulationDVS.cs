using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class EngineSimulationDVS : EngineSimulation
    {
        private readonly double I;
        private readonly double[] M;
        private readonly double[] V;
        private readonly double Hm;
        private readonly double Hv;
        private readonly double C;

        private double m; // текущий крутящий момент
        private double v; // текущая скорость вращения коленвала
        private double a; // ускорение
        private double Vh; // скорость нагрева двигателя
        private double Vc; // скорость охлаждения двигателя

        private double Tprevious; // температура двигателя, нужно для случаев,
                                  // когда до заданной температуры нельзя дойти

        private TimeSpan lambda = new TimeSpan(0, 0, 0, 0, 1); // раз в какое время будет
                                                                 // считать
        private double t;// время в секундах, зависит от lambda

        public EngineSimulationDVS(double I, double[] M, double[] V, double Toverheating,
            double Hm, double Hv, double C)
        {
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
                throw;
            }

            Tengine = Tenvironment;
            DoProcessing();
            ShowReport();
        }

        private void DoProcessing()
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
                    break;

                //Console.WriteLine($"v={v}\tm={m}\ta={a}\tT={Tengine}");
                totalTime = totalTime.Add(lambda);
            }
        }

        private void ShowReport()
        {
            if (Tprevious == Tengine)
            {
                throw new Exception("Слишком низкая температура на улице");
                //Console.WriteLine($"{totalTime.Minutes}:{totalTime.Seconds}" +
                //    $":{totalTime.Milliseconds}");
            }
            else
            {
                //Console.WriteLine($"Больше температура не поднимается, за {totalTime.Minutes}:{totalTime.Seconds}" +
                //    $":{totalTime.Milliseconds} она поднялась до {Tengine}°C");
            }

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
