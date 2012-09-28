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
        public int mode_ = 0;   //флаг режима
        public int k_ = 0;       //служебная переменная 
        
        public Target targ;

        public TorpedoControlAlgorithm(IObjectControl o)
        {
            controlledObject = o; 
        }

        public void Process()  //алгоритм
        {
            switch (mode_)  //переключение между режимами 
            {
                case 0:
                    FirstSearch();
                    break;
                case 1:
                    ContactVerification();
                    break;
            }       
        }



        public void AddTarget(Target t)
        {
            targ = t;
        }




        public void FirstSearch()   //первичный поиск (0)
        {
            if (targ.isReceived = true) //если принят сигнал, то
                mode_ = 1;              //переход к ПК
        }

        public void ContactVerification()   //подтверждение контакта, ПК  (1)
        {
            switch (targ.isReceived)     
            {
                case true:             //если сигнал получен
                    switch (k_)     
                    {
                        case 2:         // 2 раза поддряд, то
                            mode_ = 2;  //переход в режим СН1
                            k_ = 0;     //сброс счетчика
                            break;
                        default:        //если нет, то 
                            k_++;       //счетчик + 1  
                            break;
                    }
                    break;
                    
                case false:         //если сигнал не получен, то
                    mode_ = 0;      //возврат к первичному поиску
                    k_ = 0;         //и сброс счетчика
                    break;
            }
        }

        public void Convergence1()      //самонаведение СН1     (2)
        {
        }

        public void Convergence2()      //самонаведение СН2
        {
        }

        public void Convergence3()      //самонаведение СН3
        {
        }

        public void Convergence4()      //самонаведение СН4
        {
        }

        public void PrecursiveSearch1()     //предварительный поиск ПРП1
        {
        }

        public void PrecursiveSearch2()     //предварительный поиск ПРП2
        {
        }

        public void PrecursiveSearch3()     //предварительный поиск ПРП3
        {
        }

        public void PrecursiveSearch4()     //предварительный поиск ПРП4
        {
        }

        public void RepeatedSearch1()  //повторный поиск ПП1 (ближний)
        {
        }

        public void RepeatedSearch2()  //повторный поиск ПП2 
        {
        }

        public void AnotherSearch()     //поиск другого объекта ПДО
        {
        }

        public void Guidance()      //наведение НВ
        {
        }


    }
}
