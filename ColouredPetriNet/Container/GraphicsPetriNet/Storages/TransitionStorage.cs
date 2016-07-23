using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.ITransitionStorage Transitions;
        public delegate void ForEachTransitionFunction(TransitionWrapper transition);

        private class TransitionStorage : Interfaces.ITransitionStorage
        {
            public List<TransitionWrapper> Transitions;
            public List<TransitionWrapper> SelectedTransitions;
            private GraphicsPetriNet _parent;

            public int Count { get { return Transitions.Count; } }
            public int SelectedTransitionCount { get { return SelectedTransitions.Count; } }

            public TransitionStorage(GraphicsPetriNet parent)
            {
                _parent = parent;
                Transitions = new List<TransitionWrapper>();
                SelectedTransitions = new List<TransitionWrapper>();
            }

            public TransitionWrapper this[int id]
            {
                get
                {
                    for (int i = 0; i < Transitions.Count; ++i)
                    {
                        if (Transitions[i].Id == id)
                        {
                            return Transitions[i];
                        }
                    }
                    return null;
                }
            }

            public TransitionWrapper this[int type, int index]
            {
                get
                {
                    if (index < 0) return null;
                    int counter = -1;
                    for (int i = 0; i < Transitions.Count; ++i)
                    {
                        if ((Transitions[i].Type == type) && (index == ++counter))
                        {
                            return Transitions[i];
                        }
                    }
                    return null;
                }
            }

            public GraphicsItems.GraphicsItem GetItem(int id)
            {
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if (Transitions[i].Id == id)
                    {
                        return Transitions[i].Transition;
                    }
                }
                return null;
            }

            public GraphicsItems.GraphicsItem GetItem(int type, int index)
            {
                if (index < 0) return null;
                int counter = -1;
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if ((Transitions[i].Type == type) && (index == ++counter))
                    {
                        return Transitions[i].Transition;
                    }
                }
                return null;
            }

            public bool IsExist(int id)
            {
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if (Transitions[i].Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool Contains(int type)
            {
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if (Transitions[i].Type == type)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetCount(int type)
            {
                int counter = 0;
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if (Transitions[i].Type == type)
                    {
                        ++counter;
                    }
                }
                return counter;
            }

            public TransitionWrapper Add(GraphicsItems.GraphicsItem item)
            {
                if (ReferenceEquals(item, null) || IsExist(item.Id))
                {
                    return null;
                }
                if (_parent._idGenerator.CurrentId < item.Id)
                {
                    _parent._idGenerator.Reset(item.Id);
                }
                var transition = new TransitionWrapper(item);
                Transitions.Add(transition);
                return transition;
            }

            public bool Remove(int id)
            {
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if (Transitions[i].Id == id)
                    {
                        PrepareTransitionToRemove(Transitions[i]);
                        Transitions.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public void RemoveByType(int type)
            {
                for (int i = Transitions.Count - 1; i >= 0; --i)
                {
                    if (Transitions[i].Type == type)
                    {
                        PrepareTransitionToRemove(Transitions[i]);
                        Transitions.RemoveAt(i);
                    }
                }
            }

            public void RemoveSelectedTransitions()
            {
                for (int i = SelectedTransitions.Count - 1; i >= 0; --i)
                {
                    Remove(SelectedTransitions[i].Id);
                }
            }

            public void Clear()
            {
                _parent.Links.Clear();
                SelectedTransitions.Clear();
                Transitions.Clear();
            }

            public List<TransitionWrapper> Find(int x, int y)
            {
                var foundTransitions = new List<TransitionWrapper>();
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if (Transitions[i].Transition.IsCollision(x, y))
                    {
                        foundTransitions.Add(Transitions[i]);
                    }
                }
                return foundTransitions;
            }

            public List<TransitionWrapper> Find(int x, int y, int type)
            {
                var foundTransitions = new List<TransitionWrapper>();
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if ((Transitions[i].Type == type) &&
                        Transitions[i].Transition.IsCollision(x, y))
                    {
                        foundTransitions.Add(Transitions[i]);
                    }
                }
                return foundTransitions;
            }

            public List<TransitionWrapper> Find(int x, int y, int w, int h,
                GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
            {
                var foundTransitions = new List<TransitionWrapper>();
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if (Transitions[i].Transition.IsCollision(x, y, w, h, overlap))
                    {
                        foundTransitions.Add(Transitions[i]);
                    }
                }
                return foundTransitions;
            }

            public List<TransitionWrapper> Find(int x, int y, int w, int h, int type,
                GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
            {
                var foundTransitions = new List<TransitionWrapper>();
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if ((Transitions[i].Type == type) &&
                        Transitions[i].Transition.IsCollision(x, y, w, h, overlap))
                    {
                        foundTransitions.Add(Transitions[i]);
                    }
                }
                return foundTransitions;
            }

            public TransitionWrapper GetSelectedTransition(int index)
            {
                return SelectedTransitions[index];
            }

            public TransitionWrapper GetSelectedTransitionById(int id)
            {
                for (int i = 0; i < SelectedTransitions.Count; ++i)
                {
                    if (SelectedTransitions[i].Id == id)
                    {
                        return SelectedTransitions[i];
                    }
                }
                return null;
            }

            public void ForEachTransition(ForEachTransitionFunction function)
            {
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    function(Transitions[i]);
                }
            }

            public void ForEachSelectedTransition(GraphicsPetriNet.ForEachTransitionFunction function)
            {
                for (int i = 0; i < SelectedTransitions.Count; ++i)
                {
                    function(SelectedTransitions[i]);
                }
            }

            public void Select()
            {
                SelectedTransitions.Clear();
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    Transitions[i].Transition.Select();
                    SelectedTransitions.Add(Transitions[i]);
                }
            }

            public void Select(int type)
            {
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    if ((Transitions[i].Type == type)
                        && (!Transitions[i].Transition.IsSelected()))
                    {
                        Transitions[i].Transition.Select();
                        SelectedTransitions.Add(Transitions[i]);
                    }
                }
            }

            public void Deselect()
            {
                SelectedTransitions.Clear();
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    Transitions[i].Transition.Deselect();
                }
            }

            public void Deselect(int type)
            {
                for (int i = SelectedTransitions.Count - 1; i >= 0; --i)
                {
                    if (SelectedTransitions[i].Type == type)
                    {
                        Transitions[i].Transition.Deselect();
                        SelectedTransitions.RemoveAt(i);
                    }
                }
            }

            #region Helpful Functions
            public int GetSelectedTransitionIndex(TransitionWrapper transition)
            {
                for (int i = 0; i < SelectedTransitions.Count; ++i)
                {
                    if (SelectedTransitions[i] == transition)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void RemoveAllLinks()
            {
                for (int i = 0; i < Transitions.Count; ++i)
                {
                    Transitions[i].InputLinks.Clear();
                    Transitions[i].OutputLinks.Clear();
                }
            }

            public void PrepareTransitionToRemove(TransitionWrapper transition)
            {
                RemoveLinks(transition);
                int index = GetSelectedTransitionIndex(transition);
                if (index >= 0)
                {
                    SelectedTransitions.RemoveAt(index);
                }
            }

            public void RemoveLinks(TransitionWrapper transition)
            {
                StateWrapper state;
                for (int i = 0; i < transition.InputLinks.Count; ++i)
                {
                    state = transition.InputLinks[i].State;
                    for (int j = 0; j < state.OutputLinks.Count; ++j)
                    {
                        if (state.OutputLinks[j].Transition.Id == transition.Id)
                        {
                            state.OutputLinks.RemoveAt(j);
                        }
                    }
                }
                for (int i = 0; i < transition.OutputLinks.Count; ++i)
                {
                    state = transition.OutputLinks[i].State;
                    for (int j = 0; j < state.InputLinks.Count; ++j)
                    {
                        if (state.InputLinks[j].Transition.Id == transition.Id)
                        {
                            state.InputLinks.RemoveAt(j);
                        }
                    }
                }
            }
            #endregion
        }
    }
}
