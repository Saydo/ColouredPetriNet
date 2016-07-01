using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public interface IRoundGraphicsItem : IGraphicsItem
    {
        int radius
        {
            get;
            set;
        }
    }

    public class RoundGraphicsItem : ColourGraphicsItem, IRoundGraphicsItem
    {
        public RoundGraphicsItem() : this(-1, -1)
        {
        }

        public RoundGraphicsItem(int id, int typeId, int r = 10, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, x, y, z)
        {
            radius = r;
        }

        public int radius
        {
            get { return m_radius; }
            set
            {
                m_radius = (value < 0 ? 0 : value);
                updateBorder();
            }
        }

        public override void draw(Graphics graphics)
        {
            graphics.FillEllipse(m_fillBrush, m_x - m_radius, m_y - m_radius, 2*m_radius, 2*m_radius);
            graphics.DrawEllipse(m_borderPen, m_x - m_radius, m_y - m_radius, 2*m_radius, 2*m_radius);
            if (m_selected)
            {
                int r = m_radius + m_extent;
                graphics.DrawEllipse(m_selectionPen, m_x - r, m_y - r, 2*r, 2*r);
            }
        }

        public override bool inShape(int x, int y)
        {
            int r = m_radius + (m_selected ? m_extent : 0);
            return ((x - m_x) * (x - m_x) + (y - m_y) * (y - m_y) <= r * r);
        }

        public override bool inShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if (((y > m_y) && (x > m_x) && (!inShape(x, y)))
                    || ((y + h < m_y) && (x > m_x) && (!inShape(x, y + h)))
                    || ((y > m_y) && (x + w < m_x) && (!inShape(x + w, y)))
                    || ((y + h < m_y) && (x + w < m_x) && (!inShape(x + w, y + h))))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if ((x < m_x) && (y < m_y) && (x + w > m_x) && (y + h > m_y) && inShape(x, y)
                    && inShape(x, y + h) && inShape(x + w, y + h) && inShape(x + w, y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void setBorder(int left, int right, int bottom, int top)
        {
            base.setBorder(left, right, bottom, top);
            m_radius = (right - left - (int)m_borderPen.Width) / 2 - (m_selected ? m_extent : 0);
        }

        protected override void updateBorder()
        {
            int r = m_radius + (int)m_borderPen.Width / 2 + (m_selected ? m_extent : 0);
            base.setBorder(-r, r, -r, r);
        }

        protected int m_radius;
    }
}