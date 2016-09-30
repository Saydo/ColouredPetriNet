using System.Drawing;

namespace ColouredPetriNet.Gui.Core
{
    public struct ImageInfo
    {
        public string FileName;
        public string Name;
        public Image Image;

        public ImageInfo(string filename, string name)
        {
            FileName = filename;
            Name = name;
            Image = Image.FromFile(filename);
        }

        public ImageInfo(string filename, string name, Image image)
        {
            FileName = filename;
            Name = name;
            Image = image;
        }
    }
}
