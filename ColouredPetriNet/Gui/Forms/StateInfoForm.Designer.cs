namespace ColouredPetriNet.Gui.Forms
{
    partial class StateInfoForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StateInfoForm));
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblInputLinks = new System.Windows.Forms.Label();
            this.dgvInputLinks = new System.Windows.Forms.DataGridView();
            this.dgvOutputLinks = new System.Windows.Forms.DataGridView();
            this.lblOutputLinks = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.dgvMarkers = new System.Windows.Forms.DataGridView();
            this.lblMarkers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(15, 15);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(16, 13);
            this.lblId.TabIndex = 3;
            this.lblId.Text = "Id";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(43, 12);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(214, 20);
            this.txtId.TabIndex = 2;
            // 
            // lblInputLinks
            // 
            this.lblInputLinks.AutoSize = true;
            this.lblInputLinks.Location = new System.Drawing.Point(16, 182);
            this.lblInputLinks.Name = "lblInputLinks";
            this.lblInputLinks.Size = new System.Drawing.Size(58, 13);
            this.lblInputLinks.TabIndex = 4;
            this.lblInputLinks.Text = "Input links:";
            this.lblInputLinks.Click += new System.EventHandler(this.label2_Click);
            // 
            // dgvInputLinks
            // 
            this.dgvInputLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputLinks.Location = new System.Drawing.Point(18, 203);
            this.dgvInputLinks.Name = "dgvInputLinks";
            this.dgvInputLinks.Size = new System.Drawing.Size(240, 102);
            this.dgvInputLinks.TabIndex = 5;
            this.dgvInputLinks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dgvOutputLinks
            // 
            this.dgvOutputLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputLinks.Location = new System.Drawing.Point(18, 339);
            this.dgvOutputLinks.Name = "dgvOutputLinks";
            this.dgvOutputLinks.Size = new System.Drawing.Size(240, 102);
            this.dgvOutputLinks.TabIndex = 7;
            this.dgvOutputLinks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // lblOutputLinks
            // 
            this.lblOutputLinks.AutoSize = true;
            this.lblOutputLinks.Location = new System.Drawing.Point(16, 318);
            this.lblOutputLinks.Name = "lblOutputLinks";
            this.lblOutputLinks.Size = new System.Drawing.Size(66, 13);
            this.lblOutputLinks.TabIndex = 6;
            this.lblOutputLinks.Text = "Output links:";
            this.lblOutputLinks.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(183, 457);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvMarkers
            // 
            this.dgvMarkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarkers.Location = new System.Drawing.Point(18, 66);
            this.dgvMarkers.Name = "dgvMarkers";
            this.dgvMarkers.Size = new System.Drawing.Size(240, 102);
            this.dgvMarkers.TabIndex = 10;
            this.dgvMarkers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // lblMarkers
            // 
            this.lblMarkers.AutoSize = true;
            this.lblMarkers.Location = new System.Drawing.Point(16, 45);
            this.lblMarkers.Name = "lblMarkers";
            this.lblMarkers.Size = new System.Drawing.Size(48, 13);
            this.lblMarkers.TabIndex = 9;
            this.lblMarkers.Text = "Markers:";
            this.lblMarkers.Click += new System.EventHandler(this.label4_Click);
            // 
            // StateInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 490);
            this.Controls.Add(this.dgvMarkers);
            this.Controls.Add(this.lblMarkers);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvOutputLinks);
            this.Controls.Add(this.lblOutputLinks);
            this.Controls.Add(this.dgvInputLinks);
            this.Controls.Add(this.lblInputLinks);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StateInfoForm";
            this.Text = "State Info";
            this.Load += new System.EventHandler(this.StateInfoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblInputLinks;
        private System.Windows.Forms.DataGridView dgvInputLinks;
        private System.Windows.Forms.DataGridView dgvOutputLinks;
        private System.Windows.Forms.Label lblOutputLinks;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridView dgvMarkers;
        private System.Windows.Forms.Label lblMarkers;
    }
}