using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public delegate void AccumulateMarkersFunction(Interfaces.IStateWrapper state,
        List<Interfaces.IMarkerWrapper> markers);

    public struct PetriNetAccumulateRule
    {
        public int StateType;
        public List<Tuple<int, int>> Markers;
        public AccumulateMarkersFunction AccumulateFunction;

        public PetriNetAccumulateRule(int stateType, List<Tuple<int, int>> markers, AccumulateMarkersFunction function = null)
        {
            StateType = stateType;
            Markers = markers;
            AccumulateFunction = function;
        }

        public bool IsComply(int stateType, List<Tuple<int, List<int>>> inputMarkers)
        {
            if (StateType != stateType)
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