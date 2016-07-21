using System.Collections.Generic;

namespace ColouredPetriNet.Container
{
    public delegate void MoveMarkersFunction(Interfaces.IStateWrapper state1,
        Interfaces.IStateWrapper state2, Interfaces.ITransitionWrapper transition,
        List<Interfaces.IMarkerWrapper> markers);

    public struct PetriNetMoveRule
    {
        public int InputStateType;
        public int OutputStateType;
        public int TransitionType;
        public int MarkerType;
        public int MarkerCount;
        public MoveMarkersFunction MoveFunction;

        public PetriNetMoveRule(int inputStateType, int outputStateType, int transitionType,
            int markerType, int markerCount, MoveMarkersFunction function = null)
        {
            InputStateType = inputStateType;
            OutputStateType = outputStateType;
            TransitionType = transitionType;
            MarkerType = markerType;
            MarkerCount = markerCount;
            MoveFunction = function;
        }

        public bool IsComply(int inputStateType, int outputStateType, int transitionType,
            int markerType, int markerCount)
        {
            return ((InputStateType == inputStateType) && (OutputStateType == outputStateType)
                && (TransitionType == transitionType) && (MarkerType == markerType)
                && (MarkerCount <= markerCount));
        }
    }
}
