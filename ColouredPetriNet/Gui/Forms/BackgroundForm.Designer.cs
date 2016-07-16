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
            optionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pbImage)).BeginInit();
            this.SuspendLayout();
            // 
            // optionPanel
            // 
            optionPanel.Controls.Add(btnChoose);
            optionPanel.Controls.Add(pbImage);
            optionPanel.Controls.Add(rbtnSingleColor);
            optionPanel.Controls.Add(rbtnImage);
            optionPanel.Location = new System.Drawing.Point(13, 13);
            optionPanel.Name = "optionPanel";
            optionPanel.Size = new System.Drawing.Size(181, 224);
            optionPanel.TabIndex = 0;
            // 
            // button1
            // 
            btnChoose.Location = new System.Drawing.Point(90, 193);
            btnChoose.Name = "button1";
            btnChoose.Size = new System.Drawing.Size(75, 23);
            btnChoose.TabIndex = 3;
            btnChoose.Text = "Choose";
            btnChoose.UseVisualStyleBackColor = true;
            btnChoose.Click += new System.EventHandler(button1_Click);
            // 
            // pictureBox1
            // 
            pbImage.BorderStyle = BorderStyle.FixedSingle;
            pbImage.Location = new System.Drawing.Point(15, 37);
            pbImage.Name = "pictureBox1";
            pbImage.Size = new System.Drawing.Size(150, 150);
            pbImage.TabIndex = 2;
            pbImage.TabStop = false;
            // 
            // rbtnSingleColor
            // 
            rbtnSingleColor.AutoSize = true;
            rbtnSingleColor.Checked = true;
            rbtnSingleColor.Location = new System.Drawing.Point(75, 14);
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
            rbtnImage.Location = new System.Drawing.Point(15, 13);
            rbtnImage.Name = "rbtnImage";
            rbtnImage.Size = new System.Drawing.Size(54, 17);
            rbtnImage.TabIndex = 0;
            rbtnImage.Text = "Image";
            rbtnImage.UseVisualStyleBackColor = true;
            // 
            // BackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 251);
            this.Controls.Add(optionPanel);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "BackgroundForm";
            this.Text = "Background";
            optionPanel.ResumeLayout(false);
            optionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pbImage)).EndInit();
            this.ResumeLayout(false);
        }

        private Panel optionPanel;
        private RadioButton rbtnSingleColor;
        private RadioButton rbtnImage;
        private Button btnChoose;
        private PictureBox pbImage;
        private ColorDialog cdlgColor;
    }
}