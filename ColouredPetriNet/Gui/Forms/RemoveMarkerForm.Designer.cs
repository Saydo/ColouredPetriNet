using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class RemoveMarkerForm
    {
        private void InitializeComponent()
        {
            dgvMarkers = new DataGridView();
            btnClear = new Button();
            btnRemove = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)(dgvMarkers)).BeginInit();
            this.SuspendLayout();
            //
            // dgvMarkers
            //
            dgvMarkers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarkers.Location = new System.Drawing.Point(13, 13);
            dgvMarkers.Name = "dgvMarkers";
            dgvMarkers.Size = new System.Drawing.Size(225, 137);
            dgvMarkers.TabIndex = 0;
            //
            // btnClear
            //
            btnClear.Location = new System.Drawing.Point(13, 156);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(66, 23);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += (obj, e) => ClearMarkers();
            //
            // btnRemove
            //
            btnRemove.Location = new System.Drawing.Point(85, 156);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(76, 23);
            btnRemove.TabIndex = 2;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += (obj, e) => RemoveMarkers();
            //
            // btnCancel
            //
            btnCancel.Location = new System.Drawing.Point(167, 156);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(71, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            //
            // RemoveMarkerForm
            //
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 190);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnRemove);
            this.Controls.Add(btnClear);
            this.Controls.Add(dgvMarkers);
            this.Icon = Properties.Resources.AppIcon;
            this.Name = "RemoveMarkerForm";
            this.Text = "RemoveMarkerForm";
            ((System.ComponentModel.ISupportInitialize)(dgvMarkers)).EndInit();
            this.ResumeLayout(false);

        }

        private DataGridView dgvMarkers;
        private Button btnClear;
        private Button btnRemove;
        private Button btnCancel;
    }
}