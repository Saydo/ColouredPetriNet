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
            this.rbtnImage = new System.Windows.Forms.RadioButton();
            this.rbtnSingleColor = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.optionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // optionPanel
            // 
            this.optionPanel.Controls.Add(this.button2);
            this.optionPanel.Controls.Add(this.colorPanel);
            this.optionPanel.Controls.Add(this.button1);
            this.optionPanel.Controls.Add(this.pictureBox1);
            this.optionPanel.Controls.Add(this.rbtnSingleColor);
            this.optionPanel.Controls.Add(this.rbtnImage);
            this.optionPanel.Location = new System.Drawing.Point(13, 13);
            this.optionPanel.Name = "optionPanel";
            this.optionPanel.Size = new System.Drawing.Size(364, 428);
            this.optionPanel.TabIndex = 0;
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
            // rbtnSingleColor
            // 
            this.rbtnSingleColor.AutoSize = true;
            this.rbtnSingleColor.Checked = true;
            this.rbtnSingleColor.Location = new System.Drawing.Point(15, 232);
            this.rbtnSingleColor.Name = "rbtnSingleColor";
            this.rbtnSingleColor.Size = new System.Drawing.Size(81, 17);
            this.rbtnSingleColor.TabIndex = 1;
            this.rbtnSingleColor.TabStop = true;
            this.rbtnSingleColor.Text = "Single Color";
            this.rbtnSingleColor.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(15, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 172);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(235, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Choose";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.SystemColors.Control;
            this.colorPanel.Location = new System.Drawing.Point(15, 256);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(198, 128);
            this.colorPanel.TabIndex = 4;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(235, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Choose";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // BackgroundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 453);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel colorPanel;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}