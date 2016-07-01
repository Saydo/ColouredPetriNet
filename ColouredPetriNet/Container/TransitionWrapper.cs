namespace PetriNet
{ 
    public class TransitionWrapper<T> : PetriNetNode<T>
    {
        public TransitionWrapper(int id, T value) : base(id, value)
        {
        }
    }
}
