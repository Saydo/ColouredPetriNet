using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class ImageItemStyleForm
    {
        private void InitializeComponent()
        {
            grbBorder = new GroupBox();
            lblBorderWidth = new Label();
            numBorderWidth = new NumericUpDown();
            btnChooseBorderColor = new Button();
            lblBorderColor = new Label();
            pnlBorderColor = new Panel();
            lblHeight = new Label();
            numHeight = new NumericUpDown();
            btnOk = new Button();
            btnCancel = new Button();
            btnChooseFillColor = new Button();
            lblFillColor = new Label();
            pnlFillColor = new Panel();
            lblWidth = new Label();
            numWidth = new NumericUpDown();
            lblImage = new Label();
            numImage = new NumericUpDown();
            grbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numBorderWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numImage)).BeginInit();
            this.SuspendLayout();
            // 
            // grbBorder
            // 
            grbBorder.Controls.Add(lblBorderWidth);
            grbBorder.Controls.Add(numBorderWidth);
            grbBorder.Controls.Add(btnChooseBorderColor);
            grbBorder.Controls.Add(lblBorderColor);
            grbBorder.Controls.Add(pnlBorderColor);
            grbBorder.Location = new System.Drawing.Point(13, 137);
            grbBorder.Name = "grbBorder";
            grbBorder.Size = new System.Drawing.Size(212, 97);
            grbBorder.TabIndex = 26;
            grbBorder.TabStop = false;
            grbBorder.Text = "Border";
            // 
            // lblBorderWidth
            // 
            lblBorderWidth.AutoSize = true;
            lblBorderWidth.Location = new System.Drawing.Point(18, 21);
            lblBorderWidth.Name = "lblBorderWidth";
            lblBorderWidth.Size = new System.Drawing.Size(35, 13);
            lblBorderWidth.TabIndex = 16;
            lblBorderWidth.Text = "Width";
            // 
            // numBorderWidth
            // 
            numBorderWidth.Location = new System.Drawing.Point(59, 19);
            numBorderWidth.Name = "numBorderWidth";
            numBorderWidth.Size = new System.Drawing.Size(135, 20);
            numBorderWidth.TabIndex = 15;
            // 
            // btnChooseBorderColor
            // 
            btnChooseBorderColor.Location = new System.Drawing.Point(106, 58);
            btnChooseBorderColor.Name = "btnChooseBorderColor";
            btnChooseBorderColor.Size = new System.Drawing.Size(88, 23);
            btnChooseBorderColor.TabIndex = 14;
            btnChooseBorderColor.Text = "Choose";
            btnChooseBorderColor.UseVisualStyleBackColor = true;
            // 
            // lblBorderColor
            // 
            lblBorderColor.AutoSize = true;
            lblBorderColor.Location = new System.Drawing.Point(22, 63);
            lblBorderColor.Name = "lblBorderColor";
            lblBorderColor.Size = new System.Drawing.Size(31, 13);
            lblBorderColor.TabIndex = 13;
            lblBorderColor.Text = "Color";
            // 
            // pnlBorderColor
            // 
            pnlBorderColor.BorderStyle = BorderStyle.FixedSingle;
            pnlBorderColor.Location = new System.Drawing.Point(59, 58);
            pnlBorderColor.Name = "pnlBorderColor";
            pnlBorderColor.Size = new System.Drawing.Size(29, 28);
            pnlBorderColor.TabIndex = 12;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new System.Drawing.Point(19, 66);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new System.Drawing.Size(38, 13);
            lblHeight.TabIndex = 25;
            lblHeight.Text = "Height";
            // 
            // numHeight
            // 
            numHeight.Location = new System.Drawing.Point(72, 64);
            numHeight.Name = "numHeight";
            numHeight.Size = new System.Drawing.Size(135, 20);
            numHeight.TabIndex = 24;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(83, 240);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(61, 23);
            btnOk.TabIndex = 23;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(150, 240);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnChooseFillColor
            // 
            btnChooseFillColor.Location = new System.Drawing.Point(119, 90);
            btnChooseFillColor.Name = "btnChooseFillColor";
            btnChooseFillColor.Size = new System.Drawing.Size(88, 23);
            btnChooseFillColor.TabIndex = 21;
            btnChooseFillColor.Text = "Choose";
            btnChooseFillColor.UseVisualStyleBackColor = true;
            // 
            // lblFillColor
            // 
            lblFillColor.AutoSize = true;
            lblFillColor.Location = new System.Drawing.Point(18, 95);
            lblFillColor.Name = "lblFillColor";
            lblFillColor.Size = new System.Drawing.Size(48, 13);
            lblFillColor.TabIndex = 20;
            lblFillColor.Text = "Fill color:";
            // 
            // pnlFillColor
            // 
            pnlFillColor.BorderStyle = BorderStyle.FixedSingle;
            pnlFillColor.Location = new System.Drawing.Point(72, 90);
            pnlFillColor.Name = "pnlFillColor";
            pnlFillColor.Size = new System.Drawing.Size(32, 32);
            pnlFillColor.TabIndex = 19;
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Location = new System.Drawing.Point(19, 40);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new System.Drawing.Size(35, 13);
            lblWidth.TabIndex = 18;
            lblWidth.Text = "Width";
            // 
            // numWidth
            // 
            numWidth.Location = new System.Drawing.Point(72, 38);
            numWidth.Name = "numWidth";
            numWidth.Size = new System.Drawing.Size(135, 20);
            numWidth.TabIndex = 17;
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new System.Drawing.Point(19, 14);
            lblImage.Name = "lblImage";
            lblImage.Size = new System.Drawing.Size(36, 13);
            lblImage.TabIndex = 28;
            lblImage.Text = "Image";
            // 
            // numImage
            // 
            numImage.Location = new System.Drawing.Point(72, 12);
            numImage.Name = "numImage";
            numImage.Size = new System.Drawing.Size(135, 20);
            numImage.TabIndex = 27;
            // 
            // ImageItemStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 272);
            this.Controls.Add(lblImage);
            this.Controls.Add(numImage);
            this.Controls.Add(grbBorder);
            this.Controls.Add(lblHeight);
            this.Controls.Add(numHeight);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnChooseFillColor);
            this.Controls.Add(lblFillColor);
            this.Controls.Add(pnlFillColor);
            this.Controls.Add(lblWidth);
            this.Controls.Add(numWidth);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "ImageItemStyleForm";
            this.Text = "Item Style";
            grbBorder.ResumeLayout(false);
            grbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(numBorderWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private GroupBox grbBorder;
        private Label lblBorderWidth;
        private NumericUpDown numBorderWidth;
        private Button btnChooseBorderColor;
        private Label lblBorderColor;
        private Panel pnlBorderColor;
        private Label lblHeight;
        private NumericUpDown numHeight;
        private Button btnOk;
        private Button btnCancel;
        private Button btnChooseFillColor;
        private Label lblFillColor;
        private Panel pnlFillColor;
        private Label lblWidth;
        private NumericUpDown numWidth;
        private Label lblImage;
        private NumericUpDown numImage;
    }
}