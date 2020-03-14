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
            this.queryNameLabel = new System.Windows.Forms.Label();
            this.queryNameTextBox = new System.Windows.Forms.TextBox();
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
            this.createQueryTabControl.Name = "createQueryTabControl";
            this.createQueryTabControl.SelectedIndex = 0;
            this.createQueryTabControl.Size = new System.Drawing.Size(984, 592);
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
            this.mainTableTabPage.Location = new System.Drawing.Point(4, 22);
            this.mainTableTabPage.Name = "mainTableTabPage";
            this.mainTableTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTableTabPage.Size = new System.Drawing.Size(976, 566);
            this.mainTableTabPage.TabIndex = 0;
            this.mainTableTabPage.Text = "Main Table";
            // 
            // goToBuildQueryTabFromMainTableTabButton
            // 
            this.goToBuildQueryTabFromMainTableTabButton.Location = new System.Drawing.Point(828, 493);
            this.goToBuildQueryTabFromMainTableTabButton.Name = "goToBuildQueryTabFromMainTableTabButton";
            this.goToBuildQueryTabFromMainTableTabButton.Size = new System.Drawing.Size(75, 23);
            this.goToBuildQueryTabFromMainTableTabButton.TabIndex = 8;
            this.goToBuildQueryTabFromMainTableTabButton.Text = "Next";
            this.goToBuildQueryTabFromMainTableTabButton.UseVisualStyleBackColor = true;
            this.goToBuildQueryTabFromMainTableTabButton.Click += new System.EventHandler(this.GoToBuildQueryTabFromMainTableTabButton_Click);
            // 
            // mainTableCombobox
            // 
            this.mainTableCombobox.FormattingEnabled = true;
            this.mainTableCombobox.Location = new System.Drawing.Point(142, 123);
            this.mainTableCombobox.Name = "mainTableCombobox";
            this.mainTableCombobox.Size = new System.Drawing.Size(209, 21);
            this.mainTableCombobox.TabIndex = 1;
            // 
            // mainTableLabel
            // 
            this.mainTableLabel.AutoSize = true;
            this.mainTableLabel.Location = new System.Drawing.Point(96, 82);
            this.mainTableLabel.Name = "mainTableLabel";
            this.mainTableLabel.Size = new System.Drawing.Size(145, 13);
            this.mainTableLabel.TabIndex = 0;
            this.mainTableLabel.Text = "Select the query\'s main table:";
            // 
            // buildQueryTabPage
            // 
            this.buildQueryTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.buildQueryTabPage.Controls.Add(this.mainTableTextBox);
            this.buildQueryTabPage.Controls.Add(this.mainTableNameLabel);
            this.buildQueryTabPage.Controls.Add(this.buildQueryLabel);
            this.buildQueryTabPage.Controls.Add(this.buildQueryDataGridView);
            this.buildQueryTabPage.Controls.Add(this.goBackToMainTableTabFromBuildQueryTabButton);
            this.buildQueryTabPage.Controls.Add(this.goToSelectColumnsTabFromBuildQueryTabButton);
            this.buildQueryTabPage.Location = new System.Drawing.Point(4, 22);
            this.buildQueryTabPage.Name = "buildQueryTabPage";
            this.buildQueryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.buildQueryTabPage.Size = new System.Drawing.Size(976, 566);
            this.buildQueryTabPage.TabIndex = 1;
            this.buildQueryTabPage.Text = "Build Query";
            // 
            // mainTableTextBox
            // 
            this.mainTableTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTableTextBox.Location = new System.Drawing.Point(91, 50);
            this.mainTableTextBox.Name = "mainTableTextBox";
            this.mainTableTextBox.ReadOnly = true;
            this.mainTableTextBox.Size = new System.Drawing.Size(141, 20);
            this.mainTableTextBox.TabIndex = 15;
            // 
            // mainTableNameLabel
            // 
            this.mainTableNameLabel.AutoSize = true;
            this.mainTableNameLabel.Location = new System.Drawing.Point(26, 53);
            this.mainTableNameLabel.Name = "mainTableNameLabel";
            this.mainTableNameLabel.Size = new System.Drawing.Size(59, 13);
            this.mainTableNameLabel.TabIndex = 14;
            this.mainTableNameLabel.Text = "Main table:";
            // 
            // buildQueryLabel
            // 
            this.buildQueryLabel.AutoSize = true;
            this.buildQueryLabel.Location = new System.Drawing.Point(25, 22);
            this.buildQueryLabel.Name = "buildQueryLabel";
            this.buildQueryLabel.Size = new System.Drawing.Size(294, 13);
            this.buildQueryLabel.TabIndex = 13;
            this.buildQueryLabel.Text = "Build join query. Choose the join type, table and join columns.";
            // 
            // buildQueryDataGridView
            // 
            this.buildQueryDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.buildQueryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buildQueryDataGridView.Location = new System.Drawing.Point(29, 88);
            this.buildQueryDataGridView.Name = "buildQueryDataGridView";
            this.buildQueryDataGridView.Size = new System.Drawing.Size(893, 380);
            this.buildQueryDataGridView.TabIndex = 12;
            this.buildQueryDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.BuildQueryDataGridView_CellEndEdit);
            // 
            // goBackToMainTableTabFromBuildQueryTabButton
            // 
            this.goBackToMainTableTabFromBuildQueryTabButton.Location = new System.Drawing.Point(743, 495);
            this.goBackToMainTableTabFromBuildQueryTabButton.Name = "goBackToMainTableTabFromBuildQueryTabButton";
            this.goBackToMainTableTabFromBuildQueryTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToMainTableTabFromBuildQueryTabButton.TabIndex = 11;
            this.goBackToMainTableTabFromBuildQueryTabButton.Text = "Back";
            this.goBackToMainTableTabFromBuildQueryTabButton.UseVisualStyleBackColor = true;
            this.goBackToMainTableTabFromBuildQueryTabButton.Click += new System.EventHandler(this.GoBackToMainTableTabFromBuildQueryTabButton_Click);
            // 
            // goToSelectColumnsTabFromBuildQueryTabButton
            // 
            this.goToSelectColumnsTabFromBuildQueryTabButton.Location = new System.Drawing.Point(837, 495);
            this.goToSelectColumnsTabFromBuildQueryTabButton.Name = "goToSelectColumnsTabFromBuildQueryTabButton";
            this.goToSelectColumnsTabFromBuildQueryTabButton.Size = new System.Drawing.Size(75, 23);
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
            this.selectColumnsTabPage.Location = new System.Drawing.Point(4, 22);
            this.selectColumnsTabPage.Name = "selectColumnsTabPage";
            this.selectColumnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.selectColumnsTabPage.Size = new System.Drawing.Size(976, 566);
            this.selectColumnsTabPage.TabIndex = 2;
            this.selectColumnsTabPage.Text = "Select Columns";
            // 
            // selectColumnsLabel
            // 
            this.selectColumnsLabel.AutoSize = true;
            this.selectColumnsLabel.Location = new System.Drawing.Point(59, 39);
            this.selectColumnsLabel.Name = "selectColumnsLabel";
            this.selectColumnsLabel.Size = new System.Drawing.Size(252, 13);
            this.selectColumnsLabel.TabIndex = 14;
            this.selectColumnsLabel.Text = "Choose the columns you wish to select in this query.";
            // 
            // goBackToBuildQueryTabFromSelectColumnsTabButton
            // 
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Location = new System.Drawing.Point(749, 492);
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Name = "goBackToBuildQueryTabFromSelectColumnsTabButton";
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.TabIndex = 13;
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Text = "Back";
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.UseVisualStyleBackColor = true;
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Click += new System.EventHandler(this.GoBackToBuildQueryTabFromSelectColumnsTabButton_Click);
            // 
            // goToPreviewTabFromSelectColumnsTabButton
            // 
            this.goToPreviewTabFromSelectColumnsTabButton.Location = new System.Drawing.Point(843, 492);
            this.goToPreviewTabFromSelectColumnsTabButton.Name = "goToPreviewTabFromSelectColumnsTabButton";
            this.goToPreviewTabFromSelectColumnsTabButton.Size = new System.Drawing.Size(75, 23);
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
            this.selectColumnsDataGridView.Location = new System.Drawing.Point(342, 76);
            this.selectColumnsDataGridView.Name = "selectColumnsDataGridView";
            this.selectColumnsDataGridView.Size = new System.Drawing.Size(292, 382);
            this.selectColumnsDataGridView.TabIndex = 0;
            // 
            // queryPreviewTabPage
            // 
            this.queryPreviewTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.queryPreviewTabPage.Controls.Add(this.goBackToSelectColumnsTabFromPreviewTabButton);
            this.queryPreviewTabPage.Controls.Add(this.saveButton);
            this.queryPreviewTabPage.Controls.Add(this.queryRichTextBox);
            this.queryPreviewTabPage.Controls.Add(this.previewLabel);
            this.queryPreviewTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryPreviewTabPage.Name = "queryPreviewTabPage";
            this.queryPreviewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.queryPreviewTabPage.Size = new System.Drawing.Size(976, 566);
            this.queryPreviewTabPage.TabIndex = 3;
            this.queryPreviewTabPage.Text = "Preview";
            // 
            // goBackToSelectColumnsTabFromPreviewTabButton
            // 
            this.goBackToSelectColumnsTabFromPreviewTabButton.Location = new System.Drawing.Point(748, 487);
            this.goBackToSelectColumnsTabFromPreviewTabButton.Name = "goBackToSelectColumnsTabFromPreviewTabButton";
            this.goBackToSelectColumnsTabFromPreviewTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToSelectColumnsTabFromPreviewTabButton.TabIndex = 15;
            this.goBackToSelectColumnsTabFromPreviewTabButton.Text = "Back";
            this.goBackToSelectColumnsTabFromPreviewTabButton.UseVisualStyleBackColor = true;
            this.goBackToSelectColumnsTabFromPreviewTabButton.Click += new System.EventHandler(this.GoBackToSelectColumnsTabFromPreviewTabButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(842, 487);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // queryRichTextBox
            // 
            this.queryRichTextBox.Location = new System.Drawing.Point(70, 106);
            this.queryRichTextBox.Name = "queryRichTextBox";
            this.queryRichTextBox.Size = new System.Drawing.Size(642, 238);
            this.queryRichTextBox.TabIndex = 1;
            this.queryRichTextBox.Text = "";
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(67, 40);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(645, 13);
            this.previewLabel.TabIndex = 0;
            this.previewLabel.Text = "This is a preview of how your query will look like. If you wish to change anythin" +
    "g, please go back to previous steps and do the changes.";
            // 
            // queryNameLabel
            // 
            this.queryNameLabel.AutoSize = true;
            this.queryNameLabel.Location = new System.Drawing.Point(99, 212);
            this.queryNameLabel.Name = "queryNameLabel";
            this.queryNameLabel.Size = new System.Drawing.Size(174, 13);
            this.queryNameLabel.TabIndex = 9;
            this.queryNameLabel.Text = "Choose a name for your new query:";
            // 
            // queryNameTextBox
            // 
            this.queryNameTextBox.Location = new System.Drawing.Point(142, 258);
            this.queryNameTextBox.Name = "queryNameTextBox";
            this.queryNameTextBox.Size = new System.Drawing.Size(209, 20);
            this.queryNameTextBox.TabIndex = 10;
            // 
            // CreateQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 592);
            this.Controls.Add(this.createQueryTabControl);
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
    }
}