using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorpedoModel.Interfaces
{
    public interface IObjectControl     //интерфейс, по которому алгоритм управляет торпедой
    {
        void SetHorizontalRotationVelocity(float newSpeed); //скорость горизонтальной циркуляции
        void SetVerticalRotationVelocity(float newSpeed);   //скорость вертикальной циркуляции
        void SetEnginePower(float speed); //установка скорости
        void SetCockedMode(bool on); //установка боевого взвода
        void SetSignalLength(float length); //установка длительности излучения
        void SetProbeLength(float length);  //установка периода зондирования (времени ожидания сигнала)
        void EmmitSignalAndStartEchoWaiting(); //команда на излучение и ожидание сигнала
        void StopEchoWaiting();     //команда на прекращение ожидания сигнала
    }
}
