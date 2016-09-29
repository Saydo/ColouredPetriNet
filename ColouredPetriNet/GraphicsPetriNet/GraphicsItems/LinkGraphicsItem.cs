using System.Drawing;

namespace ColouredPetriNet.GraphicsPetriNet.GraphicsItems
{
    public class LinkGraphicsItem : LineGraphicsItem
    {
        public enum LinkDirection { FromP1toP2, FromP2toP1, Both, None };

        protected int _arrowLength;
        protected LinkDirection _direction;
        protected Point[] _arrowPoints;

        public LinkDirection Direction
        {
            get { return _direction; }
            set
            {
                _direction = value;
                UpdateArrowPosition();
            }
        }

        public int ArrowLength
        {
            get { return _arrowLength; }
            set
            {
                _arrowLength = (value < 0 ? 0 : value);
                UpdateArrowPosition();
            }
        }

        public LinkGraphicsItem() : this(-1, -1, new Point(), new Point())
        {
        }

        public LinkGraphicsItem(int id, int typeId, Point p1, Point p2, LinkDirection direction = LinkDirection.None, int z = 0)
            : base(id, typeId, p1, p2, z)
        {
            _arrowLength = 5;
            _direction = direction;
            _arrowPoints = new Point[4];
            for (int i = 0; i < _arrowPoints.Length; ++i)
            {
                _arrowPoints[i] = new Point();
            }
            UpdateArrowPosition();
        }

        public override void Draw(Graphics graphics)
        {
            graphics.DrawLine(_pen, _point1, _point2);
            if ((_direction == LinkDirection.FromP1toP2) || (_direction == LinkDirection.Both))
            {
                graphics.DrawLine(_pen, _point1, _arrowPoints[0]);
                graphics.DrawLine(_pen, _point1, _arrowPoints[1]);
            }
            if ((_direction == LinkDirection.FromP2toP1) || (_direction == LinkDirection.Both))
            {
                graphics.DrawLine(_pen, _point2, _arrowPoints[2]);
                graphics.DrawLine(_pen, _point2, _arrowPoints[3]);
            }
            if (_selected)
            {
                graphics.DrawPolygon(_selectionPen, _extentPoints);
            }
        }

        public override void SetPosition(int x, int y)
        {
            int dx = x - _center.X;
            int dy = y - _center.Y;
            base.SetPosition(x, y);
            for (int i = 0; i < _arrowPoints.Length; ++i)
            {
                _arrowPoints[i].X += dx;
                _arrowPoints[i].Y += dy;
            }
        }

        public void MovePoint1(int x, int y)
        {
            _point1.X += x;
            _point1.Y += y;
            _center.X = (_point2.X + _point1.X) / 2;
            _center.Y = (_point2.Y + _point1.Y) / 2;
            UpdateBorder();
        }

        public void MovePoint2(int x, int y)
        {
            _point2.X += x;
            _point2.Y += y;
            _center.X = (_point2.X + _point1.X) / 2;
            _center.Y = (_point2.Y + _point1.Y) / 2;
            UpdateBorder();
        }

        public override void Move(int x, int y)
        {
            base.Move(x, y);
            for (int i = 0; i < _arrowPoints.Length; ++i)
            {
                _arrowPoints[i].X += x;
                _arrowPoints[i].Y += y;
            }
        }

        protected override void UpdateBorder()
        {
            base.UpdateBorder();
            UpdateArrowPosition();
        }

        protected void UpdateArrowPosition()
        {
            if ((_direction == LinkDirection.FromP1toP2) || (_direction == LinkDirection.Both))
            {
                UpdateArrowPosition(_point1, _point2, out _arrowPoints[0], out _arrowPoints[1]);
            }
            if ((_direction == LinkDirection.FromP2toP1) || (_direction == LinkDirection.Both))
            {
                UpdateArrowPosition(_point2, _point1, out _arrowPoints[2], out _arrowPoints[3]);
            }
        }

        protected void UpdateArrowPosition(Point p1, Point p2, out Point arrowPoint1, out Point arrowPoint2)
        {
            var eq1 = new LinearAlgebra.Equation(p1, p2);
            var p3 = eq1.GetPoint(p1, p2, _arrowLength);
            var eq2 = eq1.GetNormalEquation(p3);
            arrowPoint1 = eq2.GetPoint(p3, _extent);
            arrowPoint2 = eq2.GetPoint(p3, -_extent);
        }
    }
}
