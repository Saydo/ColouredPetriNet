using System.Collections.Generic;

namespace ColouredPetriNet.Gui.Core.Events
{
    public class PetriNetNodeEventArgs : System.EventArgs
    {
        public int Id;
        public int TypeId;

        public PetriNetNodeEventArgs(int id = -1, int typeId = -1)
            : base()
        {
            Id = id;
            TypeId = typeId;
        }
    }

    public class StateEventArgs : PetriNetNodeEventArgs
    {
        public List<int> Markers;

        public StateEventArgs(int id = -1, int typeId = -1)
            : base(id, typeId)
        {
            Markers = new List<int>();
        }

        public StateEventArgs(int id, int typeId, List<int> markersList)
            : base(id, typeId)
        {
            Id = id;
            Markers = markersList;
        }
    }

    public class ExtendedStateEventArgs : PetriNetNodeEventArgs
    {
        public List<System.Tuple<int, int>> Markers;

        public ExtendedStateEventArgs(int id = -1, int typeId = -1)
            : base(id, typeId)
        {
            Markers = new List<System.Tuple<int, int>>();
        }

        public ExtendedStateEventArgs(int id, int typeId, List<System.Tuple<int, int>> markersList)
            : base(id, typeId)
        {
            Markers = markersList;
        }
    }

    public class ShowInfoEventArgs : System.EventArgs
    {
        public enum ItemType { State, Transition, Marker };

        public int Id;
        public ItemType Type;

        public ShowInfoEventArgs(int id = -1)
            : base()
        {
            Id = id;
            Type = ItemType.State;
        }

        public ShowInfoEventArgs(int id, ItemType type)
            : base()
        {
            Id = id;
            Type = type;
        }
    }
}
