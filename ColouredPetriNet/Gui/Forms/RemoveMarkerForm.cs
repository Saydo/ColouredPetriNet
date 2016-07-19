﻿using System;
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
        public event EventHandler<Core.Events.PetriNetNodeEventArgs> ClearButtonClick;
        public event EventHandler<Core.Events.StateEventArgs> RemoveButtonClick;

        private Core.GraphicsStateWrapper _selectedState;
        private DataTable _markersTable;

        public RemoveMarkerForm()
        {
            InitializeComponent();
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

        public void ShowDialog(Core.GraphicsStateWrapper selectedState)
        {
            _selectedState = selectedState;
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
            if (!ReferenceEquals(_selectedState, null))
            {
                Image markerImage;
                string markerType;
                for (int i = 0; i < _selectedState.Markers.Count; ++i)
                {
                    GetMarkerType(_selectedState.Markers[i].Item1, out markerImage, out markerType);
                    for (int j = 0; j < _selectedState.Markers[i].Item2.Count; ++j)
                    {
                        newRow = _markersTable.NewRow();
                        newRow["Id"] = _selectedState.Markers[i].Item2[j];
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
            if (ClearButtonClick != null)
            {
                ClearButtonClick(this,
                    new Core.Events.PetriNetNodeEventArgs(_selectedState.State.Id));
            }
        }

        private void RemoveMarkerFromTable(int id)
        {
            for (int i = 0; i < _markersTable.Rows.Count; ++i)
            {
                if (id == _markersTable.Rows[i].Field<int>(0))
                {
                    _markersTable.Rows.RemoveAt(i);
                    return;
                }
            }
        }

        private void RemoveMarkers()
        {
            List<int> removedMarkers = new List<int>();
            int id;
            for (int i = dgvMarkers.SelectedRows.Count - 1; i >= 0; --i)
            {
                id = (int)dgvMarkers.SelectedRows[i].Cells[0].Value;
                RemoveMarkerFromTable(id);
                removedMarkers.Add(id);
            }
            if (RemoveButtonClick != null)
            {
                RemoveButtonClick(this,
                    new Core.Events.StateEventArgs(_selectedState.State.Id, -1, removedMarkers));
            }
        }
    }
}
