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
            listModsClient.Items.Clear();
            listModsServer.Items.Clear();
            listFoldersClient.Items.Clear();
            listFoldersServer.Items.Clear();
            if (Directory.Exists(modpackPath + @"\config\") && Directory.Exists(modpackPath + @"\mods\"))
            {

                string filepath = modpackPath + @"\mods\";
                DirectoryInfo d = new DirectoryInfo(filepath);

                foreach (var file in d.GetFiles("*.jar"))
                {
                    listModsClient.Items.Add(file.Name, true);
                    listModsServer.Items.Add(file.Name, true);
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
                    listFoldersClient.Items.Add(f.Name, itemChecked);
                    listFoldersServer.Items.Add(f.Name, itemChecked);
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

                progressBarSub.Maximum = e.EntriesTotal;
                progressBarSub.Value = e.EntriesSaved + 1;
            }
            else if (e.EventType == ZipProgressEventType.Saving_EntryBytesRead)
            {
                progressBarMain.Value = (int)((e.BytesTransferred * 100) / e.TotalBytesToTransfer);
            }
            else if (e.EventType == ZipProgressEventType.Saving_Completed)
            {
                txtConsole.AppendText("Done!" + "\n");
                progressBarMain.Value = 0;
                progressBarSub.Value = 0;
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
                            if (listModsClient.CheckedItems.Contains(file.Name))
                                zip.AddFile(@modpackPath + @"\mods\" + file.Name, @"minecraft\mods");
                        }

                        string[] dirs = Directory.GetDirectories(@modpackPath + @"\mods\");
                        foreach (string item2 in dirs)
                        {
                            FileInfo f = new FileInfo(item2);
                            zip.AddDirectory(@modpackPath + @"\mods\" + f.Name + @"\", @"minecraft\mods\" + f.Name);
                        }
                    }

                    for (int i = 0; i < listFoldersClient.Items.Count; i++)
                    {
                        String folder = listFoldersClient.GetItemText(listFoldersClient.Items[i]);
                        if (listFoldersClient.CheckedItems.Contains(folder))
                        {
                            if (!folder.ToLower().Equals("config") && !folder.ToLower().Equals("mods"))
                            {
                                if (Directory.Exists(@modpackPath + @"\" + folder + @"\"))
                                    zip.AddDirectory(@modpackPath + @"\" + folder + @"\", @"minecraft\" + folder);
                            }
                        }
                    }
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"C:\";
                    saveFileDialog1.Title = "Save Client Files";
                    saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.DefaultExt = ".zip";
                    saveFileDialog1.Filter = "ZIP file (*.zip)|*.zip";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.FileName = name + " v" + version + ".zip";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        zip.Save(saveFileDialog1.FileName);
                    }
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
                            if (listModsServer.CheckedItems.Contains(file.Name))
                                zip.AddFile(@modpackPath + @"\mods\" + file.Name, @"\" + serverFolderName + @"\mods");
                        }

                        string[] dirs = Directory.GetDirectories(@modpackPath + @"\mods\");
                        foreach (string item2 in dirs)
                        {
                            FileInfo f = new FileInfo(item2);
                            zip.AddDirectory(@modpackPath + @"\mods\" + f.Name + @"\", @"\" + serverFolderName + @"\mods\" + f.Name);
                        }
                    }
                    for (int i = 0; i < listFoldersServer.Items.Count; i++)
                    {
                        String folderServer = listFoldersServer.GetItemText(listFoldersServer.Items[i]);
                        if (listFoldersServer.CheckedItems.Contains(folderServer))
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
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = @"C:\";
                    saveFileDialog1.Title = "Save Server Files";
                    saveFileDialog1.CheckPathExists = true;
                    saveFileDialog1.DefaultExt = ".zip";
                    saveFileDialog1.Filter = "ZIP file (*.zip)|*.zip";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    saveFileDialog1.FileName = name + " v" + version + " Server Files" + ".zip";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        zip.Save(saveFileDialog1.FileName);
                    }
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
                                loadModPackFiles();
                            }
                            else if (reader.Name == "UnTickedClientMods")
                            {
                                int number = 0;
                                for (int i = 0; i < Convert.ToInt32(reader.GetAttribute("NumOfClientMods")); i++)
                                {
                                    for (int j = 0; j < listModsClient.Items.Count; j++)
                                    {
                                        if (listModsClient.CheckedItems.Contains(reader.GetAttribute("ClientMod" + number)) && listModsClient.Items[j].ToString().Equals(reader.GetAttribute("ClientMod" + number)))
                                        {
                                            listModsClient.SetItemCheckState(j, CheckState.Unchecked);
                                            number++;
                                        }
                                    }
                                }
                            }
                            else if (reader.Name == "UnTickedServerMods")
                            {
                                int number = 0;
                                int amount = Convert.ToInt32(reader.GetAttribute("NumOfServerMods"));
                                for (int i = 0; i < amount; i++)
                                {
                                    for (int j = 0; j < listModsServer.Items.Count; j++)
                                    {
                                        if (listModsServer.CheckedItems.Contains(reader.GetAttribute("ServerMod" + number)) && listModsServer.Items[j].ToString().Equals(reader.GetAttribute("ServerMod" + number)))
                                        {
                                            listModsServer.SetItemCheckState(j, CheckState.Unchecked);
                                            number++;
                                        }
                                            
                                    }
                                }
                            }
                            else if (reader.Name == "TickedClientFolders")
                            {
                                int number = 0;
                                for (int i = 0; i < Convert.ToInt32(reader.GetAttribute("NumOfClientFolders")); i++)
                                {
                                    for (int j = 0; j < listFoldersClient.Items.Count; j++)
                                    {
                                        if (!listFoldersClient.CheckedItems.Contains(reader.GetAttribute("ClientFolder" + number)) && listFoldersClient.Items[j].ToString().Equals(reader.GetAttribute("ClientFolder" + number)))
                                        {
                                            listFoldersClient.SetItemCheckState(j, CheckState.Checked);
                                            number++;
                                        }
                                    }
                                }
                            }
                            else if (reader.Name == "TickedServerFolders")
                            {
                                int number = 0;
                                for (int i = 0; i < Convert.ToInt32(reader.GetAttribute("NumOfServerFolders")); i++)
                                {
                                    for (int j = 0; j < listFoldersServer.Items.Count; j++)
                                    {
                                        if (!listFoldersServer.CheckedItems.Contains(reader.GetAttribute("ServerFolder" + number)) && listFoldersServer.Items[j].ToString().Equals(reader.GetAttribute("ServerFolder" + number)))
                                        {
                                            listFoldersServer.SetItemCheckState(j, CheckState.Checked);
                                            number++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    reader.Close();
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

                int number = 0;
                writer.WriteStartElement("UnTickedClientMods");
                for (int i = 0; i < listModsClient.Items.Count; i++)
                {
                    if (!listModsClient.GetItemChecked(i))
                    {
                        writer.WriteAttributeString("ClientMod" + number, listModsClient.Items[i].ToString());
                        number++;
                    }
                }
                writer.WriteAttributeString("NumOfClientMods", "" + number);
                writer.WriteEndElement();

                number = 0;
                writer.WriteStartElement("UnTickedServerMods");
                for (int i = 0; i < listModsServer.Items.Count; i++)
                {
                    if (!listModsServer.GetItemChecked(i))
                    {
                        writer.WriteAttributeString("ServerMod" + number, listModsServer.Items[i].ToString());
                        number++;
                    }
                }
                writer.WriteAttributeString("NumOfServerMods", "" + number);
                writer.WriteEndElement();

                number = 0;
                writer.WriteStartElement("TickedClientFolders");
                for (int i = 0; i < listFoldersClient.Items.Count; i++)
                {
                    if (listFoldersClient.GetItemChecked(i))
                    {
                        if (!listFoldersClient.Items[i].Equals("config") && !listFoldersClient.Items[i].Equals("mods"))
                        {
                            writer.WriteAttributeString("ClientFolder" + number, listFoldersClient.Items[i].ToString());
                            number++;
                        }
                    }
                }
                writer.WriteAttributeString("NumOfClientFolders", "" + number);
                writer.WriteEndElement();

                number = 0;
                writer.WriteStartElement("TickedServerFolders");
                for (int i = 0; i < listFoldersServer.Items.Count; i++)
                {
                    if (listFoldersServer.GetItemChecked(i))
                    {
                        if (!listFoldersServer.Items[i].Equals("config") && !listFoldersServer.Items[i].Equals("mods"))
                        {
                            writer.WriteAttributeString("ServerFolder" + number, listFoldersServer.Items[i].ToString());
                            number++;
                        }
                    }
                }
                writer.WriteAttributeString("NumOfServerFolders", "" + number);
                writer.WriteEndElement();
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
            listModsClient.Items.Clear();
            listModsServer.Items.Clear();
            listFoldersClient.Items.Clear();
            listFoldersServer.Items.Clear();
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
