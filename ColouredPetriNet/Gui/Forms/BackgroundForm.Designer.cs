namespace ColouredPetriNet.Gui.Forms
{
    partial class BackgroundForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackgroundForm));
            this.optionPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rbtnSingleColor = new System.Windows.Forms.RadioButton();
            this.rbtnImage = new System.Windows.Forms.RadioButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.optionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.button1);
            this.optionPanel.Controls.Add(this.pictureBox1);
            this.optionPanel.Controls.Add(this.rbtnSingleColor);
            this.optionPanel.Controls.Add(this.rbtnImage);
            this.optionPanel.Location = new System.Drawing.Point(13, 13);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(181, 224);
            this.optionPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // rbtnSingleColor
            // 
            this.rbtnSingleColor.AutoSize = true;
            this.rbtnSingleColor.Checked = true;
            this.rbtnSingleColor.Location = new System.Drawing.Point(75, 14);
            this.rbtnSingleColor.Name = "rbtnSingleColor";
            this.rbtnSingleColor.Size = new System.Drawing.Size(81, 17);
            this.rbtnSingleColor.TabIndex = 1;
            this.rbtnSingleColor.TabStop = true;
            this.rbtnSingleColor.Text = "Single Color";
            this.rbtnSingleColor.UseVisualStyleBackColor = true;
            // 
            // rbtnImage
            // 
            this.rbtnImage.AutoSize = true;
            this.rbtnImage.Location = new System.Drawing.Point(15, 13);
            this.rbtnImage.Name = "rbtnImage";
            this.rbtnImage.Size = new System.Drawing.Size(54, 17);
            this.rbtnImage.TabIndex = 0;
            this.rbtnImage.Text = "Image";
            this.rbtnImage.UseVisualStyleBackColor = true;
            // 
            // BackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 251);
            this.Controls.Add(this.optionPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BackgroundForm";
            this.Text = "Background";
            this.optionPanel.ResumeLayout(false);
            this.optionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel optionPanel;
        private System.Windows.Forms.RadioButton rbtnSingleColor;
        private System.Windows.Forms.RadioButton rbtnImage;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}