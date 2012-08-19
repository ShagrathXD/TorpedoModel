using System;
using System.Collections.Generic;
using System.Text;

namespace TorpedoModel.Library.Geometry
{
    public class Coordinates
    {
        public double x;
        public double y;
        public double z;

        public Coordinates()
        {
            x = 0;
            y = 0;
            z = 0;
        }

        public Coordinates(double x_, double y_, double z_)
        {
            x = x_;
            y = y_;
            z = z_;
        }


    }
}
