using System.Drawing;
using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class LinkStyleForm : Form
    {
        private Pen _pen;
        private MainForm _parent;

        public LinkStyleForm(MainForm parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void ShowDialog(Pen pen)
        {
            _pen = pen;
            numWidth.Value = (int)pen.Width;
            pnlColor.BackColor = _pen.Color;
            base.ShowDialog();
        }

        private void ChooseColor()
        {
            dlgColor.Color = pnlColor.BackColor;
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                pnlColor.BackColor = dlgColor.Color;
            }
        }

        private void AcceptChanges()
        {
            _pen.Width = (float)numWidth.Value;
            _pen.Color = pnlColor.BackColor;
            _parent.UpdateMap();
            _pen = null;
            this.Close();
        }
    }
}
