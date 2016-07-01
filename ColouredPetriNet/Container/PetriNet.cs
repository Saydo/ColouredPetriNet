using System;
using System.Collections;
using System.Collections.Generic;

namespace PetriNet
{
    public class PetriNet : IPetriNet
    {
        public PetriNet()
        {
            m_markers = new ArrayList();
            m_states = new ArrayList();
            m_transitions = new ArrayList();
            m_idGenerator = new IdGenerator(-1);
        }

        public bool isStateExist(int id)
        {
            IStateWrapper state = getStateInterface(id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return true;
        }

        public bool isStateExist<T>(int id)
        {
            StateWrapper<T> state = getStateWrapperById<T>(id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return true;
        }

        public bool isTransitionExist(int id)
        {
            IPetriNetNode transition = getTransitionInterface(id);
            if (ReferenceEquals(null, transition))
            {
                return false;
            }
            return true;
        }

        public bool isTransitionExist<T>(int id)
        {
            TransitionWrapper<T> transition = getTransitionWrapperById<T>(id);
            if (ReferenceEquals(null, transition))
            {
                return false;
            }
            return true;
        }

        public bool isMarkerExist(int id)
        {
            IMarkerWrapper marker = getMarkerInterface(id);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            return true;
        }

        public bool isMarkerExist<T>(int id)
        {
            MarkerWrapper<T> marker = getMarkerWrapperById<T>(id);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            return true;
        }

        public bool isStateExist()
        {
            return (getStateCount() != 0);
        }

        public bool isStateExist<T>()
        {
            return (getStateCount<T>() != 0);
        }

        public bool isTransitionExist()
        {
            return (getTransitionCount() != 0);
        }

        public bool isTransitionExist<T>()
        {
            return (getTransitionCount<T>() != 0);
        }

        public bool isMarkerExist()
        {
            return (getMarkerCount() != 0);
        }

        public bool isMarkerExist<T>()
        {
            return (getMarkerCount<T>() != 0);
        }

        public int addState<T>(T value)
        {
            List<StateWrapper<T>> state_storage = findStateStorage<T>();
            if (ReferenceEquals(null, state_storage))
            {
                state_storage = new List<StateWrapper<T>>();
                m_states.Add(state_storage);
            }
            state_storage.Add(new StateWrapper<T>(m_idGenerator.getNextId(), value));
            return m_idGenerator.getCurrId();
        }

        public int addTransition<T>(T value)
        {
            List<TransitionWrapper<T>> transition_storage = findTransitionStorage<T>();
            if (ReferenceEquals(null, transition_storage))
            {
                transition_storage = new List<TransitionWrapper<T>>();
                m_transitions.Add(transition_storage);
            }
            transition_storage.Add(new TransitionWrapper<T>(m_idGenerator.getNextId(), value));
            return m_idGenerator.getCurrId();
        }

        public int addMarker<T>(int state_id, T value)
        {
            List<MarkerWrapper<T>> marker_storage = findMarkerStorage<T>();
            if (ReferenceEquals(null, marker_storage))
            {
                marker_storage = new List<MarkerWrapper<T>>();
                m_markers.Add(marker_storage);
            }
            marker_storage.Add(new MarkerWrapper<T>(m_idGenerator.getNextId(), state_id, value));
            connectMarkerToState(m_idGenerator.getCurrId(), state_id);
            return m_idGenerator.getCurrId();
        }

        public bool addStateToTransitionLink<StateType, TransitionType>(int state_id, int transition_id)
        {
            StateWrapper<StateType> state = getStateWrapperById<StateType>(state_id);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TransitionType> transition = getTransitionWrapperById<TransitionType>(transition_id);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            state.addOutputLinkNode(transition_id);
            transition.addInputLinkNode(state_id);
            return true;
        }

        public bool addTransitionToStateLink<TransitionType, StateType>(int transition_id, int state_id)
        {
            StateWrapper<StateType> state = getStateWrapperById<StateType>(state_id);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TransitionType> transition = getTransitionWrapperById<TransitionType>(transition_id);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            transition.addOutputLinkNode(state_id);
            state.addInputLinkNode(transition_id);
            return true;
        }

        public bool removeStateToTransitionLink<StateType, TransitionType>(int state_id, int transition_id)
        {
            StateWrapper<StateType> state = getStateWrapperById<StateType>(state_id);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TransitionType> transition = getTransitionWrapperById<TransitionType>(transition_id);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            state.removeOutputLinkNode(transition_id);
            transition.removeInputLinkNode(state_id);
            return true;
        }

        public bool removeTransitionToStateLink<TransitionType, StateType>(int transition_id, int state_id)
        {
            StateWrapper<StateType> state = getStateWrapperById<StateType>(state_id);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TransitionType> transition = getTransitionWrapperById<TransitionType>(transition_id);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            transition.removeOutputLinkNode(state_id);
            state.removeInputLinkNode(transition_id);
            return true;
        }

        public bool connectMarkerToState(int marker_id, int state_id)
        {
            IStateWrapper state = getStateInterface(state_id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.addMarker(marker_id);
            return true;
        }

        public bool connectMarkerToState<StateType>(int marker_id, int state_id)
        {
            StateWrapper<StateType> state = getStateWrapperById<StateType>(state_id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.addMarker(marker_id);
            return true;
        }

        public bool disconnectMarkerFromState(int marker_id, int state_id)
        {
            IStateWrapper state = getStateInterface(state_id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.removeMarker(marker_id);
            return true;
        }

        public bool disconnectMarkerFromState<StateType>(int marker_id, int state_id)
        {
            StateWrapper<StateType> state = getStateWrapperById<StateType>(state_id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.removeMarker(marker_id);
            return true;
        }

        public bool removeMarkersFromState(int state_id)
        {
            IStateWrapper state = getStateInterface(state_id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            for (int k = 0; k < state.getMarkerCount(); ++k)
            {
                removeMarkerFromStorage(state.getMarker(k));
            }
            return true;
        }

        public bool removeMarkersFromState<T>(int state_id)
        {
            StateWrapper<T> state = getStateWrapperById<T>(state_id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            for (int i = 0; i < state.getMarkerCount(); ++i)
            {
                removeMarkerFromStorage(state.getMarker(i));
            }
            return true;
        }

        public bool removeState(int id)
        {
            Tuple<IList, int, IStateWrapper> index = findStateIndex(id);
            if (ReferenceEquals(null, index))
            {
                return false;
            }
            removeLinksByState(id);
            removeMarkersFromState(index.Item3);
            index.Item1.RemoveAt(index.Item2);
            return true;
        }

        public bool removeState<T>(int id)
        {
            Tuple<List<StateWrapper<T>>, int> index = findStateIndex<T>(id);
            if (!ReferenceEquals(null, index))
            {
                removeMarkersFromState<T>(id);
                removeLinksByState(id);
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            return false;
        }

        public bool removeTransition(int id)
        {
            Tuple<IList, int, IPetriNetNode> index = findTransitionIndex(id);
            if (!ReferenceEquals(null, index))
            {
                removeLinksByTransition(id);
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            return false;
        }

        public bool removeTransition<T>(int id)
        {
            Tuple<List<TransitionWrapper<T>>, int> index = findTransitionIndex<T>(id);
            if (!ReferenceEquals(null, index))
            {
                removeLinksByTransition(id);
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool removeMarker(int id)
        {
            Tuple<IList, int, IMarkerWrapper> index = findMarkerIndex(id);
            if (ReferenceEquals(null, index))
            {
                return false;
            }
            index.Item1.RemoveAt(index.Item2);
            if (index.Item3.getStateId() < 0)
            {
                return true;
            }
            IStateWrapper state = getStateInterface(index.Item3.getStateId());
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.removeMarker(id);
            return true;
        }

        public bool removeMarker<T>(int id)
        {
            Tuple<List<MarkerWrapper<T>>, int> index = findMarkerIndex<T>(id);
            if (!ReferenceEquals(null, index))
            {
                MarkerWrapper<T> marker = index.Item1[index.Item2];
                disconnectMarkerFromState(marker.getId(), marker.getStateId());
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            return false;
        }

        public bool moveMarker(int marker_id, int new_state_id)
        {
            IMarkerWrapper marker = getMarkerInterface(marker_id);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            IStateWrapper curr_state = getStateInterface(marker.getStateId());
            if (ReferenceEquals(null, curr_state))
            {
                return false;
            }
            IStateWrapper new_state = getStateInterface(new_state_id);
            if (ReferenceEquals(null, new_state))
            {
                return false;
            }
            curr_state.removeMarker(marker_id);
            new_state.addMarker(marker_id);
            marker.setStateId(new_state_id);
            return true;
        }

        public bool moveMarker<T>(int marker_id, int new_state_id)
        {
            MarkerWrapper<T> marker = getMarkerWrapperById<T>(marker_id);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            IStateWrapper curr_state = getStateInterface(marker.getStateId());
            if (ReferenceEquals(null, curr_state))
            {
                return false;
            }
            IStateWrapper new_state = getStateInterface(new_state_id);
            if (ReferenceEquals(null, new_state))
            {
                return false;
            }
            curr_state.removeMarker(marker_id);
            new_state.addMarker(marker_id);
            marker.setStateId(new_state_id);
            return true;
        }

        public int getStateCount()
        {
            IList storage;
            int sum_count = 0;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = (IList)m_states[i];
                sum_count += storage.Count;
            }
            return sum_count;
        }

        public int getStateCount<T>()
        {
            List<StateWrapper<T>> storage = findStateStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return 0;
            }
            else
            {
                return storage.Count;
            }
        }

        public int getTransitionCount()
        {
            IList storage;
            int sum_count = 0;
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = (IList)m_transitions[i];
                sum_count += storage.Count;
            }
            return sum_count;
        }

        public int getTransitionCount<T>()
        {
            List<TransitionWrapper<T>> storage = findTransitionStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return 0;
            }
            else
            {
                return storage.Count;
            }
        }

        public int getMarkerCount()
        {
            IList storage;
            int sum_count = 0;
            for (int i = 0; i < m_markers.Count; ++i)
            {
                storage = (IList)m_markers[i];
                sum_count += storage.Count;
            }
            return sum_count;
        }

        public int getMarkerCount<T>()
        {
            List<MarkerWrapper<T>> storage = findMarkerStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return 0;
            }
            else
            {
                return storage.Count;
            }
        }

        public StateWrapper<T> getStateWrapperById<T>(int id)
        {
            List<StateWrapper<T>> storage = findStateStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].getId() == id)
                {
                    return storage[i];
                }
            }
            return null;
        }

        public TransitionWrapper<T> getTransitionWrapperById<T>(int id)
        {
            List<TransitionWrapper<T>> storage = findTransitionStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].getId() == id)
                {
                    return storage[i];
                }
            }
            return null;
        }

        public MarkerWrapper<T> getMarkerWrapperById<T>(int id)
        {
            List<MarkerWrapper<T>> storage = findMarkerStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].getId() == id)
                {
                    return storage[i];
                }
            }
            return null;
        }

