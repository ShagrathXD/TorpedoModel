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
        public Torpedo torp;
        public Target targ;

        void AddTorpedo(Torpedo newTorp_)
        {
            torp = newTorp_;
        }

        void AddTarget(Target target_)
        {
            targ = target_;
            torp.SetTargetData(target_);
        }

        public void SetInitData()   //установка начальных значений
        {
            torp.speed = 10;
            targ.distance = 1000;
            targ.isReceived = true;
        }

        public void InitMovingProcessor() //инициализация всего процессора
        {   
            AddTorpedo( new Torpedo(new Coordinates()));
            AddTarget( new Target() );
            SetInitData();
        }

        public void MoveProcess()  //main     
        {
            var torp_speed = torp.GetSpeed();  //получение значения скорости
            if (targ.distance != 0)
            {
                targ.distance = targ.distance - torp_speed;     //изменение значения дистанции
                torp.coord.x = torp.coord.x + torp_speed;       //изменение координат
            }
            else
            {
                Console.WriteLine("press key to finish");
                Console.ReadKey();
            }
            torp.Algorithm();           
        }
}}
