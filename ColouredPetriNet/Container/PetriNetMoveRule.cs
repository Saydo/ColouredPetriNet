using System;
using System.Collections.Generic;

namespace PetriNet
{
    public delegate void MoveMarkersFunction(IStateWrapper state1, IStateWrapper state2,
        IPetriNetNode transition, List<IMarkerWrapper> markers);

    public class PetriNetMoveRule
    {
        public Type inputState;
        public Type outputState;
        public Type transition;
        public Type marker;
        public int count;
        public MoveMarkersFunction moveFunction;

        public PetriNetMoveRule(Type input_state, Type output_state, Type transition, Type marker, int count)
        {
            inputState = input_state;
            outputState = output_state;
            this.transition = transition;
            this.marker = marker;
        }

        public bool isComply(Type input_state, Type output_state, Type transition, Type marker, int count)
        {
            return ((inputState == input_state) && (outputState == output_state)
                && (this.transition == transition) && (this.marker == marker) && (this.count <= count));
        }
    }
}
