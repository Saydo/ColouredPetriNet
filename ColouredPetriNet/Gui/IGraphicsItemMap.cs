using System.Collections.Generic;
using System.Drawing;
using ColouredPetriNet.Gui.GraphicsItems;

namespace ColouredPetriNet.Gui
{
    public interface IGraphicsItemMap
    {
        OverlapType Overlap { get; set; }
        bool Contains(int id);
        List<GraphicsItem> FindItems(int x, int y);
        void Select(int x, int y);
        void Deselect(int x, int y);
        void Select(int x, int y, int w, int h);
        void Deselect(int x, int y, int w, int h);
        void SelectAllItems();
        void DeselectAllItems();
        void RemoveSelectedItems();
        void AddItem(GraphicsItem item);
        bool RemoveItem(int id);
        void Clear();
        void SetSelectionArea(int x, int y, int w, int h);
        void UpdateSelectionArea(int w, int h);
        void UpdateSelectionAreaByPos(int x, int y);
        void HideSelectionArea();
        void Draw(Graphics graphics);
    }
}
