namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IMarkerStorage : IPetriNetItemStorage
    {
        MarkerInfo this[int id] { get; }
        GraphicsItems.IGraphicsItem GetItem(int id);
        bool Add(int stateId, GraphicsItems.GraphicsItem item);
        bool RemoveFromState(int stateId);
        bool RemoveFromState(int type, int stateId, int count = -1);
        bool Move(int markerId, int oldStateId, int newStateId);
        bool MoveAll(int oldStateId, int newStateId);
        bool MoveAll(int type, int oldStateId, int newStateId);
        void MoveByRules();
        void ForEachMarker(GraphicsPetriNet.ForEachMarkerFunction function);
    }
}
