using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class MarkerInfoForm
    {
        private void InitializeComponent()
        {
            lblId = new Label();
            lblStateId = new Label();
            lblType = new Label();
            txtId = new TextBox();
            txtStateId = new TextBox();
            txtType = new TextBox();
            btnOk = new Button();
            this.SuspendLayout();
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
            // txtId
            // 
            txtId.Location = new System.Drawing.Point(67, 12);
            txtId.Name = "txtId";
            txtId.Size = new System.Drawing.Size(142, 20);
            txtId.TabIndex = 0;
            txtId.ReadOnly = true;
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
            txtStateId.ReadOnly = true;
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.Location = new System.Drawing.Point(17, 67);
            lblType.Name = "lblType";
            lblType.Size = new System.Drawing.Size(44, 13);
            lblType.Text = "Type";
            // 
            // txtType
            // 
            txtType.Location = new System.Drawing.Point(67, 64);
            txtType.Name = "txtType";
            txtType.Size = new System.Drawing.Size(142, 20);
            txtType.ReadOnly = true;
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(134, 103);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(75, 23);
            btnOk.TabIndex = 4;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += (obj, e) => this.Close();
            // 
            // MarkerInfoForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 138);
            this.Controls.Add(btnOk);
            this.Controls.Add(lblStateId);
            this.Controls.Add(txtStateId);
            this.Controls.Add(lblId);
            this.Controls.Add(txtId);
            this.Controls.Add(lblType);
            this.Controls.Add(txtType);
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            this.Name = "MarkerInfoForm";
            this.Text = "Marker Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblId;
        private Label lblStateId;
        private Label lblType;
        private TextBox txtId;
        private TextBox txtStateId;
        private TextBox txtType;
        private Button btnOk;
    }
}