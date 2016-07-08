namespace ColouredPetriNet.Gui.Style
{
    public class ShapeStyle
    {
        public System.Drawing.Brush FillBrush { get; set; }
        public System.Drawing.Pen BorderPen { get; set; }
    }

    public class RoundShapeStyle : ShapeStyle
    {
        private int _radius;

        public int Radius
        {
            get { return _radius; }
            set { _radius = (value < 0 ? -value : value); }
        }
    }

    public class RectangleShapeStyle : ShapeStyle
    {
        private int _width;
        private int _height;

        public int Width
        {
            get { return _width; }
            set { _width = (value < 0 ? -value : value); }
        }

        public int Height
        {
            get { return _height; }
            set { _height = (value < 0 ? -value : value); }
        }
    }

    public class TriangleShapeStyle : ShapeStyle
    {
        private int _side;

        public int Side
        {
            get { return _side; }
            set { _side = (value < 0 ? -value : value); }
        }
    }

    public class ImageShapeStyle : RectangleShapeStyle
    {
        public string ImageName { get; set; }
    }

    public struct ColouredPetriNetStyle
    {
        public RectangleShapeStyle RhombMarker;
        public RoundShapeStyle RoundMarker;
        public TriangleShapeStyle TriangleMarker;
        public RectangleShapeStyle RectangleTransition;
        public RectangleShapeStyle RhombTransition;
        public RoundShapeStyle RoundState;
        public ImageShapeStyle ImageState;
        public GraphicsItems.OverlapType SelectionMode;
        public System.Drawing.Pen SelectionPen;
    }
}