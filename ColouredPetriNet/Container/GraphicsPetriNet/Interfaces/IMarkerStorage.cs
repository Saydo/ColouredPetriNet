namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IMarkerStorage : IPetriNetItemStorage
    {
        GraphicsItems.GraphicsItem this[int id] { get; }
        GraphicsItems.GraphicsItem GetMarker(int stateId, int type, int index);
        MarkerInfo GetMarkerInfo(int id);
        int Create(int stateId, GraphicsItems.GraphicsItem item);
        bool Add(int stateId, GraphicsItems.GraphicsItem item);
        void ForEachState(GraphicsPetriNet.ForEachStateFunction function);
        bool RemoveFromState(int stateId);
        bool RemoveFromState(int type, int stateId, int count = -1);
        bool Move(int markerId, int newStateId);
        bool Move(int markerId, int markerType, int newStateId);
        bool MoveAll(int oldStateId, int newStateId);
        bool MoveAll(int type, int oldStateId, int newStateId);
        void MoveByRules();
        void ForEachMarker(GraphicsPetriNet.ForEachMarkerFunction function);
    }
}
