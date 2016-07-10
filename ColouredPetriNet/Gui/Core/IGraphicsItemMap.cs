using System.Collections.Generic;
using System.Drawing;

namespace ColouredPetriNet.Gui.Core
{
    public interface IGraphicsItemMap
    {
        GraphicsItems.OverlapType Overlap { get; set; }
        bool Contains(int id);
        List<GraphicsItems.GraphicsItem> FindItems(int x, int y);
        void Select(int x, int y);
        void Deselect(int x, int y);
        void Select(int x, int y, int w, int h);
        void Deselect(int x, int y, int w, int h);
        void SelectAllItems();
        void DeselectAllItems();
        void RemoveSelectedItems();
        void AddItem(GraphicsItems.GraphicsItem item);
        bool RemoveItem(int id);
        void Clear();
        void SetSelectionArea(int x, int y, int w, int h);
        void UpdateSelectionArea(int w, int h);
        void UpdateSelectionAreaByPos(int x, int y);
        void HideSelectionArea();
        void Draw(Graphics graphics);
    }
}
