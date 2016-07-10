using System.Collections.Generic;
using System.Drawing;

namespace ColouredPetriNet.Gui.Core
{
    public enum LinkDirection { FromStateToTransition, FromTransitionToState };

    public interface IPetriNetGraphicsMap
    {
        // Properties
        int ItemCount { get; }
        int LinkCount { get; }
        int MarkerCount { get; }
        int TransitionCount { get; }
        int StateCount { get; }
        Style.ColouredPetriNetStyle Style { get; set; }
        // Add
        void AddState(int x, int y, ColouredStateType stateType);
        void AddTransition(int x, int y, ColouredTransitionType transitionType);
        void AddMarker(int stateId, ColouredMarkerType markerType);
        void AddLink(int stateId, int transitionId, LinkDirection direction);
        // Remove
        bool RemoveItem(int id);
        bool RemoveLink(int id);
        bool RemoveLinks(int stateId, int transitionId);
        bool RemoveLinks(int stateId, int transitionId, LinkDirection direction);
        bool RemoveMarker(int id);
        bool RemoveMarker(int id, int stateId);
        bool RemoveMarkers(int stateId);
        bool RemoveMarkers(ColouredMarkerType markerType);
        bool RemoveMarkers(int stateId, ColouredMarkerType markerType);
        bool RemoveState(int id);
        bool RemoveStates(ColouredStateType stateType);
        bool RemoveTransition(int id);
        bool RemoveTransitions(ColouredStateType transitionType);
        // Clear
        void Clear();
        void ClearLinks();
        void ClearMarkers();
        void ClearStates();
        void ClearTransitions();
        // Contains
        bool Contains(int id);
        bool Contains(ColouredMarkerType markerType);
        bool Contains(ColouredStateType stateType);
        bool Contains(ColouredTransitionType transitionType);
        bool Contains(int id, ColouredMarkerType markerType);
        bool Contains(int id, ColouredStateType stateType);
        bool Contains(int id, ColouredTransitionType transitionType);
        bool ContainsMarker(int id);
        bool ContainsState(int id);
        bool ContainsTransition(int id);
        bool ContainsLink(int stateId, int transitionId);
        bool ContainsLink(int stateId, int transitionId, LinkDirection direction);
        // Count
        int GetItemCount();
        int GetMarkerCount(ColouredMarkerType markerType);
        int GetTransitionCount(ColouredTransitionType transitionType);
        int GetStateCount(ColouredStateType stateType);
        int GetLinkCount(int stateId, int transitionId);
        int GetLinkCount(int stateId, int transitionId, LinkDirection direction);
        // Find
        List<GraphicsItems.GraphicsItem> FindItems(int x, int y);
        List<GraphicsItems.GraphicsItem> FindLinks(int x, int y);
        List<GraphicsItems.GraphicsItem> FindMarkers(int x, int y);
        List<GraphicsItems.GraphicsItem> FindMarkers(int x, int y, ColouredMarkerType markerType);
        List<GraphicsItems.GraphicsItem> FindStates(int x, int y);
        List<GraphicsItems.GraphicsItem> FindStates(int x, int y, ColouredStateType stateType);
        List<GraphicsItems.GraphicsItem> FindTransitions(int x, int y);
        List<GraphicsItems.GraphicsItem> FindTransitions(int x, int y, ColouredTransitionType transitionType);
        // Select
        void Select(int x, int y);
        void Select(int x, int y, int w, int h);
        void SelectItems();
        void SelectLinks();
        void SelectLinks(int stateId, int transitionId);
        void SelectLinks(int stateId, int transitionId, LinkDirection direction);
        void SelectMarkers();
        void SelectMarkers(int stateId);
        void SelectMarkers(ColouredMarkerType markerType);
        void SelectMarkers(int stateId, ColouredMarkerType markerType);
        void SelectStates();
        void SelectStates(ColouredStateType stateType);
        void SelectTransitions();
        void SelectTransitions(ColouredTransitionType transitionType);
        // Deselect
        void Deselect(int x, int y);
        void Deselect(int x, int y, int w, int h);
        void DeselectItems();
        void DeselectLinks();
        void DeselectLinks(int stateId, int transitionId);
        void DeselectLinks(int stateId, int transitionId, LinkDirection direction);
        void DeselectMarkers();
        void DeselectMarkers(int stateId);
        void DeselectMarkers(ColouredMarkerType markerType);
        void DeselectMarkers(int stateId, ColouredMarkerType markerType);
        void DeselectStates();
        void DeselectStates(ColouredStateType stateType);
        void DeselectTransitions();
        void DeselectTransitions(ColouredTransitionType transitionType);
        // Serialization
        bool Serialize(string filePath);
        bool Deserialize(string filePath);
        // SelectionArea
        void SetSelectionArea(int x, int y, int w, int h);
        void UpdateSelectionArea(int w, int h);
        void UpdateSelectionAreaByPos(int x, int y);
        void HideSelectionArea();
        // Draw
        void Draw(Graphics graphics);
    }
}
