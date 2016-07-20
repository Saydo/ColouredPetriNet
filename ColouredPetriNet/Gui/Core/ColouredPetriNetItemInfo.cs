using System.Drawing;

namespace ColouredPetriNet.Gui.Core
{
    public static class ColouredPetriNetItemInfo
    {
        public enum ItemType { Link, Marker = 100, Transition = 200, State = 300 };

        public static string GetStateTypeName(int typeId)
        {
            int stateType = typeId - (int)ItemType.State;
            switch (stateType)
            {
                case (int)ColouredStateType.RoundState:
                    return "RoundState";
                case (int)ColouredStateType.ImageState:
                    return "ImageState";
            }
            return "";
        }

        public static string GetTransitionTypeName(int typeId)
        {
            int transitionType = typeId - (int)ItemType.Transition;
            switch (transitionType)
            {
                case (int)ColouredTransitionType.RectangleTransition:
                    return "RectangleTransition";
                case (int)ColouredTransitionType.RhombTransition:
                    return "RhombTransition";
            }
            return "";
        }

        public static string GetMarkerTypeName(int typeId)
        {
            int markerType = typeId - (int)ItemType.Marker;
            switch (markerType)
            {
                case (int)ColouredMarkerType.RoundMarker:
                    return "RoundMarker";
                case (int)ColouredMarkerType.RhombMarker:
                    return "RhombMarker";
                case (int)ColouredMarkerType.TriangleMarker:
                    return "TriangleMarker";
            }
            return "";
        }

        public static void GetStateType(Core.GraphicsItems.GraphicsItem item, out Image image, out string type)
        {
            int typeId = item.TypeId - (int)ItemType.State;
            switch (typeId)
            {
                case (int)Core.ColouredStateType.RoundState:
                    image = new Bitmap(Properties.Resources.RoundStateIcon, 20, 20);
                    type = "RoundState";
                    break;
                case (int)Core.ColouredStateType.ImageState:
                    image = new Bitmap(Properties.Resources.ImageStateIcon, 20, 20);
                    type = "ImageState";
                    break;
                default:
                    image = null;
                    type = "";
                    break;
            }
        }

        public static void GetTransitionType(Core.GraphicsItems.GraphicsItem item, out Image image, out string type)
        {
            int typeId = item.TypeId - (int)ItemType.Transition;
            switch (typeId)
            {
                case (int)Core.ColouredTransitionType.RectangleTransition:
                    image = new Bitmap(Properties.Resources.RectangleTransitionIcon, 20, 20);
                    type = "RectangleTransition";
                    break;
                case (int)Core.ColouredTransitionType.RhombTransition:
                    image = new Bitmap(Properties.Resources.RhombTransitionIcon, 20, 20);
                    type = "RhombTransition";
                    break;
                default:
                    image = null;
                    type = "";
                    break;
            }
        }

        public static void GetMarkerType(Core.GraphicsItems.GraphicsItem item, out Image image, out string type)
        {
            int typeId = item.TypeId - (int)ItemType.Marker;
            switch (typeId)
            {
                case (int)Core.ColouredMarkerType.RoundMarker:
                    image = new Bitmap(Properties.Resources.RoundMarkerIcon, 20, 20);
                    type = "RoundMarker";
                    break;
                case (int)Core.ColouredMarkerType.RhombMarker:
                    image = new Bitmap(Properties.Resources.RhombMarkerIcon, 20, 20);
                    type = "RhombMarker";
                    break;
                case (int)Core.ColouredMarkerType.TriangleMarker:
                    image = new Bitmap(Properties.Resources.TriangleMarkerIcon, 20, 20);
                    type = "TriangleMarker";
                    break;
                default:
                    image = null;
                    type = "";
                    break;
            }
        }
    }
}
