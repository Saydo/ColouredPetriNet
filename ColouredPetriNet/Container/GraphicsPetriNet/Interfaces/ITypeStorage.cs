using System.Collections.Generic;

namespace ColouredPetriNet.Container.GraphicsPetriNet.Interfaces
{
    public interface ITypeStorage
    {
        TypeInfo this[int index] { get; }
        int Count { get; }
        bool Add(string name, GraphicsPetriNet.ItemType kind, ItemForm form);
        bool Add(TypeInfo type);
        void Remove(int index);
        bool RemoveAt(int index);
        bool RemoveById(int id);
        bool RemoveByName(string name);
        void Clear();
        bool Contains(int id);
        bool Contains(string typeName);
        bool Contains(GraphicsPetriNet.ItemType typeKind);
        bool Contains(ItemForm typeForm);
        TypeInfo FindType(int id);
        TypeInfo FindType(string name);
        List<TypeInfo> FindTypes(ItemForm form);
        List<TypeInfo> FindTypes(GraphicsPetriNet.ItemType kind);
        void ForEachType(GraphicsPetriNet.ForEachTypeFunction function);
        bool ChangeType(int id, string name, GraphicsPetriNet.ItemType kind, ItemForm form);
    }
}
