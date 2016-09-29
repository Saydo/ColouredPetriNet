using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Interfaces
{
    public interface IAccumulateRuleStorage
    {
        Rules.AccumulateRule this[int index] { get; }
        int Count { get; }
        bool Add(Rules.AccumulateRule rule);
        bool Remove(int stateType, List<Rules.OneTypeMarkerInfo> markers);
        void Clear();
        Rules.AccumulateRule Find(int stateType, List<Rules.OneTypeMarkerInfo> markers);
        void Accumulate(StateWrapper state);
    }
}
