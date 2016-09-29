using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.IMoveRuleStorage MoveRules;
        private MoveRuleStorage _moveRules;

        private class MoveRuleStorage : Interfaces.IMoveRuleStorage
        {
            public List<Rules.MoveRule> Rules;
            public int Count { get { return Rules.Count; } }

            public MoveRuleStorage()
            {
                Rules = new List<Rules.MoveRule>();
            }

            public Rules.MoveRule this[int index]
            {
                get { return Rules[index]; }
            }

            public bool Add(Rules.MoveRule rule)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].Equals(rule))
                    {
                        return false;
                    }
                }
                Rules.Insert(GetNewRuleIndex(rule), rule);
                return true;
            }

            public bool Remove(int outputStateType, int inputStateType, int transitionType,
                List<Rules.OneTypeMarkerInfo> outputMarkers)
            {
                int index = GetIndex(outputStateType, inputStateType, transitionType, outputMarkers);
                if (index >= 0)
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

            public Rules.MoveRule Find(int outputStateType, int inputStateType, int transitionType,
                List<Rules.OneTypeMarkerInfo> outputMarkers)
            {
                int index = GetIndex(outputStateType, inputStateType, transitionType, outputMarkers);
                if (index >= 0)
                {
                    return Rules[index];
                }
                return null;
            }

            public void Move(StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    /*
                    while (Rules[i].Move(outputState, inputState, transition))
                    {
                    }
                    */
                }
            }

            #region Helpful Functions
            public int GetIndex(int outputState, int inputState, int transition, List<Rules.OneTypeMarkerInfo> markers)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].IsFit(outputState, inputState, transition, markers))
                    {
                        return i;
                    }
                }
                return -1;
            }

            private int GetNewRuleIndex(Rules.MoveRule rule)
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
