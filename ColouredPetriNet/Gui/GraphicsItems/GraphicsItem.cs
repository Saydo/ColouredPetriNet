using System.Drawing;

namespace ColouredPetriNet.Gui.GraphicsItems
{
    public class GraphicsItem : IGraphicsItem
    {
        protected int _x;
        protected int _y;
        protected int _z;
        protected int _extent;
        protected int[] _borderPoint;
        protected bool _selected;
        protected Pen _selectionPen;

        public int Id { get; private set; }
        public int TypeId { get; private set; }
        public int X
        {
            get { return _x; }
            set { _x = (value < 0 ? 0 : value); }
        }

        public int Y
        {
            get { return _y; }
            set { _y = (value < 0 ? 0 : value); }
        }

        public int Z
        {
            get { return _z; }
            set { _z = (value < 0 ? 0 : value); }
        }

        public int Extent
        {
            get { return _extent; }
            set
            {
                _extent = (value < 0 ? 0 : value);
                UpdateBorder();
            }
        }

        public Pen SelectionPen
        {
            get { return _selectionPen; }
            set
            {
                if (!ReferenceEquals(value, null))
                {
                    _selectionPen = value;
                }
            }
        }

        public GraphicsItem() : this(-1, -1)
        {
        }

        public GraphicsItem(int id, int typeId, int x = 0, int y = 0, int z = 0)
        {
            Id = id;
            TypeId = typeId;
            _x = x;
            _y = y;
            _z = z;
            _extent = 2;
            _selected = false;
            _selectionPen = new Pen(Color.FromArgb(0, 0, 0));
            _borderPoint = new[] { 0, 0, 0, 0 };
        }

        public virtual void Draw(Graphics graphics)
        {
            if (_selected)
            {
                graphics.DrawRectangle(_selectionPen, _x - _extent, _y - _extent, 2*_extent, 2*_extent);
            }
        }

        public bool IsCollision(int x, int y, int z = -1)
        {
            if ((z >= 0) && (_z != z))
            {
                return false;
            }
            return (InBorder(x, y) && InShape(x, y));
        }

        public bool IsCollision(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial, int z = -1)
        {
            if ((z >= 0) && (_z != z))
            {
                return false;
            }
            if ((w == 0) && (h == 0))
            {
                return (InBorder(x, y) && InShape(x, y));
            }
            if (IsOverlapBorder(x, y, w, h, overlap))
            {
                return true;
            }
            else
            {
                if (overlap == OverlapType.Full)
                {
                    return false;
                }
                else
                {
                    return InShape(x, y, w, h, overlap);
                }
            }
        }

        public virtual bool InShape(int x, int y)
        {
            return false;
        }

        public virtual bool InShape(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            return false;
        }

        public bool InBorder(int x, int y)
        {
            int diff_x = x - _x;
            int diff_y = y - _y;
            if ((diff_x < _borderPoint[(int)BorderSide.Left]) || (diff_x > _borderPoint[(int)BorderSide.Right])
                || (diff_y < _borderPoint[(int)BorderSide.Bottom]) || (diff_y > _borderPoint[(int)BorderSide.Top]))
            {
                return false;
            }
            return true;
        }

        public bool IsOverlapBorder(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if ((x + w < _x + _borderPoint[(int)BorderSide.Left]) || (x > _x + _borderPoint[(int)BorderSide.Right])
                    || (y + h < _y + _borderPoint[(int)BorderSide.Bottom]) || (y > _y + _borderPoint[(int)BorderSide.Top]))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if ((x <= _x + _borderPoint[(int)BorderSide.Left]) && (x + w >= _x + _borderPoint[(int)BorderSide.Right])
                   && (y <= _y + _borderPoint[(int)BorderSide.Bottom]) && (y + h >= _y + _borderPoint[(int)BorderSide.Top]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public virtual void SetBorder(int left, int right, int bottom, int top)
        {
            _borderPoint[(int)BorderSide.Left] = left;
            _borderPoint[(int)BorderSide.Right] = right;
            _borderPoint[(int)BorderSide.Bottom] = bottom;
            _borderPoint[(int)BorderSide.Top] = top;
        }

        public virtual void SetBorder(BorderSide side, int value)
        {
            _borderPoint[(int)side] = value;
        }

        public int GetBorder(BorderSide side)
        {
            return _borderPoint[(int)side];
        }

        public int[] GetBorder()
        {
            return _borderPoint;
        }

        public Point GetPos()
        {
            return new Point(_x, _y);
        }

        public bool IsSelected()
        {
            return _selected;
        }

        public void Select()
        {
            _selected = true;
            UpdateBorder();
        }

        public void Deselect()
        {
            _selected = false;
            UpdateBorder();
        }

        protected virtual void UpdateBorder()
        {
            if (_selected)
            {
                SetBorder(-_extent, _extent, _extent, -_extent);
            }
            else
            {
                SetBorder(0, 0, 0, 0);
            }
        }
    }
}
