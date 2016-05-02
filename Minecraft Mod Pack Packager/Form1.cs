using System;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;
using Ionic.Zip;
using System.Xml;

namespace Minecraft_Mod_Pack_Packager
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public String modpackPath = "";
        public String serverfilesPath = "";
        public String name = "";
        public String version = "";
        public String templatesFolderPath = "";

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
                    txtModPackPath.Text = dlg.SelectedPath;
                }
            }
            loadModPackFiles();
        }
        private void loadModPackFiles()
        {
            modpackPath = txtModPackPath.Text;
            serverfilesPath = txtModPackExtraFiles.Text;
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
                    txtModPackExtraFiles.Text = dlg.SelectedPath;
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
            if (txtModPackPath.Text == "" || txtModPackName.Text == "" || txtModPackVersion.Text == "")
            {
                MessageBox.Show("You need to fill out all the information", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            else if (checkBoxClient.Checked == false && checkBoxServer.Checked == false)
            {
                MessageBox.Show("You need to select the type of files you want to package", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            else if (txtModPackExtraFiles.Text == "")
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
                    zip.Save(Application.StartupPath + @"\" + name + " v" + version + ".zip");
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
                    if (txtModPackExtraFiles.Text != "")
                        zip.AddDirectory(@serverfilesPath, @"\" + serverFolderName + @"\");
                    zip.Save(Application.StartupPath + @"\" + name + " v" + version + " Server Files" + ".zip");
                    zip.Dispose();
                }
            }
                      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            templatesFolderPath = Application.StartupPath + @"\templates\";
            if (!Directory.Exists(templatesFolderPath))
            {
                Directory.CreateDirectory(templatesFolderPath);
            }

            DirectoryInfo d = new DirectoryInfo(templatesFolderPath);
            foreach (var file in d.GetFiles("*.xml"))
            {
                comboTemplates.Items.Add(file.Name.Substring(0, (file.Name.Length - 4)));
            }
        }

        private void btnLoadTemplate_Click(object sender, EventArgs e)
        {
            try {
               if (comboTemplates.Items.Count > 0 && comboTemplates.Text != "")
                {
                    XmlTextReader reader = new XmlTextReader(templatesFolderPath + comboTemplates.Text + ".xml");
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            if (reader.Name == "TemplateInfo")
                            {
                                txtModPackName.Text = comboTemplates.Text;
                                txtModPackVersion.Text = reader.GetAttribute("CurrentVersion");
                                txtModPackPath.Text = reader.GetAttribute("ModPackPath");
                                txtModPackExtraFiles.Text = reader.GetAttribute("ExtraFilesPath");
                                checkBoxClient.Checked = Convert.ToBoolean(reader.GetAttribute("ClientFiles"));
                                checkBoxServer.Checked = Convert.ToBoolean(reader.GetAttribute("ServerFiles"));
                            }
                        }
                    }
                    reader.Close();
                    loadModPackFiles();
                }
            }
            catch (Exception ex)
            {
                txtConsole.AppendText("Unable to load " + templatesFolderPath + txtModPackName.Text + ".xml" + ex.Message);
            }
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            if (txtModPackPath.Text == "" || txtModPackName.Text == "" || txtModPackVersion.Text == "")
            {
                MessageBox.Show("You need to fill out all the information", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            else if (checkBoxClient.Checked == false && checkBoxServer.Checked == false)
            {
                MessageBox.Show("You need to select the type of files you want to package", "Error!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                return;
            }
            try {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(templatesFolderPath + txtModPackName.Text + ".xml", settings);
                writer.WriteStartDocument();
                writer.WriteStartElement("TemplateInfo");
                writer.WriteAttributeString("CurrentVersion", txtModPackVersion.Text);
                writer.WriteAttributeString("ModPackPath", txtModPackPath.Text);
                writer.WriteAttributeString("ExtraFilesPath", txtModPackExtraFiles.Text);
                writer.WriteAttributeString("ClientFiles", checkBoxClient.Checked.ToString());
                writer.WriteAttributeString("ServerFiles", checkBoxServer.Checked.ToString());

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            catch(Exception ex)
            {
                txtConsole.AppendText("Unable to save " + templatesFolderPath + txtModPackName.Text + ".xml" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            checkedListBox2.Items.Clear();
            checkedListBox3.Items.Clear();
            checkedListBox4.Items.Clear();
            txtModPackName.Text = "";
            txtModPackVersion.Text = "";
            txtModPackPath.Text = "";
            txtModPackExtraFiles.Text = "";
            checkBoxClient.Checked = false;
            checkBoxServer.Checked = false;
            txtConsole.Text = "";
        }

    }
}
