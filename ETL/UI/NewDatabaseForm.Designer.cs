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
            this.credentialsTabPage = new System.Windows.Forms.TabPage();
            this.rememberDatabaseCheckbox = new System.Windows.Forms.CheckBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.schemaTextBox = new System.Windows.Forms.TextBox();
            this.dbNameTextBox = new System.Windows.Forms.TextBox();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.hostTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.schemaLabel = new System.Windows.Forms.Label();
            this.dbNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.hostLabel = new System.Windows.Forms.Label();
            this.goBackToTypeTabFromCredentialsTabButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.typeTabPage = new System.Windows.Forms.TabPage();
            this.dbTypesComboBox = new System.Windows.Forms.ComboBox();
            this.goToCredentialsTabFromTypeTabButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.newDatabaseTabControl = new System.Windows.Forms.TabControl();
            this.credentialsTabPage.SuspendLayout();
            this.typeTabPage.SuspendLayout();
            this.newDatabaseTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // credentialsTabPage
            // 
            this.credentialsTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.credentialsTabPage.Controls.Add(this.rememberDatabaseCheckbox);
            this.credentialsTabPage.Controls.Add(this.portTextBox);
            this.credentialsTabPage.Controls.Add(this.schemaTextBox);
            this.credentialsTabPage.Controls.Add(this.dbNameTextBox);
            this.credentialsTabPage.Controls.Add(this.passTextBox);
            this.credentialsTabPage.Controls.Add(this.usernameTextBox);
            this.credentialsTabPage.Controls.Add(this.hostTextBox);
            this.credentialsTabPage.Controls.Add(this.portLabel);
            this.credentialsTabPage.Controls.Add(this.schemaLabel);
            this.credentialsTabPage.Controls.Add(this.dbNameLabel);
            this.credentialsTabPage.Controls.Add(this.passwordLabel);
            this.credentialsTabPage.Controls.Add(this.usernameLabel);
            this.credentialsTabPage.Controls.Add(this.hostLabel);
            this.credentialsTabPage.Controls.Add(this.goBackToTypeTabFromCredentialsTabButton);
            this.credentialsTabPage.Controls.Add(this.connectButton);
            this.credentialsTabPage.Location = new System.Drawing.Point(4, 22);
            this.credentialsTabPage.Name = "credentialsTabPage";
            this.credentialsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.credentialsTabPage.Size = new System.Drawing.Size(492, 289);
            this.credentialsTabPage.TabIndex = 2;
            this.credentialsTabPage.Text = "Credentials";
            // 
            // rememberDatabaseCheckbox
            // 
            this.rememberDatabaseCheckbox.AutoSize = true;
            this.rememberDatabaseCheckbox.Location = new System.Drawing.Point(134, 188);
            this.rememberDatabaseCheckbox.Name = "rememberDatabaseCheckbox";
            this.rememberDatabaseCheckbox.Size = new System.Drawing.Size(124, 17);
            this.rememberDatabaseCheckbox.TabIndex = 30;
            this.rememberDatabaseCheckbox.Text = "Remember database";
            this.rememberDatabaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // portTextBox
            // 
            this.portTextBox.Location = new System.Drawing.Point(134, 162);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(224, 20);
            this.portTextBox.TabIndex = 29;
            // 
            // schemaTextBox
            // 
            this.schemaTextBox.Location = new System.Drawing.Point(134, 136);
            this.schemaTextBox.Name = "schemaTextBox";
            this.schemaTextBox.Size = new System.Drawing.Size(224, 20);
            this.schemaTextBox.TabIndex = 27;
            // 
            // dbNameTextBox
            // 
            this.dbNameTextBox.Location = new System.Drawing.Point(134, 112);
            this.dbNameTextBox.Name = "dbNameTextBox";
            this.dbNameTextBox.Size = new System.Drawing.Size(224, 20);
            this.dbNameTextBox.TabIndex = 25;
            // 
            // passTextBox
            // 
            this.passTextBox.Location = new System.Drawing.Point(134, 87);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.PasswordChar = '*';
            this.passTextBox.Size = new System.Drawing.Size(224, 20);
            this.passTextBox.TabIndex = 23;
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(134, 63);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(224, 20);
            this.usernameTextBox.TabIndex = 21;
            // 
            // hostTextBox
            // 
            this.hostTextBox.Location = new System.Drawing.Point(134, 39);
            this.hostTextBox.Name = "hostTextBox";
            this.hostTextBox.Size = new System.Drawing.Size(224, 20);
            this.hostTextBox.TabIndex = 19;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(48, 164);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(26, 13);
            this.portLabel.TabIndex = 28;
            this.portLabel.Text = "Port";
            // 
            // schemaLabel
            // 
            this.schemaLabel.AutoSize = true;
            this.schemaLabel.Location = new System.Drawing.Point(46, 139);
            this.schemaLabel.Name = "schemaLabel";
            this.schemaLabel.Size = new System.Drawing.Size(46, 13);
            this.schemaLabel.TabIndex = 26;
            this.schemaLabel.Text = "Schema";
            // 
            // dbNameLabel
            // 
            this.dbNameLabel.AutoSize = true;
            this.dbNameLabel.Location = new System.Drawing.Point(46, 114);
            this.dbNameLabel.Name = "dbNameLabel";
            this.dbNameLabel.Size = new System.Drawing.Size(84, 13);
            this.dbNameLabel.TabIndex = 24;
            this.dbNameLabel.Text = "Database Name";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(46, 90);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 22;
            this.passwordLabel.Text = "Password";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(46, 65);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(55, 13);
            this.usernameLabel.TabIndex = 20;
            this.usernameLabel.Text = "Username";
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(46, 41);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(29, 13);
            this.hostLabel.TabIndex = 18;
            this.hostLabel.Text = "Host";
            // 
            // goBackToTypeTabFromCredentialsTabButton
            // 
            this.goBackToTypeTabFromCredentialsTabButton.Location = new System.Drawing.Point(266, 223);
            this.goBackToTypeTabFromCredentialsTabButton.Name = "goBackToTypeTabFromCredentialsTabButton";
            this.goBackToTypeTabFromCredentialsTabButton.Size = new System.Drawing.Size(75, 23);
            this.goBackToTypeTabFromCredentialsTabButton.TabIndex = 17;
            this.goBackToTypeTabFromCredentialsTabButton.Text = "Back";
            this.goBackToTypeTabFromCredentialsTabButton.UseVisualStyleBackColor = true;
            this.goBackToTypeTabFromCredentialsTabButton.Click += new System.EventHandler(this.GoBackToTypeTabFromCredentialsTabButton_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(361, 223);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 16;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // typeTabPage
            // 
            this.typeTabPage.BackColor = System.Drawing.SystemColors.Control;
            this.typeTabPage.Controls.Add(this.dbTypesComboBox);
            this.typeTabPage.Controls.Add(this.goToCredentialsTabFromTypeTabButton);
            this.typeTabPage.Controls.Add(this.label2);
            this.typeTabPage.Location = new System.Drawing.Point(4, 22);
            this.typeTabPage.Name = "typeTabPage";
            this.typeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.typeTabPage.Size = new System.Drawing.Size(492, 289);
            this.typeTabPage.TabIndex = 1;
            this.typeTabPage.Text = "Type";
            // 
            // dbTypesComboBox
            // 
            this.dbTypesComboBox.FormattingEnabled = true;
            this.dbTypesComboBox.Location = new System.Drawing.Point(52, 78);
            this.dbTypesComboBox.Name = "dbTypesComboBox";
            this.dbTypesComboBox.Size = new System.Drawing.Size(168, 21);
            this.dbTypesComboBox.TabIndex = 6;
            // 
            // goToCredentialsTabFromTypeTabButton
            // 
            this.goToCredentialsTabFromTypeTabButton.Location = new System.Drawing.Point(342, 218);
            this.goToCredentialsTabFromTypeTabButton.Name = "goToCredentialsTabFromTypeTabButton";
            this.goToCredentialsTabFromTypeTabButton.Size = new System.Drawing.Size(75, 23);
            this.goToCredentialsTabFromTypeTabButton.TabIndex = 5;
            this.goToCredentialsTabFromTypeTabButton.Text = "Next";
            this.goToCredentialsTabFromTypeTabButton.UseVisualStyleBackColor = true;
            this.goToCredentialsTabFromTypeTabButton.Click += new System.EventHandler(this.GoToCredentialsTabFromTypeTabButton_Click);
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
            // newDatabaseTabControl
            // 
            this.newDatabaseTabControl.Controls.Add(this.typeTabPage);
            this.newDatabaseTabControl.Controls.Add(this.credentialsTabPage);
            this.newDatabaseTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newDatabaseTabControl.Location = new System.Drawing.Point(0, 0);
            this.newDatabaseTabControl.Name = "newDatabaseTabControl";
            this.newDatabaseTabControl.SelectedIndex = 0;
            this.newDatabaseTabControl.Size = new System.Drawing.Size(500, 315);
            this.newDatabaseTabControl.TabIndex = 0;
            // 
            // NewDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 315);
            this.Controls.Add(this.newDatabaseTabControl);
            this.Name = "NewDatabaseForm";
            this.Text = "NewDatabaseForm";
            this.credentialsTabPage.ResumeLayout(false);
            this.credentialsTabPage.PerformLayout();
            this.typeTabPage.ResumeLayout(false);
            this.typeTabPage.PerformLayout();
            this.newDatabaseTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage credentialsTabPage;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox schemaTextBox;
        private System.Windows.Forms.TextBox dbNameTextBox;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox hostTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label schemaLabel;
        private System.Windows.Forms.Label dbNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Button goBackToTypeTabFromCredentialsTabButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TabPage typeTabPage;
        private System.Windows.Forms.ComboBox dbTypesComboBox;
        private System.Windows.Forms.Button goToCredentialsTabFromTypeTabButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl newDatabaseTabControl;
        private System.Windows.Forms.CheckBox rememberDatabaseCheckbox;
    }
}