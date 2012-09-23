using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorpedoModel.Interfaces
{
    public interface IObjectControl
    {
        void SetRudderCourse(Classes.Angle angle); 
        void SetSpeed(float speed);
        void SetEmitterMode(string mode); //Функция задающая тип сигнала излучателя, строка - имя режима. 
    }
}
