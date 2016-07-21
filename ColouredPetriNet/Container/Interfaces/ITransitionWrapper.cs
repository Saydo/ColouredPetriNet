namespace ColouredPetriNet.Container.Interfaces
{
    public interface ITransitionWrapper : IColouredPetriNetNode
    {
    }

    public interface ITransitionWrapper<T> : ITransitionWrapper, IColouredPetriNetNode<T>
    {
    }
}
