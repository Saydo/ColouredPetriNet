using System;
using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public delegate void AccumulateMarkersAction(List<Tuple<int, int>> outputMarkers, List<Tuple<int, int>> inputMarkers,
       StateWrapper state);

    public sealed class AccumulateRule : MarkerTransitionRule
    {
        public int State { get; private set; }
        public AccumulateMarkersAction AccumulateFunction;

        public AccumulateRule(int id, int state = AnyType, int priority = 1)
            : base(id, priority)
        {
            State = state;
            UpdatedMarkers = new List<OneTypeMarkerConvertInfo>();
            NewMarkers = new List<OneTypeMarkerInfo>();
        }

        public bool Equals(AccumulateRule rule)
        {
            if ((this.State != rule.State)
                || (this.UpdatedMarkers.Count != rule.UpdatedMarkers.Count))
            {
                return false;
            }
            int j;
            for (int i = 0; i < rule.UpdatedMarkers.Count; ++i)
            {
                for (j = 0; j < this.UpdatedMarkers.Count; ++j)
                {
                    if (this.UpdatedMarkers[j].MarkerType == rule.UpdatedMarkers[i].MarkerType)
                    {
                        if (this.UpdatedMarkers[j].Count > rule.UpdatedMarkers[i].Count)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == this.UpdatedMarkers.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsFit(int state, List<OneTypeMarkerInfo> outputMarkers)
        {
            if ((this.UpdatedMarkers.Count == 0)
                || ((this.State !=  AnyType) && (this.State != state)))
            {
                return false;
            }
            int j;
            for (int i = 0; i < outputMarkers.Count; ++i)
            {
                for (j = 0; j < this.UpdatedMarkers.Count; ++j)
                {
                    if (this.UpdatedMarkers[j].MarkerType == outputMarkers[i].MarkerType)
                    {
                        if (this.UpdatedMarkers[j].Count > outputMarkers[i].Count)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == this.UpdatedMarkers.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Accumulate(IdGenerator idGenerator, StateWrapper state)
        {
            if ((state == null) || ((this.State != AnyType) && (this.State != state.Type)))
            {
                return false;
            }
            List<Tuple<int, int>> outputMarkers, inputMarkers;
            this.Transit(idGenerator, state, out outputMarkers, out inputMarkers);
            AccumulateFunction(outputMarkers, inputMarkers, state);
            return true;
        }
    }
}