﻿using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

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
        private string _currentFile;

        public MainForm()
        {
            InitializeComponent();
            _itemMap = new Core.PetriNetGraphicsMap();
            _mousePressed = false;
            _itemSelected = false;
            _selectedState = null;
            _selectedTransition = null;
            _lastMousePosition = new Point();
            _mapMode = ItemMapMode.View;
            _newStateType = Core.ColouredStateType.RoundState;
            _newTransitionType = Core.ColouredTransitionType.RectangleTransition;
            _newMarkerType = Core.ColouredMarkerType.RoundMarker;
            _currentFile = null;
        }

        public void ClearMarkers(int stateId)
        {
            ClearMarkersFromStateTree(stateId);
            _itemMap.RemoveMarkers(stateId);
            pbMap.Refresh();
        }

        public void RemoveMarker(int id, int stateId)
        {
            RemoveMarkerFromStateTree(id, stateId);
            _itemMap.RemoveMarker(id, stateId);
            pbMap.Refresh();
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
            //System.Console.WriteLine("ItemMapMouseClick");
            int id;
            TreeNode treeNode;
            switch (_mapMode)
            {
                case ItemMapMode.AddState:
                    id = _itemMap.AddState(e.X, e.Y, _newStateType);
                    if (_newStateType == Core.ColouredStateType.RoundState)
                    {
                        treeNode = new TreeNode("State " + id.ToString(),
                            (int)StateTreeImage.RoundState, (int)StateTreeImage.RoundState);
                        treeNode.Tag = id;
                        trvStates.Nodes.Add(treeNode);
                    }
                    else if (_newStateType == Core.ColouredStateType.ImageState)
                    {
                        treeNode = new TreeNode("State " + id.ToString(),
                            (int)StateTreeImage.ImageState, (int)StateTreeImage.ImageState);
                        treeNode.Tag = id;
                        trvStates.Nodes.Add(treeNode);
                    }
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddTransition:
                    id = _itemMap.AddTransition(e.X, e.Y, _newTransitionType);
                    if (_newTransitionType == Core.ColouredTransitionType.RectangleTransition)
                    {
                        treeNode = new TreeNode("Transition " + id.ToString(),
                            (int)TransitionTreeImage.RectangleTransition,
                            (int)TransitionTreeImage.RectangleTransition);
                        treeNode.Tag = id;
                        trvTransitions.Nodes.Add(treeNode);
                    }
                    else if (_newTransitionType == Core.ColouredTransitionType.RhombTransition)
                    {
                        treeNode = new TreeNode("Transition " + id.ToString(),
                            (int)TransitionTreeImage.RhombTransition,
                            (int)TransitionTreeImage.RhombTransition);
                        treeNode.Tag = id;
                        trvTransitions.Nodes.Add(treeNode);
                    }
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddMarker:
                    var selectedStates = _itemMap.FindStates(e.X, e.Y);
                    if (selectedStates.Count > 0)
                    {
                        var state = selectedStates[selectedStates.Count - 1];
                        id = _itemMap.AddMarker(state.State.Id, _newMarkerType);
                        int stateIndex= FindStateIndexInTreeView(state.State.Id);
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
                    }
                    pbMap.Refresh();
                    break;
                case ItemMapMode.AddLink:
                    if (_itemSelected)
                    {
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
                        var chosenStates = _itemMap.FindStates(e.X, e.Y);
                        if (chosenStates.Count > 0)
                        {
                            _selectedState = chosenStates[0];
                            _itemSelected = true;
                            _selectedState.State.Select();
                        }
                        else
                        {
                            var chosenTransitions = _itemMap.FindTransitions(e.X, e.Y);
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
                    var chosenStates2 = _itemMap.FindStates(e.X, e.Y);
                    if (chosenStates2.Count > 0)
                    {
                        dlgRemoveMarker.SelectedState = chosenStates2[0];
                        dlgRemoveMarker.ShowDialog();
                    }
                    break;
            }
        }

        private void ItemMapMouseDown(object sender, MouseEventArgs e)
        {
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
            else
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
            _itemMap.HideSelectionArea();
            this.pbMap.Refresh();
        }

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            if ((_mapMode == ItemMapMode.Remove) && (e.KeyCode == Keys.Delete))
            {
                var setecledStates = _itemMap.GetSelectedStates();
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
                var setecledTransitions = _itemMap.GetSelectedTransitions();
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
                _itemMap.RemoveSelectedItems();
                pbMap.Refresh();
            }
        }

        private void SetItemMapMode(ItemMapMode mode)
        {
            _itemMap.DeselectItems();
            _itemMap.HideSelectionArea();
            _mousePressed = false;
            _itemSelected = false;
            _selectedState = null;
            _selectedTransition = null;
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
            //System.Console.WriteLine("SetNewStateType: " + type);
            _newStateType = type;
        }

        private void SetNewTransitionType(Core.ColouredTransitionType type)
        {
            //System.Console.WriteLine("SetNewTransitionType: " + type);
            _newTransitionType = type;
        }

        private void SetNewMarkerType(Core.ColouredMarkerType type)
        {
            //System.Console.WriteLine("SetNewMarkerType: " + type);
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
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                if(_itemMap.Deserialize(dlgOpenFile.FileName))
                {
                    _currentFile = dlgOpenFile.FileName;
                }
                else
                {
                    MessageBox.Show("Error: Could not load file!");
                }
            }
        }

        private void SaveToFile()
        {
            if (_currentFile == null)
            {
                SaveFileAs();
            }
            else
            {
                if (!_itemMap.Serialize(_currentFile))
                {
                    MessageBox.Show("Error: Could not save file!");
                }
            }
        }

        private void SaveFileAs()
        {
            if (dlgSaveFile.ShowDialog() == DialogResult.OK)
            {
                System.Console.WriteLine("File:{0}", dlgSaveFile.FileName);
                if (_itemMap.Serialize(dlgSaveFile.FileName))
                {
                    _currentFile = dlgSaveFile.FileName;
                }
                else
                {
                    MessageBox.Show("Error: Could not save file!");
                }
            }
        }

        private void OpenShowStateInfoForm()
        {
            dlgShowIteminfo.ShowDialog();
        }

        private void OpenShowTransitionInfoForm()
        {
            dlgShowIteminfo.ShowDialog();
        }

        private void OpenShowMarkerInfoForm()
        {
            dlgShowIteminfo.ShowDialog();
        }

        private void OpenLinkStyleForm()
        {
            dlgLinkStyle.ShowDialog();
        }

        private void OpenStateStyleForm()
        {
            dlgItemStyle.ShowDialog();
        }

        private void OpenTransitionStyleForm()
        {
            dlgItemStyle.ShowDialog();
        }

        private void OpenMarkerStyleForm()
        {
            dlgItemStyle.ShowDialog();
        }

        private void OpenBackgroundForm()
        {
            dlgBackground.ShowDialog();
        }

        private void OpenAboutForm()
        {
            dlgAbout.ShowDialog();
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
    }
}
