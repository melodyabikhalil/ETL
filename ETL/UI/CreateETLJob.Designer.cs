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
            this.nameGroupbox = new System.Windows.Forms.GroupBox();
            this.ETLJobNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.etlsLabel = new System.Windows.Forms.Label();
            this.etlJobDataGridView = new System.Windows.Forms.DataGridView();
            this.datagridviewGroupBox = new System.Windows.Forms.GroupBox();
            this.nameGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.etlJobDataGridView)).BeginInit();
            this.datagridviewGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameGroupbox
            // 
            this.nameGroupbox.Controls.Add(this.ETLJobNameTextBox);
            this.nameGroupbox.Controls.Add(this.label1);
            this.nameGroupbox.Location = new System.Drawing.Point(21, 33);
            this.nameGroupbox.Name = "nameGroupbox";
            this.nameGroupbox.Size = new System.Drawing.Size(953, 96);
            this.nameGroupbox.TabIndex = 0;
            this.nameGroupbox.TabStop = false;
            this.nameGroupbox.Text = "Name";
            // 
            // ETLJobNameTextBox
            // 
            this.ETLJobNameTextBox.Location = new System.Drawing.Point(313, 45);
            this.ETLJobNameTextBox.Name = "ETLJobNameTextBox";
            this.ETLJobNameTextBox.Size = new System.Drawing.Size(315, 20);
            this.ETLJobNameTextBox.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Choose a name for the ETL Job";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(899, 556);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // etlsLabel
            // 
            this.etlsLabel.AutoSize = true;
            this.etlsLabel.Location = new System.Drawing.Point(33, 46);
            this.etlsLabel.Name = "etlsLabel";
            this.etlsLabel.Size = new System.Drawing.Size(257, 39);
            this.etlsLabel.TabIndex = 18;
            this.etlsLabel.Text = "Choose the ETLs you which to add in this Job.\r\n\r\nThe ETLs will run in the order t" +
    "hat you select them in.";
            // 
            // etlJobDataGridView
            // 
            this.etlJobDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.etlJobDataGridView.Location = new System.Drawing.Point(313, 73);
            this.etlJobDataGridView.Name = "etlJobDataGridView";
            this.etlJobDataGridView.Size = new System.Drawing.Size(315, 289);
            this.etlJobDataGridView.TabIndex = 17;
            this.etlJobDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.EtlJobDataGridView_RowsAdded);
            // 
            // datagridviewGroupBox
            // 
            this.datagridviewGroupBox.Controls.Add(this.etlJobDataGridView);
            this.datagridviewGroupBox.Controls.Add(this.etlsLabel);
            this.datagridviewGroupBox.Location = new System.Drawing.Point(21, 153);
            this.datagridviewGroupBox.Name = "datagridviewGroupBox";
            this.datagridviewGroupBox.Size = new System.Drawing.Size(953, 386);
            this.datagridviewGroupBox.TabIndex = 21;
            this.datagridviewGroupBox.TabStop = false;
            this.datagridviewGroupBox.Text = "ETLs order";
            // 
            // CreateETLJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 591);
            this.Controls.Add(this.datagridviewGroupBox);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.nameGroupbox);
            this.Name = "CreateETLJob";
            this.Text = "Create ETL job";
            this.nameGroupbox.ResumeLayout(false);
            this.nameGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.etlJobDataGridView)).EndInit();
            this.datagridviewGroupBox.ResumeLayout(false);
            this.datagridviewGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox nameGroupbox;
        private System.Windows.Forms.TextBox ETLJobNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label etlsLabel;
        private System.Windows.Forms.DataGridView etlJobDataGridView;
        private System.Windows.Forms.GroupBox datagridviewGroupBox;
    }
}