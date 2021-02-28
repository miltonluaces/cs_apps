#region Imports

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NumCalc;

#endregion

namespace PSO {
    
    public class Particle : IComparable {

        #region Fields

        private Object info;
      
        private double[] position;
        private double[] velocity;
        private double[] bestPosition;
        private double bestVal;
        private double val;
                
        #endregion

        #region Constructors

        public Particle(object info, int nDim) {
            this.info = info;
            this.position = new double[nDim];
            this.val = double.MinValue;
        }

        public Particle(Object info, double[] position) {
            this.info = info;
            this.position = position;
            this.velocity = new double[position.Length];
            this.bestPosition = new double[position.Length];
            for(int i=0;i<position.Length;i++) {
                bestPosition[i] = position[i];
            }
            this.bestVal = double.MinValue;
        }

        public Particle(Object info, double[] position, double[] bestPosition) {
            this.info = info;
            this.position = position;
            this.bestPosition = bestPosition;
      
            this.velocity = new double[position.Length];
            this.bestVal = double.MinValue;
        }

        #endregion

        #region Properties

        public Object Info {
            get { return info; }
        }
      
        public double[] Position {
            get { return position; }
            set { position = value; }
        }

        public double[] BestPosition {
            get { return bestPosition; }
        }

        public double BestVal {
            get { return bestVal; }
            set { bestVal = value; }
        }

        public int Dim {
            get { return position.Length; }
        }

        public double[] Velocity {
            get { return velocity; }
            set { velocity = value; }
        }

        //public bool UseRandom {
        //    get { return useRandom; }
        //    set { useRandom = value; }
        //}

        public double Val {
            get { return val; }
            set { val = value; }
        }

        //public double[] Mins {
        //    get { return mins; }
        //}

        //public double[] Maxs {
        //    get { return maxs; }
        //}
        
        //public double Inertia {
        //    get { return inertia; }
        //    set { inertia = value; }
        //}

        #endregion

        #region Public Methods

        public Particle Clone() {
            Particle clone = new Particle(info, position, bestPosition);
            clone.Velocity = this.velocity;
            clone.BestVal = bestVal;
            clone.Val = val;
            return clone;
        }
        
        #endregion

        #region Override Equals

        public override bool Equals(Object obj) {
            Particle part = (Particle)obj;
            for(int i=0;i<Dim;i++) {
                if(position[i] != part.Position[i] || velocity[i] != part.velocity[i]) { return false; }
            }
            return true;
        }
        
        #endregion

        #region Override ToString

        public override String ToString() {
            if(position == null) { return ""; }
            String str = info.ToString() + " : Pos[";
            
            for(int i=0;i<position.Length;i++) { str += position[i].ToString("0.000000") + ((i<position.Length-1)? " ": ""); }
            str += "]";
            if(velocity != null) {
                str +=" Vel[";
                for(int i=0;i<Dim;i++) { str += velocity[i].ToString("0.00") + ((i<velocity.Length-1)? " ": ""); }
                str += "]";
            }
            if(val == double.MinValue) {
                str += "Val=minValue";
            } 
            else {
                str += " Val=" + val.ToString("0.00");
            }
            if(bestPosition != null) {
                str += " bPos[";
                for(int i=0;i<Dim;i++) { str += bestPosition[i].ToString("0.00") + ((i<bestPosition.Length-1)? " ; ": ""); }
                str += "]";
                if(bestVal == double.MinValue) {
                    str += "bVal=minValue";
                } 
                else {
                    str += " bVal=" + bestVal.ToString("0.00");
                }
            }
            return str;
        }

        #endregion
        
        #region IComparable Members

        public int CompareTo(object part) {
            return (int)Math.Round(this.Val - ((Particle)part).Val);
        }

        #endregion

    }
}
