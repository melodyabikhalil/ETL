namespace ETL.UI
{
    partial class ViewEditETLForm
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
            this.etlNameLabel = new System.Windows.Forms.Label();
            this.ETLDataGridView = new System.Windows.Forms.DataGridView();
            this.doneButton = new System.Windows.Forms.Button();
            this.sourceDatabaseLabel = new System.Windows.Forms.Label();
            this.sourceTableOrQueryLabel = new System.Windows.Forms.Label();
            this.destinationTableLabel = new System.Windows.Forms.Label();
            this.destinationDatabaseLabel = new System.Windows.Forms.Label();
            this.srcColumnLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ETLDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // etlNameLabel
            // 
            this.etlNameLabel.AutoSize = true;
            this.etlNameLabel.Location = new System.Drawing.Point(35, 36);
            this.etlNameLabel.Name = "etlNameLabel";
            this.etlNameLabel.Size = new System.Drawing.Size(61, 13);
            this.etlNameLabel.TabIndex = 0;
            this.etlNameLabel.Text = "ETL Name: ";
            // 
            // ETLDataGridView
            // 
            this.ETLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ETLDataGridView.Location = new System.Drawing.Point(33, 199);
            this.ETLDataGridView.Name = "ETLDataGridView";
            this.ETLDataGridView.Size = new System.Drawing.Size(911, 217);
            this.ETLDataGridView.TabIndex = 1;
            this.ETLDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ETLDataGridView_DataError);
            this.ETLDataGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ETLDataGridView_EditingControlShowing);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(869, 442);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 2;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // sourceDatabaseLabel
            // 
            this.sourceDatabaseLabel.AutoSize = true;
            this.sourceDatabaseLabel.Location = new System.Drawing.Point(35, 86);
            this.sourceDatabaseLabel.Name = "sourceDatabaseLabel";
            this.sourceDatabaseLabel.Size = new System.Drawing.Size(92, 13);
            this.sourceDatabaseLabel.TabIndex = 3;
            this.sourceDatabaseLabel.Text = "Source database:";
            // 
            // sourceTableOrQueryLabel
            // 
            this.sourceTableOrQueryLabel.AutoSize = true;
            this.sourceTableOrQueryLabel.Location = new System.Drawing.Point(35, 120);
            this.sourceTableOrQueryLabel.Name = "sourceTableOrQueryLabel";
            this.sourceTableOrQueryLabel.Size = new System.Drawing.Size(115, 13);
            this.sourceTableOrQueryLabel.TabIndex = 4;
            this.sourceTableOrQueryLabel.Text = "Source table or query:";
            // 
            // destinationTableLabel
            // 
            this.destinationTableLabel.AutoSize = true;
            this.destinationTableLabel.Location = new System.Drawing.Point(359, 120);
            this.destinationTableLabel.Name = "destinationTableLabel";
            this.destinationTableLabel.Size = new System.Drawing.Size(92, 13);
            this.destinationTableLabel.TabIndex = 6;
            this.destinationTableLabel.Text = "Destination table:";
            // 
            // destinationDatabaseLabel
            // 
            this.destinationDatabaseLabel.AutoSize = true;
            this.destinationDatabaseLabel.Location = new System.Drawing.Point(359, 86);
            this.destinationDatabaseLabel.Name = "destinationDatabaseLabel";
            this.destinationDatabaseLabel.Size = new System.Drawing.Size(113, 13);
            this.destinationDatabaseLabel.TabIndex = 5;
            this.destinationDatabaseLabel.Text = "Destination database:";
            // 
            // srcColumnLabel
            // 
            this.srcColumnLabel.AutoSize = true;
            this.srcColumnLabel.Location = new System.Drawing.Point(38, 157);
            this.srcColumnLabel.Name = "srcColumnLabel";
            this.srcColumnLabel.Size = new System.Drawing.Size(0, 13);
            this.srcColumnLabel.TabIndex = 7;
            // 
            // ViewEditETLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 498);
            this.Controls.Add(this.srcColumnLabel);
            this.Controls.Add(this.destinationTableLabel);
            this.Controls.Add(this.destinationDatabaseLabel);
            this.Controls.Add(this.sourceTableOrQueryLabel);
            this.Controls.Add(this.sourceDatabaseLabel);
            this.Controls.Add(this.doneButton);
            this.Controls.Add(this.ETLDataGridView);
            this.Controls.Add(this.etlNameLabel);
            this.Name = "ViewEditETLForm";
            this.Text = "View/Edit ETL";
            ((System.ComponentModel.ISupportInitialize)(this.ETLDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label etlNameLabel;
        private System.Windows.Forms.DataGridView ETLDataGridView;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.Label sourceDatabaseLabel;
        private System.Windows.Forms.Label sourceTableOrQueryLabel;
        private System.Windows.Forms.Label destinationTableLabel;
        private System.Windows.Forms.Label destinationDatabaseLabel;
        private System.Windows.Forms.Label srcColumnLabel;
    }
}