using System.Collections.Generic;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        public Interfaces.IMoveRuleStorage MoveRules;

        private class MoveRuleStorage : Interfaces.IMoveRuleStorage
        {
            private List<PetriNetMoveRule> _rules;

            public MoveRuleStorage()
            {
                _rules = new List<PetriNetMoveRule>();
            }

            public void Add(int inputStateType, int outputStateType, int transitionType,
                int markerType, int markerCount = 1)
            {
                _rules.Add(new PetriNetMoveRule(inputStateType, outputStateType, transitionType,
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
                        _rules.RemoveAt(indexList[i]);
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
                        _rules.RemoveAt(index);
                    }
                }
            }

            public void Clear()
            {
                _rules.Clear();
            }

            #region Helpful Functions
            public List<int> GetIndexList(int inputStateType, int outputStateType,
                int transitionType, int markerType)
            {
                var indexList = new List<int>();
                for (int i = 0; i < _rules.Count; ++i)
                {
                    if ((_rules[i].InputStateType == inputStateType)
                        && (_rules[i].OutputStateType == outputStateType)
                        && (_rules[i].TransitionType == transitionType)
                        && (_rules[i].MarkerType == markerType))
                    {
                        indexList.Add(i);
                    }
                }
                return indexList;
            }

            public int GetIndex(int inputStateType, int outputStateType, int transitionType,
                int markerType, int markerCount)
            {
                for (int i = 0; i < _rules.Count; ++i)
                {
                    if ((_rules[i].InputStateType == inputStateType)
                        && (_rules[i].OutputStateType == outputStateType)
                        && (_rules[i].TransitionType == transitionType)
                        && (_rules[i].MarkerType == markerType)
                        && (_rules[i].MarkerCount == markerCount))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public PetriNetMoveRule GetSuitableRule(int inputStateType, int outputStateType,
                int transitionType, int markerType, int markerCount)
            {
                for (int i = 0; i < _rules.Count; ++i)
                {
                    if (_rules[i].IsComply(inputStateType, outputStateType, transitionType,
                        markerType, markerCount))
                    {
                        return _rules[i];
                    }
                }
                return new PetriNetMoveRule(-1, -1, -1, -1, -1);
            }
            #endregion
        }
    }
}
