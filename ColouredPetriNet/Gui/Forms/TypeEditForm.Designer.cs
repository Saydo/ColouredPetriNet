using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class TypeEditForm
    {
        private void InitializeComponent()
        {
            btnCancel = new Button();
            btnOk = new Button();
            lblId = new Label();
            txtId = new TextBox();
            cmbKind = new ComboBox();
            lblKind = new Label();
            lblForm = new Label();
            cmbForm = new ComboBox();
            txtName = new TextBox();
            lblName = new Label();
            pbForm = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pbForm)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(115, 137);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(65, 23);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(59, 137);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(49, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += (obj, e) => AcceptChanges();
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new System.Drawing.Point(30, 18);
            lblId.Name = "lblId";
            lblId.Size = new System.Drawing.Size(16, 13);
            lblId.TabIndex = 2;
            lblId.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new System.Drawing.Point(52, 15);
            txtId.Name = "txtId";
            txtId.Size = new System.Drawing.Size(158, 20);
            txtId.TabIndex = 3;
            txtId.ReadOnly = true;
            // 
            // cmbKind
            // 
            cmbKind.FormattingEnabled = true;
            cmbKind.Location = new System.Drawing.Point(53, 67);
            cmbKind.Name = "cmbKind";
            cmbKind.Size = new System.Drawing.Size(110, 21);
            cmbKind.TabIndex = 4;
            cmbKind.Items.Add("State");
            cmbKind.Items.Add("Transition");
            cmbKind.Items.Add("Marker");
            cmbKind.SelectedIndex = 0;
            cmbKind.SelectedIndexChanged += (obj, e) => UpdateImage();
            // 
            // lblKind
            // 
            lblKind.AutoSize = true;
            lblKind.Location = new System.Drawing.Point(19, 70);
            lblKind.Name = "lblKind";
            lblKind.Size = new System.Drawing.Size(28, 13);
            lblKind.TabIndex = 5;
            lblKind.Text = "Kind";
            // 
            // lblForm
            // 
            lblForm.AutoSize = true;
            lblForm.Location = new System.Drawing.Point(17, 97);
            lblForm.Name = "lblForm";
            lblForm.Size = new System.Drawing.Size(30, 13);
            lblForm.TabIndex = 7;
            lblForm.Text = "Form";
            // 
            // cmbForm
            // 
            cmbForm.FormattingEnabled = true;
            cmbForm.Location = new System.Drawing.Point(53, 94);
            cmbForm.Name = "cmbForm";
            cmbForm.Size = new System.Drawing.Size(110, 21);
            cmbForm.TabIndex = 6;
            cmbForm.Items.Add("Round");
            cmbForm.Items.Add("Rectangle");
            cmbForm.Items.Add("Rhomb");
            cmbForm.Items.Add("Triangle");
            cmbForm.Items.Add("Image");
            cmbForm.SelectedIndex = 0;
            cmbForm.SelectedIndexChanged += (obj, e) => UpdateImage();
            // 
            // txtName
            // 
            txtName.Location = new System.Drawing.Point(52, 41);
            txtName.Name = "txtName";
            txtName.Size = new System.Drawing.Size(158, 20);
            txtName.TabIndex = 9;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new System.Drawing.Point(11, 44);
            lblName.Name = "lblName";
            lblName.Size = new System.Drawing.Size(35, 13);
            lblName.TabIndex = 8;
            lblName.Text = "Name";
            // 
            // pbForm
            // 
            pbForm.Location = new System.Drawing.Point(170, 70);
            pbForm.Name = "pbForm";
            pbForm.Size = new System.Drawing.Size(40, 40);
            pbForm.TabIndex = 10;
            pbForm.TabStop = false;
            // 
            // TypeEditForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 173);
            this.Controls.Add(pbForm);
            this.Controls.Add(txtName);
            this.Controls.Add(lblName);
            this.Controls.Add(lblForm);
            this.Controls.Add(cmbForm);
            this.Controls.Add(lblKind);
            this.Controls.Add(cmbKind);
            this.Controls.Add(txtId);
            this.Controls.Add(lblId);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.Name = "TypeEditForm";
            this.Text = "Edit Type";
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            ((System.ComponentModel.ISupportInitialize)(pbForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btnCancel;
        private Button btnOk;
        private Label lblId;
        private TextBox txtId;
        private ComboBox cmbKind;
        private Label lblKind;
        private Label lblForm;
        private ComboBox cmbForm;
        private TextBox txtName;
        private Label lblName;
        private PictureBox pbForm;
    }
}