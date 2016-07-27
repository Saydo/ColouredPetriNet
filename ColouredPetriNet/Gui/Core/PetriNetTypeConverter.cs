using System.Drawing;
using ColouredPetriNet.Container.GraphicsPetriNet;
using ColouredPetriNet.Container.GraphicsPetriNet.GraphicsItems;

namespace ColouredPetriNet.Gui.Core
{
    public static class PetriNetTypeConverter
    {
        public static Image GetTypeFormImage(GraphicsPetriNet.ItemType kind, ItemForm form)
        {
            switch (form)
            {
                case ItemForm.Round:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.RoundStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.RoundTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.RoundMarkerIcon;
                    }
                    break;
                case ItemForm.Rectangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.RectangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.RectangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.RectangleMarkerIcon;
                    }
                    break;
                case ItemForm.Rhomb:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.RhombStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.RhombTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.RhombMarkerIcon;
                    }
                    break;
                case ItemForm.Triangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.TriangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.TriangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.TriangleMarkerIcon;
                    }
                    break;
                case ItemForm.Image:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.ImageStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.ImageTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.ImageMarkerIcon;
                    }
                    break;
            }
            return null;
        }

        public static Image GetAddItemImage(GraphicsPetriNet.ItemType kind, ItemForm form)
        {
            switch (form)
            {
                case ItemForm.Round:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddRoundStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddRoundTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddRoundMarkerIcon;
                    }
                    break;
                case ItemForm.Rectangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddRectangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddRectangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddRectangleMarkerIcon;
                    }
                    break;
                case ItemForm.Rhomb:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddRhombStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddRhombTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddRhombMarkerIcon;
                    }
                    break;
                case ItemForm.Triangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddTriangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddTriangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddTriangleMarkerIcon;
                    }
                    break;
                case ItemForm.Image:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddImageStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddImageTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddImageMarkerIcon;
                    }
                    break;
            }
            return null;
        }

        public static Image GetItemImage(ItemForm form, Style.ShapeStyle style)
        {
            Image image = null;
            Graphics graphics;
            int width, height;
            Point[] points;
            switch (form)
            {
                case ItemForm.Round:
                    var roundShape = (Style.RoundShapeStyle)style;
                    width = (roundShape.Radius + (int)roundShape.BorderPen.Width + 2)*2;
                    image = new Bitmap(width, width);
                    graphics = Graphics.FromImage(image);
                    graphics.FillEllipse(style.FillBrush, (int)roundShape.BorderPen.Width + 2,
                        (int)roundShape.BorderPen.Width + 2, roundShape.Radius * 2, roundShape.Radius * 2);
                    graphics.DrawEllipse(style.BorderPen, (int)roundShape.BorderPen.Width + 2,
                        (int)roundShape.BorderPen.Width + 2, roundShape.Radius*2, roundShape.Radius * 2);
                    break;
                case ItemForm.Rectangle:
                    var rectangleShape = (Style.RectangleShapeStyle)style;
                    width = rectangleShape.Width + (int)rectangleShape.BorderPen.Width * 2 + 4;
                    height = rectangleShape.Height + (int)rectangleShape.BorderPen.Width * 2 + 4;
                    image = new Bitmap(width, height);
                    graphics = Graphics.FromImage(image);
                    graphics.FillRectangle(style.FillBrush, (int)rectangleShape.BorderPen.Width + 2,
                        (int)rectangleShape.BorderPen.Width + 2, rectangleShape.Width, rectangleShape.Height);
                    graphics.DrawRectangle(style.BorderPen, (int)rectangleShape.BorderPen.Width + 2,
                        (int)rectangleShape.BorderPen.Width + 2, rectangleShape.Width, rectangleShape.Height);
                    break;
                case ItemForm.Rhomb:
                    var rhombShape = (Style.RectangleShapeStyle)style;
                    width = rhombShape.Width + (int)rhombShape.BorderPen.Width * 2 + 4;
                    height = rhombShape.Height + (int)rhombShape.BorderPen.Width * 2 + 4;
                    points = new Point[4] {
                        new Point((int)rhombShape.BorderPen.Width + 2, height/2),
                        new Point(width/2, (int)rhombShape.BorderPen.Width + 2),
                        new Point(width - (int)rhombShape.BorderPen.Width - 2, height/2),
                        new Point(width/2, height - (int)rhombShape.BorderPen.Width - 2)
                    };
                    image = new Bitmap(width, height);
                    graphics = Graphics.FromImage(image);
                    graphics.FillPolygon(style.FillBrush, points);
                    graphics.DrawPolygon(style.BorderPen, points);
                    break;
                case ItemForm.Triangle:
                    var triangleShape = (Style.TriangleShapeStyle)style;
                    width = (triangleShape.Side + (int)triangleShape.BorderPen.Width + 2) * 2;
                    points = new Point[3] {
                        new Point(width/2, (int)triangleShape.BorderPen.Width + 2),
                        new Point(width - (int)triangleShape.BorderPen.Width - 2, width - (int)triangleShape.BorderPen.Width - 2),
                        new Point((int)triangleShape.BorderPen.Width + 2, width - (int)triangleShape.BorderPen.Width - 2)
                    };
                    image = new Bitmap(width, width);
                    graphics = Graphics.FromImage(image);
                    graphics.FillPolygon(style.FillBrush, points);
                    graphics.DrawPolygon(style.BorderPen, points);
                    break;
                case ItemForm.Image:
                    var imageShape = (Style.ImageShapeStyle)style;
                    width = imageShape.Width + (int)imageShape.BorderPen.Width * 2 + 4;
                    height = imageShape.Height + (int)imageShape.BorderPen.Width * 2 + 4;
                    image = new Bitmap(width, height);
                    graphics = Graphics.FromImage(image);
                    graphics.DrawImage(Image.FromFile(imageShape.ImageName),
                        (int)imageShape.BorderPen.Width + 2, (int)imageShape.BorderPen.Width + 2,
                        imageShape.Width, imageShape.Height);
                    break;
            }
            return image;
        }
    }
}
