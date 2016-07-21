using System;
using System.Collections.Generic;
using System.Linq;
namespace ColouredPetriNet.Container.Interfaces
{
    public interface IMarkerStorage : IPetriNetItemStorage
    {
        IMarkerWrapper this[int id] { get; }
        IMarkerWrapper this[int type, int index] { get; }
        MarkerWrapper<T> GetWrapper<T>(int id);
        MarkerWrapper<T> GetWrapper<T>(int type, int index);
        Tuple<int, int> Create<T>(int stateId, T value);
        int Create<T>(int type, int stateId, T value);
        int Add<T>(int id, int stateId, T value);
        bool Add<T>(int id, int type, int stateId, T value);
        bool RemoveFromState(int stateId);
        bool RemoveFromState(int type, int stateId, int count = -1);
        bool Move(int markerId, int newStateId);
        bool Move(int markerId, int markerType, int newStateId, int newStateType, int oldStateType = -1);
        bool MoveAll(int oldStateId, int newStateId);
        bool MoveAll(int type, int oldStateId, int newStateId);
        void MoveByRules();
        void ForEachMarker(ColouredPetriNet.ForEachMarkerFunction function);
    }
}
