namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IMoveRuleStorage
    {
        int Count { get; }
        void Add(PetriNetMoveRule rule);
        void Remove(int inputStateType, int outputStateType, int transitionType,
            OneTypeMarkers outputMarkers);
        void Clear();
        void Move(StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition);
    }
}
