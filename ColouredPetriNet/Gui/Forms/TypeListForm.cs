using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PetriNet = ColouredPetriNet.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class TypeListForm : Form
    {
        private DataTable _typesTable;
        private PetriNet.GraphicsPetriNet _petriNet;
        private MainForm _parent;

        public TypeListForm(MainForm parent, PetriNet.GraphicsPetriNet petriNet)
        {
            InitializeComponent();
            _petriNet = petriNet;
            _parent = parent;
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
            dgvTypes.RowPrePaint += TypesRowPrePaint;
        }

        public int GetNextTypeId()
        {
            return _petriNet.GetLastTypeId() + 1;
        }

        public int GenerateNextTypeId()
        {
            return _petriNet.GenerateTypeId();
        }

        public bool Contains(string typeName)
        {
            return _petriNet.Types.Contains(typeName);
        }

        public void AddType(PetriNet.TypeInfo type)
        {
            DataRow newRow;
            newRow = _typesTable.NewRow();
            newRow["Image"] = new Bitmap(Core.PetriNetTypeConverter.GetTypeFormImage(type.Kind, type.Form), 20, 20);
            newRow["Id"] = type.Id;
            newRow["Name"] = type.Name;
            newRow["Kind"] = type.Kind.ToString();
            newRow["Form"] = type.Form.ToString();
            _typesTable.Rows.Add(newRow);
            _parent.AddType(type);
        }

        public void EditType(int id, string name, string kindName, string formName)
        {
            var row = FindRow(id);
            if (row == null) return;
            var kind = PetriNet.TypeInfo.GetTypeKindFromString(kindName);
            var form = PetriNet.TypeInfo.GetTypeFormFromString(formName);
            row.Cells[0].Value = new Bitmap(Core.PetriNetTypeConverter.GetTypeFormImage(kind, form), 20, 20);
            row.Cells[2].Value = name;
            row.Cells[3].Value = kindName;
            row.Cells[4].Value = formName;
            _parent.ChangeType(id, name, kind, form);
        }

        new public void ShowDialog()
        {
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
            if ((int)dgvTypes.SelectedRows[0].Cells[1].Value < 8)
            {
                MessageBox.Show("You can't edit reserved types!");
                return;
            }
            dlgEditType.ShowDialog(GetTypeInfo(dgvTypes.SelectedRows[0]));
        }

        private PetriNet.TypeInfo GetTypeInfo(DataGridViewRow row)
        {
            return new PetriNet.TypeInfo((int)row.Cells[1].Value, (string)row.Cells[2].Value,
                PetriNet.TypeInfo.GetTypeKindFromString((string)row.Cells[3].Value),
                PetriNet.TypeInfo.GetTypeFormFromString((string)row.Cells[4].Value));
        }

        private DataGridViewRow FindRow(int id)
        {
            for (int i = 0; i < dgvTypes.Rows.Count; ++i)
            {
                if (id == (int)dgvTypes.Rows[i].Cells[1].Value)
                {
                    return dgvTypes.Rows[i];
                }
            }
            return null;
        }

        private void UpdateTypesTable()
        {
            _typesTable.Clear();
            if (ReferenceEquals(_petriNet, null))
            {
                return;
            }
            DataRow newRow;
            PetriNet.TypeInfo type;
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

        private void TypesRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if ((int)dgvTypes.Rows[e.RowIndex].Cells[1].Value < 8)
            {
                dgvTypes.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Silver;
            }
        }

        private void RemoveType()
        {
            int typeId;
            for (int i = dgvTypes.SelectedRows.Count - 1; i >= 0; --i)
            {
                typeId = (int)dgvTypes.SelectedRows[i].Cells[1].Value;
                if (typeId < 8)
                    continue;
                for (int j = 0; j < _typesTable.Rows.Count; ++j)
                {
                    if (typeId == (int)_typesTable.Rows[j].ItemArray[1])
                    {
                        _typesTable.Rows.RemoveAt(j);
                        break;
                    }
                }
                _parent.RemoveType(typeId);
            }
        }

        private void ClearTypes()
        {
            int typeId;
            for (int i = _typesTable.Rows.Count - 1; i >= 0; --i)
            {
                typeId = (int)_typesTable.Rows[i].ItemArray[1];
                if (typeId >= 8)
                {
                    _typesTable.Rows.RemoveAt(i);
                    _parent.RemoveType(typeId);
                }
            }
        }
    }
}
