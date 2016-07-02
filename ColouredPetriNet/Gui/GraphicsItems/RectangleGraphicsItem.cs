using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
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

        public RectangleGraphicsItem() : this(-1, -1)
        {
        }

        public RectangleGraphicsItem(int id, int typeId, int w = 10, int h = 10, int x = 0, int y = 0, int z = 0)
            : base (id, typeId, x, y, z)
        {
            _width = w;
            _height = h;
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
            graphics.FillRectangle(_fillBrush, _x - _width/2, _y - _height/2, _width, _height);
            graphics.DrawRectangle(_borderPen, _x - _width/2, _y - _height/2, _width, _height);
            if (_selected)
            {
                graphics.DrawRectangle(_selectionPen, _x - _width/2 - _extent, _y - _height/2 - _extent,
                    _width + 2*_extent, _height + 2*_extent);
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
