using System.Drawing;

namespace ColouredPetriNet.Gui.Core.GraphicsItems
{
    public class ColourGraphicsItem : GraphicsItem
    {
        protected Brush _fillBrush;
        protected Pen _borderPen;

        public Brush FillBrush
        {
            get { return _fillBrush; }
            set { _fillBrush = value; }
        }

        public Pen BorderPen
        {
            get { return _borderPen; }
            set { _borderPen = value; }
        }

        public ColourGraphicsItem() : this(-1, -1, new Point(0, 0))
        {
        }

        public ColourGraphicsItem(int id, int typeId, int z = 0)
            : this(id, typeId, new Point(0, 0), z)
        {
        }

        public ColourGraphicsItem(int id, int typeId, Point center, int z = 0)
            : base(id, typeId, center, z)
        {
            _fillBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
            _borderPen = new Pen(Color.FromArgb(0, 0, 0));
        }
    }
}
