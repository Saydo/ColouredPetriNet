namespace ColouredPetriNet.Container.Interfaces
{
    public interface IPetriNetItemStorage
    {
        T GetValue<T>(int id);
        T GetValue<T>(int type, int index);
        bool IsExist(int id);
        bool Contains(int type);
        int GetCount();
        int GetCount(int type);
        int GetTypeId<T>();
        bool Remove(int id);
        bool Remove(int id, int type);
        bool RemoveByType(int type);
        bool RemoveType(int type);
        void Clear();
    }
}
