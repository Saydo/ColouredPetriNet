using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public enum BorderName { Left, Right, Top, Bottom };
    public enum OverlapType { Full, Partial };

    public interface IGraphicsItem
    {
        int id
        {
            get;
        }
        int x
        {
            get;
            set;
        }
        int y
        {
            get;
            set;
        }
        int z
        {
            get;
            set;
        }
        int typeId
        {
            get;
        }
        int extent
        {
            get;
            set;
        }
        Pen selectionPen
        {
            get;
            set;
        }
        void draw(Graphics graphics);
        bool isCollision(int x, int y, int z = -1);
        bool isCollision(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial, int z = -1);
        bool inBorder(int x, int y);
        bool overlapBorder(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial);
        void setBorder(int left, int right, int top, int bottom);
        int[] getBorder();
        Point getPos();
        bool isSelected();
        void select();
        void deselect();
    }

    public class GraphicsItem : IGraphicsItem
    {
        public GraphicsItem() : this(-1, -1)
        {
        }

        public GraphicsItem(int id, int typeId, int x = 0, int y = 0, int z = 0)
        {
            m_borderPoint = new[] { 0, 0, 0, 0 };
            m_id = id;
            m_typeId = typeId;
            m_x = x;
            m_y = y;
            m_z = z;
            m_extent = 2;
            m_selected = false;
            m_selectionPen = new Pen(Color.FromArgb(0, 0, 0));
        }

        public int id
        {
            get { return m_id; }
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

        public int z
        {
            get { return m_z; }
            set { m_z = (value < 0 ? 0 : value); }
        }

        public int typeId
        {
            get { return m_typeId; }
        }

        public int extent
        {
            get { return m_extent; }
            set
            {
                m_extent = (value < 0 ? 0 : value);
                updateBorder();
            }
        }

        public Pen selectionPen
        {
            get { return m_selectionPen; }
            set
            {
                if (!ReferenceEquals(value, null))
                {
                    m_selectionPen = value;
                }
            }
        }

        public virtual void draw(Graphics graphics)
        {
            if (m_selected)
            {
                graphics.DrawRectangle(m_selectionPen, m_x - m_extent, m_y - m_extent, 2*m_extent, 2*m_extent);
            }
        }

        public bool isCollision(int x, int y, int z = -1)
        {
            if ((z >= 0) && (m_z != z))
            {
                return false;
            }
            return (inBorder(x, y) && inShape(x, y));
        }

        public bool isCollision(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial, int z = -1)
        {
            if ((z >= 0) && (m_z != z))
            {
                return false;
            }
            if ((w == 0) && (h == 0))
            {
                return (inBorder(x, y) && inShape(x, y));
            }
            if (overlapBorder(x, y, w, h, overlap))
            {
                return true;
            }
            else
            {
                if (overlap == OverlapType.Full)
                {
                    return false;
                }
                else
                {
                    return inShape(x, y, w, h, overlap);
                }
            }
        }

        public virtual bool inShape(int x, int y)
        {
            return false;
        }

        public virtual bool inShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            return false;
        }

        public bool inBorder(int x, int y)
        {
            int diff_x = x - m_x;
            int diff_y = y - m_y;
            if ((diff_x < m_borderPoint[(int)BorderName.Left]) || (diff_x > m_borderPoint[(int)BorderName.Right])
                || (diff_y < m_borderPoint[(int)BorderName.Bottom]) || (diff_y > m_borderPoint[(int)BorderName.Top]))
            {
                return false;
            }
            return true;
        }

        public bool overlapBorder(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if ((x + w < m_x + m_borderPoint[(int)BorderName.Left]) || (x > m_x + m_borderPoint[(int)BorderName.Right])
                    || (y + h < m_y + m_borderPoint[(int)BorderName.Bottom]) || (y > m_y + m_borderPoint[(int)BorderName.Top]))
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
                if ((x <= m_x + m_borderPoint[(int)BorderName.Left]) && (x + w >= m_x + m_borderPoint[(int)BorderName.Right])
                   && (y <= m_y + m_borderPoint[(int)BorderName.Bottom]) && (y + h >= m_y + m_borderPoint[(int)BorderName.Top]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual void setBorder(int left, int right, int bottom, int top)
        {
            m_borderPoint[(int)BorderName.Left] = left;
            m_borderPoint[(int)BorderName.Right] = right;
            m_borderPoint[(int)BorderName.Bottom] = bottom;
            m_borderPoint[(int)BorderName.Top] = top;
        }

        public int[] getBorder()
        {
            return m_borderPoint;
        }

        public Point getPos()
        {
            return new Point(m_x, m_y);
        }

        public bool isSelected()
        {
            return m_selected;
        }

        public void select()
        {
            m_selected = true;
            updateBorder();
        }

        public void deselect()
        {
            m_selected = false;
            updateBorder();
        }

        protected virtual void updateBorder()
        {
            if (m_selected)
            {
                setBorder(-m_extent, m_extent, m_extent, -m_extent);
            }
            else
            {
                setBorder(0, 0, 0, 0);
            }
        }

        protected int m_id;
        protected int m_x;
        protected int m_y;
        protected int m_z;
        protected int m_typeId;
        protected int m_extent;
        protected int[] m_borderPoint;
        protected bool m_selected;
        protected Pen m_selectionPen;
    }
}
