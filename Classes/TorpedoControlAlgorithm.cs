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
        public const int d2_ = 700; //дистанция, на которой режим излучения меняется с "С1" на "С2"
        public const int d3_ = 500;  //дистанция, на которой длительность акустического цикла уменьшается в 4 раза, м
        public const int d4_ = 200;      //дистанция, на которой длительность зондирующего сигнала уменьшается в 2 раза, м
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
            switch ((int)(targ.distance))
            {
                case d4_:
                    torp.emitterMode = "C4";
                    break;
                case (d3_):
                    torp.emitterMode = "C3";
                    break;
                case (d2_):
                    torp.emitterMode = "C2";
                    break;
                default:
                    break;
            }

            
  ///          if (targ.distance < d2_)
  ///          {
  ///              if (targ.distance < d3_)
  ///              {
  ///                  if (targ.distance < d4_)
  ///                      torp.emitterMode = "C4";
  ///                  else
  ///                      torp.emitterMode = "C3";
  ///              }
  ///              else
  ///                  torp.emitterMode = "C2";
  ///          }
            ///          else
            ///              torp.emitterMode = "C1";
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
