using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Xml
{
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
