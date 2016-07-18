﻿using System.Collections.Generic;
using System.Drawing;

namespace ColouredPetriNet.Gui.Core
{
    public class PetriNetGraphicsMap : IPetriNetGraphicsMap
    {
        public enum ItemType { Link, Marker = 100, Transition = 200, State = 300 };

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
        private Container.IdGenerator _linkIdGenerator;
        public Style.ColouredPetriNetStyle Style;

        public int LinkCount { get { return _links.Count; } }
        public int TransitionCount { get { return _transitions.Count; } }
        public int StateCount { get { return _states.Count; } }

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
            _linkIdGenerator = new Container.IdGenerator(-1);
            SetDefaultStyle();
        }

        public void SetDefaultStyle()
        {
            string appDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = appDir.Substring(0, appDir.Length - "/bin/Debug".Length);
            Style.RoundMarker = new Style.RoundShapeStyle(4, new SolidBrush(Color.FromArgb(150, 0, 220)),
                new Pen(Color.FromArgb(0, 0, 0), 1.0F));
            Style.RhombMarker = new Style.RectangleShapeStyle(8, 8,
                new SolidBrush(Color.FromArgb(150, 0, 220)), new Pen(Color.FromArgb(0, 0, 0), 1.0F));
            Style.TriangleMarker = new Style.TriangleShapeStyle(8,
                new SolidBrush(Color.FromArgb(150, 0, 220)), new Pen(Color.FromArgb(0, 0, 0), 1.0F));
            Style.RectangleTransition = new Style.RectangleShapeStyle(20, 20,
                new SolidBrush(Color.FromArgb(220, 220, 0)), new Pen(Color.FromArgb(0, 0, 0), 1.0F));
            Style.RhombTransition = new Style.RectangleShapeStyle(20, 20,
                new SolidBrush(Color.FromArgb(220, 220, 0)), new Pen(Color.FromArgb(0, 0, 0), 1.0F));
            Style.RoundState = new Style.RoundShapeStyle(10, new SolidBrush(Color.FromArgb(0, 240, 0)),
                new Pen(Color.FromArgb(0, 0, 0), 1.0F));
            Style.ImageState = new Style.ImageShapeStyle(projectDir + "Resources/ImageState32x32.png", 22, 22);
            Style.SelectionMode = GraphicsItems.OverlapType.Partial;
            Style.SelectionPen = new Pen(Color.FromArgb(0, 0, 0), 1.0F);
        }

