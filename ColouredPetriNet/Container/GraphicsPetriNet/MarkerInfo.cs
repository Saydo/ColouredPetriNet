namespace ColouredPetriNet.Container.GraphicsPetriNet
{
    public struct MarkerInfo
    {
        public int Id;
        public int StateId;
        public int Type;

        public MarkerInfo(int id, int stateId, int type)
        {
            Id = id;
            StateId = stateId;
            Type = type;
        }
    }
}
