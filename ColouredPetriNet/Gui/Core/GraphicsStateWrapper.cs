using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Gui.Core
{
    public class GraphicsStateWrapper
    {
        public GraphicsItems.GraphicsItem State;
        public List<GraphicsLinkWrapper> OutputLinks;
        public List<GraphicsLinkWrapper> InputLinks;
        public List<Tuple<GraphicsItems.GraphicsItem, List<int>>> Markers;

        public GraphicsStateWrapper(GraphicsItems.GraphicsItem state)
        {
            State = state;
            Markers = new List<Tuple<GraphicsItems.GraphicsItem, List<int>>>();
            OutputLinks = new List<GraphicsLinkWrapper>();
            InputLinks = new List<GraphicsLinkWrapper>();
        }

        public void AddMarker(GraphicsItems.GraphicsItem marker)
        {
            List<int> list = new List<int>();
            list.Add(marker.Id);
            AddMarker(marker, list);
        }

        public void AddMarker(GraphicsItems.GraphicsItem marker, List<int> listId)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == marker.TypeId)
                {
                    List<int> newListId = Markers[i].Item2;
                    newListId.AddRange(listId);
                    Markers[i] = new Tuple<GraphicsItems.GraphicsItem, List<int>>(Markers[i].Item1, newListId);
                    return;
                }
            }
            Markers.Add(new Tuple<GraphicsItems.GraphicsItem, List<int>>(marker, listId));
        }

        public bool RemoveMarker(int id)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                for (int j = 0; j < Markers[i].Item2.Count; ++j)
                {
                    if (Markers[i].Item2[j] == id)
                    {
                        Markers[i].Item2.RemoveAt(j);
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RemoveMarker(int id, int typeId)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == typeId)
                {
                    for (int j = 0; j < Markers[i].Item2.Count; ++j)
                    {
                        if (Markers[i].Item2[j] == id)
                        {
                            Markers[i].Item2.RemoveAt(j);
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        public void RemoveMarkers(int typeId, List<int> listId)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == typeId)
                {
                    for (int j = 0; j < listId.Count; ++j)
                    {
                        for (int k = 0; k < Markers[i].Item2.Count; ++k)
                        {
                            if (Markers[i].Item2[k] == listId[j])
                            {
                                Markers[i].Item2.RemoveAt(k);
                                break;
                            }
                        }
                    }
                    return;
                }
            }
        }

        public void RemoveMarkers(int typeId, int count = 1)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == typeId)
                {
                    if (count > Markers[i].Item2.Count)
                    {
                        count = Markers[i].Item2.Count;
                    }
                    Markers[i].Item2.RemoveRange(Markers[i].Item2.Count - count, count);
                    return;
                }
            }
        }
    }
}
