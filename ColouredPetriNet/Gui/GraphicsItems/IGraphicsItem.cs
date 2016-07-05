using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public enum BorderSide { Left, Right, Top, Bottom };
    public enum OverlapType { Full, Partial };

    public interface IGraphicsItem
    {
        int Id { get; }
        int TypeId { get; }
        Point Center { get; set; }
        int Z { get; set; }
        int Extent { get; set; }
        Pen SelectionPen { get; set; }
        void Draw(Graphics graphics);
        void Move(int x, int y);
        bool IsCollision(int x, int y, int z = -1);
        bool IsCollision(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial, int z = -1);
        bool InShape(int x, int y);
        bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial);
        bool InBorder(int x, int y);
        bool IsOverlapBorder(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial);
        void SetBorder(int left, int right, int top, int bottom);
        void SetBorder(BorderSide side, int value);
        int GetBorder(BorderSide side);
        bool IsSelected();
        void Select();
        void Deselect();
    }
}
