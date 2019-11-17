using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
using MyFunctions;
using System.Threading;
using System.ComponentModel;

namespace SetupCreator
{
    public partial class MainWindow : Window
    {
        //Formatting variables
        private const char fDoublonChar = '@';

        //Steps variables
        private UserControl[] steps =
        {
            new StepAppInfos(),
            new StepAppFolder(),
            new StepAppFiles(),
            new StepAd(),
            new Step_SetupConfig()
        };
        private int stepIndex;
        private bool allowGenerate;

        //Variables
        public static bool editMode = false; // true = edit existing setup  ;  false = create new setup
        private string setupSaveFile;
        private string executableSetupFile;
        private bool generateResult;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.SaveFileDialog sfd;
        private MyFunctions.ControlsWPF.CircleProgress circleProgress = new MyFunctions.ControlsWPF.CircleProgress()
        {
            Mode = MyFunctions.ControlsWPF.ProgressMode.Loading,
            ShowProgress = true
        };

        //Properties
        public static MainWindow Instance { get; private set; }
        public static Setup CurrentSetup { get; set; }

        //Constructor
        public MainWindow()
        {
            InitializeComponent();

            Instance = this;
            CurrentSetup = new Setup();

            ShowStep(stepIndex = 0);
            allowGenerate = false;

            ofd = new System.Windows.Forms.OpenFileDialog()
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "SetupCreator|*" + Global.setupExtension
            };

            sfd = new System.Windows.Forms.SaveFileDialog()
            {
                AddExtension = true,
                CheckPathExists = true,
                Filter = "SetupCreator|*" + Global.setupExtension
            };

        }

        //Close the application
        private void BT_CloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //Move the window
        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        //Change step
        private void ShowStep(int _step)
        {
            this.GridSteps.Children.Clear();
            this.GridSteps.Children.Add(steps[_step]);
        }

        //Show the next step
        public void NextStep()
        {
            if (stepIndex + 1 >= steps.Length)
                return;

            ShowStep(++stepIndex);

            if (stepIndex + 1 >= steps.Length)
            {
                this.BT_NextStep.Content = "Générer";
                allowGenerate = true;
            }
        }

        //Show the previous step
        public void PreviousStep()
        {
            if (stepIndex <= 0)
                return;

            allowGenerate = false;
            this.BT_NextStep.Content = "Suivant";
            ShowStep(--stepIndex);
        }

        //Show the next step or generate setup
        private void BT_NextStep_Click(object sender, RoutedEventArgs e)
        {
            IStep step = (IStep)steps[stepIndex];

            //If the current step is correctly filled...
            if (step.Validate())
            {
                if (allowGenerate)
                {//Generate
                    this.Grid_ButtonsSteps.Visibility = Visibility.Hidden;
                    this.GridSteps.Children.Clear();
                    this.GridSteps.Children.Add(circleProgress);

                    BackgroundWorker threadGenerate = new BackgroundWorker();
                    threadGenerate.DoWork += (o, a) => GenerateSetup();
                    threadGenerate.RunWorkerCompleted += (o, a) => OnGenerated(generateResult);

                    threadGenerate.RunWorkerAsync();
                }
                else
                {//Next step
                    NextStep();
                }
            }
        }

        //Show previous step
        private void BT_PreviousStep_Click(object sender, RoutedEventArgs e)
        {
            PreviousStep();
        }

