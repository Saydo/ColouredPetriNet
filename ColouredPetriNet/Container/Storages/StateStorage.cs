namespace ColouredPetriNet.Container.Storages
{
    public partial class ColouredPetriNet
    {
        public Interfaces.IStateStorage States;

        private class StateStorage : Interfaces.IStateStorage
        {
            public IStateWrapper this[int id] { get; }
            public IStateWrapper this[int type, int index] { get; }
            public StateWrapper<T> GetWrapper<T>(int id);
            public StateWrapper<T> GetWrapper<T>(int type, int index);
            public T GetValue<T>(int id);
            T GetValue<T>(int type, int index);
            bool IsExist(int id);
            bool Contains(int type);
            int GetCount();
            int GetCount(int type);
            int GetTypeId<T>();
            Tuple<int, int> Create<T>(T value);
            int Create<T>(int type, T value);
            int Add<T>(int id, T value);
            bool Add<T>(int id, int type, T value);
            bool Remove(int id);
            bool Remove(int id, int type);
            void RemoveByType(int type);
            void Clear();
        }
    }
}
