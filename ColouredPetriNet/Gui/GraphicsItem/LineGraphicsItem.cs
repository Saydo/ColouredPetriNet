using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public interface ILineGraphicsItem : IGraphicsItem
    {
        Point point1
        {
            get;
            set;
        }
        Point point2
        {
            get;
            set;
        }
        Pen pen
        {
            get;
            set;
        }
    }

    public class LineGraphicsItem : GraphicsItem, ILineGraphicsItem
    {
        public LineGraphicsItem() : this(-1, -1, new Point(), new Point())
        {
        }

        public LineGraphicsItem(int id, int typeId, Point p1, Point p2, int z = 0)
            : base(id, typeId, 0, 0, z)
        {
            m_point1 = new Point();
            m_point2 = new Point();
            if ((!ReferenceEquals(p1, null)) && (!ReferenceEquals(p2, null)))
            {
                m_x = (p2.X + p1.X) / 2;
                m_y = (p2.Y + p1.Y) / 2;
                m_point1.X = p1.X;
                m_point1.Y = p1.Y;
                m_point2.X = p2.X;
                m_point2.Y = p2.Y;
            }
            m_extentPoint = new Point[4];
            for (int i = 0; i < m_extentPoint.Length; ++i)
            {
                m_extentPoint[i] = new Point();
            }
            updateBorder();
        }

        public Point point1
        {
            get { return m_point1; }
            set
            {
                if ((value.X >= 0) && (value.Y >= 0))
                {
                    m_point1 = value;
                    updateBorder();
                }
            }
        }

        public Point point2
        {
            get { return m_point2; }
            set
            {
                if ((value.X >= 0) && (value.Y >= 0))
                {
                    m_point2 = value;
                    updateBorder();
                }
            }
        }

        public Pen pen
        {
            get { return m_pen; }
            set { m_pen = value; }
        }

        public override void draw(Graphics graphics)
        {
            graphics.DrawLine(m_pen, m_point1, m_point2);
            if (m_selected)
            {
                graphics.DrawPolygon(m_selectionPen, m_extentPoint);
            }
        }

        public override bool inShape(int x, int y)
        {
            double[] k = new double[4];
            double[] b = new double[4];
            LinearAlgebra.getEquation(m_extentPoint[0], m_extentPoint[1], out k[0], out b[0]);
            LinearAlgebra.getEquation(m_extentPoint[1], m_extentPoint[2], out k[1], out b[1]);
            LinearAlgebra.getEquation(m_extentPoint[2], m_extentPoint[3], out k[2], out b[2]);
            LinearAlgebra.getEquation(m_extentPoint[3], m_extentPoint[0], out k[3], out b[3]);
            if ((LinearAlgebra.inLineByY(x, y, k[0], b[0]) <= 0) && (LinearAlgebra.inLineByX(x, y, k[1], b[1]) <= 0)
               && (LinearAlgebra.inLineByY(x, y, k[2], b[2]) >= 0) && (LinearAlgebra.inLineByX(x, y, k[3], b[3]) >= 0))
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
            double[] k = new double[4];
            double[] b = new double[4];
            LinearAlgebra.getEquation(m_extentPoint[0], m_extentPoint[1], out k[0], out b[0]);
            LinearAlgebra.getEquation(m_extentPoint[1], m_extentPoint[2], out k[1], out b[1]);
            LinearAlgebra.getEquation(m_extentPoint[2], m_extentPoint[3], out k[2], out b[2]);
            LinearAlgebra.getEquation(m_extentPoint[3], m_extentPoint[0], out k[3], out b[3]);
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
            m_extentPoint = LinearAlgebra.getLineBorder(m_point1, m_point2, (m_selected ? m_extent : 1));
            base.setBorder(LinearAlgebra.MinX(m_extentPoint), LinearAlgebra.MaxX(m_extentPoint),
                LinearAlgebra.MinY(m_extentPoint), LinearAlgebra.MaxY(m_extentPoint));
        }

        protected Point m_point1;
        protected Point m_point2;
        protected Pen m_pen;
        protected Point[] m_extentPoint;
    }
}
