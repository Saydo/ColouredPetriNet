using System.Drawing;

namespace ColouredPetriNet.GraphicsPetriNet.GraphicsItems
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
            Point[] points = (_selected ? _extentPoints : _points);
            var pointIndices = NormalizePointPosition(points[0], points[1], points[2]);
            var eq1 = new LinearAlgebra.Equation(points[pointIndices[0]], points[pointIndices[1]]);
            var eq2 = new LinearAlgebra.Equation(points[pointIndices[1]], points[pointIndices[2]]);
            var eq3 = new LinearAlgebra.Equation(points[pointIndices[2]], points[pointIndices[0]]);
            if ((eq2.InLineByX(x, y) <= 0) && (eq3.InLineByY(x, y) >= 0)
                && (((points[pointIndices[0]].X != points[pointIndices[1]].X)
                    && (eq1.InLineByY(x, y) <= 0))
                  || ((points[pointIndices[0]].X == points[pointIndices[1]].X)
                    && (eq1.InLineByX(x, y) >= 0))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            Point[] points = (_selected ? _extentPoints : _points);
            var pointIndices = NormalizePointPosition(points[0], points[1], points[2]);
            var eq1 = new LinearAlgebra.Equation(points[pointIndices[0]], points[pointIndices[1]]);
            var eq2 = new LinearAlgebra.Equation(points[pointIndices[1]], points[pointIndices[2]]);
            var eq3 = new LinearAlgebra.Equation(points[pointIndices[2]], points[pointIndices[0]]);
            if (overlap == OverlapType.Partial)
            {
                if (points[pointIndices[0]].Y == points[pointIndices[1]].Y)
                {
                    if (eq1.InLineByY(x, y) > 0)
                    {
                        return false;
                    }
                }
                else if (points[pointIndices[0]].X == points[pointIndices[1]].X)
                {
                    if (eq1.InLineByX(x + w, y) < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (eq1.InLineByY(x + w, y) > 0)
                    {
                        return false;
                    }
                }
                if (points[pointIndices[1]].Y == points[pointIndices[2]].Y)
                {
                    if (eq2.InLineByY(x, y) > 0)
                    {
                        return false;
                    }
                }
                else if (points[pointIndices[1]].X > points[pointIndices[2]].X)
                {
                    if (eq2.InLineByX(x, y + h) > 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (eq2.InLineByX(x, y) > 0)
                    {
                        return false;
                    }
                }
                if (points[pointIndices[0]].Y >= points[pointIndices[2]].Y)
                {
                    if (eq3.InLineByY(x + w, y + h) < 0)
                    {
                        return false;
                    }
                }
                else
                {
                    if (eq3.InLineByY(x, y + h) < 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                if (eq3.InLineByY(x + w, y) < 0)
                {
                    return false;
                }
                if (points[pointIndices[0]].X == points[pointIndices[1]].X)
                {
                    if (eq1.InLineByX(x, y) < 0)
                        return false;
                }
                else
                {
                    if (eq1.InLineByY(x, y) < 0)
                        return false;
                }
                if (points[pointIndices[1]].Y == points[pointIndices[2]].Y)
                {
                    if (eq2.InLineByY(x, y + h) > 0)
                        return false;
                }
                else
                {
                    if ((eq2.InLineByX(x + w, y + h) > 0) && (eq2.InLineByX(x + w, y) > 0))
                        return false;
                }
                return true;
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
                LinearAlgebra.Algorithm.ExpandTriangle(ref _extentPoints[0], ref _extentPoints[1],
                    ref _extentPoints[2], _extent);
            }
            base.SetBorder(LinearAlgebra.Algorithm.MinX(_extentPoints) - _center.X,
                LinearAlgebra.Algorithm.MaxX(_extentPoints) - _center.X,
                LinearAlgebra.Algorithm.MinY(_extentPoints) - _center.Y,
                LinearAlgebra.Algorithm.MaxY(_extentPoints) - _center.Y);
        }

        private int[] NormalizePointPosition(Point p1, Point p2, Point p3)
        {
            int[] indices = new int[3] { -1, -1, -1 };
            if ((p1.X <= p2.X) && (p1.X <= p3.X))
            {
                if (p1.X == p2.X)
                {
                    if (p1.Y < p2.Y)
                    {
                        indices[0] = 0;
                        indices[1] = 1;
                    }
                    else
                    {
                        indices[0] = 1;
                        indices[1] = 0;
                    }
                    indices[2] = 2;
                }
                else
                {
                    indices[0] = 0;
                }
            }
            else if ((p2.X < p1.X) && (p2.X <= p3.X))
            {
                if (p2.X == p3.X)
                {
                    if (p2.Y < p3.Y)
                    {
                        indices[0] = 1;
                        indices[1] = 2;
                    }
                    else
                    {
                        indices[0] = 2;
                        indices[1] = 1;
                    }
                    indices[2] = 0;
                }
                else
                {
                    indices[0] = 1;
                }
            }
            else
            {
                indices[0] = 2;
            }
            if (indices[1] >= 0)
                return indices;
            if (indices[0] == 0)
            {
                if (p2.Y >= p3.Y)
                {
                    indices[1] = 1;
                    indices[2] = 2;
                }
                else
                {
                    indices[1] = 2;
                    indices[2] = 1;
                }
            }
            else if (indices[0] == 1)
            {
                if (p1.Y >= p3.Y)
                {
                    indices[1] = 0;
                    indices[2] = 2;
                }
                else
                {
                    indices[1] = 2;
                    indices[2] = 0;
                }
            }
            else
            {
                if (p1.Y >= p2.Y)
                {
                    indices[1] = 0;
                    indices[2] = 1;
                }
                else
                {
                    indices[1] = 1;
                    indices[2] = 0;
                }
            }
            return indices;
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
    }
}
