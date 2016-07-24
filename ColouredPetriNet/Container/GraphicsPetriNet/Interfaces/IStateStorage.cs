using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface IStateStorage : IPetriNetItemStorage
    {
        int SelectedStateCount { get; }
        StateWrapper this[int id] { get; }
        StateWrapper this[int type, int index] { get; }
        GraphicsItems.GraphicsItem GetItem(int id);
        GraphicsItems.GraphicsItem GetItem(int type, int index);
        StateWrapper Add(GraphicsItems.GraphicsItem item);
        void RemoveSelectedStates();
        List<StateWrapper> Find(int x, int y);
        List<StateWrapper> Find(int x, int y, int type);
        List<StateWrapper> Find(int x, int y, int w, int h,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial);
        List<StateWrapper> Find(int x, int y, int w, int h, int type,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial);
        StateWrapper GetSelectedState(int index);
        StateWrapper GetSelectedStateById(int id);
        void ForEachState(GraphicsPetriNet.ForEachStateFunction function);
        void ForEachSelectedState(GraphicsPetriNet.ForEachStateFunction function);
        void Select();
        void SelectArea(int x, int y);
        void SelectArea(int x, int y, int w, int h, GraphicsItems.OverlapType overlap);
        void Select(int type);
        void Deselect();
        void DeselectArea(int x, int y);
        void DeselectArea(int x, int y, int w, int h, GraphicsItems.OverlapType overlap);
        void Deselect(int type);
        void Move(int dx, int dy);
        bool Move(int dx, int dy, int id);
    }
}
