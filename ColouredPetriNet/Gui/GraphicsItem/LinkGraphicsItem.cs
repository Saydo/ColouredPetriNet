using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public class LinkGraphicsItem : LineGraphicsItem
    {
        public enum Direction { FromP1toP2, FromP2toP1, Both, None };

        public LinkGraphicsItem() : this(-1, -1, new Point(), new Point())
        {
        }

        public LinkGraphicsItem(int id, int typeId, Point p1, Point p2, Direction dir = Direction.None, int z = 0)
            : base(id, typeId, p1, p2, z)
        {
            m_arrowPoints = new Point[4];
            for (int i = 0; i < m_arrowPoints.Length; ++i)
            {
                m_arrowPoints[i] = new Point();
            }
        }

        public override void draw(Graphics graphics)
        {
            graphics.DrawLine(m_pen, m_point1, m_point2);
            if ((direction == Direction.FromP1toP2) || (direction == Direction.Both))
            {
                graphics.DrawLine(m_pen, m_point1, m_arrowPoints[0]);
                graphics.DrawLine(m_pen, m_point1, m_arrowPoints[1]);
            }
            if ((direction == Direction.FromP2toP1) || (direction == Direction.Both))
            {
                graphics.DrawLine(m_pen, m_point2, m_arrowPoints[2]);
                graphics.DrawLine(m_pen, m_point2, m_arrowPoints[3]);
            }
            if (m_selected)
            {
                graphics.DrawPolygon(m_selectionPen, m_extentPoint);
            }
        }

        public Direction direction
        {
            get { return m_direction; }
            set
            {
                m_direction = value;
                updateArrowPosition();
            }
        }

        public int arrowLength
        {
            get { return m_arrowLength; }
            set
            {
                m_arrowLength = (value < 0 ? 0 : value);
                updateArrowPosition();
            }
        }

        protected override void updateBorder()
        {
            base.updateBorder();
            updateArrowPosition();
        }

        protected void updateArrowPosition()
        {
            if ((direction == Direction.FromP1toP2) || (direction == Direction.Both))
            {
                updateArrowPosition(m_point1, m_point2, out m_arrowPoints[0], out m_arrowPoints[1]);
            }
            if ((direction == Direction.FromP2toP1) || (direction == Direction.Both))
            {
                updateArrowPosition(m_point2, m_point1, out m_arrowPoints[2], out m_arrowPoints[3]);
            }
        }

        protected void updateArrowPosition(Point p1, Point p2, out Point arrow_p1, out Point arrow_p2)
        {
            Point p3 = new Point();
            p3.X = p2.X;
            p3.Y = p2.Y;
            LinearAlgebra.resizeLine(p1, p3, m_arrowLength);
            arrow_p1 = LinearAlgebra.normalToLine(p1, p3, m_extent, true);
            arrow_p2 = LinearAlgebra.normalToLine(p1, p3, m_extent, false);
        }

        protected int m_arrowLength;
        protected Direction m_direction;
        protected Point[] m_arrowPoints;
    }
}
