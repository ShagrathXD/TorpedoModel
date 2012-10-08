using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorpedoModel.Interfaces
{
    public interface IObjectControl     //интерфейс, по которому алгоритм управляет торпедой
    {
        void SetRudderCourse(Classes.Angle angle); 
        void SetSpeed(float speed);
        void SetEmitterMode(string mode); //Функция задающая тип сигнала излучателя, строка - имя режима. 
        void SetCockedMode(bool mode);  //установка боевого взвода
    }
}
