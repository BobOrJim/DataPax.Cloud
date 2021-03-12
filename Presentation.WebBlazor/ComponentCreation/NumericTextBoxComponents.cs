using Presentation.WebBlazor.ComponentsNonRoutable;
using Presentation.WebBlazor.Interfaces;
using System;
using System.Diagnostics;


namespace Presentation.WebBlazor.ComponentCreation //Stuff i denna fil aktiveras via User Events.
{
    public class NumericTextBoxComponents : INumericTextBoxComponents
    {
        //Rad 3
        public NumericTextBoxComponent DeviationYear = new NumericTextBoxComponent();
        public NumericTextBoxComponent DeviationMonth = new NumericTextBoxComponent();
        public NumericTextBoxComponent DeviationDay = new NumericTextBoxComponent();
        //Rad 5 part 1
        public NumericTextBoxComponent StartTimeYear = new NumericTextBoxComponent();
        public NumericTextBoxComponent StartTimeMonth = new NumericTextBoxComponent();
        public NumericTextBoxComponent StartTimeDay = new NumericTextBoxComponent();
        public NumericTextBoxComponent StartTimeHour = new NumericTextBoxComponent();
        public NumericTextBoxComponent StartTimeMinute = new NumericTextBoxComponent();
        public NumericTextBoxComponent StartTimeSecond = new NumericTextBoxComponent();
        //Rad 5 part 2
        public NumericTextBoxComponent EndTimeYear = new NumericTextBoxComponent();
        public NumericTextBoxComponent EndTimeMonth = new NumericTextBoxComponent();
        public NumericTextBoxComponent EndTimeDay = new NumericTextBoxComponent();
        public NumericTextBoxComponent EndTimeHour = new NumericTextBoxComponent();
        public NumericTextBoxComponent EndTimeMinute = new NumericTextBoxComponent();
        public NumericTextBoxComponent EndTimeSecond = new NumericTextBoxComponent();



        DateTime currentDate = DateTime.Now;
        public long elapsedTicks { get; private set; }
        public NumericTextBoxComponents()
        {
            elapsedTicks = currentDate.Ticks;
            //Debug.WriteLine($"Im a NumericTextBoxComponents and i was born on Tick: {elapsedTicks} ");
        }

        public void EndTimeYear_ExternalUpdate()
        {
            EndTimeYear.ExternalUpdate();

            //long ticks = _NumericTextBoxComponents.EndTimeYear.ObjectCreatedAtTick();
            //Debug.WriteLine($"Im a NumericTextBoxComponents and i was born on Tick: {ticks} ");
        }


    }
}


