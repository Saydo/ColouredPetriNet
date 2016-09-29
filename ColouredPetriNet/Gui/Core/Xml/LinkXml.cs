using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Xml
{
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
}
