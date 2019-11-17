using System;
using System.Collections.Generic;
using System.IO;

namespace SetupCreator
{
    [Serializable]
    public class Setup
    {
        //Variables
        private string name;
        private string version;
        private string companyName;

        private string baseFolder;
        private string appFolderName;
        private bool allowChangeBaseFolder;

        private string executable;
        private string[] appFilesPath;
        private string[] setupFilesPaths;
        private string[] directoriesPaths;

        private bool createDesktopShortcut;
        private string buildPath;
        private string buildName;
        private string license;
        private string iconSource;
        private string appImage;
        private bool startWhenFinish;

        private string[] foldersInBase;
        private string[] filesInBase;

        public List<Ad> adsList;

        //Properties
        public string Name { get => name; set => name = value; }
        public string Version { get => version; set => version = value; }
        public string Publisher { get => companyName; set => companyName = value; }

        public string BaseFolder { get => baseFolder; set => baseFolder = value; }
        public string AppFolderName { get => appFolderName; set => appFolderName = value; }
        public bool AllowChangeBaseFolder { get => allowChangeBaseFolder; set => allowChangeBaseFolder = value; }

        public string Executable { get => executable; set => executable = value; }
        public string[] AppFilesPath { get => appFilesPath; set => appFilesPath = value; }
        public string[] FDoublonsPath { get; set; }
        public string[] SetupFilesPaths { get => setupFilesPaths; set => setupFilesPaths = value; }
        public string[] DirectoriesPaths { get => directoriesPaths; set => directoriesPaths = value; }

        public bool CreateDesktopShortcut { get => createDesktopShortcut; set => createDesktopShortcut = value; }
        public string BuildPath { get => buildPath; set => buildPath = value; }
        public string BuildName { get => buildName; set => buildName = value; }
        public string License { get => license; set => license = value; }
        public string IconSource { get => iconSource; set => iconSource = value; }
        public string AppImage { get => appImage; set => appImage = value; }
        public bool StartWhenFinish { get => startWhenFinish; set => startWhenFinish = value; }

        public string[] FoldersInBase { get => foldersInBase; set => foldersInBase = value; }
        public string[] FilesInBase { get => filesInBase; set => filesInBase = value; }

        //Constructors
        public Setup()
        {
            adsList = new List<Ad>();
        }

    }
}
