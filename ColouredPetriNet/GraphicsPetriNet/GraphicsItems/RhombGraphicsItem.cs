using System.Drawing;

namespace ColouredPetriNet.GraphicsPetriNet.GraphicsItems
{
    public class RhombGraphicsItem : RectangleGraphicsItem
    {
        enum PointPos { Left, Top, Right, Bottom };

        protected Point[] _points;
        protected Point[] _extentPoints;

        public RhombGraphicsItem() : this(-1, -1, new Point(0, 0))
        {
        }

        public RhombGraphicsItem(int id, int typeId, int z = 0)
            : this(id, typeId, new Point(0, 0), 10, 10, z)
        {
        }

        public RhombGraphicsItem(int id, int typeId, Point center, int w = 10, int h = 10, int z = 0)
            : base(id, typeId, center, w, h, z)
        {
            _points = new Point[4];
            _extentPoints = new Point[4];
            for (int i = 0; i < 4; ++i)
            {
                _points[i] = new Point();
                _extentPoints[i] = new Point();
            }
            UpdateBorder();
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillPolygon(_fillBrush, _points);
            graphics.DrawPolygon(_borderPen, _points);
            if (_selected)
            {
                graphics.DrawPolygon(_selectionPen, _extentPoints);
            }
        }

        public override void SetPosition(int x, int y)
        {
            int dx = x - _center.X;
            int dy = y - _center.Y;
            for (int i = 0; i < _points.Length; ++i)
            {
                _points[i].X += dx;
                _points[i].Y += dy;
                _extentPoints[i].X += dx;
                _extentPoints[i].Y += dy;
            }
            _center.X = x;
            _center.Y = y;
        }

        public override void Move(int x, int y)
        {
            for (int i = 0; i < _points.Length; ++i)
            {
                _points[i].X += x;
                _points[i].Y += y;
                _extentPoints[i].X += x;
                _extentPoints[i].Y += y;
            }
            _center.X += x;
            _center.Y += y;
        }

        public override bool InShape(int x, int y)
        {
            LinearAlgebra.Equation[] eq = new LinearAlgebra.Equation[4];
            if (_selected)
            {
                eq[0] = new LinearAlgebra.Equation(_extentPoints[0], _extentPoints[1]);
                eq[1] = new LinearAlgebra.Equation(_extentPoints[1], _extentPoints[2]);
                eq[2] = new LinearAlgebra.Equation(_extentPoints[2], _extentPoints[3]);
                eq[3] = new LinearAlgebra.Equation(_extentPoints[3], _extentPoints[0]);
            }
            else
            {
                eq[0] = new LinearAlgebra.Equation(_points[0], _points[1]);
                eq[1] = new LinearAlgebra.Equation(_points[1], _points[2]);
                eq[2] = new LinearAlgebra.Equation(_points[2], _points[3]);
                eq[3] = new LinearAlgebra.Equation(_points[3], _points[0]);
            }
            if ((eq[0].InLineByY(x, y) <= 0) && (eq[1].InLineByY(x, y) <= 0)
                && (eq[2].InLineByY(x, y) >= 0) && (eq[3].InLineByY(x, y) >= 0))
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
            LinearAlgebra.Equation[] eq = new LinearAlgebra.Equation[4];
            if (_selected)
            {
                eq[0] = new LinearAlgebra.Equation(_extentPoints[0], _extentPoints[1]);
                eq[1] = new LinearAlgebra.Equation(_extentPoints[1], _extentPoints[2]);
                eq[2] = new LinearAlgebra.Equation(_extentPoints[2], _extentPoints[3]);
                eq[3] = new LinearAlgebra.Equation(_extentPoints[3], _extentPoints[0]);
            }
            else
            {
                eq[0] = new LinearAlgebra.Equation(_points[0], _points[1]);
                eq[1] = new LinearAlgebra.Equation(_points[1], _points[2]);
                eq[2] = new LinearAlgebra.Equation(_points[2], _points[3]);
                eq[3] = new LinearAlgebra.Equation(_points[3], _points[0]);
            }
            if (overlap == OverlapType.Partial)
            {
                if ((eq[0].InLineByY(x + w, y) > 0) || (eq[1].InLineByY(x, y) > 0)
                    || (eq[2].InLineByY(x, y + h) < 0) || (eq[3].InLineByY(x + w, y + h) < 0))
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
                if ((eq[0].InLineByY(x, y + h) <= 0) && (eq[1].InLineByY(x + w, y + h) <= 0)
                    && (eq[2].InLineByY(x + w, y) >= 0) && (eq[3].InLineByY(x, y) >= 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        protected override void UpdateBorder()
        {
            int halfWidth = (_width + (int)_borderPen.Width) / 2;
            int halfHeight = (_height + (int)_borderPen.Width) / 2;
            int extentHalfWidth = halfWidth;
            int extentHalfHeight = halfHeight;
            if (_selected)
            {
                if (extentHalfWidth <= extentHalfHeight)
                {
                    extentHalfHeight = (extentHalfWidth + _extent) * extentHalfHeight / extentHalfWidth;
                    extentHalfWidth += _extent;
                }
                else
                {
                    extentHalfWidth = (extentHalfHeight + _extent) * extentHalfWidth / extentHalfHeight;
                    extentHalfHeight += _extent;
                }
                base.SetBorder(-extentHalfWidth, extentHalfWidth, -extentHalfHeight, extentHalfHeight);
            }
            else
            {
                base.SetBorder(-halfWidth, halfWidth, -halfHeight, halfHeight);
            }
            UpdatePointPosition(halfWidth, halfHeight, extentHalfWidth, extentHalfHeight);
        }

        protected void UpdatePointPosition(int halfWidth, int halfHeight, int extentHalfWidth, int extentHalfHeight)
        {
            _points[(int)PointPos.Top].X = _center.X;
            _points[(int)PointPos.Top].Y = _center.Y + halfHeight;
            _points[(int)PointPos.Bottom].X = _center.X;
            _points[(int)PointPos.Bottom].Y = _center.Y - halfHeight;
            _points[(int)PointPos.Left].X = _center.X - halfWidth;
            _points[(int)PointPos.Left].Y = _center.Y;
            _points[(int)PointPos.Right].X = _center.X + halfWidth;
            _points[(int)PointPos.Right].Y = _center.Y;

            _extentPoints[(int)PointPos.Top].X = _center.X;
            _extentPoints[(int)PointPos.Top].Y = _center.Y + extentHalfHeight;
            _extentPoints[(int)PointPos.Bottom].X = _center.X;
            _extentPoints[(int)PointPos.Bottom].Y = _center.Y - extentHalfHeight;
            _extentPoints[(int)PointPos.Left].X = _center.X - extentHalfWidth;
            _extentPoints[(int)PointPos.Left].Y = _center.Y;
            _extentPoints[(int)PointPos.Right].X = _center.X + extentHalfWidth;
            _extentPoints[(int)PointPos.Right].Y = _center.Y;
        }
    }
}
