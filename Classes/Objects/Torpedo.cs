using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TorpedoModel.Library.Geometry;

namespace TorpedoModel.Classes
{
   public  class Torpedo
    {
       TorpedoControlAlgorithm alg;
       Target targ;
       

           public Coordinates torpPosition; //координаты торпеды

           public Coordinates coord = new Coordinates();  //инициализация координат
           public void InitCoord(Coordinates coord_)
           {
               torpPosition = coord_;
           }


           public Torpedo()     //инициализация всей торпеды
           {
               InitCoord(coord);
               TorpedoControlAlgorithm alg_ = new TorpedoControlAlgorithm();
               alg = alg_;
            }

           public void SetTorpedoPosition(Coordinates torpedoPosition) //запись координат торпеды
           {                   
               torpPosition = torpedoPosition;
           }



           public void GetTargetData(Target targ_)      //получить информацию о цели
           {
               targ = targ_;
           }

           public void Algorithm()      //старт алгоритма торпеды
           {
               alg.Process;
           }


     }
}
