using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class TestStandDVS : TestStand
    {
        public TestStandDVS(EngineSimulation engine)
        {
            this.engine = engine;
        }

        public void StartTestingWithNewParameters(double I, double[] M, double[] V, double Toverheating,
            double Hm, double Hv, double C)
        {
            engine = new EngineSimulationDVS(I, M, V, Toverheating, Hm, Hv, C);
            StartTesting();
        }

        public override void StartTesting()
        {
            engine.StartSimulation();
            while (true)
            {
                if (engine.Tengine >= engine.Toverheating)
                {
                    break;
                }
                else if (engine.Tengine == engine.Tprevious)
                {
                    break;
                }

            }
        }
    }
}
