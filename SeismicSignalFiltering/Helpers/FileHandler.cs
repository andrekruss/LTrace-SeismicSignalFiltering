using System;
using System.Drawing;
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

        public static void SaveImageFile(Image waveformsImage)
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Results");
            
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileName = "image.png";
            var filePath = Path.Combine(folderPath, fileName);

            if (!File.Exists(filePath)) 
            {
                waveformsImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                return;
            }

            int i = 1;
            fileName = $"image{i}.png";
            filePath = Path.Combine(folderPath, fileName);

            while(true)
            {
                if (!File.Exists(filePath))
                {
                    waveformsImage.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
                    return;
                }
                i = i + 1;
                filePath = Path.Combine(folderPath, $"image{i}.png");
            }
        }
    }
}
