using System;

namespace Simulation
{
    class Program
    {
        static void Main(string[] args)
        {

            EngineSimulation dvs = new EngineSimulationDVS(10, new double[] { 20, 75, 100, 105, 75, 0 },
                new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);

            ITesting test = new TestStand(dvs);
            test.StartTesting();

            //ISimulation d = new EngineSimulationDVS(10, new double[] { 20, 75, 100, 105, 75, 0 },
            //    new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);

        }
    }
}
