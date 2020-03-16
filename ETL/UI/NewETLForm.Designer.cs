namespace ETL.UI
{
    partial class NewETLForm
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
            this.ETLTabControl = new System.Windows.Forms.TabControl();
            this.ETLNameTab = new System.Windows.Forms.TabPage();
            this.fromETLNameToSrcDrstDbButton = new System.Windows.Forms.Button();
            this.ETLNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SrcDestDbTab = new System.Windows.Forms.TabPage();
            this.backFromSrcDestDbToETLNameButton = new System.Windows.Forms.Button();
            this.fromSrcDestDbToSrcDestTablesButton = new System.Windows.Forms.Button();
            this.destinationDbComboBox = new System.Windows.Forms.ComboBox();
            this.sourceDbComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SrcDestTablesTab = new System.Windows.Forms.TabPage();
            this.backToSrcDestDbFromSrcDestTablesButton = new System.Windows.Forms.Button();
            this.fromSrcDestTablesToExpressionButton = new System.Windows.Forms.Button();
            this.destTableComboBox = new System.Windows.Forms.ComboBox();
            this.srcTableOrQueriesComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ExpressionTab = new System.Windows.Forms.TabPage();
            this.backToSrcDestTablesTabButton = new System.Windows.Forms.Button();
            this.DoneButton = new System.Windows.Forms.Button();
            this.ExpressionDataGridView = new System.Windows.Forms.DataGridView();
            this.ETLTabControl.SuspendLayout();
            this.ETLNameTab.SuspendLayout();
            this.SrcDestDbTab.SuspendLayout();
            this.SrcDestTablesTab.SuspendLayout();
            this.ExpressionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpressionDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ETLTabControl
            // 
            this.ETLTabControl.Controls.Add(this.ETLNameTab);
            this.ETLTabControl.Controls.Add(this.SrcDestDbTab);
            this.ETLTabControl.Controls.Add(this.SrcDestTablesTab);
            this.ETLTabControl.Controls.Add(this.ExpressionTab);
            this.ETLTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ETLTabControl.Location = new System.Drawing.Point(0, 0);
            this.ETLTabControl.Name = "ETLTabControl";
            this.ETLTabControl.SelectedIndex = 0;
            this.ETLTabControl.Size = new System.Drawing.Size(984, 591);
            this.ETLTabControl.TabIndex = 0;
            // 
            // ETLNameTab
            // 
            this.ETLNameTab.BackColor = System.Drawing.SystemColors.Control;
            this.ETLNameTab.Controls.Add(this.fromETLNameToSrcDrstDbButton);
            this.ETLNameTab.Controls.Add(this.ETLNameTextBox);
            this.ETLNameTab.Controls.Add(this.label1);
            this.ETLNameTab.Location = new System.Drawing.Point(4, 22);
            this.ETLNameTab.Name = "ETLNameTab";
            this.ETLNameTab.Padding = new System.Windows.Forms.Padding(3);
            this.ETLNameTab.Size = new System.Drawing.Size(976, 565);
            this.ETLNameTab.TabIndex = 0;
            this.ETLNameTab.Text = "ETL Name";
            // 
            // fromETLNameToSrcDrstDbButton
            // 
            this.fromETLNameToSrcDrstDbButton.Location = new System.Drawing.Point(878, 524);
            this.fromETLNameToSrcDrstDbButton.Name = "fromETLNameToSrcDrstDbButton";
            this.fromETLNameToSrcDrstDbButton.Size = new System.Drawing.Size(75, 23);
            this.fromETLNameToSrcDrstDbButton.TabIndex = 8;
            this.fromETLNameToSrcDrstDbButton.Text = "Next";
            this.fromETLNameToSrcDrstDbButton.UseVisualStyleBackColor = true;
            this.fromETLNameToSrcDrstDbButton.Click += new System.EventHandler(this.fromETLNameToSrcDrstDbButton_Click);
            // 
            // ETLNameTextBox
            // 
            this.ETLNameTextBox.Location = new System.Drawing.Point(70, 101);
            this.ETLNameTextBox.Name = "ETLNameTextBox";
            this.ETLNameTextBox.Size = new System.Drawing.Size(134, 20);
            this.ETLNameTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a name for the ETL";
            // 
            // SrcDestDbTab
            // 
            this.SrcDestDbTab.BackColor = System.Drawing.SystemColors.Control;
            this.SrcDestDbTab.Controls.Add(this.backFromSrcDestDbToETLNameButton);
            this.SrcDestDbTab.Controls.Add(this.fromSrcDestDbToSrcDestTablesButton);
            this.SrcDestDbTab.Controls.Add(this.destinationDbComboBox);
            this.SrcDestDbTab.Controls.Add(this.sourceDbComboBox);
            this.SrcDestDbTab.Controls.Add(this.label4);
            this.SrcDestDbTab.Controls.Add(this.label3);
            this.SrcDestDbTab.Controls.Add(this.label2);
            this.SrcDestDbTab.Location = new System.Drawing.Point(4, 22);
            this.SrcDestDbTab.Name = "SrcDestDbTab";
            this.SrcDestDbTab.Padding = new System.Windows.Forms.Padding(3);
            this.SrcDestDbTab.Size = new System.Drawing.Size(976, 565);
            this.SrcDestDbTab.TabIndex = 1;
            this.SrcDestDbTab.Text = "Source & Destination Databases";
            // 
            // backFromSrcDestDbToETLNameButton
            // 
            this.backFromSrcDestDbToETLNameButton.Location = new System.Drawing.Point(767, 521);
            this.backFromSrcDestDbToETLNameButton.Name = "backFromSrcDestDbToETLNameButton";
            this.backFromSrcDestDbToETLNameButton.Size = new System.Drawing.Size(75, 23);
            this.backFromSrcDestDbToETLNameButton.TabIndex = 10;
            this.backFromSrcDestDbToETLNameButton.Text = "Back";
            this.backFromSrcDestDbToETLNameButton.UseVisualStyleBackColor = true;
            this.backFromSrcDestDbToETLNameButton.Click += new System.EventHandler(this.backFromSrcDestDbToETLNameButton_Click);
            // 
            // fromSrcDestDbToSrcDestTablesButton
            // 
            this.fromSrcDestDbToSrcDestTablesButton.Location = new System.Drawing.Point(872, 521);
            this.fromSrcDestDbToSrcDestTablesButton.Name = "fromSrcDestDbToSrcDestTablesButton";
            this.fromSrcDestDbToSrcDestTablesButton.Size = new System.Drawing.Size(75, 23);
            this.fromSrcDestDbToSrcDestTablesButton.TabIndex = 9;
            this.fromSrcDestDbToSrcDestTablesButton.Text = "Next";
            this.fromSrcDestDbToSrcDestTablesButton.UseVisualStyleBackColor = true;
            this.fromSrcDestDbToSrcDestTablesButton.Click += new System.EventHandler(this.fromSrcDestDbToSrcDestTablesButton_Click);
            // 
            // destinationDbComboBox
            // 
            this.destinationDbComboBox.FormattingEnabled = true;
            this.destinationDbComboBox.Location = new System.Drawing.Point(136, 153);
            this.destinationDbComboBox.Name = "destinationDbComboBox";
            this.destinationDbComboBox.Size = new System.Drawing.Size(121, 21);
            this.destinationDbComboBox.TabIndex = 4;
            // 
            // sourceDbComboBox
            // 
            this.sourceDbComboBox.FormattingEnabled = true;
            this.sourceDbComboBox.Location = new System.Drawing.Point(137, 101);
            this.sourceDbComboBox.Name = "sourceDbComboBox";
            this.sourceDbComboBox.Size = new System.Drawing.Size(121, 21);
            this.sourceDbComboBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Destination";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Choose source and destination databases";
            // 
            // SrcDestTablesTab
            // 
            this.SrcDestTablesTab.BackColor = System.Drawing.SystemColors.Control;
            this.SrcDestTablesTab.Controls.Add(this.backToSrcDestDbFromSrcDestTablesButton);
            this.SrcDestTablesTab.Controls.Add(this.fromSrcDestTablesToExpressionButton);
            this.SrcDestTablesTab.Controls.Add(this.destTableComboBox);
            this.SrcDestTablesTab.Controls.Add(this.srcTableOrQueriesComboBox);
            this.SrcDestTablesTab.Controls.Add(this.label6);
            this.SrcDestTablesTab.Controls.Add(this.label7);
            this.SrcDestTablesTab.Controls.Add(this.label5);
            this.SrcDestTablesTab.Location = new System.Drawing.Point(4, 22);
            this.SrcDestTablesTab.Name = "SrcDestTablesTab";
            this.SrcDestTablesTab.Padding = new System.Windows.Forms.Padding(3);
            this.SrcDestTablesTab.Size = new System.Drawing.Size(976, 565);
            this.SrcDestTablesTab.TabIndex = 2;
            this.SrcDestTablesTab.Text = "Source & Destination Tables";
            // 
            // backToSrcDestDbFromSrcDestTablesButton
            // 
            this.backToSrcDestDbFromSrcDestTablesButton.Location = new System.Drawing.Point(774, 521);
            this.backToSrcDestDbFromSrcDestTablesButton.Name = "backToSrcDestDbFromSrcDestTablesButton";
            this.backToSrcDestDbFromSrcDestTablesButton.Size = new System.Drawing.Size(75, 23);
            this.backToSrcDestDbFromSrcDestTablesButton.TabIndex = 12;
            this.backToSrcDestDbFromSrcDestTablesButton.Text = "Back";
            this.backToSrcDestDbFromSrcDestTablesButton.UseVisualStyleBackColor = true;
            this.backToSrcDestDbFromSrcDestTablesButton.Click += new System.EventHandler(this.backToSrcDestDbFromSrcDestTables_Click);
            // 
            // fromSrcDestTablesToExpressionButton
            // 
            this.fromSrcDestTablesToExpressionButton.Location = new System.Drawing.Point(879, 521);
            this.fromSrcDestTablesToExpressionButton.Name = "fromSrcDestTablesToExpressionButton";
            this.fromSrcDestTablesToExpressionButton.Size = new System.Drawing.Size(75, 23);
            this.fromSrcDestTablesToExpressionButton.TabIndex = 11;
            this.fromSrcDestTablesToExpressionButton.Text = "Next";
            this.fromSrcDestTablesToExpressionButton.UseVisualStyleBackColor = true;
            this.fromSrcDestTablesToExpressionButton.Click += new System.EventHandler(this.fromSrcDestTablesToExpression_Click);
            // 
            // destTableComboBox
            // 
            this.destTableComboBox.FormattingEnabled = true;
            this.destTableComboBox.Location = new System.Drawing.Point(152, 148);
            this.destTableComboBox.Name = "destTableComboBox";
            this.destTableComboBox.Size = new System.Drawing.Size(121, 21);
            this.destTableComboBox.TabIndex = 8;
            // 
            // srcTableOrQueriesComboBox
            // 
            this.srcTableOrQueriesComboBox.FormattingEnabled = true;
            this.srcTableOrQueriesComboBox.Location = new System.Drawing.Point(153, 96);
            this.srcTableOrQueriesComboBox.Name = "srcTableOrQueriesComboBox";
            this.srcTableOrQueriesComboBox.Size = new System.Drawing.Size(121, 21);
            this.srcTableOrQueriesComboBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Destination";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Choose source  and destination tables or queries";
            // 
            // ExpressionTab
            // 
            this.ExpressionTab.BackColor = System.Drawing.SystemColors.Control;
            this.ExpressionTab.Controls.Add(this.backToSrcDestTablesTabButton);
            this.ExpressionTab.Controls.Add(this.DoneButton);
            this.ExpressionTab.Controls.Add(this.ExpressionDataGridView);
            this.ExpressionTab.Location = new System.Drawing.Point(4, 22);
            this.ExpressionTab.Name = "ExpressionTab";
            this.ExpressionTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExpressionTab.Size = new System.Drawing.Size(976, 565);
            this.ExpressionTab.TabIndex = 3;
            this.ExpressionTab.Text = "Mapping Expressions";
            // 
            // backToSrcDestTablesTabButton
            // 
            this.backToSrcDestTablesTabButton.Location = new System.Drawing.Point(788, 524);
            this.backToSrcDestTablesTabButton.Name = "backToSrcDestTablesTabButton";
            this.backToSrcDestTablesTabButton.Size = new System.Drawing.Size(75, 23);
            this.backToSrcDestTablesTabButton.TabIndex = 14;
            this.backToSrcDestTablesTabButton.Text = "Back";
            this.backToSrcDestTablesTabButton.UseVisualStyleBackColor = true;
            this.backToSrcDestTablesTabButton.Click += new System.EventHandler(this.backToSrcDestTablesTabButton_Click);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(893, 524);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 13;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // ExpressionDataGridView
            // 
            this.ExpressionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExpressionDataGridView.Location = new System.Drawing.Point(26, 61);
            this.ExpressionDataGridView.Name = "ExpressionDataGridView";
            this.ExpressionDataGridView.Size = new System.Drawing.Size(931, 234);
            this.ExpressionDataGridView.TabIndex = 0;
            this.ExpressionDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(ExpressionDataGridView_RowsAdded);
            // 
            // NewETLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 591);
            this.Controls.Add(this.ETLTabControl);
            this.Name = "NewETLForm";
            this.Text = "NewETLForm";
            this.ETLTabControl.ResumeLayout(false);
            this.ETLNameTab.ResumeLayout(false);
            this.ETLNameTab.PerformLayout();
            this.SrcDestDbTab.ResumeLayout(false);
            this.SrcDestDbTab.PerformLayout();
            this.SrcDestTablesTab.ResumeLayout(false);
            this.SrcDestTablesTab.PerformLayout();
            this.ExpressionTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExpressionDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ETLTabControl;
        private System.Windows.Forms.TabPage ETLNameTab;
        private System.Windows.Forms.TabPage SrcDestDbTab;
        private System.Windows.Forms.TabPage SrcDestTablesTab;
        private System.Windows.Forms.TabPage ExpressionTab;
        private System.Windows.Forms.TextBox ETLNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button fromETLNameToSrcDrstDbButton;
        private System.Windows.Forms.ComboBox destinationDbComboBox;
        private System.Windows.Forms.ComboBox sourceDbComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button fromSrcDestDbToSrcDestTablesButton;
        private System.Windows.Forms.Button backFromSrcDestDbToETLNameButton;
        private System.Windows.Forms.ComboBox destTableComboBox;
        private System.Windows.Forms.ComboBox srcTableOrQueriesComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button backToSrcDestDbFromSrcDestTablesButton;
        private System.Windows.Forms.Button fromSrcDestTablesToExpressionButton;
        private System.Windows.Forms.DataGridView ExpressionDataGridView;
        private System.Windows.Forms.Button backToSrcDestTablesTabButton;
        private System.Windows.Forms.Button DoneButton;
    }
}