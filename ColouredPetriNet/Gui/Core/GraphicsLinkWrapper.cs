namespace ColouredPetriNet.Gui.Core
{
    public enum LinkDirection { FromStateToTransition, FromTransitionToState };

    public class GraphicsLinkWrapper
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
