using System;
using System.Collections;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        public Interfaces.ITransitionStorage Transitions;
        public delegate void ForEachTransitionFunction(Interfaces.ITransitionWrapper transition);

        private class TransitionStorage : Interfaces.ITransitionStorage
        {
            public ArrayList _transitions;
            private ColouredPetriNet _parent;

            public TransitionStorage(ColouredPetriNet parent)
            {
                _parent = parent;
                _transitions = new ArrayList();
            }

            public Interfaces.ITransitionWrapper this[int id]
            {
                get
                {
                    Interfaces.IOneTypeItemList itemList;
                    Interfaces.ITransitionWrapper transition;
                    for (int i = 0; i < _transitions.Count; ++i)
                    {
                        itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                        for (int j = 0; j < itemList.Items.Count; ++j)
                        {
                            transition = itemList.Items[j] as Interfaces.ITransitionWrapper;
                            if (transition.Id == id)
                            {
                                return transition;
                            }
                        }
                    }
                    return null;
                }
            }

            public Interfaces.ITransitionWrapper this[int type, int index]
            {
                get
                {
                    if ((type < 0) || (index < 0))
                    {
                        return null;
                    }
                    Interfaces.IOneTypeItemList itemList;
                    for (int i = 0; i < _transitions.Count; ++i)
                    {
                        itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                        if (itemList.Type == type)
                        {
                            if (index >= itemList.Items.Count)
                            {
                                return null;
                            }
                            else
                            {
                                return (itemList.Items[index] as Interfaces.ITransitionWrapper);
                            }
                        }
                    }
                    return null;
                }
            }

            public TransitionWrapper<T> GetWrapper<T>(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                TransitionWrapper<T> transition;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        transition = itemList.Items[j] as TransitionWrapper<T>;
                        if (transition.Id == id)
                        {
                            return transition;
                        }
                    }
                }
                return null;
            }

            public TransitionWrapper<T> GetWrapper<T>(int type, int index)
            {
                if ((type < 0) || (index < 0))
                {
                    return null;
                }
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        if (index >= itemList.Items.Count)
                        {
                            return null;
                        }
                        else
                        {
                            return (itemList.Items[index] as TransitionWrapper<T>);
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
                Interfaces.ITransitionWrapper state;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as Interfaces.ITransitionWrapper;
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
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetCount()
            {
                return _transitions.Count;
            }

            public int GetCount(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type == type)
                    {
                        return itemList.Items.Count;
                    }
                }
                return 0;
            }

            public int GetTypeId<T>()
            {
                OneTypeItemList<TransitionWrapper<T>> itemList;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as OneTypeItemList<TransitionWrapper<T>>;
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
                    storage = new OneTypeItemList<TransitionWrapper<T>>(type);
                    _transitions.Add(storage);
                }
                else
                {
                    type = storage.Type;
                }
                storage.Items.Add(new TransitionWrapper<T>(id, type, value));
                return new Tuple<int, int>(id, type);
            }

            public int Create<T>(int type, T value)
            {
                int id = _parent._idGenerator.Next();
                var storage = GetStorage(type);
                if (ReferenceEquals(storage, null))
                {
                    storage = new OneTypeItemList<TransitionWrapper<T>>(type);
                    _transitions.Add(storage);
                }
                else
                {
                    if (_parent._typeGenerator.CurrentId < type)
                    {
                        _parent._typeGenerator.Reset(type);
                    }
                }
                storage.Items.Add(new TransitionWrapper<T>(id, type, value));
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
                    storage = new OneTypeItemList<TransitionWrapper<T>>(type);
                    _transitions.Add(storage);
                }
                else
                {
                    type = storage.Type;
                }
                storage.Items.Add(new TransitionWrapper<T>(id, type, value));
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
                    storage = new OneTypeItemList<TransitionWrapper<T>>(type);
                    _transitions.Add(storage);
                }
                else
                {
                    if (_parent._typeGenerator.CurrentId < type)
                    {
                        _parent._typeGenerator.Reset(type);
                    }
                }
                storage.Items.Add(new TransitionWrapper<T>(id, type, value));
                return true;
            }

            public bool Remove(int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.ITransitionWrapper transition;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        transition = itemList.Items[j] as Interfaces.ITransitionWrapper;
                        if (transition.Id == id)
                        {
                            RemoveLinks(transition);
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
                Interfaces.ITransitionWrapper transition;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        transition = itemList.Items[j] as Interfaces.ITransitionWrapper;
                        if (transition.Id == id)
                        {
                            RemoveLinks(transition);
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
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        RemoveLinks(itemList.Items[j] as Interfaces.ITransitionWrapper);
                    }
                    itemList.Items.Clear();
                    return true;
                }
                return false;
            }

            public bool RemoveType(int type)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        RemoveLinks(itemList.Items[j] as Interfaces.ITransitionWrapper);
                    }
                    _transitions.RemoveAt(i);
                    return true;
                }
                return false;
            }

            public void Clear()
            {
                _parent.Links.Clear();
                _transitions.Clear();
            }

            public void ForEachTransition(ForEachTransitionFunction function)
            {
                Interfaces.IOneTypeItemList itemList;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        function(itemList.Items[j] as Interfaces.ITransitionWrapper);
                    }
                }
            }

            #region Helpful Functions
            public Interfaces.IOneTypeItemList GetStorage(int type)
            {
                Interfaces.IOneTypeItemList storage;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    storage = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (storage.Type == type)
                    {
                        return storage;
                    }
                }
                return null;
            }

            public OneTypeItemList<TransitionWrapper<T>> GetStorage<T>()
            {
                OneTypeItemList<TransitionWrapper<T>> storage;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    storage = _transitions[i] as OneTypeItemList<TransitionWrapper<T>>;
                    if (!ReferenceEquals(null, storage))
                    {
                        return storage;
                    }
                }
                return null;
            }

            public Interfaces.ITransitionWrapper GetInterface(int type, int id)
            {
                Interfaces.IOneTypeItemList itemList;
                Interfaces.ITransitionWrapper transition;
                for (int i = 0; i < _transitions.Count; ++i)
                {
                    itemList = _transitions[i] as Interfaces.IOneTypeItemList;
                    if (itemList.Type != type)
                    {
                        continue;
                    }
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        transition = itemList.Items[j] as Interfaces.ITransitionWrapper;
                        if (transition.Id == id)
                        {
                            return transition;
                        }
                    }
                    return null;
                }
                return null;
            }

            public void RemoveLinks(Interfaces.ITransitionWrapper transition)
            {
                for (int i = 0; i < transition.InputLinkNodes.Count; ++i)
                {
                    ColouredPetriNet.RemoveFromIdList(_parent.States[transition.InputLinkNodes[i]].OutputLinkNodes,
                        transition.InputLinkNodes[i]);
                }
                for (int i = 0; i < transition.OutputLinkNodes.Count; ++i)
                {
                    ColouredPetriNet.RemoveFromIdList(_parent.States[transition.OutputLinkNodes[i]].InputLinkNodes,
                        transition.OutputLinkNodes[i]);
                }
            }
            #endregion

        }
    }
}