        public T getStateById<T>(int id)
        {
            StateWrapper<T> state = getStateWrapperById<T>(id);
            if (ReferenceEquals(null, state))
            {
                return default(T);
            }
            else
            {
                return state.getValue();
            }
        }

        public T getTransitionById<T>(int id)
        {
            TransitionWrapper<T> transition = getTransitionWrapperById<T>(id);
            if (ReferenceEquals(null, transition))
            {
                return default(T);
            }
            else
            {
                return transition.getValue();
            }
        }

        public T getMarkerById<T>(int id)
        {
            MarkerWrapper<T> marker = getMarkerWrapperById<T>(id);
            if (ReferenceEquals(null, marker))
            {
                return default(T);
            }
            else
            {
                return marker.getValue();
            }
        }

        public T getState<T>(int index)
        {
            StateWrapper<T> state = getStateWrapper<T>(index);
            if (ReferenceEquals(null, state))
            {
                return default(T);
            }
            else
            {
                return state.getValue();
            }
        }

        public T getTransition<T>(int index)
        {
            TransitionWrapper<T> transition = getTransitionWrapper<T>(index);
            if (ReferenceEquals(null, transition))
            {
                return default(T);
            }
            else
            {
                return transition.getValue();
            }
        }

        public T getMarker<T>(int index)
        {
            MarkerWrapper<T> marker = getMarkerWrapper<T>(index);
            if (ReferenceEquals(null, marker))
            {
                return default(T);
            }
            else
            {
                return marker.getValue();
            }
        }

