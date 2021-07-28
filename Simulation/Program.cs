using System;

namespace Simulation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //ISimulation dvs1 = new EngineSimulationDVS(10, new double[] { 20, 75, 100, 105, 75, 0 },
                //    new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);
                //dvs1.StartSimulation();


                EngineSimulation dvs2 = new EngineSimulationDVS(10, new double[] { 20, 75, 100, 105, 75, 0 },
                    new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);

                TestStandDVS test3 = new TestStandDVS(dvs2);
                //test3.StartTesting();

                for (int i = 1; i < 10; i++)
                {
                    test3.StartTestingWithNewParameters(10, new double[] { 20, 75, 100, 105, 75, 0 },
                        new double[] { 0, 75, 150, 200, 250, 300 }, 110, 0.01, 0.0001, 0.1);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
