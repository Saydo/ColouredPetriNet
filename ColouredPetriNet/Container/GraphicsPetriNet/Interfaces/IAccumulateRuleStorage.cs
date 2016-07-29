using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IAccumulateRuleStorage
    {
        AccumulateRule this[int index] { get; }
        int Count { get; }
        bool Add(AccumulateRule rule);
        bool Remove(int stateType, List<OneTypeMarkers> markers);
        void Clear();
        AccumulateRule Find(int stateType, List<OneTypeMarkers> markers);
        void Accumulate(StateWrapper state);
    }
}
