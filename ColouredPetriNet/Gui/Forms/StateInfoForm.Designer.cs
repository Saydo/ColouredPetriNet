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
            txtId.Location = new System.Drawing.Point(43, 12);
            txtId.Name = "txtId";
            txtId.Size = new System.Drawing.Size(214, 20);
            txtId.TabIndex = 2;
            // 
            // lblInputLinks
            // 
            lblInputLinks.AutoSize = true;
            lblInputLinks.Location = new System.Drawing.Point(16, 182);
            lblInputLinks.Name = "lblInputLinks";
            lblInputLinks.Size = new System.Drawing.Size(58, 13);
            lblInputLinks.TabIndex = 4;
            lblInputLinks.Text = "Input links:";
            // 
            // dgvInputLinks
            // 
            dgvInputLinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInputLinks.Location = new System.Drawing.Point(18, 203);
            dgvInputLinks.Name = "dgvInputLinks";
            dgvInputLinks.Size = new System.Drawing.Size(240, 102);
            dgvInputLinks.TabIndex = 5;
            // 
            // dgvOutputLinks
            // 
            dgvOutputLinks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOutputLinks.Location = new System.Drawing.Point(18, 339);
            dgvOutputLinks.Name = "dgvOutputLinks";
            dgvOutputLinks.Size = new System.Drawing.Size(240, 102);
            dgvOutputLinks.TabIndex = 7;
            // 
            // lblOutputLinks
            // 
            lblOutputLinks.AutoSize = true;
            lblOutputLinks.Location = new System.Drawing.Point(16, 318);
            lblOutputLinks.Name = "lblOutputLinks";
            lblOutputLinks.Size = new System.Drawing.Size(66, 13);
            lblOutputLinks.TabIndex = 6;
            lblOutputLinks.Text = "Output links:";
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(183, 457);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 8;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // dgvMarkers
            // 
            dgvMarkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarkers.Location = new System.Drawing.Point(18, 66);
            dgvMarkers.Name = "dgvMarkers";
            dgvMarkers.Size = new System.Drawing.Size(240, 102);
            dgvMarkers.TabIndex = 10;
            // 
            // lblMarkers
            // 
            lblMarkers.AutoSize = true;
            lblMarkers.Location = new System.Drawing.Point(16, 45);
            lblMarkers.Name = "lblMarkers";
            lblMarkers.Size = new System.Drawing.Size(48, 13);
            lblMarkers.TabIndex = 9;
            lblMarkers.Text = "Markers:";
            // 
            // StateInfoForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 490);
            this.Controls.Add(dgvMarkers);
            this.Controls.Add(lblMarkers);
            this.Controls.Add(btnOk);
            this.Controls.Add(dgvOutputLinks);
            this.Controls.Add(lblOutputLinks);
            this.Controls.Add(dgvInputLinks);
            this.Controls.Add(lblInputLinks);
            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "StateInfoForm";
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
    }
}