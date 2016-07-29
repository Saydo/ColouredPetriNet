using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.IMoveRuleStorage MoveRules;
        private MoveRuleStorage _moveRules;

        private class MoveRuleStorage : Interfaces.IMoveRuleStorage
        {
            public List<MoveRule> Rules;
            public int Count { get { return Rules.Count; } }

            public MoveRuleStorage()
            {
                Rules = new List<MoveRule>();
            }

            public MoveRule this[int index]
            {
                get { return Rules[index]; }
            }

            public bool Add(MoveRule rule)
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

            public bool Remove(int outputStateType, int inputStateType, int transitionType,
                List<OneTypeMarkers> outputMarkers)
            {
                int index = GetIndex(outputStateType, inputStateType, transitionType, outputMarkers);
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

            public MoveRule Find(int outputStateType, int inputStateType, int transitionType,
                List<OneTypeMarkers> outputMarkers)
            {
                int index = GetIndex(outputStateType, inputStateType, transitionType, outputMarkers);
                if (index > 0)
                {
                    return Rules[index];
                }
                return null;
            }

            public void Move(StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    while (Rules[i].Move(outputState, inputState, transition))
                    {
                    }
                }
            }

            #region Helpful Functions
            public int GetIndex(int outputStateType, int inputStateType, int transitionType, List<OneTypeMarkers> markers)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].IsComply(outputStateType, inputStateType, transitionType, markers))
                    {
                        return i;
                    }
                }
                return -1;
            }

            private int GetNewRuleIndex(MoveRule rule)
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
