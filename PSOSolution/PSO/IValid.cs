using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO {
    
    public interface IValid {
        bool IsValid(Particle part);
    }
}
