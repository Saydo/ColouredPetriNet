using System;
using System.Collections;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        public Interfaces.IStateStorage States;
        public delegate void ForEachStateFunction(Interfaces.IStateWrapper state);

        private class StateStorage : Interfaces.IStateStorage
        {
            public ArrayList _states;
            private ColouredPetriNet _parent;

            public StateStorage(ColouredPetriNet parent)
            {
                _parent = parent;
                _states = new ArrayList();
            }

            public Interfaces.IStateWrapper this[int id]
            {
                get
                {
                    Interfaces.IOneTypeItemList itemList;
                    Interfaces.IStateWrapper state;
                    for (int i = 0; i < _states.Count; ++i)
                    {
                        itemList = _states[i] as Interfaces.IOneTypeItemList;
                        for (int j = 0; j < itemList.Items.Count; ++j)
                        {
                            state = itemList.Items[j] as Interfaces.IStateWrapper;
                            if (state.Id == id)
                            {
                                return state;
                            }
                        }
                    }
                    return null;
                }
            }

            public Interfaces.IStateWrapper this[int type, int index]
            {
                get
                {
                    if ((type < 0) || (index < 0))
                    {
                        return null;
                    }
                    Interfaces.IOneTypeItemList itemList;
                    for (int i = 0; i < _states.Count; ++i)
                    {
                        itemList = _states[i] as Interfaces.IOneTypeItemList;
                        if (itemList.Type == type)
                        {
                            if (index >= itemList.Items.Count)
                            {
                                return null;
                            }
                            else
                            {
                                return (itemList.Items[index] as Interfaces.IStateWrapper);
                            }
                        }
                    }
                    return null;
                }
            }

            public StateWrapper<T> GetWrapper<T>(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                StateWrapper<T> state;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as StateWrapper<T>;
                        if (state.Id == id)
                        {
                            return state;
                        }
                    }
                }
                return null;
            }

            public StateWrapper<T> GetWrapper<T>(int type, int index)
            {
                if ((type < 0) || (index < 0))
                {
                    return null;
                }
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        if (index >= itemList.Items.Count)
                        {
                            return null;
                        }
                        else
                        {
                            return (itemList.Items[index] as StateWrapper<T>);
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
                Interfaces.IStateWrapper state;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as Interfaces.IStateWrapper;
                        if (state.Id == id)
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
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetCount()
            {
                return _states.Count;
            }

            public int GetCount(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        return itemList.Items.Count;
                    }
                }
                return 0;
            }

            public int GetTypeId<T>()
            {
                OneTypeItemList<StateWrapper<T>> itemList;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as OneTypeItemList<StateWrapper<T>>;
                    if (!ReferenceEquals(itemList, null))
                    {
                        return itemList.Type;
                    }
                }
                return -1;
            }

            public Tuple<int, int> Create<T>(T value)
            {
                int id = _parent._idGenerator.Next();
                int type;
                var storage = GetStorage<T>();
                if (ReferenceEquals(null, storage))
                {
                    type = _parent._typeGenerator.Next();
                    storage = new OneTypeItemList<StateWrapper<T>>(type);
                    _states.Add(storage);
                }
                else
                {
                    type = storage.Type;
                }
                storage.Items.Add(new StateWrapper<T>(id, type, value));
                return new Tuple<int, int>(id, type);
            }

            public int Create<T>(int type, T value)
            {
                int id = _parent._idGenerator.Next();
                var storage = GetStorage(type);
                if (ReferenceEquals(storage, null))
                {
                    storage = new OneTypeItemList<StateWrapper<T>>(type);
                    _states.Add(storage);
                }
                else
                {
                    if (_parent._typeGenerator.CurrentId < type)
                    {
                        _parent._typeGenerator.Reset(type);
                    }
                }
                storage.Items.Add(new StateWrapper<T>(id, type, value));
                return id;
            }

            public int Add<T>(int id, T value)
            {
                if (IsExist(id))
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
                    storage = new OneTypeItemList<StateWrapper<T>>(type);
                    _states.Add(storage);
                }
                else
                {
                    type = storage.Type;
                }
                storage.Items.Add(new StateWrapper<T>(id, type, value));
                return type;
            }

            public bool Add<T>(int id, int type, T value)
            {
                if (IsExist(id))
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
                    storage = new OneTypeItemList<StateWrapper<T>>(type);
                    _states.Add(storage);
                }
                else
                {
                    if (_parent._typeGenerator.CurrentId < type)
                    {
                        _parent._typeGenerator.Reset(type);
                    }
                }
                storage.Items.Add(new StateWrapper<T>(id, type, value));
                return true;
            }

            public bool Remove(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IStateWrapper state;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as Interfaces.IStateWrapper;
                        if (state.Id == id)
                        {
                            ((MarkerStorage)_parent.Markers).RemoveFromState(state);
                            RemoveLinks(state);
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
                Interfaces.IStateWrapper state;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as Interfaces.IStateWrapper;
                        if (state.Id == id)
                        {
                            ((MarkerStorage)_parent.Markers).RemoveFromState(state);
                            RemoveLinks(state);
                            itemList.Items.RemoveAt(j);
                            return true;
                        }
                    }
                    return false;
                }
                return false;
            }

            public bool RemoveByType(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        ((MarkerStorage)_parent.Markers).RemoveFromState(itemList.Items[j] as Interfaces.IStateWrapper);
                        RemoveLinks(itemList.Items[j] as Interfaces.IStateWrapper);
                    }
                    itemList.Items.Clear();
                    return true;
                }
                return false;
            }

            public bool RemoveType(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        ((MarkerStorage)_parent.Markers).RemoveFromState(itemList.Items[j] as Interfaces.IStateWrapper);
                        RemoveLinks(itemList.Items[j] as Interfaces.IStateWrapper);
                    }
                    _states.RemoveAt(i);
                    return true;
                }
                return false;
            }

            public void Clear()
            {
                ((MarkerStorage)_parent.Markers)._markers.Clear();
                _parent.Links.Clear();
                _states.Clear();
            }

            public void ForEachState(ForEachStateFunction function)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        function(itemList.Items[j] as Interfaces.IStateWrapper);
                    }
                }
            }

            #region Helpful Functions
            public Interfaces.IOneTypeItemList GetStorage(int type)
            {
                Interfaces.IOneTypeItemList storage;
                for (int i = 0; i < _states.Count; ++i)
                {
                    storage = _states[i] as Interfaces.IOneTypeItemList;
                    if (storage.Type == type)
                    {
                        return storage;
                    }
                }
                return null;
            }

            public OneTypeItemList<StateWrapper<T>> GetStorage<T>()
            {
                OneTypeItemList<StateWrapper<T>> storage;
                for (int i = 0; i < _states.Count; ++i)
                {
                    storage = _states[i] as OneTypeItemList<StateWrapper<T>>;
                    if (!ReferenceEquals(null, storage))
                    {
                        return storage;
                    }
                }
                return null;
            }

            public void DisconnectAllMarkers()
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        (itemList.Items[j] as Interfaces.IStateWrapper).RemoveAllMarkers();
                    }
                }
            }

            public Interfaces.IStateWrapper GetInterface(int type, int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IStateWrapper state;
                for (int i = 0; i < _states.Count; ++i)
                {
                    itemList = _states[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as Interfaces.IStateWrapper;
                        if (state.Id == id)
                        {
                            return state;
                        }
                    }
                    return null;
                }
                return null;
            }

            public void RemoveLinks(Interfaces.IStateWrapper state)
            {
                for (int i = 0; i < state.InputLinkNodes.Count; ++i)
                {
                    ColouredPetriNet.RemoveFromIdList(_parent.Transitions[state.InputLinkNodes[i]].OutputLinkNodes,
                        state.InputLinkNodes[i]);
                }
                for (int i = 0; i < state.OutputLinkNodes.Count; ++i)
                {
                    ColouredPetriNet.RemoveFromIdList(_parent.Transitions[state.OutputLinkNodes[i]].InputLinkNodes,
                        state.OutputLinkNodes[i]);
                }
            }
            #endregion
        }
    }
}
