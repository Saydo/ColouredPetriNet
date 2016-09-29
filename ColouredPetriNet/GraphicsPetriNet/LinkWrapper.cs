namespace ColouredPetriNet.GraphicsPetriNet
{
    public class LinkWrapper
    {
        public int Id;
        public GraphicsItems.LinkGraphicsItem Link;
        public StateWrapper State;
        public TransitionWrapper Transition;
        public LinkDirection Direction;

        public LinkWrapper(StateWrapper state, TransitionWrapper transition,
            GraphicsItems.LinkGraphicsItem link, LinkDirection direction)
        {
            Id = link.Id;
            State = state;
            Transition = transition;
            Link = link;
            Direction = direction;
        }
    }
}
