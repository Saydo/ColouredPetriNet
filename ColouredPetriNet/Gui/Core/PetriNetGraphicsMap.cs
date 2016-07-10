using System.Collections.Generic;
using System.Drawing;

namespace ColouredPetriNet.Gui.Core
{
    public class PetriNetGraphicsMap// : IPetriNetGraphicsMap
    {
        private enum ItemType { Link, Marker = 100, Transition = 200, State = 300 };

        private const int _linkZ = 1;
        private const int _stateZ = 2;

        private List<GraphicsLinkWrapper> _links;
        private List<GraphicsStateWrapper> _states;
        private List<GraphicsTransitionWrapper> _transitions;
        private List<int> _selectedLinks;
        private List<int> _selectedStates;
        private List<int> _selectedTransitions;
        private SelectionArea _selectionArea;
        private Container.ColouredPetriNet _petriNet;

        public int LinkCount { get { return _links.Count; } }
        public int TransitionCount { get { return _transitions.Count; } }
        public int StateCount { get { return _states.Count; } }
        public Style.ColouredPetriNetStyle Style { get; set; }

        public PetriNetGraphicsMap()
        {
            _links = new List<GraphicsLinkWrapper>();
            _states = new List<GraphicsStateWrapper>();
            _transitions = new List<GraphicsTransitionWrapper>();
            _selectedLinks = new List<int>();
            _selectedStates = new List<int>();
            _selectedTransitions = new List<int>();
            _selectionArea = new SelectionArea();
            _petriNet = new Container.ColouredPetriNet();
            Style = new Style.ColouredPetriNetStyle();

        }

        #region Add Functions
        public void AddState(int x, int y, ColouredStateType stateType)
        {
            int id;
            switch (stateType)
            {
                case ColouredStateType.RoundState:
                    id = _petriNet.AddState<RoundState>(new RoundState());
                    var roundState = new GraphicsItems.RoundGraphicsItem(id,
                        (int)ItemType.State + (int)ColouredStateType.RoundState,
                        new Point(x, y), Style.RoundState.Radius, _stateZ);
                    roundState.SelectionPen = Style.SelectionPen;
                    roundState.BorderPen = Style.RoundState.BorderPen;
                    roundState.FillBrush = Style.RoundState.FillBrush;
                    _states.Add(new GraphicsStateWrapper(roundState));
                    break;
                case ColouredStateType.ImageState:
                    id = _petriNet.AddState<ImageState>(new ImageState());
                    var imageState = new GraphicsItems.ImageGraphicsItem(id,
                        (int)ItemType.State + (int)ColouredStateType.ImageState,
                        Image.FromFile(Style.ImageState.ImageName),
                        new Point(x, y), Style.ImageState.Width, Style.ImageState.Height, _stateZ);
                    imageState.SelectionPen = Style.SelectionPen;
                    _states.Add(new GraphicsStateWrapper(imageState));
                    break;
            }
        }

        public void AddTransition(int x, int y, ColouredTransitionType transitionType)
        {
            int id;
            switch (transitionType)
            {
                case ColouredTransitionType.RectangleTransition:
                    id = _petriNet.AddTransition<RectangleTransition>(new RectangleTransition());
                    var rectangleTransition = new GraphicsItems.RectangleGraphicsItem(id,
                        (int)ItemType.Transition + (int)ColouredTransitionType.RectangleTransition,
                        new Point(x, y),
                        Style.RectangleTransition.Width, Style.RectangleTransition.Height, _stateZ);
                    rectangleTransition.SelectionPen = Style.SelectionPen;
                    rectangleTransition.BorderPen = Style.RectangleTransition.BorderPen;
                    rectangleTransition.FillBrush = Style.RectangleTransition.FillBrush;
                    _transitions.Add(new GraphicsTransitionWrapper(rectangleTransition));
                    break;
                case ColouredTransitionType.RhombTransition:
                    id = _petriNet.AddTransition<RhombTransition>(new RhombTransition());
                    var rhombTransition = new GraphicsItems.RhombGraphicsItem(id,
                        (int)ItemType.Transition + (int)ColouredTransitionType.RhombTransition,
                        new Point(x, y),
                        Style.RhombTransition.Width, Style.RhombTransition.Height, _stateZ);
                    rhombTransition.SelectionPen = Style.SelectionPen;
                    rhombTransition.BorderPen = Style.RhombTransition.BorderPen;
                    rhombTransition.FillBrush = Style.RhombTransition.FillBrush;
                    _transitions.Add(new GraphicsTransitionWrapper(rhombTransition));
                    break;
            }
        }

