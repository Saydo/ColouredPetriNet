using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class LinkStyleForm
    {
        private void InitializeComponent()
        {
            numWidth = new NumericUpDown();
            lblWidth = new Label();
            pnlColor = new Panel();
            lblColor = new Label();
            btnChoose = new Button();
            btnCancel = new Button();
            btnOk = new Button();
            ((System.ComponentModel.ISupportInitialize)(numWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // numWidth
            // 
            numWidth.Location = new System.Drawing.Point(66, 16);
            numWidth.Name = "numWidth";
            numWidth.Size = new System.Drawing.Size(135, 20);
            numWidth.TabIndex = 0;
            // 
            // lblWidth
            // 
            lblWidth.AutoSize = true;
            lblWidth.Location = new System.Drawing.Point(13, 18);
            lblWidth.Name = "lblWidth";
            lblWidth.Size = new System.Drawing.Size(35, 13);
            lblWidth.TabIndex = 1;
            lblWidth.Text = "Width";
            // 
            // pnlColor
            // 
            pnlColor.BorderStyle = BorderStyle.FixedSingle;
            pnlColor.Location = new System.Drawing.Point(66, 53);
            pnlColor.Name = "pnlColor";
            pnlColor.Size = new System.Drawing.Size(32, 29);
            pnlColor.TabIndex = 2;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new System.Drawing.Point(12, 58);
            lblColor.Name = "lblColor";
            lblColor.Size = new System.Drawing.Size(31, 13);
            lblColor.TabIndex = 3;
            lblColor.Text = "Color";
            // 
            // btnChoose
            // 
            btnChoose.Location = new System.Drawing.Point(113, 53);
            btnChoose.Name = "btnChoose";
            btnChoose.Size = new System.Drawing.Size(88, 23);
            btnChoose.TabIndex = 4;
            btnChoose.Text = "Choose";
            btnChoose.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(126, 102);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(59, 102);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(61, 23);
            btnOk.TabIndex = 6;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // LinkStyleForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 137);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnChoose);
            this.Controls.Add(lblColor);
            this.Controls.Add(pnlColor);
            this.Controls.Add(lblWidth);
            this.Controls.Add(numWidth);
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            this.Name = "LinkStyleForm";
            this.Text = "Link Style";
            ((System.ComponentModel.ISupportInitialize)(numWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private NumericUpDown numWidth;
        private Label lblWidth;
        private Panel pnlColor;
        private Label lblColor;
        private Button btnChoose;
        private Button btnCancel;
        private Button btnOk;
    }
}