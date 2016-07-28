using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class RoundItemStyleForm : Form
    {
        private int _typeId;
        private Core.Style.RoundShapeStyle _style;
        private ItemStyleForm _parent;

        public RoundItemStyleForm(ItemStyleForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void ShowDialog(int typeId, Core.Style.RoundShapeStyle style)
        {
            _typeId = typeId;
            _style = style;
            numRadius.Value = _style.Radius;
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
            _style.Radius = (int)numRadius.Value;
            ((SolidBrush)_style.FillBrush).Color = pnlFillColor.BackColor;
            _style.BorderPen.Color = pnlBorderColor.BackColor;
            _style.BorderPen.Width = (float)numBorderWidth.Value;
            _parent.UpdateItem(_typeId, ColouredPetriNet.Container.GraphicsPetriNet.ItemForm.Round);
            _style = null;
            this.Close();
        }
    }
}