        //Generate the setup
        private void GenerateSetup()
        {
            if (CurrentSetup == null)
                return;

            string startupPath = System.Windows.Forms.Application.StartupPath;
            string scriptPath = startupPath + @"\Resources\GeneratedSetup_Program.cs";
            string code = File.ReadAllText(scriptPath, System.Text.Encoding.UTF8);

            string dllsResDir = System.Windows.Forms.Application.StartupPath + @"\Resources\dlls";
            string destZip = "";
            string icoPath = "";


            CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");
            CompilerParameters cp = new CompilerParameters();
            // Generate an executable instead of 
            // a class library.
            cp.GenerateExecutable = true;

            //Generate file app info
            string paramsName = "SetupGeneratorInfos.xml";
            string paramsPath = Environment.GetEnvironmentVariable("TMP") + @"\" + paramsName;
            GenrarteXmlInfos().Save(paramsPath);

            // Set the assembly file name to generate.
            executableSetupFile = CurrentSetup.BuildPath + @"\" + CurrentSetup.BuildName + ".exe";
            cp.OutputAssembly = executableSetupFile;
            
            // Generate debug information.
            cp.IncludeDebugInformation = false;


            // Add embeded resources (app files)

            string tmpDir = Environment.GetEnvironmentVariable("TMP") + @"\SetupCreator\";
            Directory.CreateDirectory(tmpDir);
            FileInfo fi;
            string tempFile;

            foreach (string f in CurrentSetup.AppFilesPath)
            {
                fi = new FileInfo(f);
                if (fi.Exists)
                    File.Copy(f, tmpDir + fi.Name, true);
                else
                {
                    DeleteTmpFiles();
                    System.Windows.Forms.MessageBox.Show("This file was not found : " + Environment.NewLine + f);
                    return;
                }
            }

            foreach (string f in CurrentSetup.FDoublonsPath)
            {
                fi = new FileInfo(f);

                tempFile = tmpDir + fi.Name + fDoublonChar + fi.Directory.Name;
                File.Copy(f, tempFile, true);
            }

            File.Copy(paramsPath, tmpDir + paramsName, true);

            destZip = Environment.GetEnvironmentVariable("TMP") + @"\Setup.zip";

            if (File.Exists(destZip))
                File.Delete(destZip);

            MyFunctions.FileManager.ZipDirectory(tmpDir, destZip);

            cp.EmbeddedResources.Add(destZip);
            
         // Add an assembly reference.
            cp.ReferencedAssemblies.Add("System.dll");
            cp.ReferencedAssemblies.Add("System.Drawing.dll");
            cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
            cp.ReferencedAssemblies.Add("System.Linq.dll");
            cp.ReferencedAssemblies.Add(dllsResDir + @"\System.IO.Compression.FileSystem.dll");
            cp.ReferencedAssemblies.Add(dllsResDir + @"\System.IO.Compression.dll");
            cp.EmbeddedResources.Add(dllsResDir + @"\GeneratedSetup.dll");
            cp.ReferencedAssemblies.Add(dllsResDir + @"\System.Xaml.dll");
            cp.ReferencedAssemblies.Add(dllsResDir + @"\WindowsBase.dll");
            cp.ReferencedAssemblies.Add(dllsResDir + @"\PresentationCore.dll");
            cp.ReferencedAssemblies.Add(dllsResDir + @"\PresentationFramework.dll");

            // Save the assembly as a physical file.
            cp.GenerateInMemory = false;

            // Set the level at which the compiler 
            // should start displaying warnings.
            cp.WarningLevel = 3;

            // Set whether to treat all warnings as errors.
            cp.TreatWarningsAsErrors = false;

            // Set compiler argument to optimize output.
            cp.CompilerOptions = "/optimize";
            cp.CompilerOptions += " /win32manifest:" + "\"" + System.Windows.Forms.Application.StartupPath 
                                                          + @"\app.manifest" + "\""; //Add manifest

            // Set setup icon if it exists
            icoPath = Environment.GetEnvironmentVariable("TMP") + @"\SetupIcon.ico";

            if (!string.IsNullOrEmpty(CurrentSetup.IconSource))
            {//Set a custom icon to the setup

                //Determine if the icon file exists...
                if (File.Exists(CurrentSetup.IconSource))
                    cp.CompilerOptions += @" /win32icon:" + "\"" + CurrentSetup.IconSource + "\"";
                else
                    throw new Exception("Le fichier suivant est introuvable : " + CurrentSetup.IconSource);
            }
            else
            {//Set default icon to the setup
                FileStream fs = new FileStream(icoPath, FileMode.Create);
                Properties.Resources.DefaultSetupIcon.Save(fs);
                fs.Close();

                cp.CompilerOptions += @" /win32icon:" + "\"" + icoPath + "\"";
            }

            // Set a temporary files collection.
            // The TempFileCollection stores the temporary files
            // generated during a build in the current directory,
            // and does not delete them after compilation.
            cp.TempFiles = new TempFileCollection(Environment.GetEnvironmentVariable("TMP"), false);

            if (provider.Supports(GeneratorSupport.EntryPointMethod))
            {
                // Specify the class that contains 
                // the main method of the executable.
                cp.MainClass = "GeneratedSetupL.Program";
            }

            // Invoke compilation.
            CompilerResults cr = provider.CompileAssemblyFromSource(cp, code);
           
            if (cr.Errors.Count > 0)
            {//Error
                // Display compilation errors.
                string log = "Errors building " + code+ "into " + cr.PathToAssembly + Environment.NewLine;
                foreach (CompilerError ce in cr.Errors)
                {
                    log += Environment.NewLine;
                    log = ce.ToString();
                }

                string logPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Log.txt";
                File.WriteAllText(logPath, log);

                ProcessManager.RunPowerShellCommand("start \""+logPath+"\"", false);
                generateResult = false;
            }
            else
            {//Success
                generateResult = true;
            }

            DeleteTmpFiles();

            void DeleteTmpFiles()
            {
                if (Directory.Exists(tmpDir))
                    Directory.Delete(tmpDir, true);

                if (File.Exists(destZip))
                    File.Delete(destZip);

                if (File.Exists(paramsPath))
                    File.Delete(paramsPath);

                if (File.Exists(icoPath))
                    File.Delete(icoPath);
            }

        }

        private void OnGenerated(bool success)
        {
            ShowStep(stepIndex);
            this.Grid_ButtonsSteps.Visibility = Visibility.Visible;

            if (success)
                GenerateSuccess();
        }

