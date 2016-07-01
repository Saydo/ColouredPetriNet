using System;

namespace PetriNet
{
    public interface IMarkerWrapper
    {
        int getId();
        int getStateId();
        void setStateId(int value);
        Type getValueType();
    }

    public interface IMarkerWrapper<T> : IMarkerWrapper
    {
        T getValue();
    }
}
