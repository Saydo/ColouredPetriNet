using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class ItemStyleForm
    {
        private void InitializeComponent()
        {
            dgvItems = new DataGridView();
            btnCancel = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)(dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new System.Drawing.Point(13, 12);
            dgvItems.Name = "dgvItems";
            dgvItems.Size = new System.Drawing.Size(259, 163);
            dgvItems.TabIndex = 0;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(206, 181);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(66, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // btnEdit
            // 
            btnEdit.Location = new System.Drawing.Point(155, 181);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(47, 23);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // ItemStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 217);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnCancel);
            this.Controls.Add(dgvItems);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = Properties.Resources.AppIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemStyleForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Item Style";
            ((System.ComponentModel.ISupportInitialize)(dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        private DataGridView dgvItems;
        private Button btnCancel;
        private Button btnEdit;
    }
}