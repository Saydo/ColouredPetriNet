using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

namespace ColouredPetriNet.Gui.Core
{
    public class ImageStorage
    {
        private List<ImageInfo> _images;
        private string _storageDirectory;

        public string StorageDirectory { get { return _storageDirectory; } }

        public ImageStorage(string storageDirectory)
        {
            _storageDirectory = storageDirectory;
            _images = new List<ImageInfo>();
            LoadFromDirectory(storageDirectory);
        }

        public static Image FromFile(string path)
        {
            var bytes = File.ReadAllBytes(path);
            var ms = new MemoryStream(bytes);
            var img = Image.FromStream(ms);
            return img;
        }

        public bool Contains(string name)
        {
            for (int i = 0; i < _images.Count; ++i)
            {
                if (_images[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public string GenerateImageName(string name)
        {
            if (Contains(name))
            {
                string[] result = Regex.Split(name, @"^*(\(\d+\))?$");
                if (result.Length == 2)
                {
                    return result[0] + "(1)";
                }
                else
                {
                    string strNumber = Regex.Split(result[1], @"\(|\)")[1];
                    int newNumber = int.Parse(strNumber) + 1;
                    return result[0] + newNumber.ToString();
                }
            }
            return name;
        }

        public void LoadFromDirectory(string directory)
        {
            string[] files = Directory.GetFiles(directory);
            string[] filePath;
            string fileName;
            foreach (string file in files)
            {
                if (Regex.IsMatch(file, @".*\.png"))
                {
                    filePath = Regex.Split(file, @"\\|/|\.png$");
                    fileName = filePath[filePath.Length - 2];
                    _images.Add(new ImageInfo(fileName + ".png", GenerateImageName(fileName), FromFile(file)));
                }
            }
        }

        public int Count()
        {
            return _images.Count;
        }

        public ImageInfo GetImage(int index)
        {
            return _images[index];
        }

        public ImageInfo GetImage(string name)
        {
            int index = GetIndex(name);
            if (index >= 0)
            {
                return _images[index];
            }
            return new ImageInfo("", "", null);
        }

        public string Add(string file, string name)
        {
            if (Regex.IsMatch(file, @".*\.png"))
            {
                string[] filePath = Regex.Split(file, @"\\|/|\.png$");
                string fileName = filePath[filePath.Length - 2];
                string imageName = GenerateImageName(name);
                File.Copy(file, _storageDirectory + imageName + ".png", true);
                _images.Add(new ImageInfo(fileName + ".png", imageName, FromFile(file)));
                return imageName;
            }
            return null;
        }

        public string Add(string file)
        {
            if (Regex.IsMatch(file, @".*\.png"))
            {
                string[] filePath = Regex.Split(file, @"\\|/|\.png$");
                string fileName = filePath[filePath.Length - 2];
                string imageName = GenerateImageName(fileName);
                File.Copy(file, _storageDirectory + imageName + ".png", true);
                _images.Add(new ImageInfo(fileName + ".png", imageName, FromFile(file)));
                return imageName;
            }
            return null;
        }

        public void Remove(string name)
        {
            int index = GetIndex(name);
            if (index >= 0)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            string filePath = _storageDirectory + _images[index].FileName;
            if (File.Exists(filePath))
            {
                try
                {
                    File.Delete(filePath);
                }
                catch (IOException e)
                {
                    System.Console.WriteLine("Can't Remove Image from File: {0}", e.Message);
                    return;
                }
                finally
                {
                    _images.RemoveAt(index);
                }
            }
            else
            {
                _images.RemoveAt(index);
            }
        }

        public void Clear()
        {
            for (int i = _images.Count - 1; i >= 0; --i)
            {
                RemoveAt(i);
            }
        }

        private int GetIndex(string name)
        {
            for (int i = 0; i < _images.Count; ++i)
            {
                if (_images[i].Name == name)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