        private void GenerateSuccess()
        {
            System.Windows.Forms.MessageBox.Show("Génération du setup terminée.", "SetupCreator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            AskToSave();

            this.MI_SetupOptions.Header = CurrentSetup.Name;
            this.MI_SetupOptions.Visibility = Visibility.Visible;
        }

        //Ask the user if he want to save
        private void AskToSave()
        {
            string msg = "Voulez vous sauvegarder ce setup ?";
            if (System.Windows.Forms.MessageBox.Show(msg, "SetupGenerator", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question)
                == System.Windows.Forms.DialogResult.Yes)
            {
                BT_SaveSetup_Click(null, null);
            }
        }

        //Generate XML object that coontains informations about the setup
        private XElement GenrarteXmlInfos()
        {
            string license = "";
            if (!string.IsNullOrEmpty(CurrentSetup.License))
            {
                if (!File.Exists(CurrentSetup.License))
                    throw new FileNotFoundException("File not found : " + Environment.NewLine + CurrentSetup.License);

                license = File.ReadAllText(CurrentSetup.License, System.Text.Encoding.UTF8);
            }

            XElement root = new XElement("Setup");

            //Add app infos
            root.Add
                (
                    new XElement("name", CurrentSetup.Name),
                    new XElement("version", CurrentSetup.Version),
                    new XElement("companyName", CurrentSetup.Publisher),
                    new XElement("baseFolder", CurrentSetup.BaseFolder),
                    new XElement("appFolderName", CurrentSetup.AppFolderName),
                    new XElement("allowChangeBaseFolder", CurrentSetup.AllowChangeBaseFolder),
                    new XElement("license", license),
                    new XElement("createDesktopShortcut", CurrentSetup.CreateDesktopShortcut),
                    new XElement("exeName", 
                    !string.IsNullOrEmpty(CurrentSetup.Executable) ?
                        CurrentSetup.Executable.SplitAndGetLastPart(@"\") : ""),

                    new XElement("appImage", 
                    File.Exists(CurrentSetup.AppImage) ? Global.ImgToString(CurrentSetup.AppImage) : ""),

                    new XElement("startWhenFinish", CurrentSetup.StartWhenFinish)
                );

            //Add files paths
            XElement filesElement = new XElement("Files");
            root.Add(filesElement);
            foreach (string fp in CurrentSetup.SetupFilesPaths)
            {
                filesElement.Add(new XElement("File", fp));
            }

            //Add direcories
            XElement dirsElement = new XElement("Directories");
            root.Add(dirsElement);
            foreach (string d in CurrentSetup.DirectoriesPaths)
            {
                dirsElement.Add(new XElement("Directory", d));
            }

            //Include ads
            XElement adsElement = new XElement("AdsList");
            root.Add(adsElement);
            foreach (Ad ad in CurrentSetup.adsList)
            {
                if (File.Exists(ad.image))
                {
                    XElement adElement = new XElement("Ad",
                        new XElement("image", Global.ImgToString(ad.image)),
                        new XElement("description", ad.description),
                        new XElement("urlTitle", ad.urlTitle),
                        new XElement("url", ad.url)
                    );

                    adsElement.Add(adElement);
                }
            }

            //root.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SetupInfos.xml");
            return root;
        }

        #region Menu

        private void BT_OpenSetup_Click(object sender, RoutedEventArgs e)
        {
            OpenSetup();
        }

        private void BT_SaveSetup_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(setupSaveFile))
                SaveSetup(setupSaveFile);
            else
                SaveSetupAs();

        }

        private void BT_SaveAs(object sender, RoutedEventArgs e)
        {
            SaveSetupAs();
        }

        #endregion

        //Save the setup
        private void SaveSetup(string _path)
        {
            IStep step = (IStep)steps[stepIndex];
            step.Validate();

            FileManager.Serialize(_path, CurrentSetup);
            setupSaveFile = _path;
        }

        //Save as...
        private void SaveSetupAs()
        {
            if(sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SaveSetup(sfd.FileName);
            }
        }

        //Open a setup file (save)
        public void OpenSetup(string _path)
        {
            CurrentSetup = FileManager.Deserialize<Setup>(_path);
            setupSaveFile = _path;

            if (!this.IsActive)
            {
                this.Show();
            }

            foreach (dynamic s in steps)
            {
                s.Update();
            }

        }

        public bool OpenSetup()
        {
            if(ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                OpenSetup(ofd.FileName);
                return true;
            }

            return false;
        }

        //Create new setup
        private void BT_NewSetup_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        //Execute the generated setup
        private void MI_ExecuteSetup_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(executableSetupFile))
                ProcessManager.RunProcess(executableSetupFile, System.Diagnostics.ProcessWindowStyle.Normal, null, false, true);
        }

        //Open the directory of the setup in the explorer
        private void MI_OpenDirectory_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists(executableSetupFile))
            {
                FileInfo fi = new FileInfo(executableSetupFile);
                ProcessManager.RunPowerShellCommand("Start \"" + fi.Directory.FullName + "\"");
            }
        }

        //Show ADMAN Software-FR menu
        private void BT_ADMANSoftware_Click(object sender, RoutedEventArgs e)
        {
            App.admanMenu.ShowMenu();
        }

    }
}
