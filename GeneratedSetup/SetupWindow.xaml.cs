using SetupCreator;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml;

namespace GeneratedSetup
{
    public partial class SetupWindow : Window
    {
        //XML KEYS
        private const string BASEFOLDER_key = "baseFolder";
        private const string XMLINFOS_key = "SetupGeneratorInfos.xml";
        private const string APPFOLDER_key = "appFolderName";
        private const string EXENAME_key = "exeName";
        private const string APPNAME_key = "name";
        private const string ALLOWCHANGEAPPFOLDER_key = "allowChangeBaseFolder";
        private const string CREATESHORTCUT_key = "createDesktopShortcut";
        private const string LICENSE_key = "license";
        private const string VERSION_key = "version";
        private const string STARTWHENFINISH_key = "startWhenFinish";
        private const string APPIMAGE_key = "appImage";

        //Formatting variables
        private const char fDoublonChar = '@';
        private const string specialFolderChar = "@";

        //Command variables
        private readonly string[] args;  //shema : "COMMAND%PARAM1?PARAM2..."
        private const char commandCharSeparator = '%';
        private const char paramsCharSeparator = '?';

        //Variables
        private Dictionary<string, string> setupParams = null;

        private readonly Dictionary<string, Stream> setupFiles = null;
        private List<string> voidableFiles; // files to remove if the installation is stopped
        private List<string> filesPaths;
        private List<string> dirsPaths;
        private List<Ad> ads;

        private int progress;
        private Thread threadInstall;
        private bool stopInstall;
        private bool success;

        private readonly StackPanel step_License;
        private readonly StackPanel step_Success;
        private readonly StackPanel step1;
        private readonly StackPanel step2;

        private string baseOutput;
        private string outputPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private string exeName;

        private bool createShortcut = false;
        private bool startWhenFinish = false;

        //Controls variables
        private System.Windows.Controls.TextBox TB_OutputDir;
        private System.Windows.Controls.ProgressBar PB_Instalation;
        private System.Windows.Controls.Label LB_InstallationDetail;
        private Image IMG_LargeIcon;
        private System.Windows.Controls.Label LB_SetupName;
        private System.Windows.Controls.Button BT_ChooseOutputDir;
        private System.Windows.Controls.Button BT_ValidateLicence;
        private System.Windows.Controls.Label LB_Statut;
        private System.Windows.Controls.CheckBox CB_StartApp;
        private System.Windows.Controls.CheckBox CB_CreateShortcut;

        //Events
        private event Action<bool> InstallFinished;

        //Properties
        private int InstallProgess
        {
            get => progress;
            set
            {
                if (value == progress)
                    return;

                progress = value;

                if (PB_Instalation != null)
                {
                    PB_Instalation.Value = value;
                }
            }
        }

        //Constructor
        public SetupWindow(Dictionary<string, System.IO.Stream> _files)
        {
            InitializeComponent();

            setupFiles = _files;
            PrepareSetup();

            LoadSettings();

            step_License = (StackPanel)FindResource("Step_License");
            step_Success = (StackPanel)FindResource("Step_Success");
            step1 = (StackPanel)FindResource("Step1");
            step2 = (StackPanel)FindResource("Step2");

            args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                ReadCommands();
            }
            else
            {
                if (!string.IsNullOrEmpty(setupParams[LICENSE_key]))
                    ShowStep(step_License);
                else
                    ShowStep(step1);
            }

        }

        //Close this application
        private void BT_CloseApp_Click(object sender, RoutedEventArgs e)
        {
            CloseApp();
        }

        private void CloseApp()
        {
            Close();
        }

        //Move the window
        private void MainGrid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ReadCommands()
        {
            string command;
            string[] cparams = new string[0];
            string[] tmp;
            for (int i = 1; i < args.Length; i++)
            {
                tmp = args[i].Split(commandCharSeparator);
                command = tmp[0];

                if (tmp.Length > 0)
                    cparams = tmp[1].Split(paramsCharSeparator);

                ExecuteCommand(command, cparams);
            }
        }

