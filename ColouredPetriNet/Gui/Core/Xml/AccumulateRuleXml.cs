using System.Collections.Generic;
using System.Xml.Serialization;
using PetriNetRules = ColouredPetriNet.GraphicsPetriNet.Rules;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("AccumulateRule")]
    public class AccumulateRuleXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("state")]
        public int State { get; set; }
        [XmlAttribute("priority")]
        public int Priority { get; set; }
        [XmlArray("UpdatedMarkers")]
        [XmlArrayItem("OneTypeMarkers")]
        public List<OneTypeMarkerConvertXml> UpdatedMarkers;
        [XmlArray("NewMarkers")]
        [XmlArrayItem("OneTypeNewMarkers")]
        public List<NewMarkersXml> NewMarkers;

        public AccumulateRuleXml()
            : this(-1, -1, 1)
        {
        }

        public AccumulateRuleXml(int id, int state, int priority = 1)
        {
            Id = id;
            State = state;
            Priority = priority;
            UpdatedMarkers = new List<OneTypeMarkerConvertXml>();
            NewMarkers = new List<NewMarkersXml>();
        }

        public AccumulateRuleXml(PetriNetRules.AccumulateRule rule)
            : this(rule.State, rule.Priority)
        {
            for (int i = 0; i < rule.UpdatedMarkers.Count; ++i)
            {
                this.UpdatedMarkers.Add(new OneTypeMarkerConvertXml(rule.UpdatedMarkers[i]));
            }
            for (int i = 0; i < rule.NewMarkers.Count; ++i)
            {
                this.NewMarkers.Add(new NewMarkersXml(rule.NewMarkers[i]));
            }
        }
    }

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
