using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Interfaces;

namespace TorpedoModel.Classes
{
    public class ObjectControl : IObjectControl
    {
        float HorizontalRotationVelocity;
        float VerticalRotationVelocity;
        public float EnginePower;  //скорость торпеды

        float SignalLength; //длительность зондирующего импульса
        float ProbeLength;  //длительность приода зондирования(время ожидания эхо-сигнала)


        bool cockedMode = false; //установка боевого взвода


        public ObjectControl()  //конструктор для объекта управления
        {
            EnginePower = 0;
        }

        public float GetSpeed()      //возврат значения скорости торпеды
        {
            return EnginePower;
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
            EnginePower = speed;
        }

        public void SetCockedMode(bool on)
        {
            cockedMode = on;
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
