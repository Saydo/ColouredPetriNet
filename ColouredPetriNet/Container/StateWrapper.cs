using System.Collections.Generic;

namespace PetriNet
{
    public class StateWrapper<T> : PetriNetNode<T>, IStateWrapper<T>
    {
        protected List<int> m_markerList;

        public StateWrapper() : base()
        {
            m_markerList = new List<int>();
        }

        public StateWrapper(int id, T value) : base(id, value)
        {
            m_markerList = new List<int>();
        }

        public int getMarker(int index)
        {
            if ((index < 0) || (index >= m_markerList.Count))
            {
                return -1;
            }
            else
            {
                return m_markerList[index];
            }
        }

        public int getMarkerCount()
        {
            return m_markerList.Count;
        }

        public bool containsMarkers()
        {
            return (m_markerList.Count > 0);
        }

        public bool containsMarker(int id)
        {
            return m_markerList.Contains(id);
        }

        public void addMarker(int id)
        {
            addToIdList(m_markerList, id);
        }

        public void removeMarker(int id)
        {
            m_markerList.Remove(id);
        }
    }
}
