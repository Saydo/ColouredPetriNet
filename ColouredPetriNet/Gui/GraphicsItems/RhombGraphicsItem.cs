using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class RhombGraphicsItem : RectangleGraphicsItem
    {
        enum PointPos { Left, Top, Right, Bottom };

        protected Point[] _points;
        protected Point[] _extentPoints;

        public RhombGraphicsItem() : this(-1, -1)
        {
        }

        public RhombGraphicsItem(int id, int typeId, int w = 10, int h = 10, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, w, h, x, y, z)
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
            _points[(int)PointPos.Top].X = _x;
            _points[(int)PointPos.Top].Y = _y + halfHeight;
            _points[(int)PointPos.Bottom].X = _x;
            _points[(int)PointPos.Bottom].Y = _y - halfHeight;
            _points[(int)PointPos.Left].X = _x - halfWidth;
            _points[(int)PointPos.Left].Y = _y;
            _points[(int)PointPos.Right].X = _x + halfWidth;
            _points[(int)PointPos.Right].Y = _y;

            _extentPoints[(int)PointPos.Top].X = _x;
            _extentPoints[(int)PointPos.Top].Y = _y + extentHalfHeight;
            _extentPoints[(int)PointPos.Bottom].X = _x;
            _extentPoints[(int)PointPos.Bottom].Y = _y - extentHalfHeight;
            _extentPoints[(int)PointPos.Left].X = _x - extentHalfWidth;
            _extentPoints[(int)PointPos.Left].Y = _y;
            _extentPoints[(int)PointPos.Right].X = _x + extentHalfWidth;
            _extentPoints[(int)PointPos.Right].Y = _y;
        }
    }
}
