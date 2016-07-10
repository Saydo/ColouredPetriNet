using System.Drawing;

namespace ColouredPetriNet.Gui.Core.GraphicsItems
{
    public class PolygonGraphicsItem : ColourGraphicsItem
    {
        protected Point[] _points;
        protected Point[] _extentPoints;

        public PolygonGraphicsItem() : this(-1, -1, new Point(0, 0))
        {
        }

        public PolygonGraphicsItem(int id, int typeId, int count = 4, int z = 0)
            : this(id, typeId, new Point(0, 0), count, z)
        {
        }

        public PolygonGraphicsItem(int id, int typeId, Point center, int count = 4, int z = 0)
            : base(id, typeId, center, z)
        {
            _points = new Point[count];
            _extentPoints = new Point[count];
            for (int i = 0; i < count; ++i)
            {
                _points[i] = new Point();
                _extentPoints[i] = new Point();
            }
        }

        public Point GetPoint(int index)
        {
            if ((index < 0) || (index >= _points.Length))
            {
                return default(Point);
            }
            else
            {
                return _points[index];
            }
        }

        public void SetPoint(int index, Point p)
        {
            if ((index >= 0) && (index < _points.Length))
            {
                _extentPoints[index].X += p.X - _points[index].X;
                _extentPoints[index].Y += p.Y - _points[index].Y;
                _points[index] = p;
                
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

        public override void Move(int x, int y)
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
    }
}
