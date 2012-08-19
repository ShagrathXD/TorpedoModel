using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Library.Geometry;

namespace TorpedoModel.Classes
{
    public class Target
    {
        public double distance = 99999;    //дистанция до цели
        public bool isReceived = false;      //наличие цели
        public Angle targetCourse = new Angle(0, 0);    //курс на цель

        public void SetTargetData(Target inData)
        {
            isReceived = inData.isReceived;
            distance = inData.distance;
            targetCourse = inData.targetCourse;
        }

        public void GetTargetData(out bool isReceived_, out double targetDistance_, out Angle tCourse_)
        {
            isReceived_ = isReceived;
            targetDistance_ = distance;
            tCourse_ = targetCourse;
        }
    }
}
