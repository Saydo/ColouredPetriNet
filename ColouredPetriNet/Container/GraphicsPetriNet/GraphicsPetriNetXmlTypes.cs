using System.Xml.Serialization;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Xml
{
    public class GraphicsPetriNetXml
    {
        // TODO: Types
        [XmlArray("States")]
        [XmlArrayItem("State")]
        public List<StateXml> StateList;
        [XmlArray("Transitions")]
        [XmlArrayItem("Transition")]
        public List<TransitionXml> TransitionList;
        [XmlArray("Links")]
        [XmlArrayItem("Link")]
        public List<LinkXml> LinkList;

        public GraphicsPetriNetXml()
        {
            StateList = new List<StateXml>();
            TransitionList = new List<TransitionXml>();
            LinkList = new List<LinkXml>();
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
        public string Type { get; set; }
        [XmlElement("Marker")]
        public List<MarkerXml> Markers;

        public StateXml()
        {
            Id = -1;
            X = Y = 0;
            Type = "";
            Markers = new List<MarkerXml>();
        }

        public StateXml(int id, int x, int y, string type)
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
        public string Type { get; set; }

        public TransitionXml()
        {
            Id = -1;
            X = Y = 0;
            Type = "";
        }

        public TransitionXml(int id, int x, int y, string type)
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
        public string Type { get; set; }

        public MarkerXml()
        {
            Id = -1;
            Type = "";
        }

        public MarkerXml(int id, string type)
        {
            this.Id = id;
            this.Type = type;
        }
    }
}

