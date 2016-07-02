using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public class StateWrapper<T> : ColouredPetriNetNode<T>, IStateWrapper<T>
    {
        protected List<int> _markerList;

        public StateWrapper() : base()
        {
            _markerList = new List<int>();
        }

        public StateWrapper(int id, T state) : base(id, state)
        {
            _markerList = new List<int>();
        }

        public int GetMarker(int index)
        {
            if ((index < 0) || (index >= _markerList.Count))
            {
                return -1;
            }
            else
            {
                return _markerList[index];
            }
        }

        public int GetMarkerCount()
        {
            return _markerList.Count;
        }

        public bool ContainsMarkers()
        {
            return (_markerList.Count > 0);
        }

        public bool ContainsMarker(int id)
        {
            return _markerList.Contains(id);
        }

        public void AddMarker(int id)
        {
            AddToIdList(_markerList, id);
        }

        public void RemoveMarker(int id)
        {
            _markerList.Remove(id);
        }
    }
}