        public StateWrapper<T> getStateWrapper<T>(int index)
        {
            if (index < 0)
            {
                return null;
            }
            List<StateWrapper<T>> storage = findStateStorage<T>();
            if ((ReferenceEquals(null, storage)) || (index >= storage.Count))
            {
                return null;
            }
            return storage[index];
        }

        public TransitionWrapper<T> getTransitionWrapper<T>(int index)
        {
            if (index < 0)
            {
                return null;
            }
            List<TransitionWrapper<T>> storage = findTransitionStorage<T>();
            if ((ReferenceEquals(null, storage)) || (index >= storage.Count))
            {
                return null;
            }
            return storage[index];
        }

        public MarkerWrapper<T> getMarkerWrapper<T>(int index)
        {
            if (index < 0)
            {
                return null;
            }
            List<MarkerWrapper<T>> storage = findMarkerStorage<T>();
            if ((ReferenceEquals(null, storage)) || (index >= storage.Count))
            {
                return null;
            }
            return storage[index];
        }

        public void clear()
        {
            m_markers.Clear();
            m_states.Clear();
            m_transitions.Clear();
        }

        public void clearStates()
        {
            m_states.Clear();
        }

        public void clearStates<T>()
        {
            List<StateWrapper<T>> storage;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = m_states[i] as List<StateWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    storage.Clear();
                    return;
                }
            }
        }

        public void clearTransitions()
        {
            m_transitions.Clear();
        }

        public void clearTransitions<T>()
        {
            List<TransitionWrapper<T>> storage;
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = m_transitions[i] as List<TransitionWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    storage.Clear();
                    return;
                }
            }
        }

        public void clearMarkers()
        {
            m_markers.Clear();
        }

        public void clearMarkers<T>()
        {
            List<MarkerWrapper<T>> storage;
            for (int i = 0; i < m_markers.Count; ++i)
            {
                storage = m_markers[i] as List<MarkerWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    storage.Clear();
                    return;
                }
            }
        }

        public void clearLinks()
        {
            IList storage;
            IStateWrapper state;
            IPetriNetNode transition;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = (IList)m_states[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    state.clearInputLinkNodes();
                    state.clearOutputLinkNodes();
                }
            }
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = (IList)m_transitions[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IPetriNetNode)storage[j];
                    transition.clearInputLinkNodes();
                    transition.clearOutputLinkNodes();
                }
            }
        }

        public void moveMarkers()
        {
            IList state_storage;
            IStateWrapper state;
            IStateWrapper out_state;
            IPetriNetNode out_transition;
            List<int> out_transitions;
            List<int> out_states;
            List<Tuple<Type, List<int>>> marker_list;
            List<IMarkerWrapper> marker_wrapper_list;
            PetriNetMoveRule move_rule;
            PetriNetAccumulateRule acc_rule;
            // sequence: accumulate(prev) -> move -> accumulate(next)
            for (int i = 0; i < m_states.Count; ++i)
            {
                state_storage = (IList)m_states[i];
                if (ReferenceEquals(null, state_storage))
                {
                    continue;
                }
                for (int j = 0; j < state_storage.Count; ++j)
                {
                    state = (IStateWrapper)state_storage[j];
                    out_transitions = state.getOutputLinkNodes();
                    for (int k = 0; k < out_transitions.Count; ++k)
                    {
                        out_transition = getTransitionInterface(out_transitions[k]);
                        out_states = out_transition.getOutputLinkNodes();
                        for (int r = 0; r < out_states.Count; ++r)
                        {
                            out_state = getStateInterface(out_states[r]);
                            marker_list = getStateMarkerList(out_state);
                            // prev accumulate
                            acc_rule = findSuitablePrevAccumulateRule(state.getValueType(), marker_list);
                            if ((!ReferenceEquals(null, acc_rule)) && (!ReferenceEquals(null, acc_rule.accumulateFunction)))
                            {
                                marker_wrapper_list = getMarkerWrapperList(marker_list);
                                acc_rule.accumulateFunction(state, marker_wrapper_list);
                            }
                            // move
                            for (int m = 0; m < marker_list.Count; ++m)
                            {
                                move_rule = findSuitableMovementRule(state.getValueType(), out_state.getValueType(),
                                    out_transition.getValueType(), marker_list[m].Item1, marker_list[m].Item2.Count);
                                if (!ReferenceEquals(null, move_rule))
                                {
                                    marker_wrapper_list = getMarkerWrapperList(marker_list);
                                    move_rule.moveFunction(state, out_state, out_transition, marker_wrapper_list);
                                }
                            }
                            // next accumulate
                            acc_rule = findSuitableNextAccumulateRule(out_state.getValueType(), marker_list);
                            if (!ReferenceEquals(null, acc_rule))
                            {
                                marker_wrapper_list = getMarkerWrapperList(marker_list);
                                acc_rule.accumulateFunction(state, marker_wrapper_list);
                            }
                        }
                    }
                }
            }
        }

        public void addMoveRule(Type input_state, Type output_state, Type transition, Type marker, int count = 1)
        {
            m_moveRules.Add(new PetriNetMoveRule(input_state, output_state, transition, marker, count));
        }

        public void addPrevAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            m_prevAccumulateRules.Add(new PetriNetAccumulateRule(state, markers));
        }

        public void addPrevAccumulateRule(Type state, Type marker, int count = 1)
        {
            List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
            markers.Add(new Tuple<Type, int>(marker, count));
            m_prevAccumulateRules.Add(new PetriNetAccumulateRule(state,  markers));
        }

        public void addNextAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            m_nextAccumulateRules.Add(new PetriNetAccumulateRule(state, markers));
        }
        
        public void addNextAccumulateRule(Type state, Type marker, int count = 1)
        {
            List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
            markers.Add(new Tuple<Type, int>(marker, count));
            m_nextAccumulateRules.Add(new PetriNetAccumulateRule(state, markers));
        }

        public void clearMoveRules()
        {
            m_moveRules.Clear();
        }

        public void clearPrevAccumulateRules()
        {
            m_prevAccumulateRules.Clear();
        }

        public void clearNextAccumulateRules()
        {
            m_nextAccumulateRules.Clear();
        }

        public void removeMoveRule(Type input_state, Type output_state, Type transition, Type marker, int count = -1)
        {
            if (count < 0)
            {
                List<int> index_list = findMoveRuleIndexList(input_state, output_state, transition, marker);
                for (int i = index_list.Count-1; i >= 0; --i)
                {
                    m_moveRules.RemoveAt(index_list[i]);
                    for (int j = i - 1; j >= 0; --j)
                    {
                        if (index_list[j] > index_list[i])
                        {
                            --index_list[j];
                        }
                    }
                }
            }
            else
            {
                int index = findMoveRuleIndex(input_state, output_state, transition, marker, count);
                if (index > 0)
                {
                    m_moveRules.RemoveAt(index);
                }
            }
        }

        public void removePrevAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            int index = findAccumulateRuleIndex(m_prevAccumulateRules, state, markers);
            if (index > 0)
            {
                m_prevAccumulateRules.RemoveAt(index);
            }
        }

        public void removePrevAccumulateRule(Type state, Type marker, int count = -1)
        {
            if (count < 0)
            {
                List<int> index_list = findAccumulateRuleIndexList(m_prevAccumulateRules, state, marker);
                removeFromList(m_prevAccumulateRules, index_list);
            }
            else
            {
                List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
                markers.Add(new Tuple<Type, int>(marker, count));
                int index = findAccumulateRuleIndex(m_prevAccumulateRules, state, markers);
                if (index > 0)
                {
                    m_prevAccumulateRules.RemoveAt(index);
                }
            }
        }

        public void removeNextAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            int index = findAccumulateRuleIndex(m_nextAccumulateRules, state, markers);
            if (index > 0)
            {
                m_nextAccumulateRules.RemoveAt(index);
            }
        }

        public void removeNextAccumulateRule(Type state, Type marker, int count = -1)
        {
            if (count < 0)
            {
                List<int> index_list = findAccumulateRuleIndexList(m_nextAccumulateRules, state, marker);
                removeFromList(m_nextAccumulateRules, index_list);
            }
            else
            {
                List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
                markers.Add(new Tuple<Type, int>(marker, count));
                int index = findAccumulateRuleIndex(m_nextAccumulateRules, state, markers);
                if (index > 0)
                {
                    m_nextAccumulateRules.RemoveAt(index);
                }
            }
        }

        //--------------- Helpful Functions --------------------
        protected void removeLinksByState(int state_id)
        {
            IList storage;
            IPetriNetNode transition;
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = (IList)m_transitions[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IPetriNetNode)storage[j];
                    transition.removeInputLinkNode(state_id);
                    transition.removeOutputLinkNode(state_id);
                }
            }
        }

        protected void removeLinksByTransition(int transition_id)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = (IList)m_states[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    state.removeInputLinkNode(transition_id);
                    state.removeOutputLinkNode(transition_id);
                }
            }
        }

        protected Tuple<IList, int, IStateWrapper> findStateIndex(int id)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = (IList)m_states[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    if (state.getId() == id)
                    {
                        return new Tuple<IList, int, IStateWrapper>(storage, j, state);
                    }
                }
            }
            return null;
        }

        protected Tuple<List<StateWrapper<T>>, int> findStateIndex<T>(int id)
        {
            List<StateWrapper<T>> storage = findStateStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].getId() == id)
                {
                    return new Tuple<List<StateWrapper<T>>, int>(storage, i);
                }
            }
            return null;
        }

        protected Tuple<IList, int, IPetriNetNode> findTransitionIndex(int id)
        {
            IList storage;
            IPetriNetNode transition;
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = (IList)m_transitions[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IPetriNetNode)storage[j];
                    if (transition.getId() == id)
                    {
                        return new Tuple<IList, int, IPetriNetNode>(storage, j, transition);
                    }
                }
            }
            return null;
        }

        protected Tuple<List<TransitionWrapper<T>>, int> findTransitionIndex<T>(int id)
        {
            List<TransitionWrapper<T>> storage = findTransitionStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].getId() == id)
                {
                    return new Tuple<List<TransitionWrapper<T>>, int>(storage, i);
                }
            }
            return null;
        }

        protected Tuple<IList, int, IMarkerWrapper> findMarkerIndex(int id)
        {
            IList storage;
            IMarkerWrapper marker;
            for (int i = 0; i < m_markers.Count; ++i)
            {
                storage = (IList)m_markers[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    marker = (IMarkerWrapper)storage[j];
                    if (marker.getId() == id)
                    {
                        return new Tuple<IList, int, IMarkerWrapper>(storage, j, marker);
                    }
                }
            }
            return null;
        }

        protected Tuple<List<MarkerWrapper<T>>, int> findMarkerIndex<T>(int id)
        {
            List<MarkerWrapper<T>> storage = findMarkerStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].getId() == id)
                {
                    return new Tuple<List<MarkerWrapper<T>>, int>(storage, i);
                }
            }
            return null;
        }

        protected List<StateWrapper<T>> findStateStorage<T>()
        {
            List<StateWrapper<T>> storage;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = m_states[i] as List<StateWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    return storage;
                }
            }
            return null;
        }

        protected List<TransitionWrapper<T>> findTransitionStorage<T>()
        {
            List<TransitionWrapper<T>> storage;
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = m_transitions[i] as List<TransitionWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    return storage;
                }
            }
            return null;
        }

        protected List<MarkerWrapper<T>> findMarkerStorage<T>()
        {
            List<MarkerWrapper<T>> storage;
            for (int i = 0; i < m_markers.Count; ++i)
            {
                storage = m_markers[i] as List<MarkerWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    return storage;
                }
            }
            return null;
        }

        protected void removeStateFromStorage(int id)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = (IList)m_states[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    if (state.getId() == id)
                    {
                        storage.RemoveAt(j);
                        return;
                    }
                }
            }
        }

        protected void removeTransitionFromStorage(int id)
        {
            IList storage;
            IPetriNetNode transition;
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = (IList)m_transitions[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IPetriNetNode)storage[j];
                    if (transition.getId() == id)
                    {
                        storage.RemoveAt(j);
                        return;
                    }
                }
            }
        }

        protected void removeMarkerFromStorage(int id)
        {
            IList storage;
            IMarkerWrapper marker;
            for (int i = 0; i < m_markers.Count; ++i)
            {
                storage = (IList)m_markers[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    marker = (IMarkerWrapper)storage[j];
                    if (marker.getId() == id)
                    {
                        storage.RemoveAt(j);
                        return;
                    }
                }
            }
        }

        protected void removeMarkersFromState(IStateWrapper state)
        {
            if (ReferenceEquals(null, state))
            {
                return;
            }
            for (int i = 0; i < state.getMarkerCount(); ++i)
            {
                removeMarkerFromStorage(state.getMarker(i));
            }
        }

        protected IStateWrapper getStateInterface(int id)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < m_states.Count; ++i)
            {
                storage = (IList)m_states[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    if (state.getId() == id)
                    {
                        return state;
                    }
                }
            }
            return null;
        }

        protected IPetriNetNode getTransitionInterface(int id)
        {
            IList storage;
            IPetriNetNode transition;
            for (int i = 0; i < m_transitions.Count; ++i)
            {
                storage = (IList)m_transitions[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IPetriNetNode)storage[j];
                    if (transition.getId() == id)
                    {
                        return transition;
                    }
                }
            }
            return null;
        }

        protected IMarkerWrapper getMarkerInterface(int id)
        {
            IList storage;
            IMarkerWrapper marker;
            for (int i = 0; i < m_markers.Count; ++i)
            {
                storage = (IList)m_markers[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    marker = (IMarkerWrapper)storage[j];
                    if (marker.getId() == id)
                    {
                        return marker;
                    }
                }
            }
            return null;
        }

        protected PetriNetMoveRule findSuitableMovementRule(Type input_state, Type output_state,
            Type transition, Type marker, int count)
        {
            for (int i = 0; i < m_moveRules.Count; ++i)
            {
                if (m_moveRules[i].isComply(input_state, output_state, transition, marker, count))
                {
                    return m_moveRules[i];
                }
            }
            return null;
        }

        protected PetriNetAccumulateRule findSuitablePrevAccumulateRule(Type state, List<Tuple<Type, List<int>>> in_markers)
        {
            for (int i = 0; i < m_prevAccumulateRules.Count; ++i)
            {
                if (m_prevAccumulateRules[i].isComply(state, in_markers))
                {
                    return m_prevAccumulateRules[i];
                }
            }
            return null;
        }

        protected PetriNetAccumulateRule findSuitableNextAccumulateRule(Type state, List<Tuple<Type, List<int>>> in_markers)
        {
            for (int i = 0; i < m_nextAccumulateRules.Count; ++i)
            {
                if (m_nextAccumulateRules[i].isComply(state, in_markers))
                {
                    return m_nextAccumulateRules[i];
                }
            }
            return null;
        }

        protected List<Tuple<Type, List<int>>> getStateMarkerList(IStateWrapper state)
        {
            List<Tuple<Type, List<int>>> marker_list = new List<Tuple<Type, List<int>>>();
            List<int> id_list;
            for (int i = 0; i < state.getMarkerCount(); ++i)
            {
                IMarkerWrapper marker = getMarkerInterface(state.getMarker(i));
                bool is_found = false;
                for (int j = 0; j < marker_list.Count; ++j)
                {
                    if (marker_list[j].Item1 == marker.getValueType())
                    {
                        id_list = marker_list[j].Item2;
                        id_list.Add(marker.getId());
                        marker_list[j] = new Tuple<Type, List<int>>(marker_list[j].Item1, id_list);
                        is_found = true;
                        break;
                    }
                }
                if (!is_found)
                {
                    id_list = new List<int>();
                    id_list.Add(marker.getId());
                    marker_list.Add(new Tuple<Type, List<int>>(marker.getValueType(), id_list));
                }
            }
            return marker_list;
        }

        protected List<IMarkerWrapper> getMarkerWrapperList(List<Tuple<Type, List<int>>> marker_list)
        {
            List<IMarkerWrapper> marker_wrapper_list = new List<IMarkerWrapper>();
            IMarkerWrapper marker;
            for (int i = 0; i < marker_list.Count; ++i)
            {
                for (int j = 0; j < marker_list[i].Item2.Count; ++j)
                {
                    marker = getMarkerInterface(marker_list[i].Item2[j]);
                    marker_wrapper_list.Add(marker);
                }
            }
            return marker_wrapper_list;
        }

        protected List<int> findAccumulateRuleIndexList(List<PetriNetAccumulateRule> acc_rules, Type state, Type marker)
        {
            List<int> index_list = new List<int>();
            for (int i = 0; i < acc_rules.Count; ++i)
            {
                if ((acc_rules[i].state == state) && (acc_rules[i].markers.Count == 1)
                    && (acc_rules[i].markers[0].Item1 == marker))
                {
                    index_list.Add(i);
                }
            }
            return index_list;
        }

        protected List<int> findMoveRuleIndexList(Type input_state, Type output_state, Type transition, Type marker)
        {
            List<int> index_list = new List<int>();
            for (int i = 0; i < m_moveRules.Count; ++i)
            {
                if ((m_moveRules[i].inputState == input_state) && (m_moveRules[i].outputState == output_state)
                    && (m_moveRules[i].transition == transition) && (m_moveRules[i].marker == marker))
                {
                    index_list.Add(i);
                }
            }
            return index_list;
        }

        protected int findMoveRuleIndex(Type input_state, Type output_state, Type transition, Type marker, int count)
        {
            for (int i = 0; i < m_moveRules.Count; ++i)
            {
                if ((m_moveRules[i].inputState == input_state) && (m_moveRules[i].outputState == output_state)
                    && (m_moveRules[i].transition == transition) && (m_moveRules[i].marker == marker)
                    && (m_moveRules[i].count == count))
                {
                    return i;
                }
            }
            return -1;
        }

        protected int findAccumulateRuleIndex(List<PetriNetAccumulateRule> acc_rules, Type state, List<Tuple<Type, int>> markers)
        {
            for (int i = 0; i < acc_rules.Count; ++i)
            {
                if ((acc_rules[i].state == state)
                    && isEquals(acc_rules[i].markers, markers))
                {
                    return i;
                }
            }
            return -1;
        }

        protected bool isEquals(List<Tuple<Type, int>> list1, List<Tuple<Type, int>> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }
            bool is_found = false;
            for (int i = 0; i < list1.Count; ++i)
            {
                is_found = false;
                for (int j = 0; j < list2.Count; ++j)
                {
                    if ((list1[i].Item1 != list2[j].Item1) || (list1[i].Item2 != list2[j].Item2))
                    {
                        is_found = true;
                        break;
                    }
                }
                if (!is_found)
                {
                    return false;
                }
            }
            return true;
        }
        
        protected void removeFromList<T>(List<T> list, List<int> index_list)
        {
            for (int i = index_list.Count - 1; i >= 0; --i)
            {
                list.RemoveAt(index_list[i]);
                for (int j = i - 1; j >= 0; --j)
                {
                    if (index_list[j] > index_list[i])
                    {
                        --index_list[j];
                    }
                }
            }
        }

        //-----------------------------------------------------------
        protected ArrayList m_states;
        protected ArrayList m_transitions;
        protected ArrayList m_markers;
        protected IdGenerator m_idGenerator;
        protected List<PetriNetMoveRule> m_moveRules;
        protected List<PetriNetAccumulateRule> m_prevAccumulateRules;
        protected List<PetriNetAccumulateRule> m_nextAccumulateRules;
    }
}
