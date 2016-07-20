using System.Collections;

namespace ColouredPetriNet.Container.Storages
{
    public partial class ColouredPetriNet
    {
        public Interfaces.IMarkerStorage Markers;

        private class MarkerStorage : Interfaces.IMarkerStorage
        {
            public ArrayList markers;

            public MarkerStorage(ColouredPetriNet parent)
            {
            }

            public IMarkerWrapper this[int id] { get; }
            public IMarkerWrapper this[int type, int index] { get; }
            public MarkerWrapper<T> GetWrapper<T>(int id);
            public MarkerWrapper<T> GetWrapper<T>(int type, int index);
            public T GetValue<T>(int id);
            public T GetValue<T>(int type, int index);
            public bool IsExist(int id);
            public bool Contains(int type);
            public int GetCount();
            public int GetCount(int type);
            public int GetTypeId<T>();
            public Tuple<int, int> Create<T>(int stateId, T value);
            public int Create<T>(int type, int stateId, T value);
            public int Add<T>(int id, int stateId, T value);
            public bool Add<T>(int id, int type, int stateId, T value);
            public bool Remove(int id);
            public bool Remove(int id, int type);
            public void RemoveByType(int type);
            public bool RemoveFromState(int stateId);
            public bool RemoveFromState(int type, int stateId, int count = -1);
            public void Clear();
            public bool Move(int markerId, int newStateId, int oldStateId = -1);
            public bool Move(int markerId, int markerType, int newStateId, int newStateType, int oldStateId = -1, int oldStateType = -1);
            public bool MoveAll(int oldStateId, int newStateId);
            public bool MoveAll(int type, int oldStateId, int newStateId);
            public void MoveAll();
        }

        public ColouredPetriNet(int t)
        {
            Markers = new MarkerStorage(this);
            //
        }
    }
}
