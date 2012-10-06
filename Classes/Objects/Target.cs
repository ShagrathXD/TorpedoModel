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
        public bool isClassified = true; //цель однозначно классифицирована (да/нет)
        public bool isTrue = true; //цель настоящая (да/нет)
    }
}
