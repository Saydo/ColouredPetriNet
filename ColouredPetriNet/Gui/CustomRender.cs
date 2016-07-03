using System.Windows.Forms;
using System.Drawing;

public class CustomRenderer : ToolStripProfessionalRenderer
{
    int innerImagePadding = 2;

    protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
    {
        System.Console.WriteLine("OnRenderItemImage");
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        System.Console.WriteLine("OnRenderItemText");
        if (!ReferenceEquals(e.Item.Image, null))
        {
            System.Console.WriteLine("Image exist!");
        }
        Image img = e.Item.Tag as Image;
        if (img == null) base.OnRenderItemText(e);
        else {
            e.Graphics.DrawImage(img, e.Item.ContentRectangle.Left + e.Item.Bounds.Height + innerImagePadding,
                                 e.Item.ContentRectangle.Top + innerImagePadding,
                                 System.Math.Max(1, e.Item.ContentRectangle.Height - innerImagePadding * 2),
                                 System.Math.Max(1, e.Item.ContentRectangle.Height - innerImagePadding * 2));
            Rectangle textRect = new Rectangle(e.Item.ContentRectangle.Left + e.Item.Bounds.Height * 2,
                                 e.Item.ContentRectangle.Top + 1,
                                 e.TextRectangle.Width,
                                 e.TextRectangle.Height);
            e.Graphics.DrawString(e.Text, e.TextFont, new SolidBrush(e.TextColor), textRect);
        }
    }
}