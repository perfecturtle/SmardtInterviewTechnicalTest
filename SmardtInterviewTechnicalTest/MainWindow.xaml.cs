using SmardtInterviewTechnicalTest.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
        public MainWindowViewModel MainWindowViewModel => DataContext as MainWindowViewModel;

        public MainWindow()
        {

            InitializeComponent();
            //TrendChartTemperature.Series[0].Points.AddXY(DateTime.Now.Minute, 100);

            //TrendChartTemperature.Series[0].Points.AddXY(DateTime.Now.AddMinutes(10).Minute, 150);
            TrendChartTemperature.Series[0].BorderWidth = 4;
            TrendChartTemperature.Series[1].BorderWidth = 4;
            TemperatureChartArea.AxisY.Title = "Temperature";
            TemperatureChartArea.AxisX.Title = "Time (Min)";
        }

        private void UpdateChart_Click(object sender, RoutedEventArgs e)
        {
            TrendChartTemperature.Series[0].Points.AddXY(DateTime.Now, MainWindowViewModel.InputTemperature != null ? MainWindowViewModel.InputTemperature : 0);
            TrendChartTemperature.Series[1].Points.AddXY(DateTime.Now, MainWindowViewModel.TemperatureSetpoint);
        }
    }
}