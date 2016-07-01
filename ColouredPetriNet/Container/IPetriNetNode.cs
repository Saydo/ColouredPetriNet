using System;
using System.Collections.Generic;

namespace PetriNet
{
    public interface IPetriNetNode
    {
        int getId();
        Type getValueType();
        List<int> getInputLinkNodes();
        List<int> getOutputLinkNodes();
        bool containsInputLinkNodes();
        bool containsInputLinkNode(int id);
        bool containsOutputLinkNodes();
        bool containsOutputLinkNode(int id);
        bool containsLinkNode(int id);
        void addInputLinkNode(int id);
        void addOutputLinkNode(int id);
        bool removeInputLinkNode(int id);
        bool removeOutputLinkNode(int id);
        void clearInputLinkNodes();
        void clearOutputLinkNodes();
    }

    public interface IPetriNetNode<T> : IPetriNetNode
    {
        T getValue();
    }
}
