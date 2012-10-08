using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Classes;
using TorpedoModel.Interfaces;
//ядро системы
namespace TorpedoModel
{
    class Core
    {
        private double step_ = 1;   //шаг системного таймера
        private bool stop_ = false;  //флаг остановки 
        MovingProcessor move;
        ObjectControl obj; 
        Timer timer = new Timer();
        
        public void Cycle() //цикл последовательно вызывает основные компоненты системы
        {
            MovingProcessor move_ = new MovingProcessor(); 
            move = move_;
            move.CreateObjects();
            Console.WriteLine("init move proc ok");
            while (!stop_)  
            {
                move.MoveProcess();
                timer.Increment(step_);             
            }
        }  
  }      
}



