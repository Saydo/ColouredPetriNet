namespace ColouredPetriNet.Container.ColouredPetriNet.Interfaces
{
    public interface ITransitionWrapper : IColouredPetriNetNode
    {
    }

    public interface ITransitionWrapper<T> : ITransitionWrapper, IColouredPetriNetNode<T>
    {
    }
}
