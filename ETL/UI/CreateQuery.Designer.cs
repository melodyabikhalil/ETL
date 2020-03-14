namespace ETL.UI
{
    partial class CreateQuery
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
            this.buildQueryTabPage = new System.Windows.Forms.TabPage();
            this.mainTableLabel = new System.Windows.Forms.Label();
            this.mainTableCombobox = new System.Windows.Forms.ComboBox();
            this.goToBuildQueryTabFromMainTableTabButton = new System.Windows.Forms.Button();
            this.goBackToMainTableTabFromBuildQueryTabButton = new System.Windows.Forms.Button();
            this.goToSelectColumnsTabFromBuildQueryTabButton = new System.Windows.Forms.Button();
            this.buildQueryDataGridView = new System.Windows.Forms.DataGridView();
            this.selectColumnsTabPage = new System.Windows.Forms.TabPage();
            this.selectColumnsDataGridView = new System.Windows.Forms.DataGridView();
            this.buildQueryLabel = new System.Windows.Forms.Label();
            this.goBackToBuildQueryTabFromSelectColumnsTabButton = new System.Windows.Forms.Button();
            this.goToPreviewTabFromSelectColumnsTabButton = new System.Windows.Forms.Button();
            this.selectColumnsLabel = new System.Windows.Forms.Label();
            this.queryPreviewTabPage = new System.Windows.Forms.TabPage();
            this.previewLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.goBackToSelectColumnsTabFromPreviewTabButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
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
            this.createQueryTabControl.Size = new System.Drawing.Size(1024, 592);
            this.createQueryTabControl.TabIndex = 0;
            // 
            // mainTableTabPage
            // 
            this.mainTableTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.mainTableTabPage.Controls.Add(this.goToBuildQueryTabFromMainTableTabButton);
            this.mainTableTabPage.Controls.Add(this.mainTableCombobox);
            this.mainTableTabPage.Controls.Add(this.mainTableLabel);
            this.mainTableTabPage.Location = new System.Drawing.Point(4, 22);
            this.mainTableTabPage.Name = "mainTableTabPage";
            this.mainTableTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.mainTableTabPage.Size = new System.Drawing.Size(1016, 566);
            this.mainTableTabPage.TabIndex = 0;
            this.mainTableTabPage.Text = "Main Table";
            this.mainTableTabPage.Click += new System.EventHandler(this.MainTableTabPage_Click);
            // 
            // buildQueryTabPage
            // 
            this.buildQueryTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.buildQueryTabPage.Controls.Add(this.buildQueryLabel);
            this.buildQueryTabPage.Controls.Add(this.buildQueryDataGridView);
            this.buildQueryTabPage.Controls.Add(this.goBackToMainTableTabFromBuildQueryTabButton);
            this.buildQueryTabPage.Controls.Add(this.goToSelectColumnsTabFromBuildQueryTabButton);
            this.buildQueryTabPage.Location = new System.Drawing.Point(4, 22);
            this.buildQueryTabPage.Name = "buildQueryTabPage";
            this.buildQueryTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.buildQueryTabPage.Size = new System.Drawing.Size(1016, 566);
            this.buildQueryTabPage.TabIndex = 1;
            this.buildQueryTabPage.Text = "Build Query";
            // 
            // mainTableLabel
            // 
            this.mainTableLabel.AutoSize = true;
            this.mainTableLabel.Location = new System.Drawing.Point(96, 82);
            this.mainTableLabel.Name = "mainTableLabel";
            this.mainTableLabel.Size = new System.Drawing.Size(142, 13);
            this.mainTableLabel.TabIndex = 0;
            this.mainTableLabel.Text = "Select the query\'s main table";
            // 
            // mainTableCombobox
            // 
            this.mainTableCombobox.FormattingEnabled = true;
            this.mainTableCombobox.Location = new System.Drawing.Point(142, 123);
            this.mainTableCombobox.Name = "mainTableCombobox";
            this.mainTableCombobox.Size = new System.Drawing.Size(180, 21);
            this.mainTableCombobox.TabIndex = 1;
            // 
            // goToBuildQueryTabFromMainTableTabButton
            // 
            this.goToBuildQueryTabFromMainTableTabButton.Location = new System.Drawing.Point(828, 493);
            this.goToBuildQueryTabFromMainTableTabButton.Name = "goToBuildQueryTabFromMainTableTabButton";
            this.goToBuildQueryTabFromMainTableTabButton.Size = new System.Drawing.Size(75, 23);
            this.goToBuildQueryTabFromMainTableTabButton.TabIndex = 8;
            this.goToBuildQueryTabFromMainTableTabButton.Text = "Next";
            this.goToBuildQueryTabFromMainTableTabButton.UseVisualStyleBackColor = true;
            // 
            // goBackToMainTableTabFromBuildQueryTabButton
            // 
            this.goBackToMainTableTabFromBuildQueryTabButton.Location = new System.Drawing.Point(743, 495);
            this.goBackToMainTableTabFromBuildQueryTabButton.Name = "goBackToMainTableTabFromBuildQueryTabButton";
            this.goBackToMainTableTabFromBuildQueryTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToMainTableTabFromBuildQueryTabButton.TabIndex = 11;
            this.goBackToMainTableTabFromBuildQueryTabButton.Text = "Back";
            this.goBackToMainTableTabFromBuildQueryTabButton.UseVisualStyleBackColor = true;
            // 
            // goToSelectColumnsTabFromBuildQueryTabButton
            // 
            this.goToSelectColumnsTabFromBuildQueryTabButton.Location = new System.Drawing.Point(837, 495);
            this.goToSelectColumnsTabFromBuildQueryTabButton.Name = "goToSelectColumnsTabFromBuildQueryTabButton";
            this.goToSelectColumnsTabFromBuildQueryTabButton.Size = new System.Drawing.Size(75, 23);
            this.goToSelectColumnsTabFromBuildQueryTabButton.TabIndex = 10;
            this.goToSelectColumnsTabFromBuildQueryTabButton.Text = "Next";
            this.goToSelectColumnsTabFromBuildQueryTabButton.UseVisualStyleBackColor = true;
            // 
            // buildQueryDataGridView
            // 
            this.buildQueryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.buildQueryDataGridView.Location = new System.Drawing.Point(25, 62);
            this.buildQueryDataGridView.Name = "buildQueryDataGridView";
            this.buildQueryDataGridView.Size = new System.Drawing.Size(962, 416);
            this.buildQueryDataGridView.TabIndex = 12;
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
            this.selectColumnsTabPage.Size = new System.Drawing.Size(1016, 566);
            this.selectColumnsTabPage.TabIndex = 2;
            this.selectColumnsTabPage.Text = "Select Columns";
            // 
            // selectColumnsDataGridView
            // 
            this.selectColumnsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectColumnsDataGridView.Location = new System.Drawing.Point(116, 104);
            this.selectColumnsDataGridView.Name = "selectColumnsDataGridView";
            this.selectColumnsDataGridView.Size = new System.Drawing.Size(731, 310);
            this.selectColumnsDataGridView.TabIndex = 0;
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
            // goBackToBuildQueryTabFromSelectColumnsTabButton
            // 
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Location = new System.Drawing.Point(749, 492);
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Name = "goBackToBuildQueryTabFromSelectColumnsTabButton";
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.TabIndex = 13;
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.Text = "Back";
            this.goBackToBuildQueryTabFromSelectColumnsTabButton.UseVisualStyleBackColor = true;
            // 
            // goToPreviewTabFromSelectColumnsTabButton
            // 
            this.goToPreviewTabFromSelectColumnsTabButton.Location = new System.Drawing.Point(843, 492);
            this.goToPreviewTabFromSelectColumnsTabButton.Name = "goToPreviewTabFromSelectColumnsTabButton";
            this.goToPreviewTabFromSelectColumnsTabButton.Size = new System.Drawing.Size(75, 23);
            this.goToPreviewTabFromSelectColumnsTabButton.TabIndex = 12;
            this.goToPreviewTabFromSelectColumnsTabButton.Text = "Next";
            this.goToPreviewTabFromSelectColumnsTabButton.UseVisualStyleBackColor = true;
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
            // queryPreviewTabPage
            // 
            this.queryPreviewTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.queryPreviewTabPage.Controls.Add(this.goBackToSelectColumnsTabFromPreviewTabButton);
            this.queryPreviewTabPage.Controls.Add(this.saveButton);
            this.queryPreviewTabPage.Controls.Add(this.richTextBox1);
            this.queryPreviewTabPage.Controls.Add(this.previewLabel);
            this.queryPreviewTabPage.Location = new System.Drawing.Point(4, 22);
            this.queryPreviewTabPage.Name = "queryPreviewTabPage";
            this.queryPreviewTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.queryPreviewTabPage.Size = new System.Drawing.Size(1016, 566);
            this.queryPreviewTabPage.TabIndex = 3;
            this.queryPreviewTabPage.Text = "Preview";
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
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(70, 106);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(642, 238);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // goBackToSelectColumnsTabFromPreviewTabButton
            // 
            this.goBackToSelectColumnsTabFromPreviewTabButton.Location = new System.Drawing.Point(748, 487);
            this.goBackToSelectColumnsTabFromPreviewTabButton.Name = "goBackToSelectColumnsTabFromPreviewTabButton";
            this.goBackToSelectColumnsTabFromPreviewTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToSelectColumnsTabFromPreviewTabButton.TabIndex = 15;
            this.goBackToSelectColumnsTabFromPreviewTabButton.Text = "Back";
            this.goBackToSelectColumnsTabFromPreviewTabButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(842, 487);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // CreateQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 592);
            this.Controls.Add(this.createQueryTabControl);
            this.Name = "CreateQuery";
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
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label previewLabel;
    }
}