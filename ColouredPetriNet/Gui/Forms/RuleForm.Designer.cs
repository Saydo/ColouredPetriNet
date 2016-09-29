using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class RuleForm
    {
        private void InitializeComponent()
        {
            dgvInputMarkers = new DataGridView();
            btnEdit = new Button();
            btnBack = new Button();
            btnAdd = new Button();
            btnRemove = new Button();
            btnRemove2 = new Button();
            btnAdd2 = new Button();
            btnEdit2 = new Button();
            dgvOutputMarkers = new DataGridView();
            lblInputMarkers = new Label();
            lblOutputMarkers = new Label();
            ((System.ComponentModel.ISupportInitialize)(dgvInputMarkers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvOutputMarkers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvInputMarkers
            // 
            dgvInputMarkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInputMarkers.Location = new System.Drawing.Point(14, 31);
            dgvInputMarkers.Name = "dgvInputMarkers";
            dgvInputMarkers.Size = new System.Drawing.Size(189, 172);
            dgvInputMarkers.TabIndex = 0;
            // 
            // btnEdit
            // 
            btnEdit.Location = new System.Drawing.Point(144, 209);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(59, 23);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(323, 238);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(75, 23);
            btnBack.TabIndex = 3;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(14, 209);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(59, 23);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new System.Drawing.Point(79, 209);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(59, 23);
            btnRemove.TabIndex = 5;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnRemove2
            // 
            btnRemove2.Location = new System.Drawing.Point(274, 209);
            btnRemove2.Name = "btnRemove2";
            btnRemove2.Size = new System.Drawing.Size(59, 23);
            btnRemove2.TabIndex = 9;
            btnRemove2.Text = "Remove";
            btnRemove2.UseVisualStyleBackColor = true;
            // 
            // btnAdd2
            // 
            btnAdd2.Location = new System.Drawing.Point(209, 209);
            btnAdd2.Name = "btnAdd2";
            btnAdd2.Size = new System.Drawing.Size(59, 23);
            btnAdd2.TabIndex = 8;
            btnAdd2.Text = "Add";
            btnAdd2.UseVisualStyleBackColor = true;
            // 
            // btnEdit2
            // 
            btnEdit2.Location = new System.Drawing.Point(339, 209);
            btnEdit2.Name = "btnEdit2";
            btnEdit2.Size = new System.Drawing.Size(59, 23);
            btnEdit2.TabIndex = 7;
            btnEdit2.Text = "Edit";
            btnEdit2.UseVisualStyleBackColor = true;
            // 
            // dgvOutputMarkers
            // 
            dgvOutputMarkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutputMarkers.Location = new System.Drawing.Point(209, 31);
            dgvOutputMarkers.Name = "dgvOutputMarkers";
            dgvOutputMarkers.Size = new System.Drawing.Size(189, 172);
            dgvOutputMarkers.TabIndex = 6;
            // 
            // lblInputMarkers
            // 
            lblInputMarkers.AutoSize = true;
            lblInputMarkers.Location = new System.Drawing.Point(66, 9);
            lblInputMarkers.Name = "lblInputMarkers";
            lblInputMarkers.Size = new System.Drawing.Size(72, 13);
            lblInputMarkers.TabIndex = 10;
            lblInputMarkers.Text = "Input Markers";
            // 
            // lblOutputMarkers
            // 
            lblOutputMarkers.AutoSize = true;
            lblOutputMarkers.Location = new System.Drawing.Point(261, 9);
            lblOutputMarkers.Name = "lblOutputMarkers";
            lblOutputMarkers.Size = new System.Drawing.Size(80, 13);
            lblOutputMarkers.TabIndex = 11;
            lblOutputMarkers.Text = "Output Markers";
            // 
            // RuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 275);
            this.Controls.Add(lblOutputMarkers);
            this.Controls.Add(lblInputMarkers);
            this.Controls.Add(btnRemove2);
            this.Controls.Add(btnAdd2);
            this.Controls.Add(btnEdit2);
            this.Controls.Add(dgvOutputMarkers);
            this.Controls.Add(btnRemove);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnBack);
            this.Controls.Add(btnEdit);
            this.Controls.Add(dgvInputMarkers);
            this.Name = "RuleForm";
            this.Text = "Rule Info";
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            ((System.ComponentModel.ISupportInitialize)(dgvInputMarkers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvOutputMarkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private DataGridView dgvInputMarkers;
        private Button btnEdit;
        private Button btnBack;
        private Button btnAdd;
        private Button btnRemove;
        private Button btnRemove2;
        private Button btnAdd2;
        private Button btnEdit2;
        private DataGridView dgvOutputMarkers;
        private Label lblInputMarkers;
        private Label lblOutputMarkers;
    }
}