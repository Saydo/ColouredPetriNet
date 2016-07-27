using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public enum ItemType { Link, Marker = 100, Transition = 200, State = 300 };

        private const int _linkZ = 1;
        private const int _stateZ = 2;
        private IdGenerator _idGenerator;
        private IdGenerator _typeGenerator;

        public GraphicsPetriNet()
        {
            _idGenerator = new IdGenerator(-1);
            _typeGenerator = new IdGenerator(-1);

            this.Types = _types = new TypeStorage(this);
            this.States = _states = new StateStorage(this);
            this.Transitions = _transitions = new TransitionStorage(this);
            this.Markers = _markers = new MarkerStorage(this);
            this.Links = _links = new LinkStorage(this);
            this.MoveRules = _moveRules = new MoveRuleStorage();
            this.PrevAccumulateRules = _prevAccumulateRules = new AccumulateRuleStorage();
            this.NextAccumulateRules = _nextAccumulateRules = new AccumulateRuleStorage();
        }

        public int GenerateItemId()
        {
            return _idGenerator.Next();
        }

        public int GenerateTypeId()
        {
            return _typeGenerator.Next();
        }

        public int GetLastItemId()
        {
            return _idGenerator.CurrentId;
        }

        public int GetLastTypeId()
        {
            return _typeGenerator.CurrentId;
        }

        public void Clear()
        {
            _types.Clear();
        }

        public void Select(int x, int y)
        {
            _states.SelectArea(x, y);
            _transitions.SelectArea(x, y);
            _links.SelectArea(x, y);
        }

        public void Select(int x, int y, int w, int h, GraphicsItems.OverlapType overlap)
        {
            _states.SelectArea(x, y, w, h, overlap);
            _transitions.SelectArea(x, y, w, h, overlap);
            _links.SelectArea(x, y, w, h, overlap);
        }

        public void SelectItems()
        {
            _states.Select();
            _transitions.Select();
            _links.Select();
        }

        public void Deselect(int x, int y)
        {
            _states.DeselectArea(x, y);
            _transitions.DeselectArea(x, y);
            _links.DeselectArea(x, y);
        }

        public void Deselect(int x, int y, int w, int h, GraphicsItems.OverlapType overlap)
        {
            _states.DeselectArea(x, y, w, h, overlap);
            _transitions.DeselectArea(x, y, w, h, overlap);
            _links.DeselectArea(x, y, w, h, overlap);
        }

        public void DeselectItems()
        {
            _states.Deselect();
            _transitions.Deselect();
            _links.Deselect();
        }

        public void RemoveSelectedItems()
        {
            _links.RemoveSelectedLinks();
            _transitions.RemoveSelectedTransitions();
            _states.RemoveSelectedStates();
        }

        public void Move(int dx, int dy)
        {
            _states.Move(dx, dy);
            _transitions.Move(dx, dy);
            _links.Move(dx, dy);
        }

        public bool Move(int dx, int dy, int id)
        {
            if (_states.Move(dx, dy, id))
            {
                return true;
            }
            if (_transitions.Move(dx, dy, id))
            {
                return true;
            }
            if (_links.Move(dx, dy, id))
            {
                return true;
            }
            return false;
        }

        public void MoveSelectedItems(int dx, int dy)
        {
            var movedStates = new List<StateWrapper>(_states.SelectedStates);
            var movedTransitions = new List<TransitionWrapper>(_transitions.SelectedTransitions);
            _links.UpdateMovedItems(movedStates, movedTransitions);
            for (int i = 0; i < movedStates.Count; ++i)
            {
                 MoveState(dx, dy, movedStates[i]);
            }
            for (int i = 0; i < movedTransitions.Count; ++i)
            {
                MoveTransition(dx, dy, movedTransitions[i]);
            }
        }

        public void Draw(System.Drawing.Graphics graphics)
        {
            _links.Draw(graphics);
            _transitions.Draw(graphics);
            _states.Draw(graphics);
        }

        /*
        public Xml.GraphicsPetriNetXml ToXml()
        {
            var itemsXml = new Core.Serialize.PetriNetItemsXml();
            Core.Serialize.StateXml stateXml;
            List<int> listId;
            string markerType;
            // Add States
            for (int i = 0; i < _states.Count; ++i)
            {
                stateXml = new Core.Serialize.StateXml(_states[i].State.Id, _states[i].State.Center.X,
                    _states[i].State.Center.Y, ColouredPetriNetItemInfo.GetStateTypeName(_states[i].State.TypeId));
                // Add Markers
                for (int j = 0; j < _states[i].Markers.Count; ++j)
                {
                    markerType = ColouredPetriNetItemInfo.GetMarkerTypeName(_states[i].Markers[j].Item1.TypeId);
                    listId = _states[i].Markers[j].Item2;
                    for (int k = 0; k < listId.Count; ++k)
                    {
                        stateXml.Markers.Add(new Core.Serialize.MarkerXml(listId[k], markerType));
                    }
                }
                itemsXml.StateList.Add(stateXml);
            }
            // Add Transitions
            for (int i = 0; i < _transitions.Count; ++i)
            {
                itemsXml.TransitionList.Add(new Core.Serialize.TransitionXml(_transitions[i].Transition.Id,
                    _transitions[i].Transition.Center.X, _transitions[i].Transition.Center.Y,
                    ColouredPetriNetItemInfo.GetTransitionTypeName(_transitions[i].Transition.TypeId)));
            }
            // Add Links
            for (int i = 0; i < _links.Count; ++i)
            {
                itemsXml.LinkList.Add(new Core.Serialize.LinkXml(_links[i].Link.Id,
                    _links[i].State.State.Id, _links[i].Transition.Transition.Id,
                    (_links[i].Direction == LinkDirection.FromStateToTransition ? "FromState" : "ToState")));
            }
            return itemsXml;
        }
        */
        //public bool FromXml(string filePath);
        #region Helpful Functions
        private static void MoveState(int dx, int dy, StateWrapper state)
        {
            for (int i = 0; i < state.InputLinks.Count; ++i)
            {
                state.InputLinks[i].Link.MovePoint1(dx, dy);
            }
            for (int i = 0; i < state.OutputLinks.Count; ++i)
            {
                state.OutputLinks[i].Link.MovePoint1(dx, dy);
            }
            state.Move(dx, dy);
        }

        private static void MoveTransition(int dx, int dy, TransitionWrapper transition)
        {
            for (int i = 0; i < transition.InputLinks.Count; ++i)
            {
                transition.InputLinks[i].Link.MovePoint2(dx, dy);
            }
            for (int i = 0; i < transition.OutputLinks.Count; ++i)
            {
                transition.OutputLinks[i].Link.MovePoint2(dx, dy);
            }
            transition.Transition.Move(dx, dy);
        }

        private static void MoveLink(int dx, int dy, LinkWrapper link)
        {
            MoveTransition(dx, dy, link.Transition);
            MoveState(dx, dy, link.State);
        }

        private static void RemoveFromList<T>(List<T> list, List<int> indexList)
        {
            for (int i = indexList.Count - 1; i >= 0; --i)
            {
                list.RemoveAt(indexList[i]);
                for (int j = i - 1; j >= 0; --j)
                {
                    if (indexList[j] > indexList[i])
                    {
                        --indexList[j];
                    }
                }
            }
        }

        /*
        private void GetItemsFromXml(Core.Serialize.PetriNetItemsXml itemsXml)
        {
            Core.Serialize.StateXml stateXml;
            GraphicsStateWrapper state;
            GraphicsTransitionWrapper transition;
            GraphicsItems.GraphicsItem item;
            GraphicsItems.LinkGraphicsItem.LinkDirection graphicsLinkDirection;
            LinkDirection wrapperLinkDirection;
            this.Clear();
            for (int i = 0; i < itemsXml.StateList.Count; ++i)
            {
                stateXml = itemsXml.StateList[i];
                state = new GraphicsStateWrapper(GetStateGraphicsItemFromXml(stateXml));
                for (int j = 0; j < stateXml.Markers.Count; ++j)
                {
                    state.AddMarker(GetMarkerGraphicsItemFromXml(stateXml.Markers[j]));
                    switch (stateXml.Markers[j].Type)
                    {
                        case "RoundMarker":
                            _petriNet.AddMarker(stateXml.Markers[j].Id, stateXml.Id,
                                new RoundMarker());
                            break;
                        case "RhombMarker":
                            _petriNet.AddMarker(stateXml.Markers[j].Id, stateXml.Id,
                                new RhombMarker());
                            break;
                        case "TriangleMarker":
                            _petriNet.AddMarker(stateXml.Markers[j].Id, stateXml.Id,
                                new TriangleMarker());
                            break;
                    }
                }
                switch (stateXml.Type)
                {
                    case "RoundState":
                        _petriNet.AddState(stateXml.Id, new RoundState());
                        break;
                    case "ImageState":
                        _petriNet.AddState(stateXml.Id, new ImageState());
                        break;
                }
                _states.Add(state);
                AddStateEvent(this, ConvertToStateEventArgs(state));
            }
            for (int i = 0; i < itemsXml.TransitionList.Count; ++i)
            {
                item = GetTransitionGraphicsItemFromXml(itemsXml.TransitionList[i]);
                switch (item.TypeId)
                {
                    case (int)ColouredPetriNetItemInfo.ItemType.Transition + (int)ColouredTransitionType.RectangleTransition:
                        _petriNet.AddTransition(item.Id, new RectangleTransition());
                        break;
                    case (int)ColouredPetriNetItemInfo.ItemType.Transition + (int)ColouredTransitionType.RhombTransition:
                        _petriNet.AddTransition(item.Id, new RhombTransition());
                        break;
                }
                _transitions.Add(new GraphicsTransitionWrapper(item));
                AddTransitionEvent(this, new Events.PetriNetNodeEventArgs(item.Id, item.TypeId));
            }
            for (int i = 0; i < itemsXml.LinkList.Count; ++i)
            {
                if (itemsXml.LinkList[i].Direction.Equals("FromState"))
                {
                    AddLink(itemsXml.LinkList[i].StateId, itemsXml.LinkList[i].TransitionId,
                        LinkDirection.FromStateToTransition);
                }
                else
                {
                    AddLink(itemsXml.LinkList[i].StateId, itemsXml.LinkList[i].TransitionId,
                        LinkDirection.FromTransitionToState);
                }
            }
        }

        private GraphicsItems.GraphicsItem GetStateGraphicsItemFromXml(Core.Serialize.StateXml stateXml)
        {
            switch (stateXml.Type)
            {
                case "RoundState":
                    var roundState = new GraphicsItems.RoundGraphicsItem(stateXml.Id,
                            (int)ColouredPetriNetItemInfo.ItemType.State + (int)ColouredStateType.RoundState,
                            new Point(stateXml.X, stateXml.Y), Style.RoundState.Radius, _stateZ);
                    roundState.SelectionPen = Style.SelectionPen;
                    roundState.BorderPen = Style.RoundState.BorderPen;
                    roundState.FillBrush = Style.RoundState.FillBrush;
                    return roundState;
                case "ImageState":
                    var imageState = new GraphicsItems.ImageGraphicsItem(stateXml.Id,
                        (int)ColouredPetriNetItemInfo.ItemType.State + (int)ColouredStateType.ImageState,
                        Image.FromFile(Style.ImageState.ImageName),
                        new Point(stateXml.X, stateXml.Y), Style.ImageState.Width, Style.ImageState.Height, _stateZ);
                    imageState.SelectionPen = Style.SelectionPen;
                    return imageState;
            }
            return null;
        }

        private GraphicsItems.GraphicsItem GetTransitionGraphicsItemFromXml(Core.Serialize.TransitionXml transitionXml)
        {
            switch (transitionXml.Type)
            {
                case "RectangleTransition":
                    var rectangleTransition = new GraphicsItems.RectangleGraphicsItem(transitionXml.Id,
                            (int)ColouredPetriNetItemInfo.ItemType.Transition + (int)ColouredTransitionType.RectangleTransition,
                            new Point(transitionXml.X, transitionXml.Y),
                            Style.RectangleTransition.Width, Style.RectangleTransition.Height, _stateZ);
                    rectangleTransition.SelectionPen = Style.SelectionPen;
                    rectangleTransition.BorderPen = Style.RectangleTransition.BorderPen;
                    rectangleTransition.FillBrush = Style.RectangleTransition.FillBrush;
                    return rectangleTransition;
                case "RhombTransition":
                    var rhombTransition = new GraphicsItems.RhombGraphicsItem(transitionXml.Id,
                        (int)ColouredPetriNetItemInfo.ItemType.Transition + (int)ColouredTransitionType.RhombTransition,
                        new Point(transitionXml.X, transitionXml.Y),
                        Style.RhombTransition.Width, Style.RhombTransition.Height, _stateZ);
                    rhombTransition.SelectionPen = Style.SelectionPen;
                    rhombTransition.BorderPen = Style.RhombTransition.BorderPen;
                    rhombTransition.FillBrush = Style.RhombTransition.FillBrush;
                    return rhombTransition;
            }
            return null;
        }

        private GraphicsItems.GraphicsItem GetMarkerGraphicsItemFromXml(Core.Serialize.MarkerXml markerXml)
        {
            switch (markerXml.Type)
            {
                case "RoundMarker":
                    var roundMarker = new GraphicsItems.RoundGraphicsItem(markerXml.Id,
                        (int)ColouredPetriNetItemInfo.ItemType.Marker + (int)ColouredMarkerType.RoundMarker,
                        new Point(0, 0),
                        Style.RoundMarker.Radius, _stateZ);
                    roundMarker.SelectionPen = Style.SelectionPen;
                    roundMarker.BorderPen = Style.RoundMarker.BorderPen;
                    roundMarker.FillBrush = Style.RoundMarker.FillBrush;
                    return roundMarker;
                case "RhombMarker":
                    var rhombMarker = new GraphicsItems.RhombGraphicsItem(markerXml.Id,
                        (int)ColouredPetriNetItemInfo.ItemType.Marker + (int)ColouredMarkerType.RhombMarker,
                        new Point(0, 0),
                        Style.RhombMarker.Width, Style.RhombMarker.Height, _stateZ);
                    rhombMarker.SelectionPen = Style.SelectionPen;
                    rhombMarker.BorderPen = Style.RhombMarker.BorderPen;
                    rhombMarker.FillBrush = Style.RhombMarker.FillBrush;
                    return rhombMarker;
                case "TriangleMarker":
                    var triangleMarker = new GraphicsItems.TriangleGraphicsItem(markerXml.Id,
                        (int)ColouredPetriNetItemInfo.ItemType.Marker + (int)ColouredMarkerType.TriangleMarker,
                        new Point(0, 0), Style.TriangleMarker.Side, _stateZ);
                    triangleMarker.SelectionPen = Style.SelectionPen;
                    triangleMarker.BorderPen = Style.TriangleMarker.BorderPen;
                    triangleMarker.FillBrush = Style.TriangleMarker.FillBrush;
                    return triangleMarker;
            }
            return null;
        }
        */
        #endregion
    }
}