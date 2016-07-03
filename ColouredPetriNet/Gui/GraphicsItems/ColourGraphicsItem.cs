using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
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

        public ColourGraphicsItem() : this(-1, -1)
        {
        }

        public ColourGraphicsItem(int id, int typeId, int x = 0, int y = 0, int z = 0) : base(id, typeId, x, y, z)
        {
            _fillBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
            _borderPen = new Pen(Color.FromArgb(0, 0, 0));
        }
    }
}
