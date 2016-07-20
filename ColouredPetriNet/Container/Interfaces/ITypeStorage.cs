namespace ColouredPetriNet.Container.Interfaces
{
    public interface ITypeStorage
    {
        int Count { get; }
        bool Contains(int type);
        bool Add(int type);
        int Create();
        bool Remove(int type);
        bool RemoveAt(int index);
        void Clear();
    }
}
