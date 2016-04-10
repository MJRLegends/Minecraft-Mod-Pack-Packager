using System;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using Ionic.Zip;

namespace Minecraft_Mod_Pack_Packager
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public String modpackPath = "";
        public String serverfilesPath = "";
        public String name = "";
        public String version = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnModPackPath_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select Mod Pack Folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    modpackPath = dlg.SelectedPath;
                    txtModPackPath.Text = modpackPath;
                }
            }
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            checkedListBox4.Items.Clear();
            if (Directory.Exists(modpackPath + @"\config\") && Directory.Exists(modpackPath + @"\mods\"))
            {

                string filepath = modpackPath + @"\mods\";
                DirectoryInfo d = new DirectoryInfo(filepath);

                foreach (var file in d.GetFiles("*.jar"))
                {
                    checkedListBox1.Items.Add(file.Name, true);
                    checkedListBox2.Items.Add(file.Name, true);
                }
                bool itemChecked = false;
                string[] dirs = Directory.GetDirectories(@modpackPath);
                foreach (string item2 in dirs)
                {
                    FileInfo f = new FileInfo(item2);
                    if (f.Name.ToLower().Equals("config") || f.Name.ToLower().Equals("mods"))
                        itemChecked = true;
                    else
                        itemChecked = false;
                    checkedListBox3.Items.Add(f.Name, itemChecked);
                    checkedListBox4.Items.Add(f.Name, itemChecked);
                }
            }
            else
            {
                MessageBox.Show("The directory doesnt seem to have a config & mods folder, You sure thats the correct folder you have selected?", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                txtModPackPath.Clear();
            }
        }

        private void btnModPackExtraFiles_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select Server Files/Extra Files Folder";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    serverfilesPath = dlg.SelectedPath;
                    txModPackExtraFiles.Text = serverfilesPath;
                }
            }
        }

        public void SaveProgress(object sender, SaveProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Saving_Started)
            {
                txtConsole.AppendText("Begin Saving: " + e.ArchiveName + "\n");
            }
            else if (e.EventType == ZipProgressEventType.Saving_BeforeWriteEntry)
            {
                txtConsole.AppendText("Writing: " + e.CurrentEntry.FileName + " (" + (e.EntriesSaved + 1) + "/" + e.EntriesTotal + ")"+ "\n");
                txtConsole.AppendText("Filename:" + e.CurrentEntry.FileName + "\n");

                progressBar2.Maximum = e.EntriesTotal;
                progressBar2.Value = e.EntriesSaved + 1;
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                progressBar1.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                txtConsole.AppendText("Done!" + "\n");
                progressBar1.Value = 0;
                progressBar2.Value = 0;
            }
        }

        private void btnCreateFiles_Click(object sender, EventArgs e)
        {
            if (checkBoxClient.Checked == false && checkBoxServer.Checked == false)
            {
                MessageBox.Show("You need to select the type of files you want to package", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            else if (txtModPackPath.Text == "" || txtModPackName.Text == "" || txtModPackVersion.Text == "")
            {
                MessageBox.Show("You need to fill out all the information", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            else if (txModPackExtraFiles.Text == "")
            {
                String output = MessageBox.Show("Are you sure you dont want to include any extra server files such as jar's", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning).ToString();
                if (output.ToLower().Equals("No"))
                {
                    return;
                }
            }
            name = txtModPackName.Text;
            version = txtModPackVersion.Text;
            if (checkBoxClient.Checked == true)
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.ParallelDeflateThreshold = -1;
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.SaveProgress += SaveProgress;
                    zip.StatusMessageTextWriter = System.Console.Out;
                    txtConsole.AppendText("Creating Client Files..." + "\n");
                    txtConsole.AppendText("Adding Files..." + "\n");
                    if (Directory.Exists(modpackPath + @"\config\"))
                        zip.AddDirectory(@modpackPath + @"\config\", @"minecraft\config");
                    if (Directory.Exists(modpackPath + @"\mods\"))
                    {
                        string filepath = modpackPath + @"\mods\";
                        DirectoryInfo d = new DirectoryInfo(filepath);

                        foreach (var file in d.GetFiles("*.jar"))
                        {
                            if (checkedListBox1.CheckedItems.Contains(file.Name))
                                zip.AddFile(@modpackPath + @"\mods\" + file.Name, @"minecraft\mods");
                        }

                        string[] dirs = Directory.GetDirectories(@modpackPath + @"\mods\");
                        foreach (string item2 in dirs)
                        {
                            FileInfo f = new FileInfo(item2);
                            zip.AddDirectory(@modpackPath + @"\mods\" + f.Name + @"\", @"minecraft\mods\" + f.Name);
                        }
                    }

                    for (int i = 0; i < checkedListBox3.Items.Count; i++)
                    {
                        String folder = checkedListBox3.GetItemText(checkedListBox3.Items[i]);
                        if (checkedListBox3.CheckedItems.Contains(folder))
                        {
                            if (!folder.ToLower().Equals("config") && !folder.ToLower().Equals("mods"))
                            {
                                if (Directory.Exists(@modpackPath + @"\" + folder + @"\"))
                                    zip.AddDirectory(@modpackPath + @"\" + folder + @"\", @"minecraft\" + folder);
                            }
                        }
                    }
                    zip.Save(@Application.StartupPath + "/" + name + " v" + version + ".zip");
                    zip.Dispose();
                }
            }
            if (checkBoxServer.Checked == true)
            {
                String serverFolderName = name + " Server Files - Use with v" + version;
                using (ZipFile zip = new ZipFile())
                {
                    zip.ParallelDeflateThreshold = -1;
                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    zip.SaveProgress += SaveProgress;
                    zip.StatusMessageTextWriter = System.Console.Out;
                    txtConsole.AppendText("Creating Server Files..." + "\n");
                    txtConsole.AppendText("Adding Files..." + "\n");
                    if (Directory.Exists(modpackPath + @"\config\"))
                        zip.AddDirectory(@modpackPath + @"\config\", @"\" + serverFolderName + @"\config");
                    if (Directory.Exists(modpackPath + @"\mods\"))
                    {
                        string filepath = modpackPath + @"\mods\";
                        DirectoryInfo d = new DirectoryInfo(filepath);

                        foreach (var file in d.GetFiles("*.jar"))
                        {
                            if (checkedListBox2.CheckedItems.Contains(file.Name))
                                zip.AddFile(@modpackPath + @"\mods\" + file.Name, @"\" + serverFolderName + @"\mods");
                        }

                        string[] dirs = Directory.GetDirectories(@modpackPath + @"\mods\");
                        foreach (string item2 in dirs)
                        {
                            FileInfo f = new FileInfo(item2);
                            zip.AddDirectory(@modpackPath + @"\mods\" + f.Name + @"\", @"\" + serverFolderName + @"\mods\" + f.Name);
                        }
                    }
                    for (int i = 0; i < checkedListBox4.Items.Count; i++)
                    {
                        String folderServer = checkedListBox4.GetItemText(checkedListBox4.Items[i]);
                        if (checkedListBox4.CheckedItems.Contains(folderServer))
                        {
                            if (!folderServer.ToLower().Equals("config") && !folderServer.ToLower().Equals("mods"))
                            {
                                if (Directory.Exists(modpackPath + @"\" + folderServer + @"\"))
                                    zip.AddDirectory(@modpackPath + @"\" + folderServer + @"\", @"\" + serverFolderName + @"\" + folderServer);
                            }
                        }
                    }
                    if (txModPackExtraFiles.Text != "")
                        zip.AddDirectory(@serverfilesPath, @"\" + serverFolderName + @"\");
                    zip.Save(@Application.StartupPath + "/" + name + " v" + version + " Server Files" + ".zip");
                    zip.Dispose();
                }
            }
                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
