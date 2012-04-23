namespace SavannaFrame
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.topPanelMainMenu = new System.Windows.Forms.Panel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.модельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.доменыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tabController = new System.Windows.Forms.TabControl();
            this.FramePage = new System.Windows.Forms.TabPage();
            this.panelDiagramm = new System.Windows.Forms.Panel();
            this.diagramView = new MindFusion.Diagramming.WinForms.DiagramView();
            this.DiagramContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьФреймшаблонToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.FrameDiagram = new MindFusion.Diagramming.Diagram();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbTypeLink = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cmbZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.panelDataView = new System.Windows.Forms.Panel();
            this.FrameTreeView = new System.Windows.Forms.TreeView();
            this.TreeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьФреймшаблонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.добавитьСлотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьСлотToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.удалитьФреймToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.FrameDataGridView = new System.Windows.Forms.DataGridView();
            this.SlotName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlotType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlotValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.EditBtn = new System.Windows.Forms.Button();
            this.GamePage = new System.Windows.Forms.TabPage();
            this.topPanelMainMenu.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.tabController.SuspendLayout();
            this.FramePage.SuspendLayout();
            this.panelDiagramm.SuspendLayout();
            this.DiagramContextMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelDataView.SuspendLayout();
            this.TreeContextMenu.SuspendLayout();
            this.EditPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FrameDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // topPanelMainMenu
            // 
            this.topPanelMainMenu.Controls.Add(this.MainMenu);
            resources.ApplyResources(this.topPanelMainMenu, "topPanelMainMenu");
            this.topPanelMainMenu.Name = "topPanelMainMenu";
            // 
            // MainMenu
            // 
            resources.ApplyResources(this.MainMenu, "MainMenu");
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.модельToolStripMenuItem,
            this.играToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.сохранитьКакToolStripMenuItem,
            this.toolStripMenuItem2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            resources.ApplyResources(this.файлToolStripMenuItem, "файлToolStripMenuItem");
            // 
            // создатьToolStripMenuItem
            // 
            this.создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            resources.ApplyResources(this.создатьToolStripMenuItem, "создатьToolStripMenuItem");
            this.создатьToolStripMenuItem.Click += new System.EventHandler(this.создатьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            resources.ApplyResources(this.открытьToolStripMenuItem, "открытьToolStripMenuItem");
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            resources.ApplyResources(this.сохранитьToolStripMenuItem, "сохранитьToolStripMenuItem");
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // сохранитьКакToolStripMenuItem
            // 
            this.сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            resources.ApplyResources(this.сохранитьКакToolStripMenuItem, "сохранитьКакToolStripMenuItem");
            this.сохранитьКакToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            resources.ApplyResources(this.выходToolStripMenuItem, "выходToolStripMenuItem");
            // 
            // модельToolStripMenuItem
            // 
            this.модельToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.доменыToolStripMenuItem});
            this.модельToolStripMenuItem.Name = "модельToolStripMenuItem";
            resources.ApplyResources(this.модельToolStripMenuItem, "модельToolStripMenuItem");
            // 
            // доменыToolStripMenuItem
            // 
            this.доменыToolStripMenuItem.Name = "доменыToolStripMenuItem";
            resources.ApplyResources(this.доменыToolStripMenuItem, "доменыToolStripMenuItem");
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            resources.ApplyResources(this.играToolStripMenuItem, "играToolStripMenuItem");
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            resources.ApplyResources(this.справкаToolStripMenuItem, "справкаToolStripMenuItem");
            this.справкаToolStripMenuItem.Click += new System.EventHandler(this.справкаToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.tabController);
            resources.ApplyResources(this.MainPanel, "MainPanel");
            this.MainPanel.Name = "MainPanel";
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.FramePage);
            this.tabController.Controls.Add(this.GamePage);
            resources.ApplyResources(this.tabController, "tabController");
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            // 
            // FramePage
            // 
            this.FramePage.Controls.Add(this.panelDiagramm);
            this.FramePage.Controls.Add(this.panelDataView);
            resources.ApplyResources(this.FramePage, "FramePage");
            this.FramePage.Name = "FramePage";
            this.FramePage.UseVisualStyleBackColor = true;
            // 
            // panelDiagramm
            // 
            this.panelDiagramm.Controls.Add(this.diagramView);
            this.panelDiagramm.Controls.Add(this.toolStrip1);
            resources.ApplyResources(this.panelDiagramm, "panelDiagramm");
            this.panelDiagramm.Name = "panelDiagramm";
            // 
            // diagramView
            // 
            this.diagramView.BackColor = System.Drawing.SystemColors.Window;
            this.diagramView.Behavior = MindFusion.Diagramming.Behavior.DrawLinks;
            this.diagramView.ContextMenuStrip = this.DiagramContextMenu;
            this.diagramView.ControlHandlesStyle = MindFusion.Diagramming.HandlesStyle.Custom;
            this.diagramView.Diagram = this.FrameDiagram;
            resources.ApplyResources(this.diagramView, "diagramView");
            this.diagramView.InplaceEditAcceptOnEnter = true;
            this.diagramView.InplaceEditCancelOnEsc = false;
            this.diagramView.Name = "diagramView";
            this.diagramView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.diagramView_MouseDown);
            this.diagramView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.diagramView_MouseMove);
            this.diagramView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.diagramView_MouseUp);
            // 
            // DiagramContextMenu
            // 
            this.DiagramContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьФреймшаблонToolStripMenuItem1});
            this.DiagramContextMenu.Name = "DiagramContextMenu";
            resources.ApplyResources(this.DiagramContextMenu, "DiagramContextMenu");
            // 
            // добавитьФреймшаблонToolStripMenuItem1
            // 
            this.добавитьФреймшаблонToolStripMenuItem1.Name = "добавитьФреймшаблонToolStripMenuItem1";
            resources.ApplyResources(this.добавитьФреймшаблонToolStripMenuItem1, "добавитьФреймшаблонToolStripMenuItem1");
            this.добавитьФреймшаблонToolStripMenuItem1.Click += new System.EventHandler(this.добавитьФреймшаблонToolStripMenuItem_Click);
            // 
            // FrameDiagram
            // 
            this.FrameDiagram.AllowLinksRepeat = false;
            this.FrameDiagram.AllowSelfLoops = false;
            this.FrameDiagram.BackBrush = new MindFusion.Drawing.SolidBrush("#FFFFFFFF");
            this.FrameDiagram.DefaultShape = MindFusion.Diagramming.Shape.FromId("Ellipse");
            this.FrameDiagram.LinkEndsMovable = false;
            this.FrameDiagram.MeasureUnit = System.Drawing.GraphicsUnit.Pixel;
            this.FrameDiagram.MinimumNodeSize = new System.Drawing.SizeF(20F, 10F);
            this.FrameDiagram.RoutingOptions.GridSize = 16F;
            this.FrameDiagram.RoutingOptions.NodeVicinitySize = 48F;
            this.FrameDiagram.ShapeBrush = new MindFusion.Drawing.SolidBrush("#FFB0E0E6");
            this.FrameDiagram.LinkCreated += new MindFusion.Diagramming.LinkEventHandler(this.FrameDiagram_LinkCreated);
            this.FrameDiagram.NodeCreated += new MindFusion.Diagramming.NodeEventHandler(this.FraimDiagram_NodeCreated);
            this.FrameDiagram.NodeSelected += new MindFusion.Diagramming.NodeEventHandler(this.FrameDiagram_NodeSelected);
            this.FrameDiagram.NodeDeselected += new MindFusion.Diagramming.NodeEventHandler(this.FrameDiagram_NodeDeselected);
            this.FrameDiagram.NodeDeleting += new MindFusion.Diagramming.NodeValidationEventHandler(this.FrameDiagram_NodeDeleting);
            this.FrameDiagram.SelectionMoved += new System.EventHandler(this.FrameDiagram_SelectionMoved);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.cmbTypeLink,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.cmbZoom,
            this.toolStripLabel3,
            this.toolStripSeparator1,
            this.toolStripLabel4});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // cmbTypeLink
            // 
            this.cmbTypeLink.BackColor = System.Drawing.SystemColors.Control;
            this.cmbTypeLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTypeLink.Items.AddRange(new object[] {
            resources.GetString("cmbTypeLink.Items"),
            resources.GetString("cmbTypeLink.Items1")});
            this.cmbTypeLink.Name = "cmbTypeLink";
            resources.ApplyResources(this.cmbTypeLink, "cmbTypeLink");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            resources.ApplyResources(this.toolStripLabel2, "toolStripLabel2");
            // 
            // cmbZoom
            // 
            this.cmbZoom.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("cmbZoom.AutoCompleteCustomSource"),
            resources.GetString("cmbZoom.AutoCompleteCustomSource1"),
            resources.GetString("cmbZoom.AutoCompleteCustomSource2"),
            resources.GetString("cmbZoom.AutoCompleteCustomSource3")});
            this.cmbZoom.BackColor = System.Drawing.SystemColors.Control;
            this.cmbZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoom.Items.AddRange(new object[] {
            resources.GetString("cmbZoom.Items"),
            resources.GetString("cmbZoom.Items1"),
            resources.GetString("cmbZoom.Items2"),
            resources.GetString("cmbZoom.Items3"),
            resources.GetString("cmbZoom.Items4")});
            this.cmbZoom.Name = "cmbZoom";
            resources.ApplyResources(this.cmbZoom, "cmbZoom");
            this.cmbZoom.SelectedIndexChanged += new System.EventHandler(this.cmbZoom_SelectedIndexChanged);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            resources.ApplyResources(this.toolStripLabel3, "toolStripLabel3");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            resources.ApplyResources(this.toolStripLabel4, "toolStripLabel4");
            // 
            // panelDataView
            // 
            this.panelDataView.Controls.Add(this.FrameTreeView);
            this.panelDataView.Controls.Add(this.EditPanel);
            this.panelDataView.Controls.Add(this.panel1);
            resources.ApplyResources(this.panelDataView, "panelDataView");
            this.panelDataView.Name = "panelDataView";
            // 
            // FrameTreeView
            // 
            this.FrameTreeView.ContextMenuStrip = this.TreeContextMenu;
            resources.ApplyResources(this.FrameTreeView, "FrameTreeView");
            this.FrameTreeView.HideSelection = false;
            this.FrameTreeView.Name = "FrameTreeView";
            this.FrameTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FrameTreeView_NodeMouseClick);
            this.FrameTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrameTreeView_KeyDown);
            this.FrameTreeView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrameTreeView_KeyUp);
            // 
            // TreeContextMenu
            // 
            this.TreeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьФреймшаблонToolStripMenuItem,
            this.toolStripMenuItem4,
            this.добавитьСлотToolStripMenuItem,
            this.удалитьСлотToolStripMenuItem,
            this.toolStripMenuItem3,
            this.удалитьФреймToolStripMenuItem});
            this.TreeContextMenu.Name = "TreeContextMenu";
            resources.ApplyResources(this.TreeContextMenu, "TreeContextMenu");
            // 
            // добавитьФреймшаблонToolStripMenuItem
            // 
            this.добавитьФреймшаблонToolStripMenuItem.Name = "добавитьФреймшаблонToolStripMenuItem";
            resources.ApplyResources(this.добавитьФреймшаблонToolStripMenuItem, "добавитьФреймшаблонToolStripMenuItem");
            this.добавитьФреймшаблонToolStripMenuItem.Click += new System.EventHandler(this.добавитьФреймшаблонToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // добавитьСлотToolStripMenuItem
            // 
            this.добавитьСлотToolStripMenuItem.Name = "добавитьСлотToolStripMenuItem";
            resources.ApplyResources(this.добавитьСлотToolStripMenuItem, "добавитьСлотToolStripMenuItem");
            // 
            // удалитьСлотToolStripMenuItem
            // 
            this.удалитьСлотToolStripMenuItem.Name = "удалитьСлотToolStripMenuItem";
            resources.ApplyResources(this.удалитьСлотToolStripMenuItem, "удалитьСлотToolStripMenuItem");
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // удалитьФреймToolStripMenuItem
            // 
            this.удалитьФреймToolStripMenuItem.Name = "удалитьФреймToolStripMenuItem";
            resources.ApplyResources(this.удалитьФреймToolStripMenuItem, "удалитьФреймToolStripMenuItem");
            this.удалитьФреймToolStripMenuItem.Click += new System.EventHandler(this.удалитьФреймToolStripMenuItem_Click);
            // 
            // EditPanel
            // 
            this.EditPanel.Controls.Add(this.FrameDataGridView);
            resources.ApplyResources(this.EditPanel, "EditPanel");
            this.EditPanel.Name = "EditPanel";
            // 
            // FrameDataGridView
            // 
            this.FrameDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.FrameDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FrameDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlotName,
            this.SlotType,
            this.SlotValue});
            resources.ApplyResources(this.FrameDataGridView, "FrameDataGridView");
            this.FrameDataGridView.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.FrameDataGridView.MultiSelect = false;
            this.FrameDataGridView.Name = "FrameDataGridView";
            this.FrameDataGridView.ReadOnly = true;
            this.FrameDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.FrameDataGridView.RowHeadersVisible = false;
            // 
            // SlotName
            // 
            resources.ApplyResources(this.SlotName, "SlotName");
            this.SlotName.Name = "SlotName";
            this.SlotName.ReadOnly = true;
            // 
            // SlotType
            // 
            resources.ApplyResources(this.SlotType, "SlotType");
            this.SlotType.Name = "SlotType";
            this.SlotType.ReadOnly = true;
            // 
            // SlotValue
            // 
            resources.ApplyResources(this.SlotValue, "SlotValue");
            this.SlotValue.Name = "SlotValue";
            this.SlotValue.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightBlue;
            this.panel1.Controls.Add(this.EditBtn);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // EditBtn
            // 
            resources.ApplyResources(this.EditBtn, "EditBtn");
            this.EditBtn.Name = "EditBtn";
            this.EditBtn.UseVisualStyleBackColor = true;
            // 
            // GamePage
            // 
            resources.ApplyResources(this.GamePage, "GamePage");
            this.GamePage.Name = "GamePage";
            this.GamePage.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.topPanelMainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.topPanelMainMenu.ResumeLayout(false);
            this.topPanelMainMenu.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.tabController.ResumeLayout(false);
            this.FramePage.ResumeLayout(false);
            this.panelDiagramm.ResumeLayout(false);
            this.panelDiagramm.PerformLayout();
            this.DiagramContextMenu.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelDataView.ResumeLayout(false);
            this.TreeContextMenu.ResumeLayout(false);
            this.EditPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FrameDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topPanelMainMenu;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.TabPage FramePage;
        private System.Windows.Forms.TabPage GamePage;
        private System.Windows.Forms.Panel panelDataView;
        private System.Windows.Forms.Panel panelDiagramm;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView FrameDataGridView;
        public MindFusion.Diagramming.Diagram FrameDiagram;
        private MindFusion.Diagramming.WinForms.DiagramView diagramView;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem модельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem доменыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cmbTypeLink;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cmbZoom;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.TreeView FrameTreeView;
        private System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlotValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button EditBtn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ContextMenuStrip DiagramContextMenu;
        private System.Windows.Forms.ToolStripMenuItem добавитьФреймшаблонToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip TreeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem добавитьФреймшаблонToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem добавитьСлотToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьСлотToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem удалитьФреймToolStripMenuItem;
    }
}

