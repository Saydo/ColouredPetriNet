using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ColouredPetriNet.Container.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class TypeListForm : Form
    {
        private DataTable _typesTable;
        private GraphicsPetriNet _petriNet;

        public TypeListForm()
        {
            InitializeComponent();
            _typesTable = new DataTable();
            _typesTable.Columns.Add(new DataColumn("Image", typeof(Image)));
            _typesTable.Columns.Add(new DataColumn("Id", typeof(int)));
            _typesTable.Columns.Add(new DataColumn("Name", typeof(string)));
            _typesTable.Columns.Add(new DataColumn("Kind", typeof(string)));
            _typesTable.Columns.Add(new DataColumn("Form", typeof(string)));
            dgvTypes.DataSource = _typesTable;
            dgvTypes.ReadOnly = true;
            dgvTypes.AllowUserToAddRows = false;
            dgvTypes.RowHeadersVisible = false;
            dgvTypes.Columns[0].HeaderText = "";
            dgvTypes.Columns[0].Width = 22;
            dgvTypes.Columns[1].Width = 25;
            dgvTypes.Columns[2].Width = 105;
            dgvTypes.Columns[3].Width = 55;
            dgvTypes.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var dgvColumnHeaderStyle = new DataGridViewCellStyle();
            dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTypes.ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle;
        }

        public void ShowDialog(GraphicsPetriNet petriNet)
        {
            _petriNet = petriNet;
            UpdateTypesTable();
            base.ShowDialog();
        }

        private void OpenEditDialog()
        {
            if (dgvTypes.SelectedRows.Count != 1)
            {
                MessageBox.Show("Select one type!");
                return;
            }
            dlgEditType.ShowDialog(GetTypeInfo(dgvTypes.SelectedRows[0]));
        }

        private TypeInfo GetTypeInfo(DataGridViewRow row)
        {
            return new TypeInfo((int)row.Cells[1].Value, (string)row.Cells[2].Value,
                TypeInfo.GetTypeKindFromString((string)row.Cells[3].Value),
                TypeInfo.GetTypeFormFromString((string)row.Cells[4].Value));
        }

        private void UpdateTypesTable()
        {
            _typesTable.Clear();
            if (ReferenceEquals(_petriNet, null))
            {
                return;
            }
            DataRow newRow;
            TypeInfo type;
            for (int i = 0; i < _petriNet.Types.Count; ++i)
            {
                type = _petriNet.Types[i];
                newRow = _typesTable.NewRow();
                newRow["Image"] = new Bitmap(Core.PetriNetTypeConverter.GetTypeFormImage(type.Kind, type.Form), 20, 20);
                newRow["Id"] = type.Id;
                newRow["Name"] = type.Name;
                newRow["Kind"] = type.Kind.ToString();
                newRow["Form"] = type.Form.ToString();
                _typesTable.Rows.Add(newRow);
            }
        }

        private void RemoveType()
        {
            int typeId;
            for (int i = 0; i < dgvTypes.SelectedRows.Count; ++i)
            {
                typeId = (int)dgvTypes.SelectedRows[i].Cells[1].Value;
                for (int j = 0; j < _typesTable.Rows.Count; ++j)
                {
                    if (typeId == (int)_typesTable.Rows[j].ItemArray[1])
                    {
                        _typesTable.Rows.RemoveAt(j);
                        break;
                    }
                }
                _petriNet.Types.RemoveById(typeId);
            }
        }

        private void ClearTypes()
        {
            _typesTable.Clear();
            _petriNet.Types.Clear();
        }
    }
}
