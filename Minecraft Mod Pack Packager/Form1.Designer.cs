namespace Minecraft_Mod_Pack_Packager
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtModPackPath = new System.Windows.Forms.TextBox();
            this.btnModPackPath = new System.Windows.Forms.Button();
            this.lblModPackPath = new System.Windows.Forms.Label();
            this.btnCreateFiles = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.tabControlMods = new System.Windows.Forms.TabControl();
            this.tabModsClient = new System.Windows.Forms.TabPage();
            this.listModsClient = new System.Windows.Forms.CheckedListBox();
            this.tabModsServer = new System.Windows.Forms.TabPage();
            this.listModsServer = new System.Windows.Forms.CheckedListBox();
            this.lblModsHeader = new System.Windows.Forms.Label();
            this.lblServerFiles = new System.Windows.Forms.Label();
            this.btnModPackExtraFiles = new System.Windows.Forms.Button();
            this.txtModPackExtraFiles = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.progressBarSub = new System.Windows.Forms.ProgressBar();
            this.lblModPackName = new System.Windows.Forms.Label();
            this.lblModPackVersion = new System.Windows.Forms.Label();
            this.txtModPackName = new System.Windows.Forms.TextBox();
            this.txtModPackVersion = new System.Windows.Forms.TextBox();
            this.checkBoxClient = new System.Windows.Forms.CheckBox();
            this.checkBoxServer = new System.Windows.Forms.CheckBox();
            this.lblFolderHeader = new System.Windows.Forms.Label();
            this.tabControlFolders = new System.Windows.Forms.TabControl();
            this.tabFolderClient = new System.Windows.Forms.TabPage();
            this.listFoldersClient = new System.Windows.Forms.CheckedListBox();
            this.tabFolderServer = new System.Windows.Forms.TabPage();
            this.listFoldersServer = new System.Windows.Forms.CheckedListBox();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.comboTemplates = new System.Windows.Forms.ComboBox();
            this.lblLoadTemplate = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControlMods.SuspendLayout();
            this.tabModsClient.SuspendLayout();
            this.tabModsServer.SuspendLayout();
            this.tabControlFolders.SuspendLayout();
            this.tabFolderClient.SuspendLayout();
            this.tabFolderServer.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModPackPath
            // 
            this.txtModPackPath.Location = new System.Drawing.Point(90, 63);
            this.txtModPackPath.Name = "txtModPackPath";
            this.txtModPackPath.ReadOnly = true;
            this.txtModPackPath.Size = new System.Drawing.Size(337, 20);
            this.txtModPackPath.TabIndex = 0;
            // 
            // btnModPackPath
            // 
            this.btnModPackPath.Location = new System.Drawing.Point(433, 61);
            this.btnModPackPath.Name = "btnModPackPath";
            this.btnModPackPath.Size = new System.Drawing.Size(27, 19);
            this.btnModPackPath.TabIndex = 1;
            this.btnModPackPath.Text = "...";
            this.btnModPackPath.UseVisualStyleBackColor = true;
            this.btnModPackPath.Click += new System.EventHandler(this.btnModPackPath_Click);
            // 
            // lblModPackPath
            // 
            this.lblModPackPath.AutoSize = true;
            this.lblModPackPath.Location = new System.Drawing.Point(3, 67);
            this.lblModPackPath.Name = "lblModPackPath";
            this.lblModPackPath.Size = new System.Drawing.Size(81, 13);
            this.lblModPackPath.TabIndex = 2;
            this.lblModPackPath.Text = "Mod Pack Path";
            // 
            // btnCreateFiles
            // 
            this.btnCreateFiles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCreateFiles.Location = new System.Drawing.Point(0, 486);
            this.btnCreateFiles.Name = "btnCreateFiles";
            this.btnCreateFiles.Size = new System.Drawing.Size(959, 45);
            this.btnCreateFiles.TabIndex = 5;
            this.btnCreateFiles.Text = "Create Files";
            this.btnCreateFiles.UseVisualStyleBackColor = true;
            this.btnCreateFiles.Click += new System.EventHandler(this.btnCreateFiles_Click);
            // 
            // txtConsole
            // 
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConsole.Location = new System.Drawing.Point(6, 144);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(447, 268);
            this.txtConsole.TabIndex = 6;
            // 
            // tabControlMods
            // 
            this.tabControlMods.Controls.Add(this.tabModsClient);
            this.tabControlMods.Controls.Add(this.tabModsServer);
            this.tabControlMods.Location = new System.Drawing.Point(670, 23);
            this.tabControlMods.Name = "tabControlMods";
            this.tabControlMods.SelectedIndex = 0;
            this.tabControlMods.Size = new System.Drawing.Size(271, 392);
            this.tabControlMods.TabIndex = 7;
            // 
            // tabModsClient
            // 
            this.tabModsClient.Controls.Add(this.listModsClient);
            this.tabModsClient.Location = new System.Drawing.Point(4, 22);
            this.tabModsClient.Name = "tabModsClient";
            this.tabModsClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabModsClient.Size = new System.Drawing.Size(263, 366);
            this.tabModsClient.TabIndex = 0;
            this.tabModsClient.Text = "Client Files";
            this.tabModsClient.UseVisualStyleBackColor = true;
            // 
            // listModsClient
            // 
            this.listModsClient.FormattingEnabled = true;
            this.listModsClient.Location = new System.Drawing.Point(0, 0);
            this.listModsClient.Name = "listModsClient";
            this.listModsClient.Size = new System.Drawing.Size(263, 364);
            this.listModsClient.TabIndex = 0;
            // 
            // tabModsServer
            // 
            this.tabModsServer.Controls.Add(this.listModsServer);
            this.tabModsServer.Location = new System.Drawing.Point(4, 22);
            this.tabModsServer.Name = "tabModsServer";
            this.tabModsServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabModsServer.Size = new System.Drawing.Size(263, 366);
            this.tabModsServer.TabIndex = 1;
            this.tabModsServer.Text = "Server Files";
            this.tabModsServer.UseVisualStyleBackColor = true;
            // 
            // listModsServer
            // 
            this.listModsServer.FormattingEnabled = true;
            this.listModsServer.Location = new System.Drawing.Point(0, 0);
            this.listModsServer.Name = "listModsServer";
            this.listModsServer.Size = new System.Drawing.Size(263, 364);
            this.listModsServer.TabIndex = 1;
            // 
            // lblModsHeader
            // 
            this.lblModsHeader.AutoSize = true;
            this.lblModsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModsHeader.Location = new System.Drawing.Point(744, 2);
            this.lblModsHeader.Name = "lblModsHeader";
            this.lblModsHeader.Size = new System.Drawing.Size(128, 18);
            this.lblModsHeader.TabIndex = 8;
            this.lblModsHeader.Text = "Mods to include";
            // 
            // lblServerFiles
            // 
            this.lblServerFiles.AutoSize = true;
            this.lblServerFiles.Location = new System.Drawing.Point(3, 94);
            this.lblServerFiles.Name = "lblServerFiles";
            this.lblServerFiles.Size = new System.Drawing.Size(115, 13);
            this.lblServerFiles.TabIndex = 11;
            this.lblServerFiles.Text = "Server Jar + Extra Files";
            // 
            // btnModPackExtraFiles
            // 
            this.btnModPackExtraFiles.Location = new System.Drawing.Point(433, 88);
            this.btnModPackExtraFiles.Name = "btnModPackExtraFiles";
            this.btnModPackExtraFiles.Size = new System.Drawing.Size(27, 19);
            this.btnModPackExtraFiles.TabIndex = 10;
            this.btnModPackExtraFiles.Text = "...";
            this.btnModPackExtraFiles.UseVisualStyleBackColor = true;
            this.btnModPackExtraFiles.Click += new System.EventHandler(this.btnModPackExtraFiles_Click);
            // 
            // txtModPackExtraFiles
            // 
            this.txtModPackExtraFiles.Location = new System.Drawing.Point(124, 90);
            this.txtModPackExtraFiles.Name = "txtModPackExtraFiles";
            this.txtModPackExtraFiles.ReadOnly = true;
            this.txtModPackExtraFiles.Size = new System.Drawing.Size(303, 20);
            this.txtModPackExtraFiles.TabIndex = 9;
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(12, 422);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(935, 15);
            this.progressBarMain.TabIndex = 12;
            // 
            // progressBarSub
            // 
            this.progressBarSub.Location = new System.Drawing.Point(12, 443);
            this.progressBarSub.Name = "progressBarSub";
            this.progressBarSub.Size = new System.Drawing.Size(935, 15);
            this.progressBarSub.TabIndex = 13;
            // 
            // lblModPackName
            // 
            this.lblModPackName.AutoSize = true;
            this.lblModPackName.Location = new System.Drawing.Point(3, 13);
            this.lblModPackName.Name = "lblModPackName";
            this.lblModPackName.Size = new System.Drawing.Size(87, 13);
            this.lblModPackName.TabIndex = 14;
            this.lblModPackName.Text = "Mod Pack Name";
            // 
            // lblModPackVersion
            // 
            this.lblModPackVersion.AutoSize = true;
            this.lblModPackVersion.Location = new System.Drawing.Point(3, 40);
            this.lblModPackVersion.Name = "lblModPackVersion";
            this.lblModPackVersion.Size = new System.Drawing.Size(94, 13);
            this.lblModPackVersion.TabIndex = 15;
            this.lblModPackVersion.Text = "Mod Pack Version";
            // 
            // txtModPackName
            // 
            this.txtModPackName.Location = new System.Drawing.Point(90, 10);
            this.txtModPackName.Name = "txtModPackName";
            this.txtModPackName.Size = new System.Drawing.Size(337, 20);
            this.txtModPackName.TabIndex = 16;
            // 
            // txtModPackVersion
            // 
            this.txtModPackVersion.Location = new System.Drawing.Point(99, 37);
            this.txtModPackVersion.Name = "txtModPackVersion";
            this.txtModPackVersion.Size = new System.Drawing.Size(328, 20);
            this.txtModPackVersion.TabIndex = 17;
            // 
            // checkBoxClient
            // 
            this.checkBoxClient.AutoSize = true;
            this.checkBoxClient.Location = new System.Drawing.Point(6, 117);
            this.checkBoxClient.Name = "checkBoxClient";
            this.checkBoxClient.Size = new System.Drawing.Size(76, 17);
            this.checkBoxClient.TabIndex = 18;
            this.checkBoxClient.Text = "Client Files";
            this.checkBoxClient.UseVisualStyleBackColor = true;
            // 
            // checkBoxServer
            // 
            this.checkBoxServer.AutoSize = true;
            this.checkBoxServer.Location = new System.Drawing.Point(99, 117);
            this.checkBoxServer.Name = "checkBoxServer";
            this.checkBoxServer.Size = new System.Drawing.Size(81, 17);
            this.checkBoxServer.TabIndex = 19;
            this.checkBoxServer.Text = "Server Files";
            this.checkBoxServer.UseVisualStyleBackColor = true;
            // 
            // lblFolderHeader
            // 
            this.lblFolderHeader.AutoSize = true;
            this.lblFolderHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolderHeader.Location = new System.Drawing.Point(468, 4);
            this.lblFolderHeader.Name = "lblFolderHeader";
            this.lblFolderHeader.Size = new System.Drawing.Size(143, 18);
            this.lblFolderHeader.TabIndex = 20;
            this.lblFolderHeader.Text = "Folders to include";
            // 
            // tabControlFolders
            // 
            this.tabControlFolders.Controls.Add(this.tabFolderClient);
            this.tabControlFolders.Controls.Add(this.tabFolderServer);
            this.tabControlFolders.Location = new System.Drawing.Point(466, 23);
            this.tabControlFolders.Name = "tabControlFolders";
            this.tabControlFolders.SelectedIndex = 0;
            this.tabControlFolders.Size = new System.Drawing.Size(198, 392);
            this.tabControlFolders.TabIndex = 21;
            // 
            // tabFolderClient
            // 
            this.tabFolderClient.Controls.Add(this.listFoldersClient);
            this.tabFolderClient.Location = new System.Drawing.Point(4, 22);
            this.tabFolderClient.Name = "tabFolderClient";
            this.tabFolderClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabFolderClient.Size = new System.Drawing.Size(190, 366);
            this.tabFolderClient.TabIndex = 0;
            this.tabFolderClient.Text = "Client Files";
            this.tabFolderClient.UseVisualStyleBackColor = true;
            // 
            // listFoldersClient
            // 
            this.listFoldersClient.FormattingEnabled = true;
            this.listFoldersClient.Location = new System.Drawing.Point(0, 0);
            this.listFoldersClient.Name = "listFoldersClient";
            this.listFoldersClient.Size = new System.Drawing.Size(190, 364);
            this.listFoldersClient.TabIndex = 2;
            // 
            // tabFolderServer
            // 
            this.tabFolderServer.Controls.Add(this.listFoldersServer);
            this.tabFolderServer.Location = new System.Drawing.Point(4, 22);
            this.tabFolderServer.Name = "tabFolderServer";
            this.tabFolderServer.Padding = new System.Windows.Forms.Padding(3);
            this.tabFolderServer.Size = new System.Drawing.Size(190, 366);
            this.tabFolderServer.TabIndex = 1;
            this.tabFolderServer.Text = "Server Files";
            this.tabFolderServer.UseVisualStyleBackColor = true;
            // 
            // listFoldersServer
            // 
            this.listFoldersServer.FormattingEnabled = true;
            this.listFoldersServer.Location = new System.Drawing.Point(0, 0);
            this.listFoldersServer.Name = "listFoldersServer";
            this.listFoldersServer.Size = new System.Drawing.Size(190, 364);
            this.listFoldersServer.TabIndex = 3;
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Location = new System.Drawing.Point(280, 1);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(80, 23);
            this.btnLoadTemplate.TabIndex = 22;
            this.btnLoadTemplate.Text = "Load";
            this.btnLoadTemplate.UseVisualStyleBackColor = true;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // comboTemplates
            // 
            this.comboTemplates.FormattingEnabled = true;
            this.comboTemplates.Location = new System.Drawing.Point(93, 1);
            this.comboTemplates.Name = "comboTemplates";
            this.comboTemplates.Size = new System.Drawing.Size(181, 21);
            this.comboTemplates.TabIndex = 23;
            // 
            // lblLoadTemplate
            // 
            this.lblLoadTemplate.AutoSize = true;
            this.lblLoadTemplate.Location = new System.Drawing.Point(9, 4);
            this.lblLoadTemplate.Name = "lblLoadTemplate";
            this.lblLoadTemplate.Size = new System.Drawing.Size(78, 13);
            this.lblLoadTemplate.TabIndex = 24;
            this.lblLoadTemplate.Text = "Load Template";
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelContent.Controls.Add(this.lblModPackName);
            this.panelContent.Controls.Add(this.txtModPackPath);
            this.panelContent.Controls.Add(this.btnModPackPath);
            this.panelContent.Controls.Add(this.lblModPackPath);
            this.panelContent.Controls.Add(this.tabControlFolders);
            this.panelContent.Controls.Add(this.txtConsole);
            this.panelContent.Controls.Add(this.lblFolderHeader);
            this.panelContent.Controls.Add(this.tabControlMods);
            this.panelContent.Controls.Add(this.checkBoxServer);
            this.panelContent.Controls.Add(this.lblModsHeader);
            this.panelContent.Controls.Add(this.checkBoxClient);
            this.panelContent.Controls.Add(this.txtModPackExtraFiles);
            this.panelContent.Controls.Add(this.txtModPackVersion);
            this.panelContent.Controls.Add(this.btnModPackExtraFiles);
            this.panelContent.Controls.Add(this.txtModPackName);
            this.panelContent.Controls.Add(this.lblServerFiles);
            this.panelContent.Controls.Add(this.lblModPackVersion);
            this.panelContent.Controls.Add(this.progressBarMain);
            this.panelContent.Controls.Add(this.progressBarSub);
            this.panelContent.Location = new System.Drawing.Point(0, 28);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(959, 461);
            this.panelContent.TabIndex = 25;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Location = new System.Drawing.Point(366, 1);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(80, 23);
            this.btnSaveTemplate.TabIndex = 26;
            this.btnSaveTemplate.Text = "Save";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(452, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 23);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 531);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveTemplate);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.lblLoadTemplate);
            this.Controls.Add(this.comboTemplates);
            this.Controls.Add(this.btnLoadTemplate);
            this.Controls.Add(this.btnCreateFiles);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(975, 570);
            this.MinimumSize = new System.Drawing.Size(975, 570);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Mod Pack Packager v2.5.0 - By MJRLegends";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlMods.ResumeLayout(false);
            this.tabModsClient.ResumeLayout(false);
            this.tabModsServer.ResumeLayout(false);
            this.tabControlFolders.ResumeLayout(false);
            this.tabFolderClient.ResumeLayout(false);
            this.tabFolderServer.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtModPackPath;
        private System.Windows.Forms.Button btnModPackPath;
        private System.Windows.Forms.Label lblModPackPath;
        private System.Windows.Forms.Button btnCreateFiles;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TabControl tabControlMods;
        private System.Windows.Forms.TabPage tabModsClient;
        private System.Windows.Forms.TabPage tabModsServer;
        private System.Windows.Forms.Label lblModsHeader;
        private System.Windows.Forms.Label lblServerFiles;
        private System.Windows.Forms.Button btnModPackExtraFiles;
        private System.Windows.Forms.TextBox txtModPackExtraFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.ProgressBar progressBarSub;
        private System.Windows.Forms.Label lblModPackName;
        private System.Windows.Forms.Label lblModPackVersion;
        private System.Windows.Forms.TextBox txtModPackName;
        private System.Windows.Forms.TextBox txtModPackVersion;
        private System.Windows.Forms.CheckBox checkBoxClient;
        private System.Windows.Forms.CheckBox checkBoxServer;
        private System.Windows.Forms.CheckedListBox listModsClient;
        private System.Windows.Forms.CheckedListBox listModsServer;
        private System.Windows.Forms.Label lblFolderHeader;
        private System.Windows.Forms.TabControl tabControlFolders;
        private System.Windows.Forms.TabPage tabFolderClient;
        private System.Windows.Forms.CheckedListBox listFoldersClient;
        private System.Windows.Forms.TabPage tabFolderServer;
        private System.Windows.Forms.CheckedListBox listFoldersServer;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.ComboBox comboTemplates;
        private System.Windows.Forms.Label lblLoadTemplate;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnSaveTemplate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

