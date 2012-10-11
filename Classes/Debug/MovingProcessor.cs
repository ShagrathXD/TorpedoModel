using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Classes;
using TorpedoModel.Interfaces;
using TorpedoModel.Library.Geometry;
 
namespace TorpedoModel
{
    public class MovingProcessor
    {
        Torpedo torp;   //торпеда   
        Target targ;    //цель

        public MovingProcessor()
        {
            CreateBasicObjects();
        }

        #region Creating_Basic_Objects

        public void CreateBasicObjects() //создание начальных объектов
        {
            AddTorpedo(new Torpedo(new Coordinates()));  //создание торпеды с нулевыми координатами и нулевыми параметрами управления
            AddTarget(new Target(new Course(), 99999, new Course(), 0)); //создание цели на дистанции 99999 с нулевыми углами курса/пеленга и нулевой скоростью 
        }

        void AddTorpedo(Torpedo newTorp)   //добавить новую торпеду
        {
            torp = newTorp;
        }

        void AddTarget(Target newTarget)    //добавить новую цель
        {
            targ = newTarget;
        }

        #endregion       

        public void MoveProcess()  //main     
        {
            torp.Algorithm(targ.peleng, targ.distance, targ.course, targ.speed);    //запуск алгоритма. Осуществляется передача данных 
            //от цели targ в алгоритм Algorithm через торпеду torp

            #region Moving
            targ.distance = targ.distance - torp.GetSpeed();     //изменение значения дистанции
            torp.coord.x = torp.coord.x + torp.GetSpeed();       //изменение координат
            #endregion 

        }
    }
}
