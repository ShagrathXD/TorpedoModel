using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Library.Geometry;
using TorpedoModel.Interfaces;
using TorpedoModel.Classes;

namespace TorpedoModel.Classes
{
    public class Torpedo 
    {
       TorpedoControlAlgorithm alg;
       public Coordinates coord = new Coordinates();  //инициализация координат
       public float depth;          //глубина торпеды


       public Torpedo(Coordinates coord_)     //инициализация всей торпеды
       {
           coord = coord_;
           alg = new TorpedoControlAlgorithm(new Target());  //передача объекта управления и цели в алгоритм 
       }

       public void SetTorpedoPosition(Coordinates torpedoPosition) //запись координат торпеды
       {                   
           coord = torpedoPosition;
       }

       public void Algorithm(Angle targPeleng_, float targDistance_, Angle targCourse_, float targSpeed_)      //старт алгоритма торпеды
       {
           alg.SetTargetInformation(targPeleng_, targDistance_, targCourse_, targSpeed_);
           alg.Process();
         
       }

       public float GetSpeed()      //возврат значения скорости торпеды
       {
           return alg.obj.EnginePower;
       }


    }
}
