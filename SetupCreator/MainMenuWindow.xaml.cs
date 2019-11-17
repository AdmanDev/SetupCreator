using System;
using System.IO;
using System.Windows;

namespace SetupCreator
{
    public partial class MainMenuWindow : Window
    {
        public MainMenuWindow()
        {
            InitializeComponent();

            ArgToOpenFile();
        }

        //Close application
        private void BT_CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Move the window
        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Create new setup
        private void BT_New_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        //Open existing setup
        private void BT_Open_Click(object sender, RoutedEventArgs e)
        {
            if (new MainWindow().OpenSetup())
                this.Close();
        }

        //Check if there is an command to execute (with start argumments)
        private void ArgToOpenFile()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                string file = args[1];
                if (File.Exists(file) && Path.GetExtension(file) == Global.setupExtension)
                {
                    new MainWindow().OpenSetup(file);
                    this.Close();
                }
            }
        }

        //Show ADMAN Software-FR menu
        private void BT_ADMANSoftware_Click(object sender, RoutedEventArgs e)
        {
            App.admanMenu.ShowMenu();
        }
    }
}
