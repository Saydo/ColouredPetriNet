namespace ColouredPetriNet.Container.Interfaces
{
    public interface IMarkerWrapper
    {
        int Id { get; }
        int Type { get; }
        int StateId { get; set; }
        System.Type GetValueType();
    }

    public interface IMarkerWrapper<T> : IMarkerWrapper
    {
        T Value { get; }
    }
}
