using System;
using System.Collections;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        public Interfaces.IMarkerStorage Markers;
        public delegate void ForEachMarkerFunction(Interfaces.IMarkerWrapper marker);

        private class MarkerStorage : Interfaces.IMarkerStorage
        {
            public ArrayList _markers;
            private ColouredPetriNet _parent;

            public MarkerStorage(ColouredPetriNet parent)
            {
                _parent = parent;
                _markers = new ArrayList();
            }

            public Interfaces.IMarkerWrapper this[int id]
            {
                get
                {
                    Interfaces.IOneTypeItemList itemList;
                    Interfaces.IMarkerWrapper marker;
                    for (int i = 0; i < _markers.Count; ++i)
                    {
                        itemList = _markers[i] as Interfaces.IOneTypeItemList;
                        for (int j = 0; j < itemList.Items.Count; ++j)
                        {
                            marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                            if (marker.Id == id)
                            {
                                return marker;
                            }
                        }
                    }
                    return null;
                }
            }

            public Interfaces.IMarkerWrapper this[int type, int index]
            {
                get
                {
                    if ((type < 0) || (index < 0))
                    {
                        return null;
                    }
                    Interfaces.IOneTypeItemList itemList;
                    for (int i = 0; i < _markers.Count; ++i)
                    {
                        itemList = _markers[i] as Interfaces.IOneTypeItemList;
                        if (itemList.Type == type)
                        {
                            if (index >= itemList.Items.Count)
                            {
                                return null;
                            }
                            else
                            {
                                return (itemList.Items[index] as Interfaces.IMarkerWrapper);
                            }
                        }
                    }
                    return null;
                }
            }

            public MarkerWrapper<T> GetWrapper<T>(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                MarkerWrapper<T> marker;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as MarkerWrapper<T>;
                        if (marker.Id == id)
                        {
                            return marker;
                        }
                    }
                }
                return null;
            }

            public MarkerWrapper<T> GetWrapper<T>(int type, int index)
            {
                if ((type < 0) || (index < 0))
                {
                    return null;
                }
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        if (index >= itemList.Items.Count)
                        {
                            return null;
                        }
                        else
                        {
                            return (itemList.Items[index] as MarkerWrapper<T>);
                        }
                    }
                }
                return null;
            }

            public T GetValue<T>(int id)
            {
                var wrapper = GetWrapper<T>(id);
                if (ReferenceEquals(wrapper, null))
                {
                    return default(T);
                }
                return wrapper.Value;
            }

            public T GetValue<T>(int type, int index)
            {
                var wrapper = GetWrapper<T>(type, index);
                if (ReferenceEquals(wrapper, null))
                {
                    return default(T);
                }
                return wrapper.Value;
            }

            public bool IsExist(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                        if (marker.Id == id)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }

            public bool Contains(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetCount()
            {
                return _markers.Count;
            }

            public int GetCount(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        return itemList.Items.Count;
                    }
                }
                return 0;
            }

            public int GetTypeId<T>()
            {
                OneTypeItemList<MarkerWrapper<T>> itemList;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as OneTypeItemList<MarkerWrapper<T>>;
                    if (!ReferenceEquals(itemList, null))
                    {
                        return itemList.Type;
                    }
                }
                return -1;
            }

            public Tuple<int, int> Create<T>(int stateId, T value)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return new Tuple<int, int>(-1, -1);
                }
                int type;
                int id = _parent._idGenerator.Next();
                var storage = GetStorage<T>();
                if (ReferenceEquals(null, storage))
                {
                    type = _parent._typeGenerator.Next();
                    storage = new OneTypeItemList<MarkerWrapper<T>>(type);
                    _markers.Add(storage); 
                }
                else
                {
                    type = storage.Type;
                }
                storage.Items.Add(new MarkerWrapper<T>(id, type, stateId, value));
                state.AddMarker(id);
                return new Tuple<int, int>(id, type);
            }

            public int Create<T>(int type, int stateId, T value)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return -1;
                }
                int id = _parent._idGenerator.Next();
                var storage = GetStorage(type);
                if (ReferenceEquals(storage, null))
                {
                    storage = new OneTypeItemList<MarkerWrapper<T>>(type);
                    _markers.Add(storage);
                }
                else
                {
                    if (_parent._typeGenerator.CurrentId < type)
                    {
                        _parent._typeGenerator.Reset(type);
                    }
                }
                storage.Items.Add(new MarkerWrapper<T>(id, type, stateId, value));
                state.AddMarker(id);
                return id;
            }

            public int Add<T>(int id, int stateId, T value)
            {
                if (IsExist(id))
                {
                    return -1;
                }
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return -1;
                }
                int type;
                if (_parent._idGenerator.CurrentId < id)
                {
                    _parent._idGenerator.Reset(id);
                }
                var storage = GetStorage<T>();
                if (ReferenceEquals(null, storage))
                {
                    type = _parent._typeGenerator.Next();
                    storage = new OneTypeItemList<MarkerWrapper<T>>(type);
                    _markers.Add(storage);
                }
                else
                {
                    type = storage.Type;
                }
                storage.Items.Add(new MarkerWrapper<T>(id, type, stateId, value));
                state.AddMarker(id);
                return type;
            }

            public bool Add<T>(int id, int type, int stateId, T value)
            {
                if (IsExist(id))
                {
                    return false;
                }
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return false;
                }
                if (_parent._idGenerator.CurrentId < id)
                {
                    _parent._idGenerator.Reset(id);
                }
                var storage = GetStorage(type);
                if (ReferenceEquals(storage, null))
                {
                    storage = new OneTypeItemList<MarkerWrapper<T>>(type);
                    _markers.Add(storage);
                }
                else
                {
                    if (_parent._typeGenerator.CurrentId < type)
                    {
                        _parent._typeGenerator.Reset(type);
                    }
                }
                storage.Items.Add(new MarkerWrapper<T>(id, type, stateId, value));
                state.AddMarker(id);
                return true;
            }

            public bool Remove(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                        if (marker.Id == id)
                        {
                            var state = _parent.States[marker.StateId];
                            state.RemoveMarker(id);
                            itemList.Items.RemoveAt(j);
                            return true;
                        }
                    }
                }
                return false;
            }

            public bool Remove(int id, int type)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                        if (marker.Id == id)
                        {
                            var state = _parent.States[marker.StateId];
                            state.RemoveMarker(id);
                            itemList.Items.RemoveAt(j);
                            return true;
                        }
                    }
                }
                return false;
            }

            public bool RemoveByType(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                Interfaces.IStateWrapper state;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                        state = _parent.States[marker.StateId];
                        state.RemoveMarker(marker.Id);
                    }
                    itemList.Items.Clear();
                    return true;
                }
                return false;
            }

            public bool RemoveType(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                Interfaces.IStateWrapper state;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                        state = _parent.States[marker.StateId];
                        state.RemoveMarker(marker.Id);
                    }
                    _markers.RemoveAt(i);
                    return true;
                }
                return false;
            }

            public bool RemoveFromState(int stateId)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return false;
                }
                RemoveFromState(state);
                return true;
            }

            public bool RemoveFromState(int type, int stateId, int count = -1)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return false;
                }
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                int markerId;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = state.GetMarkerCount() - 1; j >= 0; --j)
                    {
                        markerId = state.GetMarker(j);
                        for (int k = 0; k < itemList.Items.Count; ++k)
                        {
                            marker = itemList.Items[k] as Interfaces.IMarkerWrapper;
                            if (marker.Id == markerId)
                            {
                                itemList.Items.RemoveAt(k);
                                state.RemoveMarker(j);
                                break;
                            }
                        }
                    }
                }
                return true;
            }

            public void Clear()
            {
                ((StateStorage)_parent.States).DisconnectAllMarkers();
                _markers.Clear();
            }

            public bool Move(int markerId, int newStateId)
            {
                var marker = this[markerId];
                if (ReferenceEquals(marker, null))
                {
                    return false;
                }
                var oldState = _parent.States[marker.StateId];
                if (ReferenceEquals(oldState, null))
                {
                    return false;
                }
                var newState = _parent.States[newStateId];
                if (ReferenceEquals(newState, null))
                {
                    return false;
                }
                oldState.RemoveMarker(markerId);
                newState.AddMarker(markerId);
                marker.StateId = newStateId;
                return true;
            }

            public bool Move(int markerId, int markerType, int newStateId, int newStateType, int oldStateType = -1)
            {
                var marker = this.GetInterface(markerType, markerId);
                if (ReferenceEquals(marker, null))
                {
                    return false;
                }
                var states = (StateStorage)_parent.States;
                var oldState = (oldStateType < 0 ? states[marker.StateId]
                    : states.GetInterface(oldStateType, marker.StateId));
                if (ReferenceEquals(oldState, null))
                {
                    return false;
                }
                var newState = states.GetInterface(newStateType, newStateId);
                if (ReferenceEquals(newState, null))
                {
                    return false;
                }
                oldState.RemoveMarker(markerId);
                newState.AddMarker(markerId);
                marker.StateId = newStateId;
                return true;
            }

            public bool MoveAll(int oldStateId, int newStateId)
            {
                var oldState = _parent.States[oldStateId];
                if (ReferenceEquals(oldState, null))
                {
                    return false;
                }
                var newState = _parent.States[newStateId];
                if (ReferenceEquals(newState, null))
                {
                    return false;
                }
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < oldState.GetMarkerCount(); ++i)
                {
                    marker = this[oldState.GetMarker(i)];
                    newState.AddMarker(marker.Id);
                    marker.StateId = newStateId;
                }
                oldState.RemoveAllMarkers();
                return true;
            }

            public bool MoveAll(int type, int oldStateId, int newStateId)
            {
                var oldState = _parent.States[oldStateId];
                if (ReferenceEquals(oldState, null))
                {
                    return false;
                }
                var newState = _parent.States[newStateId];
                if (ReferenceEquals(newState, null))
                {
                    return false;
                }
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < oldState.GetMarkerCount(); ++i)
                {
                    marker = this[oldState.GetMarker(i)];
                    newState.AddMarker(marker.Id);
                    marker.StateId = newStateId;
                }
                oldState.RemoveAllMarkers();
                return true;
            }

            public void MoveByRules()
            {
                var states = ((StateStorage)_parent.States)._states;
                var prevAccRules = (AccumulateRuleStorage)_parent.PrevAccumulateRules;
                var nextAccRules = (AccumulateRuleStorage)_parent.NextAccumulateRules;
                var moveRules = ((MoveRuleStorage)_parent.MoveRules);
                Interfaces.IOneTypeItemList stateStorage;
                Interfaces.IStateWrapper state;
                Interfaces.IStateWrapper outputState;
                Interfaces.ITransitionWrapper outputTransition;
                List<int> outputTransitions;
                List<int> outputStates;
                List<Tuple<int, List<int>>> markerList;
                List<Interfaces.IMarkerWrapper> markerWrapperList;
                PetriNetMoveRule moveRule;
                PetriNetAccumulateRule accumulateRule;
                // sequence: accumulate(prev) -> move -> accumulate(next)
                for (int i = 0; i < states.Count; ++i)
                {
                    stateStorage = states[i] as Interfaces.IOneTypeItemList;
                    if (ReferenceEquals(null, stateStorage))
                    {
                        continue;
                    }
                    for (int j = 0; j < stateStorage.Items.Count; ++j)
                    {
                        state = stateStorage.Items[j] as Interfaces.IStateWrapper;
                        outputTransitions = state.OutputLinkNodes;
                        for (int k = 0; k < outputTransitions.Count; ++k)
                        {
                            outputTransition = _parent.Transitions[outputTransitions[k]];
                            outputStates = outputTransition.OutputLinkNodes;
                            for (int r = 0; r < outputStates.Count; ++r)
                            {
                                outputState = _parent.States[outputStates[r]];
                                markerList = GetStateMarkerList(outputState);
                                // prev accumulate
                                accumulateRule = prevAccRules.GetSuitableRule(state.Type, markerList);
                                if ((!ReferenceEquals(null, accumulateRule)) &&
                                    (!ReferenceEquals(null, accumulateRule.AccumulateFunction)))
                                {
                                    markerWrapperList = GetMarkerWrapperList(markerList);
                                    accumulateRule.AccumulateFunction(state, markerWrapperList);
                                }
                                // move
                                for (int m = 0; m < markerList.Count; ++m)
                                {
                                    moveRule = moveRules.GetSuitableRule(state.Type, outputState.Type,
                                        outputTransition.Type, markerList[m].Item1, markerList[m].Item2.Count);
                                    if (!ReferenceEquals(null, moveRule))
                                    {
                                        markerWrapperList = GetMarkerWrapperList(markerList);
                                        moveRule.MoveFunction(state, outputState, outputTransition, markerWrapperList);
                                    }
                                }
                                // next accumulate
                                accumulateRule = nextAccRules.GetSuitableRule(outputState.Type, markerList);
                                if (!ReferenceEquals(null, accumulateRule))
                                {
                                    markerWrapperList = GetMarkerWrapperList(markerList);
                                    accumulateRule.AccumulateFunction(state, markerWrapperList);
                                }
                            }
                        }
                    }
                }
            }

            public void ForEachMarker(ForEachMarkerFunction function)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        function(itemList.Items[j] as Interfaces.IMarkerWrapper);
                    }
                }
            }

            #region Helpful Functions
            public Interfaces.IOneTypeItemList GetStorage(int type)
            {
                Interfaces.IOneTypeItemList storage;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    storage = _markers[i] as Interfaces.IOneTypeItemList;
                    if (storage.Type == type)
                    {
                        return storage;
                    }
                }
                return null;
            }

            public OneTypeItemList<MarkerWrapper<T>> GetStorage<T>()
            {
                OneTypeItemList<MarkerWrapper<T>> storage;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    storage = _markers[i] as OneTypeItemList<MarkerWrapper<T>>;
                    if (!ReferenceEquals(null, storage))
                    {
                        return storage;
                    }
                }
                return null;
            }

            public void RemoveFromState(Interfaces.IStateWrapper state)
            {
                for (int i = 0; i < state.GetMarkerCount(); ++i)
                {
                    RemoveFromStorage(state.GetMarker(i));
                }
                state.RemoveAllMarkers();
            }

            public void RemoveFromStorage(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                        if (marker.Id == id)
                        {
                            itemList.Items.RemoveAt(j);
                            return;
                        }
                    }
                }
            }

            public Interfaces.IMarkerWrapper GetInterface(int type, int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < _markers.Count; ++i)
                {
                    itemList = _markers[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        marker = itemList.Items[j] as Interfaces.IMarkerWrapper;
                        if (marker.Id == id)
                        {
                            return marker;
                        }
                    }
                    return null;
                }
                return null;
            }

            public List<Tuple<int, List<int>>> GetStateMarkerList(Interfaces.IStateWrapper state)
            {
                var markerList = new List<Tuple<int, List<int>>>();
                List<int> idList;
                Interfaces.IMarkerWrapper marker;
                bool isFound;
                for (int i = 0; i < state.GetMarkerCount(); ++i)
                {
                    marker = this[state.GetMarker(i)];
                    isFound = false;
                    for (int j = 0; j < markerList.Count; ++j)
                    {
                        if (markerList[j].Item1 == marker.Type)
                        {
                            idList = markerList[j].Item2;
                            idList.Add(marker.Id);
                            markerList[j] = new Tuple<int, List<int>>(markerList[j].Item1, idList);
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        idList = new List<int>();
                        idList.Add(marker.Id);
                        markerList.Add(new Tuple<int, List<int>>(marker.Type, idList));
                    }
                }
                return markerList;
            }

            public List<Interfaces.IMarkerWrapper> GetMarkerWrapperList(List<Tuple<int, List<int>>> markerList)
            {
                var markerWrapperList = new List<Interfaces.IMarkerWrapper>();
                Interfaces.IMarkerWrapper marker;
                for (int i = 0; i < markerList.Count; ++i)
                {
                    for (int j = 0; j < markerList[i].Item2.Count; ++j)
                    {
                        marker = this[markerList[i].Item2[j]];
                        markerWrapperList.Add(marker);
                    }
                }
                return markerWrapperList;
            }
            #endregion
        }
    }
}
