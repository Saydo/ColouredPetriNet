using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class RhombGraphicsItem : RectangleGraphicsItem
    {
        enum PointPos { Top, Bottom, Left, Right };

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
            double[] k = { 0.0, 0.0, 0.0, 0.0 };
            double[] b = { 0.0, 0.0, 0.0, 0.0 };
            if (_selected)
            {
                LinearAlgebra.GetEquation(_extentPoints[0], _extentPoints[1], out k[0], out b[0]);
                LinearAlgebra.GetEquation(_extentPoints[1], _extentPoints[2], out k[1], out b[1]);
                LinearAlgebra.GetEquation(_extentPoints[2], _extentPoints[3], out k[2], out b[2]);
                LinearAlgebra.GetEquation(_extentPoints[3], _extentPoints[0], out k[3], out b[3]);
            }
            else
            {
                LinearAlgebra.GetEquation(_points[0], _points[1], out k[0], out b[0]);
                LinearAlgebra.GetEquation(_points[1], _points[2], out k[1], out b[1]);
                LinearAlgebra.GetEquation(_points[2], _points[3], out k[2], out b[2]);
                LinearAlgebra.GetEquation(_points[3], _points[0], out k[3], out b[3]);
            }
            if ((LinearAlgebra.InLineByY(x, y, k[0], b[0]) <= 0) && (LinearAlgebra.InLineByY(x, y, k[1], b[1]) <= 0)
                && (LinearAlgebra.InLineByY(x, y, k[2], b[2]) >= 0) && (LinearAlgebra.InLineByY(x, y, k[3], b[3]) >= 0))
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
            double[] k = { 0.0, 0.0, 0.0, 0.0 };
            double[] b = { 0.0, 0.0, 0.0, 0.0 };
            if (_selected)
            {
                LinearAlgebra.GetEquation(_extentPoints[0], _extentPoints[1], out k[0], out b[0]);
                LinearAlgebra.GetEquation(_extentPoints[1], _extentPoints[2], out k[1], out b[1]);
                LinearAlgebra.GetEquation(_extentPoints[2], _extentPoints[3], out k[2], out b[2]);
                LinearAlgebra.GetEquation(_extentPoints[3], _extentPoints[0], out k[3], out b[3]);
            }
            else
            {
                LinearAlgebra.GetEquation(_points[0], _points[1], out k[0], out b[0]);
                LinearAlgebra.GetEquation(_points[1], _points[2], out k[1], out b[1]);
                LinearAlgebra.GetEquation(_points[2], _points[3], out k[2], out b[2]);
                LinearAlgebra.GetEquation(_points[3], _points[0], out k[3], out b[3]);
            }
            if (overlap == OverlapType.Partial)
            {
                if ((LinearAlgebra.InLineByY(x + w, y, k[0], b[0]) > 0) || (LinearAlgebra.InLineByY(x, y, k[1], b[1]) > 0)
                    || (LinearAlgebra.InLineByY(x, y + h, k[2], b[2]) < 0)
                    || (LinearAlgebra.InLineByY(x + w, y + h, k[3], b[3]) < 0))
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
                if ((LinearAlgebra.InLineByY(x, y + h, k[0], b[0]) <= 0)
                    && (LinearAlgebra.InLineByY(x + w, y + h, k[1], b[1]) <= 0)
                    && (LinearAlgebra.InLineByY(x + w, y, k[2], b[2]) >= 0)
                    && (LinearAlgebra.InLineByY(x, y, k[3], b[3]) >= 0))
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
            int halfWidth = (_width - (int)_borderPen.Width) / 2;
            int halfHeight = (_height - (int)_borderPen.Width) / 2;
            if (_selected)
            {
                halfWidth += _extent;
                halfHeight += _extent;
            }
            base.SetBorder(-halfWidth, halfWidth, -halfHeight, halfHeight);
            UpdatePointPosition(halfWidth, halfHeight);
        }

        protected void UpdatePointPosition(int halfWidth, int halfHeight)
        {
            _points[(int)PointPos.Top].X = _x;
            _points[(int)PointPos.Top].Y = _y + halfHeight;
            _points[(int)PointPos.Bottom].X = _x;
            _points[(int)PointPos.Bottom].Y = _y - halfHeight;
            _points[(int)PointPos.Left].X = _x - halfWidth;
            _points[(int)PointPos.Left].Y = _y;
            _points[(int)PointPos.Right].X = _x + halfWidth;
            _points[(int)PointPos.Right].Y = _y;
            for (int i = 0; i < 4; ++i)
            {
                _extentPoints[i].X = _points[i].X;
                _extentPoints[i].Y = _points[i].Y;
            }
            if (_selected)
            {
                _points[(int)PointPos.Top].Y -= _extent;
                _points[(int)PointPos.Bottom].Y += _extent;
                _points[(int)PointPos.Left].X += _extent;
                _points[(int)PointPos.Right].X -= _extent;
            }
        }
    }
}
