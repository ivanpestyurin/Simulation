using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    abstract class TestStand : ITesting
    {
        protected EngineSimulation engine;
        public abstract void StartTesting();
    }

}
