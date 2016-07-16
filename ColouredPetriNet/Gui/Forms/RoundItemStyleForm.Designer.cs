namespace ColouredPetriNet.Gui.Forms
{
    partial class RoundItemStyleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoundItemStyleForm));
            this.grbBorder = new System.Windows.Forms.GroupBox();
            this.lblBorderWidth = new System.Windows.Forms.Label();
            this.numBorderWidth = new System.Windows.Forms.NumericUpDown();
            this.btnChooseBorderColor = new System.Windows.Forms.Button();
            this.lblBorderColor = new System.Windows.Forms.Label();
            this.pnlBorderColor = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChooseFillColor = new System.Windows.Forms.Button();
            this.lblFillColor = new System.Windows.Forms.Label();
            this.pnlFillColor = new System.Windows.Forms.Panel();
            this.lblRadius = new System.Windows.Forms.Label();
            this.numRadius = new System.Windows.Forms.NumericUpDown();
            this.grbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBorder
            // 
            this.grbBorder.Controls.Add(this.lblBorderWidth);
            this.grbBorder.Controls.Add(this.numBorderWidth);
            this.grbBorder.Controls.Add(this.btnChooseBorderColor);
            this.grbBorder.Controls.Add(this.lblBorderColor);
            this.grbBorder.Controls.Add(this.pnlBorderColor);
            this.grbBorder.Location = new System.Drawing.Point(14, 96);
            this.grbBorder.Name = "grbBorder";
            this.grbBorder.Size = new System.Drawing.Size(212, 97);
            this.grbBorder.TabIndex = 26;
            this.grbBorder.TabStop = false;
            this.grbBorder.Text = "Border";
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
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(84, 199);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(61, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnChooseFillColor
            // 
            this.btnChooseFillColor.Location = new System.Drawing.Point(120, 49);
            this.btnChooseFillColor.Name = "btnChooseFillColor";
            this.btnChooseFillColor.Size = new System.Drawing.Size(88, 23);
            this.btnChooseFillColor.TabIndex = 21;
            this.btnChooseFillColor.Text = "Choose";
            this.btnChooseFillColor.UseVisualStyleBackColor = true;
            // 
            // lblFillColor
            // 
            this.lblFillColor.AutoSize = true;
            this.lblFillColor.Location = new System.Drawing.Point(19, 54);
            this.lblFillColor.Name = "lblFillColor";
            this.lblFillColor.Size = new System.Drawing.Size(48, 13);
            this.lblFillColor.TabIndex = 20;
            this.lblFillColor.Text = "Fill color:";
            // 
            // pnlFillColor
            // 
            this.pnlFillColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFillColor.Location = new System.Drawing.Point(73, 49);
            this.pnlFillColor.Name = "pnlFillColor";
            this.pnlFillColor.Size = new System.Drawing.Size(32, 32);
            this.pnlFillColor.TabIndex = 19;
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(20, 14);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(40, 13);
            this.lblRadius.TabIndex = 18;
            this.lblRadius.Text = "Radius";
            // 
            // numRadius
            // 
            this.numRadius.Location = new System.Drawing.Point(73, 12);
            this.numRadius.Name = "numRadius";
            this.numRadius.Size = new System.Drawing.Size(135, 20);
            this.numRadius.TabIndex = 17;
            // 
            // RoundItemStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 233);
            this.Controls.Add(this.grbBorder);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChooseFillColor);
            this.Controls.Add(this.lblFillColor);
            this.Controls.Add(this.pnlFillColor);
            this.Controls.Add(this.lblRadius);
            this.Controls.Add(this.numRadius);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoundItemStyleForm";
            this.Text = "Item Style";
            this.grbBorder.ResumeLayout(false);
            this.grbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBorder;
        private System.Windows.Forms.Label lblBorderWidth;
        private System.Windows.Forms.NumericUpDown numBorderWidth;
        private System.Windows.Forms.Button btnChooseBorderColor;
        private System.Windows.Forms.Label lblBorderColor;
        private System.Windows.Forms.Panel pnlBorderColor;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChooseFillColor;
        private System.Windows.Forms.Label lblFillColor;
        private System.Windows.Forms.Panel pnlFillColor;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.NumericUpDown numRadius;
    }
}