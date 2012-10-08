using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Library.Geometry;

namespace TorpedoModel.Classes
{
    public class Target
    {
        public Angle peleng;           //пеленг на цель
        public float distance;    //дистанция до цели
        public Angle course;           //курс на цель
        public float speed;       //скорость цели

        public bool isReceived = false;      //наличие сигнала от цели
        public bool isTrue = true; //цель настоящая (да/нет)
        public bool isClassified = true; //цель однозначно классифицирована (да/нет)

        #region TargetConstructors

        public Target()         //конструктор для создания цели с нулевыми параметрами
        {
            distance = 0;
            speed = 0;
            Angle course_ = new Angle(0, 0);
            course = course_;
            Angle peleng_ = new Angle(0, 0);
            peleng = peleng_;
        }

        public Target(Angle peleng_, float distance_, Angle course_, float speed_)         //конструктор для создания цели с конкретными параметрами
        {
            distance = distance_;
            speed = speed_;
            course = course_;
            peleng = peleng_;
        }

        #endregion 


    }
}

