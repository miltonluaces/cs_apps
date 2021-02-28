using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO {
    public interface IOptimizer {

        void CreateSwarm();
        Swarm GetSwarm();
        void Init();
        void Update();
    }
}
