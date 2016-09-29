using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetriNet = ColouredPetriNet.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class ImageItemStyleForm : Form
    {
        private int _typeId;
        private Core.Style.ImageShapeStyle _style;
        private ItemStyleForm _parent;

        public ImageItemStyleForm(ItemStyleForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void ShowDialog(int typeId, Core.Style.ImageShapeStyle style)
        {
            _typeId = typeId;
            _style = style;
            base.ShowDialog();
        }

        private void AcceptChanges()
        {
            /*
            _style.Width = (int)numWidth.Value;
            _style.Height = (int)numHeight.Value;
            ((SolidBrush)_style.FillBrush).Color = pnlFillColor.BackColor;
            _style.BorderPen.Color = pnlBorderColor.BackColor;
            _style.BorderPen.Width = (float)numBorderWidth.Value;
            */
            _parent.UpdateItem(_typeId, PetriNet.ItemForm.Image);
            _style = null;
            this.Close();
        }
    }
}
