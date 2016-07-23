using System;
using System.Collections.Generic;
using System.Drawing;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public class StateWrapper
    {
        public int Id;
        public int Type;
        public GraphicsItems.GraphicsItem State;
        public List<LinkWrapper> OutputLinks;
        public List<LinkWrapper> InputLinks;
        public List<Tuple<GraphicsItems.GraphicsItem, List<int>>> Markers;
        private Font textFont;
        private Brush textBrush;

        public StateWrapper(GraphicsItems.GraphicsItem state)
        {
            Id = state.Id;
            Type = state.TypeId;
            textFont = new Font("Arial", 10);
            textBrush = new SolidBrush(Color.FromArgb(0, 0, 0));
            State = state;
            Markers = new List<Tuple<GraphicsItems.GraphicsItem, List<int>>>();
            OutputLinks = new List<LinkWrapper>();
            InputLinks = new List<LinkWrapper>();
        }

        public void Draw(Graphics graphics)
        {
            State.Draw(graphics);
            for (int i = 0; ((i < 3) && (i < Markers.Count)); ++i)
            {
                Markers[i].Item1.Draw(graphics);
                graphics.DrawString(Markers[i].Item2.Count.ToString(), textFont,
                    textBrush, Markers[i].Item1.Center.X, Markers[i].Item1.Center.Y);
            }
        }

        public void AddMarker(int id, GraphicsItems.GraphicsItem marker)
        {
            List<int> newListId;
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == marker.TypeId)
                {
                    newListId = Markers[i].Item2;
                    newListId.Add(id);
                    Markers[i] = new Tuple<GraphicsItems.GraphicsItem, List<int>>(Markers[i].Item1, newListId);
                    return;
                }
            }
            newListId = new List<int>();
            newListId.Add(id);
            Markers.Add(new Tuple<GraphicsItems.GraphicsItem, List<int>>(marker, newListId));
            UpdateMarkerPosition();
        }

        public void AddMarker(GraphicsItems.GraphicsItem marker)
        {
            AddMarker(marker.Id, marker);
        }

        public void AddMarker(GraphicsItems.GraphicsItem marker, List<int> listId)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == marker.TypeId)
                {
                    List<int> newListId = Markers[i].Item2;
                    newListId.AddRange(listId);
                    Markers[i] = new Tuple<GraphicsItems.GraphicsItem, List<int>>(Markers[i].Item1, newListId);
                    return;
                }
            }
            Markers.Add(new Tuple<GraphicsItems.GraphicsItem, List<int>>(marker, listId));
            UpdateMarkerPosition();
        }

        public void ClearMarkers()
        {
            Markers.Clear();
            UpdateMarkerPosition();
        }

        public void RemoveMarkerType(int index)
        {
            Markers.RemoveAt(index);
            UpdateMarkerPosition();
        }

        public void RemoveMarkerAt(int index1, int index2)
        {
            Markers[index1].Item2.RemoveAt(index2);
            UpdateMarkerPosition();
        }

        public bool RemoveMarker(int id)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                for (int j = 0; j < Markers[i].Item2.Count; ++j)
                {
                    if (Markers[i].Item2[j] == id)
                    {
                        Markers[i].Item2.RemoveAt(j);
                        if (Markers[i].Item2.Count == 0)
                        {
                            Markers.RemoveAt(i);
                        }
                        UpdateMarkerPosition();
                        return true;
                    }
                }
            }
            return false;
        }

        public bool RemoveMarker(int id, int typeId)
        {
            for (int i = 0; i < Markers.Count; ++i)
            {
                if (Markers[i].Item1.TypeId == typeId)
                {
                    for (int j = 0; j < Markers[i].Item2.Count; ++j)
                    {
                        if (Markers[i].Item2[j] == id)
                        {
                            Markers[i].Item2.RemoveAt(j);
                            if (Markers[i].Item2.Count == 0)
                            {
                                Markers.RemoveAt(i);
                            }
                            UpdateMarkerPosition();
                            return true;
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        public void RemoveMarkers(int typeId, List<int> listId)
        {
            for (int i = Markers.Count - 1; i >= 0; --i)
            {
                if (Markers[i].Item1.TypeId == typeId)
                {
                    for (int j = 0; j < listId.Count; ++j)
                    {
                        for (int k = 0; k < Markers[i].Item2.Count; ++k)
                        {
                            if (Markers[i].Item2[k] == listId[j])
                            {
                                Markers[i].Item2.RemoveAt(k);
                                if (Markers[i].Item2.Count == 0)
                                {
                                    Markers.RemoveAt(i);
                                }
                                break;
                            }
                        }
                    }
                    UpdateMarkerPosition();
                    return;
                }
            }
        }

        public void RemoveMarkers(int typeId, int count = 1)
        {
            for (int i = Markers.Count - 1; i >= 0; --i)
            {
                if (Markers[i].Item1.TypeId == typeId)
                {
                    if (count > Markers[i].Item2.Count)
                    {
                        count = Markers[i].Item2.Count;
                    }
                    Markers[i].Item2.RemoveRange(Markers[i].Item2.Count - count, count);
                    if (Markers[i].Item2.Count == 0)
                    {
                        Markers.RemoveAt(i);
                    }
                    UpdateMarkerPosition();
                    return;
                }
            }
        }

        public void Move(int dx, int dy)
        {
            State.Move(dx, dy);
            UpdateMarkerPosition();
        }

        private void UpdateMarkerPosition()
        {
            Point p;
            int halfWeight, halfHeight;
            switch (Markers.Count)
            {
                case 0:
                    break;
                case 1:
                    Markers[0].Item1.Center = State.Center;
                    break;
                case 2:
                    p = State.Center;
                    halfWeight = (Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Right) - Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Left)) / 2;
                    halfHeight = (Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Top) - Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2;
                    p.X -= (State.GetBorder(GraphicsItems.BorderSide.Right) - State.GetBorder(GraphicsItems.BorderSide.Left)) / 2 - halfWeight;
                    p.Y += (State.GetBorder(GraphicsItems.BorderSide.Top) - State.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2 - halfHeight;
                    Markers[0].Item1.Center = p;
                    p = State.Center;
                    halfWeight = (Markers[1].Item1.GetBorder(GraphicsItems.BorderSide.Right) - Markers[1].Item1.GetBorder(GraphicsItems.BorderSide.Left)) / 2;
                    halfHeight = (Markers[1].Item1.GetBorder(GraphicsItems.BorderSide.Top) - Markers[1].Item1.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2;
                    p.X += (State.GetBorder(GraphicsItems.BorderSide.Right) - State.GetBorder(GraphicsItems.BorderSide.Left)) / 2 - halfWeight;
                    p.Y -= (State.GetBorder(GraphicsItems.BorderSide.Top) - State.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2 - halfHeight;
                    Markers[1].Item1.Center = p;
                    break;
                default:
                    p = State.Center;
                    halfWeight = (Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Right) - Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Left)) / 2;
                    halfHeight = (Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Top) - Markers[0].Item1.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2;
                    p.X -= (State.GetBorder(GraphicsItems.BorderSide.Right) - State.GetBorder(GraphicsItems.BorderSide.Left)) / 2 - halfWeight;
                    p.Y -= (State.GetBorder(GraphicsItems.BorderSide.Top) - State.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2 - halfHeight;
                    Markers[0].Item1.Center = p;
                    p.X -= halfWeight;
                    halfWeight = (Markers[1].Item1.GetBorder(GraphicsItems.BorderSide.Right) - Markers[1].Item1.GetBorder(GraphicsItems.BorderSide.Left)) / 2;
                    p.X += State.GetBorder(GraphicsItems.BorderSide.Right) - State.GetBorder(GraphicsItems.BorderSide.Left) - halfWeight;
                    Markers[1].Item1.Center = p;
                    p = State.Center;
                    halfHeight = (Markers[2].Item1.GetBorder(GraphicsItems.BorderSide.Top) - Markers[2].Item1.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2;
                    p.Y += (State.GetBorder(GraphicsItems.BorderSide.Top) - State.GetBorder(GraphicsItems.BorderSide.Bottom)) / 2 - halfHeight;
                    Markers[2].Item1.Center = p;
                    break;
            }
        }
    }
}
