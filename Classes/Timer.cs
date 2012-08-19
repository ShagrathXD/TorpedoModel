﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TorpedoModel.Classes
{
 public class Timer     //системный таймер
        {
            
            private static double time_;

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
            

        }
        
        
}