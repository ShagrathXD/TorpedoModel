using System;
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
       public ObjectControl obj;  //объект управления
       public Coordinates coord = new Coordinates();  //инициализация координат
       public float depth;          //глубина торпеды


       public Torpedo(Coordinates coord_, ObjectControl obj_)     //инициализация всей торпеды
       {
           obj = obj_;                               //создание нового объекта управления    
           coord = coord_;
           alg = new TorpedoControlAlgorithm(obj, new Target());  //передача объекта управления и цели в алгоритм 
       }

       public void SetTorpedoPosition(Coordinates torpedoPosition) //запись координат торпеды
       {                   
           coord = torpedoPosition;
       }

       public void Algorithm(Angle targPeleng_, float targDistance_, Angle targCourse_, float targSpeed_)      //старт алгоритма торпеды
       {
           alg.SetTargetInformation(targPeleng_, targDistance_, targCourse_, targSpeed_);
           alg.Process();
           obj = alg.obj; //синхронизация
       }

       public float GetSpeed()      //возврат значения скорости торпеды
       {
           return obj.EnginePower;
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
