using System.Windows.Controls;

namespace SetupCreator
{
    public partial class StepAppInfos : UserControl, IStep
    {
        //Constructor
        public StepAppInfos()
        {
            InitializeComponent();
        }

        public bool Validate()
        {
            if (string.IsNullOrEmpty(this.TB_AppName.Text))
                return false;

            MainWindow.CurrentSetup.Name = this.TB_AppName.Text;
            MainWindow.CurrentSetup.Version = this.TB_AppVersion.Text;
            MainWindow.CurrentSetup.Publisher = this.TB_CompanyName.Text;

            return true;
        }

        public void Update()
        {
            this.TB_AppName.Text = MainWindow.CurrentSetup.Name;
            this.TB_AppVersion.Text = MainWindow.CurrentSetup.Version;
            this.TB_CompanyName.Text = MainWindow.CurrentSetup.Publisher;

        }
    }
}
