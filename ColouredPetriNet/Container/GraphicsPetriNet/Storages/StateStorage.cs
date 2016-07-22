using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.IStateStorage States;
        public delegate void ForEachStateFunction(StateWrapper state);

        private class StateStorage : Interfaces.IStateStorage
        {
            public List<StateWrapper> States;
            public List<StateWrapper> SelectedStates;
            private GraphicsPetriNet _parent;

            public int Count { get { return States.Count; } }

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

            public void Clear()
            {
                _parent.Links.Clear();
                SelectedStates.Clear();
                States.Clear();
            }

            public void ForEachState(ForEachStateFunction function)
            {
                for (int i = 0; i < States.Count; ++i)
                {
                    function(States[i]);
                }
            }

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
            #endregion
        }
    }
}
