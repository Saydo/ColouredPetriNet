using System.Xml.Serialization;
using System.Collections.Generic;

namespace ColouredPetriNet.Gui.Core.Xml
{
    public enum PenListItem { SelectionPen, LinePen };

    public class PetriNetStyleXml
    {
        [XmlElement("SelectionMode")]
        public SelectionModeXml SelectionMode;
        [XmlElement("Pen")]
        public PenXml[] PenList;
        [XmlArray("ItemsStyle")]
        [XmlArrayItem("ItemStyle")]
        public List<ItemStyleXml> ItemStyleList;

        public PetriNetStyleXml()
        {
            PenList = new PenXml[2] {
                new PenXml("SelectionPen", System.Drawing.Color.FromArgb(0, 0, 0)),
                new PenXml("LinePen", System.Drawing.Color.FromArgb(0, 0, 0))
            };
            SelectionMode = new SelectionModeXml();
            ItemStyleList = new List<ItemStyleXml>();
        }
    }

    public class SelectionModeXml
    {
        private string _value;
        [XmlAttribute("value")]
        public string Value
        {
            get { return _value; }
            set { _value = (value.Equals("Full") ? value : "Partial"); }
        }

        public SelectionModeXml()
        {
            Value = "Partial";
        }

        public SelectionModeXml(string mode)
        {
            Value = mode;
        }
    }

    public class PenXml
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("color")]
        public string Color { get; set; }
        [XmlAttribute("width")]
        public int Width { get; set; }

        public PenXml()
        {
            this.Name = "";
            this.Width = 1;
            var color = System.Drawing.Color.FromArgb(0, 0, 0);
            SetColor(color);
        }

        public PenXml(string name, System.Drawing.Color color, int width = 1)
        {
            this.Name = name;
            this.Width = width;
            SetColor(color);
        }

        public void SetColor(System.Drawing.Color color)
        {
            this.Color = color.ToArgb().ToString("X");
        }

        public void FromPen(System.Drawing.Pen pen)
        {
            this.Width = (int)pen.Width;
            this.Color = pen.Color.ToArgb().ToString("X");
        }

        public System.Drawing.Pen ToPen()
        {
            int argb = System.Int32.Parse(this.Color, System.Globalization.NumberStyles.HexNumber);
            return new System.Drawing.Pen(System.Drawing.Color.FromArgb(argb), this.Width);
        }
    }

    public class BrushXml
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("color")]
        public string Color { get; set; }

        public BrushXml()
        {
            var color = System.Drawing.Color.FromArgb(0, 0, 0);
            SetColor(color);
        }

        public BrushXml(string name, System.Drawing.Color color)
        {
            this.Name = name;
            SetColor(color);
        }

        public void SetColor(System.Drawing.Color color)
        {
            this.Color = color.ToArgb().ToString("X");
        }

        public void FromBrush(System.Drawing.SolidBrush brush)
        {
            this.Color = brush.Color.ToArgb().ToString("X");
        }

        public System.Drawing.SolidBrush ToBrush()
        {
            int argb = System.Int32.Parse(this.Color, System.Globalization.NumberStyles.HexNumber);
            return new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(argb));
        }
    }

    public class ItemStyleXml
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlElement("Pen")]
        public PenXml BorderPen;
        [XmlElement("Brush")]
        public BrushXml FillBrush;

        public ItemStyleXml()
        {
            Name = "";
            BorderPen = new PenXml("BorderPen", System.Drawing.Color.FromArgb(0, 0, 0));
            FillBrush = new BrushXml("FillBrush", System.Drawing.Color.FromArgb(0, 0, 0));
        }

        public ItemStyleXml(string name) : this()
        {
            Name = name;
        }
    }

    public class RoundItemStyleXml : ItemStyleXml
    {
        [XmlAttribute("radius")]
        public int Radius { get; set; }

        public RoundItemStyleXml() : base()
        {
            Radius = 1;
        }

        public RoundItemStyleXml(string name, int radius) : base(name)
        {
            Radius = radius;
        }
    }

    public class RectangleItemStyleXml : ItemStyleXml
    {
        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        public RectangleItemStyleXml() : base()
        {
            Width = 10;
            Height = 10;
        }

        public RectangleItemStyleXml(string name, int w, int h) : base(name)
        {
            Width = w;
            Height = h;
        }
    }

    public class TriangleItemStyleXml : ItemStyleXml
    {
        [XmlAttribute("side")]
        public int Side { get; set; }

        public TriangleItemStyleXml() : base()
        {
            Side = 10;
        }

        public TriangleItemStyleXml(string name, int side) : base(name)
        {
            Side = side;
        }
    }

    public class ImageItemStyleXml : RectangleItemStyleXml
    {
        [XmlAttribute("image")]
        public string Image { get; set; }

        public ImageItemStyleXml() : base()
        {
            Image = "";
        }

        public ImageItemStyleXml(string name, string image, int w, int h) : base(name, w, h)
        {
            Image = image;
        }
    }
}
