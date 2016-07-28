using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class TypeListForm
    {
        private void InitializeComponent()
        {
            btnAdd = new Button();
            btnRemove = new Button();
            btnClear = new Button();
            dgvTypes = new DataGridView();
            btnEdit = new Button();
            btnBack = new Button();
            dlgEditType = new TypeEditForm(this);
            ((System.ComponentModel.ISupportInitialize)(dgvTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            btnAdd.Location = new System.Drawing.Point(66, 226);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(43, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += (obj, e) => dlgEditType.ShowDialog();
            // 
            // btnRemove
            // 
            btnRemove.Location = new System.Drawing.Point(170, 226);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(58, 23);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += (obj, e) => RemoveType();
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(234, 226);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(51, 23);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += (obj, e) => ClearTypes();
            // 
            // dgvTypes
            // 
            dgvTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTypes.Location = new System.Drawing.Point(13, 12);
            dgvTypes.Name = "dgvTypes";
            dgvTypes.Size = new System.Drawing.Size(272, 208);
            dgvTypes.TabIndex = 4;
            // 
            // btnEdit
            // 
            btnEdit.Location = new System.Drawing.Point(115, 226);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(49, 23);
            btnEdit.TabIndex = 8;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += (obj, e) => OpenEditDialog();
            // 
            // btnBack
            // 
            btnBack.Location = new System.Drawing.Point(13, 226);
            btnBack.Name = "btnBack";
            btnBack.Size = new System.Drawing.Size(47, 23);
            btnBack.TabIndex = 9;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += (obj, e) => this.Close();
            // 
            // TypeListForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 261);
            this.Controls.Add(btnBack);
            this.Controls.Add(btnEdit);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnRemove);
            this.Controls.Add(btnClear);
            this.Controls.Add(dgvTypes);
            this.Name = "TypeListForm";
            this.Text = "Types";
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            ((System.ComponentModel.ISupportInitialize)(dgvTypes)).EndInit();
            this.ResumeLayout(false);

        }

        private Button btnAdd;
        private Button btnRemove;
        private Button btnClear;
        private DataGridView dgvTypes;
        private Button btnEdit;
        private Button btnBack;
        private TypeEditForm dlgEditType;
    }
}