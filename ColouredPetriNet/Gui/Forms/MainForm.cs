using System.Windows.Forms;
using System.Drawing;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class MainForm : Form
    {
        private enum ItemMapMode { View, Move, AddState, AddTransition, AddMarker, Remove, RemoveMarker};

        private Core.PetriNetGraphicsMap _itemMap;
        private bool _mousePressed;
        private ItemMapMode _mapMode;
        private Core.ColouredStateType _newStateType;
        private Core.ColouredTransitionType _newTransitionType;
        private Core.ColouredMarkerType _newMarkerType;

        public MainForm()
        {
            InitializeComponent();
            _itemMap = new Core.PetriNetGraphicsMap();
            //_itemMap.Overlap = GraphicsItems.OverlapType.Full;
            _mousePressed = false;
            _mapMode = ItemMapMode.View;
            _newStateType = Core.ColouredStateType.RoundState;
            _newTransitionType = Core.ColouredTransitionType.RectangleTransition;
            _newMarkerType = Core.ColouredMarkerType.RoundMarker;
            /*
            ImageList img_list = new ImageList();
            img_list.Images.Add(Properties.Resources.AddRoundStateIcon);
            img_list.Images.Add(Properties.Resources.RemoveIcon);
            trvStates.ImageList = img_list;
            trvStates.Nodes.Add(new TreeNode("State 1", 1, 1));
            trvStates.Nodes.Add(new TreeNode("State 2", 0, 0));
            */
            //_itemMap.AddItem(new GraphicsItems.RoundGraphicsItem(1, 1, new Point(100, 100), 10));
            //_itemMap.AddItem(new GraphicsItems.RhombGraphicsItem(1, 1, new Point(100, 100), 20, 4));
            //_itemMap.AddItem(new GraphicsItems.RectangleGraphicsItem(1, 1, new Point(100, 100), 20, 40));

            //_itemMap.AddItem(new GraphicsItems.LinkGraphicsItem(2, 1, new Point(50, 50), new Point(100, 100),
            //    GraphicsItems.LinkGraphicsItem.LinkDirection.Both));
            //_itemMap.AddItem(new GraphicsItems.LineGraphicsItem(2, 1, new Point(50, 50), new Point(100, 100)));
            //GraphicsItems.TriangleGraphicsItem triangle = new GraphicsItems.TriangleGraphicsItem(0, 0, new Point(100, 100), 40);
            //GraphicsItems.TriangleGraphicsItem triangle = new GraphicsItems.TriangleGraphicsItem(0, 0,
            //    new Point(80, 111), new Point(100, 77), new Point(120, 111));
            //    new Point(10, 10), new Point(10, 50), new Point(40, 50));
            //_itemMap.AddItem(triangle);
        }

        private void ItemMapPaint(object sender, PaintEventArgs e)
        {
            _itemMap.Draw(e.Graphics);
        }

        private void ItemMapMouseClick(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("ItemMapMouseClick");
            switch (_mapMode)
            {
                case ItemMapMode.AddState:
                    _itemMap.AddState(e.X, e.Y, _newStateType);
                    break;
                case ItemMapMode.AddTransition:
                    _itemMap.AddTransition(e.X, e.Y, _newTransitionType);
                    break;
                case ItemMapMode.AddMarker:
                    var selectedStates = _itemMap.FindStates(e.X, e.Y);
                    if (selectedStates.Count > 0)
                    {
                        var state = selectedStates[selectedStates.Count - 1];
                        _itemMap.AddMarker(state.State.Id, _newMarkerType);
                    }
                    break;
            }
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

        private void SetItemMapMode(ItemMapMode mode)
        {
            System.Console.WriteLine("SetItemMapMode: " + mode);
            _mapMode = mode;
        }

        private void SetNewStateType(Core.ColouredStateType type)
        {
            System.Console.WriteLine("SetNewStateType: " + type);
            _newStateType = type;
        }

        private void SetNewTransitionType(Core.ColouredTransitionType type)
        {
            System.Console.WriteLine("SetNewTransitionType: " + type);
            _newTransitionType = type;
        }

        private void SetNewMarkerType(Core.ColouredMarkerType type)
        {
            System.Console.WriteLine("SetNewMarkerType: " + type);
            _newMarkerType = type;
        }
    }
}
