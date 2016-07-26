using System.Windows.Forms;
using ColouredPetriNet.Container.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class TypeEditForm : Form
    {
        private enum DialogMode { Add, Edit };

        private DialogMode _mode;

        public TypeEditForm()
        {
            InitializeComponent();
            _mode = DialogMode.Add;
        }

        new public void ShowDialog()
        {
            _mode = DialogMode.Add;
            txtId.Text = "";
            txtName.Text = "";
            cmbKind.SelectedIndex = 0;
            cmbForm.SelectedIndex = 0;
            base.ShowDialog();
        }

        public void ShowDialog(TypeInfo type)
        {
            _mode = DialogMode.Edit;
            txtId.Text = type.Id.ToString();
            txtName.Text = type.Name;
            cmbKind.SelectedItem = type.Kind.ToString();
            cmbForm.SelectedItem = type.Form.ToString();
            base.ShowDialog();
        }

        private void AcceptChanges()
        {
            if (_mode == DialogMode.Add)
            {
                //
            }
            else
            {
                //
            }
            this.Close();
        }
    }
}
