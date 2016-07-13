using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ColouredPetriNet.Gui.Forms
{
    public class ToolStripRadioButtonMenuItem : ToolStripMenuItem
    {
        private bool mouseHoverState = false;
        private bool mouseDownState = false;

        public ToolStripRadioButtonMenuItem()
            : base()
        {
            Initialize();
        }

        public ToolStripRadioButtonMenuItem(string text)
            : base(text, null, (EventHandler)null)
        {
            Initialize();
        }

        public ToolStripRadioButtonMenuItem(Image image)
            : base(null, image, (EventHandler)null)
        {
            Initialize();
        }

        public ToolStripRadioButtonMenuItem(string text, Image image)
            : base(text, image, (EventHandler)null)
        {
            Initialize();
        }

        public ToolStripRadioButtonMenuItem(string text, Image image,
            EventHandler onClick)
            : base(text, image, onClick)
        {
            Initialize();
        }

        public ToolStripRadioButtonMenuItem(string text, Image image,
            EventHandler onClick, string name)
            : base(text, image, onClick, name)
        {
            Initialize();
        }

        public ToolStripRadioButtonMenuItem(string text, Image image,
            params ToolStripItem[] dropDownItems)
            : base(text, image, dropDownItems)
        {
            Initialize();
        }

        public ToolStripRadioButtonMenuItem(string text, Image image,
            EventHandler onClick, Keys shortcutKeys)
            : base(text, image, onClick)
        {
            Initialize();
            this.ShortcutKeys = shortcutKeys;
        }

        private void Initialize()
        {
            CheckOnClick = true;
        }

        protected override void OnCheckedChanged(EventArgs e)
        {
            base.OnCheckedChanged(e);
            if ((!Checked) || (this.Parent == null))
                return;
            foreach (ToolStripItem item in Parent.Items)
            {
                ToolStripRadioButtonMenuItem radioItem = item as ToolStripRadioButtonMenuItem;
                if ((radioItem != null) && (radioItem != this) && radioItem.Checked)
                {
                    radioItem.Checked = false;
                    return;
                }
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (Checked) return;
            base.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image != null)
            {
                base.OnPaint(e);
                return;
            }
            else
            {
                CheckState currentState = this.CheckState;
                this.CheckState = CheckState.Unchecked;
                base.OnPaint(e);
                this.CheckState = currentState;
            }
            RadioButtonState buttonState = RadioButtonState.UncheckedNormal;
            if (Enabled)
            {
                if (mouseDownState)
                {
                    if (Checked)
                        buttonState = RadioButtonState.CheckedPressed;
                    else
                        buttonState = RadioButtonState.UncheckedPressed;
                }
                else if (mouseHoverState)
                {
                    if (Checked)
                        buttonState = RadioButtonState.CheckedHot;
                    else
                        buttonState = RadioButtonState.UncheckedHot;
                }
                else
                {
                    if (Checked) buttonState = RadioButtonState.CheckedNormal;
                }
            }
            else
            {
                if (Checked) buttonState = RadioButtonState.CheckedDisabled;
                else buttonState = RadioButtonState.UncheckedDisabled;
            }
            Int32 offset = (ContentRectangle.Height -
                RadioButtonRenderer.GetGlyphSize(e.Graphics, buttonState).Height) / 2;
            Point imageLocation = new Point(ContentRectangle.Location.X + 4,
                ContentRectangle.Location.Y + offset);
            RadioButtonRenderer.DrawRadioButton(e.Graphics, imageLocation, buttonState);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            mouseHoverState = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            mouseHoverState = false;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mouseDownState = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mouseDownState = false;
            base.OnMouseUp(e);
        }

        public override bool Enabled
        {
            get
            {
                ToolStripMenuItem ownerMenuItem = OwnerItem as ToolStripMenuItem;
                if ((!DesignMode) && (ownerMenuItem != null) && ownerMenuItem.CheckOnClick)
                {
                    return base.Enabled && ownerMenuItem.Checked;
                }
                else
                {
                    return base.Enabled;
                }
            }
            set
            {
                base.Enabled = value;
            }
        }

        protected override void OnOwnerChanged(EventArgs e)
        {
            ToolStripMenuItem ownerMenuItem = OwnerItem as ToolStripMenuItem;
            if ((ownerMenuItem != null) && ownerMenuItem.CheckOnClick)
            {
                ownerMenuItem.CheckedChanged += new EventHandler(OwnerMenuItem_CheckedChanged);
            }
            base.OnOwnerChanged(e);
        }

        private void OwnerMenuItem_CheckedChanged( object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
