using System.Windows;

namespace GeneratedSetup
{

    public partial class ProgressWindow : Window
    {
        public ProgressWindow(string title, int min = 0, int max = 100)
        {
            InitializeComponent();

            this.PB.Minimum = min;
            this.PB.Maximum = max;
            this.PB.Value = min;
        }

        public void Progress(int incr = 1)
        {
            if (incr < 1)
                return;

            if (this.PB.Value < this.PB.Maximum)
                this.PB.Value += incr;
        }

        private void PB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(e.NewValue >= this.PB.Maximum)
            {
                this.Close();
            }
        }
    }
}
