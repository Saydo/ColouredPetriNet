﻿using System.Drawing;
using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    public class StripImageList : ToolStripDropDownButton
    {
        public StripImageList(string toolTipText = "") : base()
        {
            ((ToolStripDropDownMenu)DropDown).ShowCheckMargin = false;
            this.ToolTipText = toolTipText;
            this.DropDownItemClicked += ChangeImage;
        }

        public void AddItem(Image image, string text, string toolTipText = "")
        {
            if (ReferenceEquals(image, null))
            {
                return;
            }
            if (this.DropDown.Items.Count == 0)
            {
                this.Image = image;
                this.ToolTipText = toolTipText;
            }
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            item.Image = image;
            item.ToolTipText = toolTipText;
            this.DropDown.Items.Add(item);
        }

        private void ChangeImage(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripDropDownButton button = sender as ToolStripDropDownButton;
            if ((!ReferenceEquals(button, null)) && (!ReferenceEquals(e.ClickedItem, null)))
            {
                button.Image = e.ClickedItem.Image;
                button.ToolTipText = e.ClickedItem.ToolTipText;
            }
        }
    }
}
