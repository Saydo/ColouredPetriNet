using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public interface IColourGraphicsItem : IGraphicsItem
    {
        Brush fillBrush
        {
            get;
            set;
        }
        Pen borderPen
        {
            get;
            set;
        }
    }

    public class ColourGraphicsItem : GraphicsItem, IColourGraphicsItem
    {
        public ColourGraphicsItem() : this(-1, -1)
        {
        }

        public ColourGraphicsItem(int id, int typeId, int x = 0, int y = 0, int z = 0) : base(id, typeId, x, y, z)
        {
            m_fillBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
            m_borderPen = new Pen(Color.FromArgb(0, 0, 0));
        }

        public Brush fillBrush
        {
            get { return m_fillBrush; }
            set { m_fillBrush = value; }
        }

        public Pen borderPen
        {
            get { return m_borderPen; }
            set { m_borderPen = value; }
        }

        protected Brush m_fillBrush;
        protected Pen m_borderPen;
    }
}
