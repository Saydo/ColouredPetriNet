using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class PolygonGraphicsItem : ColourGraphicsItem
    {
        protected Point[] _points;
        protected Point[] _extentPoints;

        public PolygonGraphicsItem() : this(-1, -1)
        {
        }

        public PolygonGraphicsItem(int id, int typeId, int count = 4, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, x, y, z)
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
    }
}
