using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class RectangleItemStyleForm
    {
        private void InitializeComponent()
        {
            btnOk = new Button();
            btnCancel = new Button();
            btnChooseFillColor = new Button();
            lblFillColor = new Label();
            pnlFillColor = new Panel();
            lblWidth = new Label();
            numWidth = new NumericUpDown();
            lblHeight = new Label();
            numHeight = new NumericUpDown();
            grbBorder = new GroupBox();
            btnChooseBorderColor = new Button();
            lblBorderColor = new Label();
            pnlBorderColor = new Panel();
            lblBorderWidth = new Label();
            numBorderWidth = new NumericUpDown();
            dlgColor = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(numWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numHeight)).BeginInit();
            grbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(numBorderWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(82, 226);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(61, 23);
            btnOk.TabIndex = 13;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += (obj, e) => AcceptChanges();
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(149, 226);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // btnChooseFillColor
            // 
            btnChooseFillColor.Location = new System.Drawing.Point(118, 76);
            btnChooseFillColor.Name = "btnChooseFillColor";
            btnChooseFillColor.Size = new System.Drawing.Size(88, 23);
            btnChooseFillColor.TabIndex = 11;
            btnChooseFillColor.Text = "Choose";
            btnChooseFillColor.UseVisualStyleBackColor = true;
            btnChooseFillColor.Click += (obj, e) => ChooseFillColor();
            // 
            // lblFillColor
            // 
            lblFillColor.AutoSize = true;
            lblFillColor.Location = new System.Drawing.Point(17, 81);
            lblFillColor.Name = "lblFillColor";
            lblFillColor.Size = new System.Drawing.Size(48, 13);
            lblFillColor.TabIndex = 10;
            lblFillColor.Text = "Fill color:";
            // 
            // pnlFillColor
            // 
            pnlFillColor.BorderStyle = BorderStyle.FixedSingle;
            pnlFillColor.Location = new System.Drawing.Point(71, 76);
            pnlFillColor.Name = "pnlFillColor";
            pnlFillColor.Size = new System.Drawing.Size(32, 32);
            pnlFillColor.TabIndex = 9;
            pnlFillColor.Click += (obj, e) => ChooseFillColor();
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Location = new System.Drawing.Point(18, 14);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new System.Drawing.Size(35, 13);
            lblWidth.TabIndex = 8;
            lblWidth.Text = "Width";
            // 
            // numWidth
            // 
            numWidth.Location = new System.Drawing.Point(71, 12);
            numWidth.Name = "numWidth";
            numWidth.Size = new System.Drawing.Size(135, 20);
            numWidth.TabIndex = 7;
            numWidth.Minimum = 0;
            numWidth.Maximum = 200;
            // 
            // lblHeight
            // 
            lblHeight.AutoSize = true;
            lblHeight.Location = new System.Drawing.Point(18, 40);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new System.Drawing.Size(38, 13);
            lblHeight.TabIndex = 15;
            lblHeight.Text = "Height";
            // 
            // numHeight
            // 
            numHeight.Location = new System.Drawing.Point(71, 38);
            numHeight.Name = "numHeight";
            numHeight.Size = new System.Drawing.Size(135, 20);
            numHeight.TabIndex = 14;
            numHeight.Minimum = 0;
            numHeight.Maximum = 200;
            // 
            // grbBorder
            // 
            grbBorder.Controls.Add(lblBorderWidth);
            grbBorder.Controls.Add(numBorderWidth);
            grbBorder.Controls.Add(btnChooseBorderColor);
            grbBorder.Controls.Add(lblBorderColor);
            grbBorder.Controls.Add(pnlBorderColor);
            grbBorder.Location = new System.Drawing.Point(12, 123);
            grbBorder.Name = "grbBorder";
            grbBorder.Size = new System.Drawing.Size(212, 97);
            grbBorder.TabIndex = 16;
            grbBorder.TabStop = false;
            grbBorder.Text = "Border";
            // 
            // btnChooseBorderColor
            // 
            btnChooseBorderColor.Location = new System.Drawing.Point(106, 58);
            btnChooseBorderColor.Name = "btnChooseBorderColor";
            btnChooseBorderColor.Size = new System.Drawing.Size(88, 23);
            btnChooseBorderColor.TabIndex = 14;
            btnChooseBorderColor.Text = "Choose";
            btnChooseBorderColor.UseVisualStyleBackColor = true;
            btnChooseBorderColor.Click += (obj, e) => ChooseBorderColor();
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
            pnlBorderColor.Click += (obj, e) => ChooseBorderColor();
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
            numBorderWidth.Minimum = 0;
            numBorderWidth.Maximum = 30;
            // 
            // RectangleItemStyleForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 257);
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
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            this.Name = "RectangleItemStyleForm";
            this.Text = "Item Style";
            ((System.ComponentModel.ISupportInitialize)(numWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numHeight)).EndInit();
            grbBorder.ResumeLayout(false);
            grbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(numBorderWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnOk;
        private Button btnCancel;
        private Button btnChooseFillColor;
        private Label lblFillColor;
        private Panel pnlFillColor;
        private Label lblWidth;
        private NumericUpDown numWidth;
        private Label lblHeight;
        private NumericUpDown numHeight;
        private GroupBox grbBorder;
        private Label lblBorderWidth;
        private NumericUpDown numBorderWidth;
        private Button btnChooseBorderColor;
        private Label lblBorderColor;
        private Panel pnlBorderColor;
        private ColorDialog dlgColor;
    }
}