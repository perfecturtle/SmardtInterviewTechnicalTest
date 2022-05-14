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
using DataVis = System.Windows.Forms.DataVisualization;
namespace SmardtInterviewTechnicalTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TrendChartTemperature.Series[0].Points.Add(3.0).AxisLabel = "Time";
            TrendChartTemperature.Series[0].Points.AddXY(150, 150);
            TrendChartTemperature.Series[0].BorderWidth = 4;
            TemperatureChartArea.AxisY.Title = "Temperature";


        }
    }
}
