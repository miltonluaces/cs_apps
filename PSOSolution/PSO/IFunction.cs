#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#endregion

namespace PSO {

    public interface IFunction {
        double GetValue(Particle particle);
    }
}
