namespace ColouredPetriNet.Container
{
    public interface IStateWrapper : IColouredPetriNetNode
    {
        int GetMarker(int index);
        int GetMarkerCount();
        bool ContainsMarkers();
        bool ContainsMarker(int id);
        void AddMarker(int id);
        void RemoveMarker(int id);
    }

    public interface IStateWrapper<T> : IStateWrapper, IColouredPetriNetNode<T>
    {
    }
}
