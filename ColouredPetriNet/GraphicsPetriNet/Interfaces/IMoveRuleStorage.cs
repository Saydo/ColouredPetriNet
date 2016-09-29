using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Interfaces
{
    public interface IMoveRuleStorage
    {
        Rules.MoveRule this[int index] { get; }
        int Count { get; }
        bool Add(Rules.MoveRule rule);
        bool Remove(int outputStateType, int inputStateType, int transitionType,
            List<Rules.OneTypeMarkerInfo> outputMarkers);
        void Clear();
        Rules.MoveRule Find(int outputStateType, int inputStateType, int transitionType,
            List<Rules.OneTypeMarkerInfo> outputMarkers);
        void Move(StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition);
    }
}
