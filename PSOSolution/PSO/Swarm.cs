#region Imports

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

#endregion

namespace PSO {

    public class Swarm  {

        #region Fields

        private List<Particle> particles;
        private Particle best;
     
        #endregion

        #region Constructor

        public Swarm(int nDims) {
            particles = new List<Particle>();
            best = new Particle("best", nDims);
        }
        
        #endregion

        #region Properties

        public List<Particle> Particles {
            get { return particles; }
            set { particles = value; }
        }

        public Particle Best {
            get { return best; }
        }

        #endregion

        #region Setters and Getters 

        public void Add(Particle part) {
            particles.Add(part);
        }

        public void SaveBest(Particle newBest) {
            for(int i=0;i<newBest.Position.Length;i++) {
                best.Position[i] = newBest.Position[i];
            }
            best.Val = newBest.Val;
        }
        
        #endregion

        #region Interface Implementations

        public void Sort() {
            particles.Sort();
        }

        public Particle GetBest() {
            return best;
        }

        #endregion

        #region Override ToString

        public override string ToString() {
            string str = "Particles: \n";
            foreach(Particle part in particles) {
                str += part.ToString() + "\n";
            }
            if(GetBest() != null) {
                str += "Best : \n" + GetBest().ToString();
            }
            str += "\n";
            return str;
        }

        #endregion

    }
}
