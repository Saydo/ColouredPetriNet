using System;

namespace PetriNet
{
    public class MarkerWrapper<T> : IMarkerWrapper<T>
    {
        public MarkerWrapper(int id, int state_id, T value)
        {
            m_id = id;
            m_stateId = state_id;
            m_value = value;
        }

        public int getId()
        {
            return m_id;
        }

        public int getStateId()
        {
            return m_stateId;
        }

        public void setStateId(int value)
        {
            m_stateId = value;
        }

        public T getValue()
        {
            return m_value;
        }

        public Type getValueType()
        {
            return typeof(T);
        }

        protected int m_id;
        protected int m_stateId;
        protected T m_value;
    }
}
