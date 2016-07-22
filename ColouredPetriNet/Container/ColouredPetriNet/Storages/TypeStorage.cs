using System.Collections.Generic;

namespace ColouredPetriNet.Container.ColouredPetriNet
{
    public partial class ColouredPetriNet
    {
        public Interfaces.ITypeStorage Types;
        public delegate void ForEachTypeFunction(int type);

        private class TypeStorage : Interfaces.ITypeStorage
        {
            private List<int> _types;
            private ColouredPetriNet _parent;

            public TypeStorage(ColouredPetriNet parent)
            {
                _parent = parent;
                _types = new List<int>();
            }

            public int Count
            {
                get { return _types.Count; }
            }

            public bool Contains(int type)
            {
                for (int i = 0; i < _types.Count; ++i)
                {
                    if (_types[i] == type)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool Add(int type)
            {
                if (Contains(type))
                {
                    return false;
                }
                if (_parent._typeGenerator.CurrentId < type)
                {
                    _parent._typeGenerator.Reset(type);
                }
                _types.Add(type);
                return true;
            }

            public int Create()
            {
                _types.Add(_parent._typeGenerator.Next());
                return _parent._typeGenerator.CurrentId;
            }

            public bool Remove(int type)
            {
                int index = GetIndex(type);
                if (index < 0)
                {
                    return false;
                }
                else
                {
                    _parent.States.RemoveType(type);
                    _parent.Markers.RemoveType(type);
                    _parent.Transitions.RemoveType(type);
                    _types.RemoveAt(index);
                    return true;
                }
            }

            public bool RemoveAt(int index)
            {
                if ((index < 0) || (index >= _types.Count))
                {
                    return false;
                }
                _parent.States.RemoveType(_types[index]);
                _parent.Markers.RemoveType(_types[index]);
                _parent.Transitions.RemoveType(_types[index]);
                _types.RemoveAt(index);
                return true;
            }

            public void Clear()
            {
                _types.Clear();
                _parent.States.Clear();
                _parent.Transitions.Clear();
            }

            public void ForEachType(ForEachTypeFunction function)
            {
                for (int i = 0; i < _types.Count; ++i)
                {
                    function(_types[i]);
                }
            }

            #region Helpful Functions
            public int GetIndex(int type)
            {
                for (int i = 0; i < _types.Count; ++i)
                {
                    if (_types[i] == type)
                    {
                        return i;
                    }
                }
                return -1;
            }
            #endregion
        }
    }
}
