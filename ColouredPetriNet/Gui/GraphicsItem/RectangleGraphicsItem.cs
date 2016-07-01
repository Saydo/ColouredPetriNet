using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public interface IRectangleGraphicsItem : IGraphicsItem
    {
        int width
        {
            get;
            set;
        }
        int height
        {
            get;
            set;
        }
        void setSize(int w, int h);
    }

    public class RectangleGraphicsItem : ColourGraphicsItem, IRectangleGraphicsItem
    {
        public RectangleGraphicsItem() : this(-1, -1)
        {
        }

        public RectangleGraphicsItem(int id, int typeId, int w = 10, int h = 10, int x = 0, int y = 0, int z = 0)
            : base (id, typeId, x, y, z)
        {
            m_width = w;
            m_height = h;
        }

        public int width
        {
            get { return m_width; }
            set
            {
                m_width = (value < 0 ? 0 : value);
                updateBorder();
            }
        }

        public int height
        {
            get { return m_height; }
            set
            {
                m_height = (value < 0 ? 0 : value);
                updateBorder();
            }
        }

        public void setSize(int w, int h)
        {
            m_width = w;
            m_height = h;
            updateBorder();
        }

        public override void setBorder(int left, int right, int bottom, int top)
        {
            base.setBorder(left, right, bottom, top);
            m_width = right - left - (int)m_borderPen.Width;
            m_height = top - bottom - (int)m_borderPen.Width;
            if (m_selected)
            {
                m_width -= 2 * m_extent;
                m_height -= 2 * m_extent;
            }
        }

        public override void draw(Graphics graphics)
        {
            graphics.FillRectangle(m_fillBrush, m_x - m_width/2, m_y - m_height/2, m_width, m_height);
            graphics.DrawRectangle(m_borderPen, m_x - m_width/2, m_y - m_height/2, m_width, m_height);
            if (m_selected)
            {
                graphics.DrawRectangle(m_selectionPen, m_x - m_width/2 - m_extent, m_y - m_height/2 - m_extent,
                    m_width + 2*m_extent, m_height + 2*m_extent);
            }
        }

        protected override void updateBorder()
        {
            int half_width = (m_width - (int)m_borderPen.Width) / 2;
            int half_height = (m_height - (int)m_borderPen.Width) / 2;
            if (m_selected)
            {
                half_width += m_extent;
                half_height += m_extent;
            }
            base.setBorder(-half_width, half_width, -half_height, half_height);
        }

        protected int m_width;
        protected int m_height;
    }
}
