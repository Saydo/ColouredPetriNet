namespace ColouredPetriNet.Container
{ 
    public class TransitionWrapper<T> : ColouredPetriNetNode<T>
    {
        public TransitionWrapper(int id, T transition) : base(id, transition)
        {
        }
    }
}
