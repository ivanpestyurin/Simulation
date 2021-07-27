using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    abstract class EngineSimulation
    {
        public abstract void StartSimulation();
        protected abstract void EngineHeating();
        protected abstract void EngineCooling();
    }
}
