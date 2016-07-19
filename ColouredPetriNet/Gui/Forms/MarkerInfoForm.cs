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
    public partial class MarkerInfoForm : Form
    {
        public MarkerInfoForm()
        {
            InitializeComponent();
        }

        public void ShowDialog(int id, int stateId, string type)
        {
            txtId.Text = id.ToString();
            txtStateId.Text = stateId.ToString();
            txtType.Text = type;
            base.ShowDialog();
        }
    }
}
