using SeismicSignalFiltering.Controller;
using SeismicSignalFiltering.Helpers;
using SeismicSignalFiltering.Models;
using SeismicSignalFiltering.Views;
using System;
using System.Collections.Generic;
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

            double samplePeriod = 0.004;
            double sampleRate = 1 / samplePeriod;
            float[] signalData = FileHandler.ReadSignalFile("C:/Users/Andre/Desktop/Andre/LTrace/arquivo.dat");

            SeismicSignalModel signalModel = new SeismicSignalModel(signalData, sampleRate);
            FilterModel filterModel = new FilterModel(sampleRate);
            IFilteredSignalView filteredSignalView = new FilteredSignalView();
            FilteredSignalController filteredSignalController = new FilteredSignalController(filteredSignalView, signalModel, filterModel);

            Application.Run((Form) filteredSignalView);
        }
    }
}
