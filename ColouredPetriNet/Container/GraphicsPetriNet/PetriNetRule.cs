using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public abstract class PetriNetRule
    {
        public List<OneTypeItemIdConvertationRule> ConversationRules;
        public int Priority;

        public int Weight
        {
            get
            {
                int count = 0;
                for (int i = 0; i < ConversationRules.Count; ++i)
                {
                    count += ConversationRules[i].ItemCount;
                }
                return count;
            }
        }

        public PetriNetRule(int priority)
        {
            Priority = priority;
            ConversationRules = new List<OneTypeItemIdConvertationRule>();
        }

        protected Tuple<int, List<int>> GetMarkerIdList(int index, StateWrapper state)
        {
            return new Tuple<int, List<int>>(state.Markers[index].Item1.TypeId,
                state.Markers[index].Item2);
        }

        protected List<int> GetIndexMap(StateWrapper state)
        {
            var indexMap = new List<int>();
            if (ConversationRules.Count == 0)
            {
                System.Console.WriteLine("[GetIndexMap] (1) => null");
                return null;
            }
            int j;
            for (int i = 0; i < ConversationRules.Count; ++i)
            {
                for (j = 0; j < state.Markers.Count; ++j)
                {
                    System.Console.WriteLine("ConversationRules[{0}].OutputItemType = {1}", i,
                        ConversationRules[i].OutputItemType);
                    System.Console.WriteLine("Markers[{0}].Type = {1}", i,
                        state.Markers[j].Item1.TypeId);
                    if (ConversationRules[i].OutputItemType == state.Markers[j].Item1.TypeId)
                    {
                        if (ConversationRules[i].ItemCount > state.Markers[j].Item2.Count)
                        {
                            System.Console.WriteLine("[GetIndexMap] (2) => null");
                            return null;
                        }
                        indexMap.Add(j);
                        break;
                    }
                }
                if (j == state.Markers.Count)
                {
                    System.Console.WriteLine("[GetIndexMap] (3) => null");
                    return null;
                }
            }
            return indexMap;
        }
    }
}
