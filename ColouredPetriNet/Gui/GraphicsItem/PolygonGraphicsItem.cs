using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public class PolygonGraphicsItem : ColourGraphicsItem
    {
        public PolygonGraphicsItem() : this(-1, -1)
        {
        }

        public PolygonGraphicsItem(int id, int typeId, int count = 4, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, x, y, z)
        {
            m_points = new Point[count];
            m_extentPoints = new Point[count];
            for (int i = 0; i < count; ++i)
            {
                m_points[i] = new Point();
                m_extentPoints[i] = new Point();
            }
        }

        public Point getPoint(int index)
        {
            if ((index < 0) || (index >= m_points.Length))
            {
                return default(Point);
            }
            else
            {
                return m_points[index];
            }
        }

        public void setPoint(int index, Point p)
        {
            if ((index >= 0) && (index < m_points.Length))
            {
                m_extentPoints[index].X += p.X - m_points[index].X;
                m_extentPoints[index].Y += p.Y - m_points[index].Y;
                m_points[index] = p;
                
            }
        }

        public override void draw(Graphics graphics)
        {
            graphics.FillPolygon(m_fillBrush, m_points);
            graphics.DrawPolygon(m_borderPen, m_points);
            if (m_selected)
            {
                graphics.DrawPolygon(m_selectionPen, m_extentPoints);
            }
        }

        protected Point[] m_points;
        protected Point[] m_extentPoints;
    }
}
