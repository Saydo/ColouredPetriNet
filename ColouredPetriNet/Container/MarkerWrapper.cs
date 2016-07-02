using System;

namespace ColouredPetriNet.Container
{
    public class MarkerWrapper<T> : IMarkerWrapper<T>
    {
        public int Id { get; private set; }
        public int StateId { get; set; }
        public T Value { get; private set; }

        public MarkerWrapper(int id, int stateId, T value)
        {
            Id = id;
            StateId = stateId;
            Value = value;
        }

        public Type GetValueType()
        {
            return typeof(T);
        }
    }
}