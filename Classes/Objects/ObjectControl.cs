using System;
using System.Collections.Generic;
using System.Text;

namespace TorpedoModel.Classes.Objects
{
    public class ObjectControl
    {
        public double speed = 0;  //скорость торпеды
        public string emitterMode = "C1";   //режим излучения
        public Angle rudderCourse; //углы поворота рулей
        
        public Angle rudder = new Angle(0, 0); //инициализация руля
        public void InitRudder(Angle rudder_)
        {
            rudderCourse = rudder_;
        }

        public void SetControlData(ObjectControl controlData)  //установка параметров управления
        {
            speed = controlData.speed;
            emitterMode = controlData.emitterMode;
            rudderCourse = controlData.rudderCourse;
        }

        public double GetSpeed()   //получить значение скорости
        {
            return speed;
        }
    }
}
