using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public delegate void MoveFunction(StateWrapper outputState, StateWrapper inputState,
        TransitionWrapper transition, OneTypeMarkers outputMarker, List<OneTypeMarkers> inputMarkers);

    public class PetriNetMoveRule
    {
        public const int Any = -1;

        public int OutputStateType;
        public int InputStateType;
        public int TransitionType;
        public OneTypeMarkers OutputMarkers;
        public List<OneTypeMarkers> InputMarkers;
        public MoveFunction PrevMoveFunction;
        public MoveFunction NextMoveFunction;

        public PetriNetMoveRule()
        {
            OutputStateType = Any;
            InputStateType = Any;
            TransitionType = Any;
            OutputMarkers = new OneTypeMarkers();
            InputMarkers = new List<OneTypeMarkers>();
        }

        public PetriNetMoveRule(int inputStateType, int outputStateType, int transitionType,
            OneTypeMarkers outputMarker, List<OneTypeMarkers> inputMarkers,
            MoveFunction prevMoveFunction = null, MoveFunction nextMoveFunction = null)
        {
            OutputStateType = outputStateType;
            InputStateType = inputStateType;
            TransitionType = transitionType;
            OutputMarkers = outputMarker;
            InputMarkers = inputMarkers;
            PrevMoveFunction = prevMoveFunction;
            NextMoveFunction = nextMoveFunction;
        }

        public Xml.MoveRuleXml ToXml()
        {
            var inputMarkersXml = new List<Xml.OneTypeMarkersXml>();
            for (int i = 0; i < InputMarkers.Count; ++i)
            {
                inputMarkersXml.Add(InputMarkers[i].ToXml());
            }
            return new Xml.MoveRuleXml(OutputStateType, InputStateType, TransitionType,
                OutputMarkers.ToXml(), inputMarkersXml);
        }

        public static PetriNetMoveRule FromXml(Xml.MoveRuleXml ruleXml)
        {
            PetriNetMoveRule rule = new PetriNetMoveRule();
            /*
            var inputMarkersXml = new List<Xml.OneTypeMarkersXml>();
            for (int i = 0; i < ruleXml; ++i)
            {
                inputMarkersXml.Add(InputMarkers[i].ToXml());
            }
            return new Xml.MoveRuleXml(OutputStateType, InputStateType, TransitionType,
                OutputMarkers.ToXml(), inputMarkersXml);
            */
            return rule;
        }

        /*
        public bool IsComply(int outputStateType, int inputStateType, int transitionType,
            int markerType, int markerCount)
        {
            return (((OutputStateType == Any) || (OutputStateType == outputStateType))
                && ((InputStateType == Any) || (InputStateType == inputStateType))
                && ((TransitionType == Any) || (TransitionType == transitionType))
                && ((MarkerType == Any) || (MarkerType == markerType))
                && ((MarkerCount == Any) || (MarkerCount <= markerCount)));
        }
        */
    }
}