        public void AddMarker(int stateId, ColouredMarkerType markerType)
        {
            int id;
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return;
            }
            switch (markerType)
            {
                case ColouredMarkerType.RoundMarker:
                    id = _petriNet.AddMarker<RoundMarker>(stateId, new RoundMarker());
                    var roundMarker = new GraphicsItems.RoundGraphicsItem(id,
                        (int)ItemType.Marker + (int)ColouredMarkerType.RoundMarker,
                        new Point(0, 0),
                        Style.RoundMarker.Radius, _stateZ);
                    roundMarker.SelectionPen = Style.SelectionPen;
                    roundMarker.BorderPen = Style.RoundMarker.BorderPen;
                    roundMarker.FillBrush = Style.RoundMarker.FillBrush;
                    state.AddMarker(roundMarker);
                    break;
                case ColouredMarkerType.RhombMarker:
                    id = _petriNet.AddMarker<RhombMarker>(stateId, new RhombMarker());
                    var rhombMarker = new GraphicsItems.RhombGraphicsItem(id,
                        (int)ItemType.Marker + (int)ColouredMarkerType.RhombMarker,
                        new Point(0, 0),
                        Style.RhombMarker.Width, Style.RhombMarker.Height, _stateZ);
                    rhombMarker.SelectionPen = Style.SelectionPen;
                    rhombMarker.BorderPen = Style.RhombMarker.BorderPen;
                    rhombMarker.FillBrush = Style.RhombMarker.FillBrush;
                    state.AddMarker(rhombMarker);
                    break;
                case ColouredMarkerType.TriangleMarker:
                    id = _petriNet.AddMarker<TriangleMarker>(stateId, new TriangleMarker());
                    var triangleMarker = new GraphicsItems.TriangleGraphicsItem(id,
                        (int)ItemType.Marker + (int)ColouredMarkerType.TriangleMarker,
                        new Point(0, 0), Style.TriangleMarker.Side, _stateZ);
                    triangleMarker.SelectionPen = Style.SelectionPen;
                    triangleMarker.BorderPen = Style.TriangleMarker.BorderPen;
                    triangleMarker.FillBrush = Style.TriangleMarker.FillBrush;
                    state.AddMarker(triangleMarker);
                    break;
            }
        }

