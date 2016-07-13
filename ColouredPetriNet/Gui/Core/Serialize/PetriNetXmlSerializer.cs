using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace ColouredPetriNet.Gui.Core.Serialize
{
    public sealed class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding { get { return Encoding.UTF8; } }
    }

    static class PetriNetXmlSerializer
    {
        public static PetriNetStyleXml ToXml(Style.ColouredPetriNetStyle style)
        {
            var styleXml = new PetriNetStyleXml();
            styleXml.SelectionMode.Value = (style.SelectionMode == GraphicsItems.OverlapType.Full ? "Full" : "Partial");
            styleXml.SelectionPen.FromPen(style.SelectionPen);
            ItemStyleXml itemStyle = new RoundItemStyleXml("RoundState", style.RoundState.Radius);
            itemStyle.BorderPen.FromPen(style.RoundState.BorderPen);
            itemStyle.FillBrush.FromBrush((System.Drawing.SolidBrush)style.RoundState.FillBrush);
            styleXml.ItemStyleList.Add(itemStyle);
            itemStyle = new ImageItemStyleXml("ImageState", style.ImageState.ImageName,
                style.ImageState.Width, style.ImageState.Height);
            itemStyle.BorderPen.FromPen(style.ImageState.BorderPen);
            itemStyle.FillBrush.FromBrush((System.Drawing.SolidBrush)style.ImageState.FillBrush);
            styleXml.ItemStyleList.Add(itemStyle);
            itemStyle = new RectangleItemStyleXml("RectangleTransition", style.RectangleTransition.Width,
                style.RectangleTransition.Height);
            itemStyle.BorderPen.FromPen(style.RectangleTransition.BorderPen);
            itemStyle.FillBrush.FromBrush((System.Drawing.SolidBrush)style.RectangleTransition.FillBrush);
            styleXml.ItemStyleList.Add(itemStyle);
            itemStyle = new RectangleItemStyleXml("RhombTransition", style.RhombTransition.Width,
                style.RhombTransition.Height);
            itemStyle.BorderPen.FromPen(style.RhombTransition.BorderPen);
            itemStyle.FillBrush.FromBrush((System.Drawing.SolidBrush)style.RhombTransition.FillBrush);
            styleXml.ItemStyleList.Add(itemStyle);
            itemStyle = new RoundItemStyleXml("RoundMarker", style.RoundMarker.Radius);
            itemStyle.BorderPen.FromPen(style.RoundMarker.BorderPen);
            itemStyle.FillBrush.FromBrush((System.Drawing.SolidBrush)style.RoundMarker.FillBrush);
            styleXml.ItemStyleList.Add(itemStyle);
            itemStyle = new RectangleItemStyleXml("RhombMarker", style.RhombMarker.Width,
                style.RhombMarker.Height);
            itemStyle.BorderPen.FromPen(style.RhombMarker.BorderPen);
            itemStyle.FillBrush.FromBrush((System.Drawing.SolidBrush)style.RhombMarker.FillBrush);
            styleXml.ItemStyleList.Add(itemStyle);
            itemStyle = new TriangleItemStyleXml("TriangleMarker", style.TriangleMarker.Side);
            itemStyle.BorderPen.FromPen(style.TriangleMarker.BorderPen);
            itemStyle.FillBrush.FromBrush((System.Drawing.SolidBrush)style.TriangleMarker.FillBrush);
            styleXml.ItemStyleList.Add(itemStyle);
            return styleXml;
        }

        public static Style.ColouredPetriNetStyle FromXml(PetriNetStyleXml styleXml)
        {
            var style = new Style.ColouredPetriNetStyle();
            style.SelectionMode = (styleXml.SelectionMode.Value.Equals("Full") ? GraphicsItems.OverlapType.Full
                : GraphicsItems.OverlapType.Partial);
            style.SelectionPen = styleXml.SelectionPen.ToPen();
            var roundItemXml = (RoundItemStyleXml)styleXml.ItemStyleList[(int)Style.PetriNetField.RoundState];
            style.RoundState.Radius = roundItemXml.Radius;
            style.RoundState.BorderPen = roundItemXml.BorderPen.ToPen();
            style.RoundState.FillBrush = roundItemXml.FillBrush.ToBrush();
            var imageItemXml = (ImageItemStyleXml)styleXml.ItemStyleList[(int)Style.PetriNetField.ImageState];
            style.ImageState.ImageName = imageItemXml.Image;
            style.ImageState.Width = imageItemXml.Width;
            style.ImageState.Height = imageItemXml.Height;
            style.ImageState.BorderPen = imageItemXml.BorderPen.ToPen();
            style.ImageState.FillBrush = imageItemXml.FillBrush.ToBrush();
            var rectangleItemXml = (RectangleItemStyleXml)styleXml.ItemStyleList[(int)Style.PetriNetField.RectangleTransition];
            style.RectangleTransition.Width = rectangleItemXml.Width;
            style.RectangleTransition.Height = rectangleItemXml.Height;
            style.RectangleTransition.BorderPen = rectangleItemXml.BorderPen.ToPen();
            style.RectangleTransition.FillBrush = rectangleItemXml.FillBrush.ToBrush();
            rectangleItemXml = (RectangleItemStyleXml)styleXml.ItemStyleList[(int)Style.PetriNetField.RhombTransition];
            style.RhombTransition.Width = rectangleItemXml.Width;
            style.RhombTransition.Height = rectangleItemXml.Height;
            style.RhombTransition.BorderPen = rectangleItemXml.BorderPen.ToPen();
            style.RhombTransition.FillBrush = rectangleItemXml.FillBrush.ToBrush();
            roundItemXml = (RoundItemStyleXml)styleXml.ItemStyleList[(int)Style.PetriNetField.RoundMarker];
            style.RoundMarker.Radius = roundItemXml.Radius;
            style.RoundMarker.BorderPen = roundItemXml.BorderPen.ToPen();
            style.RoundMarker.FillBrush = roundItemXml.FillBrush.ToBrush();
            rectangleItemXml = (RectangleItemStyleXml)styleXml.ItemStyleList[(int)Style.PetriNetField.RhombMarker];
            style.RhombMarker.Width = rectangleItemXml.Width;
            style.RhombMarker.Height = rectangleItemXml.Height;
            style.RhombMarker.BorderPen = rectangleItemXml.BorderPen.ToPen();
            style.RhombMarker.FillBrush = rectangleItemXml.FillBrush.ToBrush();
            var triangleItemXml = (TriangleItemStyleXml)styleXml.ItemStyleList[(int)Style.PetriNetField.TriangleMarker];
            style.TriangleMarker.Side = triangleItemXml.Side;
            style.TriangleMarker.BorderPen = triangleItemXml.BorderPen.ToPen();
            style.TriangleMarker.FillBrush = triangleItemXml.FillBrush.ToBrush();
            return style;
        }

        public static bool Serialize(string filename, ColouredPetriNetXml petriNetXml)
        {
            if ((ReferenceEquals(petriNetXml, null)) || (filename.Equals("")))
            {
                return false;
            }
            System.Type[] itemStyleTypes = {
                typeof(RoundItemStyleXml),
                typeof(ImageItemStyleXml),
                typeof(RectangleItemStyleXml),
                typeof(RectangleItemStyleXml),
                typeof(RoundItemStyleXml),
                typeof(RectangleItemStyleXml),
                typeof(TriangleItemStyleXml)
            };
            XmlSerializer serializer = new XmlSerializer(typeof(ColouredPetriNetXml), itemStyleTypes);
            FileStream fileStream = null;
            try
            {
                using (Utf8StringWriter textWriter = new Utf8StringWriter())
                {
                    fileStream = new FileStream(filename, FileMode.Create);
                    serializer.Serialize(fileStream, petriNetXml);
                }
            }
            catch (IOException)
            {
                return false;
            }
            finally
            {
                if (!ReferenceEquals(fileStream, null))
                {
                    fileStream.Close();
                }
            }
            return true;
        }

        public static bool Deserialize(string filename, out ColouredPetriNetXml petriNetXml)
        {
            petriNetXml = null;
            System.Type[] itemStyleTypes = {
                typeof(RoundItemStyleXml),
                typeof(ImageItemStyleXml),
                typeof(RectangleItemStyleXml),
                typeof(RectangleItemStyleXml),
                typeof(RoundItemStyleXml),
                typeof(RectangleItemStyleXml),
                typeof(TriangleItemStyleXml)
            };
            XmlSerializer serializer = new XmlSerializer(typeof(ColouredPetriNetXml), itemStyleTypes);
            FileStream fileStream = null;
            try
            {
                using (Utf8StringWriter textWriter = new Utf8StringWriter())
                {
                    fileStream = new FileStream(filename, FileMode.Open);
                    petriNetXml = (ColouredPetriNetXml)serializer.Deserialize(fileStream);
                }
            }
            catch(IOException)
            {
                return false;
            }
            finally
            {
                fileStream.Close();
            }
            return true;
        }
    }
}
