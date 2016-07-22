using System.Drawing;

namespace ColouredPetriNet.Container.GraphicsPetriNet.GraphicsItems
{
    public class ImageGraphicsItem : RectangleGraphicsItem
    {
        protected Image _image;

        public ImageGraphicsItem() : this(-1, -1, null, new Point(0, 0), 0, 0)
        {
        }

        public ImageGraphicsItem(int id, int typeId, Image image, int z = 0)
            : this(id, typeId, image, new Point(0, 0), image.Width, image.Height, z)
        {
        }

        public ImageGraphicsItem(int id, int typeId, Image image, Point center, int z = 0)
            : this (id, typeId, image, center, image.Width, image.Height, z)
        {
        }

        public ImageGraphicsItem(int id, int typeId, Image image, Point center, int w, int h, int z = 0)
            : base(id, typeId, center, w, h, z)
        {
            _image = image;
        }

        public override void Draw(Graphics graphics)
        {
            if (!ReferenceEquals(null, _image))
            {
                graphics.DrawImage(_image, _center.X - _width/2, _center.Y - _height/2, _width, _height);
            }
            if (_selected)
            {
                graphics.DrawRectangle(_selectionPen, _center.X - _width / 2 - _extent, _center.Y - _height / 2 - _extent,
                    _width + 2 * _extent, _height + 2 * _extent);
            }
        }
    }
}
