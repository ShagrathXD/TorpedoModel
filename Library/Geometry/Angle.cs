using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorpedoModel.Classes
{
    public class Angle                        
    {
        public double Phi { get; set; }
        public double Tetha { get; set; }

        public Angle()
        {
            Phi = 0;
            Tetha = Math.Sin(Math.PI / 2);
        }

        public Angle(double phi, double tetha)
        {
            Phi = phi;
            Tetha = tetha;
        }

        public Angle FromDegreeToRad()
        {
            return new Angle(Math.PI / 180 * Phi, Math.PI / 180 * Tetha);
        }
    }
}
