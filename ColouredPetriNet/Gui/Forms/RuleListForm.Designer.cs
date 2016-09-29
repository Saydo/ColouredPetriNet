using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class RuleListForm
    {
        private void InitializeComponent()
        {
            dgvRules = new DataGridView();
            btnClear = new Button();
            btnRemove = new Button();
            btnAdd = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)(dgvRules)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRules
            // 
            dgvRules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRules.Location = new System.Drawing.Point(13, 13);
            dgvRules.Name = "dgvRules";
            dgvRules.Size = new System.Drawing.Size(259, 208);
            dgvRules.TabIndex = 0;
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(211, 227);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(61, 23);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new System.Drawing.Point(142, 227);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(63, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(81, 227);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(55, 23);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(13, 227);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(62, 23);
            btnBack.TabIndex = 4;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += (obj, e) => this.Close();
            // 
            // RuleListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 256);
            this.Controls.Add(btnBack);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnRemove);
            this.Controls.Add(btnClear);
            this.Controls.Add(dgvRules);
            this.Name = "RuleListForm";
            this.Text = "Rules";
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            ((System.ComponentModel.ISupportInitialize)(dgvRules)).EndInit();
            this.ResumeLayout(false);
        }

        private DataGridView dgvRules;
        private Button btnClear;
        private Button btnRemove;
        private Button btnAdd;
        private Button btnBack;
    }
}