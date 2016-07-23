using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public delegate void AccumulateMarkersFunction(StateWrapper state);

    public struct PetriNetAccumulateRule
    {
        public const int Any = -1;

        public int StateType;
        public List<Tuple<int, int>> Markers;
        public AccumulateMarkersFunction Accumulate;

        public PetriNetAccumulateRule(int stateType, List<Tuple<int, int>> markers, AccumulateMarkersFunction function = null)
        {
            StateType = stateType;
            Markers = markers;
            Accumulate = function;
        }

        public bool IsComply(int stateType, List<Tuple<GraphicsItems.GraphicsItem, List<int>>> inputMarkers)
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
                    if ((Markers[i].Item1 == Any) || (Markers[i].Item1 == inputMarkers[j].Item1.TypeId))
                    {
                        if ((Markers[i].Item2 == Any) || (Markers[i].Item2 <= inputMarkers[j].Item2.Count))
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