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
            public List<PetriNetAccumulateRule> Rules;
            public int Count { get { return Rules.Count; } }

            public AccumulateRuleStorage()
            {
                Rules = new List<PetriNetAccumulateRule>();
            }

            /*
            public void Add(int stateType, List<Tuple<int, int>> markers)
            {
                Rules.Add(new PetriNetAccumulateRule(stateType, markers));
            }

            public void Add(int stateType, int markerType, int markerCount = 1)
            {
                var markers = new List<Tuple<int, int>>();
                markers.Add(new Tuple<int, int>(markerType, markerCount));
                Rules.Add(new PetriNetAccumulateRule(stateType, markers));
            }

            public void Remove(int stateType, List<Tuple<int, int>> markers)
            {
                int index = GetIndex(stateType, markers);
                if (index > 0)
                {
                    Rules.RemoveAt(index);
                }
            }

            public void Remove(int stateType, int markerType, int markerCount = -1)
            {
                if (markerCount < 0)
                {
                    var indexList = GetIndexList(stateType, markerType);
                    RemoveFromList(Rules, indexList);
                }
                else
                {
                    var markers = new List<Tuple<int, int>>();
                    markers.Add(new Tuple<int, int>(markerType, markerCount));
                    int index = GetIndex(stateType, markers);
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

            public bool Accumulate(StateWrapper state)
            {
                var rule = GetSuitableRule(state.Type, state.Markers);
                if ((!ReferenceEquals(null, rule)) && (!ReferenceEquals(null, rule.Accumulate)))
                {
                    rule.Accumulate(state);
                    return true;
                }
                return false;
            }

            #region Helpful functions
            public List<int> GetIndexList(int stateType, int markerType)
            {
                var indexList = new List<int>();
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if ((Rules[i].StateType == stateType)
                        && (Rules[i].Markers.Count == 1)
                        && (Rules[i].Markers[0].Item1 == markerType))
                    {
                        indexList.Add(i);
                    }
                }
                return indexList;
            }

            public int GetIndex(int stateType, List<Tuple<int, int>> markers)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if ((Rules[i].StateType == stateType)
                        && IsEquals(Rules[i].Markers, markers))
                    {
                        return i;
                    }
                }
                return -1;
            }

            public PetriNetAccumulateRule GetSuitableRule(int stateType, List<Tuple<GraphicsItems.GraphicsItem, List<int>>> inputMarkers)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].IsComply(stateType, inputMarkers))
                    {
                        return Rules[i];
                    }
                }
                return new PetriNetAccumulateRule(-1, null, null);
            }

            public PetriNetAccumulateRule GetSuitableRule(int stateType, List<Tuple<int, List<int>>> inputMarkers)
            {
                for (int i = 0; i < Rules.Count; ++i)
                {
                    if (Rules[i].IsComply(stateType, inputMarkers))
                    {
                        return Rules[i];
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
            */
        }
    }
}
