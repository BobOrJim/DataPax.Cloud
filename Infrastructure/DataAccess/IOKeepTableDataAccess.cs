using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq.Expressions;
using System.Text;
using Infrastructure.Models;
using Interfaces.Interfaces;
using System.Reflection;
using System.Diagnostics;

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

            IOColumnNamesList.Add(nameof(iOSample.Hub2Hub_KKS123_SystemVolt_Erratic));
            IOColumnNamesList.Add(nameof(iOSample.Hub2Hub_KKS123_SystemVolt_Low));
            IOColumnNamesList.Add(nameof(iOSample.Hub2Hub_KKS123_Retarder_LowCurrent));
            IOColumnNamesList.Add(nameof(iOSample.Hub2Hub_KKS123_AuxPressure_Low));

            IOColumnNamesList.Add(nameof(iOSample.Panna_flisinmatning_skruv1_Motorskydd));
            IOColumnNamesList.Add(nameof(iOSample.Panna_flisinmatning_skruv1_Sakerhetsbrytare));
            IOColumnNamesList.Add(nameof(iOSample.Panna_flisinmatning_skruv1_Varvtalsvakt));
            IOColumnNamesList.Add(nameof(iOSample.Panna_flisinmatning_skruv1_Nodstop));

            IOColumnNamesList.Add(nameof(iOSample.Panna_Fribord_flisinmating_pt1000));
            IOColumnNamesList.Add(nameof(iOSample.Panna_Fribord_askutmating_pt1000));
            IOColumnNamesList.Add(nameof(iOSample.Panna_Fribord_ForeBrannare_pt1000));
            IOColumnNamesList.Add(nameof(iOSample.Panna_Fribord_EfterBrannare_pt1000));

            IOColumnNamesList.Add(nameof(iOSample.Karlatornet_Ventilation_Franluft_HogTemp));
            IOColumnNamesList.Add(nameof(iOSample.Karlatornet_Ventilation_Franluft_LagTemp));
            IOColumnNamesList.Add(nameof(iOSample.Karlatornet_Brandlarm_Hiss1_Aktivt));
            IOColumnNamesList.Add(nameof(iOSample.Karlatornet_Brandlarm_Hiss2_Aktivt));

            IOColumnNamesList.Add(nameof(iOSample.Vestas_Verk12_Koppling_HogTemp));
            IOColumnNamesList.Add(nameof(iOSample.Vestas_Verk12_Koppling_LagOljeNiva));
            IOColumnNamesList.Add(nameof(iOSample.Vestas_Verk12_Koppling_TryckAvvikelse));
            IOColumnNamesList.Add(nameof(iOSample.Vestas_Verk12_Vaderstation_WatchDog));

            return IOColumnNamesList;
        }

    }
}
