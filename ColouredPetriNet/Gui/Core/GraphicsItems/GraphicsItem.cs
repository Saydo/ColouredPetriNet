using System.Drawing;

namespace ColouredPetriNet.Gui.Core.GraphicsItems
{
    public class GraphicsItem : IGraphicsItem
    {
        protected Point _center;
        protected int _z;
        protected int _extent;
        protected int[] _borderPoints;
        protected bool _selected;
        protected Pen _selectionPen;

        public int Id { get; private set; }
        public int TypeId { get; private set; }
        public Point Center
        {
            get { return _center; }
            set {
                if (_center != value)
                {
                    SetPosition(value.X, value.Y);
                }
            }
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

        public GraphicsItem() : this(-1, -1, new Point(0, 0))
        {
        }

        public GraphicsItem(int id, int typeId, int z = 0) : this (id, typeId, new Point(0, 0), z)
        {
        }

        public GraphicsItem(int id, int typeId, Point center, int z = 0)
        {
            Id = id;
            TypeId = typeId;
            _center = center;
            _z = z;
            _extent = 2;
            _selected = false;
            _selectionPen = new Pen(Color.FromArgb(0, 0, 0));
            _borderPoints = new[] { 0, 0, 0, 0 };
        }

        public virtual void Draw(Graphics graphics)
        {
            if (_selected)
            {
                graphics.DrawRectangle(_selectionPen, _center.X - _extent, _center.Y - _extent,
                    2*_extent, 2*_extent);
            }
        }

        public virtual void SetPosition(int x, int y)
        {
            _center.X = x;
            _center.Y = y;
        }

        public virtual void Move(int x, int y)
        {
            _center.X += x;
            _center.Y += y;
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
            if (!IsOverlapBorder(x, y, w, h, overlap))
            {
                return false;
            }
            else
            {
                if (overlap == OverlapType.Full)
                {
                    return true;
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
            if ((x < _center.X + _borderPoints[(int)BorderSide.Left])
                || (x > _center.X + _borderPoints[(int)BorderSide.Right])
                || (y < _center.Y + _borderPoints[(int)BorderSide.Bottom])
                || (y > _center.Y + _borderPoints[(int)BorderSide.Top]))
            {
                return false;
            }
            return true;
        }

        public bool IsOverlapBorder(int x, int y, int w, int h, OverlapType overlap = OverlapType.Partial)
        {
            if (overlap == OverlapType.Partial)
            {
                if ((x + w < _center.X + _borderPoints[(int)BorderSide.Left])
                    || (x > _center.X + _borderPoints[(int)BorderSide.Right])
                    || (y + h < _center.Y + _borderPoints[(int)BorderSide.Bottom])
                    || (y > _center.Y + _borderPoints[(int)BorderSide.Top]))
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
                if ((x <= _center.X + _borderPoints[(int)BorderSide.Left])
                    && (x + w >= _center.X + _borderPoints[(int)BorderSide.Right])
                    && (y <= _center.Y + _borderPoints[(int)BorderSide.Bottom])
                    && (y + h >= _center.Y + _borderPoints[(int)BorderSide.Top]))
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
            _borderPoints[(int)BorderSide.Left] = left;
            _borderPoints[(int)BorderSide.Right] = right;
            _borderPoints[(int)BorderSide.Bottom] = bottom;
            _borderPoints[(int)BorderSide.Top] = top;
        }

        public virtual void SetBorder(BorderSide side, int value)
        {
            _borderPoints[(int)side] = value;
        }

        public int GetBorder(BorderSide side)
        {
            return _borderPoints[(int)side];
        }

        public int[] GetBorder()
        {
            return _borderPoints;
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
