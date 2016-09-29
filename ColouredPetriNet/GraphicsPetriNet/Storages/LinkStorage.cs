using System.Collections.Generic;

namespace ColouredPetriNet.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.ILinkStorage Links;
        private LinkStorage _links;
        public delegate void ForEachLinkFunction(StateWrapper state, TransitionWrapper transition,
            LinkDirection direction);

        private class LinkStorage : Interfaces.ILinkStorage
        {
            public List<LinkWrapper> Links;
            public List<LinkWrapper> SelectedLinks;
            public IdGenerator IdGenerator;
            private GraphicsPetriNet _parent;

            public LinkStorage(GraphicsPetriNet parent)
            {
                _parent = parent;
                Links = new List<LinkWrapper>();
                SelectedLinks = new List<LinkWrapper>();
                IdGenerator = new IdGenerator(-1);
            }

            public int Count { get { return Links.Count; } }
            public int SelectedLinkCount { get { return SelectedLinks.Count; } }

            public LinkWrapper this[int id]
            {
                get
                {
                    for (int i = 0; i < Links.Count; ++i)
                    {
                        if (Links[i].Id == id)
                        {
                            return Links[i];
                        }
                    }
                    return null;
                }
            }

            public GraphicsItems.GraphicsItem GetItem(int id)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].Id == id)
                    {
                        return Links[i].Link;
                    }
                }
                return null;
            }

            public bool Contains(int stateId, int transitionId)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].State.Id == stateId)
                    {
                        if (ContainsTransition(transitionId, Links[i].State.OutputLinks)
                            || ContainsTransition(transitionId, Links[i].State.InputLinks))
                        {
                            return true;
                        }
                        return false;
                    }
                    else if (Links[i].Transition.Id == transitionId)
                    {
                        if (ContainsState(stateId, Links[i].Transition.OutputLinks)
                            || ContainsState(stateId, Links[i].Transition.InputLinks))
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }

            public bool Contains(int stateId, int transitionId, LinkDirection direction)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].State.Id == stateId)
                    {
                        if (direction == LinkDirection.FromStateToTransition)
                        {
                            return ContainsTransition(transitionId, Links[i].State.OutputLinks);
                        }
                        else
                        {
                            return ContainsTransition(transitionId, Links[i].State.InputLinks);
                        }
                    }
                    else if (Links[i].Transition.Id == transitionId)
                    {
                        if (direction == LinkDirection.FromStateToTransition)
                        {
                            return ContainsState(stateId, Links[i].Transition.InputLinks);
                        }
                        else
                        {
                            return ContainsState(stateId, Links[i].Transition.OutputLinks);
                        }
                    }
                }
                return false;
            }

            public int GetCount(int stateId, int transitionId)
            {
                List<LinkWrapper> linkList;
                int counter = 0;
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].State.Id == stateId)
                    {
                        linkList = Links[i].State.OutputLinks;
                        for (int j = 0; j < linkList.Count; ++j)
                        {
                            if (linkList[j].Transition.Id == transitionId)
                            {
                                ++counter;
                                break;
                            }
                        }
                        linkList = Links[i].State.InputLinks;
                        for (int j = 0; j < linkList.Count; ++j)
                        {
                            if (linkList[j].Transition.Id == transitionId)
                            {
                                ++counter;
                                break;
                            }
                        }
                        return counter;
                    }
                    else if (Links[i].Transition.Id == transitionId)
                    {
                        linkList = Links[i].Transition.OutputLinks;
                        for (int j = 0; j < linkList.Count; ++j)
                        {
                            if (linkList[j].State.Id == stateId)
                            {
                                ++counter;
                                break;
                            }
                        }
                        linkList = Links[i].Transition.InputLinks;
                        for (int j = 0; j < linkList.Count; ++j)
                        {
                            if (linkList[j].State.Id == stateId)
                            {
                                ++counter;
                                break;
                            }
                        }
                        return counter;
                    }
                }
                return counter;
            }

            public int GetCountByType(int stateType, int transitionType)
            {
                int counter = 0;
                for (int i = 0; i < Links.Count; ++i)
                {
                    if ((Links[i].State.Type == stateType)
                        && (Links[i].Transition.Type == transitionType))
                    {
                        ++counter;
                    }
                }
                return counter;
            }

            public LinkWrapper Add(int stateId, int transitionId, LinkDirection direction)
            {
                var state = _parent._states[stateId];
                if (ReferenceEquals(state, null))
                {
                    return null;
                }
                var transition = _parent._transitions[transitionId];
                if (ReferenceEquals(state, null))
                {
                    return null;
                }
                if (Contains(stateId, transitionId, direction))
                {
                    return null;
                }
                var linkDirection = (direction == LinkDirection.FromStateToTransition ?
                    GraphicsItems.LinkGraphicsItem.LinkDirection.FromP1toP2
                    : GraphicsItems.LinkGraphicsItem.LinkDirection.FromP2toP1);
                var linkGraphics = new GraphicsItems.LinkGraphicsItem(IdGenerator.Next(),
                    (int)GraphicsPetriNet.ItemType.Link, state.State.Center,
                    transition.Transition.Center, linkDirection, _stateZ);
                var link = new LinkWrapper(state, transition, linkGraphics, direction);
                Links.Add(link);
                if (direction == LinkDirection.FromStateToTransition)
                {
                    state.OutputLinks.Add(link);
                    transition.InputLinks.Add(link);
                }
                else
                {
                    state.InputLinks.Add(link);
                    transition.OutputLinks.Add(link);
                }
                return link;
            }

            public bool Remove(int id)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].Id == id)
                    {
                        PrepareLinkToRemove(Links[i]);
                        Links.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public bool Remove(int stateId, int transitionId)
            {
                int index;
                List<LinkWrapper> linkList;
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].State.Id == stateId)
                    {
                        if ((index = GetTransitionIndex(transitionId, Links[i].State.OutputLinks)) >= 0)
                        {
                            linkList = Links[i].State.OutputLinks;
                            RemoveFromLinkList(Links[i], linkList[index].Transition.InputLinks);
                            linkList.RemoveAt(index);
                            return true;
                        }
                        else if ((index = GetTransitionIndex(transitionId, Links[i].State.InputLinks)) >= 0)
                        {
                            linkList = Links[i].State.InputLinks;
                            RemoveFromLinkList(Links[i], linkList[index].Transition.OutputLinks);
                            linkList.RemoveAt(index);
                            return true;
                        }
                        return false;
                    }
                    else if (Links[i].Transition.Id == transitionId)
                    {
                        if ((index = GetStateIndex(stateId, Links[i].Transition.OutputLinks)) >= 0)
                        {
                            linkList = Links[i].Transition.OutputLinks;
                            RemoveFromLinkList(Links[i], linkList[index].State.InputLinks);
                            linkList.RemoveAt(index);
                            return true;
                        }
                        else if ((index = GetStateIndex(stateId, Links[i].Transition.InputLinks)) >= 0)
                        {
                            linkList = Links[i].Transition.InputLinks;
                            RemoveFromLinkList(Links[i], linkList[index].State.OutputLinks);
                            linkList.RemoveAt(index);
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }

            public bool Remove(int stateId, int transitionId, LinkDirection direction)
            {
                int index;
                List<LinkWrapper> linkList;
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].State.Id == stateId)
                    {
                        if (direction == LinkDirection.FromStateToTransition)
                        {
                            if ((index = GetTransitionIndex(transitionId, Links[i].State.OutputLinks)) >= 0)
                            {
                                linkList = Links[i].State.OutputLinks;
                                RemoveFromLinkList(Links[i], linkList[index].Transition.InputLinks);
                                linkList.RemoveAt(index);
                                return true;
                            }
                            return false;
                        }
                        else
                        {
                            if ((index = GetTransitionIndex(transitionId, Links[i].State.InputLinks)) >= 0)
                            {
                                linkList = Links[i].State.InputLinks;
                                RemoveFromLinkList(Links[i], linkList[index].Transition.OutputLinks);
                                linkList.RemoveAt(index);
                                return true;
                            }
                            return false;
                        }
                    }
                    else if (Links[i].Transition.Id == transitionId)
                    {
                        if (direction == LinkDirection.FromStateToTransition)
                        {
                            if ((index = GetStateIndex(stateId, Links[i].Transition.InputLinks)) >= 0)
                            {
                                linkList = Links[i].Transition.InputLinks;
                                RemoveFromLinkList(Links[i], linkList[index].State.OutputLinks);
                                linkList.RemoveAt(index);
                                return true;
                            }
                            return false;
                        }
                        else
                        {
                            if ((index = GetStateIndex(stateId, Links[i].Transition.OutputLinks)) >= 0)
                            {
                                linkList = Links[i].Transition.OutputLinks;
                                RemoveFromLinkList(Links[i], linkList[index].State.InputLinks);
                                linkList.RemoveAt(index);
                                return true;
                            }
                            return false;
                        }
                    }
                }
                return false;
            }

            public void RemoveSelectedLinks()
            {
                for (int i = SelectedLinks.Count - 1; i >= 0; --i)
                {
                    Remove(SelectedLinks[i].Id);
                }
            }

            public void Clear()
            {
                _parent._states.RemoveAllLinks();
                _parent._transitions.RemoveAllLinks();
                SelectedLinks.Clear();
                Links.Clear();
            }

            public List<LinkWrapper> Find(int x, int y)
            {
                var foundLinks = new List<LinkWrapper>();
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].Link.IsCollision(x, y))
                    {
                        foundLinks.Add(Links[i]);
                    }
                }
                return foundLinks;
            }

            public List<LinkWrapper> Find(int x, int y, LinkDirection direction)
            {
                var foundLinks = new List<LinkWrapper>();
                for (int i = 0; i < Links.Count; ++i)
                {
                    if ((Links[i].Direction == direction) && Links[i].Link.IsCollision(x, y))
                    {
                        foundLinks.Add(Links[i]);
                    }
                }
                return foundLinks;
            }

            public List<LinkWrapper> Find(int x, int y, int w, int h,
                GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
            {
                var foundLinks = new List<LinkWrapper>();
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].Link.IsCollision(x, y, w, h, overlap))
                    {
                        foundLinks.Add(Links[i]);
                    }
                }
                return foundLinks;
            }

            public List<LinkWrapper> Find(int x, int y, int w, int h, LinkDirection direction,
                GraphicsItems.OverlapType overlap = GraphicsItems.OverlapType.Partial)
            {
                var foundLinks = new List<LinkWrapper>();
                for (int i = 0; i < Links.Count; ++i)
                {
                    if ((Links[i].Direction == direction) && Links[i].Link.IsCollision(x, y, w, h, overlap))
                    {
                        foundLinks.Add(Links[i]);
                    }
                }
                return foundLinks;
            }

            public LinkWrapper GetSelectedLink(int index)
            {
                return SelectedLinks[index];
            }

            public LinkWrapper GetSelectedLinkById(int id)
            {
                for (int i = 0; i < SelectedLinks.Count; ++i)
                {
                    if (SelectedLinks[i].Id == id)
                    {
                        return SelectedLinks[i];
                    }
                }
                return null;
            }

            public void ForEachLink(ForEachLinkFunction function)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    function(Links[i].State, Links[i].Transition, Links[i].Direction);
                }
            }

            public void ForEachSelectedLink(ForEachLinkFunction function)
            {
                for (int i = 0; i < SelectedLinks.Count; ++i)
                {
                    function(SelectedLinks[i].State, SelectedLinks[i].Transition, SelectedLinks[i].Direction);
                }
            }

            public void Select()
            {
                SelectedLinks.Clear();
                for (int i = 0; i < Links.Count; ++i)
                {
                    Links[i].Link.Select();
                    SelectedLinks.Add(Links[i]);
                }
            }

            public void SelectArea(int x, int y)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if ((!Links[i].Link.IsSelected()) && Links[i].Link.IsCollision(x, y))
                    {
                        Links[i].Link.Select();
                        SelectedLinks.Add(Links[i]);
                    }
                }
            }

            public void SelectArea(int x, int y, int w, int h, GraphicsItems.OverlapType overlap)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if ((!Links[i].Link.IsSelected())
                        && Links[i].Link.IsCollision(x, y, w, h, overlap))
                    {
                        Links[i].Link.Select();
                        SelectedLinks.Add(Links[i]);
                    }
                }
            }

            public void Select(int stateId, int transitionId)
            {
                var state = _parent._states[stateId];
                if (ReferenceEquals(state, null))
                {
                    return;
                }
                for (int i = 0; i < state.InputLinks.Count; ++i)
                {
                    if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        state.InputLinks[i].Link.Select();
                        SelectedLinks.Add(state.InputLinks[i]);
                        break;
                    }
                }
                for (int i = 0; i < state.OutputLinks.Count; ++i)
                {
                    if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                    {
                        state.OutputLinks[i].Link.Select();
                        SelectedLinks.Add(state.OutputLinks[i]);
                        break;
                    }
                }
            }

            public void Select(int stateId, int transitionId, LinkDirection direction)
            {
                var state = _parent._states[stateId];
                if (ReferenceEquals(state, null))
                {
                    return;
                }
                if (direction == LinkDirection.FromStateToTransition)
                {
                    for (int i = 0; i < state.OutputLinks.Count; ++i)
                    {
                        if (state.OutputLinks[i].Transition.Transition.Id == transitionId)
                        {
                            state.OutputLinks[i].Link.Select();
                            SelectedLinks.Add(state.OutputLinks[i]);
                            return;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < state.InputLinks.Count; ++i)
                    {
                        if (state.InputLinks[i].Transition.Transition.Id == transitionId)
                        {
                            state.InputLinks[i].Link.Select();
                            SelectedLinks.Add(state.InputLinks[i]);
                            return;
                        }
                    }
                }
            }

            public void Deselect()
            {
                SelectedLinks.Clear();
                for (int i = 0; i < Links.Count; ++i)
                {
                    Links[i].Link.Deselect();
                }
            }

            public void DeselectArea(int x, int y)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].Link.IsSelected() && Links[i].Link.IsCollision(x, y))
                    {
                        Links[i].Link.Deselect();
                        SelectedLinks.Remove(Links[i]);
                    }
                }
            }

            public void DeselectArea(int x, int y, int w, int h, GraphicsItems.OverlapType overlap)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].Link.IsSelected()
                        && Links[i].Link.IsCollision(x, y, w, h, overlap))
                    {
                        Links[i].Link.Deselect();
                        SelectedLinks.Remove(Links[i]);
                    }
                }
            }

            public void Deselect(int stateId, int transitionId)
            {
                int counter = 0;
                for (int i = SelectedLinks.Count - 1; ((i >= 0) && (counter < 2)); --i)
                {
                    if ((SelectedLinks[i].State.Id == stateId)
                        && (SelectedLinks[i].Transition.Id == transitionId))
                    {
                        SelectedLinks[i].Link.Deselect();
                        SelectedLinks.RemoveAt(i);
                        ++counter;
                    }
                }
            }

            public void Deselect(int stateId, int transitionId, LinkDirection direction)
            {
                for (int i = 0; i < SelectedLinks.Count; ++i)
                {
                    if ((SelectedLinks[i].State.Id == stateId)
                        && (SelectedLinks[i].Transition.Id == transitionId)
                        && (SelectedLinks[i].Direction == direction))
                    {
                        SelectedLinks[i].Link.Deselect();
                        SelectedLinks.RemoveAt(i);
                        return;
                    }
                }
            }

            public void Move(int dx, int dy)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    MoveLink(dx, dy, Links[i]);
                }
            }

            public bool Move(int dx, int dy, int id)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i].Id == id)
                    {
                        MoveLink(dx, dy, Links[i]);
                        return true;
                    }
                }
                return false;
            }

            #region Helpful Functions
            public bool ContainsState(int id, List<LinkWrapper> list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].State.Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool ContainsTransition(int id, List<LinkWrapper> list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].Transition.Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }

            public int GetStateIndex(int id, List<LinkWrapper> list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].State.Id == id)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public int GetTransitionIndex(int id, List<LinkWrapper> list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i].Transition.Id == id)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public int GetSelectedLinkIndex(LinkWrapper link)
            {
                for (int i = 0; i < SelectedLinks.Count; ++i)
                {
                    if (SelectedLinks[i] == link)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public bool RemoveFromLinkList(LinkWrapper link, List<LinkWrapper> list)
            {
                for (int i = 0; i < list.Count; ++i)
                {
                    if (list[i] == link)
                    {
                        list.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public bool RemoveLink(LinkWrapper link)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    if (Links[i] == link)
                    {
                        PrepareLinkToRemove(link);
                        Links.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public void PrepareLinkToRemove(LinkWrapper link)
            {
                if (link.Direction == LinkDirection.FromStateToTransition)
                {
                    RemoveFromLinkList(link, link.State.OutputLinks);
                    RemoveFromLinkList(link, link.Transition.InputLinks);
                }
                else
                {
                    RemoveFromLinkList(link, link.State.InputLinks);
                    RemoveFromLinkList(link, link.Transition.OutputLinks);
                }
                int index = GetSelectedLinkIndex(link);
                if (index >= 0)
                {
                    SelectedLinks.RemoveAt(index);
                }
            }

            public void Draw(System.Drawing.Graphics graphics)
            {
                for (int i = 0; i < Links.Count; ++i)
                {
                    Links[i].Link.Draw(graphics);
                }
            }

            public void UpdateMovedItems(List<StateWrapper> movedStates, List<TransitionWrapper> movedTransitions)
            {
                for (int i = 0; i < SelectedLinks.Count; ++i)
                {
                    if (!movedStates.Contains(SelectedLinks[i].State))
                    {
                        movedStates.Add(SelectedLinks[i].State);
                    }
                    if (!movedTransitions.Contains(SelectedLinks[i].Transition))
                    {
                        movedTransitions.Add(SelectedLinks[i].Transition);
                    }
                }
            }
            #endregion
        }
    }
}
