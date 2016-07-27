using System.Drawing;
using ColouredPetriNet.Container.GraphicsPetriNet;
using ColouredPetriNet.Container.GraphicsPetriNet.GraphicsItems;

namespace ColouredPetriNet.Gui.Core
{
    public static class PetriNetTypeConverter
    {
        public static Image GetTypeFormImage(GraphicsPetriNet.ItemType kind, ItemForm form)
        {
            switch (form)
            {
                case ItemForm.Round:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.RoundStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.RoundTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.RoundMarkerIcon;
                    }
                    break;
                case ItemForm.Rectangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.RectangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.RectangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.RectangleMarkerIcon;
                    }
                    break;
                case ItemForm.Rhomb:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.RhombStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.RhombTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.RhombMarkerIcon;
                    }
                    break;
                case ItemForm.Triangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.TriangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.TriangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.TriangleMarkerIcon;
                    }
                    break;
                case ItemForm.Image:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.ImageStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.ImageTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.ImageMarkerIcon;
                    }
                    break;
            }
            return null;
        }

        public static Image GetAddItemImage(GraphicsPetriNet.ItemType kind, ItemForm form)
        {
            switch (form)
            {
                case ItemForm.Round:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddRoundStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddRoundTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddRoundMarkerIcon;
                    }
                    break;
                case ItemForm.Rectangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddRectangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddRectangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddRectangleMarkerIcon;
                    }
                    break;
                case ItemForm.Rhomb:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddRhombStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddRhombTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddRhombMarkerIcon;
                    }
                    break;
                case ItemForm.Triangle:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddTriangleStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddTriangleTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddTriangleMarkerIcon;
                    }
                    break;
                case ItemForm.Image:
                    switch (kind)
                    {
                        case GraphicsPetriNet.ItemType.State:
                            return Properties.Resources.AddImageStateIcon;
                        case GraphicsPetriNet.ItemType.Transition:
                            return Properties.Resources.AddImageTransitionIcon;
                        case GraphicsPetriNet.ItemType.Marker:
                            return Properties.Resources.AddImageMarkerIcon;
                    }
                    break;
            }
            return null;
        }
    }
}
