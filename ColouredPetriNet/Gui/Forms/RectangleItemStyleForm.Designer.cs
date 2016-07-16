namespace ColouredPetriNet.Gui.Forms
{
    partial class RectangleItemStyleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RectangleItemStyleForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChooseFillColor = new System.Windows.Forms.Button();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.pnlFillColor = new System.Windows.Forms.Panel();
            this.lblWidth = new System.Windows.Forms.Label();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.lblHeight = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.grbBorder = new System.Windows.Forms.GroupBox();
            this.btnChooseBorderColor = new System.Windows.Forms.Button();
            this.lblBorderColor = new System.Windows.Forms.Label();
            this.pnlBorderColor = new System.Windows.Forms.Panel();
            this.lblBorderWidth = new System.Windows.Forms.Label();
            this.numBorderWidth = new System.Windows.Forms.NumericUpDown();
            this.cdlgColor = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            this.grbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(82, 226);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(61, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 226);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnChooseFillColor
            // 
            this.btnChooseFillColor.Location = new System.Drawing.Point(118, 76);
            this.btnChooseFillColor.Name = "btnChooseFillColor";
            this.btnChooseFillColor.Size = new System.Drawing.Size(88, 23);
            this.btnChooseFillColor.TabIndex = 11;
            this.btnChooseFillColor.Text = "Choose";
            this.btnChooseFillColor.UseVisualStyleBackColor = true;
            // 
            // lblFillColor
            // 
            this.lblFillColor.AutoSize = true;
            this.lblFillColor.Location = new System.Drawing.Point(17, 81);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(48, 13);
            this.lblFillColor.TabIndex = 10;
            this.lblFillColor.Text = "Fill color:";
            // 
            // pnlFillColor
            // 
            this.pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFillColor.Location = new System.Drawing.Point(71, 76);
            this.pnlFillColor.Name = "pnlFillColor";
            this.pnlFillColor.Size = new System.Drawing.Size(32, 32);
            this.pnlFillColor.TabIndex = 9;
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(18, 14);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(35, 13);
            this.lblWidth.TabIndex = 8;
            this.lblWidth.Text = "Width";
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(71, 12);
            this.numWidth.Name = "numWidth";
            this.numWidth.Size = new System.Drawing.Size(135, 20);
            this.numWidth.TabIndex = 7;
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(18, 40);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(38, 13);
            this.lblHeight.TabIndex = 15;
            this.lblHeight.Text = "Height";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(71, 38);
            this.numHeight.Name = "numHeight";
            this.numHeight.Size = new System.Drawing.Size(135, 20);
            this.numHeight.TabIndex = 14;
            // 
            // grbBorder
            // 
            this.grbBorder.Controls.Add(this.lblBorderWidth);
            this.grbBorder.Controls.Add(this.numBorderWidth);
            this.grbBorder.Controls.Add(this.btnChooseBorderColor);
            this.grbBorder.Controls.Add(this.lblBorderColor);
            this.grbBorder.Controls.Add(this.pnlBorderColor);
            this.grbBorder.Location = new System.Drawing.Point(12, 123);
            this.grbBorder.Name = "grbBorder";
            this.grbBorder.Size = new System.Drawing.Size(212, 97);
            this.grbBorder.TabIndex = 16;
            this.grbBorder.TabStop = false;
            this.grbBorder.Text = "Border";
            // 
            // btnChooseBorderColor
            // 
            this.btnChooseBorderColor.Location = new System.Drawing.Point(106, 58);
            this.btnChooseBorderColor.Name = "btnChooseBorderColor";
            this.btnChooseBorderColor.Size = new System.Drawing.Size(88, 23);
            this.btnChooseBorderColor.TabIndex = 14;
            this.btnChooseBorderColor.Text = "Choose";
            this.btnChooseBorderColor.UseVisualStyleBackColor = true;
            // 
            // lblBorderColor
            // 
            this.lblBorderColor.AutoSize = true;
            this.lblBorderColor.Location = new System.Drawing.Point(22, 63);
            this.lblBorderColor.Name = "lblBorderColor";
            this.lblBorderColor.Size = new System.Drawing.Size(31, 13);
            this.lblBorderColor.TabIndex = 13;
            this.lblBorderColor.Text = "Color";
            // 
            // pnlBorderColor
            // 
            this.pnlBorderColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBorderColor.Location = new System.Drawing.Point(59, 58);
            this.pnlBorderColor.Name = "pnlBorderColor";
            this.pnlBorderColor.Size = new System.Drawing.Size(29, 28);
            this.pnlBorderColor.TabIndex = 12;
            // 
            // lblBorderWidth
            // 
            this.lblBorderWidth.AutoSize = true;
            this.lblBorderWidth.Location = new System.Drawing.Point(18, 21);
            this.lblBorderWidth.Name = "lblBorderWidth";
            this.lblBorderWidth.Size = new System.Drawing.Size(35, 13);
            this.lblBorderWidth.TabIndex = 16;
            this.lblBorderWidth.Text = "Width";
            // 
            // numBorderWidth
            // 
            this.numBorderWidth.Location = new System.Drawing.Point(59, 19);
            this.numBorderWidth.Name = "numBorderWidth";
            this.numBorderWidth.Size = new System.Drawing.Size(135, 20);
            this.numBorderWidth.TabIndex = 15;
            // 
            // RectangleItemStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 257);
            this.Controls.Add(this.grbBorder);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.numHeight);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChooseFillColor);
            this.Controls.Add(this.lblFillColor);
            this.Controls.Add(this.pnlFillColor);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.numWidth);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RectangleItemStyleForm";
            this.Text = "Item Style";
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            this.grbBorder.ResumeLayout(false);
            this.grbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChooseFillColor;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.Panel pnlFillColor;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.GroupBox grbBorder;
        private System.Windows.Forms.Label lblBorderWidth;
        private System.Windows.Forms.NumericUpDown numBorderWidth;
        private System.Windows.Forms.Button btnChooseBorderColor;
        private System.Windows.Forms.Label lblBorderColor;
        private System.Windows.Forms.Panel pnlBorderColor;
        private System.Windows.Forms.ColorDialog cdlgColor;
    }
}