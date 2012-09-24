using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Classes; 
using TorpedoModel.Interfaces;
///работа системы начинается с запуска инициализации в ядре. этот основной класс приложения служит для передачи управления в ядро
namespace TorpedoModel
{
    class Program         					
    {
        public static void Main(string[] args)  		//главная точка входа
        {
            Core init_ = new Core();    
            init_.Cycle();          
        }
    }
}





