using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Classes;
using TorpedoModel.Interfaces;
//алгоритм управления торпедой; принимает обработанную информацию о сигнале, и на ее основе подает сигналы управления на руль, двигатель и излучатель 
namespace TorpedoModel
{
    public class TorpedoControlAlgorithm : ITorpedoControlAlgorithm, IObjectControl
    {
        public ObjectControl obj;
        Target targ;

        public const int d2_ = 700; //дистанция, на которой режим излучения меняется с "С1" на "С2"
        public const int d3_ = 500;  //дистанция, на которой длительность акустического цикла уменьшается в 4 раза, м
        public const int d4_ = 200;      //дистанция, на которой длительность зондирующего сигнала уменьшается в 2 раза, м
        
        private bool searchIsFirst_ = true;     //указатель того, что поиск первичный
        public int k_ = 0;       //служебная переменная

        float speed;
        float s1 = 42; //скорость самонаведения
        float s2 = 28;

        public int mode_ = 0;   //флаг режима
        enum Modes { FS, CV, Con1, Con2, Con3, Con4, PS1, PS2, PS3, PS4, RS1, RS2, AS, G }; //перечисление всех режимов

        public TorpedoControlAlgorithm(Target t)
        {
            obj = new ObjectControl();
            targ = t;            
        }

        public void Process()  //алгоритм
        {
            #region Switching_Between_Modes
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
            #endregion
        }
    



        #region Modes (parts of algorithm)

        public void FirstSearch()   //первичный поиск (0)
        {
            if (targ.isReceived = true) //если принят сигнал, то
                mode_ = (int)Modes.CV;              //переход к ПК
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
            speed = obj.EnginePower;
            switch (targ.isReceived)    
            {
                case true:
                    if (targ.distance > d2_)    //если дистанция до цели превышает d2, то
                    {
                        Classification(targ);   //классификация цели
                        if (speed < s1)
                            obj.SetEnginePower(speed + (3 / 2));
                        else
                        {
                            if (speed > s1)
                                obj.SetEnginePower(s1);
                            else
                                break;        
                        }
                        obj.SetHorizontalRotationVelocity(0);
                        obj.SetVerticalRotationVelocity(0);
                    }
                    else                     //если дистанция меньше d2
                    {
                        
                            mode_ = (int)Modes.Con2;    //переход к режиму СН2
                                    
                    }
                    break;
                case false:         //если сигнала нет, 
                    if (speed = s2)     //если скорость = 28 узл, то 
                        mode_ = (int)Modes.PS1;     //переход к режиму ПРП1
                    else
                    {
                        if (speed > s2)
                            obj.SetEnginePower(speed - (5 / 2));
                        else
                        {
                            obj.SetEnginePower(s2);
                            mode_ = (int)Modes.PS1;
                        }
                    }            
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
                        Classification(targ);   //классификация цели
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
                        Classification(targ);   //классификация цели   
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
            //предварительный поиск  
            mode_ = (int)Modes.RS2;  //переход к режиму ПП2
        }

        public void PrecursiveSearch2()     //предварительный поиск ПРП2    (7)
        {
            //предварительный поиск  
            mode_ = (int)Modes.RS1;  //переход к режиму ПП1
        }

        public void PrecursiveSearch3()     //предварительный поиск ПРП3    (8)
        {
            //предварительный поиск  
            mode_ = (int)Modes.RS1;  //переход к режиму ПП1
        }

        public void PrecursiveSearch4()     //предварительный поиск ПРП4    (9)
        {
            //предварительный поиск  
            mode_ = (int)Modes.RS1;  //переход к режиму ПП1
        }

        public void RepeatedSearch1()  //повторный поиск ПП1 (ближний)      (10)
        {
            switch (targ.isReceived)
            {
                case true:                //если есть сигнал, то
                    mode_ = (int)Modes.Con2;   //переход в режим СН2
                    break;
                case false:               //если нет, то
                    // циркуляция
                    break;
            }
        }

        public void RepeatedSearch2()  //повторный поиск ПП2  (дальний)              (11)
        {
            switch (targ.isReceived)
            {
                case true:                //если есть сигнал, то
                    mode_ = (int)Modes.Con1;   //переход в режим СН1
                    break;
                case false:               //если нет, то
                    // циркуляция
                    break;
            }
        }

        public void AnotherSearch()     //поиск другого объекта ПДО         (12)
        {
            switch (k_)                 // флаг k_ равен нулю, если круг циркуляции первый по счету
            {
                case 0:                 
                    // циркуляция;
                    // if (круг завершен)       //проверка завершения круга
                    // {
                    //     k_ = 1;              //если да, установка флага 
                    // }
                    break;
                case 1:                 
                    if (targ.isClassified = false)  //если цель не классифицирована, тогда
                    {
                        mode_ = (int)Modes.CV;           //переход в режим ПК
                        k_ = 0;                     //обнуление флага k_
                    }
                    break;
            }
        }

        public void Guidance()      //наведение НВ                          (13)
        {
            obj.SetCockedMode(true);        //установка боевого взвода
        }

        #endregion
        
        public void Classification(Target t_)        //классификация цели
        {
            //по результатам классификации,
            targ.isTrue = true; //если цель настоящая, или
            // targ.isTrue = false; //если цель ложная

            if (targ.isTrue = false)    //проверка на истинность по итогам классификации 
            {                           //если цель ложная, то
                mode_ = (int)Modes.AS;  //переход в режим ПДО
            }
        }


        #region ITorpedoControlAlgorithm Members

        public void SetTargetInformation(Angle peleng, float distance, Angle targetCourse, float targetSpeed)
        {
            targ.peleng = peleng;
            targ.distance = distance;
            targ.course = targetCourse;
            targ.speed = targetSpeed;
        }

        public void SetTargetSignalReceived(bool isReceived)
        {
            targ.isReceived = isReceived;
        }

        public void SetSignalAmplitude(float signalAmp)
        {
        }
        #endregion

        #region IObjectControl Members

        public void SetHorizontalRotationVelocity(float newSpeed)
        {
            throw new NotImplementedException();
        }

        public void SetVerticalRotationVelocity(float newSpeed)
        {
            throw new NotImplementedException();
        }

        public void SetEnginePower(float speed)
        {
            throw new NotImplementedException();
        }

        public void SetCockedMode(bool on)
        {
            throw new NotImplementedException();
        }

        public void SetSignalLength(float length)
        {
            throw new NotImplementedException();
        }

        public void SetProbeLength(float length)
        {
            throw new NotImplementedException();
        }

        public void EmmitSignalAndStartEchoWaiting()
        {
            throw new NotImplementedException();
        }

        public void StopEchoWaiting()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
