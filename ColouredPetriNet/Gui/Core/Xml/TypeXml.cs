using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Xml
{
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
}
