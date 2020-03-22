namespace ETL.UI
{
    partial class CreateETLJob
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
            this.etlJobTabControl = new System.Windows.Forms.TabControl();
            this.etlJobNameTabPage = new System.Windows.Forms.TabPage();
            this.fromJobNameToEtlsListButton = new System.Windows.Forms.Button();
            this.ETLJobNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.etlsTabPage = new System.Windows.Forms.TabPage();
            this.goBackToNameTabFromETLsTabButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.etlsLabel = new System.Windows.Forms.Label();
            this.etlJobDataGridView = new System.Windows.Forms.DataGridView();
            this.etlJobTabControl.SuspendLayout();
            this.etlJobNameTabPage.SuspendLayout();
            this.etlsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.etlJobDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // etlJobTabControl
            // 
            this.etlJobTabControl.Controls.Add(this.etlJobNameTabPage);
            this.etlJobTabControl.Controls.Add(this.etlsTabPage);
            this.etlJobTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.etlJobTabControl.Location = new System.Drawing.Point(0, 0);
            this.etlJobTabControl.Name = "etlJobTabControl";
            this.etlJobTabControl.SelectedIndex = 0;
            this.etlJobTabControl.Size = new System.Drawing.Size(986, 591);
            this.etlJobTabControl.TabIndex = 0;
            // 
            // etlJobNameTabPage
            // 
            this.etlJobNameTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.etlJobNameTabPage.Controls.Add(this.fromJobNameToEtlsListButton);
            this.etlJobNameTabPage.Controls.Add(this.ETLJobNameTextBox);
            this.etlJobNameTabPage.Controls.Add(this.label1);
            this.etlJobNameTabPage.Location = new System.Drawing.Point(4, 22);
            this.etlJobNameTabPage.Name = "etlJobNameTabPage";
            this.etlJobNameTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.etlJobNameTabPage.Size = new System.Drawing.Size(978, 565);
            this.etlJobNameTabPage.TabIndex = 0;
            this.etlJobNameTabPage.Text = "Name";
            // 
            // fromJobNameToEtlsListButton
            // 
            this.fromJobNameToEtlsListButton.Location = new System.Drawing.Point(821, 490);
            this.fromJobNameToEtlsListButton.Name = "fromJobNameToEtlsListButton";
            this.fromJobNameToEtlsListButton.Size = new System.Drawing.Size(75, 23);
            this.fromJobNameToEtlsListButton.TabIndex = 12;
            this.fromJobNameToEtlsListButton.Text = "Next";
            this.fromJobNameToEtlsListButton.UseVisualStyleBackColor = true;
            this.fromJobNameToEtlsListButton.Click += new System.EventHandler(this.FromJobNameToEtlsListButton_Click);
            // 
            // ETLJobNameTextBox
            // 
            this.ETLJobNameTextBox.Location = new System.Drawing.Point(85, 120);
            this.ETLJobNameTextBox.Name = "ETLJobNameTextBox";
            this.ETLJobNameTextBox.Size = new System.Drawing.Size(198, 20);
            this.ETLJobNameTextBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Choose a name for the ETL Job";
            // 
            // etlsTabPage
            // 
            this.etlsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.etlsTabPage.Controls.Add(this.goBackToNameTabFromETLsTabButton);
            this.etlsTabPage.Controls.Add(this.saveButton);
            this.etlsTabPage.Controls.Add(this.etlsLabel);
            this.etlsTabPage.Controls.Add(this.etlJobDataGridView);
            this.etlsTabPage.Location = new System.Drawing.Point(4, 22);
            this.etlsTabPage.Name = "etlsTabPage";
            this.etlsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.etlsTabPage.Size = new System.Drawing.Size(978, 565);
            this.etlsTabPage.TabIndex = 1;
            this.etlsTabPage.Text = "ETLs";
            // 
            // goBackToNameTabFromETLsTabButton
            // 
            this.goBackToNameTabFromETLsTabButton.Location = new System.Drawing.Point(738, 494);
            this.goBackToNameTabFromETLsTabButton.Name = "goBackToNameTabFromETLsTabButton";
            this.goBackToNameTabFromETLsTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToNameTabFromETLsTabButton.TabIndex = 14;
            this.goBackToNameTabFromETLsTabButton.Text = "Back";
            this.goBackToNameTabFromETLsTabButton.UseVisualStyleBackColor = true;
            this.goBackToNameTabFromETLsTabButton.Click += new System.EventHandler(this.GoBackToNameTabFromETLsTabButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(849, 494);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // etlsLabel
            // 
            this.etlsLabel.AutoSize = true;
            this.etlsLabel.Location = new System.Drawing.Point(49, 33);
            this.etlsLabel.Name = "etlsLabel";
            this.etlsLabel.Size = new System.Drawing.Size(257, 39);
            this.etlsLabel.TabIndex = 2;
            this.etlsLabel.Text = "Choose the ETLs you which to add in this Job.\r\n\r\nThe ETLs will run in the order t" +
    "hat you select them in.";
            // 
            // etlJobDataGridView
            // 
            this.etlJobDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.etlJobDataGridView.Location = new System.Drawing.Point(331, 124);
            this.etlJobDataGridView.Name = "etlJobDataGridView";
            this.etlJobDataGridView.Size = new System.Drawing.Size(315, 289);
            this.etlJobDataGridView.TabIndex = 1;
            this.etlJobDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.EtlJobDataGridView_RowsAdded);
            // 
            // CreateETLJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 591);
            this.Controls.Add(this.etlJobTabControl);
            this.Name = "CreateETLJob";
            this.Text = "CreateETLJob";
            this.etlJobTabControl.ResumeLayout(false);
            this.etlJobNameTabPage.ResumeLayout(false);
            this.etlJobNameTabPage.PerformLayout();
            this.etlsTabPage.ResumeLayout(false);
            this.etlsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.etlJobDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl etlJobTabControl;
        private System.Windows.Forms.TabPage etlJobNameTabPage;
        private System.Windows.Forms.Button fromJobNameToEtlsListButton;
        private System.Windows.Forms.TextBox ETLJobNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage etlsTabPage;
        private System.Windows.Forms.Button goBackToNameTabFromETLsTabButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label etlsLabel;
        private System.Windows.Forms.DataGridView etlJobDataGridView;
    }
}