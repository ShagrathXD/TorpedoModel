using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Library.Geometry;
using TorpedoModel.Interfaces;

namespace TorpedoModel.Classes
{
    public class Torpedo : IObjectControl
    {
       TorpedoControlAlgorithm alg;
       public Coordinates coord = new Coordinates();  //инициализация координат
       public float speed;
       public float depth;          //глубина 
       Angle rudder = new Angle(0,0);

       public Torpedo(Coordinates coord_)     //инициализация всей торпеды
       {
           coord = coord_;
           alg = new TorpedoControlAlgorithm(this);
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

       public void SetRudderCourse(Angle angle)
       {
           rudder = angle;
       }

       public void SetSpeed(float speed_)
       {
           speed = speed_;
       }

       public void SetEmitterMode(string mode)
       {
           //throw new NotImplementedException();
       }

       #endregion
    }
}
