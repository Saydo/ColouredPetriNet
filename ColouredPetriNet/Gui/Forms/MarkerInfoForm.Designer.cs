using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class MarkerInfoForm
    {
        private void InitializeComponent()
        {
            txtId = new TextBox();
            lblId = new Label();
            lblStateId = new Label();
            txtStateId = new TextBox();
            btnOk = new Button();
            this.SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new System.Drawing.Point(67, 12);
            txtId.Name = "txtId";
            txtId.Size = new System.Drawing.Size(142, 20);
            txtId.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new System.Drawing.Point(17, 15);
            lblId.Name = "lblId";
            lblId.Size = new System.Drawing.Size(16, 13);
            lblId.TabIndex = 1;
            lblId.Text = "Id";
            // 
            // lblStateId
            // 
            lblStateId.AutoSize = true;
            lblStateId.Location = new System.Drawing.Point(17, 41);
            lblStateId.Name = "lblStateId";
            lblStateId.Size = new System.Drawing.Size(44, 13);
            lblStateId.TabIndex = 3;
            lblStateId.Text = "State Id";
            // 
            // txtStateId
            // 
            txtStateId.Location = new System.Drawing.Point(67, 38);
            txtStateId.Name = "txtStateId";
            txtStateId.Size = new System.Drawing.Size(142, 20);
            txtStateId.TabIndex = 2;
            txtStateId.TextChanged += new System.EventHandler(textBox2_TextChanged);
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(134, 77);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // MarkerInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 112);
            this.Controls.Add(btnOk);
            this.Controls.Add(lblStateId);
            this.Controls.Add(txtStateId);
            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "MarkerInfoForm";
            this.Text = "Marker Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox txtId;
        private Label lblId;
        private Label lblStateId;
        private TextBox txtStateId;
        private Button btnOk;
    }
}