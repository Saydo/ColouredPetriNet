using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class MainForm : Form
    {
        private enum ItemMapMode { View, Move, AddState, AddTransition, AddMarker, AddLink, Remove, RemoveMarker};

        private Core.PetriNetGraphicsMap _itemMap;
        private bool _mousePressed;
        private bool _itemSelected;
        private Point _lastMousePosition;
        private ItemMapMode _mapMode;
        private Core.ColouredStateType _newStateType;
        private Core.ColouredTransitionType _newTransitionType;
        private Core.ColouredMarkerType _newMarkerType;
        private Core.GraphicsStateWrapper _selectedState;
        private Core.GraphicsTransitionWrapper _selectedTransition;

        public MainForm()
        {
            InitializeComponent();
            _itemMap = new Core.PetriNetGraphicsMap();
            //_itemMap.Overlap = GraphicsItems.OverlapType.Full;
            _mousePressed = false;
            _itemSelected = false;
            _selectedState = null;
            _selectedTransition = null;
            _lastMousePosition = new Point();
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

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            UpdateSelectionModeGui();
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
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddTransition:
                    _itemMap.AddTransition(e.X, e.Y, _newTransitionType);
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddMarker:
                    var selectedStates = _itemMap.FindStates(e.X, e.Y);
                    if (selectedStates.Count > 0)
                    {
                        var state = selectedStates[selectedStates.Count - 1];
                        _itemMap.AddMarker(state.State.Id, _newMarkerType);
                    }
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddLink:
                    if (_itemSelected)
                    {
                        System.Console.WriteLine("AddLine: select");
                        if (!ReferenceEquals(_selectedState, null))
                        {
                            var chosenTransitions = _itemMap.FindTransitions(e.X, e.Y);
                            if (chosenTransitions.Count > 0)
                            {
                                _itemMap.AddLink(_selectedState.State.Id, chosenTransitions[0].Transition.Id,
                                    Core.LinkDirection.FromStateToTransition);
                            }
                        }
                        else
                        {
                            var chosenStates = _itemMap.FindStates(e.X, e.Y);
                            if (chosenStates.Count > 0)
                            {
                                _itemMap.AddLink(chosenStates[0].State.Id, _selectedTransition.Transition.Id,
                                    Core.LinkDirection.FromTransitionToState);
                            }
                        }
                        _itemMap.DeselectItems();
                        _selectedState = null;
                        _selectedTransition = null;
                        _itemSelected = false;
                    }
                    else
                    {
                        System.Console.WriteLine("AddLine: non select");
                        var chosenStates = _itemMap.FindStates(e.X, e.Y);
                        if (chosenStates.Count > 0)
                        {
                            System.Console.WriteLine("AddLine: find states");
                            _selectedState = chosenStates[0];
                            _itemSelected = true;
                        }
                        else
                        {
                            var chosenTransitions = _itemMap.FindTransitions(e.X, e.Y);
                            if (chosenTransitions.Count > 0)
                            {
                                System.Console.WriteLine("AddLine: find transitions");
                                _selectedTransition = chosenTransitions[0];
                                _itemSelected = true;
                            }
                        }
                    }
                    pbMap.Refresh();
                    break;
            }
        }

        private void ItemMapMouseDown(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("ItemMapMouseDown");
            _mousePressed = true;
            _lastMousePosition = e.Location;
            if (_mapMode == ItemMapMode.Move)
            {
                var chosenStates = _itemMap.FindStates(e.X, e.Y);
                if (chosenStates.Count > 0)
                {
                    var selectedState = GetSelectedState(chosenStates);
                    if (ReferenceEquals(selectedState, null))
                    {
                        _itemMap.DeselectItems();
                        _itemMap.SetSelectionArea(e.X, e.Y, 1, 1);
                        _itemMap.HideSelectionArea();
                    }
                    _itemSelected = true;
                }
                else
                {
                    var chosenTransitions = _itemMap.FindTransitions(e.X, e.Y);
                    if (chosenTransitions.Count > 0)
                    {
                        var selectedTransition = GetSelectedTransition(chosenTransitions);
                        if (ReferenceEquals(selectedTransition, null))
                        {
                            _itemMap.DeselectItems();
                            _itemMap.SetSelectionArea(e.X, e.Y, 1, 1);
                            _itemMap.HideSelectionArea();
                        }
                        _itemSelected = true;
                    }
                    else
                    {
                        var chosenLinks = _itemMap.FindLinks(e.X, e.Y);
                        if (chosenLinks.Count > 0)
                        {
                            var selectedLink = GetSelectedLink(chosenLinks);
                            if (ReferenceEquals(selectedLink, null))
                            {
                                _itemMap.DeselectItems();
                                _itemMap.SetSelectionArea(e.X, e.Y, 1, 1);
                                _itemMap.HideSelectionArea();
                            }
                            _itemSelected = true;
                        }
                        else
                        {
                            _itemMap.DeselectItems();
                            _itemMap.SetSelectionArea(e.X, e.Y, 1, 1);
                        }
                    }
                }
            }
            else if ((_mapMode == ItemMapMode.View) || (_mapMode == ItemMapMode.Move)
                || (_mapMode == ItemMapMode.Remove) || (_mapMode == ItemMapMode.RemoveMarker))
            {

                _itemMap.DeselectItems();
                _itemMap.SetSelectionArea(e.X, e.Y, 1, 1);
            }
            this.pbMap.Refresh();
        }

        private void ItemMapMouseMove(object sender, MouseEventArgs e)
        {
            if (_mousePressed)
            {
                System.Console.WriteLine("ItemMapMouseMove");
                if ((_mapMode == ItemMapMode.Move) && (_itemSelected))
                {
                    _itemMap.MoveSelectedItems(e.X - _lastMousePosition.X, e.Y - _lastMousePosition.Y);
                    _lastMousePosition = e.Location;
                }
                else
                {
                    _itemMap.UpdateSelectionAreaByPos(e.X, e.Y);
                }
                this.pbMap.Refresh();
            }
        }

        private void ItemMapMouseUp(object sender, MouseEventArgs e)
        {
            System.Console.WriteLine("ItemMapMouseUp");
            _mousePressed = false;
            if (_mapMode != ItemMapMode.AddLink)
            {
                _itemSelected = false;
            }
            _itemMap.HideSelectionArea();
            this.pbMap.Refresh();
        }

        private void SetItemMapMode(ItemMapMode mode)
        {
            _itemMap.DeselectItems();
            _itemMap.HideSelectionArea();
            _mousePressed = false;
            _itemSelected = false;
            pbMap.Refresh();
            if (_mapMode == mode)
                return;
            switch (_mapMode)
            {
                case ItemMapMode.AddState:
                    mniSetModeAddRoundState.Checked = false;
                    mniSetModeAddImageState.Checked = false;
                    break;
                case ItemMapMode.AddTransition:
                    mniSetModeAddRectangleTransition.Checked = false;
                    mniSetModeAddRhombTransition.Checked = false;
                    break;
                case ItemMapMode.AddMarker:
                    mniSetModeAddRoundMarker.Checked = false;
                    mniSetModeAddRhombMarker.Checked = false;
                    mniSetModeAddTriangleMarker.Checked = false;
                    break;
            }
            switch (mode)
            {
                case ItemMapMode.AddState:
                    if (_newStateType == Core.ColouredStateType.RoundState)
                    {
                        mniSetModeAddRoundState.Checked = true;
                    }
                    else
                    {
                        mniSetModeAddImageState.Checked = true;
                    }
                    break;
                case ItemMapMode.AddTransition:
                    if (_newTransitionType == Core.ColouredTransitionType.RectangleTransition)
                    {
                        mniSetModeAddRectangleTransition.Checked = true;
                    }
                    else
                    {
                        mniSetModeAddRhombTransition.Checked = true;
                    }
                    break;
                case ItemMapMode.AddMarker:
                    if (_newMarkerType == Core.ColouredMarkerType.RoundMarker)
                    {
                        mniSetModeAddRoundMarker.Checked = true;
                    }
                    else if (_newMarkerType == Core.ColouredMarkerType.RhombMarker)
                    {
                        mniSetModeAddRhombMarker.Checked = true;
                    }
                    else
                    {
                        mniSetModeAddTriangleMarker.Checked = true;
                    }
                    break;
            }
            _mapMode = mode;

        }

        private void SetSelectionMode(Core.GraphicsItems.OverlapType overlap)
        {
            _itemMap.Style.SelectionMode = overlap;
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

        private Core.GraphicsStateWrapper GetSelectedState(List<Core.GraphicsStateWrapper> stateList)
        {
            for (int i = 0; i < stateList.Count; ++i)
            {
                if (stateList[i].State.IsSelected())
                {
                    return stateList[i];
                }
            }
            return null;
        }

        private Core.GraphicsTransitionWrapper GetSelectedTransition(List<Core.GraphicsTransitionWrapper> transitionList)
        {
            for (int i = 0; i < transitionList.Count; ++i)
            {
                if (transitionList[i].Transition.IsSelected())
                {
                    return transitionList[i];
                }
            }
            return null;
        }

        private Core.GraphicsLinkWrapper GetSelectedLink(List<Core.GraphicsLinkWrapper> linkList)
        {
            for (int i = 0; i < linkList.Count; ++i)
            {
                if (linkList[i].Link.IsSelected())
                {
                    return linkList[i];
                }
            }
            return null;
        }

        private void UpdateSelectionModeGui()
        {
            if (_itemMap.Style.SelectionMode == Core.GraphicsItems.OverlapType.Full)
            {
                this.mniSelectionModeFull.Checked = true;
            }
            else
            {
                this.mniSelectionModePartial.Checked = true;
            }
        }
    }
}
