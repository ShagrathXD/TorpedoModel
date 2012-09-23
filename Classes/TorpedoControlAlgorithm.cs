using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Classes;
using TorpedoModel.Interfaces;
//алгоритм управления торпедой; принимает обработанную информацию о сигнале, и на ее основе подает сигналы управления на руль, двигатель и излучатель 
namespace TorpedoModel
{
    public class TorpedoControlAlgorithm
    {
        IObjectControl controlledObject;
        public const int d2_ = 700; //дистанция, на которой режим излучения меняется с "С1" на "С2"
        public const int d3_ = 500;  //дистанция, на которой длительность акустического цикла уменьшается в 4 раза, м
        public const int d4_ = 200;      //дистанция, на которой длительность зондирующего сигнала уменьшается в 2 раза, м
        private bool searchIsFirst_ = true;     //указатель того, что поиск первичный
        
        public Target targ;

        public TorpedoControlAlgorithm(IObjectControl o)
        {
            controlledObject = o; 
        }

        public void Process()  //алгоритм
        {
            if (targ.isReceived == true)
                Convergence();
            else
            {
                if (searchIsFirst_ == true)
                    FirstSearch();
                else
                    RepeatedSearch();
            }
        }


        public void Convergence()   //режим сближения
        {
            switch ((int)(targ.distance))
            {
                case (d4_):
                    controlledObject.SetEmitterMode("C4");
                    break;
                case (d3_):
                    controlledObject.SetEmitterMode("C3");
                    break;
                case (d2_):
                    controlledObject.SetEmitterMode("C2");
                    break;
                default:
                    break;
            }
        }

        public void AddTarget(Target t)
        {
            targ = t;
        }

        public void FirstSearch()   //первичный поиск
        {
            searchIsFirst_ = false;
        }

        public void RepeatedSearch()  //повторный поиск
        {
        }

        public void ContactVerification()   //подтверждение контакта
        {
        }
    }
}
