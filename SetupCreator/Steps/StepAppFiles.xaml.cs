using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using MyFunctions;
using System.Linq;

namespace SetupCreator
{
    public partial class StepAppFiles : UserControl, IStep
    {
        //Variables
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.FolderBrowserDialog fbd;

        List<string> files = new List<string>();
        List<string> filesNames = new List<string>();
        List<string> fDoublons = new List<string>();
        private List<string> setupFilesPath;
        private List<string> setupDirectoriesPath;
        private List<string> directoriesPathInBase;
        private List<string> filesInBase;

        //Constructor
        public StepAppFiles()
        {
            InitializeComponent();

            ofd = new System.Windows.Forms.OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
            };

            fbd = new System.Windows.Forms.FolderBrowserDialog();
        }

        private void BT_ChooseAppEXE_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ofd.Filter = "exe|*.exe";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TB_AppEXE.Text = ofd.FileName;
            }
        }

        private void BT_AddFile_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            ofd.Filter = "|*.*";
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (string f in ofd.FileNames)
                {
                    this.LV_Files.Items.Add(new ComboBoxItem() { Content = f.SplitAndGetLastPart(@"\"), Tag = f });
                }
            }
        }

        private void BT_AddFolder_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string f = fbd.SelectedPath;
                this.LV_Files.Items.Add(new ComboBoxItem() { Content = f.SplitAndGetLastPart(@"\") + @"\*", Tag = f + @"\*" });
            }
        }

        private void BT_Remove_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if(this.LV_Files.SelectedIndex >= 0)
            {
                this.LV_Files.Items.Remove(this.LV_Files.SelectedItem);
            }
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.TB_AppEXE.Text) && this.LV_Files.Items.Count < 1)
                return false;

            files = new List<string>();
            filesNames = new List<string>();
            fDoublons = new List<string>();
            setupFilesPath = new List<string>();
            setupDirectoriesPath = new List<string>();
            directoriesPathInBase = new List<string>();
            filesInBase = new List<string>();

            //Include the executable
            string exePath = this.TB_AppEXE.Text;
            string exeName =
            MainWindow.CurrentSetup.Executable = exePath.SplitAndGetLastPart(@"\");
            if (!string.IsNullOrEmpty(exePath))
            {
                if (!File.Exists(exePath))
                {
                    System.Windows.Forms.MessageBox.Show(
                        "This executable was not found :" + Environment.NewLine + exePath,
                        "Setup - Creator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                    this.TB_AppEXE.Text = "";
                    return false;
                }

                files.Add(this.TB_AppEXE.Text);
                setupFilesPath.Add(@"*\" + exeName);
                filesNames.Add(exeName);
            }

            //Include others files
            string f;
            foreach (ComboBoxItem i in this.LV_Files.Items)
            {
                f = i.Tag as string;
                if (f.Contains("*"))
                {//Directory
                    DirectoryInfo dir = new DirectoryInfo(f.Remove(f.Length - 2));

                    if (!dir.Exists)
                    {
                        System.Windows.Forms.MessageBox.Show(
                            "This directory was not found :" + Environment.NewLine + dir.FullName,
                            "Setup - Creator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                        return false;
                    }

                    directoriesPathInBase.Add(dir.FullName);
                    AddFilesRecursively(dir, @"*\");
                }
                else
                {//File
                    AddFile(f, @"*\");
                    filesInBase.Add(f);
                }
            }

            //Set setup infos
            MainWindow.CurrentSetup.AppFilesPath = files.ToArray();
            MainWindow.CurrentSetup.FDoublonsPath = fDoublons.ToArray();
            MainWindow.CurrentSetup.SetupFilesPaths = setupFilesPath.ToArray();
            MainWindow.CurrentSetup.DirectoriesPaths = setupDirectoriesPath.ToArray();
            MainWindow.CurrentSetup.FoldersInBase = directoriesPathInBase.ToArray();
            MainWindow.CurrentSetup.FilesInBase = filesInBase.ToArray();

            return true;
        }

        public void Update()
        {
            this.TB_AppEXE.Text = MainWindow.CurrentSetup.AppFilesPath.FirstOrDefault((s)=> s.EndsWith(MainWindow.CurrentSetup.Executable));

            this.LV_Files.Items.Clear();

            string fname;
            foreach (string f in MainWindow.CurrentSetup.FilesInBase)
            {
                fname = f.SplitAndGetLastPart(@"\");
                this.LV_Files.Items.Add(new ComboBoxItem() { Content = fname, Tag = f });
            }

            foreach (string f in MainWindow.CurrentSetup.FoldersInBase)
            {
                this.LV_Files.Items.Add(new ComboBoxItem() { Content = f.SplitAndGetLastPart(@"\") + @"\*", Tag = f + @"\*" });
            }
        }

        private void AddFilesRecursively(DirectoryInfo baseDir, string parent)
        {
            if (baseDir == null)
                return;

            if (!baseDir.Exists)
            {
                System.Windows.Forms.MessageBox.Show("This directory was not found :" + Environment.NewLine + baseDir.FullName,
                    "SetupGenerator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return;
            }

            foreach (FileInfo fi in baseDir.GetFiles())
            {
                AddFile(fi.FullName, parent);
            }

            string subdir;
            foreach (DirectoryInfo di in baseDir.GetDirectories())
            {
                subdir = parent + @"\" + di.Name;
                AddFilesRecursively(di, subdir);
                setupDirectoriesPath.Add(subdir);
            }
        }

        private void AddFile(string _file, string _parent)
        {
            string fname = new FileInfo(_file).Name;
            setupFilesPath.Add(_parent + @"\" + fname);

            if (!filesNames.Contains(fname))
            {
                filesNames.Add(fname);
                files.Add(_file);
            }
            else
            {
                fDoublons.Add(_file);
            }
        }

    }
}
