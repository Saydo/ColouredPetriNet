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
    public partial class ShowItemInfoForm : Form
    {
        public event EventHandler<Core.Events.ShowInfoEventArgs> FindButtonClick;
        private Core.Events.ShowInfoEventArgs.ItemType _itemType;

        public ShowItemInfoForm()
        {
            InitializeComponent();
            _itemType = Core.Events.ShowInfoEventArgs.ItemType.State;
        }

        public void ShowDialog(Core.Events.ShowInfoEventArgs.ItemType itemType)
        {
            numId.Value = 0;
            _itemType = itemType;
            base.ShowDialog();
        }

        public void OnFindButtonClick()
        {
            if (FindButtonClick != null)
            {
                FindButtonClick(this,
                    new Core.Events.ShowInfoEventArgs((int)numId.Value, _itemType));
            }
        }
    }
}
