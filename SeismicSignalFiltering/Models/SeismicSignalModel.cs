using Accord.Audio.Filters;
using Accord.Audio;

namespace SeismicSignalFiltering.Models
{
    public class SeismicSignalModel
    {
        // Properties
        public float[] Data { get; set; }
        public double SampleRate { get; set; }

        public SeismicSignalModel() { } 

        public SeismicSignalModel(float[] signalData, double sampleRate) 
        { 
            Data = signalData;
            SampleRate = sampleRate;
        }

        // Methods
        public Signal ConvertArrayToSignal()
        {
            return Signal.FromArray(Data, (int) SampleRate);
        }
    }
}
