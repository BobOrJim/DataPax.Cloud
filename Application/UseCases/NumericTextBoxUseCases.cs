using Presentation.WebBlazor.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Application.UseCases //Stuff i denna fil aktiveras via User Events.
{
    public class NumericTextBoxUseCases
    {
        
        INumericTextBoxComponents NumericTextBoxComponents;
        public void DepInjection(INumericTextBoxComponents _NumericTextBoxComponents)
        {
            NumericTextBoxComponents = _NumericTextBoxComponents;
        }


        public void Hej()
        {

        }

        //Rad3
        public void DeviationYearValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   DeviationYearEvent ");
        }
        public void DeviationMonthValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   DeviationMonthEvent ");
        }
        public void DeviationDayValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   DeviationDayEvent ");
        }

        //Rad5 par 1
        public void StartTimeYearValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   StartTimeYearValueChangedEvent ");
        }
        public void StartTimeMonthValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   StartTimeMonthValueChangedEvent ");
        }
        public void StartTimeDayValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   StartTimeDayValueChangedEvent ");
        }
        public void StartTimeHourValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   StartTimeHourValueChangedEvent ");
        }
        public void StartTimeMinuteValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   StartTimeMinuteValueChangedEvent ");
        }
        public void StartTimeSecondValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   StartTimeSecondValueChangedEvent ");
        }

        //Rad5 par 2
        public void EndTimeYearValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   EndTimeYearValueChangedEvent ");
            NumericTextBoxComponents.EndTimeYear_ExternalUpdate();
        }
        public void EndTimeMonthValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   EndTimeMonthValueChangedEvent ");
        }
        public void EndTimeDayValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   EndTimeDayValueChangedEvent ");
        }
        public void EndTimeHourValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   EndTimeHourValueChangedEvent ");
        }
        public void EndTimeMinuteValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   EndTimeMinuteValueChangedEvent ");
        }
        public void EndTimeSecondValueChangedEvent()
        {
            Debug.WriteLine($"Event firing:   EndTimeSecondValueChangedEvent ");
        }



    }
}


