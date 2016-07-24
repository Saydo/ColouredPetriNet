using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ColouredPetriNet.Container.GraphicsPetriNet;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class StateInfoForm : Form
    {
        private DataTable _markersTable;
        private DataTable _inputLinksTable;
        private DataTable _outputLinksTable;

        public StateInfoForm()
        {
            InitializeComponent();
            // Markers Table
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
            // Input Links Table
            _inputLinksTable = new DataTable();
            _inputLinksTable.Columns.Add(new DataColumn("Id", typeof(int)));
            _inputLinksTable.Columns.Add(new DataColumn("Form", typeof(Image)));
            _inputLinksTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dgvInputLinks.DataSource = _inputLinksTable;
            dgvInputLinks.ReadOnly = true;
            dgvInputLinks.AllowUserToAddRows = false;
            dgvInputLinks.RowHeadersVisible = false;
            dgvInputLinks.Columns[0].Width = 50;
            dgvInputLinks.Columns[1].Width = 40;
            dgvInputLinks.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInputLinks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            // Output Links Table
            _outputLinksTable = new DataTable();
            _outputLinksTable.Columns.Add(new DataColumn("Id", typeof(int)));
            _outputLinksTable.Columns.Add(new DataColumn("Form", typeof(Image)));
            _outputLinksTable.Columns.Add(new DataColumn("Type", typeof(string)));
            dgvOutputLinks.DataSource = _outputLinksTable;
            dgvOutputLinks.ReadOnly = true;
            dgvOutputLinks.AllowUserToAddRows = false;
            dgvOutputLinks.RowHeadersVisible = false;
            dgvOutputLinks.Columns[0].Width = 50;
            dgvOutputLinks.Columns[1].Width = 40;
            dgvOutputLinks.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvOutputLinks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public void ShowDialog(StateWrapper state)
        {
            txtId.Text = state.State.Id.ToString();
            txtType.Text = Core.ColouredPetriNetItemInfo.GetStateTypeName(state.State.TypeId);
            UpdateMarkersTable(state);
            UpdateInputLinksTable(state);
            UpdateOutputLinksTable(state);
            base.ShowDialog();
        }

        private void UpdateMarkersTable(StateWrapper state)
        {
            DataRow newRow;
            _markersTable.Clear();
            if (!ReferenceEquals(state, null))
            {
                Image markerImage;
                string markerType;
                for (int i = 0; i < state.Markers.Count; ++i)
                {
                    Core.ColouredPetriNetItemInfo.GetMarkerType(state.Markers[i].Item1,
                        out markerImage, out markerType);
                    for (int j = 0; j < state.Markers[i].Item2.Count; ++j)
                    {
                        newRow = _markersTable.NewRow();
                        newRow["Id"] = state.Markers[i].Item2[j];
                        newRow["Form"] = markerImage;
                        newRow["Type"] = markerType;
                        _markersTable.Rows.Add(newRow);
                    }
                }
            }
        }

        private void UpdateInputLinksTable(StateWrapper state)
        {
            DataRow newRow;
            _inputLinksTable.Clear();
            if (!ReferenceEquals(state, null))
            {
                Image transitionImage;
                string transitionType;
                for (int i = 0; i < state.InputLinks.Count; ++i)
                {
                    Core.ColouredPetriNetItemInfo.GetTransitionType(state.InputLinks[i].Transition.Transition,
                        out transitionImage, out transitionType);
                    newRow = _inputLinksTable.NewRow();
                    newRow["Id"] = state.InputLinks[i].Transition.Transition.Id;
                    newRow["Form"] = transitionImage;
                    newRow["Type"] = transitionType;
                    _inputLinksTable.Rows.Add(newRow);
                }
            }
        }

        private void UpdateOutputLinksTable(StateWrapper state)
        {
            DataRow newRow;
            _outputLinksTable.Clear();
            if (!ReferenceEquals(state, null))
            {
                Image transitionImage;
                string transitionType;
                for (int i = 0; i < state.OutputLinks.Count; ++i)
                {
                    Core.ColouredPetriNetItemInfo.GetTransitionType(state.OutputLinks[i].Transition.Transition,
                        out transitionImage, out transitionType);
                    newRow = _outputLinksTable.NewRow();
                    newRow["Id"] = state.OutputLinks[i].Transition.Transition.Id;
                    newRow["Form"] = transitionImage;
                    newRow["Type"] = transitionType;
                    _outputLinksTable.Rows.Add(newRow);
                }
            }
        }
    }
}
