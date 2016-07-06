using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class TriangleGraphicsItem : PolygonGraphicsItem
    {
        private double _innerRadius;
        private double _outerRadius;

        public double InnerRadius
        {
            get { return _innerRadius; }
            set
            {
                if (_innerRadius != value)
                {
                    double dr = value - _outerRadius;
                    _outerRadius += dr;
                    _innerRadius = value;
                    LinearAlgebra.Algorithm.ExpandTriangle(ref _points[0], ref _points[1],
                        ref _points[2], (int)dr);
                    UpdateBorder();
                }
            }
        }

        public double OuterRadius
        {
            get { return _outerRadius; }
            set
            {
                if (_outerRadius != value)
                {
                    double dr = value - _outerRadius;
                    _innerRadius += dr;
                    _outerRadius = value;
                    LinearAlgebra.Algorithm.ExpandTriangle(ref _points[0], ref _points[1],
                        ref _points[2], (int)dr);
                    UpdateBorder();
                }
            }
        }

        public TriangleGraphicsItem() : this(-1, -1, new Point(0, 0))
        {
        }

        public TriangleGraphicsItem(int id, int typeId, Point p1, Point p2, Point p3, int z = 0)
            : base(id, typeId, 3, z)
        {
            _points[0] = p1;
            _points[1] = p2;
            _points[2] = p3;
            _center = LinearAlgebra.Algorithm.GetTriangleIncenter(p1, p2, p3);
            UpdateBorder();
        }

        public TriangleGraphicsItem(int id, int typeId, Point center, int side = 10, int z = 0)
            : base(id, typeId, center, 3, z)
        {
            _points[0] = new Point();
            _points[1] = new Point();
            _points[2] = new Point();
            BuildEquilateralTriangle(side);
            UpdateBorder();
        }

        public override bool InShape(int x, int y)
        {
            Point p1, p2, p3;
            LinearAlgebra.Equation[] eq = new LinearAlgebra.Equation[3];
            DefinePointPosition((_selected ? _extentPoints : _points), out p1, out p2, out p3);
            eq[0] = new LinearAlgebra.Equation(p1, p2);
            eq[1] = new LinearAlgebra.Equation(p2, p3);
            eq[2] = new LinearAlgebra.Equation(p1, p3);
            if ((eq[0].InLineByY(x, y) <= 0) && (eq[2].InLineByY(x, y) >= 0))
            {
                if (p3.X >= p2.X)
                {
                    if (eq[1].InLineByY(x, y) <= 0) return true;
                }
                else
                {
                    if (eq[1].InLineByY(x, y) >= 0) return true;
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
                LinearAlgebra.Equation[] eq = new LinearAlgebra.Equation[3];
                DefinePointPosition((_selected ? _extentPoints : _points), out p1, out p2, out p3);
                eq[0] = new LinearAlgebra.Equation(p1, p2);
                eq[1] = new LinearAlgebra.Equation(p2, p3);
                eq[2] = new LinearAlgebra.Equation(p1, p3);
                if (p1.Y > p2.Y)
                {
                    if ((eq[2].InLineByY(x, y) >= 0) && (eq[1].InLineByY(x + w, y) >= 0)
                        && (eq[0].InLineByY(x + w, y + h) <= 0))
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
                        if ((eq[0].InLineByY(x, y + h) <= 0) && (eq[1].InLineByY(x + w, y) >= 0)
                            && (eq[2].InLineByY(x, y) >= 0))
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
                        if ((eq[0].InLineByY(x, y + h) <= 0)
                            && (eq[1].InLineByY(x + w, y + h) <= 0)
                            && (eq[2].InLineByY(x + w, y) >= 0))
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
            for (int i = 0; i < 3; ++i)
            {
                _extentPoints[i].X = _points[i].X;
                _extentPoints[i].Y = _points[i].Y;
            }
            if (_selected)
            {
                System.Console.WriteLine("UpdateBorder(1):_p[0]={0}, _p[1]={1}, _p[2]={2}", _points[0], _points[1], _points[2]);
                System.Console.WriteLine("UpdateBorder(2):_ep[0]={0}, _ep[1]={1}, _ep[2]={2}", _extentPoints[0], _extentPoints[1], _extentPoints[2]);
                LinearAlgebra.Algorithm.ExpandTriangle(ref _extentPoints[0], ref _extentPoints[1],
                    ref _extentPoints[2], _extent);
                System.Console.WriteLine("UpdateBorder(3):_ep[0]={0}, _ep[1]={1}, _ep[2]={2}", _extentPoints[0], _extentPoints[1], _extentPoints[2]);
            }
            base.SetBorder(LinearAlgebra.Algorithm.MinX(_extentPoints),
                    LinearAlgebra.Algorithm.MaxX(_extentPoints),
                    LinearAlgebra.Algorithm.MinY(_extentPoints),
                    LinearAlgebra.Algorithm.MaxY(_extentPoints));
        }

        private void BuildEquilateralTriangle(int side)
        {
            _outerRadius = side / System.Math.Sqrt(3);
            _innerRadius = _outerRadius / 2;
            int dy = (int)(_outerRadius / 2);
            int dx = (int)(System.Math.Cos(System.Math.PI / 6) * _outerRadius);
            _points[0].X = _center.X - dx;
            _points[2].X = _center.X + dx;
            _points[0].Y = _points[2].Y = _center.Y + dy;
            _points[1].X = _center.X;
            _points[1].Y = _center.Y - (int)_outerRadius;
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
