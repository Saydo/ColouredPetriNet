using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IAccumulateRuleStorage
    {
        int Count { get; }
        /*
        void Add(int stateType, List<Tuple<int, int>> markers);
        void Add(int stateType, int markerType, int markerCount = 1);
        void Remove(int stateType, List<Tuple<int, int>> markers);
        void Remove(int stateType, int markerType, int markerCount = -1);
        void Clear();
        bool Accumulate(StateWrapper state);
        */
    }
}
