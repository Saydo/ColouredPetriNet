using System.Collections.Generic;
using System.Xml.Serialization;
using PetriNetRules = ColouredPetriNet.GraphicsPetriNet.Rules;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("MarkerIdConvert")]
    public class MarkerIdConvertXml
    {
        [XmlElement("UpdatedMarker")]
        public UpdatedMarkerXml UpdatedMarker;
        [XmlElement("NewMarkers")]
        public List<NewMarkersXml> NewMarkersList;

        public MarkerIdConvertXml()
        {
            UpdatedMarker = new UpdatedMarkerXml();
            NewMarkersList = new List<NewMarkersXml>();
        }

        public MarkerIdConvertXml(UpdatedMarkerXml updatedMarker)
        {
            UpdatedMarker = updatedMarker;
            NewMarkersList = new List<NewMarkersXml>();
        }

        public MarkerIdConvertXml(PetriNetRules.MarkerIdConvert idConvert)
        {
            UpdatedMarker = new UpdatedMarkerXml(idConvert.UpdatedMarkerType,
                idConvert.UpdatedMarkerConvert.ToString());
            NewMarkersList = new List<NewMarkersXml>();
            for (int i = 0; i < idConvert.NewMarkers.Count; ++i)
            {
                NewMarkersList.Add(new NewMarkersXml(idConvert.NewMarkers[i]));
            }
        }
    }
}
