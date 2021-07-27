using System;

namespace Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            EngineSimulation dvs = new EngineSimulationDVS(10, new float[] { 20, 75, 100, 105, 75, 0 },
                new float[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01f, 0.0001f, 0.1f);

            dvs.StartSimulation();
        }
    }
}
