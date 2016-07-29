using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IMoveRuleStorage
    {
        MoveRule this[int index] { get; }
        int Count { get; }
        bool Add(MoveRule rule);
        bool Remove(int outputStateType, int inputStateType, int transitionType,
            List<OneTypeMarkers> outputMarkers);
        void Clear();
        MoveRule Find(int outputStateType, int inputStateType, int transitionType,
            List<OneTypeMarkers> outputMarkers);
        void Move(StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition);
    }
}
