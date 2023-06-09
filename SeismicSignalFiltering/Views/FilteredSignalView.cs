﻿using Accord;
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
        event EventHandler SaveButtonPressed;

        // Methods
        void SetGraphPane(PointPairList rawSignalData);
        void UpdateWaveform(PointPairList signalData);
        void UpdateWaveformLabels();
        void UpdateWaveChart();
        void SaveWaveforms();
        string GetLpfSliderValue();
        string GetHpfSliderValue();
    }

    public partial class FilteredSignalView : Form, IFilteredSignalView
    {
        public FilteredSignalView()
        {
            InitializeComponent();
            AssociateEventsToHandlers();
        }

        // Methods
        public void AssociateEventsToHandlers()
        {
            txtLpfFreqCutoff.TextChanged += delegate { FreqBoxChanged?.Invoke(this, EventArgs.Empty); };
            txtHpfFreqCutoff.TextChanged += delegate { FreqBoxChanged?.Invoke(this, EventArgs.Empty); };
            trackBarLpfFreqCutoff.ValueChanged += delegate { LpfSliderChanged?.Invoke(this, EventArgs.Empty); };
            trackBarHpfFreqCutoff.ValueChanged += delegate { HpfSliderChanged?.Invoke(this, EventArgs.Empty); };
            btnSaveData.Click += delegate { SaveButtonPressed?.Invoke(this, EventArgs.Empty); };
        }

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

            TextObj lpfLabel = new TextObj("lpfCutoff = 0 Hz", 0.80, 0.05, CoordType.ChartFraction);
            lpfLabel.FontSpec.Size = 14;
            lpfLabel.FontSpec.Border.IsVisible = false;
            lpfLabel.FontSpec.Fill.IsVisible = false;
            lpfLabel.Tag = "lpf";

            TextObj hpfLabel = new TextObj("hpfCutoff = 0 Hz", 0.80, 0.10, CoordType.ChartFraction);
            hpfLabel.FontSpec.Size = 14;
            hpfLabel.FontSpec.Border.IsVisible = false;
            hpfLabel.FontSpec.Fill.IsVisible = false;
            hpfLabel.Tag = "hpf";

            waveChart.GraphPane.GraphObjList.Add(hpfLabel);
            waveChart.GraphPane.GraphObjList.Add(lpfLabel);

            waveChart.AxisChange();
            UpdateWaveChart();
        }

        public void UpdateWaveformLabels()
        {
            GraphObjList graphObjList = waveChart.GraphPane.GraphObjList;

            foreach (GraphObj graphObj in graphObjList)
            {
                if (graphObj is TextObj label)
                {
                    if (label.Tag.ToString() == "lpf")
                    {
                        var value = txtLpfFreqCutoff.Text;
                        label.Text = $"lpfCutoff = {value} Hz";
                    }
                    else if(label.Tag.ToString() == "hpf")
                    {
                        var value = txtHpfFreqCutoff.Text;
                        label.Text = $"hpfCutoff = {value} Hz";
                    }
                }
            }
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

        public void SaveWaveforms()
        {
            var image = waveChart.GetImage();
            FileHandler.SaveImageFile(image);
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
        public event EventHandler SaveButtonPressed;
    }
}
