using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Library.Geometry;

namespace TorpedoModel.Classes
{
    public class Target
    {
        public Course peleng;           //пеленг на цель
        public float distance;    //дистанция до цели
        public Course course;           //курс на цель
        public float speed;       //скорость цели

        public bool isReceived = true;      //наличие сигнала от цели
        public bool isTrue = true; //цель настоящая (да/нет)
        public bool isClassified = true; //цель однозначно классифицирована (да/нет)

        #region TargetConstructors

        public Target()         //конструктор для создания цели с нулевыми параметрами
        {
            distance = 0;
            speed = 0;
            Course course_ = new Course(0, 0);
            course = course_;
            Course peleng_ = new Course(0, 0);
            peleng = peleng_;
        }

        public Target(Course peleng_, float distance_, Course course_, float speed_)         //конструктор для создания цели с конкретными параметрами
        {
            distance = distance_;
            speed = speed_;
            course = course_;
            peleng = peleng_;
        }

        #endregion 


    }
}

