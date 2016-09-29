using System.Collections.Generic;
using System.Xml.Serialization;
using PetriNetRules = ColouredPetriNet.GraphicsPetriNet.Rules;

namespace ColouredPetriNet.Gui.Core.Xml
{
    [XmlRoot("MoveRule")]
    public class MoveRuleXml
    {
        [XmlAttribute("priority")]
        public int Priority { get; set; }
        [XmlAttribute("output_state")]
        public int OutputState { get; set; }
        [XmlAttribute("input_state")]
        public int InputState { get; set; }
        [XmlAttribute("transition")]
        public int Transition { get; set; }
        [XmlElement("OneTypeMovingMarkerInfo")]
        public List<OneTypeMovingMarkerInfoXml> OneTypeMarkerRules;

        public MoveRuleXml()
            : this(-1, -1, -1, 1)
        {
        }

        public MoveRuleXml(int outputState, int inputState, int transition, int priority = 1)
        {
            Priority = priority;
            OutputState = outputState;
            InputState = inputState;
            Transition = transition;
            OneTypeMarkerRules = new List<OneTypeMovingMarkerInfoXml>();
        }

        public MoveRuleXml(PetriNetRules.MoveRule rule)
            : this(rule.OutputState, rule.InputState, rule.Transition, rule.Priority)
        {
            foreach (var m in rule.OneTypeMarkerInfoList)
            {
                OneTypeMarkerRules.Add(new OneTypeMovingMarkerInfoXml(m));
            }
        }
    }

    [XmlRoot("OneTypeMovingMarkerInfo")]
    public class OneTypeMovingMarkerInfoXml
    {
        [XmlAttribute("marker_type")]
        public int MarkerType { get; set; }
        [XmlAttribute("common_convert_type")]
        public string CommonConvertType { get; set; }
        [XmlAttribute("count")]
        public int Count { get; set; }
        [XmlElement("MovingMarkerIdConvert")]
        public List<MovingMarkerIdConvertXml> IdConvertList;

        public OneTypeMovingMarkerInfoXml()
            : this(-1, "Move", -1)
        {
        }

        public OneTypeMovingMarkerInfoXml(int markerType, string convertType, int count)
        {
            MarkerType = markerType;
            CommonConvertType = convertType;
            Count = count;
            IdConvertList = new List<MovingMarkerIdConvertXml>();
        }

        public OneTypeMovingMarkerInfoXml(PetriNetRules.OneTypeMovingMarkerInfo info)
            : this(info.MarkerType, info.CommonConvertType.ToString(), info.Count)
        {
            for (int i = 0; i < info.IdConvertList.Count; ++i)
            {
                this.IdConvertList.Add(new MovingMarkerIdConvertXml(info.IdConvertList[i].ToString()));
            }
        }
    }

    [XmlRoot("MovingMarkerIdConvert")]
    public class MovingMarkerIdConvertXml
    {
        [XmlAttribute("convert_type")]
        public string IdConvertType { get; set; }

        public MovingMarkerIdConvertXml()
        {
            IdConvertType = "Move";
        }

        public MovingMarkerIdConvertXml(string idConvert)
        {
            IdConvertType = idConvert;
        }
    }
}
