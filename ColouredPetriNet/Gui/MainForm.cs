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
            //(10, 10), (10, 50), (40, 50)
            GraphicsItems.TriangleGraphicsItem triangle = new GraphicsItems.TriangleGraphicsItem(0, 0,
                new Point(10, 10), new Point(10, 50), new Point(40, 50));
            // beta = 18,434948822922010648427806279547
            // m1 = 42,163702135578391093318580592436
            // u1 = 13,3333
            // p1 = (23,3333; 50)

            // sin(gamma) = 0,44721359549995793928183473374626
            // 1,1071487177940905030170654601785
            // sin(90 - gamma) = 0,89442719099991587856366946749251
            // ns = 20

            // gamma = 26,565051177077989351572193720453
            // m2 = 30 / cos(gamma) = 33,541019662496845446137605030969
            // u2 = 15
            // p2 = (10, 35)
            // y1 = k * x1 + b
            // y2 = k * x2 + b
            // k = (y2 - y1) / (x2 - x1)
            // b = y1 - k * x1
            
            //k3 = 40 / 30 = 1,3333
            //b3 = 10 - 1,3333 * 10 = -3,3333
            // kp = - 1/k
            // y = x * kp + bp
            // y = x * k + b
            // x * (k + 1/k) +b = bp
            // kp3 = - 0,75
            // bp3 = 55
            
            // k1 = 40 / 13,3333 = 3
            // b1 = 10 - 3 * 10 = -20
            // k2 = 15 / 30 = 0.5
            // b2 = 35 - 0.5 * 10 = 30
            // intersection:
            // y = k1 * x + b1
            // y = k2 * x + b2
            // x = (b1 - b2) / (k2 - k1)
            // x = (-20 - 30) / (0.5 - 3) = -50 / -2.5 = 20
            // y = 3 * 20 - 20 = 40
            // incenter = (20; 40)
            // innerRadius = 10
            /*
            triangle.SetPoint(0, new Point(10, 10));
            triangle.SetPoint(1, new Point(10, 40));
            triangle.SetPoint(2, new Point(40, 40));
            */
            _itemMap.AddItem(triangle);
            //_itemMap.AddItem(new GraphicsItems.LinkGraphicsItem(2, 1, new Point(50, 50), new Point(100, 100),
            //    GraphicsItems.LinkGraphicsItem.LinkDirection.Both));
            //_itemMap.AddItem(new GraphicsItems.LineGraphicsItem(2, 1, new Point(50, 50), new Point(100, 100)));
            //_itemMap.AddItem(new GraphicsItems.RectangleGraphicsItem(1, 1, 20, 40, 100, 100));
            //_itemMap.AddItem(new GraphicsItems.RhombGraphicsItem(1, 1, 20, 4, 100, 100));
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
