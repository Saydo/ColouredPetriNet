namespace ColouredPetriNet.Gui.Core
{
    class GraphicsLinkWrapper
    {
        public GraphicsItems.LinkGraphicsItem Link;
        public GraphicsStateWrapper State;
        public GraphicsTransitionWrapper Transition;
        public LinkDirection Direction;

        public GraphicsLinkWrapper(GraphicsStateWrapper state, GraphicsTransitionWrapper transition,
            GraphicsItems.LinkGraphicsItem link, LinkDirection direction)
        {
            State = state;
            Transition = transition;
            Link = link;
            Direction = direction;
        }
    }
}
