using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Interfaces;

namespace TorpedoModel.Classes
{
    public class ObjectControl : IObjectControl
    {
        float horizontalRotationVelocity_;
        float verticalRotationVelocity_;
        public float enginePower;  //скорость торпеды

        float signalLength_; //длительность зондирующего импульса
        float probeLength_;  //длительность приода зондирования(время ожидания эхо-сигнала)


        bool cockedMode_ = false; //установка боевого взвода


        public ObjectControl()  //конструктор для объекта управления
        {
            enginePower = 0;
        }

        public float GetSpeed()      //возврат значения скорости торпеды
        {
            return enginePower;
        }

        #region IObjectControl Members

        public void SetHorizontalRotationVelocity(float newSpeed)
        {
            horizontalRotationVelocity_ = newSpeed;
        }

        public void SetVerticalRotationVelocity(float newSpeed)
        {
            verticalRotationVelocity_ = newSpeed;
        }

        public void SetEnginePower(float speed)
        {
            enginePower = speed;
        }

        public void SetCockedMode(bool on)
        {
            cockedMode_ = on;
        }

        public void SetSignalLength(float length)
        {
            signalLength_ = length;
        }

        public void SetProbeLength(float length)
        {
            probeLength_ = length;
        }

        public void EmmitSignalAndStartEchoWaiting()
        {            
        }

        public void StopEchoWaiting()
        {
        }

        #endregion
    }
}
