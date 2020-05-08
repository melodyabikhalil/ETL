namespace ETL.UI
{
    partial class CreateQueryForm
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
            this.createQueryTabControl = new System.Windows.Forms.TabControl();
            this.mainTableTabPage = new System.Windows.Forms.TabPage();
            this.queryNameTextBox = new System.Windows.Forms.TextBox();
            this.queryNameLabel = new System.Windows.Forms.Label();
            this.goToBuildQueryTabFromMainTableTabButton = new System.Windows.Forms.Button();
            this.mainTableCombobox = new System.Windows.Forms.ComboBox();
            this.mainTableLabel = new System.Windows.Forms.Label();
            this.buildQueryTabPage = new System.Windows.Forms.TabPage();
            this.mainTableTextBox = new System.Windows.Forms.TextBox();
            this.mainTableNameLabel = new System.Windows.Forms.Label();
            this.buildQueryLabel = new System.Windows.Forms.Label();
            this.buildQueryDataGridView = new System.Windows.Forms.DataGridView();
            this.goBackToMainTableTabFromBuildQueryTabButton = new System.Windows.Forms.Button();
            this.goToSelectColumnsTabFromBuildQueryTabButton = new System.Windows.Forms.Button();
            this.selectColumnsTabPage = new System.Windows.Forms.TabPage();
            this.selectColumnsLabel = new System.Windows.Forms.Label();
            this.goBackToBuildQueryTabFromSelectColumnsTabButton = new System.Windows.Forms.Button();
            this.goToPreviewTabFromSelectColumnsTabButton = new System.Windows.Forms.Button();
            this.selectColumnsDataGridView = new System.Windows.Forms.DataGridView();
            this.queryPreviewTabPage = new System.Windows.Forms.TabPage();
            this.goBackToSelectColumnsTabFromPreviewTabButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.queryRichTextBox = new System.Windows.Forms.RichTextBox();
            this.previewLabel = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.createQueryTabControl.SuspendLayout();
            this.mainTableTabPage.SuspendLayout();
            this.buildQueryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buildQueryDataGridView)).BeginInit();
            this.selectColumnsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectColumnsDataGridView)).BeginInit();
            this.queryPreviewTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // createQueryTabControl
            // 
            this.createQueryTabControl.Controls.Add(this.mainTableTabPage);
            this.createQueryTabControl.Controls.Add(this.buildQueryTabPage);
            this.createQueryTabControl.Controls.Add(this.selectColumnsTabPage);
            this.createQueryTabControl.Controls.Add(this.queryPreviewTabPage);
            this.createQueryTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createQueryTabControl.Location = new System.Drawing.Point(0, 0);
            this.createQueryTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.createQueryTabControl.Name = "createQueryTabControl";
            this.createQueryTabControl.SelectedIndex = 0;
            this.createQueryTabControl.Size = new System.Drawing.Size(1305, 729);
            this.createQueryTabControl.TabIndex = 0;
            // 
            // mainTableTabPage
            // 
            this.mainTableTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.mainTableTabPage.Controls.Add(this.queryNameTextBox);
            this.mainTableTabPage.Controls.Add(this.queryNameLabel);
            this.mainTableTabPage.Controls.Add(this.goToBuildQueryTabFromMainTableTabButton);
            this.mainTableTabPage.Controls.Add(this.mainTableCombobox);
            this.mainTableTabPage.Controls.Add(this.mainTableLabel);
            this.mainTableTabPage.Location = new System.Drawing.Point(4, 25);
            this.mainTableTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTableTabPage.Name = "mainTableTabPage";
            this.mainTableTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTableTabPage.Size = new System.Drawing.Size(1297, 700);
            this.mainTableTabPage.TabIndex = 0;
            this.mainTableTabPage.Text = "Main Table";
            // 
            // queryNameTextBox
            // 
            this.queryNameTextBox.Location = new System.Drawing.Point(189, 318);
            this.queryNameTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.queryNameTextBox.Name = "queryNameTextBox";
            this.queryNameTextBox.Size = new System.Drawing.Size(277, 22);
            this.queryNameTextBox.TabIndex = 10;
            // 
            // queryNameLabel
            // 
            this.queryNameLabel.AutoSize = true;
            this.queryNameLabel.Location = new System.Drawing.Point(132, 261);
            this.queryNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.queryNameLabel.Name = "queryNameLabel";
            this.queryNameLabel.Size = new System.Drawing.Size(233, 17);
            this.queryNameLabel.TabIndex = 9;
            this.queryNameLabel.Text = "Choose a name for your new query:";
            // 
            // goToBuildQueryTabFromMainTableTabButton
            // 
            this.goToBuildQueryTabFromMainTableTabButton.Location = new System.Drawing.Point(1104, 607);
            this.goToBuildQueryTabFromMainTableTabButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goToBuildQueryTabFromMainTableTabButton.Name = "goToBuildQueryTabFromMainTableTabButton";
            this.goToBuildQueryTabFromMainTableTabButton.Size = new System.Drawing.Size(100, 28);
            this.goToBuildQueryTabFromMainTableTabButton.TabIndex = 8;
            this.goToBuildQueryTabFromMainTableTabButton.Text = "Next";
            this.goToBuildQueryTabFromMainTableTabButton.UseVisualStyleBackColor = true;
            this.goToBuildQueryTabFromMainTableTabButton.Click += new System.EventHandler(this.GoToBuildQueryTabFromMainTableTabButton_Click);
            // 
            // mainTableCombobox
            // 
            this.mainTableCombobox.FormattingEnabled = true;
            this.mainTableCombobox.Location = new System.Drawing.Point(189, 151);
            this.mainTableCombobox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTableCombobox.Name = "mainTableCombobox";
            this.mainTableCombobox.Size = new System.Drawing.Size(277, 24);
            this.mainTableCombobox.TabIndex = 1;
            // 
            // mainTableLabel
            // 
            this.mainTableLabel.AutoSize = true;
            this.mainTableLabel.Location = new System.Drawing.Point(128, 101);
            this.mainTableLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainTableLabel.Name = "mainTableLabel";
            this.mainTableLabel.Size = new System.Drawing.Size(194, 17);
            this.mainTableLabel.TabIndex = 0;
            this.mainTableLabel.Text = "Select the query\'s main table:";
            // 
            // buildQueryTabPage
            // 
            this.buildQueryTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.buildQueryTabPage.Controls.Add(this.helpButton);
            this.buildQueryTabPage.Controls.Add(this.mainTableTextBox);
            this.buildQueryTabPage.Controls.Add(this.mainTableNameLabel);
            this.buildQueryTabPage.Controls.Add(this.buildQueryLabel);
            this.buildQueryTabPage.Controls.Add(this.buildQueryDataGridView);
            this.buildQueryTabPage.Controls.Add(this.goBackToMainTableTabFromBuildQueryTabButton);
            this.buildQueryTabPage.Controls.Add(this.goToSelectColumnsTabFromBuildQueryTabButton);
            this.buildQueryTabPage.Location = new System.Drawing.Point(4, 25);
            this.buildQueryTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buildQueryTabPage.Name = "buildQueryTabPage";
            this.buildQueryTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buildQueryTabPage.Size = new System.Drawing.Size(1297, 700);
            this.buildQueryTabPage.TabIndex = 1;
            this.buildQueryTabPage.Text = "Build Query";
            // 
            // mainTableTextBox
            // 
            this.mainTableTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTableTextBox.Location = new System.Drawing.Point(135, 69);
            this.mainTableTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainTableTextBox.Name = "mainTableTextBox";
            this.mainTableTextBox.ReadOnly = true;
            this.mainTableTextBox.Size = new System.Drawing.Size(187, 24);
            this.mainTableTextBox.TabIndex = 15;
            // 
            // mainTableNameLabel
            // 
            this.mainTableNameLabel.AutoSize = true;
            this.mainTableNameLabel.Location = new System.Drawing.Point(48, 73);
            this.mainTableNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainTableNameLabel.Name = "mainTableNameLabel";
            this.mainTableNameLabel.Size = new System.Drawing.Size(77, 17);
            this.mainTableNameLabel.TabIndex = 14;
            this.mainTableNameLabel.Text = "Main table:";
            // 
            // buildQueryLabel
            // 
            this.buildQueryLabel.AutoSize = true;
            this.buildQueryLabel.Location = new System.Drawing.Point(47, 34);
            this.buildQueryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buildQueryLabel.Name = "buildQueryLabel";
            this.buildQueryLabel.Size = new System.Drawing.Size(395, 17);
            this.buildQueryLabel.TabIndex = 13;
            this.buildQueryLabel.Text = "Build join query. Choose the join type, table and join columns.";
            // 
            // buildQueryDataGridView
            // 
            this.buildQueryDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.buildQueryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buildQueryDataGridView.Location = new System.Drawing.Point(52, 116);
            this.buildQueryDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buildQueryDataGridView.Name = "buildQueryDataGridView";
            this.buildQueryDataGridView.RowHeadersWidth = 51;
            this.buildQueryDataGridView.Size = new System.Drawing.Size(1191, 468);
            this.buildQueryDataGridView.TabIndex = 12;
            this.buildQueryDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.BuildQueryDataGridView_CellEndEdit);
            // 
            // goBackToMainTableTabFromBuildQueryTabButton
            // 
            this.goBackToMainTableTabFromBuildQueryTabButton.Location = new System.Drawing.Point(1004, 617);
            this.goBackToMainTableTabFromBuildQueryTabButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goBackToMainTableTabFromBuildQueryTabButton.Name = "goBackToMainTableTabFromBuildQueryTabButton";
            this.goBackToMainTableTabFromBuildQueryTabButton.Size = new System.Drawing.Size(100, 28);
            this.goBackToMainTableTabFromBuildQueryTabButton.TabIndex = 11;
            this.goBackToMainTableTabFromBuildQueryTabButton.Text = "Back";
            this.goBackToMainTableTabFromBuildQueryTabButton.UseVisualStyleBackColor = true;
            this.goBackToMainTableTabFromBuildQueryTabButton.Click += new System.EventHandler(this.GoBackToMainTableTabFromBuildQueryTabButton_Click);
            // 
            // goToSelectColumnsTabFromBuildQueryTabButton
            // 
            this.goToSelectColumnsTabFromBuildQueryTabButton.Location = new System.Drawing.Point(1129, 617);
            this.goToSelectColumnsTabFromBuildQueryTabButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goToSelectColumnsTabFromBuildQueryTabButton.Name = "goToSelectColumnsTabFromBuildQueryTabButton";
            this.goToSelectColumnsTabFromBuildQueryTabButton.Size = new System.Drawing.Size(100, 28);
            this.goToSelectColumnsTabFromBuildQueryTabButton.TabIndex = 10;
            this.goToSelectColumnsTabFromBuildQueryTabButton.Text = "Next";
            this.goToSelectColumnsTabFromBuildQueryTabButton.UseVisualStyleBackColor = true;
            this.goToSelectColumnsTabFromBuildQueryTabButton.Click += new System.EventHandler(this.GoToSelectColumnsTabFromBuildQueryTabButton_Click);
            // 
            // selectColumnsTabPage
            // 
            this.selectColumnsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.selectColumnsTabPage.Controls.Add(this.selectColumnsLabel);
            this.selectColumnsTabPage.Controls.Add(this.goBackToBuildQueryTabFromSelectColumnsTabButton);
            this.selectColumnsTabPage.Controls.Add(this.goToPreviewTabFromSelectColumnsTabButton);
            this.selectColumnsTabPage.Controls.Add(this.selectColumnsDataGridView);
            this.selectColumnsTabPage.Location = new System.Drawing.Point(4, 25);
            this.selectColumnsTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectColumnsTabPage.Name = "selectColumnsTabPage";
            this.selectColumnsTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectColumnsTabPage.Size = new System.Drawing.Size(1297, 700);
            this.selectColumnsTabPage.TabIndex = 2;
            this.selectColumnsTabPage.Text = "Select Columns";
            // 
            // selectColumnsLabel
            // 
            this.selectColumnsLabel.AutoSize = true;
            this.selectColumnsLabel.Location = new System.Drawing.Point(79, 48);
            this.selectColumnsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.selectColumnsLabel.Name = "selectColumnsLabel";
            this.selectColumnsLabel.Size = new System.Drawing.Size(336, 17);
            this.selectColumnsLabel.TabIndex = 14;
            this.selectColumnsLabel.Text = "Choose the columns you wish to select in this query.";
            // 
            // goBackToBuildQueryTabFromSelectColumnsTabButton
            // 
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Location = new System.Drawing.Point(1011, 628);
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Name = "goBackToBuildQueryTabFromSelectColumnsTabButton";
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Size = new System.Drawing.Size(100, 28);
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.TabIndex = 13;
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Text = "Back";
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.UseVisualStyleBackColor = true;
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Click += new System.EventHandler(this.GoBackToBuildQueryTabFromSelectColumnsTabButton_Click);
            // 
            // goToPreviewTabFromSelectColumnsTabButton
            // 
            this.goToPreviewTabFromSelectColumnsTabButton.Location = new System.Drawing.Point(1136, 628);
            this.goToPreviewTabFromSelectColumnsTabButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goToPreviewTabFromSelectColumnsTabButton.Name = "goToPreviewTabFromSelectColumnsTabButton";
            this.goToPreviewTabFromSelectColumnsTabButton.Size = new System.Drawing.Size(100, 28);
            this.goToPreviewTabFromSelectColumnsTabButton.TabIndex = 12;
            this.goToPreviewTabFromSelectColumnsTabButton.Text = "Next";
            this.goToPreviewTabFromSelectColumnsTabButton.UseVisualStyleBackColor = true;
            this.goToPreviewTabFromSelectColumnsTabButton.Click += new System.EventHandler(this.GoToPreviewTabFromSelectColumnsTabButton_Click);
            // 
            // selectColumnsDataGridView
            // 
            this.selectColumnsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.selectColumnsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectColumnsDataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.selectColumnsDataGridView.Location = new System.Drawing.Point(339, 78);
            this.selectColumnsDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.selectColumnsDataGridView.Name = "selectColumnsDataGridView";
            this.selectColumnsDataGridView.RowHeadersWidth = 51;
            this.selectColumnsDataGridView.Size = new System.Drawing.Size(656, 521);
            this.selectColumnsDataGridView.TabIndex = 0;
            // 
            // queryPreviewTabPage
            // 
            this.queryPreviewTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.queryPreviewTabPage.Controls.Add(this.goBackToSelectColumnsTabFromPreviewTabButton);
            this.queryPreviewTabPage.Controls.Add(this.saveButton);
            this.queryPreviewTabPage.Controls.Add(this.queryRichTextBox);
            this.queryPreviewTabPage.Controls.Add(this.previewLabel);
            this.queryPreviewTabPage.Location = new System.Drawing.Point(4, 25);
            this.queryPreviewTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.queryPreviewTabPage.Name = "queryPreviewTabPage";
            this.queryPreviewTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.queryPreviewTabPage.Size = new System.Drawing.Size(1297, 700);
            this.queryPreviewTabPage.TabIndex = 3;
            this.queryPreviewTabPage.Text = "Preview";
            // 
            // goBackToSelectColumnsTabFromPreviewTabButton
            // 
            this.goBackToSelectColumnsTabFromPreviewTabButton.Location = new System.Drawing.Point(1012, 622);
            this.goBackToSelectColumnsTabFromPreviewTabButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.goBackToSelectColumnsTabFromPreviewTabButton.Name = "goBackToSelectColumnsTabFromPreviewTabButton";
            this.goBackToSelectColumnsTabFromPreviewTabButton.Size = new System.Drawing.Size(100, 28);
            this.goBackToSelectColumnsTabFromPreviewTabButton.TabIndex = 15;
            this.goBackToSelectColumnsTabFromPreviewTabButton.Text = "Back";
            this.goBackToSelectColumnsTabFromPreviewTabButton.UseVisualStyleBackColor = true;
            this.goBackToSelectColumnsTabFromPreviewTabButton.Click += new System.EventHandler(this.GoBackToSelectColumnsTabFromPreviewTabButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1137, 622);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // queryRichTextBox
            // 
            this.queryRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryRichTextBox.Location = new System.Drawing.Point(43, 105);
            this.queryRichTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.queryRichTextBox.Name = "queryRichTextBox";
            this.queryRichTextBox.Size = new System.Drawing.Size(1193, 498);
            this.queryRichTextBox.TabIndex = 1;
            this.queryRichTextBox.Text = "";
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(39, 41);
            this.previewLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(855, 17);
            this.previewLabel.TabIndex = 0;
            this.previewLabel.Text = "This is a preview of how your query will look like. If you wish to change anythin" +
    "g, please go back to previous steps and do the changes.";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(1215, 68);
            this.helpButton.Margin = new System.Windows.Forms.Padding(4);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(28, 25);
            this.helpButton.TabIndex = 18;
            this.helpButton.Text = "?";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // CreateQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 729);
            this.Controls.Add(this.createQueryTabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CreateQueryForm";
            this.Text = "Create new query";
            this.createQueryTabControl.ResumeLayout(false);
            this.mainTableTabPage.ResumeLayout(false);
            this.mainTableTabPage.PerformLayout();
            this.buildQueryTabPage.ResumeLayout(false);
            this.buildQueryTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buildQueryDataGridView)).EndInit();
            this.selectColumnsTabPage.ResumeLayout(false);
            this.selectColumnsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectColumnsDataGridView)).EndInit();
            this.queryPreviewTabPage.ResumeLayout(false);
            this.queryPreviewTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl createQueryTabControl;
        private System.Windows.Forms.TabPage mainTableTabPage;
        private System.Windows.Forms.ComboBox mainTableCombobox;
        private System.Windows.Forms.Label mainTableLabel;
        private System.Windows.Forms.TabPage buildQueryTabPage;
        private System.Windows.Forms.Button goToBuildQueryTabFromMainTableTabButton;
        private System.Windows.Forms.Button goBackToMainTableTabFromBuildQueryTabButton;
        private System.Windows.Forms.Button goToSelectColumnsTabFromBuildQueryTabButton;
        private System.Windows.Forms.DataGridView buildQueryDataGridView;
        private System.Windows.Forms.Label buildQueryLabel;
        private System.Windows.Forms.TabPage selectColumnsTabPage;
        private System.Windows.Forms.Label selectColumnsLabel;
        private System.Windows.Forms.Button goBackToBuildQueryTabFromSelectColumnsTabButton;
        private System.Windows.Forms.Button goToPreviewTabFromSelectColumnsTabButton;
        private System.Windows.Forms.DataGridView selectColumnsDataGridView;
        private System.Windows.Forms.TabPage queryPreviewTabPage;
        private System.Windows.Forms.Button goBackToSelectColumnsTabFromPreviewTabButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.RichTextBox queryRichTextBox;
        private System.Windows.Forms.Label previewLabel;
        private System.Windows.Forms.TextBox mainTableTextBox;
        private System.Windows.Forms.Label mainTableNameLabel;
        private System.Windows.Forms.TextBox queryNameTextBox;
        private System.Windows.Forms.Label queryNameLabel;
        private System.Windows.Forms.Button helpButton;
    }
}