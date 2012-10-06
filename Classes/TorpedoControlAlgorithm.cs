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
        enum Modes { FS, CV, Con1, Con2, Con3, Con4, PS1, PS2, PS3, PS4, RS1, RS2, AS, G }; //перечисление всех режимов
        
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
                case 2:
                    Convergence1();
                    break;
                case 3:
                    Convergence2();
                    break;
                case 4:
                    Convergence3();
                    break;
                case 5:
                    Convergence4();
                    break;
                case 6:
                    PrecursiveSearch1();
                    break;
                case 7:
                    PrecursiveSearch2();
                    break;
                case 8:
                    PrecursiveSearch3();
                    break;
                case 9:
                    PrecursiveSearch4();
                    break;
                case 10:
                    RepeatedSearch1();
                    break;
                case 11:
                    RepeatedSearch2();
                    break;
                case 12:
                    AnotherSearch();
                    break;
                case 13:
                    Guidance();
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
                mode_ =(int)Modes.CV ;              //переход к ПК
        }

        public void ContactVerification()   //подтверждение контакта, ПК  (1)
        {
            // if (превышение порога)
            //     mode_ = 6; //переход в режим наведения
            // else
            // {
            switch (targ.isReceived)     
            {
                case true:             //если сигнал получен
                    switch (k_)     
                    {
                        case 2:         // 2 раза поддряд, то
                            mode_ = (int)Modes.Con1;  //переход в режим СН1
                            k_ = 0;     //сброс счетчика
                            break;
                        default:        //если нет, то 
                            k_++;       //счетчик + 1  
                            break;
                    }
                    break;
                    
                case false:         //если сигнал не получен, то
                    mode_ = (int)Modes.CV;      //возврат к первичному поиску
                    k_ = 0;         //и сброс счетчика
                    break;
            }
            // }
        }

        public void Convergence1()      //самонаведение СН1     (2)
        {
            switch (targ.isReceived)
            {                               
                case true:  
                    if (targ.distance > d2_)    //если дистанция до цели
                    {                           //превышает d2, то
                        //классификация цели
                    }
                    else
                    {
                        mode_ = (int)Modes.Con2;     //если дистанция меньше d2 - переход к режиму СН2
                    }
                    break;
                case false:         //если сигнала нет, 
                    mode_ =(int) Modes.PS1;     //переход к режиму ПРП1
                    break;
            }
        }

        public void Convergence2()      //самонаведение СН2     (3)
        {
            switch (targ.isReceived)
            {
                case true:
                    if (targ.distance > d3_)    //если дистанция до цели
                    {                           //превышает d3, то
                        //классификация цели
                    }
                    else
                    {
                        mode_ = (int)Modes.Con3;     //если дистанция меньше d3 - переход к режиму СН3
                    }
                    break;
                case false:         //если сигнала нет, 
                    mode_ = (int)Modes.PS2;     //переход к режиму ПРП2
                    break;
            }
        }

        public void Convergence3()      //самонаведение СН3     (4)
        {
            switch (targ.isReceived)
            {
                case true:
                    if (targ.distance > d4_)    //если дистанция до цели
                    {                           //превышает d4, то
                        //классификация цели
                    }
                    else
                    {
                        mode_ = (int)Modes.Con4;     //если дистанция меньше d4 - переход к режиму СН4
                    }
                    break;
                case false:         //если сигнала нет, 
                    mode_ = (int)Modes.PS3;     //переход к режиму ПРП3
                    break;
            }
        }

        public void Convergence4()      //самонаведение СН4     (5)
        {
            switch (targ.isReceived)
            {
                case true:                      //если сигнал есть,
                    mode_ = (int)Modes.G;     //переход к режиму НВ
                    break;
                case false:                  //если сигнала нет, 
                    mode_ = (int)Modes.PS4;     //переход к режиму ПРП4
                    break;
            }
        }

        public void PrecursiveSearch1()     //предварительный поиск ПРП1    (6)
        {
        }

        public void PrecursiveSearch2()     //предварительный поиск ПРП2    (7)
        {
        }

        public void PrecursiveSearch3()     //предварительный поиск ПРП3    (8)
        {
        }

        public void PrecursiveSearch4()     //предварительный поиск ПРП4    (9)
        {
        }

        public void RepeatedSearch1()  //повторный поиск ПП1 (ближний)      (10)
        {
        }

        public void RepeatedSearch2()  //повторный поиск ПП2                (11)
        {
        }

        public void AnotherSearch()     //поиск другого объекта ПДО         (12)
        {
        }

        public void Guidance()      //наведение НВ                          (13)
        {
        }

        public void Classification()        //классификация цели
        {
            //по результатам классификации,
            targ.isTrue = true; //если цель настоящая, или
            // targ.isTrue = false; //если цель ложная
        }

    }
}
