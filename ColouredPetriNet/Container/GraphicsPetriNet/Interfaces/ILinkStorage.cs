using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public enum LinkDirection { FromStateToTransition, FromTransitionToState };
}

namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface ILinkStorage
    {
        int Count { get; }
        int SelectedLinkCount { get; }
        LinkWrapper this[int id] { get; }
        GraphicsItems.GraphicsItem GetItem(int id);
        bool Contains(int stateId, int transitionId);
        bool Contains(int stateId, int transitionId, LinkDirection direction);
        int GetCount(int stateId, int transitionId);
        int GetCountByType(int stateType, int transitionType);
        LinkWrapper Add(int stateId, int transitionId, LinkDirection direction);
        bool Remove(int id);
        bool Remove(int stateId, int transitionId);
        bool Remove(int stateId, int transitionId, LinkDirection direction);
        void RemoveSelectedLinks();
        void Clear();
        List<LinkWrapper> Find(int x, int y);
        List<LinkWrapper> Find(int x, int y, LinkDirection direction);
        List<LinkWrapper> Find(int x, int y, int w, int h,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial);
        List<LinkWrapper> Find(int x, int y, int w, int h, LinkDirection direction,
            GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial);
        LinkWrapper GetSelectedLink(int index);
        LinkWrapper GetSelectedLinkById(int id);
        void ForEachLink(GraphicsPetriNet.ForEachLinkFunction function);
        void ForEachSelectedLink(GraphicsPetriNet.ForEachLinkFunction function);
        void Select();
        void Select(int stateId, int transitionId);
        void Select(int stateId, int transitionId, LinkDirection direction);
        void Deselect();
        void Deselect(int stateId, int transitionId);
        void Deselect(int stateId, int transitionId, LinkDirection direction);
    }
}
