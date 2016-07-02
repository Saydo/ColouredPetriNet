using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public delegate void AccumulateMarkersFunction(IStateWrapper state, List<IMarkerWrapper> markers);

    public class PetriNetAccumulateRule
    {
        public Type State { get; set; }
        public List<Tuple<Type, int>> Markers { get; set; }
        public AccumulateMarkersFunction AccumulateFunction { get; set; }

        public PetriNetAccumulateRule(Type state, List<Tuple<Type, int>> markers)
        {
            State = state;
            Markers = markers;
        }

        public bool IsComply(Type state, List<Tuple<Type, List<int>>> inputMarkers)
        {
            if (State != state)
            {
                return false;
            }
            bool isFound = false;
            for (int i = 0; i < Markers.Count; ++i)
            {
                for (int j = 0; j < inputMarkers.Count; ++j)
                {
                    if (Markers[i].Item1 == inputMarkers[j].Item1)
                    {
                        if (Markers[i].Item2 <= inputMarkers[j].Item2.Count)
                        {
                            isFound = true;
                            break;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                if (!isFound)
                {
                    return false;
                }
            }
            return true;
        }
    }
}