﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Library.Geometry;

namespace TorpedoModel.Classes
{
   public  class Torpedo
    {        
           public double speed = 0;  //скорость торпеды
           public string emitterMode = "C1";   //режим излучения
           public Angle rudderCourse; //углы поворота рулей
           public Coordinates torpPosition; //координаты торпеды

           public Coordinates coord = new Coordinates();  //инициализация координат
           public void InitCoord(Coordinates coord_)
           {
               torpPosition = coord_;
           }

           public Angle rudder = new Angle(0, 0); //инициализация руля
           public void InitRudder(Angle rudder_)
           {
               rudderCourse = rudder_;
           }

           public void InitTorpedo()    //инициализация всей торпеды
           {
               InitCoord(coord);
               InitRudder(rudder);
           }

           public void SetTorpedoPosition(Coordinates torpedoPosition) //запись координат торпеды
           {                   
               torpPosition = torpedoPosition;
           }

           public void SetControlData(Torpedo controlData)  //установка параметров управления
           {
               speed = controlData.speed;
               emitterMode = controlData.emitterMode;
               rudderCourse = controlData.rudderCourse;
           }
          
           public void GetSpeed(out double speed_)   //получить значение скорости
           {
               speed_ = speed;
           }      
     }
}