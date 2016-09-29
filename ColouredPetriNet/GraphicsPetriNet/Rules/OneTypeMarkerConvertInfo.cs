using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public class OneTypeMarkerConvertInfo
    {
        public int MarkerType { get; set; }
        public int Count { get; set; }
        public MarkerIdConvert RestMarkersIdConvert;
        public List<MarkerIdConvert> ConvertRules;

        public OneTypeMarkerConvertInfo()
            : this(-1, -1, -1, IdConvertType.Delete)
        {
        }

        public OneTypeMarkerConvertInfo(int markerType, int count, int updatedMarkerType, IdConvertType updatedMarkerConvert)
        {
            MarkerType = markerType;
            Count = count;
            RestMarkersIdConvert = new MarkerIdConvert(updatedMarkerType, updatedMarkerConvert);
            ConvertRules = new List<MarkerIdConvert>();
        }
    }
}
