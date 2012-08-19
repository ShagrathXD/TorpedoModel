using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorpedoModel.Interfaces
{
    interface ITorpedoControlAlgorithm
    {
        void SetTargetSignalReceived(bool isReceived);//сигнализация о том, получен сигнал от цели или нет
        void SetTargetCourse(Classes.Angle angle);//Направление на цель
        void SetTargetDistance(float distance);//Дистанция до цели
        //Возможно что-то еще понадобится
        //void Process(); //Запустить работу алгоритма
        //void SetControlObject(IObjectControl object); //Передаем в алгоритм ссылку на управляемый объект
    }
}
