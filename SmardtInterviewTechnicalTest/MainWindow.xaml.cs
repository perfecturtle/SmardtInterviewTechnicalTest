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
            TemperatureChartArea.AxisX.Title = "Time";
        }

        private void UpdateChart_Click(object sender, RoutedEventArgs e)
        {
            //this segment keeps track of the data required to make the chart and updates the chart
            DateTime CurrentTime = DateTime.Now;
            int AddInputTemp = MainWindowViewModel.InputTemperature != null ? (int)MainWindowViewModel.InputTemperature : 0;
            int AddSetPointTemp = MainWindowViewModel.TemperatureSetpoint;
            InputTempDataPoints.Add(new ChartPoint() { YTemperature = AddInputTemp, XTime = CurrentTime });
            SetPointTempDataPoints.Add(new ChartPoint() { YTemperature = AddSetPointTemp, XTime = CurrentTime });
            TrendChartTemperature.Series[0].Points.AddXY(CurrentTime, AddInputTemp);
            TrendChartTemperature.Series[1].Points.AddXY(CurrentTime, AddSetPointTemp);
            NumberOfPoints.Maximum = InputTempDataPoints.Count();
        }
        private List<ChartPoint> InputTempDataPoints = new List<ChartPoint>();
        private List<ChartPoint> SetPointTempDataPoints = new List<ChartPoint>();
        public class ChartPoint
        {
            public int YTemperature { get; set; }
            public DateTime XTime { get; set; }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //remove all chart points
            if (TrendChartTemperature.Series[0].Points.Count() > NumberOfPoints.Maximum - NumberOfPoints.Value)
            {
                for (int i = 0; i < TrendChartTemperature.Series[0].Points.Count() - (NumberOfPoints.Maximum - NumberOfPoints.Value); i++)
                {
                    TrendChartTemperature.Series[0].Points.RemoveAt(0);
                    TrendChartTemperature.Series[1].Points.RemoveAt(0);
                }
            }
            //add additional chart points
            else if (TrendChartTemperature.Series[0].Points.Count() < NumberOfPoints.Maximum - NumberOfPoints.Value)
            {
                TrendChartTemperature.Series[0].Points.InsertXY(0, InputTempDataPoints[(int)NumberOfPoints.Value].XTime, InputTempDataPoints[(int)NumberOfPoints.Value].YTemperature);
                TrendChartTemperature.Series[1].Points.InsertXY(0, SetPointTempDataPoints[(int)NumberOfPoints.Value].XTime, SetPointTempDataPoints[(int)NumberOfPoints.Value].YTemperature);

            }
        }
    }
}