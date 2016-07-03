using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
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

        public RoundGraphicsItem(int id, int typeId, int r = 10, int x = 0, int y = 0, int z = 0)
            : base(id, typeId, x, y, z)
        {
            Radius = r;
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(_fillBrush, _x - _radius, _y - _radius, 2 * _radius, 2 * _radius);
            graphics.DrawEllipse(_borderPen, _x - _radius, _y - _radius, 2 * _radius, 2 * _radius);
            if (_selected)
            {
                int r = _radius + _extent;
                graphics.DrawEllipse(_selectionPen, _x - r, _y - r, 2*r, 2*r);
            }
        }

        public override bool InShape(int x, int y)
        {
            int r = _radius + (_selected ? _extent : 0);
            return ((x - _x) * (x - _x) + (y - _y) * (y - _y) <= r * r);
        }

        public override bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if (((y > _y) && (x > _x) && (!InShape(x, y)))
                    || ((y + h < _y) && (x > _x) && (!InShape(x, y + h)))
                    || ((y > _y) && (x + w < _x) && (!InShape(x + w, y)))
                    || ((y + h < _y) && (x + w < _x) && (!InShape(x + w, y + h))))
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
                if ((x < _x) && (y < _y) && (x + w > _x) && (y + h > _y) && InShape(x, y)
                    && InShape(x, y + h) && InShape(x + w, y + h) && InShape(x + w, y))
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