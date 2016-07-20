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
    public partial class TransitionInfoForm : Form
    {
        private DataTable _inputLinksTable;
        private DataTable _outputLinksTable;

        public TransitionInfoForm()
        {
            InitializeComponent();
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

        public void ShowDialog(Core.GraphicsTransitionWrapper transition)
        {
            txtId.Text = transition.Transition.Id.ToString();
            txtType.Text = Core.ColouredPetriNetItemInfo.GetTransitionTypeName(transition.Transition.TypeId);
            UpdateInputLinksTable(transition);
            UpdateOutputLinksTable(transition);
            base.ShowDialog();
        }

        private void UpdateInputLinksTable(Core.GraphicsTransitionWrapper transition)
        {
            DataRow newRow;
            _inputLinksTable.Clear();
            if (!ReferenceEquals(transition, null))
            {
                Image stateImage;
                string stateType;
                for (int i = 0; i < transition.InputLinks.Count; ++i)
                {
                    Core.ColouredPetriNetItemInfo.GetStateType(transition.InputLinks[i].State.State,
                        out stateImage, out stateType);
                    newRow = _inputLinksTable.NewRow();
                    newRow["Id"] = transition.InputLinks[i].State.State.Id;
                    newRow["Form"] = stateImage;
                    newRow["Type"] = stateType;
                    _inputLinksTable.Rows.Add(newRow);
                }
            }
        }

        private void UpdateOutputLinksTable(Core.GraphicsTransitionWrapper transition)
        {
            DataRow newRow;
            _outputLinksTable.Clear();
            if (!ReferenceEquals(transition, null))
            {
                Image stateImage;
                string stateType;
                for (int i = 0; i < transition.OutputLinks.Count; ++i)
                {
                    Core.ColouredPetriNetItemInfo.GetStateType(transition.OutputLinks[i].State.State,
                        out stateImage, out stateType);
                    newRow = _outputLinksTable.NewRow();
                    newRow["Id"] = transition.OutputLinks[i].State.State.Id;
                    newRow["Form"] = stateImage;
                    newRow["Type"] = stateType;
                    _outputLinksTable.Rows.Add(newRow);
                }
            }
        }
    }
}
