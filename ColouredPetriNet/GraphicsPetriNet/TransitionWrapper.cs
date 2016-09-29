using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet
{
    public class TransitionWrapper
    {
        public int Id;
        public int Type;
        public GraphicsItems.GraphicsItem Transition;
        public List<LinkWrapper> OutputLinks;
        public List<LinkWrapper> InputLinks;

        public TransitionWrapper(GraphicsItems.GraphicsItem transition)
        {
            Id = transition.Id;
            Type = transition.TypeId;
            Transition = transition;
            OutputLinks = new List<LinkWrapper>();
            InputLinks = new List<LinkWrapper>();
        }
    }
}
