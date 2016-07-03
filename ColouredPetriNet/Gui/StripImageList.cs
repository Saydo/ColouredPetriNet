using System.Drawing;
using System.Windows.Forms;

namespace ColouredPetriNet.Gui
{
    public class StripImageList : ToolStripDropDownButton //ToolStripDropDownMenu
    {
        /*
        protected override void OnPaint(PaintEventArgs e)
        {
            for (int i = 0; i < this.DropDownItems.Count; i++)
            {
                try
                {
                    if ((this.DropDownItems[i].Image != null) && (this.DropDownItems[i].GetType().BaseType == typeof(System.Windows.Forms.ToolStripControlHost)))
                    {
                        float x = (26 / 2) - (16 / 2);
                        float y = this.DropDownItems[i].Bounds.Y + ((this.DropDownItems[i].Bounds.Height / 2) - (16 / 2));
                        e.Graphics.DrawImage(this.DropDownItems[i].Image, x, y);
                    }
                }
                catch { }
            }
            base.OnPaint(e);
        }
        */
    }
}
