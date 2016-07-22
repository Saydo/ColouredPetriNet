namespace ColouredPetriNet.Container.ColouredPetriNet.Interfaces
{
    public interface IMoveRuleStorage
    {
        void Add(int inputStateType, int outputStateType, int transitionType, int markerType,
            int markerCount = 1);
        void Remove(int inputStateType, int outputStateType, int transitionType,
            int markerType, int markerCount = -1);
        void Clear();
    }
}
