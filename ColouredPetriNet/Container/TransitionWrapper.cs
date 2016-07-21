namespace ColouredPetriNet.Container
{ 
    public class TransitionWrapper<T> : ColouredPetriNetNode<T>, Interfaces.ITransitionWrapper<T>
    {
        public TransitionWrapper(int id, int type, T transition)
            : base(id, type, transition)
        {
        }
    }
}
