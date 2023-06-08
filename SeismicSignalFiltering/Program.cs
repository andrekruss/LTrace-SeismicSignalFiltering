using SeismicSignalFiltering.Controller;
using SeismicSignalFiltering.Helpers;
using SeismicSignalFiltering.Models;
using SeismicSignalFiltering.Views;
using SeismicSignalFiltering.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeismicSignalFiltering
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Setting raw signal information
            double samplePeriod = 0.004;
            double sampleRate = 1 / samplePeriod;
            string signalFilePath = @"C:\Users\Andre\Desktop\Andre\LTrace\LTrace\SeismicSignalFiltering\SeismicSignalFiltering\Data\Signal.txt";
            //float[] signalData = FileHandler.ReadSignalFile(signalFilePath);
            float[] signalData = SignalData.GetRawSignalData(); 

            // Sets the models, view and controller
            SeismicSignalModel signalModel = new SeismicSignalModel(signalData, sampleRate);
            FilterModel filterModel = new FilterModel(sampleRate);
            IFilteredSignalView filteredSignalView = new FilteredSignalView();
            FilteredSignalController filteredSignalController = new FilteredSignalController(filteredSignalView, signalModel, filterModel);

            // Run app with the main view 
            Application.Run((Form)filteredSignalView);
            
        }
    }
}
