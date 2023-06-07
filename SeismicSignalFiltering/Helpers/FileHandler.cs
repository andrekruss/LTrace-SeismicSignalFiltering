using System;
using System.Globalization;
using System.IO;

namespace SeismicSignalFiltering.Helpers
{
    public static class FileHandler
    {
        public static float[] ReadSignalFile(string filePath)
        {
            try
            {
                string[] rawSignalFile = File.ReadAllLines(filePath);
                float[] signalData = new float[rawSignalFile.Length];
                for (int i = 0; i < signalData.Length; i++)
                {
                    signalData[i] = float.Parse(rawSignalFile[i], CultureInfo.InvariantCulture);
                }
                return signalData;
            }
            catch (IOException err)
            {
                Console.WriteLine("Error while reading file: " + err.Message);
                return null;
            }
        }
    }
}
