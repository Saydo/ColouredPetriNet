namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public enum ItemForm { Round, Rectangle, Rhomb, Image, Triangle };

    public struct TypeInfo
    {
        public int Id;
        public string Name;
        public GraphicsPetriNet.ItemType Kind;
        public ItemForm Form;

        public TypeInfo(int id, string name, GraphicsPetriNet.ItemType kind, ItemForm form)
        {
            Id = id;
            Name = name;
            Kind = kind;
            Form = form;
        }
    }
}
