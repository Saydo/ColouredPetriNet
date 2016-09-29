using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public enum IdConvertType { New, Move, Delete };

    public class MarkerIdConvert
    {
        public int UpdatedMarkerType { get; private set; }
        public IdConvertType UpdatedMarkerConvert { get; private set; }
        public List<OneTypeMarkerInfo> NewMarkers;

        public MarkerIdConvert()
            : this(-1, IdConvertType.Move)
        {
        }

        public MarkerIdConvert(int updatedMarkerType, IdConvertType updatedMarkerConvert)
        {
            UpdatedMarkerType = updatedMarkerType;
            UpdatedMarkerConvert = updatedMarkerConvert;
            NewMarkers = new List<OneTypeMarkerInfo>();
        }
    }
}
