namespace ETL.UI
{
    partial class ProgressForm
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
            IsDead = true;
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.etlLabel = new System.Windows.Forms.Label();
            this.actionLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(21, 86);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(452, 30);
            this.progressBar.TabIndex = 0;
            // 
            // etlLabel
            // 
            this.etlLabel.AutoSize = true;
            this.etlLabel.Location = new System.Drawing.Point(18, 13);
            this.etlLabel.Name = "etlLabel";
            this.etlLabel.Size = new System.Drawing.Size(35, 13);
            this.etlLabel.TabIndex = 1;
            this.etlLabel.Text = "label1";
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(18, 57);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(35, 13);
            this.actionLabel.TabIndex = 2;
            this.actionLabel.Text = "label1";
            // 
            // progressLabel
            // 
            this.progressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.progressLabel.Location = new System.Drawing.Point(367, 57);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.progressLabel.Size = new System.Drawing.Size(109, 13);
            this.progressLabel.TabIndex = 3;
            this.progressLabel.Text = "label1";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 142);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.etlLabel);
            this.Controls.Add(this.progressBar);
            this.Name = "ProgressForm";
            this.Text = "Running ETL job";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label etlLabel;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label progressLabel;
    }
}