using System.Windows.Forms;

namespace ColouredPetriNet.Gui.Forms
{
    partial class SelectImageForm
    {
        private void InitializeComponent()
        {
            btnAdd = new Button();
            lstImages = new ListView();
            btnCancel = new Button();
            btnOk = new Button();
            btnRemove = new Button();
            btnClear = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new System.Drawing.Point(18, 195);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(72, 23);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += (obj, e) => Add();
            // 
            // lstImages
            // 
            lstImages.Location = new System.Drawing.Point(12, 12);
            lstImages.Name = "lstImages";
            lstImages.Size = new System.Drawing.Size(244, 177);
            lstImages.TabIndex = 5;
            lstImages.UseCompatibleStateImageBehavior = false;
            // 
            // btnCancel
            // 
            btnCancel.Location = new System.Drawing.Point(181, 236);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (obj, e) => this.Close();
            // 
            // btnOk
            // 
            btnOk.Location = new System.Drawing.Point(125, 236);
            btnOk.Name = "btnOk";
            btnOk.Size = new System.Drawing.Size(50, 23);
            btnOk.TabIndex = 8;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new System.Drawing.Point(97, 195);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new System.Drawing.Size(72, 23);
            btnRemove.TabIndex = 9;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += (obj, e) => Remove();
            // 
            // btnClear
            // 
            btnClear.Location = new System.Drawing.Point(175, 195);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(72, 23);
            btnClear.TabIndex = 10;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += (obj, e) => Clear();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(18, 225);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(72, 44);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // SelectBackgroudImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 271);
            this.Controls.Add(pictureBox1);
            this.Controls.Add(btnClear);
            this.Controls.Add(btnRemove);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);
            this.Controls.Add(btnAdd);
            this.Controls.Add(lstImages);
            this.Name = "SelectImageForm";
            this.Text = "Select Image";
            ((System.ComponentModel.ISupportInitialize)(pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private Button btnAdd;
        private ListView lstImages;
        private Button btnCancel;
        private Button btnOk;
        private Button btnRemove;
        private Button btnClear;
        private PictureBox pictureBox1;
    }
}