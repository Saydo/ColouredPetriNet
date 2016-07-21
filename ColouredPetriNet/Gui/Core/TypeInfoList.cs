using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColouredPetriNet.Gui.Core
{
    public enum ItemForm { Round, Rectangle, Rhomb, Image, Triangle };
    public enum ItemKind { State, Transition, Marker };

    public struct TypeInfo
    {
        public int Id;
        public string Name;
        public ItemKind Kind;
        public ItemForm Form;

        public TypeInfo(int id, string name, ItemKind kind, ItemForm form)
        {
            Id = id;
            Name = name;
            Kind = kind;
            Form = form;
        }
    }

    public class TypeInfoList
    {
        private Container.IdGenerator _idGenerator;
        private List<TypeInfo> _types;

        public TypeInfoList()
        {
            _idGenerator = new Container.IdGenerator(-1);
            _types = new List<TypeInfo>();
        }

        public bool Add(string name, ItemKind kind, ItemForm form)
        {
            if (Contains(name))
            {
                return false;
            }
            _types.Add(new TypeInfo(_idGenerator.Next(), name, kind, form));
            return true;
        }

        public bool Add(TypeInfo type)
        {
            if ((type.Id < 0) || Contains(type.Id) || Contains(type.Name))
            {
                return false;
            }
            if (_idGenerator.CurrentId < type.Id)
            {
                _idGenerator.Reset(type.Id);
            }
            _types.Add(type);
            return true;
        }

        public void Remove(int index)
        {
            _types.RemoveAt(index);
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

        public bool RemoveById(int id)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Id == id)
                {
                    _types.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public bool RemoveByName(string name)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Name == name)
                {
                    _types.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            _types.Clear();
        }

        public TypeInfo GetType(int index)
        {
            return _types[index];
        }

        public int Count()
        {
            return _types.Count;
        }

        public bool Contains(int id)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(string typeName)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Name == typeName)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(ItemKind typeKind)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Kind == typeKind)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Contains(ItemForm typeForm)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Form == typeForm)
                {
                    return true;
                }
            }
            return false;
        }

        public TypeInfo FindType(int id)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Id == id)
                {
                    return _types[i];
                }
            }
            return new TypeInfo(-1, "", ItemKind.State, ItemForm.Round);
        }

        public TypeInfo FindType(string name)
        {
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Name == name)
                {
                    return _types[i];
                }
            }
            return new TypeInfo(-1, "", ItemKind.State, ItemForm.Round);
        }

        public List<TypeInfo> FindTypes(ItemForm form)
        {
            var typeList = new List<TypeInfo>();
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Form == form)
                {
                    typeList.Add(_types[i]);
                }
            }
            return typeList;
        }

        public List<TypeInfo> FindTypes(ItemKind kind)
        {
            var typeList = new List<TypeInfo>();
            for (int i = 0; i < _types.Count; ++i)
            {
                if (_types[i].Kind == kind)
                {
                    typeList.Add(_types[i]);
                }
            }
            return typeList;
        }
    }
}
