using Accord;
using SeismicSignalFiltering.Helpers;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using ZedGraph;
using System.Diagnostics;

namespace SeismicSignalFiltering.Views
{
    // This interface is used by the controller to interact with the view
    public interface IFilteredSignalView
    {
        // Properties
        string LpfFreqCutoff { get; set; }
        string HpfFreqCutoff { get; set; }

        // Events
        event EventHandler FreqBoxChanged;
        event EventHandler HpfSliderChanged;
        event EventHandler LpfSliderChanged;

        // Methods
        void SetGraphPane(PointPairList rawSignalData);
        void UpdateWaveform(PointPairList signalData);
        void UpdateWaveChart();
        string GetLpfSliderValue();
        string GetHpfSliderValue();
    }

    public partial class FilteredSignalView : Form, IFilteredSignalView
    {
        public FilteredSignalView()
        {
            InitializeComponent();
            txtLpfFreqCutoff.TextChanged += delegate { FreqBoxChanged?.Invoke(this, EventArgs.Empty); };      
            txtHpfFreqCutoff.TextChanged += delegate { FreqBoxChanged?.Invoke(this, EventArgs.Empty); };
            trackBarLpfFreqCutoff.ValueChanged += delegate { LpfSliderChanged?.Invoke(this, EventArgs.Empty); };
            trackBarHpfFreqCutoff.ValueChanged += delegate { HpfSliderChanged?.Invoke(this, EventArgs.Empty); };
        }

        // Methods
        public string GetLpfSliderValue()
        {
            return trackBarLpfFreqCutoff.Value.ToString();
        }
        public string GetHpfSliderValue()
        {
            return trackBarHpfFreqCutoff.Value.ToString();
        }

        public void SetGraphPane(PointPairList rawSignalData)
        {
            waveChart.GraphPane.Title.Text = "Formas de Onda";
            waveChart.GraphPane.XAxis.Title.Text = "Amplitude";
            waveChart.GraphPane.YAxis.Title.Text = "Tempo(ms)";
            LineItem rawSignalCurve = waveChart.GraphPane.AddCurve("Sismica Original", rawSignalData, Color.Blue, SymbolType.None);
            LineItem filteredSignalCurve = waveChart.GraphPane.AddCurve("Sismica Filtrada", new PointPairList(), Color.Red, SymbolType.None);
            waveChart.AxisChange();
            UpdateWaveChart();
        }

        public void UpdateWaveform(PointPairList signalData)
        {
            CurveItem curve = waveChart.GraphPane.CurveList.ElementAt(1);
            curve.Clear();
            curve.Points = signalData;
            UpdateWaveChart();
        }

        public void UpdateWaveChart()
        {
            waveChart.Invalidate();
        }

        // Properties
        public string LpfFreqCutoff { 
            get => txtLpfFreqCutoff.Text; 
            set => txtLpfFreqCutoff.Text = value; 
        }
        public string HpfFreqCutoff {
            get => txtHpfFreqCutoff.Text;
            set => txtHpfFreqCutoff.Text = value;
        }

        // Events
        public event EventHandler FreqBoxChanged;
        public event EventHandler LpfSliderChanged;
        public event EventHandler HpfSliderChanged;
    }
}
