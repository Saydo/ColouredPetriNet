using System.Windows.Forms;
using System.Drawing;
using PetriNet = ColouredPetriNet.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class TypeEditForm : Form
    {
        private enum DialogMode { Add, Edit };

        private DialogMode _mode;
        private TypeListForm _parent;
        private string _oldName;

        public TypeEditForm(TypeListForm parent)
        {
            InitializeComponent();
            _parent = parent;
            _mode = DialogMode.Add;
        }

        new public void ShowDialog()
        {
            _mode = DialogMode.Add;
            this.Text = "Add Type";
            txtId.Text = _parent.GetNextTypeId().ToString();
            txtName.Text = "";
            cmbKind.SelectedIndex = 0;
            cmbForm.SelectedIndex = 0;
            UpdateImage();
            base.ShowDialog();
        }

        public void ShowDialog(PetriNet.TypeInfo type)
        {
            _mode = DialogMode.Edit;
            this.Text = "Edit Type";
            txtId.Text = type.Id.ToString();
            _oldName = type.Name;
            txtName.Text = type.Name;
            cmbKind.SelectedItem = type.Kind.ToString();
            cmbForm.SelectedItem = type.Form.ToString();
            UpdateImage();
            base.ShowDialog();
        }

        private void UpdateImage()
        {
            var kind = PetriNet.TypeInfo.GetTypeKindFromString((string)cmbKind.SelectedItem);
            var form = PetriNet.TypeInfo.GetTypeFormFromString((string)cmbForm.SelectedItem);
            pbForm.Image = new Bitmap(Core.PetriNetTypeConverter.GetTypeFormImage(kind, form),
                pbForm.Width, pbForm.Height);
        }

        private void AcceptChanges()
        {
            if (_mode == DialogMode.Add)
            {
                if (_parent.Contains(txtName.Text))
                {
                    MessageBox.Show("Type with this name is exist! Select another type name!");
                    return;
                }
                _parent.AddType(new PetriNet.TypeInfo(_parent.GenerateNextTypeId(), txtName.Text,
                    PetriNet.TypeInfo.GetTypeKindFromString((string)cmbKind.SelectedItem),
                    PetriNet.TypeInfo.GetTypeFormFromString((string)cmbForm.SelectedItem)));
            }
            else
            {
                if ((txtName.Text != _oldName) && (_parent.Contains(txtName.Text)))
                {
                    MessageBox.Show("Type with this name is exist! Select another type name!");
                    return;
                }
                _parent.EditType(int.Parse(txtId.Text), txtName.Text,
                    (string)cmbKind.SelectedItem, (string)cmbForm.SelectedItem);
            }
            this.Close();
        }
    }
}
