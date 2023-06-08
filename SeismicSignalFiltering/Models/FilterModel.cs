using Accord.Audio.Filters;
using Accord.Audio;

namespace SeismicSignalFiltering.Models
{
    public class FilterModel
    {
        public double LpfFreqCutoff { get; set; }
        public double HpfFreqCutoff { get; set; }
        public double SampleRate { get; set; }

        public FilterModel() { }
        public FilterModel(double sampleRate)
        {
            SampleRate = sampleRate;
        }

        // Methods
        public Signal ApplyLpf(Signal signal)
        {
            LowPassFilter lpf = new LowPassFilter(LpfFreqCutoff, SampleRate);
            return lpf.Apply(signal);
        }

        public Signal ApplyHpf(Signal signal)
        {
            HighPassFilter hpf = new HighPassFilter(HpfFreqCutoff, SampleRate);
            return hpf.Apply(signal);
        }
    }
}
