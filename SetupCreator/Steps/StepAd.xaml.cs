using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;

namespace SetupCreator
{
    public partial class StepAd : UserControl, IStep
    {
        //Variables
        private List<AdEditorViewer> adsList;

        //Construuctor
        public StepAd()
        {
            InitializeComponent();

            adsList = new List<AdEditorViewer>();

            AddAd(new Ad());
        }

        private void AddAd(Ad ad)
        {
            AdEditorViewer aev = new AdEditorViewer(this, ad);
            this.SP_Ads.Children.Add(aev);
            adsList.Add(aev);

        }

        public void RemoveAd(AdEditorViewer editor)
        {
            if (this.SP_Ads.Children.Contains(editor))
                this.SP_Ads.Children.Remove(editor);

            if (adsList.Contains(editor))
                adsList.Remove(editor);
        }

        private void BT_AddAd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            AddAd(new Ad());
        }

        public bool Validate()
        {
            MainWindow.CurrentSetup.adsList = new List<Ad>();

            foreach (AdEditorViewer a in adsList)
            {
                if (!string.IsNullOrEmpty(a.ImagePath))
                {
                    if (!File.Exists(a.ImagePath))
                    {
                        System.Windows.Forms.MessageBox.Show(
                            "This image was not found :" + Environment.NewLine + a.ImagePath,
                            "Setup - Creator", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                        return false;
                    }

                    MainWindow.CurrentSetup.adsList.Add(new Ad(a.ImagePath, a.Description, a.UrlTitle, a.Url));
                }
            }

            return true;
        }

        public void Update()
        {
            this.SP_Ads.Children.Clear();
            adsList = new List<AdEditorViewer>();

            foreach (Ad ad in MainWindow.CurrentSetup.adsList)
            {
                AddAd(ad);
            }
        }
    }
}
