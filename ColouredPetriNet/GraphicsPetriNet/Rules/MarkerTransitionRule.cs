using System;
using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public class MarkerTransitionRule
    {
        public const int AnyType = -1;

        public int Id { get; private set; }
        public int Priority { get; set; }
        public List<OneTypeMarkerConvertInfo> UpdatedMarkers;
        public List<OneTypeMarkerInfo> NewMarkers;

        public int Weight
        {
            get
            {
                int count = 0;
                foreach (var m in UpdatedMarkers)
                    count += m.Count;
                return count;
            }
        }

        public MarkerTransitionRule(int id, int priority = 1)
        {
            Id = id;
            Priority = priority;
            UpdatedMarkers = new List<OneTypeMarkerConvertInfo>();
            NewMarkers = new List<OneTypeMarkerInfo>();
        }

        protected bool Transit(IdGenerator idGenerator, StateWrapper outputState, out List<Tuple<int, int>> outputMarkers, out List<Tuple<int, int>> inputMarkers)
        {
            outputMarkers = new List<Tuple<int, int>>();
            inputMarkers = new List<Tuple<int, int>>();
            if (outputState == null)
            {
                return false;
            }
            var outputStateIndexMap = GetStateIndexMap(outputState);
            if (outputStateIndexMap == null) return false;
            // Remove markers from state
            int newId;
            for (int i = 0; i < this.UpdatedMarkers.Count; ++i)
            {
                var markerList = outputState.Markers[outputStateIndexMap[i]].Item2;
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
