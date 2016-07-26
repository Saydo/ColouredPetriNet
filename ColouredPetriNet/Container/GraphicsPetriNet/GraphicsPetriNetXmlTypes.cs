using System.Xml.Serialization;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Xml
{
    public class GraphicsPetriNetXml
    {
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
            Types = new List<TypeXml>();
            PrevAccumulateRules = new List<AccumulateRuleXml>();
            NextAccumulateRules = new List<AccumulateRuleXml>();
            MoveRules = new List<MoveRuleXml>();
            States = new List<StateXml>();
            Transitions = new List<TransitionXml>();
            Links = new List<LinkXml>();
        }
    }

    public class TypeXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("kind")]
        public string Kind { get; set; }
        [XmlAttribute("form")]
        public string Form { get; set; }

        public TypeXml()
        {
            Id = -1;
            Name = "";
            Kind = "";
            Form = "";
        }

        public TypeXml(int id, string name, string kind, string form)
        {
            Id = id;
            Name = name;
            Kind = kind;
            Form = form;
        }
    }

    public class AccumulateRuleXml
    {
        [XmlAttribute("stateType")]
        public int StateType { get; set; }
        [XmlArray("OutputMarkers")]
        [XmlArrayItem("OneTypeMarkers")]
        public List<OneTypeMarkersXml> OutputMarkers;
        [XmlArray("InputMarkers")]
        [XmlArrayItem("OneTypeMarkers")]
        public List<OneTypeMarkersXml> InputMarkers;

        public AccumulateRuleXml(int stateType = -1)
        {
            StateType = stateType;
            OutputMarkers = new List<OneTypeMarkersXml>();
            InputMarkers = new List<OneTypeMarkersXml>();
        }
    }

    public class OneTypeMarkersXml
    {
        [XmlAttribute("type")]
        public int Type { get; set; }
        [XmlAttribute("count")]
        public int Count { get; set; }

        public OneTypeMarkersXml()
        {
            Type = -1;
            Count = -1;
        }

        public OneTypeMarkersXml(int type, int count)
        {
            Type = type;
            Count = count;
        }
    }

    public class MoveRuleXml
    {
        [XmlAttribute("outputStateType")]
        public int OutputStateType { get; set; }
        [XmlAttribute("inputStateType")]
        public int InputStateType { get; set; }
        [XmlAttribute("transitionType")]
        public int TransitionType { get; set; }
        [XmlElement("OutputMarkers")]
        public OneTypeMarkersXml OutputMarkers;
        [XmlArray("InputMarkers")]
        [XmlArrayItem("OneTypeMarkers")]
        public List<OneTypeMarkersXml> InputMarkers;

        public MoveRuleXml()
        {
            OutputStateType = -1;
            InputStateType = -1;
            TransitionType = -1;
            OutputMarkers = new OneTypeMarkersXml();
            InputMarkers = new List<OneTypeMarkersXml>();
        }

        public MoveRuleXml(int outputStateType, int inputStateType, int transitionType,
            OneTypeMarkersXml outputMarkers, List<OneTypeMarkersXml> inputMarkers)
        {
            OutputStateType = outputStateType;
            InputStateType = inputStateType;
            TransitionType = transitionType;
            OutputMarkers = new OneTypeMarkersXml();
            InputMarkers = new List<OneTypeMarkersXml>();
        }
    }

    public class StateXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("x")]
        public int X { get; set; }
        [XmlAttribute("y")]
        public int Y { get; set; }
        [XmlAttribute("type")]
        public int Type { get; set; }
        [XmlElement("Marker")]
        public List<MarkerXml> Markers;

        public StateXml()
        {
            Id = -1;
            X = Y = 0;
            Type = -1;
            Markers = new List<MarkerXml>();
        }

        public StateXml(int id, int x, int y, int type)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.Type = type;
            this.Markers = new List<MarkerXml>();
        }
    }

    public class TransitionXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("x")]
        public int X { get; set; }
        [XmlAttribute("y")]
        public int Y { get; set; }
        [XmlAttribute("type")]
        public int Type { get; set; }

        public TransitionXml()
        {
            Id = -1;
            X = Y = 0;
            Type = -1;
        }

        public TransitionXml(int id, int x, int y, int type)
        {
            this.Id = id;
            this.X = x;
            this.Y = y;
            this.Type = type;
        }
    }

    public class LinkXml
    {
        private string _direction;
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("state")]
        public int StateId { get; set; }
        [XmlAttribute("transition")]
        public int TransitionId { get; set; }
        [XmlAttribute("direction")]
        public string Direction
        {
            get { return _direction; }
            set { _direction = (value.Equals("FromState") ? value : "ToState"); }
        }

        public LinkXml()
        {
            this.Id = this.StateId = this.TransitionId = -1;
            this.Direction = "FromState";
        }

        public LinkXml(int id, int state, int transition, string direction)
        {
            this.Id = id;
            this.StateId = state;
            this.TransitionId = transition;
            this.Direction = direction;
        }
    }

    public class MarkerXml
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
        [XmlAttribute("type")]
        public int Type { get; set; }

        public MarkerXml()
        {
            Id = -1;
            Type = -1;
        }

        public MarkerXml(int id, int type)
        {
            this.Id = id;
            this.Type = type;
        }
    }
}

