using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public delegate void PrevMoveFunction(StateWrapper outputState, StateWrapper inputState,
        TransitionWrapper transition, Tuple<int, List<int>> outputMarker);
    public delegate void NextMoveFunction(StateWrapper outputState, StateWrapper inputState,
        TransitionWrapper transition, Tuple<int, List<int>> outputMarker, List<Tuple<int, List<int>>> inputMarkers);
    public delegate void MoveFunction(int oldId, int newId, int type, StateWrapper outputState, StateWrapper inputState,
        TransitionWrapper transition);

    public sealed class MoveRule : PetriNetRule
    {
        public const int Any = -1;

        public int OutputStateType;
        public int InputStateType;
        public int TransitionType;
        public PrevMoveFunction PrevMoveFunction;
        public NextMoveFunction NextMoveFunction;
        public MoveFunction MoveFunction;

        public MoveRule(int priority = 1) : base(priority)
        {
            OutputStateType = Any;
            InputStateType = Any;
            TransitionType = Any;
        }

        public MoveRule(int inputStateType, int outputStateType, int transitionType,
            int priority = 1, PrevMoveFunction prevMoveFunction = null, NextMoveFunction nextMoveFunction = null)
            : base(priority)
        {
            OutputStateType = outputStateType;
            InputStateType = inputStateType;
            TransitionType = transitionType;
            PrevMoveFunction = prevMoveFunction;
            NextMoveFunction = nextMoveFunction;
        }

        public bool Move(StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition)
        {
            if (((OutputStateType != Any) && (OutputStateType != outputState.Type))
                || ((InputStateType != Any) && (InputStateType != inputState.Type))
                || ((TransitionType != Any) && (TransitionType != transition.Type)))
            {
                System.Console.WriteLine("[Move] (1) => false");
                return false;
            }
            var indexMap = GetIndexMap(outputState);
            if (indexMap == null)
            {
                System.Console.WriteLine("[Move] (2) => false");
                return false;
            }
            if (PrevMoveFunction != null)
            {
                for (int i = 0; i < indexMap.Count; ++i)
                {
                    PrevMoveFunction(outputState, inputState, transition,
                        GetMarkerIdList(indexMap[i], outputState));
                }
            }
            List<Tuple<int, IdConvertationRule>> conversationRules;
            Tuple<int, List<int>> outputMarkers;
            List<Tuple<int, List<int>>> inputMarkers;
            int oldId, newId;
            //----------
            System.Console.Write("indexMap:");
            for (int i = 0; i < indexMap.Count; ++i)
            {
                System.Console.Write(" {0}", indexMap[i]);
            }
            System.Console.WriteLine();
            //-------------
            for (int i = 0; i < ConversationRules.Count; ++i)
            {
                outputMarkers = GetMarkerIdList(indexMap[i], outputState);
                inputMarkers = new List<Tuple<int, List<int>>>();
                conversationRules = ConversationRules[i].ConvertationRules;
                for (int j = 0; j < conversationRules.Count; ++j)
                {
                    if ((conversationRules[j].Item2.Mode != IdConvertationRule.ConvertationMode.Removed)
                        && (MoveFunction != null))
                    {
                        oldId = outputMarkers.Item2[j];
                        newId = conversationRules[j].Item2.Convert(oldId);
                        SetToMarkerList(inputMarkers, newId, conversationRules[j].Item1);
                        MoveFunction(oldId, newId, outputMarkers.Item1, outputState, inputState, transition);
                    }
                }
                if (NextMoveFunction != null)
                {
                    NextMoveFunction(outputState, inputState, transition, outputMarkers, inputMarkers);
                }
            }
            return true;
        }

        public bool IsComply(int outputStateType, int inputStateType, int transitionType,
            List<OneTypeMarkers> outputMarkers)
        {
            if ((ConversationRules.Count == 0)
                || ((OutputStateType != Any) && (OutputStateType != outputStateType))
                || ((InputStateType != Any) && (InputStateType != inputStateType))
                || ((TransitionType != Any) && (TransitionType != transitionType)))
            {
                return false;
            }
            int j;
            for (int i = 0; i < outputMarkers.Count; ++i)
            {
                for (j = 0; j < ConversationRules.Count; ++j)
                {
                    if (ConversationRules[j].OutputItemType == outputMarkers[i].Type)
                    {
                        if (ConversationRules[j].ItemCount > outputMarkers[i].Count)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == ConversationRules.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsEquals(MoveRule rule)
        {
            if ((this.OutputStateType != rule.OutputStateType)
                || (this.InputStateType != rule.InputStateType)
                || (this.TransitionType != rule.TransitionType)
                || (this.ConversationRules.Count != rule.ConversationRules.Count))
            {
                return false;
            }
            int j;
            for (int i = 0; i < rule.ConversationRules.Count; ++i)
            {
                for (j = 0; j < this.ConversationRules.Count; ++j)
                {
                    if (this.ConversationRules[j].OutputItemType == rule.ConversationRules[i].OutputItemType)
                    {
                        if (this.ConversationRules[j].ItemCount > rule.ConversationRules[i].ItemCount)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == this.ConversationRules.Count)
                {
                    return false;
                }
            }
            return true;
        }

        private void SetToMarkerList(List<Tuple<int, List<int>>> markerList, int id, int type)
        {
            int i;
            List<int> idList;
            for (i = 0; i < markerList.Count; ++i)
            {
                if (markerList[i].Item1 == type)
                {
                    idList = markerList[i].Item2;
                    idList.Add(id);
                    markerList[i] = new Tuple<int, List<int>>(type, idList);
                    return;
                }
            }
            idList = new List<int>();
            idList.Add(id);
            markerList.Add(new Tuple<int, List<int>>(type, idList));
        }
    }
}
