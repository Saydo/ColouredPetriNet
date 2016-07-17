using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class AboutForm
    {
        private void InitializeComponent()
        {
            lblName = new Label();
            lblDescription = new Label();
            btnOk = new Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            lblName.Location = new System.Drawing.Point(0, 9);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(225, 13);
            lblName.TabIndex = 0;
            lblName.Text = "Coloured Petri Net";
            lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescription
            // 
            lblDescription.Location = new System.Drawing.Point(0, 32);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new System.Drawing.Size(225, 45);
            lblDescription.TabIndex = 1;
            lblDescription.Text = "Created with .Net Framework 4.5 and Windows Forms";
            lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(138, 99);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += (obj, e) => this.Close();
            //
            // AboutForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 134);
            this.Controls.Add(btnOk);
            this.Controls.Add(lblName);
            this.Controls.Add(lblDescription);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "AboutForm";
            this.Text = "About";
            this.ResumeLayout(false);
        }

        private Label lblName;
        private Label lblDescription;
        private Button btnOk;
    }
}