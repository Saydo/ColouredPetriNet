﻿using System.Windows.Forms;
using System.Drawing;
using PetriNet = ColouredPetriNet.GraphicsPetriNet;
using ColouredPetriNet.GraphicsPetriNet.GraphicsItems;

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
            mniTypes = new ToolStripMenuItem();
            mniRules = new ToolStripMenuItem();
            mniMoveRules = new ToolStripMenuItem();
            mniPrevAccumulateRules = new ToolStripMenuItem();
            mniNextAccumulateRules = new ToolStripMenuItem();
            mniShowInfo = new ToolStripMenuItem();
            mniShowStateInfo = new ToolStripMenuItem();
            mniShowTransitionInfo = new ToolStripMenuItem();
            mniShowMarkerInfo = new ToolStripMenuItem();
            mniView = new ToolStripMenuItem();
            mniSelectionMode = new ToolStripMenuItem();
            mniSelectionModeFull = new ToolStripRadioButtonMenuItem();
            mniSelectionModePartial = new ToolStripRadioButtonMenuItem();
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
            tsbStartSimulation = new ToolStripButton();
            tsbStopSimulation = new ToolStripButton();
            dlgTypes = new TypeListForm(this, _petriNet);
            dlgRules = new RuleListForm();
            dlgShowItemInfo = new ShowItemInfoForm();
            dlgStateInfo = new StateInfoForm();
            dlgTransitionInfo = new TransitionInfoForm();
            dlgMarkerInfo = new MarkerInfoForm();
            dlgLinkStyle = new LinkStyleForm(this);
            dlgItemStyle = new ItemStyleForm(_style, _petriNet, this);
            dlgBackground = new BackgroundForm();
            dlgAbout = new AboutForm();
            dlgOpenFile = new OpenFileDialog();
            dlgSaveFile = new SaveFileDialog();
            dlgRemoveMarker = new RemoveMarkerForm(_petriNet);
            pbMap = new PictureBox();
            stsStatus = new StatusStrip();
            lblStatusText = new ToolStripStatusLabel();
            trvStates = new TreeView();
            trvTransitions = new TreeView();
            lblStates = new Label();
            lblTransitions = new Label();

            mnsMain.SuspendLayout();
            tlsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pbMap)).BeginInit();
            this.SuspendLayout();
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
            mniOpen.Click += (obj, e) => LoadFromFile();
            //
            // Save (ToolStripMenuItem)
            //
            mniSave.Name = "mniSave";
            mniSave.Size = new Size(152, 22);
            mniSave.Text = "Save";
            mniSave.Click += (obj, e) => SaveToFile();
            //
            // SaveAs (ToolStripMenuItem)
            //
            mniSaveAs.Name = "mniSaveAs";
            mniSaveAs.Size = new Size(152, 22);
            mniSaveAs.Text = "Save As...";
            mniSaveAs.Click += (obj, e) => SaveFileAs();
            //
            // Exit (ToolStripMenuItem)
            //
            mniExit.Name = "mniExit";
            mniExit.Size = new Size(152, 22);
            mniExit.Text = "Exit";
            mniExit.Click += (obj, e) => this.Close();
            //
            // Map (ToolStripMenuItem)
            //
            mniMap.Name = "mniMap";
            mniMap.Size = new Size(43, 20);
            mniMap.Text = "Map";
            mniMap.DropDownItems.AddRange(new ToolStripItem[] {
                mniTypes,
                mniRules,
                mniShowInfo
            });
            //
            // Types (ToolStripMenuItem)
            //
            mniTypes.Name = "mniTypes";
            mniTypes.Size = new Size(152, 22);
            mniTypes.Text = "Types";
            mniTypes.Click += (obj, e) => dlgTypes.ShowDialog();
            //
            // Rules (ToolStripMenuItem)
            //
            mniRules.Name = "mniRules";
            mniRules.Size = new Size(152, 22);
            mniRules.Text = "Rules";
            mniRules.DropDownItems.AddRange(new ToolStripItem[] {
                mniMoveRules,
                mniPrevAccumulateRules,
                mniNextAccumulateRules
            });
            //
            // mniMoveRules (ToolStripMenuItem)
            //
            mniMoveRules.Name = "mniMoveRules";
            mniMoveRules.Size = new Size(152, 22);
            mniMoveRules.Text = "Move Rules";
            mniMoveRules.Click += (obj, e) => OpenMoveRulesDialog();
            //
            // mniPrevAccumulateRules (ToolStripMenuItem)
            //
            mniPrevAccumulateRules.Name = "mniPrevAccumulateRules";
            mniPrevAccumulateRules.Size = new Size(152, 22);
            mniPrevAccumulateRules.Text = "Prev Accumulate Rules";
            mniPrevAccumulateRules.Click += (obj, e) => OpenPrevAccumulateRulesDialog();
            //
            // mniNextAccumulateRules (ToolStripMenuItem)
            //
            mniNextAccumulateRules.Name = "mniNextAccumulateRules";
            mniNextAccumulateRules.Size = new Size(152, 22);
            mniNextAccumulateRules.Text = "Next Accumulate Rules";
            mniNextAccumulateRules.Click += (obj, e) => OpenNextAccumulateRulesDialog();
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
            mniShowStateInfo.Click += (obj, e) =>
                dlgShowItemInfo.ShowDialog(Core.Events.ShowInfoEventArgs.ItemType.State);
            //
            // ShowTransitionInfo (ToolStripMenuItem)
            //
            mniShowTransitionInfo.Name = "mniShowTransitionInfo";
            mniShowTransitionInfo.Size = new Size(152, 22);
            mniShowTransitionInfo.Text = "About Transition";
            mniShowTransitionInfo.Click += (obj, e) =>
                dlgShowItemInfo.ShowDialog(Core.Events.ShowInfoEventArgs.ItemType.Transition);
            //
            // ShowMarkerInfo (ToolStripMenuItem)
            //
            mniShowMarkerInfo.Name = "mniShowMarkerInfo";
            mniShowMarkerInfo.Size = new Size(152, 22);
            mniShowMarkerInfo.Text = "About Marker";
            mniShowMarkerInfo.Click += (obj, e) =>
                dlgShowItemInfo.ShowDialog(Core.Events.ShowInfoEventArgs.ItemType.Marker);
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
            mniSelectionModeFull.Click += (obj, e) => SetSelectionMode(OverlapType.Full);
            //
            // SelectionModePartial (ToolStripMenuItem)
            //
            mniSelectionModePartial.Name = "mniSelectionModePartial";
            mniSelectionModePartial.Size = new Size(152, 22);
            mniSelectionModePartial.Text = "Partial";
            mniSelectionModePartial.Click += (obj, e) => SetSelectionMode(OverlapType.Partial);
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
            mniStateStyle.Click += (obj, e) => dlgItemStyle.ShowDialog(PetriNet.GraphicsPetriNet.ItemType.State);
            //
            // TransitionStyle (ToolStripMenuItem)
            //
            mniTransitionStyle.Name = "mniTransitionStyle";
            mniTransitionStyle.Size = new Size(152, 22);
            mniTransitionStyle.Text = "Transitions";
            mniTransitionStyle.Click += (obj, e) => dlgItemStyle.ShowDialog(PetriNet.GraphicsPetriNet.ItemType.Transition);
            //
            // MarkerStyle (ToolStripMenuItem)
            //
            mniMarkerStyle.Name = "mniMarkerStyle";
            mniMarkerStyle.Size = new Size(152, 22);
            mniMarkerStyle.Text = "Markers";
            mniMarkerStyle.Click += (obj, e) => dlgItemStyle.ShowDialog(PetriNet.GraphicsPetriNet.ItemType.Marker);
            //
            // mniLinkStyle (ToolStripMenuItem)
            //
            mniLinkStyle.Name = "mniLinkStyle";
            mniLinkStyle.Size = new Size(152, 22);
            mniLinkStyle.Text = "Links";
            mniLinkStyle.Click += (obj, e) => dlgLinkStyle.ShowDialog(_style.LinePen);
            //
            // Background (ToolStripMenuItem)
            //
            mniBackground.Name = "mniBackground";
            mniBackground.Size = new Size(152, 22);
            mniBackground.Text = "Background";
            mniBackground.Click += (obj, e) => dlgBackground.ShowDialog();
            //
            // About (ToolStripMenuItem)
            //
            mniAbout.Name = "mniAbout";
            mniAbout.Size = new Size(52, 20);
            mniAbout.Text = "About";
            mniAbout.Click += (obj, e) => dlgAbout.ShowDialog();
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
                tsbStartSimulation,
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
            tsbView.Image = Core.PetriNetResources.Storage.GetImage("ViewIcon");
            tsbView.Text = "View";
            tsbView.Click += (obj, e) => SetItemMapMode(ItemMapMode.View);
            //
            // Move (ToolStripButton)
            //
            tsbMove.Name = "tsbMove";
            tsbMove.Size = new Size(23, 22);
            tsbMove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbMove.Image = Core.PetriNetResources.Storage.GetImage("MoveIcon");
            tsbMove.Text = "Move";
            tsbMove.Click += (obj, e) => SetItemMapMode(ItemMapMode.Move);
            //
            // imageListAddState (StripImageList)
            //
            imageListAddState.Name = "imageListAddState";
            imageListAddState.Size = new Size(33, 22);
            imageListAddState.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddState);
            //
            // imageListAddTransition (StripImageList)
            //
            imageListAddTransition.Name = "imageListAddTransition";
            imageListAddTransition.Size = new Size(33, 22);
            imageListAddTransition.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddTransition);
            //
            // imageListAddMarker (StripImageList)
            //
            imageListAddMarker.Name = "imageListAddMarker";
            imageListAddMarker.Size = new Size(33, 22);
            imageListAddMarker.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddMarker);
            //
            // AddLink (ToolStripButton)
            //
            tsbAddLink.Name = "tsbAddLink";
            tsbAddLink.Size = new Size(23, 22);
            tsbAddLink.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddLink.Image = Core.PetriNetResources.Storage.GetImage("AddLinkIcon");
            tsbAddLink.Text = "Add Link";
            tsbAddLink.Click += (obj, e) => SetItemMapMode(ItemMapMode.AddLink);
            //
            // Remove (ToolStripButton)
            //
            tsbRemove.Name = "tsbRemove";
            tsbRemove.Size = new Size(23, 22);
            tsbRemove.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRemove.Image = Core.PetriNetResources.Storage.GetImage("RemoveIcon");
            tsbRemove.Text = "Remove";
            tsbRemove.Click += (obj, e) => SetItemMapMode(ItemMapMode.Remove);
            //
            // RemoveMarker (ToolStripButton)
            //
            tsbRemoveMarker.Name = "tsbRemoveMarker";
            tsbRemoveMarker.Size = new Size(23, 22);
            tsbRemoveMarker.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbRemoveMarker.Image = Core.PetriNetResources.Storage.GetImage("RemoveMarkerIcon");
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
            tsbOneStepSimulation.Image = Core.PetriNetResources.Storage.GetImage("OneStepIcon");
            tsbOneStepSimulation.Text = "One Step Simulation";
            tsbOneStepSimulation.Click += (obj, e) => MoveMarkers();
            //
            // tsbStartSimulation (ToolStripButton)
            //
            tsbStartSimulation.Name = "tsbStartSimulation";
            tsbStartSimulation.Size = new Size(23, 22);
            tsbStartSimulation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbStartSimulation.Image = Core.PetriNetResources.Storage.GetImage("PlayIcon");
            tsbStartSimulation.Text = "Start Simulation";
            tsbStartSimulation.Click += (obj, e) => StartMoveMarkerLoop();
            //
            // tsbStopSimulation (ToolStripButton)
            //
            tsbStopSimulation.Name = "tsbStopSimulation";
            tsbStopSimulation.Size = new Size(23, 22);
            tsbStopSimulation.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbStopSimulation.Image = Core.PetriNetResources.Storage.GetImage("StopIcon");
            tsbStopSimulation.Text = "Stop Simulation";
            tsbStopSimulation.Click += (obj, e) => StopMoveMarkerLoop();
            //
            // pbMap (PictureBox)
            //
            pbMap.Name = "pbMap";
            pbMap.Size = new Size(340, 250);
            pbMap.Location = new Point(13, 53);
            pbMap.TabIndex = 2;
            pbMap.TabStop = false;
            pbMap.BorderStyle = BorderStyle.FixedSingle;
            pbMap.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
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
            stsStatus.Items.AddRange(new ToolStripItem[] {
                lblStatusText
            });
            //
            // lblStatusText (ToolStripStatusLabel)
            //
            lblStatusText.Name = "lblStatusText";
            lblStatusText.Size = new Size(118, 17);
            lblStatusText.Text = "";
            //
            // trvStates (TreeView)
            //
            trvStates.Name = "trvStates";
            trvStates.Size = new Size(121, 105);
            trvStates.Location = new Point(360, 71);
            trvStates.TabIndex = 4;
            trvStates.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            ImageList stateImageList = new ImageList();
            stateImageList.Images.Add(PetriNet.ItemForm.Round.ToString() + PetriNet.GraphicsPetriNet.ItemType.State.ToString(), Core.PetriNetResources.Storage.GetImage("RoundStateIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Rectangle.ToString() + PetriNet.GraphicsPetriNet.ItemType.State.ToString(), Core.PetriNetResources.Storage.GetImage("RectangleStateIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Rhomb.ToString() + PetriNet.GraphicsPetriNet.ItemType.State.ToString(), Core.PetriNetResources.Storage.GetImage("RhombStateIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Triangle.ToString() + PetriNet.GraphicsPetriNet.ItemType.State.ToString(), Core.PetriNetResources.Storage.GetImage("TriangleStateIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Image.ToString() + PetriNet.GraphicsPetriNet.ItemType.State.ToString(), Core.PetriNetResources.Storage.GetImage("ImageStateIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Round.ToString() + PetriNet.GraphicsPetriNet.ItemType.Marker.ToString(), Core.PetriNetResources.Storage.GetImage("RoundMarkerIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Rectangle.ToString() + PetriNet.GraphicsPetriNet.ItemType.Marker.ToString(), Core.PetriNetResources.Storage.GetImage("RectangleMarkerIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Rhomb.ToString() + PetriNet.GraphicsPetriNet.ItemType.Marker.ToString(), Core.PetriNetResources.Storage.GetImage("RhombMarkerIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Triangle.ToString() + PetriNet.GraphicsPetriNet.ItemType.Marker.ToString(), Core.PetriNetResources.Storage.GetImage("TriangleMarkerIcon"));
            stateImageList.Images.Add(PetriNet.ItemForm.Image.ToString() + PetriNet.GraphicsPetriNet.ItemType.Marker.ToString(), Core.PetriNetResources.Storage.GetImage("ImageMarkerIcon"));
            trvStates.ImageList = stateImageList;
            //
            // trvTransitions (TreeView)
            //
            trvTransitions.Name = "trvTransitions";
            trvTransitions.Size = new Size(121, 101);
            trvTransitions.Location = new Point(360, 200);
            trvTransitions.TabIndex = 5;
            trvTransitions.Anchor = AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
            ImageList transitionImageList = new ImageList();
            transitionImageList.Images.Add(PetriNet.ItemForm.Round.ToString(), Core.PetriNetResources.Storage.GetImage("RoundTransitionIcon"));
            transitionImageList.Images.Add(PetriNet.ItemForm.Rectangle.ToString(), Core.PetriNetResources.Storage.GetImage("RectangleTransitionIcon"));
            transitionImageList.Images.Add(PetriNet.ItemForm.Rhomb.ToString(), Core.PetriNetResources.Storage.GetImage("RhombTransitionIcon"));
            transitionImageList.Images.Add(PetriNet.ItemForm.Triangle.ToString(), Core.PetriNetResources.Storage.GetImage("TriangleTransitionIcon"));
            transitionImageList.Images.Add(PetriNet.ItemForm.Image.ToString(), Core.PetriNetResources.Storage.GetImage("ImageTransitionIcon"));
            trvTransitions.ImageList = transitionImageList;
            //
            // lblStates (Label)
            //
            lblStates.Name = "lblStates";
            lblStates.Size = new Size(37, 13);
            lblStates.Location = new Point(360, 52);
            lblStates.AutoSize = true;
            lblStates.TabIndex = 6;
            lblStates.Text = "States";
            lblStates.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            //
            // lblTransitions (Label)
            //
            lblTransitions.Name = "lblTransitions";
            lblTransitions.Size = new Size(58, 13);
            lblTransitions.Location = new Point(360, 179);
            lblTransitions.AutoSize = true;
            lblTransitions.TabIndex = 7;
            lblTransitions.Text = "Transitions";
            lblTransitions.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            //
            // dlgOpenFile (OpenFileDialog)
            //
            dlgOpenFile = new OpenFileDialog();
            dlgOpenFile.Filter = "Coloured petri net files (*.cpn)|*.cpn|All files (*.*)|*.*";
            dlgOpenFile.FilterIndex = 1;
            dlgOpenFile.RestoreDirectory = true;
            //
            // dlgSaveFile (SaveFileDialog)
            //
            dlgSaveFile = new SaveFileDialog();
            dlgSaveFile.Filter = "Coloured petri net files (*.cpn)|*.cpn|All files (*.*)|*.*";
            dlgSaveFile.FilterIndex = 1;
            dlgSaveFile.RestoreDirectory = true;
            //
            // dlgRemoveMarker (RemoveMarkerForm)
            //
            dlgRemoveMarker.ClearButtonClick += (obj, e) => ClearMarkers(e.Id);
            dlgRemoveMarker.RemoveButtonClick += (obj, e) => RemoveMarkers(e.Id, e.Markers);
            //
            // dlgShowIteminfo (ShowItemInfoForm)
            //
            dlgShowItemInfo.FindButtonClick += FindItemInfo;
            //
            // MainForm
            //
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(489, 330);
            this.MinimumSize = new Size(350, 370);
            this.Controls.Add(lblTransitions);
            this.Controls.Add(lblStates);
            this.Controls.Add(trvTransitions);
            this.Controls.Add(trvStates);
            this.Controls.Add(stsStatus);
            this.Controls.Add(pbMap);
            this.Controls.Add(tlsMain);
            this.Controls.Add(mnsMain);
            this.Icon = Core.PetriNetResources.Storage.GetIcon("AppIcon");
            this.MainMenuStrip = mnsMain;
            this.Text = "Coloured Petri Net";
            mnsMain.ResumeLayout(false);
            mnsMain.PerformLayout();
            tlsMain.ResumeLayout(false);
            tlsMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(pbMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.KeyPreview = true;
            this.Load += new System.EventHandler(MainFormLoad);
            this.KeyDown += new KeyEventHandler(MainFormKeyDown);
        }

        private MenuStrip mnsMain;
        private ToolStripMenuItem mniFile;
        private ToolStripMenuItem mniOpen;
        private ToolStripMenuItem mniSave;
        private ToolStripMenuItem mniSaveAs;
        private ToolStripMenuItem mniExit;
        private ToolStripMenuItem mniMap;
        private ToolStripMenuItem mniTypes;
        private ToolStripMenuItem mniRules;
        private ToolStripMenuItem mniMoveRules;
        private ToolStripMenuItem mniPrevAccumulateRules;
        private ToolStripMenuItem mniNextAccumulateRules;
        private ToolStripMenuItem mniShowInfo;
        private ToolStripMenuItem mniShowStateInfo;
        private ToolStripMenuItem mniShowTransitionInfo;
        private ToolStripMenuItem mniShowMarkerInfo;
        private ToolStripMenuItem mniView;
        private ToolStripMenuItem mniSelectionMode;
        private ToolStripRadioButtonMenuItem mniSelectionModeFull;
        private ToolStripRadioButtonMenuItem mniSelectionModePartial;
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
        private ToolStripButton tsbStartSimulation;
        private ToolStripButton tsbStopSimulation;
        private StripImageList imageListAddState;
        private StripImageList imageListAddTransition;
        private StripImageList imageListAddMarker;
        private PictureBox pbMap;
        private StatusStrip stsStatus;
        private ToolStripStatusLabel lblStatusText;
        private TreeView trvStates;
        private TreeView trvTransitions;
        private Label lblStates;
        private Label lblTransitions;
        private TypeListForm dlgTypes;
        private RuleListForm dlgRules;
        private ShowItemInfoForm dlgShowItemInfo;
        private StateInfoForm dlgStateInfo;
        private TransitionInfoForm dlgTransitionInfo;
        private MarkerInfoForm dlgMarkerInfo;
        private LinkStyleForm dlgLinkStyle;
        private ItemStyleForm dlgItemStyle;
        private BackgroundForm dlgBackground;
        private AboutForm dlgAbout;
        private OpenFileDialog dlgOpenFile;
        private SaveFileDialog dlgSaveFile;
        private RemoveMarkerForm dlgRemoveMarker;
    }
}