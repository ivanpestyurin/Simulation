using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    class TestStand
    {
        private EngineSimulation engine;
        public TestStand(EngineSimulation engine)
        {
            this.engine = engine;
        }

        public void StartTesting()
        {
            engine.StartSimulation();
        }

    }
}
