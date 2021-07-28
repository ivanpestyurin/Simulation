using System;

namespace Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //EngineSimulationDVS dvs3 = new EngineSimulationDVS(10, new double[] { 20, 75, 100, 105, 75, 0 }, new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);
            //TestStand test2 = new TestStandDVS(dvs2);


            ISimulation dvs1 = new EngineSimulationDVS(10, new double[] { 20, 75, 100, 105, 75, 0 }, 
                new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);
            dvs1.StartSimulation();


            EngineSimulation dvs2 = new EngineSimulationDVS(10, new double[] { 20, 75, 100, 105, 75, 0 }, 
                new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);
            ITesting test1 = new TestStandDVS(dvs2);
            test1.StartTesting();


            TestStandDVS test3 = new TestStandDVS(dvs2);
            for (int i = 1; i < 10; i++)
            {
                test3.StartTestingWithNewParameters(10, new double[] { 20, 75, 100, 105, 75, 0 },
                    new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);
            }
        }
    }
}
