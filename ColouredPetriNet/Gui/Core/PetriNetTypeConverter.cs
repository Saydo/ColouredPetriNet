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
                            return PetriNetResources.Storage.GetImage("RoundStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("RoundTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("RoundMarkerIcon");
                    }
                    break;
                case ItemForm.Rectangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("RectangleStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("RectangleTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("RectangleMarkerIcon");
                    }
                    break;
                case ItemForm.Rhomb:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("RhombStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("RhombTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("RhombMarkerIcon");
                    }
                    break;
                case ItemForm.Triangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("TriangleStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("TriangleTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("TriangleMarkerIcon");
                    }
                    break;
                case ItemForm.Image:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("ImageStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("ImageTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("ImageMarkerIcon");
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
                            return PetriNetResources.Storage.GetImage("AddRoundStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddRoundTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddRoundMarkerIcon");
                    }
                    break;
                case ItemForm.Rectangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddRectangleStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddRectangleTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddRectangleMarkerIcon");
                    }
                    break;
                case ItemForm.Rhomb:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddRhombStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddRhombTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddRhombMarkerIcon");
                    }
                    break;
                case ItemForm.Triangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddTriangleStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddTriangleTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddTriangleMarkerIcon");
                    }
                    break;
                case ItemForm.Image:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return PetriNetResources.Storage.GetImage("AddImageStateIcon");
                        case GraphicsPetriNet.ItemType.Transition:
                            return PetriNetResources.Storage.GetImage("AddImageTransitionIcon");
                        case GraphicsPetriNet.ItemType.Marker:
                            return PetriNetResources.Storage.GetImage("AddImageMarkerIcon");
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
