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
    public partial class RemoveMarkerForm : Form
    {
        public MainForm MainForm;
        public Core.GraphicsStateWrapper SelectedState;
        private DataTable _markersTable;

        public RemoveMarkerForm(MainForm mainForm)
        {
            InitializeComponent();
            MainForm = mainForm;
            SelectedState = null;
            _markersTable = new DataTable();
            _markersTable.Columns.Add(new DataColumn("Id", typeof(int)));
            _markersTable.Columns.Add(new DataColumn("Form", typeof(Image)));
            _markersTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dgvMarkers.DataSource = _markersTable;
            dgvMarkers.ReadOnly = true;
            dgvMarkers.AllowUserToAddRows = false;
            dgvMarkers.RowHeadersVisible = false;
            dgvMarkers.Columns[0].Width = 50;
            dgvMarkers.Columns[1].Width = 40;
            dgvMarkers.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvMarkers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        new public void ShowDialog()
        {
            UpdateMarkersTable();
            base.ShowDialog();
        }

        private void GetMarkerType(Core.GraphicsItems.GraphicsItem item, out Image image, out string type)
        {
            int typeId = item.TypeId - (int)Core.PetriNetGraphicsMap.ItemType.Marker;
            switch (typeId)
            {
                case (int)Core.ColouredMarkerType.RoundMarker:
                    image = new Bitmap(Properties.Resources.RoundMarkerIcon, 20, 20);
                    type = "Round Marker";
                    break;
                case (int)Core.ColouredMarkerType.RhombMarker:
                    image = new Bitmap(Properties.Resources.RhombMarkerIcon, 20, 20);
                    type = "Rhomb Marker";
                    break;
                case (int)Core.ColouredMarkerType.TriangleMarker:
                    image = new Bitmap(Properties.Resources.TriangleMarkerIcon, 20, 20);
                    type = "Triangle Marker";
                    break;
                default:
                    image = null;
                    type = "";
                    break;
            }
        }

        private void UpdateMarkersTable()
        {
            DataRow newRow;
            _markersTable.Clear();
            if (!ReferenceEquals(SelectedState, null))
            {
                Image markerImage;
                string markerType;
                for (int i = 0; i < SelectedState.Markers.Count; ++i)
                {
                    GetMarkerType(SelectedState.Markers[i].Item1, out markerImage, out markerType);
                    for (int j = 0; j < SelectedState.Markers[i].Item2.Count; ++j)
                    {
                        newRow = _markersTable.NewRow();
                        newRow["Id"] = SelectedState.Markers[i].Item2[j];
                        newRow["Form"] = markerImage;
                        newRow["Type"] = markerType;
                        _markersTable.Rows.Add(newRow);
                    }
                }
            }
        }

        private void ClearMarkers()
        {
            _markersTable.Clear();
            MainForm.ClearMarkers(SelectedState.State.Id);
        }

        private void RemoveMarkerFromTable(int id)
        {
            for (int i = 0; i < _markersTable.Rows.Count; ++i)
            {
                if (id == _markersTable.Rows[i].Field<int>(0))
                {
                    _markersTable.Rows.RemoveAt(i);
                    MainForm.RemoveMarker(id, SelectedState.State.Id);
                    return;
                }
            }
        }

        private void RemoveMarkers()
        {
            for (int i = dgvMarkers.SelectedRows.Count - 1; i >= 0; --i)
            {
                RemoveMarkerFromTable((int)dgvMarkers.SelectedRows[i].Cells[0].Value);
            }
        }
    }
}
