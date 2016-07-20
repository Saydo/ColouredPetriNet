using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class StateInfoForm
    {
        private void InitializeComponent()
        {
            lblId = new Label();
            txtId = new TextBox();
            lblInputLinks = new Label();
            dgvInputLinks = new DataGridView();
            dgvOutputLinks = new DataGridView();
            lblOutputLinks = new Label();
            btnOk = new Button();
            dgvMarkers = new DataGridView();
            lblMarkers = new Label();
            lblType = new Label();
            txtType = new TextBox();
            ((System.ComponentModel.ISupportInitialize)(dgvInputLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvOutputLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dgvMarkers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new System.Drawing.Point(15, 15);
            lblId.Name = "lblId";
            lblId.Size = new System.Drawing.Size(16, 13);
            lblId.TabIndex = 3;
            lblId.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new System.Drawing.Point(52, 12);
            txtId.Name = "txtId";
            txtId.Size = new System.Drawing.Size(205, 20);
            txtId.TabIndex = 2;
            txtId.ReadOnly = true;
            // 
            // lblInputLinks
            // 
            lblInputLinks.AutoSize = true;
            lblInputLinks.Location = new System.Drawing.Point(16, 206);
            lblInputLinks.Name = "lblInputLinks";
            lblInputLinks.Size = new System.Drawing.Size(58, 13);
            lblInputLinks.TabIndex = 4;
            lblInputLinks.Text = "Input links:";
            // 
            // dgvInputLinks
            // 
            dgvInputLinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInputLinks.Location = new System.Drawing.Point(18, 227);
            dgvInputLinks.Name = "dgvInputLinks";
            dgvInputLinks.Size = new System.Drawing.Size(240, 102);
            dgvInputLinks.TabIndex = 5;
            // 
            // dgvOutputLinks
            // 
            dgvOutputLinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutputLinks.Location = new System.Drawing.Point(18, 363);
            dgvOutputLinks.Name = "dgvOutputLinks";
            dgvOutputLinks.Size = new System.Drawing.Size(240, 102);
            dgvOutputLinks.TabIndex = 7;
            // 
            // lblOutputLinks
            // 
            lblOutputLinks.AutoSize = true;
            lblOutputLinks.Location = new System.Drawing.Point(16, 342);
            lblOutputLinks.Name = "lblOutputLinks";
            lblOutputLinks.Size = new System.Drawing.Size(66, 13);
            lblOutputLinks.TabIndex = 6;
            lblOutputLinks.Text = "Output links:";
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(183, 481);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 8;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += (obj, e) => this.Close();
            // 
            // dgvMarkers
            // 
            dgvMarkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarkers.Location = new System.Drawing.Point(18, 90);
            dgvMarkers.Name = "dgvMarkers";
            dgvMarkers.Size = new System.Drawing.Size(240, 102);
            dgvMarkers.TabIndex = 10;
            // 
            // lblMarkers
            // 
            lblMarkers.AutoSize = true;
            lblMarkers.Location = new System.Drawing.Point(16, 69);
            lblMarkers.Name = "lblMarkers";
            lblMarkers.Size = new System.Drawing.Size(48, 13);
            lblMarkers.TabIndex = 9;
            lblMarkers.Text = "Markers:";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new System.Drawing.Point(15, 41);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(31, 13);
            lblType.TabIndex = 12;
            lblType.Text = "Type";
            // 
            // txtType
            // 
            txtType.Location = new System.Drawing.Point(52, 38);
            txtType.Name = "txtType";
            txtType.Size = new System.Drawing.Size(205, 20);
            txtType.TabIndex = 11;
            txtType.ReadOnly = true;
            // 
            // StateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 519);
            this.Controls.Add(lblType);
            this.Controls.Add(txtType);
            this.Controls.Add(dgvMarkers);
            this.Controls.Add(lblMarkers);
            this.Controls.Add(btnOk);
            this.Controls.Add(dgvOutputLinks);
            this.Controls.Add(lblOutputLinks);
            this.Controls.Add(dgvInputLinks);
            this.Controls.Add(lblInputLinks);
            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = Properties.Resources.AppIcon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StateInfoForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "State Info";
            ((System.ComponentModel.ISupportInitialize)(dgvInputLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvOutputLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dgvMarkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblId;
        private TextBox txtId;
        private Label lblInputLinks;
        private DataGridView dgvInputLinks;
        private DataGridView dgvOutputLinks;
        private Label lblOutputLinks;
        private Button btnOk;
        private DataGridView dgvMarkers;
        private Label lblMarkers;
        private Label lblType;
        private TextBox txtType;
    }
}