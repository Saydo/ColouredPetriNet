using System.Collections.Generic;

namespace ColouredPetriNet.Container.Storages
{
    public partial class ColouredPetriNet
    {
        public Interfaces.ITypeStorage Types;
        private IdGenerator _typeGenerator;

        private class TypeStorage : Interfaces.ITypeStorage
        {
            private List<int> _types;
            private IdGenerator _typeGenerator;

            public TypeStorage(IdGenerator typeGenerator)
            {
                _typeGenerator = typeGenerator;
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
                if (_typeGenerator.CurrentId < type)
                {
                    _typeGenerator.Reset(type);
                }
                _types.Add(type);
                return true;
            }

            public int Create()
            {
                _types.Add(_typeGenerator.Next());
                return _typeGenerator.CurrentId;
            }

            public bool Remove(int type)
            {
                //
            }

            public bool RemoveAt(int index)
            {
                if ((index < 0) || (index >= _types.Count))
                {
                    return false;
                }
                _types.RemoveAt(index);
                return true;
            }

            public void Clear()
            {
                _types.Clear();
            }
        }
    }
}