        public void AddLink(int stateId, int transitionId, LinkDirection direction)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return;
            }
            var transition = FindTransitionById(transitionId);
            if (ReferenceEquals(transition, null))
            {
                return;
            }
            GraphicsItems.LinkGraphicsItem.LinkDirection linkDirection;
            if (direction == LinkDirection.FromStateToTransition)
            {
                _petriNet.AddStateToTransitionLink(stateId, transitionId);
                linkDirection = GraphicsItems.LinkGraphicsItem.LinkDirection.FromP1toP2;
            }
            else
            {
                _petriNet.AddTransitionToStateLink(transitionId, stateId);
                linkDirection = GraphicsItems.LinkGraphicsItem.LinkDirection.FromP2toP1;
            }
            _links.Add(new GraphicsLinkWrapper(state, transition,
                new GraphicsItems.LinkGraphicsItem(-1, (int)ItemType.Link, state.State.Center,
                transition.Transition.Center, linkDirection, _stateZ), direction));
        }
        #endregion

        #region Remove Functions
        /*
        public bool RemoveItem(int id)
        {
            if (RemoveMarker(id))
                return true;
            if (RemoveState(id))
                return true;
            if (RemoveTransition(id))
                return true;
            return false;
        }

        public bool RemoveLinks(int stateId, int transitionId)
        {
            //_petriNet();
        }

        public bool RemoveLinks(int stateId, int transitionId, LinkDirection direction)
        {
            //
        }

        public bool RemoveMarker(int id)
        {
            for (int i = 0; i < _markers.Count; ++i)
            {
                if (_markers[i].Id == id)
                {
                    _markers.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveMarker(int id, int stateId)
        {
            var marker = _petriNet.GetMarkerInterface(id);
            if ((!ReferenceEquals(marker, null)) && (marker.StateId == stateId))
            {
                return _petriNet.RemoveMarker(id);
            }
            return false;
        }

        public bool RemoveMarkers(int stateId)
        {
            return _petriNet.RemoveMarkersFromState(stateId);
        }

        public bool RemoveMarkers(ColouredMarkerType markerType)
        {
            //
        }

        public bool RemoveMarkers(int stateId, ColouredMarkerType markerType)
        {
            //
        }

        public bool RemoveState(int id)
        {
            //
        }

        public bool RemoveStates(ColouredStateType stateType)
        {
            //
        }

        public bool RemoveTransition(int id)
        {
            //
        }

        public bool RemoveTransitions(ColouredStateType transitionType)
        {
            //
        }
        */
        #endregion
        
        #region Clear Functions
        public void Clear()
        {
            _selectedLinks.Clear();
            _selectedStates.Clear();
            _selectedTransitions.Clear();
            _links.Clear();
            _states.Clear();
            _transitions.Clear();
            _petriNet.Clear();
        }

        public void ClearLinks()
        {
            _selectedLinks.Clear();
            _links.Clear();
            _petriNet.ClearLinks();
        }

        public void ClearMarkers()
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                _states[i].Markers.Clear();
            }
            _petriNet.ClearMarkers();
        }

        public void ClearStates()
        {
            _selectedStates.Clear();
            _states.Clear();
            _petriNet.ClearStates();
        }

        public void ClearTransitions()
        {
            _selectedTransitions.Clear();
            _transitions.Clear();
            _petriNet.ClearTransitions();
        }
        #endregion

        /*
        #region Contains Functions
        public bool Contains(int id)
        {
            if (ContainsMarker(id))
                return true;
            if (ContainsState(id))
                return true;
            if (ContainsTransition(id))
                return true;
            return false;
        }

        public bool Contains(ColouredMarkerType markerType)
        {
            int type = (int)ItemType.Marker + (int)markerType;
            for (int i = 0; i < _markers.Count; ++i)
            {
                if (_markers[i].TypeId == type)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(ColouredStateType stateType)
        {
            int type = (int)ItemType.State + (int)stateType;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].TypeId == type)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(ColouredTransitionType transitionType)
        {
            int type = (int)ItemType.Transition + (int)transitionType;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].TypeId == type)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(int id, ColouredMarkerType markerType)
        {
            int type = (int)ItemType.Marker + (int)markerType;
            for (int i = 0; i < _markers.Count; ++i)
            {
                if (_markers[i].Id == id)
                {
                    return (_markers[i].TypeId == type);
                }
            }
            return false;
        }

        public bool Contains(int id, ColouredStateType stateType)
        {
            int type = (int)ItemType.State + (int)stateType;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].Id == id)
                {
                    return (_states[i].TypeId == type);
                }
            }
            return false;
        }

        public bool Contains(int id, ColouredTransitionType transitionType)
        {
            int type = (int)ItemType.Transition + (int)transitionType;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Id == id)
                {
                    return (_transitions[i].TypeId == type);
                }
            }
            return false;
        }

        public bool ContainsMarker(int id)
        {
            for (int i = 0; i < _markers.Count; ++i)
            {
                if (_markers[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsState(int id)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsTransition(int id)
        {
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsLink(int stateId, int transitionId)
        {
            return _petriNet.IsLinkExist(stateId, transitionId);
        }

        public bool ContainsLink(int stateId, int transitionId, LinkDirection direction)
        {
            if (direction == LinkDirection.FromStateToTransition)
            {
                return _petriNet.IsOutputLinkExist(stateId, transitionId);
            }
            else
            {
                return _petriNet.IsInputLinkExist(stateId, transitionId);
            }
        }
        #endregion

        #region Count Functions
        public int GetMarkerCount(ColouredMarkerType markerType)
        {
            int type = (int)ItemType.Marker + (int)markerType;
            int count = 0;
            for (int i = 0; i < _markers.Count; ++i)
            {
                if (_markers[i].TypeId == type)
                {
                    ++count;
                }
            }
            return count;
        }

        public int GetTransitionCount(ColouredTransitionType transitionType)
        {
            int type = (int)ItemType.Transition + (int)transitionType;
            int count = 0;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].TypeId == type)
                {
                    ++count;
                }
            }
            return count;
        }

        public int GetStateCount(ColouredStateType stateType)
        {
            int type = (int)ItemType.State + (int)stateType;
            int count = 0;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].TypeId == type)
                {
                    ++count;
                }
            }
            return count;
        }

        public int GetLinkCount(int stateId, int transitionId)
        {
            return _petriNet.GetLinkCount(stateId, transitionId);
        }

        public int GetLinkCount(int stateId, int transitionId, LinkDirection direction)
        {
            if (direction == LinkDirection.FromStateToTransition)
            {
                return _petriNet.GetOutputLinkCount(stateId, transitionId);
            }
            else
            {
                return _petriNet.GetInputLinkCount(stateId, transitionId);
            }
        }
        #endregion

        #region Find Functions
        public List<Gui.GraphicsItems.GraphicsItem> FindItems(int x, int y);
        public List<Gui.GraphicsItems.GraphicsItem> FindLinks(int x, int y);
        public List<Gui.GraphicsItems.GraphicsItem> FindMarkers(int x, int y);
        public List<Gui.GraphicsItems.GraphicsItem> FindMarkers(int x, int y, ColouredMarkerType markerType);
        public List<Gui.GraphicsItems.GraphicsItem> FindStates(int x, int y);
        public List<Gui.GraphicsItems.GraphicsItem> FindStates(int x, int y, ColouredStateType stateType);
        public List<Gui.GraphicsItems.GraphicsItem> FindTransitions(int x, int y);
        public List<Gui.GraphicsItems.GraphicsItem> FindTransitions(int x, int y, ColouredTransitionType transitionType);
        #endregion
        
        #region Select Functions
        public void Select(int x, int y);
        public void Select(int x, int y, int w, int h);
        public void SelectItems();
        public void SelectLinks();
        public void SelectLinks(int stateId, int transitionId);
        public void SelectLinks(int stateId, int transitionId, LinkDirection direction);
        public void SelectMarkers();
        public void SelectMarkers(int stateId);
        public void SelectMarkers(ColouredMarkerType markerType);
        public void SelectMarkers(int stateId, ColouredMarkerType markerType);
        public void SelectStates();
        public void SelectStates(ColouredStateType stateType);
        public void SelectTransitions();
        public void SelectTransitions(ColouredTransitionType transitionType);
        #endregion
        
        #region Deselect Functions
        public void Deselect(int x, int y);
        public void Deselect(int x, int y, int w, int h);
        public void DeselectItems();
        public void DeselectLinks();
        public void DeselectLinks(int stateId, int transitionId);
        public void DeselectLinks(int stateId, int transitionId, LinkDirection direction);
        public void DeselectMarkers();
        public void DeselectMarkers(int stateId);
        public void DeselectMarkers(ColouredMarkerType markerType);
        public void DeselectMarkers(int stateId, ColouredMarkerType markerType);
        public void DeselectStates();
        public void DeselectStates(ColouredStateType stateType);
        public void DeselectTransitions();
        public void DeselectTransitions(ColouredTransitionType transitionType);
        #endregion
        
        #region Serialization Functions
        public bool Serialize(string filePath)
        {
            return true;
        }

        public bool Deserialize(string filePath)
        {
            return true;
        }
        #endregion
        
        #region SelectionArea Functions
        public void SetSelectionArea(int x, int y, int w, int h);
        public void UpdateSelectionArea(int w, int h);
        public void UpdateSelectionAreaByPos(int x, int y);
        public void HideSelectionArea();
        #endregion
        */

        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < _links.Count; ++i)
            {
                _links[i].Link.Draw(graphics);
            }
            for (int i = 0; i < _transitions.Count; ++i)
            {
                _transitions[i].Transition.Draw(graphics);
            }
            for (int i = 0; i < _states.Count; ++i)
            {
                _states[i].State.Draw(graphics);
            }
            _selectionArea.Draw(graphics);
        }

        private GraphicsStateWrapper FindStateById(int id)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.Id == id)
                {
                    return _states[i];
                }
            }
            return null;
        }

        private GraphicsTransitionWrapper FindTransitionById(int id)
        {
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.Id == id)
                {
                    return _transitions[i];
                }
            }
            return null;
        }
    }
}
