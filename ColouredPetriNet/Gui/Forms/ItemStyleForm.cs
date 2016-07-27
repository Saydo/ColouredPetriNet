using System.Data;
using System.Drawing;
using System.Windows.Forms;
using ColouredPetriNet.Container.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class ItemStyleForm : Form
    {
        private DataTable _itemsTable;
        private Core.Style.ColouredPetriNetStyle _style;
        private GraphicsPetriNet _petriNet;
        private MainForm _parent;

        public ItemStyleForm(Core.Style.ColouredPetriNetStyle style, GraphicsPetriNet petriNet, MainForm parent)
        {
            InitializeComponent();
            _style = style;
            _petriNet = petriNet;
            _parent = parent;
            _itemsTable = new DataTable();
            _itemsTable.Columns.Add(new DataColumn("Image", typeof(Image)));
            _itemsTable.Columns.Add(new DataColumn("Id", typeof(int)));
            _itemsTable.Columns.Add(new DataColumn("Name", typeof(string)));
            _itemsTable.Columns.Add(new DataColumn("Form", typeof(string)));
            dgvItems.DataSource = _itemsTable;
            dgvItems.ReadOnly = true;
            dgvItems.AllowUserToAddRows = false;
            dgvItems.RowHeadersVisible = false;
            dgvItems.Columns[0].HeaderText = "";
            dgvItems.Columns[0].Width = 22;
            dgvItems.Columns[1].Width = 35;
            dgvItems.Columns[2].Width = 105;
            dgvItems.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var dgvColumnHeaderStyle = new DataGridViewCellStyle();
            dgvColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvItems.ColumnHeadersDefaultCellStyle = dgvColumnHeaderStyle;
        }

        public void ShowDialog(GraphicsPetriNet.ItemType itemType)
        {
            UpdateItemTable(itemType);
            base.ShowDialog();
        }

        private void UpdateItemTable(GraphicsPetriNet.ItemType itemType)
        {
            _itemsTable.Clear();
            if (ReferenceEquals(_petriNet, null))
            {
                return;
            }
            DataRow newRow;
            TypeInfo type;
            for (int i = 0; i < _petriNet.Types.Count; ++i)
            {
                type = _petriNet.Types[i];
                if (type.Kind == itemType)
                {
                    newRow = _itemsTable.NewRow();
                    //newRow["Image"] = new Bitmap(Core.PetriNetTypeConverter.GetTypeFormImage(type.Kind, type.Form), 20, 20);
                    newRow["Image"] = new Bitmap(Core.PetriNetTypeConverter.GetItemImage(type.Form, _style.FindItemStyle(type.Id)), 20, 20);
                    newRow["Id"] = type.Id;
                    newRow["Name"] = type.Name;
                    newRow["Form"] = type.Form.ToString();
                    _itemsTable.Rows.Add(newRow);
                }
            }
        }
    }
}
