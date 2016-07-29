using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public delegate void PrevAccumulateFunction(StateWrapper state, Tuple<int, List<int>> outputMarker);
    public delegate void NextAccumulateFunction(StateWrapper state, Tuple<int, List<int>> outputMarker, List<Tuple<int, List<int>>> inputMarkers);
    public delegate void AccumulateFunction(int oldId, int newId, int type, StateWrapper state);

    public sealed class AccumulateRule : PetriNetRule
    {
        public const int Any = -1;

        public int StateType;
        public PrevAccumulateFunction PrevAccumulateFunction;
        public NextAccumulateFunction NextAccumulateFunction;
        public AccumulateFunction AccumulateFunction;

        public AccumulateRule(int stateType = Any, int priority = 1, PrevAccumulateFunction prevAccumulateFunction = null,
            NextAccumulateFunction nextAccumulateFunction = null) : base(priority)
        {
            StateType = stateType;
            PrevAccumulateFunction = prevAccumulateFunction;
            NextAccumulateFunction = nextAccumulateFunction;
        }

        public bool Accumulate(StateWrapper state)
        {
            if ((StateType != Any) && (StateType != state.Type))
            {
                return false;
            }
            var indexMap = GetIndexMap(state);
            if (indexMap == null)
            {
                return false;
            }
            if (PrevAccumulateFunction != null)
            {
                for (int i = 0; i < indexMap.Count; ++i)
                {
                    PrevAccumulateFunction(state, GetMarkerIdList(indexMap[i], state));
                }
            }
            List<Tuple<int, IdConvertationRule>> conversationRules;
            Tuple<int, List<int>> outputMarkers;
            List<Tuple<int, List<int>>> inputMarkers;
            int oldId, newId;
            for (int i = 0; i < ConversationRules.Count; ++i)
            {
                outputMarkers = GetMarkerIdList(indexMap[i], state);
                inputMarkers = new List<Tuple<int, List<int>>>();
                conversationRules = ConversationRules[i].ConvertationRules;
                for (int j = 0; j < conversationRules.Count; ++j)
                {
                    if ((conversationRules[j].Item2.Mode != IdConvertationRule.ConvertationMode.Removed)
                        && (AccumulateFunction != null))
                    {
                        oldId = outputMarkers.Item2[j];
                        newId = conversationRules[j].Item2.Convert(oldId);
                        SetToMarkerList(inputMarkers, newId, conversationRules[j].Item1);
                        AccumulateFunction(oldId, newId, outputMarkers.Item1, state);
                    }
                }
                if (NextAccumulateFunction != null)
                {
                    NextAccumulateFunction(state, outputMarkers, inputMarkers);
                }
            }
            return true;
        }

        public bool IsComply(int stateType, List<OneTypeMarkers> outputMarkers)
        {
            if ((ConversationRules.Count == 0)
                || ((StateType != Any) && (StateType != stateType)))
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

        public bool IsEquals(AccumulateRule rule)
        {
            if ((this.StateType != rule.StateType)
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