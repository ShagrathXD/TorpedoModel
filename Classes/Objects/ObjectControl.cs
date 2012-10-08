using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Interfaces;

namespace TorpedoModel.Classes
{
    public class ObjectControl : IObjectControl
    {
        public double speed = 0;  //скорость торпеды
        public string emitterMode = "C1";   //режим излучения
        public Angle rudderCourse; //углы поворота рулей
        public bool cockedMode = false; //установка боевого взвода
        
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

        #region IObjectControl Members

        public void SetHorizontalRotationVelocity(float newSpeed)
        {
            throw new NotImplementedException();
        }

        public void SetVerticalRotationVelocity(float newSpeed)
        {
            throw new NotImplementedException();
        }

        public void SetEnginePower(float speed)
        {
            throw new NotImplementedException();
        }

        public void SetCockedMode(bool on)
        {
            throw new NotImplementedException();
        }

        public void SetSignalLength(float length)
        {
            throw new NotImplementedException();
        }

        public void SetProbeLength(float length)
        {
            throw new NotImplementedException();
        }

        public void EmmitSignalAndStartEchoWaiting()
        {
            throw new NotImplementedException();
        }

        public void StopEchoWaiting()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