        #region Add Functions
        public int AddState(int x, int y, ColouredStateType stateType)
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
                    return id;
                case ColouredStateType.ImageState:
                    id = _petriNet.AddState<ImageState>(new ImageState());
                    var imageState = new GraphicsItems.ImageGraphicsItem(id,
                        (int)ItemType.State + (int)ColouredStateType.ImageState,
                        Image.FromFile(Style.ImageState.ImageName),
                        new Point(x, y), Style.ImageState.Width, Style.ImageState.Height, _stateZ);
                    imageState.SelectionPen = Style.SelectionPen;
                    _states.Add(new GraphicsStateWrapper(imageState));
                    return id;
            }
            return -1;
        }

        public int AddTransition(int x, int y, ColouredTransitionType transitionType)
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
                    return id;
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
                    return id;
            }
            return -1;
        }

        public int AddMarker(int stateId, ColouredMarkerType markerType)
        {
            int id;
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return -1;
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
                    return id;
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
                    return id;
                case ColouredMarkerType.TriangleMarker:
                    id = _petriNet.AddMarker<TriangleMarker>(stateId, new TriangleMarker());
                    var triangleMarker = new GraphicsItems.TriangleGraphicsItem(id,
                        (int)ItemType.Marker + (int)ColouredMarkerType.TriangleMarker,
                        new Point(0, 0), Style.TriangleMarker.Side, _stateZ);
                    triangleMarker.SelectionPen = Style.SelectionPen;
                    triangleMarker.BorderPen = Style.TriangleMarker.BorderPen;
                    triangleMarker.FillBrush = Style.TriangleMarker.FillBrush;
                    state.AddMarker(triangleMarker);
                    return id;
            }
            return -1;
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
            var link = new GraphicsLinkWrapper(state, transition,
                new GraphicsItems.LinkGraphicsItem(_linkIdGenerator.GetNextId(),
                (int)ItemType.Link, state.State.Center, transition.Transition.Center,
                linkDirection, _stateZ), direction);
            _links.Add(link);
            if (direction == LinkDirection.FromStateToTransition)
            {
                state.OutputLinks.Add(link);
                transition.InputLinks.Add(link);
            }
            else
            {
                state.InputLinks.Add(link);
                transition.OutputLinks.Add(link);
            }
        }
        #endregion

        #region Remove Functions
        public bool RemoveLink(int id)
        {
            for (int i = 0; i < _links.Count; ++i)
            {
                if (_links[i].Link.Id == id)
                {
                    RemoveFromIdList(id, _selectedLinks);
                    if (_links[i].Direction == LinkDirection.FromStateToTransition)
                    {
                        RemoveFromLinkList(id, _links[i].State.OutputLinks);
                        RemoveFromLinkList(id, _links[i].Transition.InputLinks);
                        _petriNet.RemoveStateToTransitionLink(_links[i].State.State.Id,
                            _links[i].Transition.Transition.Id);
                    }
                    else
                    {
                        RemoveFromLinkList(id, _links[i].State.InputLinks);
                        RemoveFromLinkList(id, _links[i].Transition.OutputLinks);
                        _petriNet.RemoveTransitionToStateLink(_links[i].Transition.Transition.Id,
                            _links[i].State.State.Id);
                    }
                    _links.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveLinks(int stateId, int transitionId)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return false;
            }
            bool isFound = RemoveInputLink(state, stateId, transitionId);
            return (RemoveOutputLink(state, stateId, transitionId) || isFound);
        }

        public bool RemoveLinks(int stateId, int transitionId, LinkDirection direction)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return false;
            }
            if (direction == LinkDirection.FromTransitionToState)
            {
                return RemoveInputLink(state, stateId, transitionId);
            }
            else
            {
                return RemoveOutputLink(state, stateId, transitionId);
            }
        }

        public bool RemoveMarker(int id)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].RemoveMarker(id))
                {
                    _petriNet.RemoveMarker(id);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveMarker(int id, int stateId)
        {
            var state = _petriNet.GetStateInterface(stateId);
            if (ReferenceEquals(state, null))
            {
                return false;
            }
            var stateItem = FindStateById(stateId);
            if (ReferenceEquals(stateItem, null))
            {
                return false;
            }
            state.RemoveMarker(id);
            stateItem.RemoveMarker(id);
            return true;
        }

        public bool RemoveMarkers(int stateId)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.Id == stateId)
                {
                    _states[i].ClearMarkers();
                    _petriNet.RemoveMarkersFromState(stateId);
                    return true;
                }
            }
            return false;
        }

        public void RemoveMarkers(ColouredMarkerType markerType)
        {
            int typeId = (int)ItemType.Marker + (int)markerType;
            List<int> listId;
            for (int i = 0; i < _states.Count; ++i)
            {
                for (int j = 0; j < _states[i].Markers.Count; ++i)
                {
                    if (_states[i].Markers[j].Item1.TypeId == typeId)
                    {
                        listId = _states[i].Markers[j].Item2;
                        for (int k = 0; k < listId.Count; ++k)
                        {
                            _petriNet.RemoveMarker(listId[k]);
                        }
                        _states[i].RemoveMarkerAt(j);
                        break;
                    }
                }
            }
        }

        public void RemoveMarkers(int stateId, ColouredMarkerType markerType)
        {
            int typeId = (int)ItemType.Marker + (int)markerType;
            List<int> listId;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.Id == stateId)
                {
                    for (int j = 0; j < _states[i].Markers.Count; ++i)
                    {
                        if (_states[i].Markers[j].Item1.TypeId == typeId)
                        {
                            listId = _states[i].Markers[j].Item2;
                            for (int k = 0; k < listId.Count; ++k)
                            {
                                _petriNet.RemoveMarker(listId[k]);
                            }
                            _states[i].RemoveMarkerAt(j);
                            return;
                        }
                    }
                    return;
                }
            }
        }

        public bool RemoveState(int id)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.Id == id)
                {
                    RemoveLinksFromState(_states[i]);
                    _petriNet.RemoveState(id);
                    _states.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveStates(ColouredStateType stateType)
        {
            int typeId = (int)ItemType.State + (int)stateType;
            for (int i = _states.Count - 1; i >= 0; --i)
            {
                if (_states[i].State.TypeId == typeId)
                {
                    RemoveLinksFromState(_states[i]);
                    _petriNet.RemoveState(_states[i].State.Id);
                    _states.RemoveAt(i);
                }
            }
        }

        public bool RemoveTransition(int id)
        {
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.Id == id)
                {
                    RemoveLinksFromTransition(_transitions[i]);
                    _petriNet.RemoveTransition(id);
                    _transitions.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void RemoveTransitions(ColouredStateType transitionType)
        {
            int typeId = (int)ItemType.State + (int)transitionType;
            for (int i = _transitions.Count - 1; i >= 0; --i)
            {
                if (_transitions[i].Transition.TypeId == typeId)
                {
                    RemoveLinksFromTransition(_transitions[i]);
                    _petriNet.RemoveTransition(_transitions[i].Transition.Id);
                    _transitions.RemoveAt(i);
                }
            }
        }

        public void RemoveSelectedStates()
        {
            for (int i = 0; i < _selectedStates.Count; ++i)
            {
                RemoveState(_selectedStates[i]);
            }
        }

        public void RemoveSelectedTransitions()
        {
            for (int i = 0; i < _selectedTransitions.Count; ++i)
            {
                RemoveTransition(_selectedTransitions[i]);
            }
        }

        public void RemoveSelectedLinks()
        {
            for (int i = 0; i < _selectedLinks.Count; ++i)
            {
                RemoveLink(_selectedLinks[i]);
            }
        }

        public void RemoveSelectedItems()
        {
            RemoveSelectedLinks();
            RemoveSelectedTransitions();
            RemoveSelectedStates();
        }
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
            int typeId = (int)ItemType.Marker + (int)markerType;
            for (int i = 0; i < _states.Count; ++i)
            {
                for (int j = 0; j < _states[i].Markers.Count; ++j)
                {
                    if ((_states[i].Markers[j].Item1.TypeId == typeId)
                        && (_states[i].Markers[j].Item2.Count > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Contains(ColouredStateType stateType)
        {
            int type = (int)ItemType.State + (int)stateType;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.TypeId == type)
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
                if (_transitions[i].Transition.TypeId == type)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(int id, ColouredMarkerType markerType)
        {
            int typeId = (int)ItemType.Marker + (int)markerType;
            List<int> listId;
            for (int i = 0; i < _states.Count; ++i)
            {
                for (int j = 0; j < _states[i].Markers.Count; ++j)
                {
                    if (_states[i].Markers[j].Item1.TypeId == typeId)
                    {
                        listId = _states[i].Markers[j].Item2;
                        for (int k = 0; k < listId.Count; ++k)
                        {
                            if (listId[k] == id)
                            {
                                return true;
                            }
                        }
                        break;
                    }
                }
            }
            return false;
        }

        public bool Contains(int id, ColouredStateType stateType)
        {
            int type = (int)ItemType.State + (int)stateType;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.Id == id)
                {
                    return (_states[i].State.TypeId == type);
                }
            }
            return false;
        }

        public bool Contains(int id, ColouredTransitionType transitionType)
        {
            int type = (int)ItemType.Transition + (int)transitionType;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.Id == id)
                {
                    return (_transitions[i].Transition.TypeId == type);
                }
            }
            return false;
        }

        public bool ContainsMarker(int id)
        {
            List<int> listId;
            for (int i = 0; i < _states.Count; ++i)
            {
                for (int j = 0; j < _states[i].Markers.Count; ++j)
                {
                    listId = _states[i].Markers[j].Item2;
                    for (int k = 0; k < listId.Count; ++k)
                    {
                        if (listId[k] == id)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool ContainsState(int id)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.Id == id)
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
                if (_transitions[i].Transition.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsLink(int stateId, int transitionId)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return false;
            }
            for (int i = 0; i < state.InputLinks.Count; ++i)
            {
                if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                {
                    return true;
                }
            }
            for (int i = 0; i < state.OutputLinks.Count; ++i)
            {
                if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsLink(int stateId, int transitionId, LinkDirection direction)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return false;
            }
            if (direction == LinkDirection.FromStateToTransition)
            {
                for (int i = 0; i < state.OutputLinks.Count; ++i)
                {
                    if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < state.InputLinks.Count; ++i)
                {
                    if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region Count Functions
        public int GetMarkerCount()
        {
            int count = 0;
            for (int i = 0; i < _states.Count; ++i)
            {
                for (int j = 0; j < _states[i].Markers.Count; ++j)
                {
                    count += _states[i].Markers[j].Item2.Count;
                }
            }
            return count;
        }

        public int GetMarkerCount(ColouredMarkerType markerType)
        {
            int typeId = (int)ItemType.Marker + (int)markerType;
            int count = 0;
            for (int i = 0; i < _states.Count; ++i)
            {
                for (int j = 0; j < _states[i].Markers.Count; ++j)
                {
                    if (_states[i].Markers[j].Item1.TypeId == typeId)
                    {
                        count += _states[i].Markers[j].Item2.Count;
                        break;
                    }
                }
            }
            return count;
        }

        public int GetTransitionCount(ColouredTransitionType transitionType)
        {
            int typeId = (int)ItemType.Transition + (int)transitionType;
            int count = 0;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.TypeId == typeId)
                {
                    ++count;
                }
            }
            return count;
        }

        public int GetStateCount(ColouredStateType stateType)
        {
            int typeId = (int)ItemType.State + (int)stateType;
            int count = 0;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.TypeId == typeId)
                {
                    ++count;
                }
            }
            return count;
        }

        public int GetLinkCount(int stateId, int transitionId)
        {
            var state = FindStateById(stateId);
            int count = 0;
            if (ReferenceEquals(state, null))
            {
                return 0;
            }
            for (int i = 0; i < state.InputLinks.Count; ++i)
            {
                if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                {
                    ++count;
                    break;
                }
            }
            for (int i = 0; i < state.OutputLinks.Count; ++i)
            {
                if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                {
                    ++count;
                    break;
                }
            }
            return count;
        }

        public int GetLinkCount(int stateId, int transitionId, LinkDirection direction)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return 0;
            }
            if (direction == LinkDirection.FromStateToTransition)
            {
                for (int i = 0; i < state.OutputLinks.Count; ++i)
                {
                    if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        return 1;
                    }
                }
            }
            else
            {
                for (int i = 0; i < state.InputLinks.Count; ++i)
                {
                    if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public int GetSelectedStatesCount()
        {
            return _selectedStates.Count;
        }

        public int GetSelectedTransitionsCount()
        {
            return _selectedTransitions.Count;
        }

        public int GetSelectedLinksCount()
        {
            return _selectedLinks.Count;
        }
        #endregion

        #region Find Functions
        public List<GraphicsLinkWrapper> FindLinks(int x, int y)
        {
            var foundLinks = new List<GraphicsLinkWrapper>();
            for (int i = 0; i < _links.Count; ++i)
            {
                if (_links[i].Link.IsCollision(x, y))
                {
                    foundLinks.Add(_links[i]);
                }
            }
            return foundLinks;
        }

        public List<GraphicsLinkWrapper> FindLinks(int x, int y, LinkDirection direction)
        {
            var foundLinks = new List<GraphicsLinkWrapper>();
            for (int i = 0; i < _links.Count; ++i)
            {
                if ((_links[i].Direction == direction) && _links[i].Link.IsCollision(x, y))
                {
                    foundLinks.Add(_links[i]);
                }
            }
            return foundLinks;
        }

        public List<GraphicsLinkWrapper> FindLinks(int x, int y, int w, int h,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
        {
            var foundLinks = new List<GraphicsLinkWrapper>();
            for (int i = 0; i < _links.Count; ++i)
            {
                if (_links[i].Link.IsCollision(x, y, w, h, overlap))
                {
                    foundLinks.Add(_links[i]);
                }
            }
            return foundLinks;
        }

        public List<GraphicsLinkWrapper> FindLinks(int x, int y, int w, int h, LinkDirection direction,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
        {
            var foundLinks = new List<GraphicsLinkWrapper>();
            for (int i = 0; i < _links.Count; ++i)
            {
                if ((_links[i].Direction == direction) && _links[i].Link.IsCollision(x, y, w, h, overlap))
                {
                    foundLinks.Add(_links[i]);
                }
            }
            return foundLinks;
        }

        public List<GraphicsStateWrapper> FindStates(int x, int y)
        {
            var foundStates = new List<GraphicsStateWrapper>();
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.IsCollision(x, y))
                {
                    foundStates.Add(_states[i]);
                }
            }
            return foundStates;
        }

        public List<GraphicsStateWrapper> FindStates(int x, int y, ColouredStateType stateType)
        {
            int typeId = (int)ItemType.State + (int)stateType;
            var foundStates = new List<GraphicsStateWrapper>();
            for (int i = 0; i < _states.Count; ++i)
            {
                if ((_states[i].State.TypeId == typeId) && _states[i].State.IsCollision(x, y))
                {
                    foundStates.Add(_states[i]);
                }
            }
            return foundStates;
        }

        public List<GraphicsStateWrapper> FindStates(int x, int y, int w, int h,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
        {
            var foundStates = new List<GraphicsStateWrapper>();
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.IsCollision(x, y, w, h, overlap))
                {
                    foundStates.Add(_states[i]);
                }
            }
            return foundStates;
        }

        public List<GraphicsStateWrapper> FindStates(int x, int y, int w, int h, ColouredStateType stateType,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
        {
            int typeId = (int)ItemType.State + (int)stateType;
            var foundStates = new List<GraphicsStateWrapper>();
            for (int i = 0; i < _states.Count; ++i)
            {
                if ((_states[i].State.TypeId == typeId)
                    && _states[i].State.IsCollision(x, y, w, h, overlap))
                {
                    foundStates.Add(_states[i]);
                }
            }
            return foundStates;
        }

        public List<GraphicsTransitionWrapper> FindTransitions(int x, int y)
        {
            var foundTransitions = new List<GraphicsTransitionWrapper>();
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.IsCollision(x, y))
                {
                    foundTransitions.Add(_transitions[i]);
                }
            }
            return foundTransitions;
        }

        public List<GraphicsTransitionWrapper> FindTransitions(int x, int y, ColouredTransitionType transitionType)
        {
            int typeId = (int)ItemType.Transition + (int)transitionType;
            var foundTransitions = new List<GraphicsTransitionWrapper>();
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if ((_transitions[i].Transition.TypeId == typeId) &&
                    _transitions[i].Transition.IsCollision(x, y))
                {
                    foundTransitions.Add(_transitions[i]);
                }
            }
            return foundTransitions;
        }

        public List<GraphicsTransitionWrapper> FindTransitions(int x, int y, int w, int h,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
        {
            var foundTransitions = new List<GraphicsTransitionWrapper>();
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.IsCollision(x, y, w, h, overlap))
                {
                    foundTransitions.Add(_transitions[i]);
                }
            }
            return foundTransitions;
        }

        public List<GraphicsTransitionWrapper> FindTransitions(int x, int y, int w, int h, ColouredTransitionType transitionType,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
        {
            int typeId = (int)ItemType.Transition + (int)transitionType;
            var foundTransitions = new List<GraphicsTransitionWrapper>();
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if ((_transitions[i].Transition.TypeId == typeId) &&
                    _transitions[i].Transition.IsCollision(x, y, w, h, overlap))
                {
                    foundTransitions.Add(_transitions[i]);
                }
            }
            return foundTransitions;
        }

        public List<int> GetSelectedStates()
        {
            return new List<int>(_selectedStates);
        }

        public List<int> GetSelectedTransitions()
        {
            return new List<int>(_selectedTransitions);
        }

        public List<int> GetSelectedLinks()
        {
            return new List<int>(_selectedLinks);
        }
        #endregion

        #region Select Functions
        public void Select(int x, int y)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if ((!_states[i].State.IsSelected()) && _states[i].State.IsCollision(x, y))
                {
                    _states[i].State.Select();
                    _selectedStates.Add(_states[i].State.Id);
                }
            }
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if ((!_transitions[i].Transition.IsSelected())
                    && _transitions[i].Transition.IsCollision(x, y))
                {
                    _transitions[i].Transition.Select();
                    _selectedTransitions.Add(_transitions[i].Transition.Id);
                }
            }
            for (int i = 0; i < _links.Count; ++i)
            {
                if ((!_links[i].Link.IsSelected()) && _links[i].Link.IsCollision(x, y))
                {
                    _links[i].Link.Select();
                    _selectedLinks.Add(_links[i].Link.Id);
                }
            }
        }

        public void Select(int x, int y, int w, int h)
        {
            var overlap = Style.SelectionMode;
            for (int i = 0; i < _states.Count; ++i)
            {
                if ((!_states[i].State.IsSelected()) &&
                    _states[i].State.IsCollision(x, y, w, h, overlap))
                {
                    _states[i].State.Select();
                    _selectedStates.Add(_states[i].State.Id);
                }
            }
            for(int i = 0; i < _transitions.Count; ++i)
            {
                if ((!_transitions[i].Transition.IsSelected())
                    && _transitions[i].Transition.IsCollision(x, y, w, h, overlap))
                {
                    _transitions[i].Transition.Select();
                    _selectedTransitions.Add(_transitions[i].Transition.Id);
                }
            }
            for (int i = 0; i < _links.Count; ++i)
            {
                if ((!_links[i].Link.IsSelected()) && _links[i].Link.IsCollision(x, y, w, h, overlap))
                {
                    _links[i].Link.Select();
                    _selectedLinks.Add(_links[i].Link.Id);
                }
            }
        }

        public void SelectItems()
        {
            SelectStates();
            SelectTransitions();
            SelectLinks();
        }

        public void SelectLinks()
        {
            _selectedLinks.Clear();
            for (int i = 0; i < _links.Count; ++i)
            {
                _links[i].Link.Select();
                _selectedLinks.Add(_links[i].Link.Id);
            }
        }

        public void SelectLinks(int stateId, int transitionId)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return;
            }
            for (int i = 0; i < state.InputLinks.Count; ++i)
            {
                if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                {
                    state.InputLinks[i].Link.Select();
                    _selectedLinks.Add(state.InputLinks[i].Link.Id);
                    break;
                }
            }
            for (int i = 0; i < state.OutputLinks.Count; ++i)
            {
                if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                {
                    state.OutputLinks[i].Link.Select();
                    _selectedLinks.Add(state.OutputLinks[i].Link.Id);
                    break;
                }
            }
        }

        public void SelectLinks(int stateId, int transitionId, LinkDirection direction)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return;
            }
            if (direction == LinkDirection.FromStateToTransition)
            {
                for (int i = 0; i < state.OutputLinks.Count; ++i)
                {
                    if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        state.OutputLinks[i].Link.Select();
                        _selectedLinks.Add(state.OutputLinks[i].Link.Id);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < state.InputLinks.Count; ++i)
                {
                    if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        state.InputLinks[i].Link.Select();
                        _selectedLinks.Add(state.InputLinks[i].Link.Id);
                        return;
                    }
                }
            }
        }

        public void SelectStates()
        {
            _selectedStates.Clear();
            for (int i = 0; i < _states.Count; ++i)
            {
                _states[i].State.Select();
                _selectedStates.Add(_states[i].State.Id);
            }
        }

        public void SelectStates(ColouredStateType stateType)
        {
            int typeId = (int)ItemType.State + (int)stateType;
            for (int i = 0; i < _states.Count; ++i)
            {
                if ((_states[i].State.TypeId == typeId) && (!_states[i].State.IsSelected()))
                {
                    _states[i].State.Select();
                    _selectedStates.Add(_states[i].State.Id);
                }
            }
        }

        public void SelectTransitions()
        {
            _selectedTransitions.Clear();
            for (int i = 0; i < _transitions.Count; ++i)
            {
                _transitions[i].Transition.Select();
                _selectedTransitions.Add(_transitions[i].Transition.Id);
            }
        }

        public void SelectTransitions(ColouredTransitionType transitionType)
        {
            int typeId = (int)ItemType.Transition + (int)transitionType;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if ((_transitions[i].Transition.TypeId == typeId)
                    && (!_transitions[i].Transition.IsSelected()))
                {
                    _transitions[i].Transition.Select();
                    _selectedTransitions.Add(_transitions[i].Transition.Id);
                }
            }
        }
        #endregion

        #region Deselect Functions
        public void Deselect(int x, int y)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.IsSelected() && _states[i].State.IsCollision(x, y))
                {
                    _states[i].State.Deselect();
                    RemoveFromIdList(_states[i].State.Id, _selectedStates);
                }
            }
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.IsSelected()
                    && _transitions[i].Transition.IsCollision(x, y))
                {
                    _transitions[i].Transition.Deselect();
                    RemoveFromIdList(_transitions[i].Transition.Id, _selectedTransitions);
                }
            }
            for (int i = 0; i < _links.Count; ++i)
            {
                if (_links[i].Link.IsSelected() && _links[i].Link.IsCollision(x, y))
                {
                    _links[i].Link.Deselect();
                    RemoveFromIdList(_links[i].Link.Id, _selectedLinks);
                }
            }
        }

        public void Deselect(int x, int y, int w, int h)
        {
            var overlap = Style.SelectionMode;
            for (int i = 0; i < _states.Count; ++i)
            {
                if (_states[i].State.IsSelected() && _states[i].State.IsCollision(x, y, w, h, overlap))
                {
                    _states[i].State.Deselect();
                    RemoveFromIdList(_states[i].State.Id, _selectedStates);
                }
            }
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if (_transitions[i].Transition.IsSelected()
                    && _transitions[i].Transition.IsCollision(x, y, w, h, overlap))
                {
                    _transitions[i].Transition.Deselect();
                    RemoveFromIdList(_transitions[i].Transition.Id, _selectedTransitions);
                }
            }
            for (int i = 0; i < _links.Count; ++i)
            {
                if (_links[i].Link.IsSelected() && _links[i].Link.IsCollision(x, y, w, h, overlap))
                {
                    _links[i].Link.Deselect();
                    RemoveFromIdList(_links[i].Link.Id, _selectedLinks);
                }
            }
        }

        public void DeselectItems()
        {
            DeselectStates();
            DeselectTransitions();
            DeselectLinks();
        }

        public void DeselectLinks()
        {
            _selectedLinks.Clear();
            for (int i = 0; i < _links.Count; ++i)
            {
                _links[i].Link.Deselect();
            }
        }

        public void DeselectLinks(int stateId, int transitionId)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return;
            }
            for (int i = 0; i < state.InputLinks.Count; ++i)
            {
                if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                {
                    state.InputLinks[i].Link.Deselect();
                    RemoveFromIdList(state.InputLinks[i].Link.Id, _selectedLinks);
                    break;
                }
            }
            for (int i = 0; i < state.OutputLinks.Count; ++i)
            {
                if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                {
                    state.OutputLinks[i].Link.Deselect();
                    RemoveFromIdList(state.OutputLinks[i].Link.Id, _selectedLinks);
                    break;
                }
            }
        }

        public void DeselectLinks(int stateId, int transitionId, LinkDirection direction)
        {
            var state = FindStateById(stateId);
            if (ReferenceEquals(state, null))
            {
                return;
            }
            if (direction == LinkDirection.FromStateToTransition)
            {
                for (int i = 0; i < state.OutputLinks.Count; ++i)
                {
                    if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        state.OutputLinks[i].Link.Deselect();
                        RemoveFromIdList(state.OutputLinks[i].Link.Id, _selectedLinks);
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < state.InputLinks.Count; ++i)
                {
                    if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        state.InputLinks[i].Link.Deselect();
                        RemoveFromIdList(state.InputLinks[i].Link.Id, _selectedLinks);
                        return;
                    }
                }
            }
        }

        public void DeselectStates()
        {
            _selectedStates.Clear();
            for (int i = 0; i < _states.Count; ++i)
            {
                _states[i].State.Deselect();
            }
        }

        public void DeselectStates(ColouredStateType stateType)
        {
            int typeId = (int)ItemType.State + (int)stateType;
            for (int i = 0; i < _states.Count; ++i)
            {
                if ((_states[i].State.TypeId == typeId) && _states[i].State.IsSelected())
                {
                    _states[i].State.Deselect();
                    RemoveFromIdList(_states[i].State.Id, _selectedStates);
                }
            }
        }

        public void DeselectTransitions()
        {
            _selectedTransitions.Clear();
            for (int i = 0; i < _transitions.Count; ++i)
            {
                _transitions[i].Transition.Deselect();
            }
        }

        public void DeselectTransitions(ColouredTransitionType transitionType)
        {
            int typeId = (int)ItemType.Transition + (int)transitionType;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                if ((_transitions[i].Transition.TypeId == typeId) && _transitions[i].Transition.IsSelected())
                {
                    _transitions[i].Transition.Deselect();
                    RemoveFromIdList(_transitions[i].Transition.Id, _selectedTransitions);
                }
            }
        }
        #endregion

        #region Move Functions
        public void Move(int dx, int dy)
        {
            for (int i = 0; i < _states.Count; ++i)
            {
                _states[i].State.Move(dx, dy);
            }
            for (int i = 0; i < _transitions.Count; ++i)
            {
                _transitions[i].Transition.Move(dx, dy);
            }
            for (int i = 0; i < _links.Count; ++i)
            {
                _links[i].Link.Move(dx, dy);
            }
        }

        public bool Move(int dx, int dy, int id)
        {
            var state = FindStateById(id);
            if (ReferenceEquals(state, null))
            {
                var transition = FindTransitionById(id);
                if (ReferenceEquals(transition, null))
                {
                    var link = FindLinkById(id);
                    if (ReferenceEquals(link, null))
                    {
                        return false;
                    }
                    MoveLink(dx, dy, link);
                    return true;
                }
                MoveTransition(dx, dy, transition);
                return true;
            }
            MoveState(dx, dy, state);
            return true;
        }

        public void MoveSelectedItems(int dx, int dy)
        {
            var movedStates = new List<int>(_selectedStates);
            var movedTransitions = new List<int>(_selectedTransitions);
            GraphicsLinkWrapper link;
            for (int i = 0; i < _selectedLinks.Count; ++i)
            {
                link = FindLinkById(_selectedLinks[i]);
                AddToIdList(link.State.State.Id, movedStates);
                AddToIdList(link.Transition.Transition.Id, movedTransitions);
            }
            for (int i = 0; i < movedStates.Count; ++i)
            {
                MoveState(dx, dy, FindStateById(movedStates[i]));
            }
            for (int i = 0; i < movedTransitions.Count; ++i)
            {
                MoveTransition(dx, dy, FindTransitionById(movedTransitions[i]));
            }
        }
        #endregion

        #region Serialization Functions
        public bool Serialize(string filePath)
        {
            var petriNetXml = new Core.Serialize.ColouredPetriNetXml();
            petriNetXml.Style = Core.Serialize.PetriNetXmlSerializer.ToXml(Style);
            petriNetXml.Items = ConvertItemsToXml();
            return Core.Serialize.PetriNetXmlSerializer.Serialize(filePath, petriNetXml);
        }

        public bool Deserialize(string filePath)
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
        #endregion

        #region SelectionArea Functions
        public void SetSelectionArea(int x, int y, int w, int h)
        {
            _selectionArea.X = x;
            _selectionArea.Y = y;
            _selectionArea.Width = w;
            _selectionArea.Height = h;
            _selectionArea.Visible = true;
            _selectionArea.HorizontalDirection = HorizontalDirection.Right;
            _selectionArea.VerticalDirection = VerticalDirection.Top;
            Select(x, y, w, h);
        }

        public void UpdateSelectionAreaByPos(int x, int y)
        {
            int dx = x - _selectionArea.X;
            int dy = y - _selectionArea.Y;
            _selectionArea.Width = System.Math.Abs(dx);
            _selectionArea.Height = System.Math.Abs(dy);
            if (dx < 0)
            {
                _selectionArea.HorizontalDirection = HorizontalDirection.Left;
                if (dy < 0)
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Bottom;
                    Select(x, y, _selectionArea.Width, _selectionArea.Height);
                }
                else
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Top;
                    Select(x, _selectionArea.Y, _selectionArea.Width, _selectionArea.Height);
                }
            }
            else
            {
                _selectionArea.HorizontalDirection = HorizontalDirection.Right;
                if (dy < 0)
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Bottom;
                    Select(_selectionArea.X, y, _selectionArea.Width, _selectionArea.Height);
                }
                else
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Top;
                    Select(_selectionArea.X, _selectionArea.Y, _selectionArea.Width, _selectionArea.Height);
                }
            }
        }

        public void UpdateSelectionArea(int w, int h)
        {
            _selectionArea.Width = w;
            _selectionArea.Height = h;
            Select(_selectionArea.X, _selectionArea.Y, w, h);
        }

        public void HideSelectionArea()
        {
            _selectionArea.Visible = false;
        }
        #endregion

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
                _states[i].Draw(graphics);
            }
            _selectionArea.Draw(graphics);
        }

        #region Helpful functions
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

        private GraphicsLinkWrapper FindLinkById(int id)
        {
            for (int i = 0; i < _links.Count; ++i)
            {
                if (_links[i].Link.Id == id)
                {
                    return _links[i];
                }
            }
            return null;
        }

        private bool RemoveOutputLink(GraphicsStateWrapper state, int stateId, int transitionId)
        {
            GraphicsTransitionWrapper transition;
            for (int i = 0; i < state.OutputLinks.Count; ++i)
            {
                transition = state.OutputLinks[i].Transition;
                if (transition.Transition.Id == transitionId)
                {
                    int id = state.OutputLinks[i].Link.Id;
                    RemoveFromIdList(id, _selectedLinks);
                    RemoveFromLinkList(id, transition.InputLinks);
                    RemoveFromLinkList(id, _links);
                    state.OutputLinks.RemoveAt(i);
                    _petriNet.RemoveStateToTransitionLink(stateId, transitionId);
                    return true;
                }
            }
            return false;
        }

        private bool RemoveInputLink(GraphicsStateWrapper state, int stateId, int transitionId)
        {
            GraphicsTransitionWrapper transition;
            for (int i = 0; i < state.InputLinks.Count; ++i)
            {
                transition = state.InputLinks[i].Transition;
                if (transition.Transition.Id == transitionId)
                {
                    int id = state.InputLinks[i].Link.Id;
                    RemoveFromIdList(id, _selectedLinks);
                    RemoveFromLinkList(id, transition.OutputLinks);
                    RemoveFromLinkList(id, _links);
                    state.InputLinks.RemoveAt(i);
                    _petriNet.RemoveTransitionToStateLink(stateId, transitionId);
                    return true;
                }
            }
            return false;
        }

        private void AddToIdList(int id, List<int> listId)
        {
            for (int i = 0; i < listId.Count; ++i)
            {
                if (listId[i] == id)
                {
                    return;
                }
            }
            listId.Add(id);
        }

        private void RemoveFromIdList(int id, List<int> listId)
        {
            for (int i = 0; i < listId.Count; ++i)
            {
                if (listId[i] == id)
                {
                    listId.RemoveAt(i);
                    return;
                }
            }
        }

        private void RemoveFromLinkList(int id, List<GraphicsLinkWrapper> linkList)
        {
            for (int i = 0; i < linkList.Count; ++i)
            {
                if (linkList[i].Link.Id == id)
                {
                    linkList.RemoveAt(i);
                    return;
                }
            }
        }

        private void RemoveLinksFromState(GraphicsStateWrapper stateItem)
        {
            int id;
            for (int i = stateItem.InputLinks.Count - 1; i >= 0; --i)
            {
                id = stateItem.InputLinks[i].Link.Id;
                RemoveFromIdList(id, _selectedLinks);
                RemoveFromLinkList(id, stateItem.InputLinks[i].Transition.OutputLinks);
                //_petriNet.RemoveTransitionToStateLink(stateItem.InputLinks[i].Transition.Transition.Id,
                //    stateItem.InputLinks[i].State.State.Id);
                RemoveFromLinkList(id, _links);
                stateItem.InputLinks.RemoveAt(i);
            }
            for (int i = stateItem.OutputLinks.Count - 1; i >= 0; --i)
            {
                id = stateItem.OutputLinks[i].Link.Id;
                RemoveFromIdList(id, _selectedLinks);
                RemoveFromLinkList(id, stateItem.OutputLinks[i].Transition.InputLinks);
                //_petriNet.RemoveStateToTransitionLink(stateItem.OutputLinks[i].State.State.Id,
                //    stateItem.OutputLinks[i].Transition.Transition.Id);
                RemoveFromLinkList(id, _links);
                stateItem.OutputLinks.RemoveAt(i);
            }
        }

        private void RemoveLinksFromTransition(GraphicsTransitionWrapper transitionItem)
        {
            int id;
            for (int i = transitionItem.InputLinks.Count - 1; i >= 0; --i)
            {
                id = transitionItem.InputLinks[i].Link.Id;
                RemoveFromIdList(id, _selectedLinks);
                RemoveFromLinkList(id, transitionItem.InputLinks[i].State.OutputLinks);
                RemoveFromLinkList(id, _links);
                //_petriNet.RemoveStateToTransitionLink(transitionItem.InputLinks[i].State.State.Id,
                //    transitionItem.InputLinks[i].Transition.Transition.Id);
                transitionItem.InputLinks.RemoveAt(i);
            }
            for (int i = transitionItem.OutputLinks.Count - 1; i >= 0; --i)
            {
                id = transitionItem.OutputLinks[i].Link.Id;
                RemoveFromIdList(id, _selectedLinks);
                RemoveFromLinkList(id, transitionItem.OutputLinks[i].State.InputLinks);
                RemoveFromLinkList(id, _links);
                //_petriNet.RemoveTransitionToStateLink(transitionItem.OutputLinks[i].Transition.Transition.Id, 
                //    transitionItem.OutputLinks[i].State.State.Id);
                transitionItem.OutputLinks.RemoveAt(i);
            }
        }

        private void MoveState(int dx, int dy, GraphicsStateWrapper state)
        {
            for (int i = 0; i < state.InputLinks.Count; ++i)
            {
                state.InputLinks[i].Link.MovePoint1(dx, dy);
            }
            for (int i = 0; i < state.OutputLinks.Count; ++i)
            {
                state.OutputLinks[i].Link.MovePoint1(dx, dy);
            }
            state.State.Move(dx, dy);
        }

        private void MoveTransition(int dx, int dy, GraphicsTransitionWrapper transition)
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

        private void MoveLink(int dx, int dy, GraphicsLinkWrapper link)
        {
            MoveTransition(dx, dy, link.Transition);
            MoveState(dx, dy, link.State);
        }

        private void GetItemsFromXml(Core.Serialize.PetriNetItemsXml itemsXml)
        {
            Core.Serialize.StateXml stateXml;
            GraphicsStateWrapper state;
            GraphicsTransitionWrapper transition;
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
                }
                _states.Add(state);
            }
            for (int i = 0; i < itemsXml.TransitionList.Count; ++i)
            {
                _transitions.Add(new GraphicsTransitionWrapper(GetTransitionGraphicsItemFromXml(itemsXml.TransitionList[i])));
            }
            for (int i = 0; i < itemsXml.LinkList.Count; ++i)
            {
                if (itemsXml.LinkList[i].Direction.Equals("FromState"))
                {
                    graphicsLinkDirection = GraphicsItems.LinkGraphicsItem.LinkDirection.FromP1toP2;
                    wrapperLinkDirection = LinkDirection.FromStateToTransition;
                }
                else
                {
                    graphicsLinkDirection = GraphicsItems.LinkGraphicsItem.LinkDirection.FromP2toP1;
                    wrapperLinkDirection = LinkDirection.FromTransitionToState;
                }
                state = FindStateById(itemsXml.LinkList[i].StateId);
                transition = FindTransitionById(itemsXml.LinkList[i].TransitionId);
                _links.Add(new GraphicsLinkWrapper(state, transition,
                    new GraphicsItems.LinkGraphicsItem(itemsXml.LinkList[i].Id, (int)ItemType.Link,
                    state.State.Center, transition.Transition.Center, graphicsLinkDirection),
                    wrapperLinkDirection));
            }
        }

        private GraphicsItems.GraphicsItem GetStateGraphicsItemFromXml(Core.Serialize.StateXml stateXml)
        {
            switch (stateXml.Type)
            {
                case "RoundState":
                    return new GraphicsItems.RoundGraphicsItem(stateXml.Id,
                        (int)ItemType.State + (int)ColouredStateType.RoundState, _stateZ);
                case "ImageState":
                    return new GraphicsItems.ImageGraphicsItem(stateXml.Id,
                        (int)ItemType.State + (int)ColouredStateType.ImageState, null, _stateZ);
            }
            return null;
        }

        private GraphicsItems.GraphicsItem GetTransitionGraphicsItemFromXml(Core.Serialize.TransitionXml transitionXml)
        {
            switch (transitionXml.Type)
            {
                case "RectangleTransition":
                    return new GraphicsItems.RectangleGraphicsItem(transitionXml.Id,
                        (int)ItemType.Transition + (int)ColouredTransitionType.RectangleTransition,
                        10, 10, _stateZ);
                case "RhombTransition":
                    return new GraphicsItems.RhombGraphicsItem(transitionXml.Id,
                        (int)ItemType.Transition + (int)ColouredTransitionType.RhombTransition, _stateZ);
            }
            return null;
        }

        private GraphicsItems.GraphicsItem GetMarkerGraphicsItemFromXml(Core.Serialize.MarkerXml markerXml)
        {
            switch (markerXml.Type)
            {
                case "RoundMarker":
                    return new GraphicsItems.RoundGraphicsItem(markerXml.Id,
                        (int)ItemType.Marker + (int)ColouredMarkerType.RoundMarker, _stateZ);
                case "RhombMarker":
                    return new GraphicsItems.RhombGraphicsItem(markerXml.Id,
                        (int)ItemType.Marker + (int)ColouredMarkerType.RhombMarker, _stateZ);
                case "TriangleMarker":
                    return new GraphicsItems.TriangleGraphicsItem(markerXml.Id,
                        (int)ItemType.Marker + (int)ColouredMarkerType.TriangleMarker,
                        new Point(0, 0), 10, _stateZ);
            }
            return null;
        }

        private Core.Serialize.PetriNetItemsXml ConvertItemsToXml()
        {
            var itemsXml = new Core.Serialize.PetriNetItemsXml();
            Core.Serialize.StateXml stateXml;
            List<int> listId;
            string markerType;
            // Add States
            for (int i = 0; i < _states.Count; ++i)
            {
                stateXml = new Core.Serialize.StateXml(_states[i].State.Id, _states[i].State.Center.X,
                    _states[i].State.Center.Y, GetStateTypeName(_states[i].State.TypeId));
                // Add Markers
                for (int j = 0; j < _states[i].Markers.Count; ++j)
                {
                    markerType = GetMarkerTypeName(_states[i].Markers[j].Item1.TypeId);
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
                    GetTransitionTypeName(_transitions[i].Transition.TypeId)));
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

        private string GetStateTypeName(int typeId)
        {
            int stateType = typeId - (int)ItemType.State;
            switch (stateType)
            {
                case (int)ColouredStateType.RoundState:
                    return "RoundState";
                case (int)ColouredStateType.ImageState:
                    return "ImageState";
            }
            return "";
        }

        private string GetTransitionTypeName(int typeId)
        {
            int transitionType = typeId - (int)ItemType.Transition;
            switch (transitionType)
            {
                case (int)ColouredTransitionType.RectangleTransition:
                    return "RectangleTransition";
                case (int)ColouredTransitionType.RhombTransition:
                    return "RhombTransition";
            }
            return "";
        }

        private string GetMarkerTypeName(int typeId)
        {
            int markerType = typeId - (int)ItemType.Marker;
            switch (markerType)
            {
                case (int)ColouredMarkerType.RoundMarker:
                    return "RoundMarker";
                case (int)ColouredMarkerType.RhombMarker:
                    return "RhombMarker";
                case (int)ColouredMarkerType.TriangleMarker:
                    return "TriangleMarker";
            }
            return "";
        }
        #endregion
    }
}
