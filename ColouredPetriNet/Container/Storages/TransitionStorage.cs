namespace ColouredPetriNet.Container.Storages
{
    public partial class ColouredPetriNet
    {
        public Interfaces.ITransitionStorage TransitionStorage;

        private class TransitionStorage : Interfaces.ITransitionStorage
        {
            IColouredPetriNetNode this[int id] { get; }
            IColouredPetriNetNode this[int type, int index] { get; }
            TransitionWrapper<T> GetWrapper<T>(int id);
            TransitionWrapper<T> GetWrapper<T>(int type, int index);
            System.Tuple<int, int> Create<T>(T value);
            int Create<T>(int type, T value);
            int Add<T>(int id, T value);
            bool Add<T>(int id, int type, T value);
            T GetValue<T>(int id);
            T GetValue<T>(int type, int index);
            bool IsExist(int id);
            bool Contains(int type);
            int GetCount();
            int GetCount(int type);
            int GetTypeId<T>();
            bool Remove(int id);
            bool Remove(int id, int type);
            void RemoveByType(int type);
            void Clear();
        }

        //
    }
}
