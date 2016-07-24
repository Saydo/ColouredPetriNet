using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public delegate void AccumulateFunction(StateWrapper state, List<OneTypeMarkers> outputMarkers,
        List<OneTypeMarkers> inputMarkers);

    public class PetriNetAccumulateRule
    {
        public const int Any = -1;

        public int StateType;
        public List<OneTypeMarkers> OutputMarkers;
        public List<OneTypeMarkers> InputMarkers;
        public AccumulateFunction PrevAccumulateFunction;
        public AccumulateFunction NextAccumulateFunction;


        public PetriNetAccumulateRule(int stateType = Any, AccumulateFunction prevAccumulateFunction = null,
            AccumulateFunction nextAccumulateFunction = null)
        {
            StateType = stateType;
            OutputMarkers = new List<OneTypeMarkers>();
            InputMarkers = new List<OneTypeMarkers>();
            PrevAccumulateFunction = prevAccumulateFunction;
            NextAccumulateFunction = nextAccumulateFunction;
        }

        public PetriNetAccumulateRule(int stateType, List<OneTypeMarkers> outputMarkers,
            List<OneTypeMarkers> inputMarkers, AccumulateFunction prevAccumulateFunction = null,
            AccumulateFunction nextAccumulateFunction = null)
        {
            StateType = stateType;
            OutputMarkers = outputMarkers;
            InputMarkers = inputMarkers;
            PrevAccumulateFunction = prevAccumulateFunction;
            NextAccumulateFunction = nextAccumulateFunction;
        }

        /*
        public bool Accumulate(StateWrapper state)
        {
            if (state.Type != StateType)
            {
                return false;
            }
            for (int i = 0; i < state.Markers.Count; ++i)
            {
                if ()
                {
                    //
                }
                for (int j = 0; j < state.Markers[i].Item2.Count; ++j)
                {
                    //
                }
            }
            return false;
        }

        public bool IsComply(int stateType, List<Tuple<GraphicsItems.GraphicsItem, List<int>>> outputMarkers)
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

        public bool IsComply(int stateType, List<OneTypeMarkers> outputMarkers)
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

        private List<int> GetMarkerIndexList(StateWrapper state)
        {
            //OutputMarkers = new List<OneTypeMarkers>();
            var indexList = new List<Tuple<int, List<int>>>(); // ruleTypeIndex, state
            int type;
            bool isFound = false;
            for (int i = 0; i < OutputMarkers.Count; ++i)
            {
                isFound = false;
                type = OutputMarkers[i].Type;
                for (int j = 0; j < state.Markers.Count; ++j)
                {
                    if (state.Markers[j].Item1.TypeId == OutputMarkers[i].Type)
                    {
                        if (state.Markers[j].Item2.Count >= OutputMarkers[i].Count)
                        {
                            //
                        }
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    return false;
                }
            }
            for (int i = 0; i < state.Markers.Count; ++i)
            {
                type = state.Markers[i].Item1.TypeId;
                for ()
                {
                    //
                }
                for (int j = 0; j < state.Markers[i].Item2.Count; ++j)
                {
                    //
                }
            }
        }
        */
    }
}