using System.Windows.Forms;
using System.Drawing;

namespace ColouredPetriNet.Gui
{
    public partial class MainForm : Form
    {
        private GraphicsItemMap _itemMap;

        public MainForm()
        {
            InitializeComponent();
            _itemMap = new GraphicsItemMap();
            /*
            ImageList img_list = new ImageList();
            img_list.Images.Add(Properties.Resources.AddRoundStateIcon);
            img_list.Images.Add(Properties.Resources.RemoveIcon);
            trvStates.ImageList = img_list;
            trvStates.Nodes.Add(new TreeNode("State 1", 1, 1));
            trvStates.Nodes.Add(new TreeNode("State 2", 0, 0));
            */
            GraphicsItems.TriangleGraphicsItem triangle = new GraphicsItems.TriangleGraphicsItem(0, 0, 10, 10);
            triangle.SetPoint(0, new Point(10, 10));
            triangle.SetPoint(1, new Point(10, 40));
            triangle.SetPoint(2, new Point(40, 40));
            _itemMap.AddItem(triangle);
        }

        private void ItemMapPaint(object sender, PaintEventArgs e)
        {
            _itemMap.Draw(e.Graphics);
        }

        private void ItemMapMouseClick(object sender, MouseEventArgs e)
        {
            //
        }

        private void ItemMapMouseDown(object sender, MouseEventArgs e)
        {
            //
        }

        private void ItemMapMouseMove(object sender, MouseEventArgs e)
        {
            //
        }

        private void ItemMapMouseUp(object sender, MouseEventArgs e)
        {
            //
        }
    }
}
