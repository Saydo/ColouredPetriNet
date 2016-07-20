using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public interface IColouredPetriNet
    {
        // Add Functions
        bool AddType(int typeId);
        int AddType();
        Tuple<int, int> AddState<T>(T state);
        int AddState<T>(int type, T state);
        int AddStateWithId<T>(int id, T state);
        bool AddStateWithId<T>(int id, int type, T state);
        Tuple<int, int> AddTransition<T>(T transition);
        int AddTransition<T>(int type, T transition);
        int AddTransitionWithId<T>(int id, T transition);
        bool AddTransitionWithId<T>(int id, int type, T transition);
        Tuple<int, int> AddMarker<T>(int stateId, T marker);
        int AddMarker<T>(int type, int stateId, T marker);
        int AddMarkerWithId<T>(int id, int stateId, T marker);
        bool AddMarkerWithId<T>(int id, int type, int stateId, T marker);
        bool AddStateToTransitionLink(int stateId, int transitionId);
        bool AddStateToTransitionLink(int stateId, int stateType, int transitionId, int transitionType);
        bool AddTransitionToStateLink(int transitionId, int stateId);
        bool AddTransitionToStateLink(int transitionId, int transitionType, int stateId, int stateType);
        void AddMoveRule(int inputStateType, int outputStateType, int transitionType, int markerType,
            int markerCount = 1);
        void AddPrevAccumulateRule(int stateType, List<Tuple<int, int>> markers);
        void AddPrevAccumulateRule(int stateType, int markerType, int markerCount = 1);
        void AddNextAccumulateRule(int stateType, List<Tuple<int, int>> markers);
        void AddNextAccumulateRule(int stateType, int markerType, int markerCount = 1);
        // Remove Functions
        bool RemoveType(int typeId);
        bool RemoveState(int id);
        bool RemoveState(int id, int type);
        void RemoveStates(int type);
        bool RemoveTransition(int id);
        bool RemoveTransition(int id, int type);
        void RemoveTransitions(int type);
        bool RemoveMarker(int id);
        bool RemoveMarker(int id, int type);
        bool RemoveMarkers(int stateId);
        bool RemoveMarkersByType(int type);
        bool RemoveMarkersByType(int type, int stateId, int count = -1);
        bool RemoveStateToTransitionLink(int stateId, int transitionId);
        bool RemoveStateToTransitionLink(int stateId, int stateType, int transitionId, int transitionType);
        bool RemoveTransitionToStateLink(int transitionId, int stateId);
        bool RemoveTransitionToStateLink(int transitionId, int transitionType, int stateId, int stateType);
        void RemoveMoveRule(int inputStateType, int outputStateType, int transitionType,
            int markerType, int markerCount = -1);
        void RemovePrevAccumulateRule(int stateType, List<Tuple<int, int>> markers);
        void RemovePrevAccumulateRule(int stateType, int markerType, int markerCount = -1);
        void RemoveNextAccumulateRule(int stateType, List<Tuple<int, int>> markers);
        void RemoveNextAccumulateRule(int stateType, int markerType, int markerCount = -1);
        // Clear Functions
        void Clear();
        void ClearStates();
        void ClearTransitions();
        void ClearMarkers();
        void ClearLinks();
        void ClearMoveRules();
        void ClearPrevAccumulateRules();
        void ClearNextAccumulateRules();
        // Move Functions
        bool MoveMarker(int markerId, int newStateId, int oldStateId = -1);
        bool MoveMarker(int markerId, int markerType, int newStateId, int newStateType, int oldStateId = -1, int oldStateType = -1);
        bool MoveMarkers(int oldStateId, int newStateId);
        bool MoveMarkers(int type, int oldStateId, int newStateId);
        void MoveMarkers();
        // Contains Functions
        bool IsTypeExist(int type);
        bool IsStateExist(int id);
        bool IsTransitionExist(int id);
        bool IsMarkerExist(int id);
        bool ContainsStates(int type);
        bool ContainsTransitions(int type);
        bool ContainsMarkers(int type);
        bool IsLinkExist(int stateId, int transitionId);
        bool IsLinkExist(int stateId, int stateType, int transitionId, int transitionType);
        bool IsInputLinkExist(int stateId, int transitionId);
        bool IsInputLinkExist(int stateId, int stateType, int transitionId, int transitionType);
        bool IsOutputLinkExist(int stateId, int transitionId);
        bool IsOutputLinkExist(int stateId, int stateType, int transitionId, int transitionType);
        // Count Functions
        int GetStateCount();
        int GetStateCount(int type);
        int GetTransitionCount();
        int GetTransitionCount(int type);
        int GetMarkerCount();
        int GetMarkerCount(int type);
        int GetLinkCount();
        int GetLinkCount(int stateId, int transitionId);
        int GetLinkCountByType(int stateType, int transitionType);
        int GetLinkCountByType(int stateId, int stateType, int transitionId, int transitionType);
        int GetInputLinkCount(int stateId, int transitionId);
        int GetInputLinkCountByType(int stateId, int stateType, int transitionId, int transitionType);
        int GetOutputLinkCount(int stateId, int transitionId);
        int GetOutputLinkCountByType(int stateId, int stateType, int transitionId, int transitionType);
        // Find Functions
        int GetTypeId<T>();
        int GetStateTypeId<T>();
        int GetTransitionTypeId<T>();
        int GetMarkerTypeId<T>();
        T GetState<T>(int index);
        T GetTransition<T>(int index);
        T GetMarker<T>(int index);
        T GetStateById<T>(int id);
        T GetTransitionById<T>(int id);
        T GetMarkerById<T>(int id);
        StateWrapper<T> GetStateWrapper<T>(int index);
        TransitionWrapper<T> GetTransitionWrapper<T>(int index);
        MarkerWrapper<T> GetMarkerWrapper<T>(int index);
        StateWrapper<T> GetStateWrapperById<T>(int id);
        TransitionWrapper<T> GetTransitionWrapperById<T>(int id);
        MarkerWrapper<T> GetMarkerWrapperById<T>(int id);
        IStateWrapper GetStateInterface(int id);
        IColouredPetriNetNode GetTransitionInterface(int id);
        IMarkerWrapper GetMarkerInterface(int id);
    }
}