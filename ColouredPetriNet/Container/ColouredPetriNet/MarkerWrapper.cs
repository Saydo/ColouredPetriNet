using System;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public class MarkerWrapper<T> : Interfaces.IMarkerWrapper<T>
    {
        public int Id { get; private set; }
        public int Type { get; private set; }
        public int StateId { get; set; }
        public T Value { get; private set; }

        public MarkerWrapper(int id, int type, int stateId, T value)
        {
            Id = id;
            Type = type;
            StateId = stateId;
            Value = value;
        }

        public Type GetValueType()
        {
            return typeof(T);
        }
    }
}