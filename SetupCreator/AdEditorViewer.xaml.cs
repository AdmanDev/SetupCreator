using System;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Controls;

namespace SetupCreator
{
    public partial class AdEditorViewer : System.Windows.Controls.UserControl
    {
        //Variables
        private StepAd stepAd;
        private OpenFileDialog ofd;

        //Properties
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string UrlTitle { get; set; }
        public string Url { get; set; }

        //Constructors
        private void CommonConstructor(StepAd _stepAd)
        {
            this.DataContext = this;
            InitializeComponent();

            stepAd = _stepAd;

            ofd = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "PNG|*.png|JPG|*.jpg"
            };
        }

        public AdEditorViewer(StepAd _stepAd, Ad loadAd)
        {
            CommonConstructor(_stepAd);

            this.TB_Description.Text = loadAd.description;
            this.TB_ImagePath.Text = loadAd.image;
            this.TB_Url.Text = loadAd.url;
            this.TB_UrlTitle.Text = loadAd.urlTitle;
        }

        private void BT_ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.TB_ImagePath.Text = ofd.FileName;
            }
        }

        private void BT_Delete_Click(object sender, RoutedEventArgs e)
        {
            stepAd.RemoveAd(this);
        }
    }
}
