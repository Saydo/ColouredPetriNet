using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("ColouredPetriNet")]
    public class GraphicsPetriNetXml
    {
        [XmlElement("Style")]
        public PetriNetStyleXml Style;
        [XmlArray("Types")]
        [XmlArrayItem("Type")]
        public List<TypeXml> Types;
        [XmlArray("PrevAccumulateRules")]
        [XmlArrayItem("AccumulateRule")]
        public List<AccumulateRuleXml> PrevAccumulateRules;
        [XmlArray("NextAccumulateRules")]
        [XmlArrayItem("AccumulateRule")]
        public List<AccumulateRuleXml> NextAccumulateRules;
        [XmlArray("MoveRules")]
        [XmlArrayItem("MoveRule")]
        public List<MoveRuleXml> MoveRules;
        [XmlArray("States")]
        [XmlArrayItem("State")]
        public List<StateXml> States;
        [XmlArray("Transitions")]
        [XmlArrayItem("Transition")]
        public List<TransitionXml> Transitions;
        [XmlArray("Links")]
        [XmlArrayItem("Link")]
        public List<LinkXml> Links;

        public GraphicsPetriNetXml()
        {
            Style = new PetriNetStyleXml();
            Types = new List<TypeXml>();
            PrevAccumulateRules = new List<AccumulateRuleXml>();
            NextAccumulateRules = new List<AccumulateRuleXml>();
            MoveRules = new List<MoveRuleXml>();
            States = new List<StateXml>();
            Transitions = new List<TransitionXml>();
            Links = new List<LinkXml>();
        }
    }
}
