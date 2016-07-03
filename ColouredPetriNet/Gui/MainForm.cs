using System.Windows.Forms;
using System.Drawing;

namespace ColouredPetriNet.Gui
{
    public partial class MainForm : Form
    {
        private string[] animals;
        private ComboBox comboBox1;

        public MainForm()
        {
            InitializeComponent();
            //((ToolStripDropDownMenu)this.silAddState.DropDown).
            ToolStripMenuItem item = new ToolStripMenuItem("");
            item.Image = Image.FromFile("D:/CSharpProjects/PetriNetExample/PetriNetExample/PetriNetIcon.png");
            item.ToolTipText = "Round State";
            item.Width = 30;
            item.Paint += myToolStripMenuItem1_Paint;
            silAddState.Image = item.Image;
            silAddState.ToolTipText = "Add State";
            silAddState.DropDownItemClicked += changeGridSizeDropDownButton_DropDownItemClicked;
            ToolStripDropDownMenu ddm = (ToolStripDropDownMenu)silAddState.DropDown;
            ddm.ShowImageMargin = false;
            ddm.ShowCheckMargin = false;
            //ddm.Renderer = new CustomRenderer();
            //ddm.Items.Add(new ToolStripMenuItem("Clear all", myImage) { Tag = myImage });
            //ddm.Items.Add(new ToolStripMenuItem("Remove all", myImage) { Tag = myImage });
            //ddm.Renderer = new CustomRenderer();
            //
            silAddState.DropDown.Items.Add(item);
            item = new ToolStripMenuItem("");
            item.Width = 30;
            item.ToolTipText = "Square State";
            item.Image = Image.FromFile("D:/CSharpProjects/PetriNetExample/PetriNetExample/image.png");
            item.Paint += myToolStripMenuItem1_Paint;
            silAddState.DropDown.Items.Add(item);
            //this.silAddState.DropDown.Items.Add("item1");
            //this.silAddState.DropDown.Items.Add("item2");
            //this.silAddState.DropDown.Items.Add("item3");
            //ToolStripComboBox cmbStates = new ToolStripComboBox();
            //cmbStates.ComboBox
            InitializeComboBox();
            //ComboBox cmbStates = new ComboBox();
            //cmbStates.
            //To Display the image in TextBox
            //this.comboBoxAdv1.ShowImageInTextBox = true;
            //this.comboBoxAdv1.ListBox.DrawItem += new DrawItemEventHandler(ListBox_DrawItem);
        }

        private void changeGridSizeDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripDropDownButton button = sender as ToolStripDropDownButton;
            if ((!ReferenceEquals(e.ClickedItem, null)) && (!ReferenceEquals(button, null)))
            {
                button.Image = e.ClickedItem.Image;
                // This line converts my list gridsize options like 64, 32, and 16
                // and Parses that text into the new selected gridsize.
            }
        }

        void myToolStripMenuItem1_Paint(object sender, PaintEventArgs e)
        {
            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
            e.Graphics.DrawImage(menuItem.Image, e.ClipRectangle.Width / 2 - 12, 0);
        }

        private void InitializeComboBox()
        {
            comboBox1 = toolStripComboBox1.ComboBox;
            //toolStripComboBox1.DropDownWidth = 25;
            //toolStripComboBox1.Width = 25;
            //comboBox1.MinimumSize = new System.Drawing.Size(15, 20);
            //comboBox1.Width = 25;

            //this.comboBox1 = new ComboBox();
            /*
            this.comboBox1.DrawMode =
                System.Windows.Forms.DrawMode.OwnerDrawVariable;
            //this.comboBox1.Location = new System.Drawing.Point(200, 200);
            //this.comboBox1.Name = "comboBox1";
            //this.comboBox1.Size = new System.Drawing.Size(40, 20);
            this.comboBox1.DropDownWidth = 30;
            //this.comboBox1.DropDownStyle = ComboBoxStyle.
            this.comboBox1.TabIndex = 0;
            //this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            animals = new string[] { "Elephant", "c r o c o d i l e", "lion" };
            comboBox1.DataSource = animals;
            comboBox1.MaxDropDownItems = 3;
            this.Controls.Add(this.comboBox1);

            // Hook up the MeasureItem and DrawItem events
            this.comboBox1.DrawItem +=
                new DrawItemEventHandler(ComboBox1_DrawItem);
            //this.comboBox1.MeasureItem +=
            //    new MeasureItemEventHandler(ComboBox1_MeasureItem);
            comboBox1.Refresh();
            */
        }

        // If you set the Draw property to DrawMode.OwnerDrawVariable, 
        // you must handle the MeasureItem event. This event handler 
        // will set the height and width of each item before it is drawn. 
        private void ComboBox1_MeasureItem(object sender,
            System.Windows.Forms.MeasureItemEventArgs e)
        {

            e.ItemHeight = 25;
            //e.ItemHeight = ((ComboBox)sender).MaxDropDownItems * 25;
            e.ItemWidth = 25;

        }

        // You must handle the DrawItem event for owner-drawn combo boxes.  
        // This event handler changes the color, size and font of an 
        // item based on its position in the array.
        private void ComboBox1_DrawItem(object sender,
            System.Windows.Forms.DrawItemEventArgs e)
        {

            float size = 0;
            System.Drawing.Font myFont;
            FontFamily family = null;

            System.Drawing.Color animalColor = new System.Drawing.Color();
            size = 10;
            family = FontFamily.GenericMonospace;

            switch (e.Index)
            {
                case 0:
                    animalColor = System.Drawing.Color.Gray;
                    break;
                case 1:
                    size = 10;
                    animalColor = System.Drawing.Color.LawnGreen;
                    break;
                case 2:
                    animalColor = System.Drawing.Color.Tan;
                    break;
            }

            // Draw the background of the item.
            e.DrawBackground();

            // Create a square filled with the animals color. Vary the size
            // of the rectangle based on the length of the animals name.
            Rectangle rectangle = new Rectangle(2, e.Bounds.Top + 2,
                    e.Bounds.Height, e.Bounds.Height - 4);
            e.Graphics.FillRectangle(new SolidBrush(animalColor), rectangle);

            // Draw each string in the array, using a different size, color,
            // and font for each item.
            //myFont = new Font(family, size, FontStyle.Bold);
            //e.Graphics.DrawString(animals[e.Index], myFont, System.Drawing.Brushes.Black, new RectangleF(e.Bounds.X + rectangle.Width, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));

            // Draw the focus rectangle if the mouse hovers over an item.
            e.DrawFocusRectangle();
        }
    }
}
