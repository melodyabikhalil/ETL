namespace ETL.UI
{
    partial class MapForm
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
            this.mapDataGridView = new System.Windows.Forms.DataGridView();
            this.finishButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // mapDataGridView
            // 
            this.mapDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.mapDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mapDataGridView.Location = new System.Drawing.Point(24, 44);
            this.mapDataGridView.Name = "mapDataGridView";
            this.mapDataGridView.Size = new System.Drawing.Size(531, 239);
            this.mapDataGridView.TabIndex = 0;
            this.mapDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.mapDataGridView_CellValueChanged);
            // 
            // finishButton
            // 
            this.finishButton.Location = new System.Drawing.Point(480, 321);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(75, 23);
            this.finishButton.TabIndex = 1;
            this.finishButton.Text = "Finish";
            this.finishButton.UseVisualStyleBackColor = true;
            this.finishButton.Click += new System.EventHandler(this.finishButton_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 382);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.mapDataGridView);
            this.Name = "MapForm";
            this.Text = "Mapping table";
            ((System.ComponentModel.ISupportInitialize)(this.mapDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView mapDataGridView;
        private System.Windows.Forms.Button finishButton;
    }
}