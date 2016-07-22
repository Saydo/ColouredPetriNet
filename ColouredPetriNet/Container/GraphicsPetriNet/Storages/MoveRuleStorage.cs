using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.IMoveRuleStorage MoveRules;

        private class MoveRuleStorage : Interfaces.IMoveRuleStorage
        {
            public List<PetriNetMoveRule> Rules;
            public int Count { get { return Rules.Count; } }

            public MoveRuleStorage()
            {
                Rules = new List<PetriNetMoveRule>();
            }

            public void Add(int inputStateType, int outputStateType, int transitionType,
                int markerType, int markerCount = 1)
            {
                Rules.Add(new PetriNetMoveRule(inputStateType, outputStateType, transitionType,
                    markerType, markerCount));
            }

            public void Remove(int inputStateType, int outputStateType, int transitionType,
                int markerType, int markerCount = -1)
            {
                if (markerCount < 0)
                {
                    var indexList = GetIndexList(inputStateType, outputStateType, transitionType,
                        markerType);
                    for (int i = indexList.Count - 1; i >= 0; --i)
                    {
                        Rules.RemoveAt(indexList[i]);
                        for (int j = i - 1; j >= 0; --j)
                        {
                            if (indexList[j] > indexList[i])
                            {
                                --indexList[j];
                            }
                        }
                    }
                }
                else
                {
                    int index = GetIndex(inputStateType, outputStateType, transitionType,
                        markerType, markerCount);
                    if (index > 0)
                    {
                        Rules.RemoveAt(index);
                    }
                }
            }

            public void Clear()
            {
                Rules.Clear();
            }

            #region Helpful Functions
            public List<int> GetIndexList(int inputStateType, int outputStateType,
                int transitionType, int markerType)
            {
                var indexList = new List<int>();
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if ((Rules[i].InputStateType == inputStateType)
                        && (Rules[i].OutputStateType == outputStateType)
                        && (Rules[i].TransitionType == transitionType)
                        && (Rules[i].MarkerType == markerType))
                    {
                        indexList.Add(i);
                    }
                }
                return indexList;
            }

            public int GetIndex(int inputStateType, int outputStateType, int transitionType,
                int markerType, int markerCount)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if ((Rules[i].InputStateType == inputStateType)
                        && (Rules[i].OutputStateType == outputStateType)
                        && (Rules[i].TransitionType == transitionType)
                        && (Rules[i].MarkerType == markerType)
                        && (Rules[i].MarkerCount == markerCount))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public PetriNetMoveRule GetSuitableRule(int inputStateType, int outputStateType,
                int transitionType, int markerType, int markerCount)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].IsComply(inputStateType, outputStateType, transitionType,
                        markerType, markerCount))
                    {
                        return Rules[i];
                    }
                }
                return new PetriNetMoveRule(-1, -1, -1, -1, -1);
            }
            #endregion
        }
    }
}
