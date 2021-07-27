using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class EngineSimulationDVS : EngineSimulation
    {
        private readonly float I;
        private readonly float[] M;
        private readonly float[] V;
        private readonly float Toverheating;
        private readonly float Hm;
        private readonly float Hv;
        private readonly float C;

        private float m; // текущий крутящий момент
        private float v; // текущая скорость вращения коленвала
        private float a; // ускорение
        private float Vh; // скорость нагрева двигателя
        private float Vc; // скорость охлаждения двигателя
        private float Tengine; // температура двигателя
        private float Tenvironment; // температура окружающей среды

        private TimeSpan totalTime = new TimeSpan(0, 0, 0, 0, 0); // счетчик времени
        private TimeSpan lambda = new TimeSpan(0, 0, 0, 0, 100); // раз в какое время будет
                                                                 // считать
        private float t;// время в секундах, зависит от lambda

        public EngineSimulationDVS(float I, float[] M, float[] V, float Toverheating,
            float Hm, float Hv, float C)
        {
            this.I = I;
            this.M = M;
            this.V = V;
            this.Toverheating = Toverheating;
            this.Hm = Hm;
            this.Hv = Hv;
            this.C = C;

            Tengine = Tenvironment;
            m = M[0];
            v = V[0];

            t = (float)lambda.TotalMilliseconds / 1000;
        }

        public override void StartSimulation()
        {
            Console.Write("Темература на улице: ");
            try
            {
                Tenvironment = float.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                throw;
            }
            
            DoProcessing();
            Console.WriteLine($"{totalTime.Minutes}:{totalTime.Seconds}" +
                $":{totalTime.Milliseconds}");
        }

        private void DoProcessing()
        {
            int x = 0; // index

            float A; // Ax + By + C = 0
            float C; 
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

                EngineHeating();
                EngineCooling();

                Console.WriteLine($"v={v}\tm={m}\ta={a}\tT={Tengine}");
                totalTime = totalTime.Add(lambda); ;
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
