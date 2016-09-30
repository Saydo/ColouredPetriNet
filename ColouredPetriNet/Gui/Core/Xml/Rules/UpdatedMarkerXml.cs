using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("UpdatedMarker")]
    public class UpdatedMarkerXml
    {
        [XmlAttribute("marker_type")]
        public int MarkerType { get; set; }
        [XmlAttribute("id_convert")]
        public string IdConvert { get; set; }

        public UpdatedMarkerXml()
        {
            MarkerType = -1; // Same type
            IdConvert = "Move";
        }

        public UpdatedMarkerXml(int markerType, string idConvert)
        {
            MarkerType = markerType;
            IdConvert = idConvert;
        }
    }
}
