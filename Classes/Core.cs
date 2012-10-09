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
        Timer time;
        
        public void Cycle() //цикл последовательно вызывает основные компоненты системы
        {
            CreateBasicObjects(new MovingProcessor(), new Timer());
            while (!stop_)  
            {
                move.MoveProcess();
                time.Process(step_);             
            }
        }

        void CreateBasicObjects(MovingProcessor move_, Timer time_)
        {
            move = move_;
            time = time_;
        }
  }      
}



