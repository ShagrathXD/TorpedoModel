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
        Coordinates torpedoPosition;
        public Target targ;

        Torpedo newTorp = new Torpedo(); //инициализация торпеды
        void AddTorpedo(Torpedo newTorp_)
        {
            torp = newTorp_;
        }

        Coordinates torpCoord = new Coordinates(); //инициализация координат торпеды
        void AddPosition(Coordinates torpCoord_)
        {
            torpedoPosition = torpCoord_;
        }

        Target target = new Target();   //инициализация цели
        void AddTarget(Target target_)
        {
            targ = target_;
        }

        public void SetInitData()   //установка начальных значений
        {
            torp.speed = 10;
            targ.distance = 1000;
            targ.isReceived = true;
            torp.SetControlData(torp);
            targ.SetTargetData(targ);
        }

        public void InitMovingProcessor() //инициализация всего процессора
        {   
            AddTorpedo(newTorp);
            AddPosition(torpCoord);
            AddTarget(target);
            SetInitData();
        }

        public void MoveProcess()  //main     
        {
            torp.GetSpeed(out torp.speed);  //получение значения скорости
            if (targ.distance != 0)
            {
                targ.distance = targ.distance - torp.speed;     //изменение значения дистанции
                torpedoPosition.x = torpedoPosition.x + torp.speed;       //изменение координат
            }
            else
            {
                Console.WriteLine("press key to finish");
                Console.ReadKey();
            }                       
        }
}}
