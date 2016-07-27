using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using ColouredPetriNet.Container.GraphicsPetriNet;
using ColouredPetriNet.Container.GraphicsPetriNet.GraphicsItems;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class MainForm : Form
    {
        private enum ItemMapMode
        {
            View, Move, AddState, AddTransition, AddMarker, AddLink, Remove, RemoveMarker
        };
        private enum StateTreeImage { RoundState, ImageState, RoundMarker, RhombMarker, TriangleMarker };
        private enum TransitionTreeImage { RectangleTransition, RhombTransition };

        private GraphicsPetriNet _petriNet;
        private OverlapType _overlap;
        private Core.SelectionArea _selectionArea;
        private Core.Style.ColouredPetriNetStyle _style;
        private bool _mousePressed;
        private bool _itemSelected;
        private Point _lastMousePosition;
        private ItemMapMode _mapMode;
        private TypeInfo _newItemType;
        private StateWrapper _selectedState;
        private TransitionWrapper _selectedTransition;
        private string _currentFile;

        public MainForm()
        {
            _petriNet = new GraphicsPetriNet();
            _style = new Core.Style.ColouredPetriNetStyle();
            InitializeComponent();
            InitPetriNet();
            SetDefaultStyle();
            _newItemType = _petriNet.Types[0];
            _selectionArea = new Core.SelectionArea();
            _overlap = OverlapType.Partial;
            _mousePressed = false;
            _itemSelected = false;
            _selectedState = null;
            _selectedTransition = null;
            _lastMousePosition = new Point();
            _mapMode = ItemMapMode.View;
            _currentFile = null;
            UpdateStatus(GetCurrentMapModeName());
        }

        public void AddType(TypeInfo type)
        {
            _petriNet.Types.Add(type);
            AddTypeToToolbar(type);
            AddTypeStyle(type);
        }

        public void ChangeType(int id, string name, GraphicsPetriNet.ItemType kind, ItemForm form)
        {
            Image image = Core.PetriNetTypeConverter.GetAddItemImage(kind, form);
            string tooltipText = string.Format("Add \"{0}\" item", name);
            if ((!imageListAddState.ChangeItem(id, image, name, tooltipText))
                && (!imageListAddTransition.ChangeItem(id, image, name, tooltipText)))
            {
                imageListAddMarker.ChangeItem(id, image, name, tooltipText);
            }
            _petriNet.Types.ChangeType(id, name, kind, form);
        }

        public void RemoveType(int id)
        {
            if ((!imageListAddState.RemoveItem(id)) && (!imageListAddTransition.RemoveItem(id)))
            {
                imageListAddMarker.RemoveItem(id);
            }
            _petriNet.Types.RemoveById(id);
        }

        private void InitPetriNet()
        {
            _petriNet.Types.Add("RoundState", GraphicsPetriNet.ItemType.State, ItemForm.Round);
            _petriNet.Types.Add("ImageState", GraphicsPetriNet.ItemType.State, ItemForm.Image);
            _petriNet.Types.Add("RectangleTransition", GraphicsPetriNet.ItemType.Transition, ItemForm.Rectangle);
            _petriNet.Types.Add("RhombTransition", GraphicsPetriNet.ItemType.Transition, ItemForm.Rhomb);
            _petriNet.Types.Add("RoundMarker", GraphicsPetriNet.ItemType.Marker, ItemForm.Round);
            _petriNet.Types.Add("RhombMarker", GraphicsPetriNet.ItemType.Marker, ItemForm.Rhomb);
            _petriNet.Types.Add("TriangleMarker", GraphicsPetriNet.ItemType.Marker, ItemForm.Triangle);
            for (int i = 0; i < _petriNet.Types.Count; ++i)
            {
                AddTypeToToolbar(_petriNet.Types[i]);
            }
        }

        private void SetSelectionArea(int x, int y, int w, int h)
        {
            _selectionArea.X = x;
            _selectionArea.Y = y;
            _selectionArea.Width = w;
            _selectionArea.Height = h;
            _selectionArea.Visible = true;
            _selectionArea.HorizontalDirection = Core.HorizontalDirection.Right;
            _selectionArea.VerticalDirection = Core.VerticalDirection.Top;
            _petriNet.Select(x, y, w, h, _overlap);
        }

        private void UpdateSelectionAreaByPos(int x, int y)
        {
            int dx = x - _selectionArea.X;
            int dy = y - _selectionArea.Y;
            _selectionArea.Width = System.Math.Abs(dx);
            _selectionArea.Height = System.Math.Abs(dy);
            if (dx < 0)
            {
                _selectionArea.HorizontalDirection = Core.HorizontalDirection.Left;
                if (dy < 0)
                {
                    _selectionArea.VerticalDirection = Core.VerticalDirection.Bottom;
                    _petriNet.Select(x, y, _selectionArea.Width, _selectionArea.Height, _overlap);
                }
                else
                {
                    _selectionArea.VerticalDirection = Core.VerticalDirection.Top;
                    _petriNet.Select(x, _selectionArea.Y, _selectionArea.Width, _selectionArea.Height, _overlap);
                }
            }
            else
            {
                _selectionArea.HorizontalDirection = Core.HorizontalDirection.Right;
                if (dy < 0)
                {
                    _selectionArea.VerticalDirection = Core.VerticalDirection.Bottom;
                    _petriNet.Select(_selectionArea.X, y, _selectionArea.Width, _selectionArea.Height, _overlap);
                }
                else
                {
                    _selectionArea.VerticalDirection = Core.VerticalDirection.Top;
                    _petriNet.Select(_selectionArea.X, _selectionArea.Y, _selectionArea.Width,
                        _selectionArea.Height, _overlap);
                }
            }
        }

        private void UpdateSelectionArea(int w, int h)
        {
            _selectionArea.Width = w;
            _selectionArea.Height = h;
            _petriNet.Select(_selectionArea.X, _selectionArea.Y, w, h, _overlap);
        }

        private void SetDefaultStyle()
        {
            string appDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = appDir.Substring(0, appDir.Length - "/bin/Debug".Length);
            _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(1, new Core.Style.RoundShapeStyle(10,
                new SolidBrush(Color.FromArgb(0, 240, 0)),
                new Pen(Color.FromArgb(0, 0, 0), 1.0F))));
            _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(2, new Core.Style.ImageShapeStyle(projectDir + "Resources/ImageState32x32.png",
                22, 22)));
            _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(3, new Core.Style.RectangleShapeStyle(20, 20,
                new SolidBrush(Color.FromArgb(220, 220, 0)), new Pen(Color.FromArgb(0, 0, 0), 1.0F))));
            _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(4, new Core.Style.RectangleShapeStyle(20, 20,
                new SolidBrush(Color.FromArgb(220, 220, 0)), new Pen(Color.FromArgb(0, 0, 0), 1.0F))));
            _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(5, new Core.Style.RoundShapeStyle(4, new SolidBrush(Color.FromArgb(150, 0, 220)),
                new Pen(Color.FromArgb(0, 0, 0), 1.0F))));
            _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(6, new Core.Style.RectangleShapeStyle(8, 8,
                new SolidBrush(Color.FromArgb(150, 0, 220)), new Pen(Color.FromArgb(0, 0, 0), 1.0F))));
            _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(7, new Core.Style.TriangleShapeStyle(8,
                new SolidBrush(Color.FromArgb(150, 0, 220)), new Pen(Color.FromArgb(0, 0, 0), 1.0F))));
        }
        
        /*
        private bool Serialize(string filePath)
        {
            var petriNetXml = new Core.Serialize.ColouredPetriNetXml();
            petriNetXml.Style = Core.Serialize.PetriNetXmlSerializer.ToXml(Style);
            petriNetXml.Items = ConvertItemsToXml();
            return Core.Serialize.PetriNetXmlSerializer.Serialize(filePath, petriNetXml);
        }

        private bool Deserialize(string filePath)
        {
            Core.Serialize.ColouredPetriNetXml petriNetXml;
            if (!Core.Serialize.PetriNetXmlSerializer.Deserialize(filePath, out petriNetXml))
            {
                return false;
            }
            Style = Core.Serialize.PetriNetXmlSerializer.FromXml(petriNetXml.Style);
            GetItemsFromXml(petriNetXml.Items);
            return true;
        }
        */

        private void MainFormLoad(object sender, System.EventArgs e)
        {
            UpdateSelectionModeGui();
        }

        private void ItemMapPaint(object sender, PaintEventArgs e)
        {
            _petriNet.Draw(e.Graphics);
            _selectionArea.Draw(e.Graphics);
        }

        private void ItemMapMouseClick(object sender, MouseEventArgs e)
        {
            //System.Console.WriteLine("ItemMapMouseClick");
            int id;

            GraphicsItem graphicsItem = null;
            if (_mapMode == ItemMapMode.AddState || _mapMode == ItemMapMode.AddTransition
                || _mapMode == ItemMapMode.AddMarker)
            {
                id = _petriNet.GetLastItemId() + 1;
                switch (_newItemType.Form)
                {
                    case ItemForm.Round:
                        graphicsItem = new RoundGraphicsItem(id, _newItemType.Id, e.Location, 10);
                        break;
                    case ItemForm.Rectangle:
                        graphicsItem = new RectangleGraphicsItem(id, _newItemType.Id, e.Location,
                            20, 20);
                        break;
                    case ItemForm.Rhomb:
                        graphicsItem = new RhombGraphicsItem(id, _newItemType.Id, e.Location,
                            20, 20);
                        break;
                    case ItemForm.Triangle:
                        graphicsItem = new TriangleGraphicsItem(id, _newItemType.Id, e.Location, 15);
                        break;
                    case ItemForm.Image:
                        graphicsItem = new ImageGraphicsItem(id, _newItemType.Id,
                            Properties.Resources.ImageStateIcon, e.Location, 20, 20);
                        break;
                }
            }
            switch (_mapMode)
            {
                case ItemMapMode.AddState:
                    _petriNet.States.Add(graphicsItem);
                    //AddStateToTree(id, _newStateType);
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddTransition:
                    _petriNet.Transitions.Add(graphicsItem);
                    //AddTransitionToTree(id, _newTransitionType);
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddMarker:
                    var selectedStates = _petriNet.States.Find(e.X, e.Y);
                    if (selectedStates.Count > 0)
                    {
                        var state = selectedStates[selectedStates.Count - 1];
                        _petriNet.Markers.Add(state.State.Id, graphicsItem);
                        //AddMarkerToTree(id, state.State.Id);
                    }
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddLink:
                    if (_itemSelected)
                    {
                        if (!ReferenceEquals(_selectedState, null))
                        {
                            var chosenTransitions = _petriNet.Transitions.Find(e.X, e.Y);
                            if (chosenTransitions.Count > 0)
                            {
                                _petriNet.Links.Add(_selectedState.State.Id, chosenTransitions[0].Transition.Id,
                                    LinkDirection.FromStateToTransition);
                            }
                        }
                        else
                        {
                            var chosenStates = _petriNet.States.Find(e.X, e.Y);
                            if (chosenStates.Count > 0)
                            {
                                _petriNet.Links.Add(chosenStates[0].State.Id, _selectedTransition.Transition.Id,
                                    LinkDirection.FromTransitionToState);
                            }
                        }
                        _petriNet.DeselectItems();
                        _selectedState = null;
                        _selectedTransition = null;
                        _itemSelected = false;
                    }
                    else
                    {
                        var chosenStates = _petriNet.States.Find(e.X, e.Y);
                        if (chosenStates.Count > 0)
                        {
                            _selectedState = chosenStates[0];
                            _itemSelected = true;
                            _selectedState.State.Select();
                        }
                        else
                        {
                            var chosenTransitions = _petriNet.Transitions.Find(e.X, e.Y);
                            if (chosenTransitions.Count > 0)
                            {
                                _selectedTransition = chosenTransitions[0];
                                _itemSelected = true;
                                _selectedTransition.Transition.Select();
                            }
                        }
                    }
                    pbMap.Refresh();
                    break;
                case ItemMapMode.RemoveMarker:
                    var chosenStates2 = _petriNet.States.Find(e.X, e.Y);
                    if (chosenStates2.Count > 0)
                    {
                        dlgRemoveMarker.ShowDialog(chosenStates2[0]);
                    }
                    break;
            }
        }

        private void ItemMapMouseDown(object sender, MouseEventArgs e)
        {
            /*
            if ((_mapMode == ItemMapMode.AddState) || (_mapMode == ItemMapMode.AddTransition)
                || (_mapMode == ItemMapMode.AddMarker) || (_mapMode == ItemMapMode.AddLink)
                || (_mapMode == ItemMapMode.RemoveMarker))
            {
                return;
            }
            //System.Console.WriteLine("ItemMapMouseDown");
            _mousePressed = true;
            _lastMousePosition = e.Location;
            if (_mapMode == ItemMapMode.Move)
            {
                var chosenStates = _petriNet.FindStates(e.X, e.Y);
                if (chosenStates.Count > 0)
                {
                    var selectedState = GetSelectedState(chosenStates);
                    if (ReferenceEquals(selectedState, null))
                    {
                        _petriNet.DeselectItems();
                        _petriNet.SetSelectionArea(e.X, e.Y, 1, 1);
                        _petriNet.HideSelectionArea();
                    }
                    _itemSelected = true;
                }
                else
                {
                    var chosenTransitions = _petriNet.FindTransitions(e.X, e.Y);
                    if (chosenTransitions.Count > 0)
                    {
                        var selectedTransition = GetSelectedTransition(chosenTransitions);
                        if (ReferenceEquals(selectedTransition, null))
                        {
                            _petriNet.DeselectItems();
                            _petriNet.SetSelectionArea(e.X, e.Y, 1, 1);
                            _petriNet.HideSelectionArea();
                        }
                        _itemSelected = true;
                    }
                    else
                    {
                        var chosenLinks = _petriNet.FindLinks(e.X, e.Y);
                        if (chosenLinks.Count > 0)
                        {
                            var selectedLink = GetSelectedLink(chosenLinks);
                            if (ReferenceEquals(selectedLink, null))
                            {
                                _petriNet.DeselectItems();
                                _petriNet.SetSelectionArea(e.X, e.Y, 1, 1);
                                _petriNet.HideSelectionArea();
                            }
                            _itemSelected = true;
                        }
                        else
                        {
                            _petriNet.DeselectItems();
                            _petriNet.SetSelectionArea(e.X, e.Y, 1, 1);
                        }
                    }
                }
            }
            else
            {

                _petriNet.DeselectItems();
                _petriNet.SetSelectionArea(e.X, e.Y, 1, 1);
            }
            this.pbMap.Refresh();
            */
        }

        private void ItemMapMouseMove(object sender, MouseEventArgs e)
        {
            /*
            if (_mousePressed)
            {
                System.Console.WriteLine("ItemMapMouseMove");
                if ((_mapMode == ItemMapMode.Move) && (_itemSelected))
                {
                    _petriNet.MoveSelectedItems(e.X - _lastMousePosition.X, e.Y - _lastMousePosition.Y);
                    _lastMousePosition = e.Location;
                }
                else
                {
                    _petriNet.UpdateSelectionAreaByPos(e.X, e.Y);
                }
                this.pbMap.Refresh();
            }
            */
        }

        private void ItemMapMouseUp(object sender, MouseEventArgs e)
        {
            /*
            if (!_mousePressed)
            {
                return;
            }
            //System.Console.WriteLine("ItemMapMouseUp");
            _mousePressed = false;
            if (_mapMode != ItemMapMode.AddLink)
            {
                _itemSelected = false;
            }
            _petriNet.HideSelectionArea();
            this.pbMap.Refresh();
            */
        }

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            /*
            if ((_mapMode == ItemMapMode.Remove) && (e.KeyCode == Keys.Delete))
            {
                var setecledStates = _petriNet.GetSelectedStates();
                for (int i = 0; i < setecledStates.Count; ++i)
                {
                    for (int j = trvStates.Nodes.Count - 1; j >= 0; --j)
                    {
                        if ((int)trvStates.Nodes[j].Tag == setecledStates[i])
                        {
                            trvStates.Nodes.RemoveAt(j);
                            break;
                        }
                    }
                }
                var setecledTransitions = _petriNet.GetSelectedTransitions();
                for (int i = 0; i < setecledTransitions.Count; ++i)
                {
                    for (int j = trvTransitions.Nodes.Count - 1; j >= 0; --j)
                    {
                        if ((int)trvTransitions.Nodes[j].Tag == setecledTransitions[i])
                        {
                            trvTransitions.Nodes.RemoveAt(j);
                            break;
                        }
                    }
                }
                _petriNet.RemoveSelectedItems();
                pbMap.Refresh();
            }
            */
        }

        private void AddTypeStyle(TypeInfo type)
        {
            switch (type.Form)
            {
                case ItemForm.Round:
                    _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(type.Id,
                        new Core.Style.RoundShapeStyle(20)));
                    break;
                case ItemForm.Rectangle:
                    _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(type.Id,
                        new Core.Style.RectangleShapeStyle(20, 20)));
                    break;
                case ItemForm.Rhomb:
                    _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(type.Id,
                        new Core.Style.RectangleShapeStyle(20, 20)));
                    break;
                case ItemForm.Triangle:
                    _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(type.Id,
                        new Core.Style.TriangleShapeStyle(10)));
                    break;
                case ItemForm.Image:
                    _style.Items.Add(new Core.Style.PetriNetItemTypeStyle(type.Id,
                        new Core.Style.ImageShapeStyle("", 20, 20)));
                    break;
            }
        }

        private void AddTypeToToolbar(TypeInfo type)
        {
            Image image = null;
            switch (type.Kind)
            {
                case GraphicsPetriNet.ItemType.State:
                    switch (type.Form)
                    {
                        case ItemForm.Round:
                            image = Properties.Resources.AddRoundStateIcon;
                            break;
                        case ItemForm.Rectangle:
                            image = Properties.Resources.AddRectangleStateIcon;
                            break;
                        case ItemForm.Rhomb:
                            image = Properties.Resources.AddRhombStateIcon;
                            break;
                        case ItemForm.Triangle:
                            image = Properties.Resources.AddTriangleStateIcon;
                            break;
                        case ItemForm.Image:
                            image = Properties.Resources.AddImageStateIcon;
                            break;
                    }
                    imageListAddState.AddItem(type.Id, image, type.Name,
                        string.Format("Add \"{0}\" item", type.Name));
                    imageListAddState.DropDown.Items[imageListAddState.DropDown.Items.Count - 1].Click += (obj, e) =>
                        SetNewItemType(type);
                    break;
                case GraphicsPetriNet.ItemType.Transition:
                    switch (type.Form)
                    {
                        case ItemForm.Round:
                            image = Properties.Resources.AddRoundTransitionIcon;
                            break;
                        case ItemForm.Rectangle:
                            image = Properties.Resources.AddRectangleTransitionIcon;
                            break;
                        case ItemForm.Rhomb:
                            image = Properties.Resources.AddRhombTransitionIcon;
                            break;
                        case ItemForm.Triangle:
                            image = Properties.Resources.AddTriangleTransitionIcon;
                            break;
                        case ItemForm.Image:
                            image = Properties.Resources.AddImageTransitionIcon;
                            break;
                    }
                    imageListAddTransition.AddItem(type.Id, image, type.Name,
                        string.Format("Add \"{0}\" item", type.Name));
                    imageListAddTransition.DropDown.Items[imageListAddTransition.DropDown.Items.Count - 1].Click += (obj, e) =>
                        SetNewItemType(type);
                    break;
                case GraphicsPetriNet.ItemType.Marker:
                    switch (type.Form)
                    {
                        case ItemForm.Round:
                            image = Properties.Resources.AddRoundMarkerIcon;
                            break;
                        case ItemForm.Rectangle:
                            image = Properties.Resources.AddRectangleMarkerIcon;
                            break;
                        case ItemForm.Rhomb:
                            image = Properties.Resources.AddRhombMarkerIcon;
                            break;
                        case ItemForm.Triangle:
                            image = Properties.Resources.AddTriangleMarkerIcon;
                            break;
                        case ItemForm.Image:
                            image = Properties.Resources.AddImageMarkerIcon;
                            break;
                    }
                    imageListAddMarker.AddItem(type.Id, image, type.Name,
                        string.Format("Add \"{0}\" item", type.Name));
                    imageListAddMarker.DropDown.Items[imageListAddMarker.DropDown.Items.Count - 1].Click += (obj, e) =>
                        SetNewItemType(type);
                    break;
            }
        }

        private void SetItemMapMode(ItemMapMode mode)
        {
            _petriNet.DeselectItems();
            _selectionArea.Visible = false;
            _mousePressed = false;
            _itemSelected = false;
            _selectedState = null;
            _selectedTransition = null;
            pbMap.Refresh();
            if (_mapMode == mode)
                return;
            /*
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
            */
            _mapMode = mode;
            UpdateStatus(GetCurrentMapModeName());
        }

        private void SetSelectionMode(OverlapType overlap)
        {
            //_petriNet.Style.SelectionMode = overlap;
            _overlap = overlap;
        }

        private void SetNewItemType(TypeInfo type)
        {
            _newItemType = type;
            UpdateStatus(GetCurrentMapModeName());
        }

        private StateWrapper GetSelectedState(List<StateWrapper> stateList)
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

        private TransitionWrapper GetSelectedTransition(List<TransitionWrapper> transitionList)
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

        private LinkWrapper GetSelectedLink(List<LinkWrapper> linkList)
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
            if (_overlap == OverlapType.Full)
            {
                this.mniSelectionModeFull.Checked = true;
            }
            else
            {
                this.mniSelectionModePartial.Checked = true;
            }
        }

        private int FindStateIndexInTreeView(int id)
        {
            for (int i = 0;  i < trvStates.Nodes.Count; ++i)
            {
                if ((int)trvStates.Nodes[i].Tag == id)
                {
                    return i;
                }
            }
            return -1;
        }

        private void LoadFromFile()
        {
            /*
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                ClearMap();
                if (_petriNet.Deserialize(dlgOpenFile.FileName))
                {
                    _currentFile = dlgOpenFile.FileName;
                    pbMap.Refresh();
                }
                else
                {
                    pbMap.Refresh();
                    MessageBox.Show("Error: Could not load file!");
                }
            }
            */
        }

        private void SaveToFile()
        {
            /*
            if (_currentFile == null)
            {
                SaveFileAs();
            }
            else
            {
                if (!_petriNet.Serialize(_currentFile))
                {
                    MessageBox.Show("Error: Could not save file!");
                }
            }
            */
        }

        private void SaveFileAs()
        {
            /*
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                System.Console.WriteLine("File:{0}", dlgSaveFile.FileName);
                if (_petriNet.Serialize(dlgSaveFile.FileName))
                {
                    _currentFile = dlgSaveFile.FileName;
                }
                else
                {
                    MessageBox.Show("Error: Could not save file!");
                }
            }
            */
        }

        private void ClearMarkers(int stateId)
        {
            ClearMarkersFromStateTree(stateId);
            _petriNet.Markers.RemoveFromState(stateId);
            pbMap.Refresh();
        }

        private void RemoveMarkers(int stateId, List<int> markers)
        {
            for (int i = 0; i < markers.Count; ++i)
            {
                RemoveMarkerFromStateTree(markers[i], stateId);
                _petriNet.Markers.Remove(markers[i]);
                pbMap.Refresh();
            }
        }

        private void ClearMarkersFromStateTree(int stateId)
        {
            for (int i = 0; i < trvStates.Nodes.Count; ++i)
            {
                if ((int)trvStates.Nodes[i].Tag == stateId)
                {
                    trvStates.Nodes[i].Nodes.Clear();
                    return;
                }
            }
        }

        private void RemoveMarkerFromStateTree(int id, int stateId)
        {
            for (int i = 0; i < trvStates.Nodes.Count; ++i)
            {
                if ((int)trvStates.Nodes[i].Tag == stateId)
                {
                    for (int j = 0; j < trvStates.Nodes[i].Nodes.Count; ++j)
                    {
                        if ((int)trvStates.Nodes[i].Nodes[j].Tag == id)
                        {
                            trvStates.Nodes[i].Nodes.RemoveAt(j);
                            return;
                        }
                    }
                    return;
                }
            }
        }

        private void UpdateStatus(string operation)
        {
            lblStatusText.Text = string.Format("Current operation: \"{0}\"", operation);
            stsStatus.Refresh();
        }

        private string GetCurrentMapModeName()
        {
            switch (_mapMode)
            {
                case ItemMapMode.AddLink:
                    return "Add Link";
                case ItemMapMode.RemoveMarker:
                    return "Remove Marker";
                case ItemMapMode.AddState:
                    return "Add State";
                case ItemMapMode.AddTransition:
                    return "Add Transition";
                case ItemMapMode.AddMarker:
                    return "Add Marker";
                default:
                    return _mapMode.ToString();
            }
        }

        private void AddStateToTree(int id, Core.ColouredStateType type)
        {
            TreeNode treeNode;
            if (type == Core.ColouredStateType.RoundState)
            {
                treeNode = new TreeNode("State " + id.ToString(),
                    (int)StateTreeImage.RoundState, (int)StateTreeImage.RoundState);
                treeNode.Tag = id;
                trvStates.Nodes.Add(treeNode);
            }
            else if (type == Core.ColouredStateType.ImageState)
            {
                treeNode = new TreeNode("State " + id.ToString(),
                    (int)StateTreeImage.ImageState, (int)StateTreeImage.ImageState);
                treeNode.Tag = id;
                trvStates.Nodes.Add(treeNode);
            }
        }

        private void AddTransitionToTree(int id, Core.ColouredTransitionType type)
        {
            TreeNode treeNode;
            if (type == Core.ColouredTransitionType.RectangleTransition)
            {
                treeNode = new TreeNode("Transition " + id.ToString(),
                    (int)TransitionTreeImage.RectangleTransition,
                    (int)TransitionTreeImage.RectangleTransition);
                treeNode.Tag = id;
                trvTransitions.Nodes.Add(treeNode);
            }
            else if (type == Core.ColouredTransitionType.RhombTransition)
            {
                treeNode = new TreeNode("Transition " + id.ToString(),
                    (int)TransitionTreeImage.RhombTransition,
                    (int)TransitionTreeImage.RhombTransition);
                treeNode.Tag = id;
                trvTransitions.Nodes.Add(treeNode);
            }
        }

        private void AddMarkerToTree(int id, int stateId)
        {
            TreeNode treeNode;
            int stateIndex = FindStateIndexInTreeView(stateId);
            /*
            if (_newMarkerType == Core.ColouredMarkerType.RoundMarker)
            {
                treeNode = new TreeNode("Marker " + id.ToString(),
                    (int)StateTreeImage.RoundMarker, (int)StateTreeImage.RoundMarker);
                treeNode.Tag = id;
                trvStates.Nodes[stateIndex].Nodes.Add(treeNode);
            }
            else if (_newMarkerType == Core.ColouredMarkerType.RhombMarker)
            {
                treeNode = new TreeNode("Marker " + id.ToString(),
                    (int)StateTreeImage.RhombMarker, (int)StateTreeImage.RhombMarker);
                treeNode.Tag = id;
                trvStates.Nodes[stateIndex].Nodes.Add(treeNode);
            }
            else if (_newMarkerType == Core.ColouredMarkerType.TriangleMarker)
            {
                treeNode = new TreeNode("Marker " + id.ToString(),
                    (int)StateTreeImage.TriangleMarker, (int)StateTreeImage.TriangleMarker);
                treeNode.Tag = id;
                trvStates.Nodes[stateIndex].Nodes.Add(treeNode);
            }
            */
        }

        private void AddStateToTree(object sender, Core.Events.ExtendedStateEventArgs state)
        {
            TreeNode treeNode;
            int typeId = state.TypeId - (int)Core.PetriNetItemInfo.ItemType.State;
            switch (typeId)
            {
                case (int)Core.ColouredStateType.RoundState:
                    AddStateToTree(state.Id, Core.ColouredStateType.RoundState);
                    break;
                case (int)Core.ColouredStateType.ImageState:
                    AddStateToTree(state.Id, Core.ColouredStateType.ImageState);
                    break;
            }
            int stateIndex = trvStates.Nodes.Count - 1;
            for (int i = 0; i < state.Markers.Count; ++i)
            {
                typeId = state.Markers[i].Item2 - (int)Core.PetriNetItemInfo.ItemType.Marker;
                if (typeId == (int)Core.ColouredMarkerType.RoundMarker)
                {
                    treeNode = new TreeNode("Marker " + state.Markers[i].Item1.ToString(),
                        (int)StateTreeImage.RoundMarker, (int)StateTreeImage.RoundMarker);
                    treeNode.Tag = state.Markers[i].Item1;
                    trvStates.Nodes[stateIndex].Nodes.Add(treeNode);
                }
                else if (typeId == (int)Core.ColouredMarkerType.RhombMarker)
                {
                    treeNode = new TreeNode("Marker " + state.Markers[i].Item1.ToString(),
                        (int)StateTreeImage.RhombMarker, (int)StateTreeImage.RhombMarker);
                    treeNode.Tag = state.Markers[i].Item1;
                    trvStates.Nodes[stateIndex].Nodes.Add(treeNode);
                }
                else if (typeId == (int)Core.ColouredMarkerType.TriangleMarker)
                {
                    treeNode = new TreeNode("Marker " + state.Markers[i].Item1.ToString(),
                        (int)StateTreeImage.TriangleMarker, (int)StateTreeImage.TriangleMarker);
                    treeNode.Tag = state.Markers[i].Item1;
                    trvStates.Nodes[stateIndex].Nodes.Add(treeNode);
                }
            }
        }

        private void AddTransitionToTree(object sender, Core.Events.PetriNetNodeEventArgs transition)
        {
            int typeId = transition.TypeId - (int)Core.PetriNetItemInfo.ItemType.Transition;
            switch (typeId)
            {
                case (int)Core.ColouredTransitionType.RectangleTransition:
                    AddTransitionToTree(transition.Id, Core.ColouredTransitionType.RectangleTransition);
                    break;
                case (int)Core.ColouredTransitionType.RhombTransition:
                    AddTransitionToTree(transition.Id, Core.ColouredTransitionType.RhombTransition);
                    break;
            }
        }

        private void ClearMap()
        {
            trvStates.Nodes.Clear();
            trvTransitions.Nodes.Clear();
            _petriNet.Clear();
        }

        private void FindItemInfo(object sender, Core.Events.ShowInfoEventArgs e)
        {
            switch (e.Type)
            {
                case Core.Events.ShowInfoEventArgs.ItemType.State:
                    ShowStateInfoForm(_petriNet.States[e.Id]);
                    break;
                case Core.Events.ShowInfoEventArgs.ItemType.Transition:
                    ShowTransitionInfoForm(_petriNet.Transitions[e.Id]);
                    break;
                case Core.Events.ShowInfoEventArgs.ItemType.Marker:
                    ShowMarkerInfoForm(_petriNet.Markers[e.Id]);
                    break;
            }
        }

        private void ShowStateInfoForm(StateWrapper state)
        {
            if (state == null)
            {
                MessageBox.Show("Error: State with this id not found!");
            }
            else
            {
                dlgShowItemInfo.Hide();
                dlgStateInfo.ShowDialog(state);
            }
        }

        private void ShowTransitionInfoForm(TransitionWrapper transition)
        {
            if (transition == null)
            {
                MessageBox.Show("Error: Transition with this id not found!");
            }
            else
            {
                dlgShowItemInfo.Hide();
                dlgTransitionInfo.ShowDialog(transition);
            }
        }

        private void ShowMarkerInfoForm(MarkerInfo marker)
        {
            if (marker.Id < 0)
            {
                MessageBox.Show("Error: Marker with this id not found!");
            }
            else
            {
                dlgShowItemInfo.Hide();
                dlgMarkerInfo.ShowDialog(marker.Id, marker.StateId,
                    Core.PetriNetItemInfo.GetMarkerTypeName(marker.Type));
            }
        }
    }
}
