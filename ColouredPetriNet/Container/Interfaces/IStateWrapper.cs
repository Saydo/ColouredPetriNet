namespace ColouredPetriNet.Container.Interfaces
{
    public interface IStateWrapper : IColouredPetriNetNode
    {
        int GetMarker(int index);
        int GetMarkerAt(int index);
        int GetMarkerCount();
        bool ContainsMarkers();
        bool ContainsMarker(int id);
        void AddMarker(int id);
        void RemoveMarker(int id);
        void RemoveAllMarkers();
    }

    public interface IStateWrapper<T> : IStateWrapper, IColouredPetriNetNode<T>
    {
    }
}
