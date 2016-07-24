﻿namespace ColouredPetriNet.Container.GraphicsPetriNet
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

    public struct OneTypeMarkers
    {
        public int Type;
        public int Count;

        public OneTypeMarkers(int type, int count)
        {
            Type = type;
            Count = count;
        }
    }
}
