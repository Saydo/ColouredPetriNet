using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface ITransitionStorage : IPetriNetItemStorage
    {
        int SelectedTransitionCount { get; }
        TransitionWrapper this[int id] { get; }
        TransitionWrapper this[int type, int index] { get; }
        GraphicsItems.GraphicsItem GetItem(int id);
        GraphicsItems.GraphicsItem GetItem(int type, int index);
        TransitionWrapper Add(GraphicsItems.GraphicsItem item);
        void RemoveSelectedTransitions();
        List<TransitionWrapper> Find(int x, int y);
        List<TransitionWrapper> Find(int x, int y, int type);
        List<TransitionWrapper> Find(int x, int y, int w, int h,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial);
        List<TransitionWrapper> Find(int x, int y, int w, int h, int type,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial);
        TransitionWrapper GetSelectedTransition(int index);
        TransitionWrapper GetSelectedTransitionById(int id);
        void ForEachTransition(GraphicsPetriNet.ForEachTransitionFunction function);
        void ForEachSelectedTransition(GraphicsPetriNet.ForEachTransitionFunction function);
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
