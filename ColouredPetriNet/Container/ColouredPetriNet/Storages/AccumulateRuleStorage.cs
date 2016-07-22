using System;
using System.Collections.Generic;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        public Interfaces.IAccumulateRuleStorage PrevAccumulateRules;
        public Interfaces.IAccumulateRuleStorage NextAccumulateRules;

        private class AccumulateRuleStorage : Interfaces.IAccumulateRuleStorage
        {
            private List<PetriNetAccumulateRule> _rules;

            public AccumulateRuleStorage()
            {
                _rules = new List<PetriNetAccumulateRule>();
            }

            public void Add(int stateType, List<Tuple<int, int>> markers)
            {
                _rules.Add(new PetriNetAccumulateRule(stateType, markers));
            }

            public void Add(int stateType, int markerType, int markerCount = 1)
            {
                var markers = new List<Tuple<int, int>>();
                markers.Add(new Tuple<int, int>(markerType, markerCount));
                _rules.Add(new PetriNetAccumulateRule(stateType, markers));
            }

            public void Remove(int stateType, List<Tuple<int, int>> markers)
            {
                int index = GetIndex(stateType, markers);
                if (index > 0)
                {
                    _rules.RemoveAt(index);
                }
            }

            public void Remove(int stateType, int markerType, int markerCount = -1)
            {
                if (markerCount < 0)
                {
                    var indexList = GetIndexList(stateType, markerType);
                    ColouredPetriNet.RemoveFromList(_rules, indexList);
                }
                else
                {
                    var markers = new List<Tuple<int, int>>();
                    markers.Add(new Tuple<int, int>(markerType, markerCount));
                    int index = GetIndex(stateType, markers);
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

            #region Helpful functions
            public List<int> GetIndexList(int stateType, int markerType)
            {
                var indexList = new List<int>();
                for (int i = 0; i < _rules.Count; ++i)
                {
                    if ((_rules[i].StateType == stateType)
                        && (_rules[i].Markers.Count == 1)
                        && (_rules[i].Markers[0].Item1 == markerType))
                    {
                        indexList.Add(i);
                    }
                }
                return indexList;
            }

            public int GetIndex(int stateType, List<Tuple<int, int>> markers)
            {
                for (int i = 0; i < _rules.Count; ++i)
                {
                    if ((_rules[i].StateType == stateType)
                        && IsEquals(_rules[i].Markers, markers))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public PetriNetAccumulateRule GetSuitableRule(int stateType, List<Tuple<int, List<int>>> inputMarkers)
            {
                for (int i = 0; i < _rules.Count; ++i)
                {
                    if (_rules[i].IsComply(stateType, inputMarkers))
                    {
                        return _rules[i];
                    }
                }
                return new PetriNetAccumulateRule(-1, null, null);
            }

            private bool IsEquals(List<Tuple<int, int>> list1, List<Tuple<int, int>> list2)
            {
                if (list1.Count != list2.Count)
                {
                    return false;
                }
                bool isFound = false;
                for (int i = 0; i < list1.Count; ++i)
                {
                    isFound = false;
                    for (int j = 0; j < list2.Count; ++j)
                    {
                        if ((list1[i].Item1 != list2[j].Item1) || (list1[i].Item2 != list2[j].Item2))
                        {
                            isFound = true;
                            break;
                        }
                    }
                    if (!isFound)
                    {
                        return false;
                    }
                }
                return true;
            }
            #endregion
        }
    }
}
