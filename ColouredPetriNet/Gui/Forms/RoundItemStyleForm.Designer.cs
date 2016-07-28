using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class RoundItemStyleForm
    {
        private void InitializeComponent()
        {
            grbBorder = new GroupBox();
            lblBorderWidth = new Label();
            numBorderWidth = new NumericUpDown();
            btnChooseBorderColor = new Button();
            lblBorderColor = new Label();
            pnlBorderColor = new Panel();
            btnOk = new Button();
            btnCancel = new Button();
            btnChooseFillColor = new Button();
            lblFillColor = new Label();
            pnlFillColor = new Panel();
            lblRadius = new Label();
            numRadius = new NumericUpDown();
            dlgColor = new ColorDialog();
            grbBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBorderWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numRadius).BeginInit();
            this.SuspendLayout();
            // 
            // grbBorder
            // 
            grbBorder.Controls.Add(lblBorderWidth);
            grbBorder.Controls.Add(numBorderWidth);
            grbBorder.Controls.Add(btnChooseBorderColor);
            grbBorder.Controls.Add(lblBorderColor);
            grbBorder.Controls.Add(pnlBorderColor);
            grbBorder.Location = new System.Drawing.Point(14, 96);
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
            numBorderWidth.Minimum = 0;
            numBorderWidth.Maximum = 30;
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
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(84, 199);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(61, 23);
            btnOk.TabIndex = 23;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += (obj, e) => AcceptChanges();
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(151, 199);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 22;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // btnChooseFillColor
            // 
            btnChooseFillColor.Location = new System.Drawing.Point(120, 49);
            btnChooseFillColor.Name = "btnChooseFillColor";
            btnChooseFillColor.Size = new System.Drawing.Size(88, 23);
            btnChooseFillColor.TabIndex = 21;
            btnChooseFillColor.Text = "Choose";
            btnChooseFillColor.UseVisualStyleBackColor = true;
            btnChooseFillColor.Click += (obj, e) => ChooseFillColor();
            // 
            // lblFillColor
            // 
            lblFillColor.AutoSize = true;
            lblFillColor.Location = new System.Drawing.Point(19, 54);
            lblFillColor.Name = "lblFillColor";
            lblFillColor.Size = new System.Drawing.Size(48, 13);
            lblFillColor.TabIndex = 20;
            lblFillColor.Text = "Fill color:";
            // 
            // pnlFillColor
            // 
            pnlFillColor.BorderStyle = BorderStyle.FixedSingle;
            pnlFillColor.Location = new System.Drawing.Point(73, 49);
            pnlFillColor.Name = "pnlFillColor";
            pnlFillColor.Size = new System.Drawing.Size(32, 32);
            pnlFillColor.TabIndex = 19;
            pnlFillColor.Click += (obj, e) => ChooseFillColor();
            // 
            // lblRadius
            // 
            lblRadius.AutoSize = true;
            lblRadius.Location = new System.Drawing.Point(20, 14);
            lblRadius.Name = "lblRadius";
            lblRadius.Size = new System.Drawing.Size(40, 13);
            lblRadius.TabIndex = 18;
            lblRadius.Text = "Radius";
            // 
            // numRadius
            // 
            numRadius.Location = new System.Drawing.Point(73, 12);
            numRadius.Name = "numRadius";
            numRadius.Size = new System.Drawing.Size(135, 20);
            numRadius.TabIndex = 17;
            numRadius.Minimum = 0;
            numRadius.Maximum = 100;
            // 
            // RoundItemStyleForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 233);
            this.Controls.Add(grbBorder);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnChooseFillColor);
            this.Controls.Add(lblFillColor);
            this.Controls.Add(pnlFillColor);
            this.Controls.Add(lblRadius);
            this.Controls.Add(numRadius);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "RoundItemStyleForm";
            this.Text = "Item Style";
            this.grbBorder.ResumeLayout(false);
            this.grbBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBorderWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)numRadius).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private GroupBox grbBorder;
        private Label lblBorderWidth;
        private NumericUpDown numBorderWidth;
        private Button btnChooseBorderColor;
        private Label lblBorderColor;
        private Panel pnlBorderColor;
        private Button btnOk;
        private Button btnCancel;
        private Button btnChooseFillColor;
        private Label lblFillColor;
        private Panel pnlFillColor;
        private Label lblRadius;
        private NumericUpDown numRadius;
        private ColorDialog dlgColor;
    }
}