using System.Drawing;
using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    public class StripImageList : ToolStripDropDownButton
    {
        private int _currentId;

        public StripImageList(string toolTipText = "") : base()
        {
            _currentId = -1;
            ((ToolStripDropDownMenu)DropDown).ShowCheckMargin = false;
            this.ToolTipText = toolTipText;
            this.DropDownItemClicked += ChangeImage;
        }

        public void AddItem(int id, Image image, string text, string toolTipText = "")
        {
            if (ReferenceEquals(image, null))
            {
                return;
            }
            if (this.DropDown.Items.Count == 0)
            {
                _currentId = id;
                this.Image = image;
                this.ToolTipText = toolTipText;
            }
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            item.Image = image;
            item.Tag = id;
            item.ToolTipText = toolTipText;
            this.DropDown.Items.Add(item);
        }

        public bool ChangeItem(int id, Image image, string text, string toolTipText = "")
        {
            var items = this.DropDown.Items;
            for (int i = 0; i < items.Count; ++i)
            {
                if ((int)items[i].Tag == id)
                {
                    if (_currentId == id)
                    {
                        this.Image = image;
                        this.ToolTipText = toolTipText;
                    }
                    items[i].Image = image;
                    items[i].Text = text;
                    items[i].ToolTipText = toolTipText;
                    return true;
                }
            }
            return false;
        }

        public bool RemoveItem(int id)
        {
            var items = this.DropDown.Items;
            for (int i = 0; i < items.Count; ++i)
            {
                if ((int)items[i].Tag == id)
                {
                    if (_currentId == id)
                    {
                        if (items.Count == 1)
                        {
                            _currentId = -1;
                            this.Image = null;
                        }
                        else
                        {
                            if (i == 0)
                            {
                                _currentId = (int)items[1].Tag;
                                this.Image = items[1].Image;
                                this.ToolTipText = items[1].ToolTipText;
                            }
                            else
                            {
                                _currentId = (int)items[i - 1].Tag;
                                this.Image = items[i - 1].Image;
                                this.ToolTipText = items[i - 1].ToolTipText;
                            }
                        }
                    }
                    items.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        private void ChangeImage(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!ReferenceEquals(e.ClickedItem, null))
            {
                _currentId = (int)e.ClickedItem.Tag;
                this.Image = e.ClickedItem.Image;
                this.ToolTipText = e.ClickedItem.ToolTipText;
            }
        }
    }
}
