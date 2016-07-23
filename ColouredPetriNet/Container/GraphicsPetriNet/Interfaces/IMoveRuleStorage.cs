namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IMoveRuleStorage
    {
        int Count { get; }
        void Add(int inputStateType, int outputStateType, int transitionType, int markerType,
            int markerCount = 1);
        void Remove(int inputStateType, int outputStateType, int transitionType,
            int markerType, int markerCount = -1);
        void Clear();
        void Move(StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition);
    }
}
