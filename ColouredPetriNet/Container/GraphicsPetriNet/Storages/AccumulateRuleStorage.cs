using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.IAccumulateRuleStorage PrevAccumulateRules;
        public Interfaces.IAccumulateRuleStorage NextAccumulateRules;
        private AccumulateRuleStorage _prevAccumulateRules;
        private AccumulateRuleStorage _nextAccumulateRules;

        private class AccumulateRuleStorage : Interfaces.IAccumulateRuleStorage
        {
            public List<AccumulateRule> Rules;
            public int Count { get { return Rules.Count; } }

            public AccumulateRuleStorage()
            {
                Rules = new List<AccumulateRule>();
            }

            public AccumulateRule this[int index]
            {
                get { return Rules[index]; }
            }

            public bool Add(AccumulateRule rule)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].IsEquals(rule))
                    {
                        return false;
                    }
                }
                Rules.Insert(GetNewRuleIndex(rule), rule);               
                return true;
            }

            public bool Remove(int stateType, List<OneTypeMarkers> markers)
            {
                int index = GetIndex(stateType, markers);
                if (index > 0)
                {
                    Rules.RemoveAt(index);
                    return true;
                }
                return false;
            }

            public void Clear()
            {
                Rules.Clear();
            }

            public AccumulateRule Find(int stateType, List<OneTypeMarkers> markers)
            {
                int index = GetIndex(stateType, markers);
                if (index > 0)
                {
                    return Rules[index];
                }
                return null;
            }

            public void Accumulate(StateWrapper state)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    while (Rules[i].Accumulate(state))
                    {
                    }
                }
            }

            #region Helpful Functions
            public int GetIndex(int stateType, List<OneTypeMarkers> markers)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].IsComply(stateType, markers))
                    {
                        return i;
                    }
                }
                return -1;
            }

            private int GetNewRuleIndex(AccumulateRule rule)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if ((Rules[i].Priority < rule.Priority)
                        || ((Rules[i].Priority == rule.Priority)
                            && (Rules[i].Weight < rule.Weight)))
                    {
                        return i;
                    }
                }
                return Rules.Count;
            }
            #endregion
        }
    }
}
