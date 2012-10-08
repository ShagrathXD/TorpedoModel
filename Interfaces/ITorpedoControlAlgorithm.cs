using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Library;
using TorpedoModel.Classes;

namespace TorpedoModel.Interfaces
{
    public interface ITorpedoControlAlgorithm      //интерфейс, по которому в алгоритм пересылаются данные
    {
        void SetTargetInformation(Angle peleng, float distnce, Angle targetCourse, float targetSpeed);
        void Process(); //Запустить работу алгоритма
        void SetTargetSignalReceived(bool isReceived);//сигнализация о том, получен сигнал от цели или нет
        void SetSignalAmplitude(float signalAmp); //уровень амплитуды сигнала
    }
}
