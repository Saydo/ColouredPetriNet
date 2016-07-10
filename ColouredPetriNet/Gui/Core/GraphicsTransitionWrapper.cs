using System.Collections.Generic;

namespace ColouredPetriNet.Gui.Core
{
    class GraphicsTransitionWrapper
    {
        public GraphicsItems.GraphicsItem Transition;
        public List<GraphicsLinkWrapper> OutputLinks;
        public List<GraphicsLinkWrapper> InputLinks;

        public GraphicsTransitionWrapper(GraphicsItems.GraphicsItem transition)
        {
            Transition = transition;
            OutputLinks = new List<GraphicsLinkWrapper>();
            InputLinks = new List<GraphicsLinkWrapper>();
        }
    }
}
