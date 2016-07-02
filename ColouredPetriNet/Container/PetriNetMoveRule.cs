using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public delegate void MoveMarkersFunction(IStateWrapper state1, IStateWrapper state2,
        IColouredPetriNetNode transition, List<IMarkerWrapper> markers);

    public class PetriNetMoveRule
    {
        public Type InputState { get; set; }
        public Type OutputState { get; set; }
        public Type Transition { get; set; }
        public Type Marker { get; set; }
        public int Count { get; set; }
        public MoveMarkersFunction MoveFunction { get; set; }

        public PetriNetMoveRule(Type inputState, Type outputState, Type transition, Type marker, int count)
        {
            InputState = inputState;
            OutputState = outputState;
            Transition = transition;
            Marker = marker;
        }

        public bool IsComply(Type inputState, Type outputState, Type transition, Type marker, int count)
        {
            return ((InputState == inputState) && (OutputState == outputState)
                && (Transition == transition) && (Marker == marker) && (Count <= count));
        }
    }
}
