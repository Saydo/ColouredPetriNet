using System.Windows.Forms;
using System.Drawing;

namespace ColouredPetriNet.Gui.Forms
{
    partial class MainForm
    {
        private void InitializeComponent()
        {
            mnsMain = new MenuStrip();
            mniFile = new ToolStripMenuItem();
            mniOpen = new ToolStripMenuItem();
            mniSave = new ToolStripMenuItem();
            mniSaveAs = new ToolStripMenuItem();
            mniExit = new ToolStripMenuItem();
            mniMap = new ToolStripMenuItem();
            mniSetMode = new ToolStripMenuItem();
            mniSetModeView = new ToolStripMenuItem();
            mniSetModeMove = new ToolStripMenuItem();
            mniSetModeAddState = new ToolStripMenuItem();
            mniSetModeAddRoundState = new ToolStripMenuItem();
            mniSetModeAddImageState = new ToolStripMenuItem();
            mniSetModeAddTransition = new ToolStripMenuItem();
            mniSetModeAddRectangleTransition = new ToolStripMenuItem();
            mniSetModeAddRhombTransition = new ToolStripMenuItem();
            mniSetModeAddMarker = new ToolStripMenuItem();
            mniSetModeAddRoundMarker = new ToolStripMenuItem();
            mniSetModeAddRhombMarker = new ToolStripMenuItem();
            mniSetModeAddTriangleMarker = new ToolStripMenuItem();
            mniSetModeAddLink = new ToolStripMenuItem();
            mniSetModeRemove = new ToolStripMenuItem();
            mniSetModeRemoveMarker = new ToolStripMenuItem();
            mniShowInfo = new ToolStripMenuItem();
            mniShowStateInfo = new ToolStripMenuItem();
            mniShowTransitionInfo = new ToolStripMenuItem();
            mniShowMarkerInfo = new ToolStripMenuItem();
            mniView = new ToolStripMenuItem();
            mniSelectionMode = new ToolStripMenuItem();
            mniSelectionModeFull = new ToolStripMenuItem();
            mniSelectionModePartial = new ToolStripMenuItem();
            mniItemStyle = new ToolStripMenuItem();
            mniStateStyle = new ToolStripMenuItem();
            mniTransitionStyle = new ToolStripMenuItem();
            mniMarkerStyle = new ToolStripMenuItem();
            mniLinkStyle = new ToolStripMenuItem();
            mniBackground = new ToolStripMenuItem();
            mniAbout = new ToolStripMenuItem();
            tlsMain = new ToolStrip();
            tsbView = new ToolStripButton();
            tsbMove = new ToolStripButton();
            imageListAddState = new StripImageList();
            imageListAddTransition = new StripImageList();
            imageListAddMarker = new StripImageList();
            tsbAddLink = new ToolStripButton();
            tsbRemove = new ToolStripButton();
            tsbRemoveMarker = new ToolStripButton();
            tsSeparator1 = new ToolStripSeparator();
            tsbOneStepSimulation = new ToolStripButton();
            tsbRunSimulation = new ToolStripButton();
            tsbStopSimulation = new ToolStripButton();

            pbMap = new PictureBox();
            stsStatus = new StatusStrip();
            trvStates = new TreeView();
            trvTransitions = new TreeView();
            lblStates = new Label();
            lblTransitions = new Label();

            mnsMain.SuspendLayout();
            tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMap)).BeginInit();
            SuspendLayout();
            //
            // Main (MenuStrip)
            //
            mnsMain.Name = "mnsMain";
            mnsMain.Size = new Size(489, 24);
            mnsMain.Location = new Point(0, 0);
            mnsMain.Items.AddRange(new ToolStripItem[] {
                mniFile,
                mniMap,
                mniView,
                mniAbout
            });
            mnsMain.TabIndex = 0;
            mnsMain.Text = "Main Menu";
            //
            // File (ToolStripMenuItem)
            //
            mniFile.Name = "mniFile";
            mniFile.Size = new Size(37, 20);
            mniFile.Text = "File";
            mniFile.DropDownItems.AddRange(new ToolStripItem[] {
                mniOpen,
                mniSave,
                mniSaveAs,
                mniExit
            });
            //
            // Open (ToolStripMenuItem)
            //
            mniOpen.Name = "mniOpen";
            mniOpen.Size = new Size(152, 22);
            mniOpen.Text = "Open";
            //
            // Save (ToolStripMenuItem)
            //
            mniSave.Name = "mniSave";
            mniSave.Size = new Size(152, 22);
            mniSave.Text = "Save";
            //
            // SaveAs (ToolStripMenuItem)
            //
            mniSaveAs.Name = "mniSaveAs";
            mniSaveAs.Size = new Size(152, 22);
            mniSaveAs.Text = "Save As...";
            //
            // Exit (ToolStripMenuItem)
            //
            mniExit.Name = "mniExit";
            mniExit.Size = new Size(152, 22);
            mniExit.Text = "Exit";
            //
            // Map (ToolStripMenuItem)
            //
            mniMap.Name = "mniMap";
            mniMap.Size = new Size(43, 20);
            mniMap.Text = "Map";
            mniMap.DropDownItems.AddRange(new ToolStripItem[] {
                mniSetMode,
                mniShowInfo
            });
            //
            // SetMode (ToolStripMenuItem)
            //
            mniSetMode.Name = "mniSetMode";
            mniSetMode.Size = new Size(152, 22);
            mniSetMode.Text = "Set Mode";
            mniSetMode.DropDownItems.AddRange(new ToolStripItem[] {
                mniSetModeView,
                mniSetModeMove,
                mniSetModeAddState,
                mniSetModeAddTransition,
                mniSetModeAddMarker,
                mniSetModeAddLink,
                mniSetModeRemove,
                mniSetModeRemoveMarker
            });
            //
            // SetModeView (ToolStripMenuItem)
            //
            mniSetModeView.Name = "mniSetModeView";
            mniSetModeView.Size = new Size(152, 22);
            mniSetModeView.Text = "View";
            //
            // SetModeMove (ToolStripMenuItem)
            //
            mniSetModeMove.Name = "mniSetModeMove";
            mniSetModeMove.Size = new Size(152, 22);
            mniSetModeMove.Text = "Move";
            //
            // SetModeAddState (ToolStripMenuItem)
            //
            mniSetModeAddState.Name = "mniSetModeAddState";
            mniSetModeAddState.Size = new Size(152, 22);
            mniSetModeAddState.Text = "Add State";
            mniSetModeAddState.DropDownItems.AddRange(new ToolStripItem[] {
                mniSetModeAddRoundState,
                mniSetModeAddImageState
            });
            //
            // SetModeAddRoundState (ToolStripMenuItem)
            //
            mniSetModeAddRoundState.Name = "mniSetModeAddRoundState";
            mniSetModeAddRoundState.Size = new Size(152, 22);
            mniSetModeAddRoundState.Text = "Round State";
            //
            // SetModeAddImageState (ToolStripMenuItem)
            //
            mniSetModeAddImageState.Name = "mniSetModeAddImageState";
            mniSetModeAddImageState.Size = new Size(152, 22);
            mniSetModeAddImageState.Text = "Image State";
            //
            // SetModeAddTransition (ToolStripMenuItem)
            //
            mniSetModeAddTransition.Name = "mniSetModeAddTransition";
            mniSetModeAddTransition.Size = new Size(152, 22);
            mniSetModeAddTransition.Text = "Add Transition";
            mniSetModeAddTransition.DropDownItems.AddRange(new ToolStripItem[] {
                mniSetModeAddRectangleTransition,
                mniSetModeAddRhombTransition
            });
            //
            // SetModeAddRectangleTransition (ToolStripMenuItem)
            //
            mniSetModeAddRectangleTransition.Name = "mniSetModeAddRectangleTransition";
            mniSetModeAddRectangleTransition.Size = new Size(152, 22);
            mniSetModeAddRectangleTransition.Text = "Rectangle Transition";
            //
            // SetModeAddRhombTransition (ToolStripMenuItem)
            //
            mniSetModeAddRhombTransition.Name = "mniSetModeAddRhombTransition";
            mniSetModeAddRhombTransition.Size = new Size(152, 22);
            mniSetModeAddRhombTransition.Text = "Rhomb Transition";
            //
            // SetModeAddMarker (ToolStripMenuItem)
            //
            mniSetModeAddMarker.Name = "mniSetModeAddMarker";
            mniSetModeAddMarker.Size = new Size(152, 22);
            mniSetModeAddMarker.Text = "Add Marker";
            mniSetModeAddMarker.DropDownItems.AddRange(new ToolStripItem[] {
                mniSetModeAddRoundMarker,
                mniSetModeAddRhombMarker,
                mniSetModeAddTriangleMarker
            });
            //
            // SetModeAddRoundMarker (ToolStripMenuItem)
            //
            mniSetModeAddRoundMarker.Name = "mniSetModeAddRoundMarker";
            mniSetModeAddRoundMarker.Size = new Size(152, 22);
            mniSetModeAddRoundMarker.Text = "Round Marker";
            //
            // SetModeAddRhombMarker (ToolStripMenuItem)
            //
            mniSetModeAddRhombMarker.Name = "mniSetModeAddRhombMarker";
            mniSetModeAddRhombMarker.Size = new Size(152, 22);
            mniSetModeAddRhombMarker.Text = "Rhomb Marker";
            //
            // SetModeAddTriangleMarker (ToolStripMenuItem)
            //
            mniSetModeAddTriangleMarker.Name = "mniSetModeAddTriangleMarker";
            mniSetModeAddTriangleMarker.Size = new Size(152, 22);
            mniSetModeAddTriangleMarker.Text = "Triangle Marker";
            //
            // SetModeAddLink (ToolStripMenuItem)
            //
            mniSetModeAddLink.Name = "mniSetModeAddLink";
            mniSetModeAddLink.Size = new Size(152, 22);
            mniSetModeAddLink.Text = "Add Link";
            //
            // SetModeRemove (ToolStripMenuItem)
            //
            mniSetModeRemove.Name = "mniSetModeRemove";
            mniSetModeRemove.Size = new Size(152, 22);
            mniSetModeRemove.Text = "Remove";
            //
            // SetModeRemoveMarker (ToolStripMenuItem)
            //
            mniSetModeRemoveMarker.Name = "mniSetModeRemoveMarker";
            mniSetModeRemoveMarker.Size = new Size(152, 22);
            mniSetModeRemoveMarker.Text = "Remove Marker";
            //
            // ShowInfo (ToolStripMenuItem)
            //
            mniShowInfo.Name = "mniShowInfo";
            mniShowInfo.Size = new Size(152, 22);
            mniShowInfo.Text = "Show Info";
            mniShowInfo.DropDownItems.AddRange(new ToolStripItem[] {
                mniShowStateInfo,
                mniShowTransitionInfo,
                mniShowMarkerInfo
            });
            //
            // ShowStateInfo (ToolStripMenuItem)
            //
            mniShowStateInfo.Name = "mniShowStateInfo";
            mniShowStateInfo.Size = new Size(152, 22);
            mniShowStateInfo.Text = "About State";
            //
            // ShowTransitionInfo (ToolStripMenuItem)
            //
            mniShowTransitionInfo.Name = "mniShowTransitionInfo";
            mniShowTransitionInfo.Size = new Size(152, 22);
            mniShowTransitionInfo.Text = "About Transition";
            //
            // ShowMarkerInfo (ToolStripMenuItem)
            //
            mniShowMarkerInfo.Name = "mniShowMarkerInfo";
            mniShowMarkerInfo.Size = new Size(152, 22);
            mniShowMarkerInfo.Text = "About Marker";
            //
            // View (ToolStripMenuItem)
            //
            mniView.Name = "mniView";
            mniView.Size = new Size(44, 20);
            mniView.Text = "View";
            mniView.DropDownItems.AddRange(new ToolStripItem[] {
                mniSelectionMode,
                mniItemStyle,
                mniBackground
            });
            //
            // SelectionMode (ToolStripMenuItem)
            //
            mniSelectionMode.Name = "mniSelectionMode";
            mniSelectionMode.Size = new Size(152, 22);
            mniSelectionMode.Text = "Selection Mode";
            mniSelectionMode.DropDownItems.AddRange(new ToolStripItem[] {
                mniSelectionModeFull,
                mniSelectionModePartial
            });
            //
            // SelectionModeFull (ToolStripMenuItem)
            //
            mniSelectionModeFull.Name = "mniSelectionModeFull";
            mniSelectionModeFull.Size = new Size(152, 22);
            mniSelectionModeFull.Text = "Full";
            //
            // SelectionModePartial (ToolStripMenuItem)
            //
            mniSelectionModePartial.Name = "mniSelectionModePartial";
            mniSelectionModePartial.Size = new Size(152, 22);
            mniSelectionModePartial.Text = "Partial";
            mniSelectionModePartial.Checked = true;
            //
            // ItemStyle (ToolStripMenuItem)
            //
            mniItemStyle.Name = "mniItemStyle";
            mniItemStyle.Size = new Size(152, 22);
            mniItemStyle.Text = "Item Style";
            mniItemStyle.DropDownItems.AddRange(new ToolStripItem[] {
                mniStateStyle,
                mniTransitionStyle,
                mniMarkerStyle,
                mniLinkStyle
            });
            //
            // StateStyle (ToolStripMenuItem)
            //
            mniStateStyle.Name = "mniStateStyle";
            mniStateStyle.Size = new Size(152, 22);
            mniStateStyle.Text = "States";
            //
            // TransitionStyle (ToolStripMenuItem)
            //
            mniTransitionStyle.Name = "mniTransitionStyle";
            mniTransitionStyle.Size = new Size(152, 22);
            mniTransitionStyle.Text = "Transitions";
            //
            // MarkerStyle (ToolStripMenuItem)
            //
            mniMarkerStyle.Name = "mniMarkerStyle";
            mniMarkerStyle.Size = new Size(152, 22);
            mniMarkerStyle.Text = "Markers";
            //
            // mniLinkStyle (ToolStripMenuItem)
            //
            mniLinkStyle.Name = "mniLinkStyle";
            mniLinkStyle.Size = new Size(152, 22);
            mniLinkStyle.Text = "Links";
            //
            // Background (ToolStripMenuItem)
            //
            mniBackground.Name = "mniBackground";
            mniBackground.Size = new Size(152, 22);
            mniBackground.Text = "Background";
            //
            // About (ToolStripMenuItem)
            //
            mniAbout.Name = "mniAbout";
            mniAbout.Size = new Size(52, 20);
            mniAbout.Text = "About";
            //
            // Main (ToolStrip)
            //
            tlsMain.Name = "tlsMain";
            tlsMain.Size = new Size(489, 25);
            tlsMain.Location = new Point(0, 24);
            tlsMain.Items.AddRange(new ToolStripItem[] {
                tsbView,
                tsbMove,
                imageListAddState,
                imageListAddTransition,
                imageListAddMarker,
                tsbAddLink,
                tsbRemove,
                tsbRemoveMarker,
                tsSeparator1,
                tsbOneStepSimulation,
                tsbRunSimulation,
                tsbStopSimulation
            });
            tlsMain.TabIndex = 1;
            tlsMain.Text = "Main ToolStrip";
            //
            // View (ToolStripButton)
            //
            tsbView.Name = "tsbView";
            tsbView.Size = new Size(23, 22);
            tsbView.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbView.Image = Properties.Resources.ViewIcon;
            tsbView.Text = "View";
            tsbView.Click += (obj, e) => SetItemMapMode(ItemMapMode.View);
            //
            // Move (ToolStripButton)
            //
            tsbMove.Name = "tsbMove";
            tsbMove.Size = new Size(23, 22);
            tsbMove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbMove.Image = Properties.Resources.MoveIcon;
            tsbMove.Text = "Move";
            tsbMove.Click += (obj, e) => SetItemMapMode(ItemMapMode.Move);
            //
            // imageListAddState (StripImageList)
            //
            imageListAddState.Name = "imageListAddState";
            imageListAddState.Size = new Size(33, 22);
            imageListAddState.AddItem(Properties.Resources.AddRoundStateIcon, "Add Round State");
            imageListAddState.AddItem(Properties.Resources.AddImageStateIcon, "Add Image State");
            imageListAddState.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddState);
            imageListAddState.DropDown.Items[0].Click += (obj, e) => SetNewStateType(Core.ColouredStateType.RoundState);
            imageListAddState.DropDown.Items[1].Click += (obj, e) => SetNewStateType(Core.ColouredStateType.ImageState);
            //
            // imageListAddTransition (StripImageList)
            //
            imageListAddTransition.Name = "imageListAddTransition";
            imageListAddTransition.Size = new Size(33, 22);
            imageListAddTransition.AddItem(Properties.Resources.AddRectangleTransitionIcon, "Add Rectangle Transition");
            imageListAddTransition.AddItem(Properties.Resources.AddRhombTransitionIcon, "Add Rhomb Transition");
            imageListAddTransition.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddTransition);
            imageListAddTransition.DropDown.Items[0].Click += (obj, e) => SetNewTransitionType(Core.ColouredTransitionType.RectangleTransition);
            imageListAddTransition.DropDown.Items[1].Click += (obj, e) => SetNewTransitionType(Core.ColouredTransitionType.RhombTransition);
            //
            // imageListAddMarker (StripImageList)
            //
            imageListAddMarker.Name = "imageListAddMarker";
            imageListAddMarker.Size = new Size(33, 22);
            imageListAddMarker.AddItem(Properties.Resources.AddRoundMarkerIcon, "Add Round Marker");
            imageListAddMarker.AddItem(Properties.Resources.AddRhombMarkerIcon, "Add Rhomb Marker");
            imageListAddMarker.AddItem(Properties.Resources.AddTriangleMarkerIcon, "Add Triangle Marker");
            imageListAddMarker.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddMarker);
            imageListAddMarker.DropDown.Items[0].Click += (obj, e) => SetNewMarkerType(Core.ColouredMarkerType.RoundMarker);
            imageListAddMarker.DropDown.Items[1].Click += (obj, e) => SetNewMarkerType(Core.ColouredMarkerType.RhombMarker);
            imageListAddMarker.DropDown.Items[2].Click += (obj, e) => SetNewMarkerType(Core.ColouredMarkerType.TriangleMarker);
            //
            // AddLink (ToolStripButton)
            //
            tsbAddLink.Name = "tsbAddLink";
            tsbAddLink.Size = new Size(23, 22);
            tsbAddLink.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddLink.Image = Properties.Resources.AddLinkIcon;
            tsbAddLink.Text = "Add Link";
            tsbAddLink.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddLink);
            //
            // Remove (ToolStripButton)
            //
            tsbRemove.Name = "tsbRemove";
            tsbRemove.Size = new Size(23, 22);
            tsbRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRemove.Image = Properties.Resources.RemoveIcon;
            tsbRemove.Text = "Remove";
            tsbRemove.Click += (obj, e) => SetItemMapMode(ItemMapMode.Remove);
            //
            // RemoveMarker (ToolStripButton)
            //
            tsbRemoveMarker.Name = "tsbRemoveMarker";
            tsbRemoveMarker.Size = new Size(23, 22);
            tsbRemoveMarker.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRemoveMarker.Image = Properties.Resources.RemoveMarkerIcon;
            tsbRemoveMarker.Text = "Remove Marker";
            tsbRemoveMarker.Click += (obj, e) => SetItemMapMode(ItemMapMode.RemoveMarker);
            //
            // tsSeparator1 (ToolStripSeparator)
            //
            tsSeparator1.Name = "tsSeparator1";
            tsSeparator1.Size = new Size(6, 25);
            //
            // tsbOneStepSimulation (ToolStripButton)
            //
            tsbOneStepSimulation.Name = "tsbOneStepSimulation";
            tsbOneStepSimulation.Size = new Size(23, 22);
            tsbOneStepSimulation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOneStepSimulation.Image = Properties.Resources.AddImageStateIcon;
            tsbOneStepSimulation.Text = "One Step Simulation";
            //
            // tsbRunSimulation (ToolStripButton)
            //
            tsbRunSimulation.Name = "tsbRunSimulation";
            tsbRunSimulation.Size = new Size(23, 22);
            tsbRunSimulation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRunSimulation.Image = Properties.Resources.AddImageStateIcon;
            tsbRunSimulation.Text = "Run Simulation";
            //
            // tsbStopSimulation (ToolStripButton)
            //
            tsbStopSimulation.Name = "tsbStopSimulation";
            tsbStopSimulation.Size = new Size(23, 22);
            tsbStopSimulation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbStopSimulation.Image = Properties.Resources.AddImageStateIcon;
            tsbStopSimulation.Text = "Stop Simulation";
            //
            // pbMap (PictureBox)
            //
            pbMap.Name = "pbMap";
            pbMap.Size = new Size(200, 200);
            pbMap.Location = new Point(13, 53);
            pbMap.TabIndex = 2;
            pbMap.TabStop = false;
            pbMap.BorderStyle = BorderStyle.FixedSingle;
            pbMap.Paint += new PaintEventHandler(ItemMapPaint);
            pbMap.MouseClick += new MouseEventHandler(ItemMapMouseClick);
            pbMap.MouseDown += new MouseEventHandler(ItemMapMouseDown);
            pbMap.MouseMove += new MouseEventHandler(ItemMapMouseMove);
            pbMap.MouseUp += new MouseEventHandler(ItemMapMouseUp);
            //
            // stsStatus (StatusStrip)
            //
            stsStatus.Name = "stsStatus";
            stsStatus.Size = new Size(489, 22);
            stsStatus.Location = new Point(0, 309);
            stsStatus.TabIndex = 3;
            stsStatus.Text = "Status";
            //
            // trvStates (TreeView)
            //
            trvStates.Name = "trvStates";
            trvStates.Size = new Size(121, 105);
            trvStates.Location = new Point(360, 71);
            trvStates.TabIndex = 4;
            //
            // trvTransitions (TreeView)
            //
            trvTransitions.Name = "trvTransitions";
            trvTransitions.Size = new Size(121, 101);
            trvTransitions.Location = new Point(360, 195);
            trvTransitions.TabIndex = 5;
            //
            // lblStates (Label)
            //
            lblStates.Name = "lblStates";
            lblStates.Size = new Size(37, 13);
            lblStates.Location = new Point(360, 52);
            lblStates.AutoSize = true;
            lblStates.TabIndex = 6;
            lblStates.Text = "States";
            //
            // lblTransitions (Label)
            //
            lblTransitions.Name = "lblTransitions";
            lblTransitions.Size = new Size(58, 13);
            lblTransitions.Location = new Point(360, 179);
            lblTransitions.AutoSize = true;
            lblTransitions.TabIndex = 7;
            lblTransitions.Text = "Transitions";
            //
            // MainForm
            //
            Name = "MainForm"; 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 331);
            Controls.Add(lblTransitions);
            Controls.Add(lblStates);
            Controls.Add(trvTransitions);
            Controls.Add(trvStates);
            Controls.Add(stsStatus);
            Controls.Add(pbMap);
            Controls.Add(tlsMain);
            Controls.Add(mnsMain);
            Icon = Properties.Resources.AppIcon;
            MainMenuStrip = mnsMain;
            Text = "Coloured Petri Net";
            mnsMain.ResumeLayout(false);
            mnsMain.PerformLayout();
            tlsMain.ResumeLayout(false);
            tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pbMap)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private MenuStrip mnsMain;

        private ToolStripMenuItem mniFile;
        private ToolStripMenuItem mniOpen;
        private ToolStripMenuItem mniSave;
        private ToolStripMenuItem mniSaveAs;
        private ToolStripMenuItem mniExit;

        private ToolStripMenuItem mniMap;
        private ToolStripMenuItem mniSetMode;

        private ToolStripMenuItem mniSetModeView;
        private ToolStripMenuItem mniSetModeMove;
        private ToolStripMenuItem mniSetModeAddState;
        private ToolStripMenuItem mniSetModeAddRoundState;
        private ToolStripMenuItem mniSetModeAddImageState;
        private ToolStripMenuItem mniSetModeAddTransition;
        private ToolStripMenuItem mniSetModeAddRectangleTransition;
        private ToolStripMenuItem mniSetModeAddRhombTransition;
        private ToolStripMenuItem mniSetModeAddMarker;
        private ToolStripMenuItem mniSetModeAddRoundMarker;
        private ToolStripMenuItem mniSetModeAddRhombMarker;
        private ToolStripMenuItem mniSetModeAddTriangleMarker;
        private ToolStripMenuItem mniSetModeAddLink;
        private ToolStripMenuItem mniSetModeRemove;
        private ToolStripMenuItem mniSetModeRemoveMarker;

        private ToolStripMenuItem mniShowInfo;
        private ToolStripMenuItem mniShowStateInfo;
        private ToolStripMenuItem mniShowTransitionInfo;
        private ToolStripMenuItem mniShowMarkerInfo;

        private ToolStripMenuItem mniView;
        private ToolStripMenuItem mniSelectionMode;
        private ToolStripMenuItem mniSelectionModeFull;
        private ToolStripMenuItem mniSelectionModePartial;
        private ToolStripMenuItem mniItemStyle;
        private ToolStripMenuItem mniStateStyle;
        private ToolStripMenuItem mniTransitionStyle;
        private ToolStripMenuItem mniMarkerStyle;
        private ToolStripMenuItem mniLinkStyle;
        private ToolStripMenuItem mniBackground;

        private ToolStripMenuItem mniAbout;
        private ToolStrip tlsMain;
        private ToolStripButton tsbView;
        private ToolStripButton tsbMove;
        private ToolStripButton tsbAddLink;
        private ToolStripButton tsbRemove;
        private ToolStripButton tsbRemoveMarker;
        private ToolStripSeparator tsSeparator1;
        private ToolStripButton tsbOneStepSimulation;
        private ToolStripButton tsbRunSimulation;
        private ToolStripButton tsbStopSimulation;
        private StripImageList imageListAddState;
        private StripImageList imageListAddTransition;
        private StripImageList imageListAddMarker;
        private PictureBox pbMap;
        private StatusStrip stsStatus;
        private TreeView trvStates;
        private TreeView trvTransitions;
        private Label lblStates;
        private Label lblTransitions;
    }
}