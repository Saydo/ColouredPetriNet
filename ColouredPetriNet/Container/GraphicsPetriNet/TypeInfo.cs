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

        public static GraphicsPetriNet.ItemType GetTypeKindFromString(string kindName)
        {
            if (kindName == GraphicsPetriNet.ItemType.State.ToString())
            {
                return GraphicsPetriNet.ItemType.State;
            }
            else if (kindName == GraphicsPetriNet.ItemType.Transition.ToString())
            {
                return GraphicsPetriNet.ItemType.Transition;
            }
            else if (kindName == GraphicsPetriNet.ItemType.Marker.ToString())
            {
                return GraphicsPetriNet.ItemType.Marker;
            }
            else
            {
                return GraphicsPetriNet.ItemType.Link;
            }
        }

        public static ItemForm GetTypeFormFromString(string formName)
        {
            if (formName == ItemForm.Round.ToString())
            {
                return ItemForm.Round;
            }
            else if (formName == ItemForm.Rectangle.ToString())
            {
                return ItemForm.Rectangle;
            }
            else if (formName == ItemForm.Rhomb.ToString())
            {
                return ItemForm.Rhomb;
            }
            else if (formName == ItemForm.Triangle.ToString())
            {
                return ItemForm.Triangle;
            }
            else
            {
                return ItemForm.Image;
            }
        }
    }
}
