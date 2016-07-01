namespace PetriNet
{
    public interface IStateWrapper : IPetriNetNode
    {
        int getMarker(int index);
        int getMarkerCount();
        bool containsMarkers();
        bool containsMarker(int id);
        void addMarker(int id);
        void removeMarker(int id);
    }

    public interface IStateWrapper<T> : IStateWrapper, IPetriNetNode<T>
    {
    }
}
