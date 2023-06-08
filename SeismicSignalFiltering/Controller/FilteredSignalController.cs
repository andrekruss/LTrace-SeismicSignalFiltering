using Accord.Audio;
using Accord.Audio.Filters;
using SeismicSignalFiltering.Helpers;
using SeismicSignalFiltering.Models;
using SeismicSignalFiltering.Views;
using System;
using System.Globalization;
using System.Windows.Forms;
using ZedGraph;

namespace SeismicSignalFiltering.Controller
{
    public class FilteredSignalController
    {
        private readonly IFilteredSignalView _view;
        private readonly SeismicSignalModel _rawSignal;
        private readonly SeismicSignalModel _filteredSignal;
        private readonly FilterModel _filter;

        public FilteredSignalController(IFilteredSignalView view, SeismicSignalModel signalModel, FilterModel filterModel)
        {
            this._view = view;
            this._rawSignal = signalModel;
            this._filter = filterModel;
            this._filteredSignal = new SeismicSignalModel();
            this._filteredSignal.SampleRate = this._rawSignal.SampleRate;

            // register event handler method to event raised from views
            this._view.FreqBoxChanged += FreqBoxChangedHandler;
            this._view.HpfSliderChanged += HpfSliderChangedHandler;
            this._view.LpfSliderChanged += LpfSliderChangedHandler;

            // Initializing the graphic with raw signal
            this._view.SetGraphPane(BuildSignalPoints(this._rawSignal.Data, this._rawSignal.SampleRate));
            this._view.HpfFreqCutoff = "0";
            this._view.LpfFreqCutoff = "0";
        }

        // ---------------- Methods ----------------

        // Helper method to builds a list of (Amplitude, t) points to plot on graph
        public PointPairList BuildSignalPoints(float[] signalData, double samplePeriod)
        {
            double timeValue = 0;
            PointPairList points = new PointPairList();
            for (int i = 0; i < signalData.Length; i++)
            {
                points.Add(signalData[i], timeValue);
                timeValue = timeValue + samplePeriod;
            }
            return points;
        }

        public void SetHpfParameter(double hpfFreqCutoff)
        {
            this._filter.HpfFreqCutoff = hpfFreqCutoff;
        }

        public void SetLpfParameter(double lpfFreqCutoff)
        {
            this._filter.LpfFreqCutoff = lpfFreqCutoff;
        }

        public void FilterSignal()
        {
            var rawSignal = this._rawSignal.ConvertArrayToSignal();
            var filteredSignal = this._filter.ApplyLpf(this._filter.ApplyHpf(rawSignal));
            this._filteredSignal.Data = filteredSignal.ToFloat();
        }

        // ---------------- Event Methods ----------------

        // Triggered when one of the text boxes is changed
        private void FreqBoxChangedHandler(object sender, EventArgs e)
        {
            double lpfValue;
            double hpfValue;
            bool lpfValid = double.TryParse(this._view.LpfFreqCutoff, out lpfValue);
            bool hpfValid = double.TryParse(this._view.HpfFreqCutoff, out hpfValue);

            if (lpfValid && hpfValid)
            {
                SetLpfParameter(lpfValue);
                SetHpfParameter(hpfValue);
                FilterSignal();

                // update view
                this._view.UpdateWaveform(BuildSignalPoints(this._filteredSignal.Data, this._filteredSignal.SampleRate));
            }
        }

        // Triggered when the LPF slider is changed
        private void LpfSliderChangedHandler(object sender, EventArgs e)
        {
            string lpfSliderValue = this._view.GetLpfSliderValue();
            this._view.LpfFreqCutoff = lpfSliderValue;
            double lpfValue = double.Parse(lpfSliderValue, CultureInfo.InvariantCulture);
            this._filter.LpfFreqCutoff = lpfValue;

            double hpfValue;
            bool hpfValid = double.TryParse(this._view.HpfFreqCutoff, out hpfValue);

            if (hpfValid)
            {
                SetHpfParameter(hpfValue);
                SetLpfParameter(lpfValue);
                FilterSignal();
            }
        }

        // Triggered when the HPF slider is changed
        private void HpfSliderChangedHandler(object sender, EventArgs e)
        {
            string hpfSliderValue = this._view.GetHpfSliderValue();
            this._view.HpfFreqCutoff = hpfSliderValue;
            double hpfValue = double.Parse(hpfSliderValue, CultureInfo.InvariantCulture);
            this._filter.HpfFreqCutoff = hpfValue;

            double lpfValue;
            bool lpfValid = double.TryParse(this._view.LpfFreqCutoff, out lpfValue);

            if (lpfValid)
            {
                SetHpfParameter(hpfValue);
                SetLpfParameter(lpfValue);
                FilterSignal();
            }
        }

    }
}
