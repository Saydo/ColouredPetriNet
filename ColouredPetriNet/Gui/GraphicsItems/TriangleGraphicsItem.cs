using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class TriangleGraphicsItem : PolygonGraphicsItem
    {
        public TriangleGraphicsItem() : this(-1, -1)
        {
        }

        public TriangleGraphicsItem(int id, int typeId, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, 3, x, y, z)
        {
            UpdateBorder();
        }

        public override bool InShape(int x, int y)
        {
            Point p1, p2, p3;
            double k1, k2, k3, b1, b2, b3;
            DefinePointPosition((_selected ? _extentPoints : _points), out p1, out p2, out p3);
            LinearAlgebra.GetEquation(p1, p2, out k1, out b1);
            LinearAlgebra.GetEquation(p1, p3, out k2, out b2);
            LinearAlgebra.GetEquation(p2, p3, out k3, out b3);
            if ((LinearAlgebra.InLineByY(x, y, k1, b1) <= 0) && (LinearAlgebra.InLineByY(x, y, k2, b2) >= 0))
            {
                if (p3.X >= p2.X)
                {
                    if (LinearAlgebra.InLineByY(x, y, k3, b3) <= 0) return true;
                }
                else
                {
                    if (LinearAlgebra.InLineByY(x, y, k3, b3) >= 0) return true;
                }
            }
            return false;
        }

        public override bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if ((x + w < _borderPoint[(int)BorderSide.Left]) || (x > _borderPoint[(int)BorderSide.Right])
                   || (y + h < _borderPoint[(int)BorderSide.Bottom]) || (y > _borderPoint[(int)BorderSide.Top]))
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
                DefinePointPosition((_selected ? _extentPoints : _points), out p1, out p2, out p3);
                LinearAlgebra.GetEquation(p1, p2, out k1, out b1);
                LinearAlgebra.GetEquation(p2, p3, out k2, out b2);
                LinearAlgebra.GetEquation(p1, p3, out k3, out b3);
                if (p1.Y > p2.Y)
                {
                    if ((LinearAlgebra.InLineByY(x, y, k3, b3) >= 0)
                        && (LinearAlgebra.InLineByY(x + w, y, k2, b2) >= 0)
                        && (LinearAlgebra.InLineByY(x + w, y + h, k1, b1) <= 0))
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
                        if ((LinearAlgebra.InLineByY(x, y + h, k1, b1) <= 0)
                            && (LinearAlgebra.InLineByY(x + w, y, k2, b2) >= 0)
                            && (LinearAlgebra.InLineByY(x, y, k3, b3) >= 0))
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
                        if ((LinearAlgebra.InLineByY(x, y + h, k1, b1) <= 0)
                            && (LinearAlgebra.InLineByY(x + w, y + h, k2, b2) <= 0)
                            && (LinearAlgebra.InLineByY(x + w, y, k3, b3) >= 0))
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

        protected override void UpdateBorder()
        {
            if (_selected)
            {
                for (int i = 0; i < 3; ++i)
                {
                    _extentPoints[i].X = _points[i].X;
                    _extentPoints[i].Y = _points[i].Y;
                }
                LinearAlgebra.ExpandTriangle(_extentPoints[0], _extentPoints[1], _extentPoints[2], _extent);
                base.SetBorder(LinearAlgebra.MinX(_extentPoints), LinearAlgebra.MaxX(_extentPoints),
                    LinearAlgebra.MinY(_extentPoints), LinearAlgebra.MaxY(_extentPoints));
            }
            else
            {
                base.SetBorder(LinearAlgebra.MinX(_points), LinearAlgebra.MaxX(_points),
                    LinearAlgebra.MinY(_points), LinearAlgebra.MaxY(_points));
            }
        }

        private void DefinePointPosition(Point[] points, out Point p1, out Point p2, out Point p3)
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
