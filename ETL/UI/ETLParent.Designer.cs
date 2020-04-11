namespace ETL.UI
{
    partial class ETLParent
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.databaseMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ETLMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewEditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.createJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mappingMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMappingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.mainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.databasesTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).BeginInit();
            this.mainSplitContainer.Panel1.SuspendLayout();
            this.mainSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseMenu,
            this.ETLMenu,
            this.toolsMenu,
            this.mappingMenu,
            this.viewMenu,
            this.helpMenu});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.mappingMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1313, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // databaseMenu
            // 
            this.databaseMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.databaseMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.databaseMenu.Name = "databaseMenu";
            this.databaseMenu.Size = new System.Drawing.Size(67, 20);
            this.databaseMenu.Text = "&Database";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.Add_Click);
            // 
            // ETLMenu
            // 
            this.ETLMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createStripMenuItem,
            this.viewEditToolStripMenuItem});
            this.ETLMenu.Name = "ETLMenu";
            this.ETLMenu.Size = new System.Drawing.Size(38, 20);
            this.ETLMenu.Text = "&ETL";
            // 
            // createStripMenuItem
            // 
            this.createStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.createStripMenuItem.Name = "createStripMenuItem";
            this.createStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.createStripMenuItem.Text = "&Create";
            this.createStripMenuItem.Click += new System.EventHandler(this.createStripMenuItem_Click);
            // 
            // viewEditToolStripMenuItem
            // 
            this.viewEditToolStripMenuItem.Name = "viewEditToolStripMenuItem";
            this.viewEditToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.viewEditToolStripMenuItem.Text = "View/Edit";
            // 
            // toolsMenu
            // 
            this.toolsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createJobToolStripMenuItem,
            this.RunToolStripMenuItem});
            this.toolsMenu.Name = "toolsMenu";
            this.toolsMenu.Size = new System.Drawing.Size(59, 20);
            this.toolsMenu.Text = "&ETL Job";
            // 
            // createJobToolStripMenuItem
            // 
            this.createJobToolStripMenuItem.Name = "createJobToolStripMenuItem";
            this.createJobToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.createJobToolStripMenuItem.Text = "&Create";
            this.createJobToolStripMenuItem.Click += new System.EventHandler(this.CreateJobToolStripMenuItem_Click);
            // 
            // RunToolStripMenuItem
            // 
            this.RunToolStripMenuItem.Name = "RunToolStripMenuItem";
            this.RunToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.RunToolStripMenuItem.Text = "Run";
            // 
            // mappingMenu
            // 
            this.mappingMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMappingToolStripMenuItem});
            this.mappingMenu.Name = "mappingMenu";
            this.mappingMenu.Size = new System.Drawing.Size(67, 20);
            this.mappingMenu.Text = "&Mapping";
            // 
            // editMappingToolStripMenuItem
            // 
            this.editMappingToolStripMenuItem.Name = "editMappingToolStripMenuItem";
            this.editMappingToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.editMappingToolStripMenuItem.Text = "View/Edit";
            this.editMappingToolStripMenuItem.Click += new System.EventHandler(this.editMappingToolStripMenuItem_Click);
            // 
            // viewMenu
            // 
            this.viewMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBarToolStripMenuItem,
            this.statusBarToolStripMenuItem});
            this.viewMenu.Name = "viewMenu";
            this.viewMenu.Size = new System.Drawing.Size(44, 20);
            this.viewMenu.Text = "&View";
            // 
            // toolBarToolStripMenuItem
            // 
            this.toolBarToolStripMenuItem.Checked = true;
            this.toolBarToolStripMenuItem.CheckOnClick = true;
            this.toolBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolBarToolStripMenuItem.Name = "toolBarToolStripMenuItem";
            this.toolBarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.toolBarToolStripMenuItem.Text = "&Toolbar";
            // 
            // statusBarToolStripMenuItem
            // 
            this.statusBarToolStripMenuItem.Checked = true;
            this.statusBarToolStripMenuItem.CheckOnClick = true;
            this.statusBarToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.statusBarToolStripMenuItem.Name = "statusBarToolStripMenuItem";
            this.statusBarToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.statusBarToolStripMenuItem.Text = "&Status Bar";
            this.statusBarToolStripMenuItem.Click += new System.EventHandler(this.StatusBarToolStripMenuItem_Click);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator8});
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(44, 20);
            this.helpMenu.Text = "&Help";
            this.helpMenu.Click += new System.EventHandler(this.HelpMenu_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(177, 6);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 674);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1313, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(36, 17);
            this.toolStripStatusLabel.Text = "Open";
            // 
            // mainSplitContainer
            // 
            this.mainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.mainSplitContainer.Name = "mainSplitContainer";
            // 
            // mainSplitContainer.Panel1
            // 
            this.mainSplitContainer.Panel1.Controls.Add(this.databasesTreeView);
            this.mainSplitContainer.Size = new System.Drawing.Size(1313, 650);
            this.mainSplitContainer.SplitterDistance = 278;
            this.mainSplitContainer.TabIndex = 4;
            // 
            // databasesTreeView
            // 
            this.databasesTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databasesTreeView.Location = new System.Drawing.Point(0, 0);
            this.databasesTreeView.Name = "databasesTreeView";
            this.databasesTreeView.Size = new System.Drawing.Size(278, 650);
            this.databasesTreeView.TabIndex = 0;
            this.databasesTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DatabasesTreeView_NodeMouseClick);
            this.databasesTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.DatabasesTreeView_NodeMouseDoubleClick);
            // 
            // ETLParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 696);
            this.Controls.Add(this.mainSplitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "ETLParent";
            this.Text = "ETL Studio";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.mainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitContainer)).EndInit();
            this.mainSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem databaseMenu;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ETLMenu;
        private System.Windows.Forms.ToolStripMenuItem createStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewMenu;
        private System.Windows.Forms.ToolStripMenuItem toolBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusBarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsMenu;
        private System.Windows.Forms.ToolStripMenuItem createJobToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.SplitContainer mainSplitContainer;
        private System.Windows.Forms.TreeView databasesTreeView;
        private System.Windows.Forms.ToolStripMenuItem RunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mappingMenu;
        private System.Windows.Forms.ToolStripMenuItem editMappingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewEditToolStripMenuItem;
    }
}



