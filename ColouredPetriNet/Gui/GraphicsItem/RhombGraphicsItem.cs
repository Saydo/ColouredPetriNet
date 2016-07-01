using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public class RhombGraphicsItem : RectangleGraphicsItem
    {
        enum PointPos { Top, Bottom, Left, Right };

        public RhombGraphicsItem() : this(-1, -1)
        {
        }

        public RhombGraphicsItem(int id, int typeId, int w = 10, int h = 10, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, w, h, x, y, z)
        {
            m_points = new Point[4];
            m_extentPoints = new Point[4];
            for (int i = 0; i < 4; ++i)
            {
                m_points[i] = new Point();
                m_extentPoints[i] = new Point();
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

        public override bool inShape(int x, int y)
        {
            double[] k = { 0.0, 0.0, 0.0, 0.0 };
            double[] b = { 0.0, 0.0, 0.0, 0.0 };
            if (m_selected)
            {
                LinearAlgebra.getEquation(m_extentPoints[0], m_extentPoints[1], out k[0], out b[0]);
                LinearAlgebra.getEquation(m_extentPoints[1], m_extentPoints[2], out k[1], out b[1]);
                LinearAlgebra.getEquation(m_extentPoints[2], m_extentPoints[3], out k[2], out b[2]);
                LinearAlgebra.getEquation(m_extentPoints[3], m_extentPoints[0], out k[3], out b[3]);
            }
            else
            {
                LinearAlgebra.getEquation(m_points[0], m_points[1], out k[0], out b[0]);
                LinearAlgebra.getEquation(m_points[1], m_points[2], out k[1], out b[1]);
                LinearAlgebra.getEquation(m_points[2], m_points[3], out k[2], out b[2]);
                LinearAlgebra.getEquation(m_points[3], m_points[0], out k[3], out b[3]);
            }
            if ((LinearAlgebra.inLineByY(x, y, k[0], b[0]) <= 0) && (LinearAlgebra.inLineByY(x, y, k[1], b[1]) <= 0)
                && (LinearAlgebra.inLineByY(x, y, k[2], b[2]) >= 0) && (LinearAlgebra.inLineByY(x, y, k[3], b[3]) >= 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool inShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            double[] k = { 0.0, 0.0, 0.0, 0.0 };
            double[] b = { 0.0, 0.0, 0.0, 0.0 };
            if (m_selected)
            {
                LinearAlgebra.getEquation(m_extentPoints[0], m_extentPoints[1], out k[0], out b[0]);
                LinearAlgebra.getEquation(m_extentPoints[1], m_extentPoints[2], out k[1], out b[1]);
                LinearAlgebra.getEquation(m_extentPoints[2], m_extentPoints[3], out k[2], out b[2]);
                LinearAlgebra.getEquation(m_extentPoints[3], m_extentPoints[0], out k[3], out b[3]);
            }
            else
            {
                LinearAlgebra.getEquation(m_points[0], m_points[1], out k[0], out b[0]);
                LinearAlgebra.getEquation(m_points[1], m_points[2], out k[1], out b[1]);
                LinearAlgebra.getEquation(m_points[2], m_points[3], out k[2], out b[2]);
                LinearAlgebra.getEquation(m_points[3], m_points[0], out k[3], out b[3]);
            }
            if (overlap == OverlapType.Partial)
            {
                if ((LinearAlgebra.inLineByY(x + w, y, k[0], b[0]) > 0) || (LinearAlgebra.inLineByY(x, y, k[1], b[1]) > 0)
                    || (LinearAlgebra.inLineByY(x, y + h, k[2], b[2]) < 0)
                    || (LinearAlgebra.inLineByY(x + w, y + h, k[3], b[3]) < 0))
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
                if ((LinearAlgebra.inLineByY(x, y + h, k[0], b[0]) <= 0)
                    && (LinearAlgebra.inLineByY(x + w, y + h, k[1], b[1]) <= 0)
                    && (LinearAlgebra.inLineByY(x + w, y, k[2], b[2]) >= 0)
                    && (LinearAlgebra.inLineByY(x, y, k[3], b[3]) >= 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            updatePointPosition(half_width, half_height);
        }

        protected void updatePointPosition(int half_width, int half_height)
        {
            m_points[(int)PointPos.Top].X = m_x;
            m_points[(int)PointPos.Top].Y = m_y + half_height;
            m_points[(int)PointPos.Bottom].X = m_x;
            m_points[(int)PointPos.Bottom].Y = m_y - half_height;
            m_points[(int)PointPos.Left].X = m_x - half_width;
            m_points[(int)PointPos.Left].Y = m_y;
            m_points[(int)PointPos.Right].X = m_x + half_width;
            m_points[(int)PointPos.Right].Y = m_y;
            for (int i = 0; i < 4; ++i)
            {
                m_extentPoints[i].X = m_points[i].X;
                m_extentPoints[i].Y = m_points[i].Y;
            }
            if (m_selected)
            {
                m_points[(int)PointPos.Top].Y -= m_extent;
                m_points[(int)PointPos.Bottom].Y += m_extent;
                m_points[(int)PointPos.Left].X += m_extent;
                m_points[(int)PointPos.Right].X -= m_extent;
            }
        }

        protected Point[] m_points;
        protected Point[] m_extentPoints;
    }
}
