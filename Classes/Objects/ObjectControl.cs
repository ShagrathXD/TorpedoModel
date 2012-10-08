using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Interfaces;

namespace TorpedoModel.Classes
{
    public class ObjectControl : IObjectControl
    {
        float speed;  //скорость торпеды
        bool cockedMode = false; //установка боевого взвода


        public ObjectControl()  //конструктор для объекта управления
        {
            speed = 0;
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
