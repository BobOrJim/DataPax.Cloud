using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Models;
using Interfaces.Interfaces;

namespace Infrastructure.DataAccess
{
    public class IOKeepTableDataAccess : IIOKeepTableDataAccess
    {
        EFAccessIOKeepTable eFAccessIOKeepTable;
        private List<string> IOColumnNamesList = new List<string>();

        public IOKeepTableDataAccess(EFAccessIOKeepTable _eFAccessIOKeepTable)
        {
            eFAccessIOKeepTable = _eFAccessIOKeepTable;
        }



        //Här vill jag ha kolumn namen, och kolumnnamen vet jag redan då de ligger i koden för IOSample för att lyfta ur datan mha EF.
        //Detta metod är därför lite bakvänd men jag använder IOSample då ändringar i IOSample slår igenom här.
        public List<string> IOColumnNames_FromIOKeepTable()
        {
            IOSample iOSample = new IOSample();

            IOColumnNamesList.Add(iOSample.Hub2Hub_KKS123_SystemVolt_Erratic.ToString());
            IOColumnNamesList.Add(iOSample.Hub2Hub_KKS123_SystemVolt_Low.ToString());
            IOColumnNamesList.Add(iOSample.Hub2Hub_KKS123_Retarder_LowCurrent.ToString());
            IOColumnNamesList.Add(iOSample.Hub2Hub_KKS123_AuxPressure_Low.ToString());

            IOColumnNamesList.Add(iOSample.Panna_flisinmatning_skruv1_Motorskydd.ToString());
            IOColumnNamesList.Add(iOSample.Panna_flisinmatning_skruv1_Sakerhetsbrytare.ToString());
            IOColumnNamesList.Add(iOSample.Panna_flisinmatning_skruv1_Varvtalsvakt.ToString());
            IOColumnNamesList.Add(iOSample.Panna_flisinmatning_skruv1_Nodstop.ToString());

            IOColumnNamesList.Add(iOSample.Panna_Fribord_flisinmating_pt1000.ToString());
            IOColumnNamesList.Add(iOSample.Panna_Fribord_askutmating_pt1000.ToString());
            IOColumnNamesList.Add(iOSample.Panna_Fribord_ForeBrannare_pt1000.ToString());
            IOColumnNamesList.Add(iOSample.Panna_Fribord_EfterBrannare_pt1000.ToString());

            IOColumnNamesList.Add(iOSample.Karlatornet_Ventilation_Franluft_HogTemp.ToString());
            IOColumnNamesList.Add(iOSample.Karlatornet_Ventilation_Franluft_LagTemp.ToString());
            IOColumnNamesList.Add(iOSample.Karlatornet_Brandlarm_Hiss1_Aktivt.ToString());
            IOColumnNamesList.Add(iOSample.Karlatornet_Brandlarm_Hiss2_Aktivt.ToString());

            IOColumnNamesList.Add(iOSample.Vestas_Verk12_Koppling_HogTemp.ToString());
            IOColumnNamesList.Add(iOSample.Vestas_Verk12_Koppling_LagOljeNiva.ToString());
            IOColumnNamesList.Add(iOSample.Vestas_Verk12_Koppling_TryckAvvikelse.ToString());
            IOColumnNamesList.Add(iOSample.Vestas_Verk12_Vaderstation_WatchDog.ToString());

            return IOColumnNamesList;
        }

    }
}
