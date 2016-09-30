using System.Collections.Generic;
using System.Xml.Serialization;
using PetriNetRules = ColouredPetriNet.GraphicsPetriNet.Rules;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("MoveRule")]
    public class MoveRuleXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("priority")]
        public int Priority { get; set; }
        [XmlAttribute("output_state")]
        public int OutputState { get; set; }
        [XmlAttribute("input_state")]
        public int InputState { get; set; }
        [XmlAttribute("transition")]
        public int Transition { get; set; }
        [XmlArray("UpdatedMarkers")]
        [XmlArrayItem("OneTypeMarkers")]
        public List<OneTypeMarkerConvertXml> UpdatedMarkers;
        [XmlArray("NewMarkers")]
        [XmlArrayItem("OneTypeNewMarkers")]
        public List<NewMarkersXml> NewMarkers;

        public MoveRuleXml()
            : this(-1, -1, -1, -1, 1)
        {
        }

        public MoveRuleXml(int id, int outputState, int inputState, int transition, int priority = 1)
        {
            Id = id;
            Priority = priority;
            OutputState = outputState;
            InputState = inputState;
            Transition = transition;
            UpdatedMarkers = new List<OneTypeMarkerConvertXml>();
            NewMarkers = new List<NewMarkersXml>();
        }

        public MoveRuleXml(PetriNetRules.MoveRule rule)
            : this(rule.Id, rule.OutputState, rule.InputState, rule.Transition, rule.Priority)
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
