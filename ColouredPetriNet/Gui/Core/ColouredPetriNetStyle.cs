﻿using System.Drawing;

namespace ColouredPetriNet.Gui.Core.Style
{
    public class ShapeStyle
    {
        public Brush FillBrush { get; set; }
        public Pen BorderPen { get; set; }

        public ShapeStyle()
        {
            FillBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
            BorderPen = new Pen(Color.FromArgb(0, 0, 0), 1.0F);
        }

        public ShapeStyle(Brush fillBrush, Pen borderPen)
        {
            FillBrush = fillBrush;
            BorderPen = borderPen;
        }
    }

    public class RoundShapeStyle : ShapeStyle
    {
        private int _radius;

        public int Radius
        {
            get { return _radius; }
            set { _radius = (value < 0 ? -value : value); }
        }

        public RoundShapeStyle(int radius = 10) : base()
        {
            Radius = radius;
        }
        
        public RoundShapeStyle(int radius, Brush fillBrush, Pen borderPen)
            : base(fillBrush, borderPen)
        {
            Radius = radius;
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

        public RectangleShapeStyle() : this(10, 10)
        {
        }

        public RectangleShapeStyle(int width, int height) : base()
        {
            _width = width;
            _height = height;
        }

        public RectangleShapeStyle(int width, int height, Brush fillBrush, Pen borderPen)
            : base(fillBrush, borderPen)
        {
            _width = width;
            _height = height;
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

        public TriangleShapeStyle(int side = 10) : base()
        {
            Side = side;
        }

        public TriangleShapeStyle(int side, Brush fillBrush, Pen borderPen) : base(fillBrush, borderPen)
        {
            Side = side;
        }
    }

    public class ImageShapeStyle : RectangleShapeStyle
    {
        public string ImageName { get; set; }

        public ImageShapeStyle(string imageName) : this(imageName, 10, 10)
        {
        }

        public ImageShapeStyle(string imageName, int width, int height) : base()
        {
            ImageName = imageName;
        }

        public ImageShapeStyle(string imageName, int width, int height, Brush fillBrush, Pen borderPen)
            : base(width, height, fillBrush, borderPen)
        {
            ImageName = imageName;
        }
    }

    public struct ColouredPetriNetStyle
    {
        public RoundShapeStyle RoundMarker;
        public RectangleShapeStyle RhombMarker;
        public TriangleShapeStyle TriangleMarker;
        public RectangleShapeStyle RectangleTransition;
        public RectangleShapeStyle RhombTransition;
        public RoundShapeStyle RoundState;
        public ImageShapeStyle ImageState;
        public GraphicsItems.OverlapType SelectionMode;
        public Pen SelectionPen;
    }
}