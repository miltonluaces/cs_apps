using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSO {

    public class Valid : IValid  {
        
        #region IValid Members

        public bool IsValid(Particle part) {
            return true;
        }

        #endregion
    }
}
