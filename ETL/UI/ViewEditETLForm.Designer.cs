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
            ((System.ComponentModel.ISupportInitialize)(this.ETLDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // etlNameLabel
            // 
            this.etlNameLabel.AutoSize = true;
            this.etlNameLabel.Location = new System.Drawing.Point(48, 41);
            this.etlNameLabel.Name = "etlNameLabel";
            this.etlNameLabel.Size = new System.Drawing.Size(61, 13);
            this.etlNameLabel.TabIndex = 0;
            this.etlNameLabel.Text = "ETL Name: ";
            // 
            // ETLDataGridView
            // 
            this.ETLDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ETLDataGridView.Location = new System.Drawing.Point(51, 112);
            this.ETLDataGridView.Name = "ETLDataGridView";
            this.ETLDataGridView.Size = new System.Drawing.Size(712, 217);
            this.ETLDataGridView.TabIndex = 1;
            this.ETLDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.ETLDataGridView_DataError);
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(688, 406);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(75, 23);
            this.doneButton.TabIndex = 2;
            this.doneButton.Text = "Done";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // ViewEditETLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}