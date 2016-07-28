using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Drawing;

namespace ColouredPetriNet.Gui.Core
{
    internal class ResourceStorage
    {
        private ResourceManager _resourceManeger;
        private IResourceWriter _resourceWriter;
        private string _resourceFile;

        public string ResourceFile { get { return _resourceFile; } }

        public ResourceStorage(string resourceFile)
        {
            _resourceFile = resourceFile;
            _resourceManeger = new ResourceManager("ColouredPetriNet.Properties.Resources", typeof(ResourceStorage).Assembly);
            //_resourceWriter = new ResourceWriter(resourceFile);
        }

        public bool AddIcon(string name, string path)
        {
            Icon icon = new Icon(path);
            if (icon == null)
            {
                return false;
            }
            AddObject(name, icon);
            return true;
        }

        public bool AddImage(string name, string path)
        {
            var image = Image.FromFile(path);
            if (image == null)
            {
                return false;
            }
            AddObject(name, image);
            return true;
        }

        public object GetResource(string name)
        {
            return _resourceManeger.GetObject(name);
        }

        public Image GetImage(string name)
        {
            return (Image)_resourceManeger.GetObject(name);
        }

        public Icon GetIcon(string name)
        {
            return (Icon)_resourceManeger.GetObject(name);
        }

        private void AddObject(string name, object obj)
        {
            var resx = new List<DictionaryEntry>();
            using (var reader = new ResXResourceReader(_resourceFile))
            {
                resx = reader.Cast<DictionaryEntry>().ToList();
                resx.Add(new DictionaryEntry() { Key = name, Value = obj });
                reader.Close();
            }
            using (var writer = new ResXResourceWriter(_resourceFile))
            {
                resx.ForEach(r => writer.AddResource(r.Key.ToString(), r.Value.ToString()));
                writer.Generate();
            }
        }
    }
}
