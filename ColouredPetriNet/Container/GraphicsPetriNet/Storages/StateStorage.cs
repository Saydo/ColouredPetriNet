using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.IStateStorage States;
        private StateStorage _states;
        public delegate void ForEachStateFunction(StateWrapper state);

        private class StateStorage : Interfaces.IStateStorage
        {
            public List<StateWrapper> States;
            public List<StateWrapper> SelectedStates;
            private GraphicsPetriNet _parent;

            public int Count { get { return States.Count; } }
            public int SelectedStateCount { get { return SelectedStates.Count; } }

            public StateStorage(GraphicsPetriNet parent)
            {
                _parent = parent;
                States = new List<StateWrapper>();
                SelectedStates = new List<StateWrapper>();
            }

            public StateWrapper this[int id]
            {
                get
                {
                    for (int i = 0; i < States.Count; ++i)
                    {
                        if (States[i].Id == id)
                        {
                            return States[i];
                        }
                    }
                    return null;
                }
            }

            public StateWrapper this[int type, int index]
            {
                get
                {
                    if (index < 0) return null;
                    int counter = -1;
                    for (int i = 0; i < States.Count; ++i)
                    {
                        if ((States[i].Type == type) && (index == ++counter))
                        {
                            return States[i];
                        }
                    }
                    return null;
                }
            }

            public GraphicsItems.GraphicsItem GetItem(int id)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Id == id)
                    {
                        return States[i].State;
                    }
                }
                return null;
            }

            public GraphicsItems.GraphicsItem GetItem(int type, int index)
            {
                if (index < 0) return null;
                int counter = -1;
                for (int i = 0; i < States.Count; ++i)
                {
                    if ((States[i].Type == type) && (index == ++counter))
                    {
                        return States[i].State;
                    }
                }
                return null;
            }

            public bool IsExist(int id)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool Contains(int type)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Type == type)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetCount(int type)
            {
                int counter = 0;
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Type == type)
                    {
                        ++counter;
                    }
                }
                return counter;
            }

            public StateWrapper Add(GraphicsItems.GraphicsItem item)
            {
                if (ReferenceEquals(item, null) || IsExist(item.Id))
                {
                    return null;
                }
                if (_parent._idGenerator.CurrentId < item.Id)
                {
                    _parent._idGenerator.Reset(item.Id);
                }
                var state = new StateWrapper(item);
                States.Add(state);
                return state;
            }

            public bool Remove(int id)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Id == id)
                    {
                        PrepareStateToRemove(States[i]);
                        States.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public void RemoveByType(int type)
            {
                for (int i = States.Count - 1; i >= 0; --i)
                {
                    if (States[i].Type == type)
                    {
                        PrepareStateToRemove(States[i]);
                        States.RemoveAt(i);
                    }
                }
            }

            public void RemoveSelectedStates()
            {
                for (int i = SelectedStates.Count - 1; i >= 0; --i)
                {
                    Remove(SelectedStates[i].Id);
                }
            }

            public void Clear()
            {
                _parent._links.Clear();
                SelectedStates.Clear();
                States.Clear();
            }

            public List<StateWrapper> Find(int x, int y)
            {
                var foundStates = new List<StateWrapper>();
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].State.IsCollision(x, y))
                    {
                        foundStates.Add(States[i]);
                    }
                }
                return foundStates;
            }

            public List<StateWrapper> Find(int x, int y, int type)
            {
                var foundStates = new List<StateWrapper>();
                for (int i = 0; i < States.Count; ++i)
                {
                    if ((States[i].Type == type) &&
                        States[i].State.IsCollision(x, y))
                    {
                        foundStates.Add(States[i]);
                    }
                }
                return foundStates;
            }

            public List<StateWrapper> Find(int x, int y, int w, int h,
                GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
            {
                var foundStates = new List<StateWrapper>();
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].State.IsCollision(x, y, w, h, overlap))
                    {
                        foundStates.Add(States[i]);
                    }
                }
                return foundStates;
            }

            public List<StateWrapper> Find(int x, int y, int w, int h, int type,
                GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
            {
                var foundStates = new List<StateWrapper>();
                for (int i = 0; i < States.Count; ++i)
                {
                    if ((States[i].Type == type) &&
                        States[i].State.IsCollision(x, y, w, h, overlap))
                    {
                        foundStates.Add(States[i]);
                    }
                }
                return foundStates;
            }

            public StateWrapper GetSelectedState(int index)
            {
                return SelectedStates[index];
            }

            public StateWrapper GetSelectedStateById(int id)
            {
                for (int i = 0; i < SelectedStates.Count; ++i)
                {
                    if (SelectedStates[i].Id == id)
                    {
                        return SelectedStates[i];
                    }
                }
                return null;
            }

            public void ForEachState(ForEachStateFunction function)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    function(States[i]);
                }
            }

            public void ForEachSelectedState(ForEachStateFunction function)
            {
                for (int i = 0; i < SelectedStates.Count; ++i)
                {
                    function(SelectedStates[i]);
                }
            }

            public void Select()
            {
                SelectedStates.Clear();
                for (int i = 0; i < States.Count; ++i)
                {
                    States[i].State.Select();
                    SelectedStates.Add(States[i]);
                }
            }

            public void SelectArea(int x, int y)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if ((!States[i].State.IsSelected()) && States[i].State.IsCollision(x, y))
                    {
                        States[i].State.Select();
                        SelectedStates.Add(States[i]);
                    }
                }
            }

            public void SelectArea(int x, int y, int w, int h, GraphicsItems.OverlapType overlap)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if ((!States[i].State.IsSelected()) &&
                        States[i].State.IsCollision(x, y, w, h, overlap))
                    {
                        States[i].State.Select();
                        SelectedStates.Add(States[i]);
                    }
                }
            }

            public void Select(int type)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if ((States[i].Type == type)
                        && (!States[i].State.IsSelected()))
                    {
                        States[i].State.Select();
                        SelectedStates.Add(States[i]);
                    }
                }
            }

            public void Deselect()
            {
                SelectedStates.Clear();
                for (int i = 0; i < States.Count; ++i)
                {
                    States[i].State.Deselect();
                }
            }

            public void DeselectArea(int x, int y)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].State.IsSelected() && States[i].State.IsCollision(x, y))
                    {
                        States[i].State.Deselect();
                        SelectedStates.Remove(States[i]);
                    }
                }
            }

            public void DeselectArea(int x, int y, int w, int h, GraphicsItems.OverlapType overlap)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].State.IsSelected()
                        && States[i].State.IsCollision(x, y, w, h, overlap))
                    {
                        States[i].State.Deselect();
                        SelectedStates.Remove(States[i]);
                    }
                }
            }

            public void Deselect(int type)
            {
                for (int i = SelectedStates.Count - 1; i >= 0; --i)
                {
                    if (SelectedStates[i].Type == type)
                    {
                        States[i].State.Deselect();
                        SelectedStates.RemoveAt(i);
                    }
                }
            }

            public void Move(int dx, int dy)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    MoveState(dx, dy, States[i]);
                }
            }

            public bool Move(int dx, int dy, int id)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Id == id)
                    {
                        MoveState(dx, dy, States[i]);
                        return true;
                    }
                }
                return false;
            }

            #region Marker Storage Functions
            public MarkerInfo GetMarker(int id)
            {
                List<int> markerList;
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        markerList = States[i].Markers[j].Item2;
                        for (int k = 0; k < markerList.Count; ++k)
                        {
                            if (markerList[k] == id)
                            {
                                return new MarkerInfo(id, States[i].Id, States[i].Markers[j].Item1.TypeId);
                            }
                        }
                    }
                }
                return new MarkerInfo(-1, -1, -1);
            }

            public GraphicsItems.IGraphicsItem GetMarkerItem(int id)
            {
                List<int> markerList;
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        markerList = States[i].Markers[j].Item2;
                        for (int k = 0; k < markerList.Count; ++k)
                        {
                            if (markerList[k] == id)
                            {
                                return States[i].Markers[j].Item1;
                            }
                        }
                    }
                }
                return null;
            }

            public bool IsMarkerExist(int id)
            {
                List<int> markerList;
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        markerList = States[i].Markers[j].Item2;
                        for (int k = 0; k < markerList.Count; ++k)
                        {
                            if (markerList[k] == id)
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            public bool ContainsMarker(int type)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        if (States[i].Markers[j].Item1.TypeId == type)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public int GetMarkerCount()
            {
                int counter = 0;
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        counter += States[i].Markers[j].Item2.Count;
                    }
                }
                return counter;
            }

            public int GetMarkerCount(int type)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        if (States[i].Markers[j].Item1.TypeId == type)
                        {
                            return States[i].Markers[j].Item2.Count;
                        }
                    }
                }
                return 0;
            }

            public bool AddMarker(int stateId, GraphicsItems.GraphicsItem item)
            {
                var state = this[stateId];
                if (ReferenceEquals(state, null))
                {
                    return false;
                }
                state.AddMarker(item);
                return true;
            }

            public bool RemoveMarker(int id)
            {
                List<int> markerList;
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        markerList = States[i].Markers[j].Item2;
                        for (int k = 0; k < markerList.Count; ++k)
                        {
                            if (markerList[k] == id)
                            {
                                if (markerList.Count == 1)
                                {
                                    States[i].RemoveMarkerType(j);
                                }
                                else
                                {
                                    States[i].RemoveMarkerAt(j, k);
                                }
                                return true;
                            }
                        }
                    }
                }
                return false;
            }

            public void RemoveMarkerByType(int type)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        if (States[i].Markers[j].Item1.TypeId == type)
                        {
                            States[i].RemoveMarkerType(j);
                            return;
                        }
                    }
                }
            }

            public bool RemoveMarkersFromState(int stateId)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Id == stateId)
                    {
                        States[i].ClearMarkers();
                        return true;
                    }
                }
                return false;
            }

            public bool RemoveMarkersFromState(int type, int stateId, int count = -1)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    if (States[i].Id == stateId)
                    {
                        if (count >= 0)
                        {
                            States[i].RemoveMarkers(type, count);
                        }
                        else
                        {
                            for (int j = 0; j < States[i].Markers.Count; ++j)
                            {
                                if (States[i].Markers[j].Item1.TypeId == type)
                                {
                                    States[i].RemoveMarkerType(j);
                                }
                            }
                        }
                        return true;
                    }
                }
                return false;
            }

            public void ClearMarkers()
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    States[i].ClearMarkers();
                }
            }

            public bool MoveMarker(int markerId, int oldStateId, int newStateId)
            {
                var oldState = this[oldStateId];
                if (ReferenceEquals(oldState, null))
                {
                    return false;
                }
                var newState = this[newStateId];
                if (ReferenceEquals(newState, null))
                {
                    return false;
                }
                List<int> markerList;
                for (int i = 0; i < oldState.Markers.Count; ++i)
                {
                    markerList = oldState.Markers[i].Item2;
                    for (int j = 0; j < markerList.Count; ++j)
                    {
                        if (markerList[j] == markerId)
                        {
                            var markers = new List<int>();
                            newState.AddMarker(markerId, oldState.Markers[i].Item1);
                            oldState.RemoveMarkerAt(i, j);
                            return true;
                        }
                    }
                }
                return false;
            }

            public bool MoveAllMarkers(int oldStateId, int newStateId)
            {
                var oldState = this[oldStateId];
                if (ReferenceEquals(oldState, null))
                {
                    return false;
                }
                var newState = this[newStateId];
                if (ReferenceEquals(newState, null))
                {
                    return false;
                }
                List<int> markerList;
                for (int i = 0; i < oldState.Markers.Count; ++i)
                {
                    markerList = oldState.Markers[i].Item2;
                    for (int j = 0; j < markerList.Count; ++j)
                    {
                        newState.AddMarker(markerList[j], oldState.Markers[i].Item1);
                        oldState.RemoveMarkerAt(i, j);
                    }
                }
                return true;
            }

            public bool MoveAllMarkers(int type, int oldStateId, int newStateId)
            {
                var oldState = this[oldStateId];
                if (ReferenceEquals(oldState, null))
                {
                    return false;
                }
                var newState = this[newStateId];
                if (ReferenceEquals(newState, null))
                {
                    return false;
                }
                List<int> markerList;
                for (int i = 0; i < oldState.Markers.Count; ++i)
                {
                    if (oldState.Markers[i].Item1.TypeId == type)
                    {
                        markerList = oldState.Markers[i].Item2;
                        for (int j = 0; j < markerList.Count; ++j)
                        {
                            newState.AddMarker(markerList[j], oldState.Markers[i].Item1);
                            oldState.RemoveMarkerAt(i, j);
                        }
                        return true;
                    }
                }
                return false;
            }

            public void MoveMarkersByRules()
            {
                /*
                TransitionWrapper transition;
                StateWrapper state;
                var prevAccRules = _parent._prevAccumulateRules;
                var nextAccRules = _parent._nextAccumulateRules;
                var moveRules = _parent._moveRules;
                // sequence: accumulate(prev) -> move -> accumulate(next)
                for (int i = 0; i < States.Count; ++i)
                {
                    prevAccRules.Accumulate(States[i]);
                    for (int j = 0; j < States[i].OutputLinks.Count; ++j)
                    {
                        transition = States[i].OutputLinks[j].Transition;
                        for (int k = 0; k < transition.OutputLinks.Count; ++k)
                        {
                            state = transition.OutputLinks[k].State;
                            moveRules.Move(States[i], state, transition);
                            nextAccRules.Accumulate(state);
                        }
                    }
                }
                */
            }

            public void ForEachMarker(ForEachMarkerFunction function)
            {
                List<int> markerList;
                for (int i = 0; i < States.Count; ++i)
                {
                    for (int j = 0; j < States[i].Markers.Count; ++j)
                    {
                        markerList = States[i].Markers[j].Item2;
                        for (int k = 0; k < markerList.Count; ++k)
                        {
                            function(new MarkerInfo(markerList[k], States[i].Id,
                                States[i].Markers[j].Item1.TypeId), States[i].Markers[j].Item1);
                        }
                    }
                }
            }
            #endregion

            #region Helpful Functions
            public int GetSelectedStateIndex(StateWrapper state)
            {
                for (int i = 0; i < SelectedStates.Count; ++i)
                {
                    if (SelectedStates[i] == state)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void RemoveAllLinks()
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    States[i].InputLinks.Clear();
                    States[i].OutputLinks.Clear();
                }
            }

            public void PrepareStateToRemove(StateWrapper state)
            {
                RemoveLinks(state);
                int index = GetSelectedStateIndex(state);
                if (index >= 0)
                {
                    SelectedStates.RemoveAt(index);
                }
            }

            public void RemoveLinks(StateWrapper state)
            {
                TransitionWrapper transition;
                for (int i = 0; i < state.InputLinks.Count; ++i)
                {
                    transition = state.InputLinks[i].Transition;
                    for (int j = 0; j < transition.OutputLinks.Count; ++j)
                    {
                        if (transition.OutputLinks[j].State.Id == state.Id)
                        {
                            transition.OutputLinks.RemoveAt(j);
                        }
                    }
                }
                for (int i = 0; i < state.OutputLinks.Count; ++i)
                {
                    transition = state.OutputLinks[i].Transition;
                    for (int j = 0; j < transition.InputLinks.Count; ++j)
                    {
                        if (transition.InputLinks[j].State.Id == state.Id)
                        {
                            transition.InputLinks.RemoveAt(j);
                        }
                    }
                }
            }

            public void Draw(System.Drawing.Graphics graphics)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    States[i].Draw(graphics);
                }
            }
            #endregion
        }
    }
}
