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
            : this(rule.Id, rule.State, rule.Priority)
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
}
