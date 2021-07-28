using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation
{
    /// <summary>
    /// Abstract class for all types of engines
    /// </summary>
    abstract class EngineSimulation : ISimulation
    {
        public double Toverheating { get; protected set; }
        public TimeSpan totalTime { get; protected set; } // счетчик времени
        public double Tengine { get; protected set; } // температура двигателя
        public double Tprevious { get; protected set; } // температура двигателя, нужно для случаев,
                                  // когда до заданной температуры нельзя дойти

        protected double Tenvironment; // температура окружающей среды
        public abstract void StartSimulation();
        protected abstract void EngineHeating();
        protected abstract void EngineCooling();
    }
}
