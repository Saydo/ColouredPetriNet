using System.Collections.Generic;
using System.Drawing;
using ColouredPetriNet.Gui.GraphicsItems;

namespace ColouredPetriNet.Gui
{
    public class GraphicsItemMap : IGraphicsItemMap
    {
        private List<GraphicsItem> _items;
        private List<int> _selectedItems;
        private SelectionArea _selectionArea;
        private OverlapType _overlap;

        public OverlapType Overlap
        {
            get { return _overlap; }
            set { _overlap = value; }
        }

        public GraphicsItemMap()
        {
            _items = new List<GraphicsItem>();
            _selectedItems = new List<int>();
            _selectionArea = new SelectionArea();
            _overlap = OverlapType.Partial;
        }

        public bool Contains(int id)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<GraphicsItem> FindItems(int x, int y)
        {
            List<GraphicsItem> foundItems = new List<GraphicsItem>();
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].IsCollision(x, y))
                {
                    foundItems.Add(_items[i]);
                }
            }
            return foundItems;
        }

        public void Select(int id)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].Id == id)
                {
                    if (!_items[i].IsSelected())
                    {
                        _items[i].Select();
                        _selectedItems.Add(id);
                    }
                    break;
                }
            }
        }

        public void Deselect(int id)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].Id == id)
                {
                    if (_items[i].IsSelected())
                    {
                        _items[i].Deselect();
                        RemoveFromSelectedItems(id);
                    }
                    break;
                }
            }
        }

        public void Select(int x, int y)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].IsCollision(x, y))
                {
                    if (!_items[i].IsSelected())
                    {
                        _items[i].Select();
                        _selectedItems.Add(_items[i].Id);
                    }
                }
            }
        }

        public void Deselect(int x, int y)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].IsCollision(x, y))
                {
                    if (_items[i].IsSelected())
                    {
                        _items[i].Deselect();
                        RemoveFromSelectedItems(_items[i].Id);
                    }
                }
            }
        }

        public void Select(int x, int y, int w, int h)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if ((FindIndexSelectedItem(_items[i].Id) < 0) && (_items[i].IsCollision(x, y, w, h, _overlap)))
                {
                    _selectedItems.Add(_items[i].Id);
                    _items[i].Select();
                }
            }
        }

        public void Deselect(int x, int y, int w, int h)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].IsCollision(x, y, w, h, _overlap))
                {
                    RemoveFromSelectedItems(_items[i].Id);
                    _items[i].Deselect();
                }
            }
        }

        public void SelectAllItems()
        {
            _selectedItems.Clear();
            for (int i = 0; i < _items.Count; ++i)
            {
                _items[i].Select();
                _selectedItems.Add(_items[i].Id);
            }
        }

        public void DeselectAllItems()
        {
            _selectedItems.Clear();
            for (int i = 0; i < _items.Count; ++i)
            {
                _items[i].Deselect();
            }
        }

        public void RemoveSelectedItems()
        {
            for (int i = 0; i < _selectedItems.Count; ++i)
            {
                for (int j = _items.Count-1; j >= 0; --j)
                {
                    if (_selectedItems[i] == _items[j].Id)
                    {
                        _items.RemoveAt(j);
                        break;
                    }
                }
            }
            _selectedItems.Clear();
        }

        public void AddItem(GraphicsItem item)
        {
            _items.Add(item);
        }

        public bool RemoveItem(int id)
        {
            bool isFound = false;
            for (int i = 0; i < _items.Count; ++i)
            {
                if (_items[i].Id == id)
                {
                    _items.RemoveAt(i);
                    isFound = true;
                    break;
                }
            }
            return isFound;
        }

        public void Clear()
        {
            _selectedItems.Clear();
            _items.Clear();
        }

        public void SetSelectionArea(int x, int y, int w, int h)
        {
            _selectionArea.X = x;
            _selectionArea.Y = y;
            _selectionArea.Width = w;
            _selectionArea.Height = h;
            _selectionArea.Visible = true;
            _selectionArea.HorizontalDirection = HorizontalDirection.Right;
            _selectionArea.VerticalDirection = VerticalDirection.Top;
            Select(x, y, w, h);
        }

        public void UpdateSelectionAreaByPos(int x, int y)
        {
            int dx = x - _selectionArea.X;
            int dy = y - _selectionArea.Y;
            _selectionArea.Width = System.Math.Abs(dx);
            _selectionArea.Height = System.Math.Abs(dy);
            if (dx < 0)
            {
                _selectionArea.HorizontalDirection = HorizontalDirection.Left;
                if (dy < 0)
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Bottom;
                    Select(x, y, _selectionArea.Width, _selectionArea.Height);
                }
                else
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Top;
                    Select(x, _selectionArea.Y, _selectionArea.Width, _selectionArea.Height);
                }
            }
            else
            {
                _selectionArea.HorizontalDirection = HorizontalDirection.Right;
                if (dy < 0)
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Bottom;
                    Select(_selectionArea.X, y, _selectionArea.Width, _selectionArea.Height);
                }
                else
                {
                    _selectionArea.VerticalDirection = VerticalDirection.Top;
                    Select(_selectionArea.X, _selectionArea.Y, _selectionArea.Width, _selectionArea.Height);
                }
            }
        }

        public void UpdateSelectionArea(int w, int h)
        {
            _selectionArea.Width = w;
            _selectionArea.Height = h;
            Select(_selectionArea.X, _selectionArea.Y, w, h);
        }

        public void HideSelectionArea()
        {
            _selectionArea.Visible = false;
        }

        public void Draw(Graphics graphics)
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                _items[i].Draw(graphics);
            }
            _selectionArea.Draw(graphics);
        }

        private int FindIndexSelectedItem(int id)
        {
            for (int i = 0; i < _selectedItems.Count; ++i)
            {
                if (_selectedItems[i] == id)
                {
                    return i;
                }
            }
            return -1;
        }

        private void RemoveFromSelectedItems(int id)
        {
            for (int i = 0; i < _selectedItems.Count; ++i)
            {
                if (_selectedItems[i] == id)
                {
                    _selectedItems.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
