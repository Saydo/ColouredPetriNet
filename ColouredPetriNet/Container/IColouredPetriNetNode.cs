using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public interface IColouredPetriNetNode
    {
        int Id { get; }
        int Type { get; }
        List<int> InputLinkNodes { get; }
        List<int> OutputLinkNodes { get; }
        Type GetValueType();
        bool ContainsInputLinkNodes();
        bool ContainsInputLinkNode(int id);
        bool ContainsOutputLinkNodes();
        bool ContainsOutputLinkNode(int id);
        bool ContainsLinkNode(int id);
        void AddInputLinkNode(int id);
        void AddOutputLinkNode(int id);
        bool RemoveInputLinkNode(int id);
        bool RemoveOutputLinkNode(int id);
        void ClearInputLinkNodes();
        void ClearOutputLinkNodes();
    }

    public interface IColouredPetriNetNode<T> : IColouredPetriNetNode
    {
        T Value { get; }
    }
}
