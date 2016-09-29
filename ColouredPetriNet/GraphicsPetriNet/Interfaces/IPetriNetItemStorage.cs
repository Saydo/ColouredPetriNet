namespace ColouredPetriNet.GraphicsPetriNet.Interfaces
{
    public interface IPetriNetItemStorage
    {
        int Count { get; }
        bool IsExist(int id);
        bool Contains(int type);
        int GetCount(int type);
        bool Remove(int id);
        void RemoveByType(int type);
        void Clear();
    }
}
