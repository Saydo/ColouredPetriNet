using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Gui.Core
{
    class GraphicsStateWrapper
    {
        public GraphicsItems.GraphicsItem State;
        public List<GraphicsLinkWrapper> OutputLinks;
        public List<GraphicsLinkWrapper> InputLinks;
        public List<Tuple<GraphicsItems.GraphicsItem, int>> Markers;

        public GraphicsStateWrapper(GraphicsItems.GraphicsItem state)
        {
            State = state;
            Markers = new List<Tuple<GraphicsItems.GraphicsItem, int>>();
            OutputLinks = new List<GraphicsLinkWrapper>();
            InputLinks = new List<GraphicsLinkWrapper>();
        }

        public void AddMarker(GraphicsItems.GraphicsItem marker, int count = 1)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == marker.TypeId)
                {
                    Markers[i] = new Tuple<GraphicsItems.GraphicsItem, int>(Markers[i].Item1,
                            Markers[i].Item2 + count);
                    return;
                }
            }
            Markers.Add(new Tuple<GraphicsItems.GraphicsItem, int>(marker, count));
        }

        public void RemoveMarkers(int typeId, int count = 1)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == typeId)
                {
                    int removeCount = (Markers[i].Item2 < count ? Markers[i].Item2 : count);
                    if (Markers[i].Item2 - removeCount == 0)
                    {
                        Markers.RemoveAt(i);
                    }
                    else
                    {
                        Markers[i] = new Tuple<GraphicsItems.GraphicsItem, int>(Markers[i].Item1,
                            Markers[i].Item2 - removeCount);
                    }
                    return;
                }
            }
        }
    }
}
