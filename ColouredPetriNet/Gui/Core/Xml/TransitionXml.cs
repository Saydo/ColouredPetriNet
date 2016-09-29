using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Xml
{
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
}
