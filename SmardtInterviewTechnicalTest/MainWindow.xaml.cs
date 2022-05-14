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
            TemperatureChartArea.AxisY.Title = "Temperature";
            TemperatureChartArea.AxisX.Title = "Time (Min)";
        }

        private void UpdateChart_Click(object sender, RoutedEventArgs e)
        {
            DateTime CurrentTime = DateTime.Now;
            int AddInputTemp = MainWindowViewModel.InputTemperature != null ? (int)MainWindowViewModel.InputTemperature : 0;
            int AddSetPointTemp = MainWindowViewModel.TemperatureSetpoint;
            .Add(new ChartPoint() { YTemperature = AddInputTemp, XTime = CurrentTime });
            SetPointTempDataPoints.Add(new ChartPoint() { YTemperature = AddSetPointTemp, XTime = CurrentTime });
            TrendChartTemperature.Series[0].Points.AddXY(CurrentTime, AddInputTemp);
            TrendChartTemperature.Series[1].Points.AddXY(CurrentTime, AddSetPointTemp);
            NumberOfPoints.Maximum = TrendChartTemperature.Series[0].Points.Count();
            //TrendChartTemperature.Series[1].Points.Remove(TrendChartTemperature.Series[0].Points[0]);
        }
        private List<ChartPoint> InputTempDataPoints = new List<ChartPoint>();
        private List<ChartPoint> SetPointTempDataPoints = new List<ChartPoint>();
        public class ChartPoint
        {
            public int YTemperature { get; set; }
            public DateTime XTime { get; set; }
        }
    }
}