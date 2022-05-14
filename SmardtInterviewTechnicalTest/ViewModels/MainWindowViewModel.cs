using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SmardtInterviewTechnicalTest.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Properties F1
        private int? _InputTemperature;
        public int? InputTemperature
        {
            get { return _InputTemperature; }
            set {
                _InputTemperature = value;
                if (value != null)
                {
                    if (value > TemperatureSetpoint)
                    {
                        CoolingBool = true;
                    }
                    if (value < TemperatureSetpoint - TemperatureSetpointDeadband)
                    {
                        CoolingBool = false;
                    }
                }
                NotifyPropertyChanged(nameof(InputTemperature)); }
        }
        private int _TemperatureSetpoint;
        public int TemperatureSetpoint
        {
            get { return _TemperatureSetpoint; }
            set
            {
                _TemperatureSetpoint = value;
                NotifyPropertyChanged(nameof(TemperatureSetpoint));
            }
        }
        private int _TemperatureSetpointDeadband;
        public int TemperatureSetpointDeadband
        {
            get { return _TemperatureSetpointDeadband; }
            set
            {
                _TemperatureSetpointDeadband = value;
                NotifyPropertyChanged(nameof(TemperatureSetpointDeadband));
            }
        }
        private bool _CoolingBool;
        public bool CoolingBool
        {
            get { return _CoolingBool; }
            set
            {
                _CoolingBool = value;
                NotifyPropertyChanged(nameof(CoolingBool));
            }
        }
        #endregion
        #region Properties F2
        private int _TextInput1;
        public int TextInput1
        {
            get { return _TextInput1; }
            set
            {
                _TextInput1 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput1));
            }
        }
        private int _TextInput2;
        public int TextInput2
        {
            get { return _TextInput2; }
            set
            {
                _TextInput2 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput2));
            }
        }
        private int _TextInput3;
        public int TextInput3
        {
            get { return _TextInput3; }
            set
            {
                _TextInput3 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput3));
            }
        }
        private int _TextInput4;
        public int TextInput4
        {
            get { return _TextInput4; }
            set
            {
                _TextInput4 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput4));
            }
        }
        private int _TextInput5;
        public int TextInput5
        {
            get { return _TextInput5; }
            set
            {
                _TextInput5 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput5));
            }
        }
        private int _TextInput6;
        public int TextInput6
        {
            get { return _TextInput6; }
            set
            {
                _TextInput6 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput6));
            }
        }
        private int _TextInput7;
        public int TextInput7
        {
            get { return _TextInput7; }
            set
            {
                _TextInput7 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput7));
            }
        }
        private int _TextInput8;
        public int TextInput8
        {
            get { return _TextInput8; }
            set
            {
                _TextInput8 = value;
                UpdateF2List();
                NotifyPropertyChanged(nameof(TextInput8));
            }
        }

        private List<int> _ListFunction2;
        public List<int> ListFunction2
        {
            get { return _ListFunction2; }
            set
            {
                _ListFunction2 = value;
                NotifyPropertyChanged(nameof(ListFunction2));
            }
        }

        private string _OutputFunction2;
        public string OutputFunction2
        {
            get { return _OutputFunction2; }
            set
            {
                _OutputFunction2 = value;
                NotifyPropertyChanged(nameof(OutputFunction2));
            }
        }
        #endregion



        public MainWindowViewModel()
        {
            Function1();
            Function2();
        }
        private void Function1()
        {
            //initialise defaults
            TemperatureSetpoint = 22;
            TemperatureSetpointDeadband = 2;
        }
        private void Function2()
        {
           
        }
        private void UpdateF2List()
        {
            ListFunction2 = new List<int>();
            ListFunction2.Add(TextInput1);
            ListFunction2.Add(TextInput2);
            ListFunction2.Add(TextInput3);
            ListFunction2.Add(TextInput4);
            ListFunction2.Add(TextInput5);
            ListFunction2.Add(TextInput6);
            ListFunction2.Add(TextInput7);
            ListFunction2.Add(TextInput8);
            ListFunction2 = ListFunction2.Where(x => x <= 100).OrderByDescending(x=> (uint)x).ToList().GetRange(0, 3);
            OutputFunction2 = $"{ListFunction2[0]}, {ListFunction2[1]}, {ListFunction2[2]}";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
