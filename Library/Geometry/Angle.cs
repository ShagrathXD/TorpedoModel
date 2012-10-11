using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorpedoModel.Classes
{
    public class Course                        
    {
        public double Phi { get; set; }
        public double Tetha { get; set; }

        public Course()
        {
            Phi = 0;
            Tetha = Math.Sin(Math.PI / 2);
        }

        public Course(double phi, double tetha)
        {
            Phi = phi;
            Tetha = tetha;
        }

        public Course FromDegreeToRad()
        {
            return new Course(Math.PI / 180 * Phi, Math.PI / 180 * Tetha);
        }
    }
}
