using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class ImageGraphicsItem : RectangleGraphicsItem
    {
        protected Image _image;

        public ImageGraphicsItem() : this(-1, -1, null, 0, 0, 0, 0)
        {
        }

        public ImageGraphicsItem(int id, int typeId, Image image, int x = 0, int y = 0, int z = 0)
            : this (id, typeId, image, x, y, image.Width, image.Height, z)
        {
        }

        public ImageGraphicsItem(int id, int typeId, Image image, int x, int y, int w, int h, int z = 0)
            : base(id, typeId, w, h, x, y, z)
        {
            _image = image;
        }

        public override void Draw(Graphics graphics)
        {
            if (!ReferenceEquals(null, _image))
            {
                graphics.DrawImage(_image, _x - _width/2, _y - _height/2, _width, _height);
            }
            if (_selected)
            {
                graphics.DrawRectangle(_selectionPen, _x - _width / 2 - _extent, _y - _height / 2 - _extent,
                    _width + 2 * _extent, _height + 2 * _extent);
            }
        }
    }
}
