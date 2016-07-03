using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
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
            _direction = direction;
            _arrowPoints = new Point[4];
            for (int i = 0; i < _arrowPoints.Length; ++i)
            {
                _arrowPoints[i] = new Point();
            }
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
                graphics.DrawPolygon(_selectionPen, _extentPoint);
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
            Point p3 = new Point();
            p3.X = p2.X;
            p3.Y = p2.Y;
            LinearAlgebra.ResizeLine(p1, p3, _arrowLength);
            arrowPoint1 = LinearAlgebra.GetNormalToLine(p1, p3, _extent, true);
            arrowPoint2 = LinearAlgebra.GetNormalToLine(p1, p3, _extent, false);
        }
    }
}
