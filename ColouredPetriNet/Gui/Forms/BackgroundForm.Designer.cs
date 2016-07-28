using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class BackgroundForm
    {
        private void InitializeComponent()
        {
            optionPanel = new Panel();
            btnChoose = new Button();
            pbImage = new PictureBox();
            rbtnSingleColor = new RadioButton();
            rbtnImage = new RadioButton();
            cdlgColor = new ColorDialog();
            btnCancel = new Button();
            optionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // optionPanel
            // 
            optionPanel.Controls.Add(rbtnSingleColor);
            optionPanel.Controls.Add(rbtnImage);
            optionPanel.Location = new System.Drawing.Point(12, 12);
            optionPanel.Name = "optionPanel";
            optionPanel.Size = new System.Drawing.Size(228, 23);
            optionPanel.TabIndex = 0;
            // 
            // btnChoose
            // 
            btnChoose.Location = new System.Drawing.Point(84, 197);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(75, 23);
            btnChoose.TabIndex = 3;
            btnChoose.Text = "Choose";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += new System.EventHandler(button1_Click);
            // 
            // pbImage
            // 
            pbImage.BorderStyle = BorderStyle.FixedSingle;
            pbImage.Location = new System.Drawing.Point(50, 41);
            pbImage.Name = "pbImage";
            pbImage.Size = new System.Drawing.Size(158, 150);
            pbImage.TabIndex = 2;
            pbImage.TabStop = false;
            // 
            // rbtnSingleColor
            // 
            rbtnSingleColor.AutoSize = true;
            rbtnSingleColor.Checked = true;
            rbtnSingleColor.Location = new System.Drawing.Point(105, 3);
            rbtnSingleColor.Name = "rbtnSingleColor";
            rbtnSingleColor.Size = new System.Drawing.Size(81, 17);
            rbtnSingleColor.TabIndex = 1;
            rbtnSingleColor.TabStop = true;
            rbtnSingleColor.Text = "Single Color";
            rbtnSingleColor.UseVisualStyleBackColor = true;
            // 
            // rbtnImage
            // 
            rbtnImage.AutoSize = true;
            rbtnImage.Location = new System.Drawing.Point(45, 3);
            rbtnImage.Name = "rbtnImage";
            rbtnImage.Size = new System.Drawing.Size(54, 17);
            rbtnImage.TabIndex = 0;
            rbtnImage.Text = "Image";
            rbtnImage.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(165, 196);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // BackgroundForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 233);
            this.Controls.Add(btnCancel);
            this.Controls.Add(pbImage);
            this.Controls.Add(btnChoose);
            this.Controls.Add(optionPanel);
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            this.Name = "BackgroundForm";
            this.Text = "Background";
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pbImage)).EndInit();
            this.ResumeLayout(false);

        }

        private Panel optionPanel;
        private RadioButton rbtnSingleColor;
        private RadioButton rbtnImage;
        private Button btnChoose;
        private PictureBox pbImage;
        private ColorDialog cdlgColor;
        private Button btnCancel;
    }
}