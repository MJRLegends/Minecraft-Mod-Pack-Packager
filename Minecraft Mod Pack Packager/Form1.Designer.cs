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
            this.txtModPackPath = new System.Windows.Forms.TextBox();
            this.btnModPackPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCreateFiles = new System.Windows.Forms.Button();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnModPackExtraFiles = new System.Windows.Forms.Button();
            this.txModPackExtraFiles = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModPackName = new System.Windows.Forms.TextBox();
            this.txtModPackVersion = new System.Windows.Forms.TextBox();
            this.checkBoxClient = new System.Windows.Forms.CheckBox();
            this.checkBoxServer = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.checkedListBox4 = new System.Windows.Forms.CheckedListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtModPackPath
            // 
            this.txtModPackPath.Location = new System.Drawing.Point(96, 59);
            this.txtModPackPath.Name = "txtModPackPath";
            this.txtModPackPath.ReadOnly = true;
            this.txtModPackPath.Size = new System.Drawing.Size(337, 20);
            this.txtModPackPath.TabIndex = 0;
            // 
            // btnModPackPath
            // 
            this.btnModPackPath.Location = new System.Drawing.Point(439, 60);
            this.btnModPackPath.Name = "btnModPackPath";
            this.btnModPackPath.Size = new System.Drawing.Size(27, 19);
            this.btnModPackPath.TabIndex = 1;
            this.btnModPackPath.Text = "...";
            this.btnModPackPath.UseVisualStyleBackColor = true;
            this.btnModPackPath.Click += new System.EventHandler(this.btnModPackPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mod Pack Path";
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
            this.txtConsole.Location = new System.Drawing.Point(12, 157);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConsole.Size = new System.Drawing.Size(447, 268);
            this.txtConsole.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(676, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(271, 392);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkedListBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(263, 366);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Client Files";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(260, 364);
            this.checkedListBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkedListBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(263, 366);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Server Files";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(263, 364);
            this.checkedListBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(750, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Mods to include";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Server Jar + Extra Files";
            // 
            // btnModPackExtraFiles
            // 
            this.btnModPackExtraFiles.Location = new System.Drawing.Point(439, 93);
            this.btnModPackExtraFiles.Name = "btnModPackExtraFiles";
            this.btnModPackExtraFiles.Size = new System.Drawing.Size(27, 19);
            this.btnModPackExtraFiles.TabIndex = 10;
            this.btnModPackExtraFiles.Text = "...";
            this.btnModPackExtraFiles.UseVisualStyleBackColor = true;
            this.btnModPackExtraFiles.Click += new System.EventHandler(this.btnModPackExtraFiles_Click);
            // 
            // txModPackExtraFiles
            // 
            this.txModPackExtraFiles.Location = new System.Drawing.Point(130, 92);
            this.txModPackExtraFiles.Name = "txModPackExtraFiles";
            this.txModPackExtraFiles.ReadOnly = true;
            this.txModPackExtraFiles.Size = new System.Drawing.Size(303, 20);
            this.txModPackExtraFiles.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 431);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(935, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(12, 460);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(935, 21);
            this.progressBar2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mod Pack Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mod Pack Version";
            // 
            // txtModPackName
            // 
            this.txtModPackName.Location = new System.Drawing.Point(96, 6);
            this.txtModPackName.Name = "txtModPackName";
            this.txtModPackName.Size = new System.Drawing.Size(337, 20);
            this.txtModPackName.TabIndex = 16;
            // 
            // txtModPackVersion
            // 
            this.txtModPackVersion.Location = new System.Drawing.Point(105, 33);
            this.txtModPackVersion.Name = "txtModPackVersion";
            this.txtModPackVersion.Size = new System.Drawing.Size(328, 20);
            this.txtModPackVersion.TabIndex = 17;
            // 
            // checkBoxClient
            // 
            this.checkBoxClient.AutoSize = true;
            this.checkBoxClient.Location = new System.Drawing.Point(12, 124);
            this.checkBoxClient.Name = "checkBoxClient";
            this.checkBoxClient.Size = new System.Drawing.Size(76, 17);
            this.checkBoxClient.TabIndex = 18;
            this.checkBoxClient.Text = "Client Files";
            this.checkBoxClient.UseVisualStyleBackColor = true;
            // 
            // checkBoxServer
            // 
            this.checkBoxServer.AutoSize = true;
            this.checkBoxServer.Location = new System.Drawing.Point(105, 124);
            this.checkBoxServer.Name = "checkBoxServer";
            this.checkBoxServer.Size = new System.Drawing.Size(81, 17);
            this.checkBoxServer.TabIndex = 19;
            this.checkBoxServer.Text = "Server Files";
            this.checkBoxServer.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(474, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "Folder/Files to include";
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(472, 28);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(198, 392);
            this.tabControl2.TabIndex = 21;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.checkedListBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(190, 366);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Client Files";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(190, 364);
            this.checkedListBox3.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.checkedListBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(190, 366);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Server Files";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // checkedListBox4
            // 
            this.checkedListBox4.FormattingEnabled = true;
            this.checkedListBox4.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox4.Name = "checkedListBox4";
            this.checkedListBox4.Size = new System.Drawing.Size(190, 364);
            this.checkedListBox4.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 531);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBoxServer);
            this.Controls.Add(this.checkBoxClient);
            this.Controls.Add(this.txtModPackVersion);
            this.Controls.Add(this.txtModPackName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnModPackExtraFiles);
            this.Controls.Add(this.txModPackExtraFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.btnCreateFiles);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModPackPath);
            this.Controls.Add(this.txtModPackPath);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(975, 570);
            this.MinimumSize = new System.Drawing.Size(975, 570);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Mod Pack Packager - By MJRLegends";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtModPackPath;
        private System.Windows.Forms.Button btnModPackPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateFiles;
        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnModPackExtraFiles;
        private System.Windows.Forms.TextBox txModPackExtraFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModPackName;
        private System.Windows.Forms.TextBox txtModPackVersion;
        private System.Windows.Forms.CheckBox checkBoxClient;
        private System.Windows.Forms.CheckBox checkBoxServer;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckedListBox checkedListBox4;
    }
}

