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

        public void UpdateItem(int typeId, ItemForm form)
        {
            for (int i = 0; i < _itemsTable.Rows.Count; ++i)
            {
                if (typeId == (int)_itemsTable.Rows[i].ItemArray[1])
                {
                    var newRow = _itemsTable.NewRow();
                    newRow["Image"] = new Bitmap(Core.PetriNetTypeConverter.GetItemImage(form, _style.FindItemStyle(typeId)), 20, 20);
                    newRow["Id"] = (int)_itemsTable.Rows[i].ItemArray[1];
                    newRow["Name"] = (string)_itemsTable.Rows[i].ItemArray[2];
                    newRow["Form"] = (string)_itemsTable.Rows[i].ItemArray[3];
                    _itemsTable.Rows.RemoveAt(i);
                    _itemsTable.Rows.InsertAt(newRow, i);
                    return;
                }
            }
        }

        private void OpenEditDialog()
        {
            if (dgvItems.SelectedRows.Count != 1)
            {
                MessageBox.Show("Select one item!");
                return;
            }
            var type = _petriNet.Types.FindType((int)dgvItems.SelectedRows[0].Cells[1].Value);
            switch (type.Form)
            {
                case ItemForm.Round:
                    dlgRoundItemStyle.Text = string.Format("\"{0}\" Style", type.Name);
                    dlgRoundItemStyle.ShowDialog(type.Id, (Core.Style.RoundShapeStyle)_style.FindItemStyle(type.Id));
                    break;
                case ItemForm.Rectangle:
                    dlgRectangleItemStyle.Text = string.Format("\"{0}\" Style", type.Name);
                    dlgRectangleItemStyle.ShowDialog(type.Id, (Core.Style.RectangleShapeStyle)_style.FindItemStyle(type.Id), ItemForm.Rectangle);
                    break;
                case ItemForm.Rhomb:
                    dlgRectangleItemStyle.Text = string.Format("\"{0}\" Style", type.Name);
                    dlgRectangleItemStyle.ShowDialog(type.Id, (Core.Style.RectangleShapeStyle)_style.FindItemStyle(type.Id), ItemForm.Rhomb);
                    break;
                case ItemForm.Triangle:
                    dlgTriangleItemStyle.Text = string.Format("\"{0}\" Style", type.Name);
                    dlgTriangleItemStyle.ShowDialog(type.Id, (Core.Style.TriangleShapeStyle)_style.FindItemStyle(type.Id));
                    break;
                case ItemForm.Image:
                    dlgImageItemStyle.Text = string.Format("\"{0}\" Style", type.Name);
                    dlgImageItemStyle.ShowDialog(type.Id, (Core.Style.ImageShapeStyle)_style.FindItemStyle(type.Id));
                    break;
            }
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
