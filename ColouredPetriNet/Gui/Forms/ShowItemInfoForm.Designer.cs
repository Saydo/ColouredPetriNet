using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class ShowItemInfoForm
    {
        private void InitializeComponent()
        {
            btnFind = new Button();
            btnCancel = new Button();
            lblId = new Label();
            numId = new NumericUpDown();

            this.SuspendLayout();
            // 
            // btnFind
            // 
            btnFind.Location = new System.Drawing.Point(43, 49);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(75, 23);
            btnFind.TabIndex = 0;
            btnFind.Text = "Find";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += (obj, e) => FindButtonClick(this,
                new Core.Events.ShowInfoEventArgs((int)numId.Value, _itemType));
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(124, 49);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new System.Drawing.Point(12, 15);
            lblId.Name = "lblId";
            lblId.Size = new System.Drawing.Size(16, 13);
            lblId.TabIndex = 5;
            lblId.Text = "Id";
            // 
            // numId
            // 
            numId.Location = new System.Drawing.Point(34, 12);
            numId.Name = "numId";
            numId.Size = new System.Drawing.Size(165, 20);
            numId.TabIndex = 4;
            numId.Minimum = 0;
            numId.Maximum = int.MaxValue;
            // 
            // ShowItemInfoForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 82);
            this.Controls.Add(lblId);
            this.Controls.Add(numId);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnFind);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "ShowItemInfoForm";
            this.Text = "Item Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnFind;
        private Button btnCancel;
        private Label lblId;
        private NumericUpDown numId;
    }
}