namespace ColouredPetriNet.Gui
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mniFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mniView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbMove = new System.Windows.Forms.ToolStripButton();
            this.tsbAddState = new System.Windows.Forms.ToolStripButton();
            this.tsbAddTransition = new System.Windows.Forms.ToolStripButton();
            this.tsbAddMarker = new System.Windows.Forms.ToolStripButton();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveMarker = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOneStepSimulation = new System.Windows.Forms.ToolStripButton();
            this.tsbRunSimulation = new System.Windows.Forms.ToolStripButton();
            this.tsbStopSimulation = new System.Windows.Forms.ToolStripButton();
            this.pbMap = new System.Windows.Forms.PictureBox();
            this.stsStatus = new System.Windows.Forms.StatusStrip();
            this.trvStates = new System.Windows.Forms.TreeView();
            this.trvTransitions = new System.Windows.Forms.TreeView();
            this.lblStates = new System.Windows.Forms.Label();
            this.lblTransitions = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniFile,
            this.mniMap,
            this.mniView,
            this.mniAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(489, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mniFile
            // 
            this.mniFile.Name = "mniFile";
            this.mniFile.Size = new System.Drawing.Size(37, 20);
            this.mniFile.Text = "File";
            // 
            // mniMap
            // 
            this.mniMap.Name = "mniMap";
            this.mniMap.Size = new System.Drawing.Size(43, 20);
            this.mniMap.Text = "Map";
            // 
            // mniView
            // 
            this.mniView.Name = "mniView";
            this.mniView.Size = new System.Drawing.Size(44, 20);
            this.mniView.Text = "View";
            // 
            // mniAbout
            // 
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(52, 20);
            this.mniAbout.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbView,
            this.tsbMove,
            this.tsbAddState,
            this.tsbAddTransition,
            this.tsbAddMarker,
            this.tsbRemove,
            this.tsbRemoveMarker,
            this.toolStripSeparator1,
            this.tsbOneStepSimulation,
            this.tsbRunSimulation,
            this.tsbStopSimulation});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(489, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbView
            // 
            this.tsbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(23, 22);
            this.tsbView.Text = "toolStripButton1";
            // 
            // tsbMove
            // 
            this.tsbMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMove.Image = ((System.Drawing.Image)(resources.GetObject("tsbMove.Image")));
            this.tsbMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMove.Name = "tsbMove";
            this.tsbMove.Size = new System.Drawing.Size(23, 22);
            this.tsbMove.Text = "toolStripButton2";
            // 
            // tsbAddState
            // 
            this.tsbAddState.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddState.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddState.Image")));
            this.tsbAddState.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddState.Name = "tsbAddState";
            this.tsbAddState.Size = new System.Drawing.Size(23, 22);
            this.tsbAddState.Text = "toolStripButton3";
            // 
            // tsbAddTransition
            // 
            this.tsbAddTransition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddTransition.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddTransition.Image")));
            this.tsbAddTransition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddTransition.Name = "tsbAddTransition";
            this.tsbAddTransition.Size = new System.Drawing.Size(23, 22);
            this.tsbAddTransition.Text = "toolStripButton4";
            // 
            // tsbAddMarker
            // 
            this.tsbAddMarker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddMarker.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddMarker.Image")));
            this.tsbAddMarker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddMarker.Name = "tsbAddMarker";
            this.tsbAddMarker.Size = new System.Drawing.Size(23, 22);
            this.tsbAddMarker.Text = "toolStripButton5";
            // 
            // tsbRemove
            // 
            this.tsbRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemove.Image")));
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(23, 22);
            this.tsbRemove.Text = "removeToolStripButton";
            // 
            // tsbRemoveMarker
            // 
            this.tsbRemoveMarker.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRemoveMarker.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveMarker.Image")));
            this.tsbRemoveMarker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveMarker.Name = "tsbRemoveMarker";
            this.tsbRemoveMarker.Size = new System.Drawing.Size(23, 22);
            this.tsbRemoveMarker.Text = "removeMarkerToolStripButton";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOneStepSimulation
            // 
            this.tsbOneStepSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOneStepSimulation.Image = ((System.Drawing.Image)(resources.GetObject("tsbOneStepSimulation.Image")));
            this.tsbOneStepSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOneStepSimulation.Name = "tsbOneStepSimulation";
            this.tsbOneStepSimulation.Size = new System.Drawing.Size(23, 22);
            this.tsbOneStepSimulation.Text = "toolStripButton9";
            // 
            // tsbRunSimulation
            // 
            this.tsbRunSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRunSimulation.Image = ((System.Drawing.Image)(resources.GetObject("tsbRunSimulation.Image")));
            this.tsbRunSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRunSimulation.Name = "tsbRunSimulation";
            this.tsbRunSimulation.Size = new System.Drawing.Size(23, 22);
            this.tsbRunSimulation.Text = "toolStripButton10";
            // 
            // tsbStopSimulation
            // 
            this.tsbStopSimulation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStopSimulation.Image = ((System.Drawing.Image)(resources.GetObject("tsbStopSimulation.Image")));
            this.tsbStopSimulation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStopSimulation.Name = "tsbStopSimulation";
            this.tsbStopSimulation.Size = new System.Drawing.Size(23, 22);
            this.tsbStopSimulation.Text = "toolStripButton11";
            // 
            // pbMap
            // 
            this.pbMap.Location = new System.Drawing.Point(13, 53);
            this.pbMap.Name = "pbMap";
            this.pbMap.Size = new System.Drawing.Size(340, 243);
            this.pbMap.TabIndex = 2;
            this.pbMap.TabStop = false;
            // 
            // stsStatus
            // 
            this.stsStatus.Location = new System.Drawing.Point(0, 309);
            this.stsStatus.Name = "stsStatus";
            this.stsStatus.Size = new System.Drawing.Size(489, 22);
            this.stsStatus.TabIndex = 3;
            this.stsStatus.Text = "statusStrip1";
            // 
            // trvStates
            // 
            this.trvStates.Location = new System.Drawing.Point(360, 71);
            this.trvStates.Name = "trvStates";
            this.trvStates.Size = new System.Drawing.Size(121, 105);
            this.trvStates.TabIndex = 4;
            // 
            // trvTransitions
            // 
            this.trvTransitions.Location = new System.Drawing.Point(360, 195);
            this.trvTransitions.Name = "trvTransitions";
            this.trvTransitions.Size = new System.Drawing.Size(121, 101);
            this.trvTransitions.TabIndex = 5;
            // 
            // lblStates
            // 
            this.lblStates.AutoSize = true;
            this.lblStates.Location = new System.Drawing.Point(360, 52);
            this.lblStates.Name = "lblStates";
            this.lblStates.Size = new System.Drawing.Size(37, 13);
            this.lblStates.TabIndex = 6;
            this.lblStates.Text = "States";
            // 
            // lblTransitions
            // 
            this.lblTransitions.AutoSize = true;
            this.lblTransitions.Location = new System.Drawing.Point(360, 179);
            this.lblTransitions.Name = "lblTransitions";
            this.lblTransitions.Size = new System.Drawing.Size(58, 13);
            this.lblTransitions.TabIndex = 7;
            this.lblTransitions.Text = "Transitions";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 331);
            this.Controls.Add(this.lblTransitions);
            this.Controls.Add(this.lblStates);
            this.Controls.Add(this.trvTransitions);
            this.Controls.Add(this.trvStates);
            this.Controls.Add(this.stsStatus);
            this.Controls.Add(this.pbMap);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Coloured Petri Net";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniFile;
        private System.Windows.Forms.ToolStripMenuItem mniMap;
        private System.Windows.Forms.ToolStripMenuItem mniView;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.ToolStripButton tsbMove;
        private System.Windows.Forms.ToolStripButton tsbAddState;
        private System.Windows.Forms.ToolStripButton tsbAddTransition;
        private System.Windows.Forms.ToolStripButton tsbAddMarker;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripButton tsbRemoveMarker;
        private System.Windows.Forms.PictureBox pbMap;
        private System.Windows.Forms.StatusStrip stsStatus;
        private System.Windows.Forms.TreeView trvStates;
        private System.Windows.Forms.TreeView trvTransitions;
        private System.Windows.Forms.Label lblStates;
        private System.Windows.Forms.Label lblTransitions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbOneStepSimulation;
        private System.Windows.Forms.ToolStripButton tsbRunSimulation;
        private System.Windows.Forms.ToolStripButton tsbStopSimulation;
    }
}