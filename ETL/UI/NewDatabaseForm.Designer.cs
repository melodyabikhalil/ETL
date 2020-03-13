namespace ETL.UI
{
    partial class NewDatabaseForm
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
            this.newDatabaseTabControl = new System.Windows.Forms.TabControl();
            this.sourceDestinationTabPage = new System.Windows.Forms.TabPage();
            this.typeTabPage = new System.Windows.Forms.TabPage();
            this.SrcDestNex = new System.Windows.Forms.Button();
            this.destRadioButton = new System.Windows.Forms.RadioButton();
            this.srcRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.backToSrcDest = new System.Windows.Forms.Button();
            this.dbTypesComboBox = new System.Windows.Forms.ComboBox();
            this.dbTypeButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.credentialsTabPage = new System.Windows.Forms.TabPage();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.schemaTextBox = new System.Windows.Forms.TextBox();
            this.schemaLabel = new System.Windows.Forms.Label();
            this.dbNameTextBox = new System.Windows.Forms.TextBox();
            this.dbNameLabel = new System.Windows.Forms.Label();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.backToDbTypes = new System.Windows.Forms.Button();
            this.Connect = new System.Windows.Forms.Button();
            this.newDatabaseTabControl.SuspendLayout();
            this.sourceDestinationTabPage.SuspendLayout();
            this.typeTabPage.SuspendLayout();
            this.credentialsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // newDatabaseTabControl
            // 
            this.newDatabaseTabControl.Controls.Add(this.sourceDestinationTabPage);
            this.newDatabaseTabControl.Controls.Add(this.typeTabPage);
            this.newDatabaseTabControl.Controls.Add(this.credentialsTabPage);
            this.newDatabaseTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newDatabaseTabControl.Location = new System.Drawing.Point(0, 0);
            this.newDatabaseTabControl.Name = "newDatabaseTabControl";
            this.newDatabaseTabControl.SelectedIndex = 0;
            this.newDatabaseTabControl.Size = new System.Drawing.Size(500, 315);
            this.newDatabaseTabControl.TabIndex = 0;
            // 
            // sourceDestinationTabPage
            // 
            this.sourceDestinationTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.sourceDestinationTabPage.Controls.Add(this.SrcDestNex);
            this.sourceDestinationTabPage.Controls.Add(this.destRadioButton);
            this.sourceDestinationTabPage.Controls.Add(this.srcRadioButton);
            this.sourceDestinationTabPage.Controls.Add(this.label1);
            this.sourceDestinationTabPage.Location = new System.Drawing.Point(4, 22);
            this.sourceDestinationTabPage.Name = "sourceDestinationTabPage";
            this.sourceDestinationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sourceDestinationTabPage.Size = new System.Drawing.Size(492, 289);
            this.sourceDestinationTabPage.TabIndex = 0;
            this.sourceDestinationTabPage.Text = "Source/Destination";
            // 
            // typeTabPage
            // 
            this.typeTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.typeTabPage.Controls.Add(this.backToSrcDest);
            this.typeTabPage.Controls.Add(this.dbTypesComboBox);
            this.typeTabPage.Controls.Add(this.dbTypeButton);
            this.typeTabPage.Controls.Add(this.label2);
            this.typeTabPage.Location = new System.Drawing.Point(4, 22);
            this.typeTabPage.Name = "typeTabPage";
            this.typeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.typeTabPage.Size = new System.Drawing.Size(492, 289);
            this.typeTabPage.TabIndex = 1;
            this.typeTabPage.Text = "Type";
            // 
            // SrcDestNex
            // 
            this.SrcDestNex.Location = new System.Drawing.Point(346, 221);
            this.SrcDestNex.Name = "SrcDestNex";
            this.SrcDestNex.Size = new System.Drawing.Size(75, 23);
            this.SrcDestNex.TabIndex = 7;
            this.SrcDestNex.Text = "Next";
            this.SrcDestNex.UseVisualStyleBackColor = true;
            this.SrcDestNex.Click += new System.EventHandler(this.SrcDestNex_Click);
            // 
            // destRadioButton
            // 
            this.destRadioButton.AutoSize = true;
            this.destRadioButton.Location = new System.Drawing.Point(63, 122);
            this.destRadioButton.Name = "destRadioButton";
            this.destRadioButton.Size = new System.Drawing.Size(78, 17);
            this.destRadioButton.TabIndex = 6;
            this.destRadioButton.TabStop = true;
            this.destRadioButton.Text = "Destination";
            this.destRadioButton.UseVisualStyleBackColor = true;
            // 
            // srcRadioButton
            // 
            this.srcRadioButton.AutoSize = true;
            this.srcRadioButton.Location = new System.Drawing.Point(63, 91);
            this.srcRadioButton.Name = "srcRadioButton";
            this.srcRadioButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.srcRadioButton.Size = new System.Drawing.Size(59, 17);
            this.srcRadioButton.TabIndex = 5;
            this.srcRadioButton.TabStop = true;
            this.srcRadioButton.Text = "Source";
            this.srcRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Do you want to add a source or a destination database?";
            // 
            // backToSrcDest
            // 
            this.backToSrcDest.Location = new System.Drawing.Point(248, 218);
            this.backToSrcDest.Name = "backToSrcDest";
            this.backToSrcDest.Size = new System.Drawing.Size(75, 23);
            this.backToSrcDest.TabIndex = 7;
            this.backToSrcDest.Text = "Back";
            this.backToSrcDest.UseVisualStyleBackColor = true;
            this.backToSrcDest.Click += new System.EventHandler(this.backToSrcDest_Click);
            // 
            // dbTypesComboBox
            // 
            this.dbTypesComboBox.FormattingEnabled = true;
            this.dbTypesComboBox.Items.AddRange(new object[] {
            "MySQL",
            "SQL Server",
            "PostgreSQL",
            "MS Access",
            "ODBC"});
            this.dbTypesComboBox.Location = new System.Drawing.Point(52, 78);
            this.dbTypesComboBox.Name = "dbTypesComboBox";
            this.dbTypesComboBox.Size = new System.Drawing.Size(168, 21);
            this.dbTypesComboBox.TabIndex = 6;
            // 
            // dbTypeButton
            // 
            this.dbTypeButton.Location = new System.Drawing.Point(342, 218);
            this.dbTypeButton.Name = "dbTypeButton";
            this.dbTypeButton.Size = new System.Drawing.Size(75, 23);
            this.dbTypeButton.TabIndex = 5;
            this.dbTypeButton.Text = "Next";
            this.dbTypeButton.UseVisualStyleBackColor = true;
            this.dbTypeButton.Click += new System.EventHandler(this.dbTypeButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Choose the database type:";
            // 
            // credentialsTabPage
            // 
            this.credentialsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.credentialsTabPage.Controls.Add(this.portTextBox);
            this.credentialsTabPage.Controls.Add(this.portLabel);
            this.credentialsTabPage.Controls.Add(this.schemaTextBox);
            this.credentialsTabPage.Controls.Add(this.schemaLabel);
            this.credentialsTabPage.Controls.Add(this.dbNameTextBox);
            this.credentialsTabPage.Controls.Add(this.dbNameLabel);
            this.credentialsTabPage.Controls.Add(this.passTextBox);
            this.credentialsTabPage.Controls.Add(this.passwordLabel);
            this.credentialsTabPage.Controls.Add(this.usernameTextBox);
            this.credentialsTabPage.Controls.Add(this.usernameLabel);
            this.credentialsTabPage.Controls.Add(this.hostTextBox);
            this.credentialsTabPage.Controls.Add(this.hostLabel);
            this.credentialsTabPage.Controls.Add(this.backToDbTypes);
            this.credentialsTabPage.Controls.Add(this.Connect);
            this.credentialsTabPage.Location = new System.Drawing.Point(4, 22);
            this.credentialsTabPage.Name = "credentialsTabPage";
            this.credentialsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.credentialsTabPage.Size = new System.Drawing.Size(492, 289);
            this.credentialsTabPage.TabIndex = 2;
            this.credentialsTabPage.Text = "Credentials";
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(134, 163);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(224, 20);
            this.portTextBox.TabIndex = 29;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(48, 165);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 28;
            this.portLabel.Text = "Port";
            // 
            // schemaTextBox
            // 
            this.schemaTextBox.Location = new System.Drawing.Point(134, 137);
            this.schemaTextBox.Name = "schemaTextBox";
            this.schemaTextBox.Size = new System.Drawing.Size(224, 20);
            this.schemaTextBox.TabIndex = 27;
            // 
            // schemaLabel
            // 
            this.schemaLabel.AutoSize = true;
            this.schemaLabel.Location = new System.Drawing.Point(46, 140);
            this.schemaLabel.Name = "schemaLabel";
            this.schemaLabel.Size = new System.Drawing.Size(46, 13);
            this.schemaLabel.TabIndex = 26;
            this.schemaLabel.Text = "Schema";
            // 
            // dbNameTextBox
            // 
            this.dbNameTextBox.Location = new System.Drawing.Point(134, 113);
            this.dbNameTextBox.Name = "dbNameTextBox";
            this.dbNameTextBox.Size = new System.Drawing.Size(224, 20);
            this.dbNameTextBox.TabIndex = 25;
            // 
            // dbNameLabel
            // 
            this.dbNameLabel.AutoSize = true;
            this.dbNameLabel.Location = new System.Drawing.Point(46, 115);
            this.dbNameLabel.Name = "dbNameLabel";
            this.dbNameLabel.Size = new System.Drawing.Size(84, 13);
            this.dbNameLabel.TabIndex = 24;
            this.dbNameLabel.Text = "Database Name";
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(134, 88);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(224, 20);
            this.passTextBox.TabIndex = 23;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(46, 91);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 22;
            this.passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(134, 64);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(224, 20);
            this.usernameTextBox.TabIndex = 21;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(46, 66);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 20;
            this.usernameLabel.Text = "Username";
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(134, 40);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(224, 20);
            this.hostTextBox.TabIndex = 19;
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(46, 42);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(29, 13);
            this.hostLabel.TabIndex = 18;
            this.hostLabel.Text = "Host";
            // 
            // backToDbTypes
            // 
            this.backToDbTypes.Location = new System.Drawing.Point(266, 223);
            this.backToDbTypes.Name = "backToDbTypes";
            this.backToDbTypes.Size = new System.Drawing.Size(75, 23);
            this.backToDbTypes.TabIndex = 17;
            this.backToDbTypes.Text = "Back";
            this.backToDbTypes.UseVisualStyleBackColor = true;
            this.backToDbTypes.Click += new System.EventHandler(this.backToDbTypes_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(361, 223);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 16;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // NewDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 315);
            this.Controls.Add(this.newDatabaseTabControl);
            this.Name = "NewDatabaseForm";
            this.Text = "NewDatabaseForm";
            this.newDatabaseTabControl.ResumeLayout(false);
            this.sourceDestinationTabPage.ResumeLayout(false);
            this.sourceDestinationTabPage.PerformLayout();
            this.typeTabPage.ResumeLayout(false);
            this.typeTabPage.PerformLayout();
            this.credentialsTabPage.ResumeLayout(false);
            this.credentialsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl newDatabaseTabControl;
        private System.Windows.Forms.TabPage sourceDestinationTabPage;
        private System.Windows.Forms.Button SrcDestNex;
        private System.Windows.Forms.RadioButton destRadioButton;
        private System.Windows.Forms.RadioButton srcRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage typeTabPage;
        private System.Windows.Forms.Button backToSrcDest;
        private System.Windows.Forms.ComboBox dbTypesComboBox;
        private System.Windows.Forms.Button dbTypeButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage credentialsTabPage;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox schemaTextBox;
        private System.Windows.Forms.Label schemaLabel;
        private System.Windows.Forms.TextBox dbNameTextBox;
        private System.Windows.Forms.Label dbNameLabel;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Button backToDbTypes;
        private System.Windows.Forms.Button Connect;
    }
}