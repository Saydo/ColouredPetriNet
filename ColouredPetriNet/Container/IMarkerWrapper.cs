using System;

namespace ColouredPetriNet.Container
{
    public interface IMarkerWrapper
    {
        int Id { get; }
        int StateId { get; set; }
        Type GetValueType();
    }

    public interface IMarkerWrapper<T> : IMarkerWrapper
    {
        T Value { get; }
    }
}
