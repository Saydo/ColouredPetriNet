using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class ItemStyleForm
    {
        private void InitializeComponent()
        {
            dgvItems = new DataGridView();
            btnClear = new Button();
            btnRemove = new Button();
            btnAdd = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)(dgvItems)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new System.Drawing.Point(13, 12);
            dgvItems.Name = "dataGridView1";
            dgvItems.Size = new System.Drawing.Size(259, 163);
            dgvItems.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(206, 181);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(66, 23);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new System.Drawing.Point(125, 181);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(75, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(72, 181);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(47, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(13, 181);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(53, 23);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // ItemStyleForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 217);
            this.Controls.Add(btnBack);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnRemove);
            this.Controls.Add(btnClear);
            this.Controls.Add(dgvItems);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "ItemStyleForm";
            this.Text = "Item Style";
            ((System.ComponentModel.ISupportInitialize)(dgvItems)).EndInit();
            this.ResumeLayout(false);

        }

        private DataGridView dgvItems;
        private Button btnClear;
        private Button btnRemove;
        private Button btnAdd;
        private Button btnBack;
    }
}