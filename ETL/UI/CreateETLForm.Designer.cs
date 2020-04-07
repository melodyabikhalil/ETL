namespace ETL.UI
{
    partial class CreateETLForm
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
            this.ExpressionTab = new System.Windows.Forms.TabPage();
            this.helpButton = new System.Windows.Forms.Button();
            this.srcColumnLabel = new System.Windows.Forms.Label();
            this.backToSrcDestTablesTabButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ExpressionDataGridView = new System.Windows.Forms.DataGridView();
            this.ETLNameTab = new System.Windows.Forms.TabPage();
            this.destinationGroupBox = new System.Windows.Forms.GroupBox();
            this.destTableComboBox = new System.Windows.Forms.ComboBox();
            this.srcTableOrQueriesComboBox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.sourceGroupBox = new System.Windows.Forms.GroupBox();
            this.destinationDbComboBox = new System.Windows.Forms.ComboBox();
            this.sourceDbComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ETLNameTextBox = new System.Windows.Forms.TextBox();
            this.fromEtlDetailsToExpressionTabButton = new System.Windows.Forms.Button();
            this.ETLTabControl = new System.Windows.Forms.TabControl();
            this.dspaceCheckBox = new System.Windows.Forms.CheckBox();
            this.dspacePathTextBox = new System.Windows.Forms.TextBox();
            this.dspacePathLabel = new System.Windows.Forms.Label();
            this.ExpressionTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpressionDataGridView)).BeginInit();
            this.ETLNameTab.SuspendLayout();
            this.destinationGroupBox.SuspendLayout();
            this.sourceGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ETLTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExpressionTab
            // 
            this.ExpressionTab.BackColor = System.Drawing.SystemColors.Control;
            this.ExpressionTab.Controls.Add(this.helpButton);
            this.ExpressionTab.Controls.Add(this.srcColumnLabel);
            this.ExpressionTab.Controls.Add(this.backToSrcDestTablesTabButton);
            this.ExpressionTab.Controls.Add(this.SaveButton);
            this.ExpressionTab.Controls.Add(this.ExpressionDataGridView);
            this.ExpressionTab.Location = new System.Drawing.Point(4, 22);
            this.ExpressionTab.Name = "ExpressionTab";
            this.ExpressionTab.Padding = new System.Windows.Forms.Padding(3);
            this.ExpressionTab.Size = new System.Drawing.Size(1011, 578);
            this.ExpressionTab.TabIndex = 3;
            this.ExpressionTab.Text = "Mapping Expressions";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(948, 12);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(21, 20);
            this.helpButton.TabIndex = 17;
            this.helpButton.Text = "?";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // srcColumnLabel
            // 
            this.srcColumnLabel.AutoSize = true;
            this.srcColumnLabel.Location = new System.Drawing.Point(17, 16);
            this.srcColumnLabel.Name = "srcColumnLabel";
            this.srcColumnLabel.Size = new System.Drawing.Size(112, 13);
            this.srcColumnLabel.TabIndex = 16;
            this.srcColumnLabel.Text = "Source table columns:";
            // 
            // backToSrcDestTablesTabButton
            // 
            this.backToSrcDestTablesTabButton.Location = new System.Drawing.Point(789, 521);
            this.backToSrcDestTablesTabButton.Name = "backToSrcDestTablesTabButton";
            this.backToSrcDestTablesTabButton.Size = new System.Drawing.Size(75, 23);
            this.backToSrcDestTablesTabButton.TabIndex = 14;
            this.backToSrcDestTablesTabButton.Text = "Back";
            this.backToSrcDestTablesTabButton.UseVisualStyleBackColor = true;
            this.backToSrcDestTablesTabButton.Click += new System.EventHandler(this.backToSrcDestTablesTabButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(894, 521);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ExpressionDataGridView
            // 
            this.ExpressionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExpressionDataGridView.Location = new System.Drawing.Point(20, 48);
            this.ExpressionDataGridView.Name = "ExpressionDataGridView";
            this.ExpressionDataGridView.Size = new System.Drawing.Size(949, 452);
            this.ExpressionDataGridView.TabIndex = 0;
            this.ExpressionDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.ExpressionDataGridView_CellEndEdit);
            this.ExpressionDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ExpressionDataGridView_EditingControlShowing);
            this.ExpressionDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.ExpressionDataGridView_RowsAdded);
            // 
            // ETLNameTab
            // 
            this.ETLNameTab.BackColor = System.Drawing.SystemColors.Control;
            this.ETLNameTab.Controls.Add(this.destinationGroupBox);
            this.ETLNameTab.Controls.Add(this.sourceGroupBox);
            this.ETLNameTab.Controls.Add(this.groupBox1);
            this.ETLNameTab.Controls.Add(this.fromEtlDetailsToExpressionTabButton);
            this.ETLNameTab.Location = new System.Drawing.Point(4, 22);
            this.ETLNameTab.Name = "ETLNameTab";
            this.ETLNameTab.Padding = new System.Windows.Forms.Padding(3);
            this.ETLNameTab.Size = new System.Drawing.Size(1011, 578);
            this.ETLNameTab.TabIndex = 0;
            this.ETLNameTab.Text = "ETL Name";
            // 
            // destinationGroupBox
            // 
            this.destinationGroupBox.Controls.Add(this.dspacePathLabel);
            this.destinationGroupBox.Controls.Add(this.dspacePathTextBox);
            this.destinationGroupBox.Controls.Add(this.dspaceCheckBox);
            this.destinationGroupBox.Controls.Add(this.destinationDbComboBox);
            this.destinationGroupBox.Controls.Add(this.destTableComboBox);
            this.destinationGroupBox.Controls.Add(this.label9);
            this.destinationGroupBox.Controls.Add(this.label12);
            this.destinationGroupBox.Controls.Add(this.label14);
            this.destinationGroupBox.Location = new System.Drawing.Point(529, 176);
            this.destinationGroupBox.Name = "destinationGroupBox";
            this.destinationGroupBox.Size = new System.Drawing.Size(429, 311);
            this.destinationGroupBox.TabIndex = 11;
            this.destinationGroupBox.TabStop = false;
            this.destinationGroupBox.Text = "Destination";
            // 
            // destTableComboBox
            // 
            this.destTableComboBox.FormattingEnabled = true;
            this.destTableComboBox.Location = new System.Drawing.Point(167, 175);
            this.destTableComboBox.Name = "destTableComboBox";
            this.destTableComboBox.Size = new System.Drawing.Size(217, 21);
            this.destTableComboBox.TabIndex = 13;
            // 
            // srcTableOrQueriesComboBox
            // 
            this.srcTableOrQueriesComboBox.FormattingEnabled = true;
            this.srcTableOrQueriesComboBox.Location = new System.Drawing.Point(174, 175);
            this.srcTableOrQueriesComboBox.Name = "srcTableOrQueriesComboBox";
            this.srcTableOrQueriesComboBox.Size = new System.Drawing.Size(201, 21);
            this.srcTableOrQueriesComboBox.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(68, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Destination table";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 178);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Source table or query";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 51);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(179, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Choose destination database && table";
            // 
            // sourceGroupBox
            // 
            this.sourceGroupBox.Controls.Add(this.sourceDbComboBox);
            this.sourceGroupBox.Controls.Add(this.label13);
            this.sourceGroupBox.Controls.Add(this.srcTableOrQueriesComboBox);
            this.sourceGroupBox.Controls.Add(this.label10);
            this.sourceGroupBox.Controls.Add(this.label11);
            this.sourceGroupBox.Location = new System.Drawing.Point(48, 176);
            this.sourceGroupBox.Name = "sourceGroupBox";
            this.sourceGroupBox.Size = new System.Drawing.Size(429, 311);
            this.sourceGroupBox.TabIndex = 10;
            this.sourceGroupBox.TabStop = false;
            this.sourceGroupBox.Text = "Source";
            // 
            // destinationDbComboBox
            // 
            this.destinationDbComboBox.FormattingEnabled = true;
            this.destinationDbComboBox.Location = new System.Drawing.Point(167, 108);
            this.destinationDbComboBox.Name = "destinationDbComboBox";
            this.destinationDbComboBox.Size = new System.Drawing.Size(217, 21);
            this.destinationDbComboBox.TabIndex = 9;
            this.destinationDbComboBox.SelectedIndexChanged += new System.EventHandler(this.destinationDbComboBox_SelectedIndexChanged);
            // 
            // sourceDbComboBox
            // 
            this.sourceDbComboBox.FormattingEnabled = true;
            this.sourceDbComboBox.Location = new System.Drawing.Point(174, 107);
            this.sourceDbComboBox.Name = "sourceDbComboBox";
            this.sourceDbComboBox.Size = new System.Drawing.Size(201, 21);
            this.sourceDbComboBox.TabIndex = 8;
            this.sourceDbComboBox.SelectedIndexChanged += new System.EventHandler(this.sourceDbComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Destination database";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(62, 110);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Source database";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 41);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Choose source database && table or query";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ETLNameTextBox);
            this.groupBox1.Location = new System.Drawing.Point(48, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 97);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ETL Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose a name for the ETL";
            // 
            // ETLNameTextBox
            // 
            this.ETLNameTextBox.Location = new System.Drawing.Point(208, 36);
            this.ETLNameTextBox.Name = "ETLNameTextBox";
            this.ETLNameTextBox.Size = new System.Drawing.Size(198, 20);
            this.ETLNameTextBox.TabIndex = 1;
            // 
            // fromEtlDetailsToExpressionTabButton
            // 
            this.fromEtlDetailsToExpressionTabButton.Location = new System.Drawing.Point(883, 515);
            this.fromEtlDetailsToExpressionTabButton.Name = "fromEtlDetailsToExpressionTabButton";
            this.fromEtlDetailsToExpressionTabButton.Size = new System.Drawing.Size(75, 23);
            this.fromEtlDetailsToExpressionTabButton.TabIndex = 8;
            this.fromEtlDetailsToExpressionTabButton.Text = "Next";
            this.fromEtlDetailsToExpressionTabButton.UseVisualStyleBackColor = true;
            this.fromEtlDetailsToExpressionTabButton.Click += new System.EventHandler(this.FromETLNameToSrcDrstDbButton_Click);
            // 
            // ETLTabControl
            // 
            this.ETLTabControl.Controls.Add(this.ETLNameTab);
            this.ETLTabControl.Controls.Add(this.ExpressionTab);
            this.ETLTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ETLTabControl.Location = new System.Drawing.Point(0, 0);
            this.ETLTabControl.Name = "ETLTabControl";
            this.ETLTabControl.SelectedIndex = 0;
            this.ETLTabControl.Size = new System.Drawing.Size(1019, 604);
            this.ETLTabControl.TabIndex = 0;
            // 
            // dspaceCheckBox
            // 
            this.dspaceCheckBox.AutoSize = true;
            this.dspaceCheckBox.Location = new System.Drawing.Point(167, 233);
            this.dspaceCheckBox.Name = "dspaceCheckBox";
            this.dspaceCheckBox.Size = new System.Drawing.Size(119, 17);
            this.dspaceCheckBox.TabIndex = 14;
            this.dspaceCheckBox.Text = "DSpace destination";
            this.dspaceCheckBox.UseVisualStyleBackColor = true;
            this.dspaceCheckBox.CheckedChanged += new System.EventHandler(this.DspaceCheckBox_CheckedChanged);
            // 
            // dspacePathTextBox
            // 
            this.dspacePathTextBox.Location = new System.Drawing.Point(167, 269);
            this.dspacePathTextBox.Name = "dspacePathTextBox";
            this.dspacePathTextBox.Size = new System.Drawing.Size(217, 20);
            this.dspacePathTextBox.TabIndex = 15;
            // 
            // dspacePathLabel
            // 
            this.dspacePathLabel.AutoSize = true;
            this.dspacePathLabel.Location = new System.Drawing.Point(84, 272);
            this.dspacePathLabel.Name = "dspacePathLabel";
            this.dspacePathLabel.Size = new System.Drawing.Size(70, 13);
            this.dspacePathLabel.TabIndex = 16;
            this.dspacePathLabel.Text = "DSpace path";
            // 
            // NewETLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 604);
            this.Controls.Add(this.ETLTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewETLForm";
            this.Text = "Create ETL";
            this.ExpressionTab.ResumeLayout(false);
            this.ExpressionTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExpressionDataGridView)).EndInit();
            this.ETLNameTab.ResumeLayout(false);
            this.destinationGroupBox.ResumeLayout(false);
            this.destinationGroupBox.PerformLayout();
            this.sourceGroupBox.ResumeLayout(false);
            this.sourceGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ETLTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage ExpressionTab;
        private System.Windows.Forms.Label srcColumnLabel;
        private System.Windows.Forms.Button backToSrcDestTablesTabButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridView ExpressionDataGridView;
        private System.Windows.Forms.TabPage ETLNameTab;
        private System.Windows.Forms.GroupBox destinationGroupBox;
        private System.Windows.Forms.ComboBox destTableComboBox;
        private System.Windows.Forms.ComboBox srcTableOrQueriesComboBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox sourceGroupBox;
        private System.Windows.Forms.ComboBox destinationDbComboBox;
        private System.Windows.Forms.ComboBox sourceDbComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ETLNameTextBox;
        private System.Windows.Forms.Button fromEtlDetailsToExpressionTabButton;
        private System.Windows.Forms.TabControl ETLTabControl;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Label dspacePathLabel;
        private System.Windows.Forms.TextBox dspacePathTextBox;
        private System.Windows.Forms.CheckBox dspaceCheckBox;
    }
}