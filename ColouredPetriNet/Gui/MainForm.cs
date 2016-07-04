using System.Windows.Forms;
using System.Drawing;

namespace ColouredPetriNet.Gui
{
    public partial class MainForm : Form
    {
        private GraphicsItemMap _itemMap;
        private bool _mousePressed;

        public MainForm()
        {
            InitializeComponent();
            _itemMap = new GraphicsItemMap();
            _mousePressed = false;
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
            //_itemMap.AddItem(new GraphicsItems.LinkGraphicsItem(2, 1, new Point(50, 50), new Point(100, 100),
            //    GraphicsItems.LinkGraphicsItem.LinkDirection.Both));
            //_itemMap.AddItem(new GraphicsItems.LineGraphicsItem(2, 1, new Point(50, 50), new Point(100, 100)));
            //_itemMap.AddItem(new GraphicsItems.RectangleGraphicsItem(1, 1, 20, 40, 100, 100));
            //_itemMap.AddItem(new GraphicsItems.RhombGraphicsItem(1, 1, 10, 20, 100, 100));
            //_itemMap.AddItem(new GraphicsItems.RoundGraphicsItem(1, 1, 10, 100, 100));
        }

        private void ItemMapPaint(object sender, PaintEventArgs e)
        {
            _itemMap.Draw(e.Graphics);
        }

        private void ItemMapMouseClick(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("ItemMapMouseClick");
        }

        private void ItemMapMouseDown(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("ItemMapMouseDown");
            _mousePressed = true;
            _itemMap.SetSelectionArea(e.X, e.Y, 1, 1);
            this.pbMap.Refresh();
        }

        private void ItemMapMouseMove(object sender, MouseEventArgs e)
        {
            if (_mousePressed)
            {
                System.Console.WriteLine("ItemMapMouseMove");
                _itemMap.UpdateSelectionAreaByPos(e.X, e.Y);
                this.pbMap.Refresh();
            }
        }

        private void ItemMapMouseUp(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("ItemMapMouseUp");
            _mousePressed = false;
            _itemMap.HideSelectionArea();
            this.pbMap.Refresh();
        }
    }
}
