using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// Abstract class for all types of tests
    /// </summary>
    abstract class TestStand : ITesting
    {
        protected EngineSimulation engine;
        public abstract void StartTesting();
    }

}
