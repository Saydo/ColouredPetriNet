namespace ColouredPetriNet.Container.Interfaces
{
    public interface ITransitionStorage : IPetriNetItemStorage
    {
        IColouredPetriNetNode this[int id] { get; }
        IColouredPetriNetNode this[int type, int index] { get; }
        TransitionWrapper<T> GetWrapper<T>(int id);
        TransitionWrapper<T> GetWrapper<T>(int type, int index);
        System.Tuple<int, int> Create<T>(T value);
        int Create<T>(int type, T value);
        int Add<T>(int id, T value);
        bool Add<T>(int id, int type, T value);
    }
}
