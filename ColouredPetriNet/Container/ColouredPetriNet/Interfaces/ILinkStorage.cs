﻿namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public enum LinkDirection { FromStateToTransition, FromTransitionToState };
    public enum LinkType { Input, Output };
}

namespace ColouredPetriNet.Container.ColouredPetriNet.Interfaces
{
    public interface ILinkStorage
    {
        bool Contains(int stateId, int transitionId);
        bool Contains(int stateId, int stateType, int transitionId);
        bool Contains(int stateId, int transitionId, LinkType linkType);
        bool Contains(int stateId, int stateType, int transitionId, LinkType linkType);
        int GetCount();
        int GetCount(int stateId, int transitionId);
        int GetCount(int stateId, int transitionId, LinkType linkType);
        int GetCount(int stateId, int stateType, int transitionId, LinkType linkType);
        int GetCountByType(int stateType, int transitionType);
        bool Add(int stateId, int transitionId, LinkDirection direction);
        bool Add(int stateId, int stateType, int transitionId, int transitionType, LinkDirection direction);
        bool Remove(int stateId, int transitionId);
        bool Remove(int stateId, int stateType, int transitionId, int transitionType);
        bool Remove(int stateId, int transitionId, LinkDirection direction);
        bool Remove(int stateId, int stateType, int transitionId, int transitionType, LinkDirection direction);
        void Clear();
        void ForEachLink(ColouredPetriNet.ForEachLinkFunction function);
    }
}