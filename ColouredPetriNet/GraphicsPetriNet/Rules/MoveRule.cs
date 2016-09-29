using System;
using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public delegate void MoveFunction(List<Tuple<int, int>> outputMarkers, List<Tuple<int, int>> inputMarkers,
        StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition);

    public sealed class MoveRule : PetriNetRule
    {
        public const int AnyType = -1;

        public int OutputState { get; private set; }
        public int InputState { get; private set; }
        public int Transition { get; private set; }
        public List<OneTypeMovingMarkerInfo> OneTypeMarkerInfoList;
        public MoveFunction MoveFunction;

        public override int Weight
        {
            get
            {
                int count = 0;
                foreach (var m in OneTypeMarkerInfoList)
                    count += m.Count;
                return count;
            }
        }

        public MoveRule()
            : this(AnyType, AnyType, AnyType, 1)
        {
        }

        public MoveRule(int fromState, int toState, int transition, int priority = 1)
            : base(priority)
        {
            OutputState = fromState;
            InputState = toState;
            Transition = transition;
            OneTypeMarkerInfoList = new List<OneTypeMovingMarkerInfo>();
        }

        public bool Equals(MoveRule rule)
        {
            if ((this.OutputState != rule.OutputState)
                || (this.InputState != rule.InputState)
                || (this.Transition != rule.Transition)
                || (this.OneTypeMarkerInfoList.Count != rule.OneTypeMarkerInfoList.Count))
            {
                return false;
            }
            int j;
            for (int i = 0; i < rule.OneTypeMarkerInfoList.Count; ++i)
            {
                for (j = 0; j < this.OneTypeMarkerInfoList.Count; ++j)
                {
                    if (this.OneTypeMarkerInfoList[j].MarkerType == rule.OneTypeMarkerInfoList[i].MarkerType)
                    {
                        if (this.OneTypeMarkerInfoList[j].Count > rule.OneTypeMarkerInfoList[i].Count)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == this.OneTypeMarkerInfoList.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsFit(int outputState, int inputState, int transition,
            List<OneTypeMarkerInfo> outputMarkers)
        {
            if ((this.OneTypeMarkerInfoList.Count == 0)
                || ((this.OutputState != AnyType) && (this.OutputState != outputState))
                || ((this.InputState != AnyType) && (this.InputState != inputState))
                || ((this.Transition != AnyType) && (this.Transition != transition)))
            {
                return false;
            }
            int j;
            for (int i = 0; i < outputMarkers.Count; ++i)
            {
                for (j = 0; j < this.OneTypeMarkerInfoList.Count; ++j)
                {
                    if (this.OneTypeMarkerInfoList[j].MarkerType == outputMarkers[i].MarkerType)
                    {
                        if (this.OneTypeMarkerInfoList[j].Count > outputMarkers[i].Count)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == this.OneTypeMarkerInfoList.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Move(IdGenerator idGenerator, StateWrapper outputState, StateWrapper inputState, TransitionWrapper transition)
        {
            if (((this.OutputState != AnyType) && (this.OutputState != outputState.Type))
                || ((this.InputState != AnyType) && (this.InputState != inputState.Type))
                || ((this.Transition != AnyType) && (this.Transition != transition.Type)))
            {
                return false;
            }
            var stateIndexMap = GetStateIndexMap(outputState);
            if (stateIndexMap == null)
            {
                return false;
            }
            var outputMarkers = new List<Tuple<int, int>>();
            var inputMarkers = new List<Tuple<int, int>>();
            for (int i = 0; i < this.OneTypeMarkerInfoList.Count; ++i)
            {
                var markerList = outputState.Markers[stateIndexMap[i]].Item2;
                var convertRules = this.OneTypeMarkerInfoList[i].IdConvertList;
                int j = 0;
                for (j = 0; ((j < markerList.Count) && (j < convertRules.Count)); ++j)
                {
                    outputMarkers.Add(new Tuple<int, int>(this.OneTypeMarkerInfoList[i].MarkerType, markerList[j]));
                    switch (convertRules[j])
                    {
                    case MoveIdConvertType.Move:
                        inputMarkers.Add(new Tuple<int, int>(this.OneTypeMarkerInfoList[i].MarkerType, markerList[j]));
                        break;
                    case MoveIdConvertType.Delete:
                        break;
                    }
                }
                for (; ((j < markerList.Count) && j < (this.OneTypeMarkerInfoList[i].Count)); ++j)
                {
                    outputMarkers.Add(new Tuple<int, int>(this.OneTypeMarkerInfoList[i].MarkerType, markerList[j]));
                    switch (this.OneTypeMarkerInfoList[i].CommonConvertType)
                    {
                    case MoveIdConvertType.Move:
                        inputMarkers.Add(new Tuple<int, int>(this.OneTypeMarkerInfoList[i].MarkerType, markerList[j]));
                        break;
                    case MoveIdConvertType.Delete:
                        break;
                    }
                }
            }
            MoveFunction(outputMarkers, inputMarkers, outputState, inputState, transition);
            return true;
        }

        #region Helpful Functions

        private List<int> GetStateIndexMap(StateWrapper state)
        {
            var indexMap = new List<int>();
            if (this.OneTypeMarkerInfoList.Count == 0)
            {
                return null;
            }
            int j;
            for (int i = 0; i < this.OneTypeMarkerInfoList.Count; ++i)
            {
                for (j = 0; j < state.Markers.Count; ++j)
                {
                    if (this.OneTypeMarkerInfoList[i].MarkerType == state.Markers[j].Item1.TypeId)
                    {
                        if (this.OneTypeMarkerInfoList[i].Count > state.Markers[j].Item2.Count)
                        {
                            return null;
                        }
                        indexMap.Add(j);
                        break;
                    }
                }
                if (j == state.Markers.Count)
                {
                    return null;
                }
            }
            return indexMap;
        }

        #endregion
    }
}
