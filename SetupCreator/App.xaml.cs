using System;
using System.Windows;
using MyFunctions;

namespace SetupCreator
{
    public partial class App : Application
    {
        //Variables
        private const string featureLink = "https://admansoftware.wordpress.com/2019/03/05/setupcreator-fonctionnalite-a-venir/";
        internal static WPF_ADMANMenu admanMenu;

        //When application is starting...
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            admanMenu = new WPF_ADMANMenu(featureLink);

            //Check if there is an update available
            UpdateManager.CheckUpdate();

            AssociateIcon();
        }

        //Associate setup files with an icon
        private void AssociateIcon()
        {
            if (!ExtensionAssociation.IsAssociated(Global.setupExtension))
            {
                string iconPath = System.Windows.Forms.Application.StartupPath
                    + @"\Resources\Images\Icon\Save logo ICO.ico";

                ExtensionAssociation.Associate(Global.setupExtension, "SetupCreator"+ Global.setupExtension,
                    "SetupCreator save icon", iconPath, System.Windows.Forms.Application.ExecutablePath);
            }
        }

        

    }
}
