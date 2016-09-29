namespace ColouredPetriNet.GraphicsPetriNet.Rules
{
    public struct OneTypeMarkerInfo
    {
        public const int All = -1;

        public int MarkerType { get; private set; }
        public int Count { get; private set; }

        public OneTypeMarkerInfo(int type, int count)
        {
            MarkerType = type;
            Count = count;
        }
    }
}
