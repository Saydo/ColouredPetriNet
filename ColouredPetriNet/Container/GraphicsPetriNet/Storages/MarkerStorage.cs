using System;
using System.Collections;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.IMarkerStorage Markers;
        public delegate void ForEachMarkerFunction(MarkerInfo info, GraphicsItems.GraphicsItem item);

        private class MarkerStorage : Interfaces.IMarkerStorage
        {
            private GraphicsPetriNet _parent;
            private StateStorage _states;

            public MarkerStorage(GraphicsPetriNet parent)
            {
                _parent = parent;
                _states = (StateStorage)_parent.States;
            }

            public int Count
            {
                get { return _states.GetMarkerCount(); }
            }

            public MarkerInfo this[int id]
            {
                get { return _states.GetMarker(id); }
            }

            public GraphicsItems.IGraphicsItem GetItem(int id)
            {
                return _states.GetMarkerItem(id);
            }

            public bool IsExist(int id)
            {
                return _states.IsMarkerExist(id);
            }

            public bool Contains(int type)
            {
                return _states.Contains(type);
            }

            public int GetCount(int type)
            {
                return _states.GetMarkerCount(type);
            }

            public bool Add(int stateId, GraphicsItems.GraphicsItem item)
            {
                return _states.AddMarker(stateId, item);
            }

            public bool Remove(int id)
            {
                return _states.RemoveMarker(id);
            }

            public void RemoveByType(int type)
            {
                _states.RemoveMarkerByType(type);
            }

            public bool RemoveFromState(int stateId)
            {
                return _states.RemoveMarkersFromState(stateId);
            }

            public bool RemoveFromState(int type, int stateId, int count = -1)
            {
                return _states.RemoveMarkersFromState(type, stateId, count);
            }

            public void Clear()
            {
                _states.ClearMarkers();
            }

            public bool Move(int markerId, int oldStateId, int newStateId)
            {
                return _states.MoveMarker(markerId, oldStateId, newStateId);
            }

            public bool MoveAll(int oldStateId, int newStateId)
            {
                return _states.MoveAllMarkers(oldStateId, newStateId);
            }

            public bool MoveAll(int type, int oldStateId, int newStateId)
            {
                return _states.MoveAllMarkers(type, oldStateId, newStateId);
            }

            public void MoveByRules()
            {
                _states.MoveMarkersByRules();
            }

            public void ForEachMarker(ForEachMarkerFunction function)
            {
                _states.ForEachMarker(function);
            }
        }
    }
}
