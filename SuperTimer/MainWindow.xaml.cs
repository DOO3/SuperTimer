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

namespace SuperTimer
{
    public partial class MainWindow : Window
    {
        Dictionary<string, Color> Colors = new Dictionary<string, Color>
        {
            { "Black", new Color {R = 0, G = 0, B = 0 } },
            { "Red", new Color {R = 255, G = 0, B = 0 } },
            { "Green", new Color {R = 0, G = 255, B = 0 } },
            { "Blue", new Color {R = 0, G = 0, B = 255 } }
        };

        public MainWindow()
        {
            InitializeComponent();
            cbFrom.ItemsSource = cbTo.ItemsSource = Colors.Keys;
        }

        private void bStart_Click(object sender, RoutedEventArgs e)
        {
            AddTimer();
        }

        private void AddTimer()
        {
            wpTimes.Children.Add(new Timer(
                new TimeSpan(int.Parse(tbHour.Text), int.Parse(tbMinut.Text), int.Parse(tbSecond.Text)), 
                tbName.Text,
                Colors[cbFrom.SelectedItem.ToString()],
                Colors[cbTo.SelectedItem.ToString()]
                ));
        }
    }
}
