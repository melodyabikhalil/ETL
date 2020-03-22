namespace ETL.UI
{
    partial class ViewQueryForm
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
            this.queryNameLabel = new System.Windows.Forms.Label();
            this.queryLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // queryNameLabel
            // 
            this.queryNameLabel.AutoSize = true;
            this.queryNameLabel.Location = new System.Drawing.Point(33, 44);
            this.queryNameLabel.Name = "queryNameLabel";
            this.queryNameLabel.Size = new System.Drawing.Size(72, 13);
            this.queryNameLabel.TabIndex = 0;
            this.queryNameLabel.Text = "Query Name: ";
            // 
            // queryLabel
            // 
            this.queryLabel.AutoSize = true;
            this.queryLabel.Location = new System.Drawing.Point(33, 94);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.Size = new System.Drawing.Size(41, 13);
            this.queryLabel.TabIndex = 2;
            this.queryLabel.Text = "Query: ";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(346, 254);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "OK";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ViewQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 299);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.queryLabel);
            this.Controls.Add(this.queryNameLabel);
            this.Name = "ViewQueryForm";
            this.Text = "View Query";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label queryNameLabel;
        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.Button closeButton;
    }
}