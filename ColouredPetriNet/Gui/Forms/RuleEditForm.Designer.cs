using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class RuleEditForm
    {
        private void InitializeComponent()
        {
            lblType = new Label();
            pbType = new PictureBox();
            cmbType = new ComboBox();
            btnCancel = new Button();
            btnOk = new Button();
            dgvIdConvertation = new DataGridView();
            lblCount = new Label();
            numCount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(pbType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvIdConvertation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(numCount)).BeginInit();
            this.SuspendLayout();
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new System.Drawing.Point(86, 17);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(31, 13);
            lblType.TabIndex = 0;
            lblType.Text = "Type";
            // 
            // pbType
            // 
            pbType.Location = new System.Drawing.Point(13, 13);
            pbType.Name = "pbType";
            pbType.Size = new System.Drawing.Size(60, 55);
            pbType.TabIndex = 1;
            pbType.TabStop = false;
            // 
            // cmbType
            // 
            cmbType.FormattingEnabled = true;
            cmbType.Location = new System.Drawing.Point(125, 13);
            cmbType.Name = "cmbType";
            cmbType.Size = new System.Drawing.Size(137, 21);
            cmbType.TabIndex = 2;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(187, 268);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(125, 268);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(56, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // dgvIdConvertation
            // 
            dgvIdConvertation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIdConvertation.Location = new System.Drawing.Point(12, 86);
            dgvIdConvertation.Name = "dgvIdConvertation";
            dgvIdConvertation.Size = new System.Drawing.Size(250, 167);
            dgvIdConvertation.TabIndex = 7;
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new System.Drawing.Point(86, 44);
            lblCount.Name = "lblCount";
            lblCount.Size = new System.Drawing.Size(35, 13);
            lblCount.TabIndex = 6;
            lblCount.Text = "Count";
            // 
            // numCount
            // 
            numCount.Location = new System.Drawing.Point(125, 40);
            numCount.Name = "numCount";
            numCount.Size = new System.Drawing.Size(137, 20);
            numCount.TabIndex = 5;
            // 
            // RuleEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 303);
            this.Controls.Add(dgvIdConvertation);
            this.Controls.Add(lblCount);
            this.Controls.Add(numCount);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.Controls.Add(cmbType);
            this.Controls.Add(pbType);
            this.Controls.Add(lblType);
            this.Name = "RuleEditForm";
            this.Text = "Edit Rule";
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            ((System.ComponentModel.ISupportInitialize)(pbType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvIdConvertation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(numCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblType;
        private PictureBox pbType;
        private ComboBox cmbType;
        private Button btnCancel;
        private Button btnOk;
        private DataGridView dgvIdConvertation;
        private Label lblCount;
        private NumericUpDown numCount;
    }
}