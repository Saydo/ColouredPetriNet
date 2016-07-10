using System;
using System.Collections;
using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public class ColouredPetriNet : IColouredPetriNet
    {
        protected ArrayList _states;
        protected ArrayList _transitions;
        protected ArrayList _markers;
        protected IdGenerator _idGenerator;
        protected List<PetriNetMoveRule> _moveRules;
        protected List<PetriNetAccumulateRule> _prevAccumulateRules;
        protected List<PetriNetAccumulateRule> _nextAccumulateRules;

        public ColouredPetriNet()
        {
            _markers = new ArrayList();
            _states = new ArrayList();
            _transitions = new ArrayList();
            _idGenerator = new IdGenerator(-1);
        }

        public bool IsStateExist(int id)
        {
            IStateWrapper state = GetStateInterface(id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return true;
        }

        public bool IsStateExist<T>(int id)
        {
            StateWrapper<T> state = GetStateWrapperById<T>(id);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return true;
        }

        public bool IsTransitionExist(int id)
        {
            IColouredPetriNetNode transition = GetTransitionInterface(id);
            if (ReferenceEquals(null, transition))
            {
                return false;
            }
            return true;
        }

        public bool IsTransitionExist<T>(int id)
        {
            TransitionWrapper<T> transition = GetTransitionWrapperById<T>(id);
            if (ReferenceEquals(null, transition))
            {
                return false;
            }
            return true;
        }

        public bool IsMarkerExist(int id)
        {
            IMarkerWrapper marker = GetMarkerInterface(id);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            return true;
        }

        public bool IsMarkerExist<T>(int id)
        {
            MarkerWrapper<T> marker = GetMarkerWrapperById<T>(id);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            return true;
        }

        public bool IsStateExist()
        {
            return (GetStateCount() != 0);
        }

        public bool IsStateExist<T>()
        {
            return (GetStateCount<T>() != 0);
        }

        public bool IsTransitionExist()
        {
            return (GetTransitionCount() != 0);
        }

        public bool IsTransitionExist<T>()
        {
            return (GetTransitionCount<T>() != 0);
        }

        public bool IsMarkerExist()
        {
            return (GetMarkerCount() != 0);
        }

        public bool IsMarkerExist<T>()
        {
            return (GetMarkerCount<T>() != 0);
        }

        public bool IsLinkExist(int stateId, int transitionId)
        {
            var state = GetStateInterface(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return state.ContainsLinkNode(transitionId);
        }

        public bool IsLinkExist<TState>(int stateId, int transitionId)
        {
            var state = GetStateWrapperById<TState>(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return state.ContainsLinkNode(transitionId);
        }

        public bool IsInputLinkExist(int stateId, int transitionId)
        {
            var state = GetStateInterface(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return state.ContainsInputLinkNode(transitionId);
        }

        public bool IsInputLinkExist<TState>(int stateId, int transitionId)
        {
            var state = GetStateWrapperById<TState>(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return state.ContainsInputLinkNode(transitionId);
        }

        public bool IsOutputLinkExist(int stateId, int transitionId)
        {
            var state = GetStateInterface(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return state.ContainsOutputLinkNode(transitionId);
        }

        public bool IsOutputLinkExist<TState>(int stateId, int transitionId)
        {
            var state = GetStateWrapperById<TState>(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            return state.ContainsOutputLinkNode(transitionId);
        }

        public int AddState<T>(T state)
        {
            List<StateWrapper<T>> stateStorage = FindStateStorage<T>();
            if (ReferenceEquals(null, stateStorage))
            {
                stateStorage = new List<StateWrapper<T>>();
                _states.Add(stateStorage);
            }
            stateStorage.Add(new StateWrapper<T>(_idGenerator.GetNextId(), state));
            return _idGenerator.GetCurrId();
        }

        public int AddTransition<T>(T transition)
        {
            List<TransitionWrapper<T>> transitionStorage = FindTransitionStorage<T>();
            if (ReferenceEquals(null, transitionStorage))
            {
                transitionStorage = new List<TransitionWrapper<T>>();
                _transitions.Add(transitionStorage);
            }
            transitionStorage.Add(new TransitionWrapper<T>(_idGenerator.GetNextId(), transition));
            return _idGenerator.GetCurrId();
        }

        public int AddMarker<T>(int stateId, T marker)
        {
            List<MarkerWrapper<T>> markerStorage = FindMarkerStorage<T>();
            if (ReferenceEquals(null, markerStorage))
            {
                markerStorage = new List<MarkerWrapper<T>>();
                _markers.Add(markerStorage);
            }
            markerStorage.Add(new MarkerWrapper<T>(_idGenerator.GetNextId(), stateId, marker));
            ConnectMarkerToState(_idGenerator.GetCurrId(), stateId);
            return _idGenerator.GetCurrId();
        }

        public bool AddStateToTransitionLink(int stateId, int transitionId)
        {
            IStateWrapper state = GetStateInterface(stateId);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            IColouredPetriNetNode transition = GetTransitionInterface(transitionId);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            state.AddOutputLinkNode(transitionId);
            transition.AddInputLinkNode(stateId);
            return true;
        }

        public bool AddStateToTransitionLink<TState, TTransition>(int stateId, int transitionId)
        {
            StateWrapper<TState> state = GetStateWrapperById<TState>(stateId);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TTransition> transition = GetTransitionWrapperById<TTransition>(transitionId);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            state.AddOutputLinkNode(transitionId);
            transition.AddInputLinkNode(stateId);
            return true;
        }

        public bool AddTransitionToStateLink(int transitionId, int stateId)
        {
            IStateWrapper state = GetStateInterface(stateId);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            IColouredPetriNetNode transition = GetTransitionInterface(transitionId);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            transition.AddOutputLinkNode(stateId);
            state.AddInputLinkNode(transitionId);
            return true;
        }

        public bool AddTransitionToStateLink<TTransition, TState>(int transitionId, int stateId)
        {
            StateWrapper<TState> state = GetStateWrapperById<TState>(stateId);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TTransition> transition = GetTransitionWrapperById<TTransition>(transitionId);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            transition.AddOutputLinkNode(stateId);
            state.AddInputLinkNode(transitionId);
            return true;
        }

        public bool RemoveStateToTransitionLink<TState, TTransition>(int stateId, int transitionId)
        {
            StateWrapper<TState> state = GetStateWrapperById<TState>(stateId);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TTransition> transition = GetTransitionWrapperById<TTransition>(transitionId);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            state.RemoveOutputLinkNode(transitionId);
            transition.RemoveInputLinkNode(stateId);
            return true;
        }

        public bool RemoveTransitionToStateLink<TTransition, TState>(int transitionId, int stateId)
        {
            StateWrapper<TState> state = GetStateWrapperById<TState>(stateId);
            if (!ReferenceEquals(null, state))
            {
                return false;
            }
            TransitionWrapper<TTransition> transition = GetTransitionWrapperById<TTransition>(transitionId);
            if (!ReferenceEquals(null, transition))
            {
                return false;
            }
            transition.RemoveOutputLinkNode(stateId);
            state.RemoveInputLinkNode(transitionId);
            return true;
        }

        public bool ConnectMarkerToState(int markerId, int stateId)
        {
            IStateWrapper state = GetStateInterface(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.AddMarker(markerId);
            return true;
        }

        public bool ConnectMarkerToState<TState>(int markerId, int stateId)
        {
            StateWrapper<TState> state = GetStateWrapperById<TState>(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.AddMarker(markerId);
            return true;
        }

        public bool DisconnectMarkerFromState(int markerId, int stateId)
        {
            IStateWrapper state = GetStateInterface(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.RemoveMarker(markerId);
            return true;
        }

        public bool DisconnectMarkerFromState<TState>(int markerId, int stateId)
        {
            StateWrapper<TState> state = GetStateWrapperById<TState>(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.RemoveMarker(markerId);
            return true;
        }

        public bool RemoveMarkersFromState(int stateId)
        {
            IStateWrapper state = GetStateInterface(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            for (int k = 0; k < state.GetMarkerCount(); ++k)
            {
                RemoveMarkerFromStorage(state.GetMarker(k));
            }
            return true;
        }

        public bool RemoveMarkersFromState<T>(int stateId)
        {
            StateWrapper<T> state = GetStateWrapperById<T>(stateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            for (int i = 0; i < state.GetMarkerCount(); ++i)
            {
                RemoveMarkerFromStorage(state.GetMarker(i));
            }
            return true;
        }

        public bool RemoveState(int id)
        {
            Tuple<IList, int, IStateWrapper> index = FindStateIndex(id);
            if (ReferenceEquals(null, index))
            {
                return false;
            }
            RemoveLinksByState(id);
            RemoveMarkersFromState(index.Item3);
            index.Item1.RemoveAt(index.Item2);
            return true;
        }

        public bool RemoveState<T>(int id)
        {
            Tuple<List<StateWrapper<T>>, int> index = FindStateIndex<T>(id);
            if (!ReferenceEquals(null, index))
            {
                RemoveMarkersFromState<T>(id);
                RemoveLinksByState(id);
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            return false;
        }

        public bool RemoveTransition(int id)
        {
            Tuple<IList, int, IColouredPetriNetNode> index = FindTransitionIndex(id);
            if (!ReferenceEquals(null, index))
            {
                RemoveLinksByTransition(id);
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            return false;
        }

        public bool RemoveTransition<T>(int id)
        {
            Tuple<List<TransitionWrapper<T>>, int> index = FindTransitionIndex<T>(id);
            if (!ReferenceEquals(null, index))
            {
                RemoveLinksByTransition(id);
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RemoveMarker(int id)
        {
            Tuple<IList, int, IMarkerWrapper> index = FindMarkerIndex(id);
            if (ReferenceEquals(null, index))
            {
                return false;
            }
            index.Item1.RemoveAt(index.Item2);
            if (index.Item3.StateId < 0)
            {
                return true;
            }
            IStateWrapper state = GetStateInterface(index.Item3.StateId);
            if (ReferenceEquals(null, state))
            {
                return false;
            }
            state.RemoveMarker(id);
            return true;
        }

        public bool RemoveMarker<T>(int id)
        {
            Tuple<List<MarkerWrapper<T>>, int> index = FindMarkerIndex<T>(id);
            if (!ReferenceEquals(null, index))
            {
                MarkerWrapper<T> marker = index.Item1[index.Item2];
                DisconnectMarkerFromState(marker.Id, marker.StateId);
                index.Item1.RemoveAt(index.Item2);
                return true;
            }
            return false;
        }

        public bool MoveMarker(int markerId, int newStateId)
        {
            IMarkerWrapper marker = GetMarkerInterface(markerId);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            IStateWrapper currState = GetStateInterface(marker.StateId);
            if (ReferenceEquals(null, currState))
            {
                return false;
            }
            IStateWrapper newState = GetStateInterface(newStateId);
            if (ReferenceEquals(null, newState))
            {
                return false;
            }
            currState.RemoveMarker(markerId);
            newState.AddMarker(markerId);
            marker.StateId = newStateId;
            return true;
        }

        public bool MoveMarker<T>(int markerId, int newStateId)
        {
            MarkerWrapper<T> marker = GetMarkerWrapperById<T>(markerId);
            if (ReferenceEquals(null, marker))
            {
                return false;
            }
            IStateWrapper currState = GetStateInterface(marker.StateId);
            if (ReferenceEquals(null, currState))
            {
                return false;
            }
            IStateWrapper newState = GetStateInterface(newStateId);
            if (ReferenceEquals(null, newState))
            {
                return false;
            }
            currState.RemoveMarker(markerId);
            newState.AddMarker(markerId);
            marker.StateId = newStateId;
            return true;
        }

        public int GetStateCount()
        {
            IList storage;
            int sumCount = 0;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = (IList)_states[i];
                sumCount += storage.Count;
            }
            return sumCount;
        }

        public int GetStateCount<T>()
        {
            List<StateWrapper<T>> storage = FindStateStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return 0;
            }
            else
            {
                return storage.Count;
            }
        }

        public int GetTransitionCount()
        {
            IList storage;
            int sumCount = 0;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = (IList)_transitions[i];
                sumCount += storage.Count;
            }
            return sumCount;
        }

        public int GetTransitionCount<T>()
        {
            List<TransitionWrapper<T>> storage = FindTransitionStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return 0;
            }
            else
            {
                return storage.Count;
            }
        }

        public int GetMarkerCount()
        {
            IList storage;
            int sumCount = 0;
            for (int i = 0; i < _markers.Count; ++i)
            {
                storage = (IList)_markers[i];
                sumCount += storage.Count;
            }
            return sumCount;
        }

        public int GetMarkerCount<T>()
        {
            List<MarkerWrapper<T>> storage = FindMarkerStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return 0;
            }
            else
            {
                return storage.Count;
            }
        }

        public int GetLinkCount()
        {
            IList storage;
            IColouredPetriNetNode node;
            int count = 0;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = (IList)_states[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    node = (IColouredPetriNetNode)storage[j];
                    count += node.OutputLinkNodes.Count;
                }
            }
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = (IList)_transitions[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    node = (IColouredPetriNetNode)storage[j];
                    if (node.InputLinkNodes.Count == 0)
                    {
                        count += node.OutputLinkNodes.Count;
                    }
                }
            }
            return count;
        }

        public int GetLinkCount<TState, TTransition>()
        {
            var stateStorage = FindStateStorage<TState>();
            if (ReferenceEquals(stateStorage, null))
            {
                return 0;
            }
            var transitionStorage = FindTransitionStorage<TTransition>();
            if (ReferenceEquals(transitionStorage, null))
            {
                return 0;
            }
            List<int> listId;
            int count = 0;
            for (int i = 0; i < stateStorage.Count; ++i)
            {
                listId = stateStorage[i].OutputLinkNodes;
                for (int j = 0; j < listId.Count; ++j)
                {
                    for (int k = 0; k < transitionStorage.Count; ++k)
                    {
                        if (transitionStorage[k].Id == listId[j])
                        {
                            ++count;
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < transitionStorage.Count; ++i)
            {
                if (transitionStorage[i].InputLinkNodes.Count > 0)
                {
                    continue;
                }
                listId = transitionStorage[i].OutputLinkNodes;
                for (int j = 0; j < listId.Count; ++j)
                {
                    for (int k = 0; k < stateStorage.Count; ++k)
                    {
                        if (stateStorage[k].Id == listId[j])
                        {
                            ++count;
                            break;
                        }
                    }
                }
            }
            return count;
        }

        public int GetLinkCount(int stateId, int transitionId)
        {
            var state = GetStateInterface(stateId);
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

        public int GetLinkCount<TState>(int stateId, int transitionId)
        {
            var state = GetStateWrapperById<TState>(stateId);
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

        public int GetInputLinkCount(int stateId, int transitionId)
        {
            var state = GetStateInterface(stateId);
            if ((!ReferenceEquals(state, null)) && (state.ContainsInputLinkNode(transitionId)))
            {
                return 1;
            }
            return 0;
        }

        public int GetInputLinkCount<TState>(int stateId, int transitionId)
        {
            var state = GetStateWrapperById<TState>(stateId);
            if ((!ReferenceEquals(state, null)) && (state.ContainsOutputLinkNode(transitionId)))
            {
                return 1;
            }
            return 0;
        }

        public int GetOutputLinkCount(int stateId, int transitionId)
        {
            var state = GetStateInterface(stateId);
            if ((!ReferenceEquals(state, null)) && (state.ContainsOutputLinkNode(transitionId)))
            {
                return 1;
            }
            return 0;
        }

        public int GetOutputLinkCount<TState>(int stateId, int transitionId)
        {
            var state = GetStateWrapperById<TState>(stateId);
            if ((!ReferenceEquals(state, null)) && (state.ContainsOutputLinkNode(transitionId)))
            {
                return 1;
            }
            return 0;
        }

        public StateWrapper<T> GetStateWrapperById<T>(int id)
        {
            List<StateWrapper<T>> storage = FindStateStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].Id == id)
                {
                    return storage[i];
                }
            }
            return null;
        }

        public TransitionWrapper<T> GetTransitionWrapperById<T>(int id)
        {
            List<TransitionWrapper<T>> storage = FindTransitionStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].Id == id)
                {
                    return storage[i];
                }
            }
            return null;
        }

        public MarkerWrapper<T> GetMarkerWrapperById<T>(int id)
        {
            List<MarkerWrapper<T>> storage = FindMarkerStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].Id == id)
                {
                    return storage[i];
                }
            }
            return null;
        }

        public T GetStateById<T>(int id)
        {
            StateWrapper<T> state = GetStateWrapperById<T>(id);
            if (ReferenceEquals(null, state))
            {
                return default(T);
            }
            else
            {
                return state.Value;
            }
        }

        public T GetTransitionById<T>(int id)
        {
            TransitionWrapper<T> transition = GetTransitionWrapperById<T>(id);
            if (ReferenceEquals(null, transition))
            {
                return default(T);
            }
            else
            {
                return transition.Value;
            }
        }

        public T GetMarkerById<T>(int id)
        {
            MarkerWrapper<T> marker = GetMarkerWrapperById<T>(id);
            if (ReferenceEquals(null, marker))
            {
                return default(T);
            }
            else
            {
                return marker.Value;
            }
        }

        public T GetState<T>(int index)
        {
            StateWrapper<T> state = GetStateWrapper<T>(index);
            if (ReferenceEquals(null, state))
            {
                return default(T);
            }
            else
            {
                return state.Value;
            }
        }

        public T GetTransition<T>(int index)
        {
            TransitionWrapper<T> transition = GetTransitionWrapper<T>(index);
            if (ReferenceEquals(null, transition))
            {
                return default(T);
            }
            else
            {
                return transition.Value;
            }
        }

        public T GetMarker<T>(int index)
        {
            MarkerWrapper<T> marker = GetMarkerWrapper<T>(index);
            if (ReferenceEquals(null, marker))
            {
                return default(T);
            }
            else
            {
                return marker.Value;
            }
        }

        public StateWrapper<T> GetStateWrapper<T>(int index)
        {
            if (index < 0)
            {
                return null;
            }
            List<StateWrapper<T>> storage = FindStateStorage<T>();
            if ((ReferenceEquals(null, storage)) || (index >= storage.Count))
            {
                return null;
            }
            return storage[index];
        }

        public TransitionWrapper<T> GetTransitionWrapper<T>(int index)
        {
            if (index < 0)
            {
                return null;
            }
            List<TransitionWrapper<T>> storage = FindTransitionStorage<T>();
            if ((ReferenceEquals(null, storage)) || (index >= storage.Count))
            {
                return null;
            }
            return storage[index];
        }

        public MarkerWrapper<T> GetMarkerWrapper<T>(int index)
        {
            if (index < 0)
            {
                return null;
            }
            List<MarkerWrapper<T>> storage = FindMarkerStorage<T>();
            if ((ReferenceEquals(null, storage)) || (index >= storage.Count))
            {
                return null;
            }
            return storage[index];
        }

        public void Clear()
        {
            _markers.Clear();
            _states.Clear();
            _transitions.Clear();
        }

        public void ClearStates()
        {
            _states.Clear();
        }

        public void ClearStates<T>()
        {
            List<StateWrapper<T>> storage;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = _states[i] as List<StateWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    storage.Clear();
                    return;
                }
            }
        }

        public void ClearTransitions()
        {
            _transitions.Clear();
        }

        public void ClearTransitions<T>()
        {
            List<TransitionWrapper<T>> storage;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = _transitions[i] as List<TransitionWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    storage.Clear();
                    return;
                }
            }
        }

        public void ClearMarkers()
        {
            _markers.Clear();
        }

        public void ClearMarkers<T>()
        {
            List<MarkerWrapper<T>> storage;
            for (int i = 0; i < _markers.Count; ++i)
            {
                storage = _markers[i] as List<MarkerWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    storage.Clear();
                    return;
                }
            }
        }

        public void ClearLinks()
        {
            IList storage;
            IStateWrapper state;
            IColouredPetriNetNode transition;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = (IList)_states[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    state.ClearInputLinkNodes();
                    state.ClearOutputLinkNodes();
                }
            }
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = (IList)_transitions[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IColouredPetriNetNode)storage[j];
                    transition.ClearInputLinkNodes();
                    transition.ClearOutputLinkNodes();
                }
            }
        }

        public void MoveMarkers()
        {
            IList stateStorage;
            IStateWrapper state;
            IStateWrapper outputState;
            IColouredPetriNetNode outputTransition;
            List<int> outputTransitions;
            List<int> outputStates;
            List<Tuple<Type, List<int>>> markerList;
            List<IMarkerWrapper> markerWrapperList;
            PetriNetMoveRule moveRule;
            PetriNetAccumulateRule accumulateRule;
            // sequence: accumulate(prev) -> move -> accumulate(next)
            for (int i = 0; i < _states.Count; ++i)
            {
                stateStorage = (IList)_states[i];
                if (ReferenceEquals(null, stateStorage))
                {
                    continue;
                }
                for (int j = 0; j < stateStorage.Count; ++j)
                {
                    state = (IStateWrapper)stateStorage[j];
                    outputTransitions = state.OutputLinkNodes;
                    for (int k = 0; k < outputTransitions.Count; ++k)
                    {
                        outputTransition = GetTransitionInterface(outputTransitions[k]);
                        outputStates = outputTransition.OutputLinkNodes;
                        for (int r = 0; r < outputStates.Count; ++r)
                        {
                            outputState = GetStateInterface(outputStates[r]);
                            markerList = GetStateMarkerList(outputState);
                            // prev accumulate
                            accumulateRule = FindSuitablePrevAccumulateRule(state.GetValueType(), markerList);
                            if ((!ReferenceEquals(null, accumulateRule)) &&
                                (!ReferenceEquals(null, accumulateRule.AccumulateFunction)))
                            {
                                markerWrapperList = GetMarkerWrapperList(markerList);
                                accumulateRule.AccumulateFunction(state, markerWrapperList);
                            }
                            // move
                            for (int m = 0; m < markerList.Count; ++m)
                            {
                                moveRule = FindSuitableMovementRule(state.GetValueType(), outputState.GetValueType(),
                                    outputTransition.GetValueType(), markerList[m].Item1, markerList[m].Item2.Count);
                                if (!ReferenceEquals(null, moveRule))
                                {
                                    markerWrapperList = GetMarkerWrapperList(markerList);
                                    moveRule.MoveFunction(state, outputState, outputTransition, markerWrapperList);
                                }
                            }
                            // next accumulate
                            accumulateRule = FindSuitableNextAccumulateRule(outputState.GetValueType(), markerList);
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

        public void AddMoveRule(Type inputState, Type outputState, Type transition, Type marker, int count = 1)
        {
            _moveRules.Add(new PetriNetMoveRule(inputState, outputState, transition, marker, count));
        }

        public void AddPrevAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            _prevAccumulateRules.Add(new PetriNetAccumulateRule(state, markers));
        }

        public void AddPrevAccumulateRule(Type state, Type marker, int count = 1)
        {
            List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
            markers.Add(new Tuple<Type, int>(marker, count));
            _prevAccumulateRules.Add(new PetriNetAccumulateRule(state,  markers));
        }

        public void AddNextAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            _nextAccumulateRules.Add(new PetriNetAccumulateRule(state, markers));
        }
        
        public void AddNextAccumulateRule(Type state, Type marker, int count = 1)
        {
            List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
            markers.Add(new Tuple<Type, int>(marker, count));
            _nextAccumulateRules.Add(new PetriNetAccumulateRule(state, markers));
        }

        public void ClearMoveRules()
        {
            _moveRules.Clear();
        }

        public void ClearPrevAccumulateRules()
        {
            _prevAccumulateRules.Clear();
        }

        public void ClearNextAccumulateRules()
        {
            _nextAccumulateRules.Clear();
        }

        public void RemoveMoveRule(Type inputState, Type outputState, Type transition, Type marker, int count = -1)
        {
            if (count < 0)
            {
                List<int> indexList = FindMoveRuleIndexList(inputState, outputState, transition, marker);
                for (int i = indexList.Count-1; i >= 0; --i)
                {
                    _moveRules.RemoveAt(indexList[i]);
                    for (int j = i - 1; j >= 0; --j)
                    {
                        if (indexList[j] > indexList[i])
                        {
                            --indexList[j];
                        }
                    }
                }
            }
            else
            {
                int index = FindMoveRuleIndex(inputState, outputState, transition, marker, count);
                if (index > 0)
                {
                    _moveRules.RemoveAt(index);
                }
            }
        }

        public void RemovePrevAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            int index = FindAccumulateRuleIndex(_prevAccumulateRules, state, markers);
            if (index > 0)
            {
                _prevAccumulateRules.RemoveAt(index);
            }
        }

        public void RemovePrevAccumulateRule(Type state, Type marker, int count = -1)
        {
            if (count < 0)
            {
                List<int> indexList = FindAccumulateRuleIndexList(_prevAccumulateRules, state, marker);
                RemoveFromList(_prevAccumulateRules, indexList);
            }
            else
            {
                List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
                markers.Add(new Tuple<Type, int>(marker, count));
                int index = FindAccumulateRuleIndex(_prevAccumulateRules, state, markers);
                if (index > 0)
                {
                    _prevAccumulateRules.RemoveAt(index);
                }
            }
        }

        public void RemoveNextAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            int index = FindAccumulateRuleIndex(_nextAccumulateRules, state, markers);
            if (index > 0)
            {
                _nextAccumulateRules.RemoveAt(index);
            }
        }

        public void RemoveNextAccumulateRule(Type state, Type marker, int count = -1)
        {
            if (count < 0)
            {
                List<int> indexList = FindAccumulateRuleIndexList(_nextAccumulateRules, state, marker);
                RemoveFromList(_nextAccumulateRules, indexList);
            }
            else
            {
                List<Tuple<Type, int>> markers = new List<Tuple<Type, int>>();
                markers.Add(new Tuple<Type, int>(marker, count));
                int index = FindAccumulateRuleIndex(_nextAccumulateRules, state, markers);
                if (index > 0)
                {
                    _nextAccumulateRules.RemoveAt(index);
                }
            }
        }

        public IStateWrapper GetStateInterface(int id)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = (IList)_states[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    if (state.Id == id)
                    {
                        return state;
                    }
                }
            }
            return null;
        }

        public IColouredPetriNetNode GetTransitionInterface(int id)
        {
            IList storage;
            IColouredPetriNetNode transition;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = (IList)_transitions[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IColouredPetriNetNode)storage[j];
                    if (transition.Id == id)
                    {
                        return transition;
                    }
                }
            }
            return null;
        }

        public IMarkerWrapper GetMarkerInterface(int id)
        {
            IList storage;
            IMarkerWrapper marker;
            for (int i = 0; i < _markers.Count; ++i)
            {
                storage = (IList)_markers[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    marker = (IMarkerWrapper)storage[j];
                    if (marker.Id == id)
                    {
                        return marker;
                    }
                }
            }
            return null;
        }

        //--------------- Helpful Functions --------------------
        #region Helpful Functions
        protected void RemoveLinksByState(int stateId)
        {
            IList storage;
            IColouredPetriNetNode transition;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = (IList)_transitions[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IColouredPetriNetNode)storage[j];
                    transition.RemoveInputLinkNode(stateId);
                    transition.RemoveOutputLinkNode(stateId);
                }
            }
        }

        protected void RemoveLinksByTransition(int transitionId)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = (IList)_states[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    state.RemoveInputLinkNode(transitionId);
                    state.RemoveOutputLinkNode(transitionId);
                }
            }
        }

        protected Tuple<IList, int, IStateWrapper> FindStateIndex(int id)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = (IList)_states[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    if (state.Id == id)
                    {
                        return new Tuple<IList, int, IStateWrapper>(storage, j, state);
                    }
                }
            }
            return null;
        }

        protected Tuple<List<StateWrapper<T>>, int> FindStateIndex<T>(int id)
        {
            List<StateWrapper<T>> storage = FindStateStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].Id == id)
                {
                    return new Tuple<List<StateWrapper<T>>, int>(storage, i);
                }
            }
            return null;
        }

        protected Tuple<IList, int, IColouredPetriNetNode> FindTransitionIndex(int id)
        {
            IList storage;
            IColouredPetriNetNode transition;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = (IList)_transitions[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IColouredPetriNetNode)storage[j];
                    if (transition.Id == id)
                    {
                        return new Tuple<IList, int, IColouredPetriNetNode>(storage, j, transition);
                    }
                }
            }
            return null;
        }

        protected Tuple<List<TransitionWrapper<T>>, int> FindTransitionIndex<T>(int id)
        {
            List<TransitionWrapper<T>> storage = FindTransitionStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].Id == id)
                {
                    return new Tuple<List<TransitionWrapper<T>>, int>(storage, i);
                }
            }
            return null;
        }

        protected Tuple<IList, int, IMarkerWrapper> FindMarkerIndex(int id)
        {
            IList storage;
            IMarkerWrapper marker;
            for (int i = 0; i < _markers.Count; ++i)
            {
                storage = (IList)_markers[i];
                for (int j = 0; j < storage.Count; ++j)
                {
                    marker = (IMarkerWrapper)storage[j];
                    if (marker.Id == id)
                    {
                        return new Tuple<IList, int, IMarkerWrapper>(storage, j, marker);
                    }
                }
            }
            return null;
        }

        protected Tuple<List<MarkerWrapper<T>>, int> FindMarkerIndex<T>(int id)
        {
            List<MarkerWrapper<T>> storage = FindMarkerStorage<T>();
            if (ReferenceEquals(null, storage))
            {
                return null;
            }
            for (int i = 0; i < storage.Count; ++i)
            {
                if (storage[i].Id == id)
                {
                    return new Tuple<List<MarkerWrapper<T>>, int>(storage, i);
                }
            }
            return null;
        }

        protected List<StateWrapper<T>> FindStateStorage<T>()
        {
            List<StateWrapper<T>> storage;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = _states[i] as List<StateWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    return storage;
                }
            }
            return null;
        }

        protected List<TransitionWrapper<T>> FindTransitionStorage<T>()
        {
            List<TransitionWrapper<T>> storage;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = _transitions[i] as List<TransitionWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    return storage;
                }
            }
            return null;
        }

        protected List<MarkerWrapper<T>> FindMarkerStorage<T>()
        {
            List<MarkerWrapper<T>> storage;
            for (int i = 0; i < _markers.Count; ++i)
            {
                storage = _markers[i] as List<MarkerWrapper<T>>;
                if (!ReferenceEquals(null, storage))
                {
                    return storage;
                }
            }
            return null;
        }

        protected void RemoveStateFromStorage(int id)
        {
            IList storage;
            IStateWrapper state;
            for (int i = 0; i < _states.Count; ++i)
            {
                storage = (IList)_states[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    state = (IStateWrapper)storage[j];
                    if (state.Id == id)
                    {
                        storage.RemoveAt(j);
                        return;
                    }
                }
            }
        }

        protected void RemoveTransitionFromStorage(int id)
        {
            IList storage;
            IColouredPetriNetNode transition;
            for (int i = 0; i < _transitions.Count; ++i)
            {
                storage = (IList)_transitions[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    transition = (IColouredPetriNetNode)storage[j];
                    if (transition.Id == id)
                    {
                        storage.RemoveAt(j);
                        return;
                    }
                }
            }
        }

        protected void RemoveMarkerFromStorage(int id)
        {
            IList storage;
            IMarkerWrapper marker;
            for (int i = 0; i < _markers.Count; ++i)
            {
                storage = (IList)_markers[i];
                if (ReferenceEquals(null, storage))
                {
                    continue;
                }
                for (int j = 0; j < storage.Count; ++j)
                {
                    marker = (IMarkerWrapper)storage[j];
                    if (marker.Id == id)
                    {
                        storage.RemoveAt(j);
                        return;
                    }
                }
            }
        }

        protected void RemoveMarkersFromState(IStateWrapper state)
        {
            if (ReferenceEquals(null, state))
            {
                return;
            }
            for (int i = 0; i < state.GetMarkerCount(); ++i)
            {
                RemoveMarkerFromStorage(state.GetMarker(i));
            }
        }

        protected PetriNetMoveRule FindSuitableMovementRule(Type inputState, Type outputState,
            Type transition, Type marker, int count)
        {
            for (int i = 0; i < _moveRules.Count; ++i)
            {
                if (_moveRules[i].IsComply(inputState, outputState, transition, marker, count))
                {
                    return _moveRules[i];
                }
            }
            return null;
        }

        protected PetriNetAccumulateRule FindSuitablePrevAccumulateRule(Type state, List<Tuple<Type, List<int>>> inputMarkers)
        {
            for (int i = 0; i < _prevAccumulateRules.Count; ++i)
            {
                if (_prevAccumulateRules[i].IsComply(state, inputMarkers))
                {
                    return _prevAccumulateRules[i];
                }
            }
            return null;
        }

        protected PetriNetAccumulateRule FindSuitableNextAccumulateRule(Type state, List<Tuple<Type, List<int>>> inputMarkers)
        {
            for (int i = 0; i < _nextAccumulateRules.Count; ++i)
            {
                if (_nextAccumulateRules[i].IsComply(state, inputMarkers))
                {
                    return _nextAccumulateRules[i];
                }
            }
            return null;
        }

        protected List<Tuple<Type, List<int>>> GetStateMarkerList(IStateWrapper state)
        {
            List<Tuple<Type, List<int>>> markerList = new List<Tuple<Type, List<int>>>();
            List<int> idList;
            IMarkerWrapper marker;
            bool isFound;
            for (int i = 0; i < state.GetMarkerCount(); ++i)
            {
                marker = GetMarkerInterface(state.GetMarker(i));
                isFound = false;
                for (int j = 0; j < markerList.Count; ++j)
                {
                    if (markerList[j].Item1 == marker.GetValueType())
                    {
                        idList = markerList[j].Item2;
                        idList.Add(marker.Id);
                        markerList[j] = new Tuple<Type, List<int>>(markerList[j].Item1, idList);
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    idList = new List<int>();
                    idList.Add(marker.Id);
                    markerList.Add(new Tuple<Type, List<int>>(marker.GetValueType(), idList));
                }
            }
            return markerList;
        }

        protected List<IMarkerWrapper> GetMarkerWrapperList(List<Tuple<Type, List<int>>> markerList)
        {
            List<IMarkerWrapper> markerWrapperList = new List<IMarkerWrapper>();
            IMarkerWrapper marker;
            for (int i = 0; i < markerList.Count; ++i)
            {
                for (int j = 0; j < markerList[i].Item2.Count; ++j)
                {
                    marker = GetMarkerInterface(markerList[i].Item2[j]);
                    markerWrapperList.Add(marker);
                }
            }
            return markerWrapperList;
        }

        protected List<int> FindAccumulateRuleIndexList(List<PetriNetAccumulateRule> accumulateRules, Type state,
            Type marker)
        {
            List<int> indexList = new List<int>();
            for (int i = 0; i < accumulateRules.Count; ++i)
            {
                if ((accumulateRules[i].State == state) && (accumulateRules[i].Markers.Count == 1)
                    && (accumulateRules[i].Markers[0].Item1 == marker))
                {
                    indexList.Add(i);
                }
            }
            return indexList;
        }

        protected List<int> FindMoveRuleIndexList(Type inputState, Type outputState, Type transition, Type marker)
        {
            List<int> indexList = new List<int>();
            for (int i = 0; i < _moveRules.Count; ++i)
            {
                if ((_moveRules[i].InputState == inputState) && (_moveRules[i].OutputState == outputState)
                    && (_moveRules[i].Transition == transition) && (_moveRules[i].Marker == marker))
                {
                    indexList.Add(i);
                }
            }
            return indexList;
        }

        protected int FindMoveRuleIndex(Type inputState, Type outputState, Type transition, Type marker, int count)
        {
            for (int i = 0; i < _moveRules.Count; ++i)
            {
                if ((_moveRules[i].InputState == inputState) && (_moveRules[i].OutputState == outputState)
                    && (_moveRules[i].Transition == transition) && (_moveRules[i].Marker == marker)
                    && (_moveRules[i].Count == count))
                {
                    return i;
                }
            }
            return -1;
        }

        protected int FindAccumulateRuleIndex(List<PetriNetAccumulateRule> accumulateRules, Type state,
            List<Tuple<Type, int>> markers)
        {
            for (int i = 0; i < accumulateRules.Count; ++i)
            {
                if ((accumulateRules[i].State == state)
                    && IsEquals(accumulateRules[i].Markers, markers))
                {
                    return i;
                }
            }
            return -1;
        }

        protected bool IsEquals(List<Tuple<Type, int>> list1, List<Tuple<Type, int>> list2)
        {
            if (list1.Count != list2.Count)
            {
                return false;
            }
            bool isFound = false;
            for (int i = 0; i < list1.Count; ++i)
            {
                isFound = false;
                for (int j = 0; j < list2.Count; ++j)
                {
                    if ((list1[i].Item1 != list2[j].Item1) || (list1[i].Item2 != list2[j].Item2))
                    {
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    return false;
                }
            }
            return true;
        }
        
        protected void RemoveFromList<T>(List<T> list, List<int> indexList)
        {
            for (int i = indexList.Count - 1; i >= 0; --i)
            {
                list.RemoveAt(indexList[i]);
                for (int j = i - 1; j >= 0; --j)
                {
                    if (indexList[j] > indexList[i])
                    {
                        --indexList[j];
                    }
                }
            }
        }
        #endregion
    }
}
