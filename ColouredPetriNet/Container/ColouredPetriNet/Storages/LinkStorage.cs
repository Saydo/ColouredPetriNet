using System.Collections.Generic;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        public Interfaces.ILinkStorage Links;
        public delegate void ForEachLinkFunction(Interfaces.IStateWrapper state,
            Interfaces.ITransitionWrapper transition, LinkDirection direction);

        private class LinkStorage : Interfaces.ILinkStorage
        {
            private ColouredPetriNet _parent;

            public LinkStorage(ColouredPetriNet parent)
            {
                _parent = parent;
            }

            public bool Contains(int stateId, int transitionId)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(null, state))
                {
                    return false;
                }
                return state.ContainsLinkNode(transitionId);
            }

            public bool Contains(int stateId, int stateType, int transitionId)
            {
                var state = ((StateStorage)_parent.States).GetInterface(stateType, stateId);
                if (ReferenceEquals(null, state))
                {
                    return false;
                }
                return state.ContainsLinkNode(transitionId);
            }

            public bool Contains(int stateId, int transitionId, LinkType linkType)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(null, state))
                {
                    return false;
                }
                if (linkType == LinkType.Input)
                {
                    return state.ContainsInputLinkNode(transitionId);
                }
                else
                {
                    return state.ContainsOutputLinkNode(transitionId);
                }
            }

            public bool Contains(int stateId, int stateType, int transitionId, LinkType linkType)
            {
                var state = ((StateStorage)_parent.States).GetInterface(stateType, stateId);
                if (ReferenceEquals(null, state))
                {
                    return false;
                }
                if (linkType == LinkType.Input)
                {
                    return state.ContainsInputLinkNode(transitionId);
                }
                else
                {
                    return state.ContainsOutputLinkNode(transitionId);
                }
            }

            public int GetCount()
            {
                var states = ((StateStorage)_parent.States)._states;
                var transitions = ((TransitionStorage)_parent.Transitions)._transitions;
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IColouredPetriNetNode item;
                int count = 0;
                for (int i = 0; i < states.Count; ++i)
                {
                    itemList = states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        item = itemList.Items[j] as Interfaces.IColouredPetriNetNode;
                        count += item.OutputLinkNodes.Count;
                    }
                }
                for (int i = 0; i < transitions.Count; ++i)
                {
                    itemList = transitions[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        item = itemList.Items[j] as Interfaces.IColouredPetriNetNode;
                        count += item.OutputLinkNodes.Count;
                    }
                }
                return count;
            }

            public int GetCount(int stateId, int transitionId)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return 0;
                }
                int count = 0;
                if (state.ContainsInputLinkNode(transitionId))
                {
                    ++count;
                }
                if (state.ContainsOutputLinkNode(transitionId))
                {
                    ++count;
                }
                return count;
            }

            public int GetCount(int stateId, int transitionId, LinkType linkType)
            {
                var state = _parent.States[stateId];
                if (ReferenceEquals(state, null))
                {
                    return 0;
                }
                if (linkType == LinkType.Input)
                {
                    return (state.ContainsInputLinkNode(transitionId) ? 1 : 0);
                }
                else
                {
                    return (state.ContainsOutputLinkNode(transitionId) ? 1 : 0);
                }
            }

            public int GetCount(int stateId, int stateType, int transitionId, LinkType linkType)
            {
                var state = ((StateStorage)_parent.States).GetInterface(stateType, stateId);
                if (ReferenceEquals(state, null))
                {
                    return 0;
                }
                if (linkType == LinkType.Input)
                {
                    return (state.ContainsInputLinkNode(transitionId) ? 1 : 0);
                }
                else
                {
                    return (state.ContainsOutputLinkNode(transitionId) ? 1 : 0);
                }
            }

            public int GetCountByType(int stateType, int transitionType)
            {
                var stateStorage = ((StateStorage)_parent.States).GetStorage(stateType);
                if (ReferenceEquals(stateStorage, null))
                {
                    return 0;
                }
                var transitionStorage = ((TransitionStorage)_parent.Transitions).GetStorage(transitionType);
                if (ReferenceEquals(transitionStorage, null))
                {
                    return 0;
                }
                Interfaces.IStateWrapper state;
                Interfaces.ITransitionWrapper transition;
                int count = 0;
                for (int i = 0; i < stateStorage.Items.Count; ++i)
                {
                    state = stateStorage.Items[i] as Interfaces.IStateWrapper;
                    for (int j = 0; j < state.OutputLinkNodes.Count; ++j)
                    {
                        for (int k = 0; k < transitionStorage.Items.Count; ++k)
                        {
                            transition = transitionStorage.Items[k] as Interfaces.ITransitionWrapper;
                            if (transition.Id == state.OutputLinkNodes[j])
                            {
                                ++count;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < transitionStorage.Items.Count; ++i)
                {
                    transition = transitionStorage.Items[i] as Interfaces.ITransitionWrapper;
                    if (transition.InputLinkNodes.Count > 0)
                    {
                        continue;
                    }
                    for (int j = 0; j < transition.OutputLinkNodes.Count; ++j)
                    {
                        for (int k = 0; k < stateStorage.Items.Count; ++k)
                        {
                            state = stateStorage.Items[k] as Interfaces.IStateWrapper;
                            if (state.Id == transition.OutputLinkNodes[j])
                            {
                                ++count;
                                break;
                            }
                        }
                    }
                }
                return count;
            }

            public bool Add(int stateId, int transitionId, LinkDirection direction)
            {
                var state = _parent.States[stateId];
                if (!ReferenceEquals(null, state))
                {
                    return false;
                }
                var transition = _parent.Transitions[transitionId];
                if (!ReferenceEquals(null, transition))
                {
                    return false;
                }
                if (direction == LinkDirection.FromStateToTransition)
                {
                    state.AddOutputLinkNode(transitionId);
                    transition.AddInputLinkNode(stateId);
                }
                else
                {
                    transition.AddOutputLinkNode(stateId);
                    state.AddInputLinkNode(transitionId);
                }
                return true;
            }

            public bool Add(int stateId, int stateType, int transitionId, int transitionType, LinkDirection direction)
            {
                var state = ((StateStorage)_parent.States).GetInterface(stateType, stateId);
                if (!ReferenceEquals(null, state))
                {
                    return false;
                }
                var transition = ((TransitionStorage)_parent.Transitions).GetInterface(transitionType, transitionId);
                if (!ReferenceEquals(null, transition))
                {
                    return false;
                }
                if (direction == LinkDirection.FromStateToTransition)
                {
                    state.AddOutputLinkNode(transitionId);
                    transition.AddInputLinkNode(stateId);
                }
                else
                {
                    transition.AddOutputLinkNode(stateId);
                    state.AddInputLinkNode(transitionId);
                }
                return true;
            }

            public bool Remove(int stateId, int transitionId)
            {
                var state = _parent.States[stateId];
                if (!ReferenceEquals(null, state))
                {
                    return false;
                }
                var transition = _parent.Transitions[transitionId];
                if (!ReferenceEquals(null, transition))
                {
                    return false;
                }
                if (state.RemoveInputLinkNode(transitionId))
                {
                    transition.RemoveOutputLinkNode(stateId);
                }
                else
                {
                    state.RemoveOutputLinkNode(transitionId);
                    transition.RemoveInputLinkNode(stateId);
                }
                return true;
            }

            public bool Remove(int stateId, int stateType, int transitionId, int transitionType)
            {
                var state = ((StateStorage)_parent.States).GetInterface(stateType, stateId);
                if (!ReferenceEquals(null, state))
                {
                    return false;
                }
                var transition = ((TransitionStorage)_parent.Transitions).GetInterface(transitionType, transitionId);
                if (!ReferenceEquals(null, transition))
                {
                    return false;
                }
                if (state.RemoveInputLinkNode(transitionId))
                {
                    transition.RemoveOutputLinkNode(stateId);
                }
                else
                {
                    state.RemoveOutputLinkNode(transitionId);
                    transition.RemoveInputLinkNode(stateId);
                }
                return true;
            }

            public bool Remove(int stateId, int transitionId, LinkDirection direction)
            {
                var state = _parent.States[stateId];
                if (!ReferenceEquals(null, state))
                {
                    return false;
                }
                var transition = _parent.Transitions[transitionId];
                if (!ReferenceEquals(null, transition))
                {
                    return false;
                }
                if (direction == LinkDirection.FromStateToTransition)
                {
                    state.RemoveOutputLinkNode(transitionId);
                    transition.RemoveInputLinkNode(stateId);
                }
                else
                {
                    state.RemoveInputLinkNode(transitionId);
                    transition.RemoveOutputLinkNode(stateId);
                }
                return true;
            }

            public bool Remove(int stateId, int stateType, int transitionId, int transitionType, LinkDirection direction)
            {
                var state = ((StateStorage)_parent.States).GetInterface(stateType, stateId);
                if (!ReferenceEquals(null, state))
                {
                    return false;
                }
                var transition = ((TransitionStorage)_parent.Transitions).GetInterface(transitionType, transitionId);
                if (!ReferenceEquals(null, transition))
                {
                    return false;
                }
                if (direction == LinkDirection.FromStateToTransition)
                {
                    state.RemoveOutputLinkNode(transitionId);
                    transition.RemoveInputLinkNode(stateId);
                }
                else
                {
                    state.RemoveInputLinkNode(transitionId);
                    transition.RemoveOutputLinkNode(stateId);
                }
                return true;
            }

            public void Clear()
            {
                var states = ((StateStorage)_parent.States)._states;
                var transitions = ((TransitionStorage)_parent.Transitions)._transitions;
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IStateWrapper state;
                Interfaces.IColouredPetriNetNode transition;
                for (int i = 0; i < states.Count; ++i)
                {
                    itemList = states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as Interfaces.IStateWrapper;
                        state.ClearInputLinkNodes();
                        state.ClearOutputLinkNodes();
                    }
                }
                for (int i = 0; i < transitions.Count; ++i)
                {
                    itemList = transitions[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        transition = itemList.Items[j] as Interfaces.ITransitionWrapper;
                        transition.ClearInputLinkNodes();
                        transition.ClearOutputLinkNodes();
                    }
                }
            }

            public void ForEachLink(ForEachLinkFunction function)
            {
                var stateStorage = (StateStorage)_parent.States;
                var transitionStorage = (TransitionStorage)_parent.Transitions;
                var states = stateStorage._states;
                var transitions = transitionStorage._transitions;
                Interfaces.IOneTypeItemList itemList;
                Interfaces.IStateWrapper state;
                Interfaces.ITransitionWrapper transition;
                for (int i = 0; i < states.Count; ++i)
                {
                    itemList = states[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        state = itemList.Items[j] as Interfaces.IStateWrapper;
                        for (int k = 0; k < state.OutputLinkNodes.Count; ++k)
                        {
                            function(state, transitionStorage[state.OutputLinkNodes[k]],
                                LinkDirection.FromStateToTransition);
                        }
                    }
                }
                for (int i = 0; i < transitions.Count; ++i)
                {
                    itemList = transitions[i] as Interfaces.IOneTypeItemList;
                    for (int j = 0; j < itemList.Items.Count; ++j)
                    {
                        transition = itemList.Items[j] as Interfaces.ITransitionWrapper;
                        for (int k = 0; k < transition.OutputLinkNodes.Count; ++k)
                        {
                            function(stateStorage[transition.OutputLinkNodes[k]], transition,
                                LinkDirection.FromTransitionToState);
                        }
                    }
                }
            }
        }
    }
}
