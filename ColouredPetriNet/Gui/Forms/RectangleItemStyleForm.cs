using System.Windows.Forms;
using System.Drawing;
using ColouredPetriNet.Container.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class RectangleItemStyleForm : Form
    {
        private int _typeId;
        private Core.Style.RectangleShapeStyle _style;
        private ItemStyleForm _parent;
        private ItemForm _form;

        public RectangleItemStyleForm(ItemStyleForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void ShowDialog(int typeId, Core.Style.RectangleShapeStyle style, ItemForm form)
        {
            _typeId = typeId;
            _style = style;
            _form = form;
            numWidth.Value = _style.Width;
            numHeight.Value = _style.Height;
            pnlFillColor.BackColor = ((SolidBrush)_style.FillBrush).Color;
            pnlBorderColor.BackColor = _style.BorderPen.Color;
            numBorderWidth.Value = (int)_style.BorderPen.Width;
            base.ShowDialog();
        }

        private void ChooseFillColor()
        {
            dlgColor.Color = pnlFillColor.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                pnlFillColor.BackColor = dlgColor.Color;
            }
        }

        private void ChooseBorderColor()
        {
            dlgColor.Color = pnlBorderColor.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                pnlBorderColor.BackColor = dlgColor.Color;
            }
        }

        private void AcceptChanges()
        {
            _style.Width = (int)numWidth.Value;
            _style.Height = (int)numHeight.Value;
            ((SolidBrush)_style.FillBrush).Color = pnlFillColor.BackColor;
            _style.BorderPen.Color = pnlBorderColor.BackColor;
            _style.BorderPen.Width = (float)numBorderWidth.Value;
            _parent.UpdateItem(_typeId, _form);
            _style = null;
            this.Close();
        }
    }
}
