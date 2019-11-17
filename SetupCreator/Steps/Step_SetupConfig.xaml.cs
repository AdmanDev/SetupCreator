using System;
using System.IO;
using System.Windows.Controls;

namespace SetupCreator
{
    public partial class Step_SetupConfig : UserControl, IStep
    {
        //Constructor
        public Step_SetupConfig()
        {
            InitializeComponent();
        }

        //Load
        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TB_SetupName.Text = MainWindow.CurrentSetup.Name + " - Setup";
        }

        public bool Validate()
        {
            string buildPath = TB_SetupOutputPath.Text;
            string buildName = TB_SetupName.Text;
            string licencePath = TB_LicencePath.Text;
            string iconSource = TB_IconPath.Text;
            string appImage = TB_AppImage.Text;

            if (string.IsNullOrEmpty(buildPath) || string.IsNullOrEmpty(buildName))
                return false;

            MainWindow.CurrentSetup.BuildPath = buildPath;
            MainWindow.CurrentSetup.BuildName = buildName;
            MainWindow.CurrentSetup.CreateDesktopShortcut = CB_CreateDesktpShortcut.IsChecked == true;
            MainWindow.CurrentSetup.StartWhenFinish = CB_StartWhenFinish.IsChecked == true;

            if (!string.IsNullOrEmpty(licencePath))
            {
                if (File.Exists(licencePath))
                {
                    MainWindow.CurrentSetup.License = licencePath;
                }
                else
                {
                    ShowMsg("This license file was not found :" + Environment.NewLine + licencePath);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(iconSource))
            {
                if (File.Exists(iconSource))
                    MainWindow.CurrentSetup.IconSource = iconSource;
                else
                {
                    ShowMsg("This icon file was not found :" + Environment.NewLine + iconSource);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(appImage))
            {
                if (File.Exists(appImage))
                    MainWindow.CurrentSetup.AppImage = appImage;
                else
                {
                    ShowMsg("This application image file was not found :" + Environment.NewLine + appImage);
                    return false;
                }
            }
                

            return true;
        }

        private void ShowMsg(string msg)
        {
            System.Windows.Forms.MessageBox.Show(
               msg, "Setup - Creator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

        }

        public void Update()
        {
            TB_SetupOutputPath.Text = MainWindow.CurrentSetup.BuildPath;
            TB_SetupName.Text = MainWindow.CurrentSetup.BuildName;
            TB_LicencePath.Text = MainWindow.CurrentSetup.License;
            TB_IconPath.Text = MainWindow.CurrentSetup.IconSource;
            TB_AppImage.Text = MainWindow.CurrentSetup.AppImage;
            CB_CreateDesktpShortcut.IsChecked = MainWindow.CurrentSetup.CreateDesktopShortcut;
            CB_StartWhenFinish.IsChecked = MainWindow.CurrentSetup.StartWhenFinish;
        }

        private void BT_ChooseSetupOutputPath_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TB_SetupOutputPath.Text = fbd.SelectedPath;
            }
        }

        private void BT_ChooseLicence_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog()
            {
                Filter = "TXT|*.txt",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TB_LicencePath.Text = ofd.FileName;
            }
        }

        private void BT_ChooseIcon_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog()
            {
                Filter = "Icon|*.ico",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TB_IconPath.Text = ofd.FileName;
            }

        }

        private void BT_ChooseAppImage_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog()
            {
                Filter = "PNG|*.png",
                CheckFileExists = true,
                CheckPathExists = true
            };

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TB_AppImage.Text = ofd.FileName;
            }
        }
    }
}
