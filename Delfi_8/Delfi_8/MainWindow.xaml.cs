using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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

namespace Delfi_8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public SeriesCollection SeriesCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Values = null,
                    PointGeometrySize = 0,
                    StrokeThickness = 4,
                    Fill = Brushes.Transparent
                }
            };

            DataContext = this;
        }

        private void _button_Click(object sender, RoutedEventArgs e)
        {
            double x = 0;
            double step = 0;
            double count = 0;
            
            try
            {
                x = Convert.ToDouble(_x.Text.Replace(",", "."));
                step = Convert.ToDouble(_step.Text.Replace(",", "."));
                count = Convert.ToInt32(_count.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ChartValues<ObservableValue> _values = new ChartValues<ObservableValue>();
            int k = 0;
            for (double i = 0; i < count; i ++)
            {
                string xTemp = Math.Round(x, 1).ToString();
                if (xTemp.Contains('.'))
                {
                    int temp = x.ToString().IndexOf('.');
                    k = Convert.ToInt32(xTemp.Substring(temp + 1));
                }
                else
                {
                    k = 0;
                }
                _values.Add(new ObservableValue(k));
                x += step;
            }

            foreach (var series in SeriesCollection)
            {
                series.Values = _values;
            }


        }
    }
}
