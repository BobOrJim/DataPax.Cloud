
namespace GlobalStringsReadOnly
{
	//When this system is commisioned in a real factory. IOTablesTemplateColumnNames will contain perhaps 1000 different IO
	//and thus we will need to write a CSV file for/with the customer in their system.
    //Then we will need to write a separate program (parser) that will generate our *.sql storedprocedures automaticly and
    //posibly this file as well.
	static public class GlobalReadOnlyStrings
    {

        public static readonly string IOTablesTemplateColumnNames  = " @ToTable_TEXT, @Timestamp_unix_BIGINT, @Datestamp_TEXT, @DeviationID_TEXT, @Hub2Hub_KKS123_SystemVolt_Erratic, " +
			"@Hub2Hub_KKS123_SystemVolt_Low, @Hub2Hub_KKS123_Retarder_LowCurrent, @Hub2Hub_KKS123_AuxPressure_Low, " +
			"@Panna_flisinmatning_skruv1_Motorskydd, @Panna_flisinmatning_skruv1_Sakerhetsbrytare, @Panna_flisinmatning_skruv1_Varvtalsvakt, @Panna_flisinmatning_skruv1_Nodstop, " +
			"@Panna_Fribord_flisinmating_pt1000, @Panna_Fribord_askutmating_pt1000, @Panna_Fribord_ForeBrannare_pt1000, @Panna_Fribord_EfterBrannare_pt1000, " +
			"@Karlatornet_Ventilation_Franluft_HogTemp, @Karlatornet_Ventilation_Franluft_LagTemp, @Karlatornet_Brandlarm_Hiss1_Aktivt, @Karlatornet_Brandlarm_Hiss2_Aktivt, " +
			"@Vestas_Verk12_Koppling_HogTemp, @Vestas_Verk12_Koppling_LagOljeNiva, @Vestas_Verk12_Koppling_TryckAvvikelse, @Vestas_Verk12_Vaderstation_WatchDog";


        public static readonly string PictureTablesTemplateColumnNames = " @ToTable_TEXT, @Timestamp_unix_BIGINT, @Datestamp_TEXT, @DeviationID_TEXT, " +
        "@PictureFileNamePrefix_TEXT, " +
        "@FilePathCurrent_TEXT, @FileNameCurrent_TEXT, @FileEndingCurrent_TEXT, " +
        "@FilePathWork_TEXT, @FileNameWork_TEXT, @FileEndingWork_TEXT, " +
        "@FilePathKeep_TEXT, @FileNameKeep_TEXT, @FileEndingKeep_TEXT, " +
        "@FilePathSpare1_TEXT, @FileNameSpare1_TEXT, @FileEndingSpare1_TEXT, " +
        "@FilePathSpare2_TEXT, @FileNameSpare2_TEXT, @FileEndingSpare2_TEXT, " +
        "@IsLabeledForGarbageCollector_BIT, @SpareBit_BIT";

        //Dessa matchar exakt namn på tabeller i db. DONT TOUCH. And use them to avoid fat fingering stuff. Dessa fat finger fel är sega att hitta. :)
        public static readonly string FactoryTable = "FactoryTable";
        public static readonly string IOOddTable = "IOOddTable";
        public static readonly string IOEvenTable = "IOEvenTable";
        public static readonly string IOKeepTable = "IOKeepTable";
        public static readonly string IODeviationTable = "IODeviationTable";
        public static readonly string Cam1OddTable = "Cam1OddTable";
        public static readonly string Cam1EvenTable = "Cam1EvenTable";
        public static readonly string Cam1KeepTable = "Cam1KeepTable";
        public static readonly string Cam1ThrowTable = "Cam1ThrowTable";
        public static readonly string Cam2OddTable = "Cam2OddTable";
        public static readonly string Cam2EvenTable = "Cam2EvenTable";
        public static readonly string Cam2KeepTable = "Cam2KeepTable";
        public static readonly string Cam2ThrowTable = "Cam2ThrowTable";

        //Dessa matchar exakt SP namn.
        public static readonly string IOTable_createIOTemplateTable = "IOTable_createIOTemplateTable";
        public static readonly string IOTable_deleteTable = "IOTable_deleteTable";
        public static readonly string IOTable_deleteAllPostsInTable = "IOTable_deleteAllPostsInTable";
        public static readonly string IOTable_getPostCountInTable = "IOTable_getPostCountInTable";
        public static readonly string IOTable_getAllPostsInTable = "IOTable_getAllPostsInTable";
        public static readonly string IOTable_cutPostsBetweenInTable = "IOTable_cutPostsBetweenInTable";
        public static readonly string FactoryTable_insert = "FactoryTable_insert";
        public static readonly string IOOddTable_insert = "IOOddTable_insert";
        public static readonly string IOEvenTable_insert = "IOEvenTable_insert";
        public static readonly string IOKeepTable_insert = "IOKeepTable_insert";
        public static readonly string IODeviationTable_Insert = "IODeviationTable_Insert";
        public static readonly string IOTable_insertInTable = "IOTable_insertInTable";
        public static readonly string PictureTable_createPictureTemplateTable = "PictureTable_createPictureTemplateTable";
        public static readonly string Cam1OddTable_Insert = "Cam1OddTable_Insert";
        public static readonly string Cam1EvenTable_Insert = "Cam1EvenTable_Insert";
        public static readonly string Cam1KeepTable_Insert = "Cam1KeepTable_Insert";
        public static readonly string Cam1ThrowTable_Insert = "Cam1ThrowTable_Insert";
        public static readonly string PictureTable_cutPostsBetweenInTable = "PictureTable_cutPostsBetweenInTable";
        public static readonly string Cam2OddTable_Insert = "Cam2OddTable_Insert";
        public static readonly string Cam2EvenTable_Insert = "Cam2EvenTable_Insert";
        public static readonly string Cam2KeepTable_Insert = "Cam2KeepTable_Insert";
        public static readonly string Cam2ThrowTable_Insert = "Cam2ThrowTable_Insert";
    }
}
