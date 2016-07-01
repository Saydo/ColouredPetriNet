using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public class SelectionArea
    {
        public enum HorizontalDirection { Left, Right };
        public enum VerticalDirection { Top, Bottom };

        public SelectionArea() : this(0, 0, 0, 0)
        {
            m_visible = false;
        }

        public SelectionArea(int x, int y, int w, int h)
        {
            m_x = x;
            m_y = y;
            m_width = w;
            m_height = h;
            m_visible = true;
            m_fillBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 255));
            m_borderPen = new Pen(Color.FromArgb(0, 0, 255));
            m_hDirection = HorizontalDirection.Right;
            m_vDirection = VerticalDirection.Top;
        }

        public int x
        {
            get { return m_x; }
            set { m_x = (value < 0 ? 0 : value); }
        }

        public int y
        {
            get { return m_y; }
            set { m_y = (value < 0 ? 0 : value); }
        }

        public int width
        {
            get { return m_width; }
            set { m_width = (value < 0 ? 0 : value); }
        }

        public int height
        {
            get { return m_height; }
            set { m_height = (value < 0 ? 0 : value); }
        }

        public Brush fillBrush
        {
            get { return m_fillBrush; }
            set
            {
                if (!ReferenceEquals(m_fillBrush, null))
                {
                    m_fillBrush = value;
                }
            }
        }

        public Pen borderPen
        {
            get { return m_borderPen; }
            set
            {
                if (!ReferenceEquals(m_borderPen, null))
                {
                    m_borderPen = value;
                }
            }
        }

        public bool visible
        {
            get { return m_visible; }
            set { m_visible = value; }
        }

        public void draw(Graphics graphics)
        {
            if (m_visible)
            {
                int x = (m_hDirection == HorizontalDirection.Left ? m_x - m_width : m_x);
                int y = (m_vDirection == VerticalDirection.Bottom ? m_y - m_height : m_y);
                graphics.FillRectangle(m_fillBrush, x, y, m_width, m_height);
                graphics.DrawRectangle(m_borderPen, x, y, m_width, m_height);
            }
        }

        public HorizontalDirection horizontalDirection
        {
            get { return m_hDirection; }
            set { m_hDirection = value; }
        }

        public VerticalDirection verticalDirection
        {
            get { return m_vDirection; }
            set { m_vDirection = value; }
        }

        private int m_x;
        private int m_y;
        private int m_width;
        private int m_height;
        private Brush m_fillBrush;
        private Pen m_borderPen;
        private bool m_visible;
        private HorizontalDirection m_hDirection;
        private VerticalDirection m_vDirection;
    }
}
