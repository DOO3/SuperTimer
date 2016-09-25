using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SuperTimer
{
    public partial class Timer : UserControl
    {
        DispatcherTimer timer = new DispatcherTimer();
        TimeSpan hms = new TimeSpan();
        public Color From { get; set; }
        public Color To { get; set; }

        public Timer(TimeSpan ts, string name, Color from, Color to)
        {
            InitializeComponent();


            lName.Content = name;
            hms = ts;
            From = from;
            To = to;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            lTimer.Content = hms.ToString();

            if (hms.Equals(TimeSpan.FromTicks(0)))
            {
                MessageBox.Show($"Timer {lName.Content} ends!", "End", MessageBoxButton.OK, MessageBoxImage.Information);
                timer.Stop();                
            }

            hms -= TimeSpan.FromSeconds(1);
        }

        
    }
}
