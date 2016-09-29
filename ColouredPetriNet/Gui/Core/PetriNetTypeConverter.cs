using System.Drawing;
using PetriNet = ColouredPetriNet.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Core
{
    public static class PetriNetTypeConverter
    {
        public static Image GetTypeFormImage(PetriNet.GraphicsPetriNet.ItemType kind, PetriNet.ItemForm form)
        {
            switch (form)
            {
                case PetriNet.ItemForm.Round:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("RoundStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("RoundTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("RoundMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Rectangle:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("RectangleStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("RectangleTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("RectangleMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Rhomb:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("RhombStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("RhombTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("RhombMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Triangle:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("TriangleStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("TriangleTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("TriangleMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Image:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("ImageStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("ImageTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("ImageMarkerIcon");
                    }
                    break;
            }
            return null;
        }

        public static Image GetAddItemImage(PetriNet.GraphicsPetriNet.ItemType kind, PetriNet.ItemForm form)
        {
            switch (form)
            {
                case PetriNet.ItemForm.Round:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddRoundStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddRoundTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddRoundMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Rectangle:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddRectangleStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddRectangleTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddRectangleMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Rhomb:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddRhombStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddRhombTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddRhombMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Triangle:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddTriangleStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddTriangleTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddTriangleMarkerIcon");
                    }
                    break;
                case PetriNet.ItemForm.Image:
                    switch (kind)
                    {
                        case PetriNet.GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddImageStateIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddImageTransitionIcon");
                        case PetriNet.GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddImageMarkerIcon");
                    }
                    break;
            }
            return null;
        }

        public static Image GetItemImage(PetriNet.ItemForm form, Style.ShapeStyle style)
        {
            Image image = null;
            Graphics graphics;
            int width, height;
            Point[] points;
            switch (form)
            {
                case PetriNet.ItemForm.Round:
                    var roundShape = (Style.RoundShapeStyle)style;
                    width = (roundShape.Radius + (int)roundShape.BorderPen.Width + 2)*2;
                    image = new Bitmap(width, width);
                    graphics = Graphics.FromImage(image);
                    graphics.FillEllipse(style.FillBrush, (int)roundShape.BorderPen.Width + 2,
                        (int)roundShape.BorderPen.Width + 2, roundShape.Radius * 2, roundShape.Radius * 2);
                    graphics.DrawEllipse(style.BorderPen, (int)roundShape.BorderPen.Width + 2,
                        (int)roundShape.BorderPen.Width + 2, roundShape.Radius*2, roundShape.Radius * 2);
                    break;
                case PetriNet.ItemForm.Rectangle:
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
                case PetriNet.ItemForm.Rhomb:
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
                case PetriNet.ItemForm.Triangle:
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
                case PetriNet.ItemForm.Image:
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
