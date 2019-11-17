using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using SetupCreator;

namespace GeneratedSetup
{
    public partial class AdsViewer : UserControl
    {
        //Variables
        private readonly List<Ad> ads;
        private List<RadioButton> adRadioButtons;
        private Ad currentAd;
        private int adIndex;

        private System.Windows.Forms.Timer nextAd_Timer;
        private int intervalBetweenAd = 10000;

        private Storyboard adClose_Anim;
        private Storyboard adOpen_Anim;

        //Properties
        private int AdIndex
        {
            get => adIndex;
            set
            {
                if (value < 0 || value >= ads.Count)
                {
                    value = 0;
                }

                adIndex = value;
                ShowAd();
            }
        }

        //Constructors
        public AdsViewer(IEnumerable<Ad> _adsList)
        {
            InitializeComponent();

            ads = new List<Ad>(_adsList);
            adRadioButtons = new List<RadioButton>();

            adClose_Anim = (Storyboard)this.FindResource("CloseAd");
            adOpen_Anim = (Storyboard)this.FindResource("OpenAd");

            nextAd_Timer = new System.Windows.Forms.Timer() { Interval = intervalBetweenAd };
            nextAd_Timer.Tick += NextAd_Timer_Tick;
        }

        //Load
        private void OnLoad(object sender, System.Windows.RoutedEventArgs e)
        {
            Load();
            nextAd_Timer.Start();
        }

        private void Load()
        {
            this.WP_AdIndexs.Children.Clear();
            adRadioButtons.Clear();
            RadioButton rb;
            for (int i = 0; i < ads.Count; i++)
            {
                rb = new RadioButton();
                rb.Tag = i;
                rb.Click += RB_Index_Checked;

                this.WP_AdIndexs.Children.Add(rb);
                adRadioButtons.Add(rb);
            }

            adRadioButtons[0].IsChecked = true;
        }

        //Triggered whenever a radio button is checked
        private void RB_Index_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
             nextAd_Timer.Stop();

            RadioButton rb = (RadioButton)sender;
            AdIndex = (int)rb.Tag;

            nextAd_Timer.Start();
        }

        private void ShowAd()
        {
            adClose_Anim.Begin(this.stackPanel, true);

        }

        //ShowAd (suite)
        private void CloseAdStoryboard_Completed(object sender, EventArgs e)
        {
            currentAd = ads[AdIndex];

            adRadioButtons[AdIndex].IsChecked = true;

            this.IMG_Drawing.Source = Global.XmlToImageSource(currentAd.image);
            this.LB_DrawingInfos.Text = currentAd.description;

            if (!Uri.IsWellFormedUriString(currentAd.url, UriKind.Absolute))
            {
                this.BT_OpenUrl.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                this.BT_OpenUrl.Visibility = System.Windows.Visibility.Visible;

                if (!string.IsNullOrEmpty(currentAd.urlTitle))
                    this.BT_OpenUrl.Content = currentAd.urlTitle;
                else
                    this.BT_OpenUrl.Content = "En savoir plus";
            }

            adOpen_Anim.Begin(this.stackPanel);
        }

        private void NextAd_Timer_Tick(object sender, EventArgs e)
        {
            AdIndex++;
        }

        private void BT_OpenUrl_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(currentAd.url);
        }

    }
}
