﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Library.Geometry;
using TorpedoModel.Interfaces;

namespace TorpedoModel.Classes
{
    public class Torpedo // : IObjectControl
    {
       TorpedoControlAlgorithm alg;
       IObjectControl obj;  //объект управления
       public Coordinates coord = new Coordinates();  //инициализация координат
       public float speed;
       public float depth;          //глубина 
       Angle rudder = new Angle(0,0);

       public Torpedo(Coordinates coord_, ObjectControl obj_)     //инициализация всей торпеды
       {
           obj = obj_;                               //создание нового объекта управления    
           coord = coord_;
           alg = new TorpedoControlAlgorithm(obj);  //передача объекта управления в алгоритм
       }

       public void SetTorpedoPosition(Coordinates torpedoPosition) //запись координат торпеды
       {                   
           coord = torpedoPosition;
       }

       public void SetTargetData(Target targ_)      //получить информацию о цели
       {
           alg.AddTarget(targ_);
       }

       public void Algorithm()      //старт алгоритма торпеды
       {
           alg.Process();
       }

       public float GetSpeed()
       {
           return speed;
       }

       #region IObjectControl Members

       // public void SetRudderCourse(Angle angle)
       // {
       //    rudder = angle;
    //   }

 //      public void SetSpeed(float speed_)
   //    {
   //        speed = speed_;
 //      }

  //     public void SetEmitterMode(string mode)
  //     {
           //throw new NotImplementedException();
    //   }

   //    public void SetCockedMode(bool mode)
  //     {
  //     }

       #endregion
    }
}
