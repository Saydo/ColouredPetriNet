using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ColouredPetriNet.Gui.Forms
{
    public partial class SelectImageForm : Form
    {
        private OpenFileDialog dlgOpenFile;

        public SelectImageForm()
        {
            InitializeComponent();
            lstImages.LargeImageList = new ImageList();
            lstImages.MultiSelect = false;
            dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "Images files (*.png)|*.png";
            dlgOpenFile.Multiselect = false;
        }

        new public void ShowDialog()
        {
            lstImages.LargeImageList.Images.Clear();
            lstImages.Items.Clear();
            LoadFromStorage();
            base.ShowDialog();
        }

        private void LoadFromStorage()
        {
            var imageStorage = Core.PetriNetResources.BackgroundImages;
            Core.ImageInfo imageInfo;
            ListViewItem imageItem;
            for (int i = 0; i < imageStorage.Count(); ++i)
            {
                imageInfo = imageStorage.GetImage(i);
                lstImages.LargeImageList.Images.Add(imageInfo.Name, imageInfo.Image);
                imageItem = new ListViewItem(imageInfo.Name, imageInfo.Name);
                imageItem.Text = "";
                lstImages.Items.Add(imageItem);
            }
        }

        private void Add()
        {
            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
            {
                Image image = Core.ImageStorage.FromFile(dlgOpenFile.FileName);
                string name = Core.PetriNetResources.BackgroundImages.Add(dlgOpenFile.FileName);
                lstImages.LargeImageList.Images.Add(name, image);
                ListViewItem imageItem = new ListViewItem(name, name);
                imageItem.Text = "";
                lstImages.Items.Add(imageItem);
            }
        }

        private void Remove()
        {
            if (lstImages.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select image for removing!");
                return;
            }
            string key = lstImages.SelectedItems[0].ImageKey;
            int index = lstImages.SelectedItems[0].Index;
            int imageIndex = lstImages.SelectedItems[0].ImageIndex;
            lstImages.LargeImageList.Images.RemoveByKey(key);
            lstImages.Items.RemoveAt(index);
            Core.PetriNetResources.BackgroundImages.Remove(key);
        }

        private void Clear()
        {
            lstImages.LargeImageList.Images.Clear();
            lstImages.Items.Clear();
            Core.PetriNetResources.BackgroundImages.Clear();
        }
    }
}
