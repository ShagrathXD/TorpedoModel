using System;
using System.Collections.Generic;
using System.Text;

namespace TorpedoModel.Classes
{
    public class Timer     //класс реализует все, что связано со временем 
    {          
        private static double time_;

        double countInterval;   //интервал работы обратного таймера 
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

        public void Process(double step)  //системное время + 1
        {
            time_ += step;  
            if (timerIsWorking = true)      //если есть запущенный таймер,
            {
                CountProcess(step);     //то происходит переход к его алгоритму
            }
        }

        public static void GetTime(out double time)  //значение времени
        {
            time = time_;
        }



        public void StartCount(float countInterval_)   //установка таймера обратного отсчета на интервал countInterval_     
        {                                                                   
            timerIsWorking = true;
            countInterval = countInterval_;
        }

        public void CountProcess(double step)          //непосредственно обратный отсчет
        {
            if (countInterval != 0)
            {
                countInterval -= step;
            }
            else
            {
                timerIsWorking = false;
                timeIsOut = true;
            }
        }
    }    
}
