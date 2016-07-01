using System;
using System.Drawing;

namespace ColorPetriNetGui
{
    public class ImageGraphicsItem : RectangleGraphicsItem
    {
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
            m_image = image;
        }

        public override void draw(Graphics graphics)
        {
            if (!ReferenceEquals(null, m_image))
            {
                graphics.DrawImage(m_image, m_x - m_width/2, m_y - m_height/2, m_width, m_height);
            }
            if (m_selected)
            {
                graphics.DrawRectangle(m_selectionPen, m_x - m_width / 2 - m_extent, m_y - m_height / 2 - m_extent,
                    m_width + 2 * m_extent, m_height + 2 * m_extent);
            }
        }

        protected Image m_image;
    }
}
