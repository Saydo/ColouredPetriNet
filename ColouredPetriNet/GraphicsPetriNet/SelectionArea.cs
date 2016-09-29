using System.Drawing;

namespace ColouredPetriNet.GraphicsPetriNet
{
    public enum HorizontalDirection { Left, Right };
    public enum VerticalDirection { Top, Bottom };

    public class SelectionArea
    {
        private int _x;
        private int _y;
        private int _width;
        private int _height;
        private Brush _fillBrush;
        private Pen _borderPen;
        private bool _visible;
        private HorizontalDirection _horizontalDirection;
        private VerticalDirection _verticalDirection;

        public int X
        {
            get { return _x; }
            set { _x = (value < 0 ? 0 : value); }
        }

        public int Y
        {
            get { return _y; }
            set { _y = (value < 0 ? 0 : value); }
        }

        public int Width
        {
            get { return _width; }
            set { _width = (value < 0 ? 0 : value); }
        }

        public int Height
        {
            get { return _height; }
            set { _height = (value < 0 ? 0 : value); }
        }

        public Brush FillBrush
        {
            get { return _fillBrush; }
            set
            {
                if (!ReferenceEquals(_fillBrush, null))
                {
                    _fillBrush = value;
                }
            }
        }

        public Pen BorderPen
        {
            get { return _borderPen; }
            set
            {
                if (!ReferenceEquals(_borderPen, null))
                {
                    _borderPen = value;
                }
            }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public HorizontalDirection HorizontalDirection
        {
            get { return _horizontalDirection; }
            set { _horizontalDirection = value; }
        }

        public VerticalDirection VerticalDirection
        {
            get { return _verticalDirection; }
            set { _verticalDirection = value; }
        }

        public SelectionArea() : this(0, 0, 0, 0)
        {
            _visible = false;
        }

        public SelectionArea(int x, int y, int w, int h)
        {
            _x = x;
            _y = y;
            _width = w;
            _height = h;
            _visible = true;
            _fillBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 255));
            _borderPen = new Pen(Color.FromArgb(0, 0, 255));
            _horizontalDirection = HorizontalDirection.Right;
            _verticalDirection = VerticalDirection.Top;
        }

        public void Draw(Graphics graphics)
        {
            if (_visible)
            {
                int x = (_horizontalDirection == HorizontalDirection.Left ? _x - _width : _x);
                int y = (_verticalDirection == VerticalDirection.Bottom ? _y - _height : _y);
                graphics.FillRectangle(_fillBrush, x, y, _width, _height);
                graphics.DrawRectangle(_borderPen, x, y, _width, _height);
            }
        }
    }
}
