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
        private double d2_ = 700; //дистанция, на которой режим излучения меняется с "С1" на "С2"
        private double d3_ = 500;  //дистанция, на которой длительность акустического цикла уменьшается в 4 раза, м
        private double d4_ = 200;      //дистанция, на которой длительность зондирующего сигнала уменьшается в 2 раза, м
        private bool searchIsFirst_ = true;     //указатель того, что поиск первичный
        
        public Target targ = new Target();    
        public Torpedo torp = new Torpedo();
       
        public TorpedoControlAlgorithm(Torpedo torpedo, Target target)
        {
            torp = torpedo;
            targ = target;
        }


        public void Process()  //алгоритм
        {
            
            if (targ.isReceived = true)
                Convergence();
            else
            {
                if (searchIsFirst_ = true)
                    FirstSearch();
                else
                    RepeatedSearch();
            }
        }


        public void Convergence()   //режим сближения
        {
            if (targ.distance < d2_)
            {
                if (targ.distance < d3_)
                {
                    if (targ.distance < d4_)
                        torp.emitterMode = "C4";
                    else
                        torp.emitterMode = "C3";
                }
                else
                    torp.emitterMode = "C2";
            }
            else
                torp.emitterMode = "C1";
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
