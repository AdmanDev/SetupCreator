using System;
using System.Windows;
using System.Windows.Controls;

namespace SetupCreator
{
    public partial class StepAppFolder : UserControl, IStep
    {
        //Variables
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private bool loading = true;
        private string setupBaseFolder;

        //Constructor
        public StepAppFolder()
        {
            InitializeComponent();

            fbd = new System.Windows.Forms.FolderBrowserDialog()
            {
                ShowNewFolderButton = true,
            };

            setupBaseFolder = @"@ProgramFiles";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(setupBaseFolder))
            {
                this.TB_BaseFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }
            else
            {
                this.TB_BaseFolder.Text = MainWindow.CurrentSetup.BaseFolder;
                switch (setupBaseFolder)
                {
                    case "@ProgramFiles":
                        this.CBB_DefaultsBaseFolders.SelectedIndex = 0;
                        this.TB_BaseFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                        break;

                    case "@Desktop":
                        this.CBB_DefaultsBaseFolders.SelectedIndex = 1;
                        this.TB_BaseFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        break;

                    default:
                        this.CBB_DefaultsBaseFolders.SelectedIndex = this.CBB_DefaultsBaseFolders.Items.Count-1;
                        this.TB_BaseFolder.Text = setupBaseFolder;
                        break;
                }
            }

            this.TB_AppFolderName.Text = MainWindow.CurrentSetup.Name;
        }

        private void BT_ChooseBaseFolder_Click(object sender, RoutedEventArgs e)
        {
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TB_BaseFolder.Text = setupBaseFolder = fbd.SelectedPath;
            }
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(setupBaseFolder) || string.IsNullOrEmpty(this.TB_AppFolderName.Text))
                return false;

            MainWindow.CurrentSetup.BaseFolder = setupBaseFolder;
            MainWindow.CurrentSetup.AppFolderName = this.TB_AppFolderName.Text;
            MainWindow.CurrentSetup.AllowChangeBaseFolder = this.CB_AllowUserChangeAppFolder.IsChecked == true;

            return true;
        }

        public void Update()
        {
            setupBaseFolder = this.TB_BaseFolder.Text = MainWindow.CurrentSetup.BaseFolder;
            this.TB_AppFolderName.Text = MainWindow.CurrentSetup.AppFolderName;
            this.CB_AllowUserChangeAppFolder.IsChecked = MainWindow.CurrentSetup.AllowChangeBaseFolder;
        }

        private void CBB_DefaultsBaseFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(loading)
            {
                loading = false;
                return;
            }

            switch (this.CBB_DefaultsBaseFolders.SelectedIndex)
            {
                case 0:
                    this.TB_BaseFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                    setupBaseFolder = @"@ProgramFiles";
                    break;

                case 1:
                    this.TB_BaseFolder.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    setupBaseFolder = @"@Desktop";
                    break;

            }

            this.BT_ChooseBaseFolder.IsEnabled = (this.CBB_DefaultsBaseFolders.SelectedIndex >= this.CBB_DefaultsBaseFolders.Items.Count-1);


        }

    }
}
