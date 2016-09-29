using System.Collections.Generic;
using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Xml
{
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
}
