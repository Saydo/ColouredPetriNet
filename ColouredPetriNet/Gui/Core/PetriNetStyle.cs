using System;
using System.Drawing;
using System.Collections.Generic;
using ColouredPetriNet.GraphicsPetriNet.GraphicsItems;

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

        public ImageShapeStyle(string imageName, int width, int height) : base(width, height)
        {
            ImageName = imageName;
        }

        public ImageShapeStyle(string imageName, int width, int height, Brush fillBrush, Pen borderPen)
            : base(width, height, fillBrush, borderPen)
        {
            ImageName = imageName;
        }
    }

    public enum PetriNetField
    {
        RoundState = 0, ImageState, RectangleTransition, RhombTransition,
        RoundMarker, RhombMarker, TriangleMarker
    };

    public struct PetriNetItemTypeStyle
    {
        public int Type;
        public ShapeStyle Style;

        public PetriNetItemTypeStyle(int type, ShapeStyle style)
        {
            Type = type;
            Style = style;
        }
    }

    public class ColouredPetriNetStyle
    {
        public OverlapType SelectionMode;
        public Pen SelectionPen;
        public Pen LinePen;
        public List<PetriNetItemTypeStyle> Items;

        public ColouredPetriNetStyle()
        {
            SelectionMode = OverlapType.Partial;
            SelectionPen = new Pen(Color.FromArgb(0, 0, 0));
            LinePen = new Pen(Color.FromArgb(0, 0, 0));
            Items = new List<PetriNetItemTypeStyle>();
        }

        public ShapeStyle FindItemStyle(int id)
        {
            for (int i = 0; i < Items.Count; ++i)
            {
                if (Items[i].Type == id)
                {
                    return Items[i].Style;
                }
            }
            return null;
        }
    }
}