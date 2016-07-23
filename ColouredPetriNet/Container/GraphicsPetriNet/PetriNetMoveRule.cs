using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public delegate void MoveMarkersFunction(StateWrapper outputState, StateWrapper inputState,
        TransitionWrapper transition, int markerType, int markerCount);

    public struct PetriNetMoveRule
    {
        public const int Any = -1;

        public int OutputStateType;
        public int InputStateType;
        public int TransitionType;
        public int MarkerType;
        public int MarkerCount;
        public MoveMarkersFunction MoveFunction;

        public PetriNetMoveRule(MoveMarkersFunction function)
        {
            OutputStateType = Any;
            InputStateType = Any;
            TransitionType = Any;
            MarkerType = Any;
            MarkerCount = Any;
            MoveFunction = function;
        }

        public PetriNetMoveRule(int inputStateType, int outputStateType, int transitionType,
            int markerType, int markerCount = Any, MoveMarkersFunction function = null)
        {
            OutputStateType = outputStateType;
            InputStateType = inputStateType;
            TransitionType = transitionType;
            MarkerType = markerType;
            MarkerCount = markerCount;
            MoveFunction = function;
        }

        public bool IsComply(int outputStateType, int inputStateType, int transitionType,
            int markerType, int markerCount)
        {
            return (((OutputStateType == Any) || (OutputStateType == outputStateType))
                && ((InputStateType == Any) || (InputStateType == inputStateType))
                && ((TransitionType == Any) || (TransitionType == transitionType))
                && ((MarkerType == Any) || (MarkerType == markerType))
                && ((MarkerCount == Any) || (MarkerCount <= markerCount)));
        }
    }
}
