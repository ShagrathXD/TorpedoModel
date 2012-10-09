using System;
using System.Collections.Generic;
using System.Text;

namespace TorpedoModel.Classes
{
    public class Timer     //класс реализует все, что связано со временем 
    {          
        private static double time_;

        float countInterval;   //интервал работы обратного таймера 
        bool timerIsWorking = false;    //сообщает о том, что работает таймер
        bool timeIsOut = false;        //сообщает о том, что время истекло

        public Timer()      //конструктор 
        {
            Reset();
        }

        public static void Reset()	  //обнуление
        {
            time_ = 0;
        }
        public void Increment(double step)  //время + 1
        {
            time_ += step;
        }
        public static void GetTime(out double time)  //значение времени
        {
            time = time_;
        }

        public void StartCount(float countInterval_)   //установка таймера обратного отсчета на интервал countInterval_     
        {                                                                   
            timerIsWorking = true;   
        }

        public void CountProcess()          //непосредственно обратный отсчет
        {
        }
    }    
}
