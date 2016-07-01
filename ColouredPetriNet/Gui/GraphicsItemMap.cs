using System.Collections.Generic;
using System.Drawing;

namespace ColorPetriNetGui
{
    public interface IGraphicsItemMap
    {
        bool contains(int id);
        List<GraphicsItem> findItems(int x, int y);
        void select(int x, int y);
        void deselect(int x, int y);
        void select(int x, int y, int w, int h);
        void deselect(int x, int y, int w, int h);
        void selectAllItems();
        void deselectAllItems();
        void removeSelectedItems();
        void addItem(GraphicsItem item);
        bool removeItem(int id);
        void clear();
        void setSelectionArea(int x, int y, int w, int h);
        void updateSelectionArea(int w, int h);
        void updateSelectionAreaByPos(int x, int y);
        void hideSelectionArea();
        OverlapType overlap
        {
            get;
            set;
        }
        void draw(Graphics graphics);
    }

    public class GraphicsItemMap : IGraphicsItemMap
    {
        public GraphicsItemMap()
        {
            m_items = new List<GraphicsItem>();
            m_selectedItems = new List<int>();
            m_selectionArea = new SelectionArea();
            m_overlap = OverlapType.Partial;
        }

        public bool contains(int id)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public List<GraphicsItem> findItems(int x, int y)
        {
            List<GraphicsItem> found_items = new List<GraphicsItem>();
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].isCollision(x, y))
                {
                    found_items.Add(m_items[i]);
                }
            }
            return found_items;
        }

        public void select(int id)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].id == id)
                {
                    if (!m_items[i].isSelected())
                    {
                        m_items[i].select();
                        m_selectedItems.Add(id);
                    }
                    break;
                }
            }
        }

        public void deselect(int id)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].id == id)
                {
                    if (m_items[i].isSelected())
                    {
                        m_items[i].deselect();
                        removeFromSelectedItems(id);
                    }
                    break;
                }
            }
        }

        public void select(int x, int y)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].isCollision(x, y))
                {
                    if (!m_items[i].isSelected())
                    {
                        m_items[i].select();
                        m_selectedItems.Add(m_items[i].id);
                    }
                }
            }
        }

        public void deselect(int x, int y)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].isCollision(x, y))
                {
                    if (m_items[i].isSelected())
                    {
                        m_items[i].deselect();
                        removeFromSelectedItems(m_items[i].id);
                    }
                }
            }
        }

        public void select(int x, int y, int w, int h)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                if ((findIndexSelectedItem(m_items[i].id) < 0) && (m_items[i].isCollision(x, y, w, h, overlap)))
                {
                    m_selectedItems.Add(m_items[i].id);
                    m_items[i].select();
                }
            }
        }

        public void deselect(int x, int y, int w, int h)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].isCollision(x, y, w, h, overlap))
                {
                    removeFromSelectedItems(m_items[i].id);
                    m_items[i].deselect();
                }
            }
        }

        public void selectAllItems()
        {
            m_selectedItems.Clear();
            for (int i = 0; i < m_items.Count; ++i)
            {
                m_items[i].select();
                m_selectedItems.Add(m_items[i].id);
            }
        }

        public void deselectAllItems()
        {
            m_selectedItems.Clear();
            for (int i = 0; i < m_items.Count; ++i)
            {
                m_items[i].deselect();
            }
        }

        public void removeSelectedItems()
        {
            for (int i = 0; i < m_selectedItems.Count; ++i)
            {
                for (int j = m_items.Count-1; j >= 0; --j)
                {
                    if (m_selectedItems[i] == m_items[j].id)
                    {
                        m_items.RemoveAt(j);
                        break;
                    }
                }
            }
            m_selectedItems.Clear();
        }

        public void addItem(GraphicsItem item)
        {
            m_items.Add(item);
        }

        public bool removeItem(int id)
        {
            bool is_found = false;
            for (int i = 0; i < m_items.Count; ++i)
            {
                if (m_items[i].id == id)
                {
                    m_items.RemoveAt(i);
                    is_found = true;
                    break;
                }
            }
            return is_found;
        }

        public void clear()
        {
            m_selectedItems.Clear();
            m_items.Clear();
        }

        public void setSelectionArea(int x, int y, int w, int h)
        {
            m_selectionArea.x = x;
            m_selectionArea.y = y;
            m_selectionArea.width = w;
            m_selectionArea.height = h;
            m_selectionArea.visible = true;
            m_selectionArea.horizontalDirection = SelectionArea.HorizontalDirection.Right;
            m_selectionArea.verticalDirection = SelectionArea.VerticalDirection.Top;
            select(x, y, w, h);
        }

        public void updateSelectionAreaByPos(int x, int y)
        {
            int diff_x = x - m_selectionArea.x;
            int diff_y = y - m_selectionArea.y;
            m_selectionArea.width = System.Math.Abs(diff_x);
            m_selectionArea.height = System.Math.Abs(diff_y);
            if (diff_x < 0)
            {
                m_selectionArea.horizontalDirection = SelectionArea.HorizontalDirection.Left;
                if (diff_y < 0)
                {
                    m_selectionArea.verticalDirection = SelectionArea.VerticalDirection.Bottom;
                    select(x, y, m_selectionArea.width, m_selectionArea.height);
                }
                else
                {
                    m_selectionArea.verticalDirection = SelectionArea.VerticalDirection.Top;
                    select(x, m_selectionArea.y, m_selectionArea.width, m_selectionArea.height);
                }
            }
            else
            {
                m_selectionArea.horizontalDirection = SelectionArea.HorizontalDirection.Right;
                if (diff_y < 0)
                {
                    m_selectionArea.verticalDirection = SelectionArea.VerticalDirection.Bottom;
                    select(m_selectionArea.x, y, m_selectionArea.width, m_selectionArea.height);
                }
                else
                {
                    m_selectionArea.verticalDirection = SelectionArea.VerticalDirection.Top;
                    select(m_selectionArea.x, m_selectionArea.y, m_selectionArea.width, m_selectionArea.height);
                }
            }
        }

        public void updateSelectionArea(int w, int h)
        {
            m_selectionArea.width = w;
            m_selectionArea.height = h;
            select(m_selectionArea.x, m_selectionArea.y, w, h);
        }

        public void hideSelectionArea()
        {
            m_selectionArea.visible = false;
        }

        public OverlapType overlap
        {
            get { return m_overlap; }
            set { m_overlap = value; }
        }

        public void draw(Graphics graphics)
        {
            for (int i = 0; i < m_items.Count; ++i)
            {
                m_items[i].draw(graphics);
            }
            m_selectionArea.draw(graphics);
        }

        private int findIndexSelectedItem(int id)
        {
            for (int i = 0; i < m_selectedItems.Count; ++i)
            {
                if (m_selectedItems[i] == id)
                {
                    return i;
                }
            }
            return -1;
        }

        private void removeFromSelectedItems(int id)
        {
            for (int i = 0; i < m_selectedItems.Count; ++i)
            {
                if (m_selectedItems[i] == id)
                {
                    m_selectedItems.RemoveAt(i);
                    break;
                }
            }
        }

        private List<GraphicsItem> m_items;
        private List<int> m_selectedItems;
        private SelectionArea m_selectionArea;
        private OverlapType m_overlap;
    }
}
