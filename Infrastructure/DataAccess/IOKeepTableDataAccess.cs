using System;
using System.Collections.Generic;
using System.Linq;
//using System.Linq.Expressions;
using System.Text;
using Infrastructure.Models;
using Interfaces.Interfaces;
using System.Reflection;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

//The interface of this class is a utility/Data-access for an IOKeepTableService in Application. And a IOKeepTableService object is used in the PresentationPage

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

        public List<Int64> IOXCoordinatesFromSignal_FromIOKeepTable(string Signal)
        {
            List<Int64> XCoordinateList = new List<Int64>();
            List<IOSample> IOSampleList = eFAccessIOKeepTable.IOKeepTable.ToList();
            foreach (IOSample item in IOSampleList)
            {
                XCoordinateList.Add(item.Timestamp_unix_BIGINT);
                //Debug.WriteLine($"item.Timestamp_unix_BIGINT = {item.Timestamp_unix_BIGINT}");
            }
            return XCoordinateList;
        }


        //DETTA ÄR EN DÅLIG LÖSNING. DEN ÄR TEMPORÄR. NÄR OM SYSTEMET GÅR LIVE KAN DET VARA 1000 SIGNALER...
        //ANTINGEN GÖR JAG REFLEKTION
        //ELLER SÅ NÅGON SQL/EF LÖSNING. KANSKE FÅR VI LÖSNING PÅ UTB...SÅ MYCKET ATT GÖRA OCH SÅ LITE TID...
        public List<Boolean> IOYCoordinatesFromSignal_FromIOKeepTable(string Signal)
        {
            List<Boolean> YCoordinateList = new List<Boolean>();
            List<IOSample> IOSampleList = eFAccessIOKeepTable.IOKeepTable.ToList();

            foreach (IOSample iOSample in IOSampleList)
            {
                switch (Signal)
                {
                    case "Hub2Hub_KKS123_AuxPressure_Low":
                        YCoordinateList.Add(iOSample.Hub2Hub_KKS123_AuxPressure_Low);
                        break;
                    case "Hub2Hub_KKS123_Retarder_LowCurrent":
                        YCoordinateList.Add(iOSample.Hub2Hub_KKS123_Retarder_LowCurrent);
                        break;
                    case "Hub2Hub_KKS123_SystemVolt_Erratic":
                        YCoordinateList.Add(iOSample.Hub2Hub_KKS123_SystemVolt_Erratic);
                        break;
                    case "Hub2Hub_KKS123_SystemVolt_Low":
                        YCoordinateList.Add(iOSample.Hub2Hub_KKS123_SystemVolt_Low);
                        break;
                    case "Panna_flisinmatning_skruv1_Motorskydd":
                        YCoordinateList.Add(iOSample.Panna_flisinmatning_skruv1_Motorskydd);
                        break;
                    case "Panna_flisinmatning_skruv1_Nodstop":
                        YCoordinateList.Add(iOSample.Panna_flisinmatning_skruv1_Nodstop);
                        break;
                    case "Panna_flisinmatning_skruv1_Sakerhetsbrytare":
                        YCoordinateList.Add(iOSample.Panna_flisinmatning_skruv1_Sakerhetsbrytare);
                        break;
                    case "Panna_flisinmatning_skruv1_Varvtalsvakt":
                        YCoordinateList.Add(iOSample.Panna_flisinmatning_skruv1_Varvtalsvakt);
                        break;
                    case "Karlatornet_Brandlarm_Hiss1_Aktivt":
                        YCoordinateList.Add(iOSample.Karlatornet_Brandlarm_Hiss1_Aktivt);
                        break;
                    case "Karlatornet_Brandlarm_Hiss2_Aktivt":
                        YCoordinateList.Add(iOSample.Karlatornet_Brandlarm_Hiss2_Aktivt);
                        break;
                    case "Karlatornet_Ventilation_Franluft_HogTemp":
                        YCoordinateList.Add(iOSample.Karlatornet_Ventilation_Franluft_HogTemp);
                        break;
                    case "Karlatornet_Ventilation_Franluft_LagTemp":
                        YCoordinateList.Add(iOSample.Karlatornet_Ventilation_Franluft_LagTemp);
                        break;
                    case "Vestas_Verk12_Koppling_HogTemp":
                        YCoordinateList.Add(iOSample.Vestas_Verk12_Koppling_HogTemp);
                        break;
                    case "Vestas_Verk12_Koppling_LagOljeNiva":
                        YCoordinateList.Add(iOSample.Vestas_Verk12_Koppling_LagOljeNiva);
                        break;
                    case "Vestas_Verk12_Koppling_TryckAvvikelse":
                        YCoordinateList.Add(iOSample.Vestas_Verk12_Koppling_TryckAvvikelse);
                        break;
                    case "Vestas_Verk12_Vaderstation_WatchDog":
                        YCoordinateList.Add(iOSample.Vestas_Verk12_Vaderstation_WatchDog);
                        break;
                    default:
                        Debug.WriteLine($"In IOYCoordinatesFromSignal_FromIOKeepTable...");
                        break;
                }
            }
            return YCoordinateList;
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
