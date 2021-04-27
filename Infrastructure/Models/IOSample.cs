using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Models
{
    [Keyless]
    public class IOSample
    {
        public string ToTable_TEXT { get; set; }
        public Int64 Timestamp_unix_BIGINT { get; set; }
        public string Datestamp_TEXT { get; }
        public string DeviationID_TEXT { get; set; }

        public bool Hub2Hub_KKS123_SystemVolt_Erratic { get; set; }
        public bool Hub2Hub_KKS123_SystemVolt_Low { get; set; }
        public bool Hub2Hub_KKS123_Retarder_LowCurrent { get; set; }
        public bool Hub2Hub_KKS123_AuxPressure_Low { get; set; }

        public bool Panna_flisinmatning_skruv1_Motorskydd { get; set; }
        public bool Panna_flisinmatning_skruv1_Sakerhetsbrytare { get; set; } 
        public bool Panna_flisinmatning_skruv1_Varvtalsvakt { get; set; }
        public bool Panna_flisinmatning_skruv1_Nodstop { get; set; }

        public int Panna_Fribord_flisinmating_pt1000 { get; set; }
        public int Panna_Fribord_askutmating_pt1000 { get; set; }
        public int Panna_Fribord_ForeBrannare_pt1000 { get; set; }
        public int Panna_Fribord_EfterBrannare_pt1000 { get; set; }

        public bool Karlatornet_Ventilation_Franluft_HogTemp { get; set; }
        public bool Karlatornet_Ventilation_Franluft_LagTemp { get; set; }
        public bool Karlatornet_Brandlarm_Hiss1_Aktivt { get; set; }
        public bool Karlatornet_Brandlarm_Hiss2_Aktivt { get; set; }

        public bool Vestas_Verk12_Koppling_HogTemp { get; set; }
        public bool Vestas_Verk12_Koppling_LagOljeNiva { get; set; }
        public bool Vestas_Verk12_Koppling_TryckAvvikelse { get; set; }
        public bool Vestas_Verk12_Vaderstation_WatchDog { get; set; }
    }
}