        private void ExecuteCommand(string _command, params string[] _params)
        {
            if (string.IsNullOrEmpty(_command) || _params == null || _params.Length <= 0)
                return;

            switch (_command.ToUpper())
            {
                case "INSTALL":
                    if (!string.IsNullOrEmpty(_params[0]))
                    {
                        outputPath = _params[0];

                        createShortcut = false;
                        startWhenFinish = false;

                        if (_params.Length > 1)
                        {
                            bool.TryParse(_params[1], out createShortcut);
                        }

                        if (_params.Length > 2)
                        {
                            bool.TryParse(_params[2], out startWhenFinish);
                        }

                        InstallFinished += (_success) =>
                        {
                            if (_success)
                            {
                                CreateShortcut();
                                StartApplication();
                            }
                            else
                            {
                                System.Windows.Forms.MessageBox.Show("Error : installation failed", setupParams[APPNAME_key], MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            CloseApp();
                        };

                        ShowStep(step2);
                        Install();
                    }
                    break;

            }
        }

        private void PrepareSetup()
        {
            ZipArchive zp = new ZipArchive(setupFiles["Setup.zip"]);
            foreach (ZipArchiveEntry i in zp.Entries)
            {
                setupFiles.Add(i.Name, i.Open());
            }
            setupFiles.Remove("Setup.zip");


            setupParams = ReadXmlInfo(setupFiles[XMLINFOS_key]);
            setupFiles.Remove(XMLINFOS_key);

            baseOutput = setupParams[BASEFOLDER_key];

            //Get special folder
            if (baseOutput.Contains(specialFolderChar))
            {
                baseOutput = baseOutput.Replace(specialFolderChar, null);

                if (Enum.TryParse(baseOutput, out Environment.SpecialFolder sf))
                    baseOutput = Environment.GetFolderPath(sf);
            }

            outputPath = baseOutput + @"\" + setupParams[APPFOLDER_key];
            exeName = setupParams[EXENAME_key];

        }

        private void LoadSettings()
        {
            Img_SetupIconW.Source = Global.SetupIcon;

            if (setupParams == null)
                return;

            LB_Title.Content = "Installation de " + setupParams[APPNAME_key];
        }

        private void ShowStep(StackPanel _step)
        {
            Grid_Steps.Children.Clear();
            Grid_Steps.Children.Add(_step);
        }

        private void Install()
        {
            BT_CloseApp.IsEnabled = false;

            voidableFiles = new List<string>();

            PB_Instalation.Minimum = 0;
            PB_Instalation.Maximum = setupFiles.Count;

            InstallProgess = 0;

            success = false;
            stopInstall = false;

            threadInstall = new Thread(new ThreadStart(() =>
            {
                string tmp;

                //Install directories
                foreach (string d in dirsPaths)
                {
                    tmp = d.Replace("*", outputPath);

                    if (!Directory.Exists(tmp))
                        Directory.CreateDirectory(tmp);
                }

                //Install files
                Stream file;
                string fp;
                string shearch;

                foreach (string i in setupFiles.Keys)
                {
                    Thread.Sleep(100);

                    if (stopInstall)
                    {
                        finish(false);
                        Thread.CurrentThread.Abort();
                    }

                    if (i.Contains(fDoublonChar.ToString()))
                    {
                        string[] dInfos = i.Split(fDoublonChar);
                        shearch = dInfos[1] + @"\" + dInfos[0];
                    }
                    else
                    {
                        shearch = i;
                    }

                    fp = filesPaths.Find(x => x.Contains(shearch));

                    if (!string.IsNullOrEmpty(fp))
                        fp = fp.Replace("*", outputPath);
                    else
                        fp = outputPath + @"\" + i;

                    if (fp.Contains(fDoublonChar.ToString()))
                        fp = fp.Remove(fp.IndexOf(fDoublonChar));

                    FileInfo fi = new FileInfo(fp);
                    if (!fi.Directory.Exists)
                        fi.Directory.Create();

                    if (!fi.Exists)
                        voidableFiles.Add(fp);

                    Dispatcher.Invoke(() =>
                    {
                        LB_InstallationDetail.Content = "Installation : " + fp;
                    });

                    file = fi.Create();

                    Global.CopyStream(setupFiles[i], file);
                    file.Close();

                    Dispatcher.Invoke(() =>
                    {
                        InstallProgess += 1;
                    });

                }

                finish(true);

                void finish(bool _success)
                {
                    Dispatcher.Invoke(() =>
                    {
                        InstallationFinished(_success);
                        InstallFinished?.Invoke(_success);
                    });
                }

            }));

            threadInstall.Start();

        }

        private void InstallationFinished(bool _success)
        {
            BT_CloseApp.IsEnabled = true;
            success = _success;
            ShowStep(step_Success);

            if (!_success)
            {
                Cancel();
            }

        }

        private void Cancel()
        {
            //Delete files
            foreach (string f in voidableFiles)
            {
                if (File.Exists(f))
                    File.Delete(f);
            }

            //Delete empty directories
            DelDirsRecursively(outputPath);

            void DelDirsRecursively(string path)
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                bool hasSubdir, hasFile;

                hasSubdir = dir.GetDirectories().Length > 0;
                hasFile = dir.GetFiles().Length > 0;

                if (!hasFile && !hasSubdir)
                {
                    Directory.Delete(dir.FullName);
                    return;
                }

                if (hasSubdir)
                {
                    foreach (DirectoryInfo subsubdir in dir.GetDirectories())
                    {
                        DelDirsRecursively(subsubdir.FullName);
                    }

                    hasSubdir = dir.GetDirectories().Length > 0;
                    if (!hasSubdir)
                        Directory.Delete(dir.FullName);
                }

            }
        }

        private void BT_FinshAndClose_Click(object sender, RoutedEventArgs e)
        {
            StartApplication();
            CreateShortcut();

            CloseApp();
        }

        private void StartApplication()
        {
            if (!string.IsNullOrEmpty(exeName))
            {
                //Get .exe file path
                string exePath = outputPath + @"\" + exeName;

                //Start installed application
                if (startWhenFinish == true)
                {
                    if (File.Exists(exePath))
                        Global.RunProcess(exePath, System.Diagnostics.ProcessWindowStyle.Normal, "", false);
                }

            }
        }

        private void CreateShortcut()
        {
            if (!string.IsNullOrEmpty(exeName))
            {
                //Get .exe file path
                string exePath = outputPath + @"\" + exeName;

                //Create shortcut
                if (createShortcut == true)
                {
                    string shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + exeName + ".lnk";
                    Global.CreateShortcut(exePath, shortcutPath);
                }

            }
        }

        private void BT_Install_Click(object sender, RoutedEventArgs e)
        {
            //Step 1 to step 2
            ShowStep(step2);

            //Install
            Install();
        }

        //Cancel installation
        private void BT_Cancel_Click(object sender, RoutedEventArgs e)
        {
            stopInstall = true;

            LB_InstallationDetail.Content = "Annulation en cours...";
            ((System.Windows.Controls.Button)sender).IsEnabled = false;
        }

        private void BT_ChooseOutputDir_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                ShowNewFolderButton = true
            };

            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                outputPath = fbd.SelectedPath + @"\" + setupParams[APPFOLDER_key];
                TB_OutputDir.Text = outputPath;
            }
        }

        private void CB_Agree_Click(object sender, RoutedEventArgs e)
        {
            BT_ValidateLicence.IsEnabled = ((System.Windows.Controls.CheckBox)sender).IsChecked == true;
        }

        private void BT_ValidateLicence_Click(object sender, RoutedEventArgs e)
        {
            //Step licence to step 1
            ShowStep(step1);
        }

        private Dictionary<string, string> ReadXmlInfo(Stream xml)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            //Read xml source
            XmlDocument doc = new XmlDocument();
            doc.Load(xml);

            //Get App infos
            result.Add(APPNAME_key, doc.GetElementsByTagName(APPNAME_key)[0].InnerText);
            result.Add(VERSION_key, doc.GetElementsByTagName(VERSION_key)[0].InnerText);
            result.Add("companyName", doc.GetElementsByTagName("companyName")[0].InnerText);
            result.Add(BASEFOLDER_key, doc.GetElementsByTagName(BASEFOLDER_key)[0].InnerText);
            result.Add(APPFOLDER_key, doc.GetElementsByTagName(APPFOLDER_key)[0].InnerText);
            result.Add(ALLOWCHANGEAPPFOLDER_key, doc.GetElementsByTagName(ALLOWCHANGEAPPFOLDER_key)[0].InnerText);
            result.Add(LICENSE_key, doc.GetElementsByTagName(LICENSE_key)[0].InnerText);
            result.Add(CREATESHORTCUT_key, doc.GetElementsByTagName(CREATESHORTCUT_key)[0].InnerText);
            result.Add(EXENAME_key, doc.GetElementsByTagName(EXENAME_key)[0].InnerText);
            result.Add(STARTWHENFINISH_key, doc.GetElementsByTagName(STARTWHENFINISH_key)[0].InnerText);

            string _appImageTxt = doc.GetElementsByTagName(APPIMAGE_key)[0].InnerText;
            if (!string.IsNullOrEmpty(_appImageTxt))
                Global.AppImage = Global.XmlToImageSource(_appImageTxt);
            else
                Global.AppImage = Global.BitmapToImageSource(Properties.Resources.SetupCreator_logo_PNG);

            //Get files paths
            filesPaths = new List<string>();
            XmlNodeList filesList = doc.GetElementsByTagName("File");

            for (int i = 0; i < filesList.Count; i++)
            {
                filesPaths.Add(filesList[i].InnerText);
            }

            //Get empty directories
            dirsPaths = new List<string>();
            XmlNodeList dirsList = doc.GetElementsByTagName("Directory");

            for (int i = 0; i < dirsList.Count; i++)
            {
                dirsPaths.Add(dirsList[i].InnerText);
            }

            //Get ads
            XmlNodeList xmlAdsList = doc.GetElementsByTagName("Ad");
            ads = new List<Ad>();
            for (int i = 0; i < xmlAdsList.Count; i++)
            {
                string img = xmlAdsList[i].ChildNodes[0].InnerText;
                string description = xmlAdsList[i].ChildNodes[1].InnerText;
                string urlTitle = xmlAdsList[i].ChildNodes[2].InnerText;
                string url = xmlAdsList[i].ChildNodes[3].InnerText;

                ads.Add(new Ad(img, description, urlTitle, url));
            }

            return result;
        }

        #region Initialition of controls

        private void TB_OutputDir_Loaded(object sender, RoutedEventArgs e)
        {
            TB_OutputDir = (System.Windows.Controls.TextBox)sender;
            TB_OutputDir.Text = outputPath;
        }

        private void BT_ChooseOutputDir_Loaded(object sender, RoutedEventArgs e)
        {
            BT_ChooseOutputDir = (System.Windows.Controls.Button)sender;

            BT_ChooseOutputDir.IsEnabled = bool.Parse(setupParams[ALLOWCHANGEAPPFOLDER_key]);
        }

        private void PB_Installation_Initialized(object sender, EventArgs e)
        {
            PB_Instalation = (System.Windows.Controls.ProgressBar)sender;
        }


        private void LB_InstallationDetail_Initialized(object sender, EventArgs e)
        {
            LB_InstallationDetail = (System.Windows.Controls.Label)sender;
        }

        private void IMG_LargeIcon_Loaded(object sender, RoutedEventArgs e)
        {
            IMG_LargeIcon = (Image)sender;
            IMG_LargeIcon.Source = Global.AppImage;
        }

        private void LB_SetupName_Loaded(object sender, RoutedEventArgs e)
        {
            LB_SetupName = (System.Windows.Controls.Label)sender;
            LB_SetupName.Content = setupParams[APPNAME_key] + " version " + setupParams[VERSION_key];
        }

        private void BT_ValidateLicence_Loaded(object sender, RoutedEventArgs e)
        {
            BT_ValidateLicence = (System.Windows.Controls.Button)sender;
        }

        private void TB_Licence_Loaded(object sender, RoutedEventArgs e)
        {
            ((TextBlock)sender).Text = setupParams[LICENSE_key];
        }

        private void LB_Statut_Loaded(object sender, RoutedEventArgs e)
        {
            LB_Statut = (System.Windows.Controls.Label)sender;

            if (!success)
                LB_Statut.Content = "Echec de l'installation !";
        }

        private void CB_StartApp_Loaded(object sender, RoutedEventArgs e)
        {
            CB_StartApp = (System.Windows.Controls.CheckBox)sender;

            if (string.IsNullOrEmpty(exeName) || !success || setupParams[STARTWHENFINISH_key] == "false")
            {
                CB_StartApp.IsChecked = false;
                startWhenFinish = false;
                CB_StartApp.Visibility = Visibility.Collapsed;
            }
            else
            {
                CB_StartApp.IsChecked = true;
                startWhenFinish = true;
            }
        }

        private void CB_CreateShortcut_Loaded(object sender, RoutedEventArgs e)
        {
            CB_CreateShortcut = (System.Windows.Controls.CheckBox)sender;

            if (string.IsNullOrEmpty(exeName) || !bool.Parse(setupParams[CREATESHORTCUT_key]) || !success)
            {
                CB_CreateShortcut.IsChecked = false;
                createShortcut = false;
                CB_CreateShortcut.Visibility = Visibility.Collapsed;
            }
            else
            {
                CB_CreateShortcut.IsChecked = true;
                createShortcut = true;
            }
        }

        private void Grid_Ads_Loaded(object sender, RoutedEventArgs e)
        {
            Grid g = (Grid)sender;
            g.Children.Clear();

            if (ads.Count > 0)
                g.Children.Add(new AdsViewer(ads));
        }


        #endregion

        private void CB_StartApp_Click(object sender, RoutedEventArgs e)
        {
            startWhenFinish = CB_StartApp.IsChecked == true;
        }

        private void CB_CreateShortcut_Click(object sender, RoutedEventArgs e)
        {
            createShortcut = CB_CreateShortcut.IsChecked == true;
        }
    }
}
