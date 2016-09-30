using System;
using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public delegate void MoveMarkersAction(List<Tuple<int, int>> outputMarkers, List<Tuple<int, int>> inputMarkers,
        StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition);

    public sealed class MoveRule : MarkerTransitionRule
    {
        public int OutputState { get; private set; }
        public int InputState { get; private set; }
        public int Transition { get; private set; }
        public MoveMarkersAction MoveFunction;

        public MoveRule()
            : this(-1, AnyType, AnyType, AnyType, 1)
        {
        }

        public MoveRule(int id, int fromState, int toState, int transition, int priority = 1)
            : base(id, priority)
        {
            OutputState = fromState;
            InputState = toState;
            Transition = transition;
        }

        public bool Equals(MoveRule rule)
        {
            if ((this.OutputState != rule.OutputState)
                || (this.InputState != rule.InputState)
                || (this.Transition != rule.Transition)
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

        public bool IsFit(int outputState, int inputState, int transition,
            List<OneTypeMarkerInfo> outputMarkers)
        {
            if ((this.UpdatedMarkers.Count == 0)
                || ((this.OutputState != AnyType) && (this.OutputState != outputState))
                || ((this.InputState != AnyType) && (this.InputState != inputState))
                || ((this.Transition != AnyType) && (this.Transition != transition)))
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

        public bool Move(IdGenerator idGenerator, StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition)
        {
            if ((outputState == null) || (inputState == null) || (transition == null)
                || ((this.OutputState != AnyType) && (this.OutputState != outputState.Type))
                || ((this.InputState != AnyType) && (this.InputState != inputState.Type))
                || ((this.Transition != AnyType) && (this.Transition != transition.Type)))
            {
                return false;
            }
            List<Tuple<int, int>> outputMarkers, inputMarkers;
            this.Transit(idGenerator, outputState, out outputMarkers, out inputMarkers);
            MoveFunction(outputMarkers, inputMarkers, outputState, inputState, transition);
            return true;
        }
    }
}
