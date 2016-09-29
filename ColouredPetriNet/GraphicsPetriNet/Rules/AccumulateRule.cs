using System;
using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public delegate void AccumulateFunction(StateWrapper state, List<Tuple<int, int>> outputMarkers,  List<Tuple<int, int>> inputMarkers);

    public sealed class AccumulateRule : PetriNetRule
    {
        public const int AnyType = -1;

        public int State { get; private set; }
        public List<OneTypeMarkerConvertInfo> UpdatedMarkers;
        public List<OneTypeMarkerInfo> NewMarkers;
        public AccumulateFunction AccumulateFunction;

        public override int Weight
        {
            get
            {
                int count = 0;
                foreach (var m in UpdatedMarkers)
                    count += m.Count;
                return count;
            }
        }

        public AccumulateRule(int state = AnyType, int priority = 1)
            : base(priority)
        {
            State = state;
            UpdatedMarkers = new List<OneTypeMarkerConvertInfo>();
            NewMarkers = new List<OneTypeMarkerInfo>();
        }

        public bool Equals(AccumulateRule rule)
        {
            if ((this.State != rule.State)
                || (this.UpdatedMarkers.Count != rule.UpdatedMarkers.Count))
            {
                return false;
            }
            int j;
            for (int i = 0; i < rule.UpdatedMarkers.Count; ++i)
            {
                for (j = 0; j < this.UpdatedMarkers.Count; ++j)
                {
                    if (this.UpdatedMarkers[j].MarkerType == rule.UpdatedMarkers[i].MarkerType)
                    {
                        if (this.UpdatedMarkers[j].Count > rule.UpdatedMarkers[i].Count)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == this.UpdatedMarkers.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsFit(int state, List<OneTypeMarkerInfo> outputMarkers)
        {
            if ((this.UpdatedMarkers.Count == 0)
                || ((this.State !=  AnyType) && (this.State != state)))
            {
                return false;
            }
            int j;
            for (int i = 0; i < outputMarkers.Count; ++i)
            {
                for (j = 0; j < this.UpdatedMarkers.Count; ++j)
                {
                    if (this.UpdatedMarkers[j].MarkerType == outputMarkers[i].MarkerType)
                    {
                        if (this.UpdatedMarkers[j].Count > outputMarkers[i].Count)
                        {
                            return false;
                        }
                        break;
                    }
                }
                if (j == this.UpdatedMarkers.Count)
                {
                    return false;
                }
            }
            return true;
        }

        public bool Accumulate(IdGenerator idGenerator, StateWrapper state)
        {
            if ((this.State != AnyType) && (this.State != state.Type))
            {
                return false;
            }
            var stateIndexMap = GetStateIndexMap(state);
            if (stateIndexMap == null)
            {
                return false;
            }
            // Remove markers from state
            int newId;
            var outputMarkers = new List<Tuple<int, int>>();
            var inputMarkers = new List<Tuple<int, int>>();
            for (int i = 0; i < this.UpdatedMarkers.Count; ++i)
            {
                var markerList = state.Markers[stateIndexMap[i]].Item2;
                var convertRules = this.UpdatedMarkers[i].ConvertRules;
                // Update Old Markers
                int j = 0;
                for (j = 0; ((j < markerList.Count) && (j < convertRules.Count)); ++j)
                {
                    outputMarkers.Add(new Tuple<int, int>(this.UpdatedMarkers[i].MarkerType, markerList[j]));
                    // Update marker
                    switch (convertRules[j].UpdatedMarkerConvert)
                    {
                    case IdConvertType.New:
                        newId = idGenerator.Next();
                        inputMarkers.Add(new Tuple<int, int>(convertRules[j].UpdatedMarkerType, newId));
                        break;
                    case IdConvertType.Delete:
                        break;
                    case IdConvertType.Move:
                        inputMarkers.Add(new Tuple<int, int>(convertRules[j].UpdatedMarkerType, markerList[j]));
                        break;
                    }
                    // Create New Markers
                    foreach (var newMarker in convertRules[j].NewMarkers)
                    {
                        for (int k = 0; k < newMarker.Count; ++k)
                        {
                            inputMarkers.Add(new Tuple<int, int>(newMarker.MarkerType, idGenerator.Next()));
                        }
                    }
                }
                // Update Rest Marlers
                var restIdConvert = this.UpdatedMarkers[i].RestMarkersIdConvert;
                for (; ((j < markerList.Count) && j < (this.UpdatedMarkers[i].Count)); ++j)
                {
                    outputMarkers.Add(new Tuple<int, int>(this.UpdatedMarkers[i].MarkerType, markerList[j]));
                    // Update marker
                    switch (restIdConvert.UpdatedMarkerConvert)
                    {
                    case IdConvertType.New:
                        newId = idGenerator.Next();
                        inputMarkers.Add(new Tuple<int, int>(restIdConvert.UpdatedMarkerType, newId));
                        break;
                    case IdConvertType.Delete:
                        break;
                    case IdConvertType.Move:
                        inputMarkers.Add(new Tuple<int, int>(restIdConvert.UpdatedMarkerType, markerList[j]));
                        break;
                    }
                    // Create New Markers
                    foreach (var newMarker in restIdConvert.NewMarkers)
                    {
                        for (int k = 0; k < newMarker.Count; ++k)
                        {
                            inputMarkers.Add(new Tuple<int, int>(newMarker.MarkerType, idGenerator.Next()));
                        }
                    }
                }
            }
            // Create New Markers
            foreach (var newMarker in this.NewMarkers)
            {
                for (int k = 0; k < newMarker.Count; ++k)
                {
                    inputMarkers.Add(new Tuple<int, int>(newMarker.MarkerType, idGenerator.Next()));
                }
            }
            AccumulateFunction(state, outputMarkers, inputMarkers);
            return true;
        }

        #region Helpful Functions

        private List<int> GetStateIndexMap(StateWrapper state)
        {
            var indexMap = new List<int>();
            if (this.UpdatedMarkers.Count == 0)
            {
                return null;
            }
            int j;
            for (int i = 0; i < this.UpdatedMarkers.Count; ++i)
            {
                for (j = 0; j < state.Markers.Count; ++j)
                {
                    if (this.UpdatedMarkers[i].MarkerType == state.Markers[j].Item1.TypeId)
                    {
                        if (this.UpdatedMarkers[i].Count > state.Markers[j].Item2.Count)
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