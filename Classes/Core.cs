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
        TorpedoControlAlgorithm alg;
        Timer timer = new Timer();
        
        public void Cycle() //цикл последовательно вызывает основные компоненты системы
        {
            MovingProcessor move_ = new MovingProcessor(); 
            move = move_;
            move.InitMovingProcessor();
            Console.WriteLine("init move proc ok");
            TorpedoControlAlgorithm alg_ = new TorpedoControlAlgorithm(move.torp, move.targ);
            alg = alg_;
            while (!stop_)  
            {
                alg.Process();
                move.torp.SetControlData(alg.torp);
                move.MoveProcess();
                alg.targ.SetTargetData(move.targ);
                timer.Increment(step_);             
            }
        }  
  }      
}



