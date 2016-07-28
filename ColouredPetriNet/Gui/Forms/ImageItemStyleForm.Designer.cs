using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class ImageItemStyleForm
    {
        private void InitializeComponent()
        {
            lblHeight = new Label();
            numHeight = new NumericUpDown();
            btnOk = new Button();
            btnCancel = new Button();
            lblWidth = new Label();
            numWidth = new NumericUpDown();
            lblImage = new Label();
            btnChoose = new Button();
            pbImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new System.Drawing.Point(20, 138);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new System.Drawing.Size(38, 13);
            lblHeight.TabIndex = 25;
            lblHeight.Text = "Height";
            // 
            // numHeight
            // 
            numHeight.Location = new System.Drawing.Point(73, 136);
            numHeight.Name = "numHeight";
            numHeight.Size = new System.Drawing.Size(105, 20);
            numHeight.TabIndex = 24;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(40, 182);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(61, 23);
            btnOk.TabIndex = 23;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(107, 182);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Location = new System.Drawing.Point(20, 112);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new System.Drawing.Size(35, 13);
            lblWidth.TabIndex = 18;
            lblWidth.Text = "Width";
            // 
            // numWidth
            // 
            numWidth.Location = new System.Drawing.Point(73, 110);
            numWidth.Name = "numWidth";
            numWidth.Size = new System.Drawing.Size(105, 20);
            numWidth.TabIndex = 17;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new System.Drawing.Point(21, 11);
            lblImage.Name = "lblImage";
            lblImage.Size = new System.Drawing.Size(36, 13);
            lblImage.TabIndex = 28;
            lblImage.Text = "Image";
            // 
            // btnChoose
            // 
            btnChoose.Location = new System.Drawing.Point(100, 34);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(75, 23);
            btnChoose.TabIndex = 29;
            btnChoose.Text = "Choose";
            btnChoose.UseVisualStyleBackColor = true;
            // 
            // pbImage
            // 
            pbImage.Location = new System.Drawing.Point(23, 34);
            pbImage.Name = "pbImage";
            pbImage.Size = new System.Drawing.Size(61, 61);
            pbImage.TabIndex = 30;
            pbImage.TabStop = false;
            // 
            // ImageItemStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 219);
            this.Controls.Add(pbImage);
            this.Controls.Add(btnChoose);
            this.Controls.Add(lblImage);
            this.Controls.Add(lblHeight);
            this.Controls.Add(numHeight);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.Controls.Add(lblWidth);
            this.Controls.Add(numWidth);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageItemStyleForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Item Style";
            ((System.ComponentModel.ISupportInitialize)(numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnOk;
        private Button btnCancel;
        private Label lblWidth;
        private Label lblImage;
        private NumericUpDown numWidth;
        private Label lblHeight;
        private NumericUpDown numHeight;
        private Button btnChoose;
        private PictureBox pbImage;
    }
}