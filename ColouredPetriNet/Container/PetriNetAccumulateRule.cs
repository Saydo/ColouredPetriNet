using System;
using System.Collections.Generic;

namespace PetriNet
{
    public delegate void AccumulateMarkersFunction(IStateWrapper state, List<IMarkerWrapper> markers);

    public class PetriNetAccumulateRule
    {
        public Type state;
        public List<Tuple<Type, int>> markers;
        public AccumulateMarkersFunction accumulateFunction;

        public PetriNetAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            this.state = state;
            this.markers = markers;
        }

        public bool isComply(Type state, List<Tuple<Type, List<int>>> in_markers)
        {
            if (this.state != state)
            {
                return false;
            }
            bool is_found = false;
            for (int i = 0; i < this.markers.Count; ++i)
            {
                for (int j = 0; j < in_markers.Count; ++j)
                {
                    if (this.markers[i].Item1 == in_markers[j].Item1)
                    {
                        if (this.markers[i].Item2 <= in_markers[j].Item2.Count)
                        {
                            is_found = true;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (!is_found)
                {
                    return false;
                }
            }
            return true;
        }
    }
}