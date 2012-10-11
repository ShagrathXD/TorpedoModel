using System;
using System.Collections.Generic;
using System.Text;
using TorpedoModel.Library;
using TorpedoModel.Classes;
using TorpedoModel.Library.Geometry;


namespace TorpedoModel.Interfaces
{
    public interface ITorpedo       //Интерфейс, по которому передаются параметры торпеды при ее создании и движении
    {
        void SetTorpedoDepth(float depth);     //глубина   
        void SetTorpedoPosition(Coordinates torpedoPosition);  //координаты
    }
}
