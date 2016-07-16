namespace ColouredPetriNet.Gui.Forms
{
    partial class TransitionInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransitionInfoForm));
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblInputLinks = new System.Windows.Forms.Label();
            this.dgvInputLinks = new System.Windows.Forms.DataGridView();
            this.dgvOutputLinks = new System.Windows.Forms.DataGridView();
            this.lblOutputLinks = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputLinks)).BeginInit();
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
            this.lblInputLinks.Location = new System.Drawing.Point(15, 51);
            this.lblInputLinks.Name = "lblInputLinks";
            this.lblInputLinks.Size = new System.Drawing.Size(58, 13);
            this.lblInputLinks.TabIndex = 4;
            this.lblInputLinks.Text = "Input links:";
            // 
            // dgvInputLinks
            // 
            this.dgvInputLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputLinks.Location = new System.Drawing.Point(17, 72);
            this.dgvInputLinks.Name = "dgvInputLinks";
            this.dgvInputLinks.Size = new System.Drawing.Size(240, 102);
            this.dgvInputLinks.TabIndex = 5;
            // 
            // dgvOutputLinks
            // 
            this.dgvOutputLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputLinks.Location = new System.Drawing.Point(17, 208);
            this.dgvOutputLinks.Name = "dgvOutputLinks";
            this.dgvOutputLinks.Size = new System.Drawing.Size(240, 102);
            this.dgvOutputLinks.TabIndex = 7;
            // 
            // lblOutputLinks
            // 
            this.lblOutputLinks.AutoSize = true;
            this.lblOutputLinks.Location = new System.Drawing.Point(15, 187);
            this.lblOutputLinks.Name = "lblOutputLinks";
            this.lblOutputLinks.Size = new System.Drawing.Size(66, 13);
            this.lblOutputLinks.TabIndex = 6;
            this.lblOutputLinks.Text = "Output links:";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(182, 326);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 8;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // TransitionInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 361);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgvOutputLinks);
            this.Controls.Add(this.lblOutputLinks);
            this.Controls.Add(this.dgvInputLinks);
            this.Controls.Add(this.lblInputLinks);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransitionInfoForm";
            this.Text = "Transition Info";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputLinks)).EndInit();
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
    }
}