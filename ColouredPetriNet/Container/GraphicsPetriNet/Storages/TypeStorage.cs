using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public partial class GraphicsPetriNet
    {
        public Interfaces.ITypeStorage Types;
        private TypeStorage _types;
        public delegate void ForEachTypeFunction(TypeInfo type);

        private class TypeStorage : Interfaces.ITypeStorage
        {
            public List<TypeInfo> Types;
            private GraphicsPetriNet _parent;

            public TypeStorage(GraphicsPetriNet parent)
            {
                _parent = parent;
                Types = new List<TypeInfo>();
            }

            public int Count
            {
                get { return Types.Count; }
            }

            public TypeInfo this[int index]
            {
                get { return Types[index]; }
            }

            public bool Add(string name, GraphicsPetriNet.ItemType kind, ItemForm form)
            {
                if (Contains(name))
                {
                    return false;
                }
                Types.Add(new TypeInfo(_parent._typeGenerator.Next(), name, kind, form));
                return true;
            }

            public bool Add(TypeInfo type)
            {
                if ((type.Id < 0) || Contains(type.Id) || Contains(type.Name))
                {
                    return false;
                }
                if (_parent._typeGenerator.CurrentId < type.Id)
                {
                    _parent._typeGenerator.Reset(type.Id);
                }
                Types.Add(type);
                return true;
            }

            public void Remove(int index)
            {
                Types.RemoveAt(index);
            }

            public bool RemoveAt(int index)
            {
                if ((index < 0) || (index >= Types.Count))
                {
                    return false;
                }
                Types.RemoveAt(index);
                return true;
            }

            public bool RemoveById(int id)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Id == id)
                    {
                        Types.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public bool RemoveByName(string name)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Name == name)
                    {
                        Types.RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public void Clear()
            {
                Types.Clear();
            }

            public bool Contains(int id)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Id == id)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool Contains(string typeName)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Name == typeName)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool Contains(GraphicsPetriNet.ItemType typeKind)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Kind == typeKind)
                    {
                        return true;
                    }
                }
                return false;
            }

            public bool Contains(ItemForm typeForm)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Form == typeForm)
                    {
                        return true;
                    }
                }
                return false;
            }

            public TypeInfo FindType(int id)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Id == id)
                    {
                        return Types[i];
                    }
                }
                return new TypeInfo(-1, "", GraphicsPetriNet.ItemType.State, ItemForm.Round);
            }

            public TypeInfo FindType(string name)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Name == name)
                    {
                        return Types[i];
                    }
                }
                return new TypeInfo(-1, "", GraphicsPetriNet.ItemType.State, ItemForm.Round);
            }

            public List<TypeInfo> FindTypes(ItemForm form)
            {
                var typeList = new List<TypeInfo>();
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Form == form)
                    {
                        typeList.Add(Types[i]);
                    }
                }
                return typeList;
            }

            public List<TypeInfo> FindTypes(GraphicsPetriNet.ItemType kind)
            {
                var typeList = new List<TypeInfo>();
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Kind == kind)
                    {
                        typeList.Add(Types[i]);
                    }
                }
                return typeList;
            }

            public void ForEachType(ForEachTypeFunction function)
            {
                for (int i = 0; i < Types.Count; ++i)
                {
                    function(Types[i]);
                }
            }

            public bool ChangeType(int id, string name, GraphicsPetriNet.ItemType kind, ItemForm form)
            {
                TypeInfo type = FindType(id);
                if ((type.Name != name) && this.Contains(name))
                {
                    return false;
                }
                for (int i = 0; i < Types.Count; ++i)
                {
                    if (Types[i].Id == id)
                    {
                        Types[i] = new TypeInfo(id, name, kind, form);
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
