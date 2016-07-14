using System;
using System.Windows.Forms;

namespace ColouredPetriNet
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            /*
            string appDir = System.AppDomain.CurrentDomain.BaseDirectory;
            string projectDir = appDir.Substring(0, appDir.Length - "/bin/Debug".Length);
            Console.WriteLine("Dir:{0}", projectDir + "Resources");
            */
            /*
            var petriNetXml = new Gui.Core.Serialize.ColouredPetriNetXml();
            // style
            petriNetXml.Style.ItemStyleList.Add(new Gui.Core.Serialize.RoundItemStyleXml("RoundState", 5));
            petriNetXml.Style.ItemStyleList.Add(new Gui.Core.Serialize.ImageItemStyleXml("ImageState", "image.png", 10, 10));
            petriNetXml.Style.ItemStyleList.Add(new Gui.Core.Serialize.RectangleItemStyleXml("RectangleTransition", 10, 10));
            petriNetXml.Style.ItemStyleList.Add(new Gui.Core.Serialize.RectangleItemStyleXml("RhombTransition", 10, 10));
            petriNetXml.Style.ItemStyleList.Add(new Gui.Core.Serialize.RoundItemStyleXml("RoundMarker", 5));
            petriNetXml.Style.ItemStyleList.Add(new Gui.Core.Serialize.RectangleItemStyleXml("RhombMarker", 10, 10));
            petriNetXml.Style.ItemStyleList.Add(new Gui.Core.Serialize.TriangleItemStyleXml("TriangleMarker", 10));
            // items
            var state = new Gui.Core.Serialize.StateXml(1, 10, 30, "RoundState");
            state.Markers.Add(new Gui.Core.Serialize.MarkerXml(3, "RoundMarker"));
            state.Markers.Add(new Gui.Core.Serialize.MarkerXml(4, "RhombMarker"));
            state.Markers.Add(new Gui.Core.Serialize.MarkerXml(5, "RoundMarker"));
            petriNetXml.Items.StateList.Add(state);
            state = new Gui.Core.Serialize.StateXml(2, 100, 200, "ImageState");
            state.Markers.Add(new Gui.Core.Serialize.MarkerXml(6, "TriangleMarker"));
            state.Markers.Add(new Gui.Core.Serialize.MarkerXml(7, "RhombMarker"));
            petriNetXml.Items.StateList.Add(state);
            petriNetXml.Items.TransitionList.Add(new Gui.Core.Serialize.TransitionXml(8, 10, 20,
                "RectangleTransition"));
            petriNetXml.Items.TransitionList.Add(new Gui.Core.Serialize.TransitionXml(9, 50, 70,
                "RhombTransition"));
            petriNetXml.Items.LinkList.Add(new Gui.Core.Serialize.LinkXml(1, 1, 8));
            petriNetXml.Items.LinkList.Add(new Gui.Core.Serialize.LinkXml(2, 2, 9));
            */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Gui.Forms.MainForm());
        }
    }
}