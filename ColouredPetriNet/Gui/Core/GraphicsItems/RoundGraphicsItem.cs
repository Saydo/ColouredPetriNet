using System.Drawing;

namespace ColouredPetriNet.Gui.Core.GraphicsItems
{
    public class RoundGraphicsItem : ColourGraphicsItem
    {
        protected int _radius;

        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = (value < 0 ? 0 : value);
                UpdateBorder();
            }
        }

        public RoundGraphicsItem() : this(-1, -1)
        {
        }

        public RoundGraphicsItem(int id, int typeId, int r = 10, int z = 0)
            : this(id, typeId, new Point(0, 0), r, z)
        {
        }

        public RoundGraphicsItem(int id, int typeId, Point center, int r = 10, int z = 0)
            : base(id, typeId, center, z)
        {
            Radius = r;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(_fillBrush, _center.X - _radius, _center.Y - _radius,
                2 * _radius, 2 * _radius);
            graphics.DrawEllipse(_borderPen, _center.X - _radius, _center.Y - _radius,
                2 * _radius, 2 * _radius);
            if (_selected)
            {
                int r = _radius + _extent;
                graphics.DrawEllipse(_selectionPen, _center.X - r, _center.Y - r, 2 * r, 2 * r);
            }
        }

        public override bool InShape(int x, int y)
        {
            int r = _radius + (_selected ? _extent : 0);
            return ((x - _center.X) * (x - _center.X) + (y - _center.Y) * (y - _center.Y) <= r * r);
        }

        public override bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if (((y > _center.Y) && (x > _center.X) && (!InShape(x, y)))
                    || ((y + h < _center.Y) && (x > _center.X) && (!InShape(x, y + h)))
                    || ((y > _center.Y) && (x + w < _center.X) && (!InShape(x + w, y)))
                    || ((y + h < _center.Y) && (x + w < _center.X) && (!InShape(x + w, y + h))))
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
                if ((x < _center.X) && (y < _center.Y) && (x + w > _center.X) && (y + h > _center.Y)
                    && InShape(x, y) && InShape(x, y + h) && InShape(x + w, y + h) && InShape(x + w, y))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public override void SetBorder(int left, int right, int bottom, int top)
        {
            base.SetBorder(left, right, bottom, top);
            _radius = (right - left - (int)_borderPen.Width) / 2 - (_selected ? _extent : 0);
        }

        protected override void UpdateBorder()
        {
            int r = _radius + (int)_borderPen.Width / 2 + (_selected ? _extent : 0);
            base.SetBorder(-r, r, -r, r);
        }
    }
}