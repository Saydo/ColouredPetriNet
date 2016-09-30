using System.Xml.Serialization;
using PetriNetRules = ColouredPetriNet.GraphicsPetriNet.Rules;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("NewMarkers")]
    public class NewMarkersXml
    {
        [XmlAttribute("marker_type")]
        public int MarkerType { get; set; }
        [XmlAttribute("count")]
        public int Count { get; set; }

        public NewMarkersXml()
        {
            MarkerType = -1;
            Count = 1;
        }

        public NewMarkersXml(int type, int count = 1)
        {
            this.MarkerType = type;
            this.Count = count;
        }

        public NewMarkersXml(PetriNetRules.OneTypeMarkerInfo info)
        {
            this.MarkerType = info.MarkerType;
            this.Count = info.Count;
        }
    }
}
