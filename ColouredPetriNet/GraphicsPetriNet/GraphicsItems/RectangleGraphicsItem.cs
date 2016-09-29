using System.Drawing;

namespace ColouredPetriNet.GraphicsPetriNet.GraphicsItems
{
    public class RectangleGraphicsItem : ColourGraphicsItem
    {
        protected int _width;
        protected int _height;

        public int Width
        {
            get { return _width; }
            set
            {
                _width = (value < 0 ? 0 : value);
                UpdateBorder();
            }
        }
        public int Height
        {
            get { return _height; }
            set
            {
                _height = (value < 0 ? 0 : value);
                UpdateBorder();
            }
        }

        public RectangleGraphicsItem() : this(-1, -1, new Point(0, 0))
        {
        }

        public RectangleGraphicsItem(int id, int typeId, int w = 10, int h = 10, int z = 0)
            : this(id, typeId, new Point(0, 0), w, h, z)
        {
        }

        public RectangleGraphicsItem(int id, int typeId, Point center, int w = 10, int h = 10, int z = 0)
            : base (id, typeId, center, z)
        {
            _width = w;
            _height = h;
            int half_width = (_width - (int)_borderPen.Width) / 2;
            int half_height = (_height - (int)_borderPen.Width) / 2;
            base.SetBorder(-half_width, half_width, -half_height, half_height);
        }

        public void SetSize(int w, int h)
        {
            _width = w;
            _height = h;
            UpdateBorder();
        }

        public override void SetBorder(int left, int right, int bottom, int top)
        {
            base.SetBorder(left, right, bottom, top);
            _width = right - left - (int)_borderPen.Width;
            _height = top - bottom - (int)_borderPen.Width;
            if (_selected)
            {
                _width -= 2 * _extent;
                _height -= 2 * _extent;
            }
        }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(_fillBrush, _center.X - _width/2, _center.Y - _height/2, _width, _height);
            graphics.DrawRectangle(_borderPen, _center.X - _width/2, _center.Y - _height/2, _width, _height);
            if (_selected)
            {
                graphics.DrawRectangle(_selectionPen, _center.X - _width/2 - _extent,
                    _center.Y - _height/2 - _extent, _width + 2*_extent, _height + 2*_extent);
            }
        }

        public override bool InShape(int x, int y)
        {
            int halfWidth = _width / 2 + (int)_borderPen.Width;
            int halfHeight = _height / 2 + (int)_borderPen.Width;
            if (_selected)
            {
                halfWidth += _extent;
                halfHeight += _extent;
            }
            if ((x < _center.X - halfWidth) || (x > _center.X + halfWidth)
                || (y < _center.Y - halfHeight) || (y > _center.Y + halfHeight))
            {
                return false;
            }
            return true;
        }

        public override bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            int halfWidth = _width / 2 + (int)_borderPen.Width;
            int halfHeight = _height / 2 + (int)_borderPen.Width;
            if (_selected)
            {
                halfWidth += _extent;
                halfHeight += _extent;
            }
            if (overlap == OverlapType.Partial)
            {
                if ((x + w < _center.X - halfWidth) || (x > _center.X + halfWidth)
                    || (y + h < _center.Y - halfHeight) || (y > _center.Y + halfHeight))
                {
                    return false;
                }
                return true;
            }
            else
            {
                if ((x <= _center.X - halfWidth) && (x + w >= _center.X + halfWidth)
                    && (y <= _center.Y - halfHeight) && (y + h >= _center.Y + halfHeight))
                {
                    return true;
                }
                return false;
            }
        }

        protected override void UpdateBorder()
        {
            int half_width = (_width - (int)_borderPen.Width) / 2;
            int half_height = (_height - (int)_borderPen.Width) / 2;
            if (_selected)
            {
                half_width += _extent;
                half_height += _extent;
            }
            base.SetBorder(-half_width, half_width, -half_height, half_height);
        }
    }
}
