using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public class TriangleGraphicsItem : PolygonGraphicsItem
    {
        public TriangleGraphicsItem() : this(-1, -1)
        {
        }

        public TriangleGraphicsItem(int id, int typeId, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, 3, x, y, z)
        {
            updateBorder();
        }

        public override bool inShape(int x, int y)
        {
            Point p1, p2, p3;
            double k1, k2, k3, b1, b2, b3;
            definePointPosition((m_selected ? m_extentPoints : m_points), out p1, out p2, out p3);
            LinearAlgebra.getEquation(p1, p2, out k1, out b1);
            LinearAlgebra.getEquation(p1, p3, out k2, out b2);
            LinearAlgebra.getEquation(p2, p3, out k3, out b3);
            if ((LinearAlgebra.inLineByY(x, y, k1, b1) <= 0) && (LinearAlgebra.inLineByY(x, y, k2, b2) >= 0))
            {
                if (p3.X >= p2.X)
                {
                    if (LinearAlgebra.inLineByY(x, y, k3, b3) <= 0) return true;
                }
                else
                {
                    if (LinearAlgebra.inLineByY(x, y, k3, b3) >= 0) return true;
                }
            }
            return false;
        }

        public override bool inShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if ((x + w < m_borderPoint[(int)BorderName.Left]) || (x > m_borderPoint[(int)BorderName.Right])
                   || (y + h < m_borderPoint[(int)BorderName.Bottom]) || (y > m_borderPoint[(int)BorderName.Top]))
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
                Point p1, p2, p3;
                double k1, k2, k3, b1, b2, b3;
                definePointPosition((m_selected ? m_extentPoints : m_points), out p1, out p2, out p3);
                LinearAlgebra.getEquation(p1, p2, out k1, out b1);
                LinearAlgebra.getEquation(p2, p3, out k2, out b2);
                LinearAlgebra.getEquation(p1, p3, out k3, out b3);
                if (p1.Y > p2.Y)
                {
                    if ((LinearAlgebra.inLineByY(x, y, k3, b3) >= 0)
                        && (LinearAlgebra.inLineByY(x + w, y, k2, b2) >= 0)
                        && (LinearAlgebra.inLineByY(x + w, y + h, k1, b1) <= 0))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (p1.Y > p3.Y)
                    {
                        if ((LinearAlgebra.inLineByY(x, y + h, k1, b1) <= 0)
                            && (LinearAlgebra.inLineByY(x + w, y, k2, b2) >= 0)
                            && (LinearAlgebra.inLineByY(x, y, k3, b3) >= 0))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if ((LinearAlgebra.inLineByY(x, y + h, k1, b1) <= 0)
                            && (LinearAlgebra.inLineByY(x + w, y + h, k2, b2) <= 0)
                            && (LinearAlgebra.inLineByY(x + w, y, k3, b3) >= 0))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        protected override void updateBorder()
        {
            if (m_selected)
            {
                for (int i = 0; i < 3; ++i)
                {
                    m_extentPoints[i].X = m_points[i].X;
                    m_extentPoints[i].Y = m_points[i].Y;
                }
                LinearAlgebra.expandTriangle(m_extentPoints[0], m_extentPoints[1], m_extentPoints[2], m_extent);
                base.setBorder(LinearAlgebra.MinX(m_extentPoints), LinearAlgebra.MaxX(m_extentPoints),
                    LinearAlgebra.MinY(m_extentPoints), LinearAlgebra.MaxY(m_extentPoints));
            }
            else
            {
                base.setBorder(LinearAlgebra.MinX(m_points), LinearAlgebra.MaxX(m_points),
                    LinearAlgebra.MinY(m_points), LinearAlgebra.MaxY(m_points));
            }
        }

        private void definePointPosition(Point[] points, out Point p1, out Point p2, out Point p3)
        {
            if ((points[0].X <= points[1].X) && (points[0].X <= points[2].X))
            {
                p1 = points[0];
                if (points[1].Y >= points[2].Y)
                {
                    p2 = points[1];
                    p3 = points[2];
                }
                else
                {
                    p2 = points[2];
                    p3 = points[1];
                }
            }
            else if ((points[0].X > points[1].X) && (points[1].X <= points[2].X))
            {
                p1 = points[1];
                if (points[0].Y >= points[2].Y)
                {
                    p2 = points[0];
                    p3 = points[2];
                }
                else
                {
                    p2 = points[2];
                    p3 = points[0];
                }
            }
            else
            {
                p1 = points[2];
                if (points[0].Y >= points[1].Y)
                {
                    p2 = points[0];
                    p3 = points[1];
                }
                else
                {
                    p2 = points[1];
                    p3 = points[0];
                }
            }
        }
    }
}
