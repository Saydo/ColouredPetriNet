using System.Collections.Generic;
using System.Xml.Serialization;
using PetriNetRules = ColouredPetriNet.GraphicsPetriNet.Rules;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("OneTypeMarkers")]
    public class OneTypeMarkerConvertXml
    {
        [XmlAttribute("marker_type")]
        public int MarkerType { get; set; }
        [XmlAttribute("count")]
        public int Count { get; set; }
        [XmlElement("MarkerIdConvert")]
        public List<MarkerIdConvertXml> IdConvertList;
        [XmlElement("RestMarkersIdConvert")]
        public MarkerIdConvertXml RestMarkersIdConvert;

        public OneTypeMarkerConvertXml()
            : this(-1, -1)
        {
        }

        public OneTypeMarkerConvertXml(int markerType, int count)
        {
            this.MarkerType = markerType;
            this.Count = count;
            IdConvertList = new List<MarkerIdConvertXml>();
            RestMarkersIdConvert = new MarkerIdConvertXml();
        }

        public OneTypeMarkerConvertXml(PetriNetRules.OneTypeMarkerConvertInfo info)
        {
            this.MarkerType = info.MarkerType;
            this.Count = info.Count;
            IdConvertList = new List<MarkerIdConvertXml>();
            RestMarkersIdConvert = new MarkerIdConvertXml(info.RestMarkersIdConvert);
            for (int i = 0; i < info.ConvertRules.Count; ++i)
            {
                IdConvertList.Add(new MarkerIdConvertXml(info.ConvertRules[i]));
            }
        }
    }
}
