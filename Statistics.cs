using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    public class Statistics {
       public Statistics(Field field){
            field.StatisticsEvent += Field_StatisticsEvent;
            Log.WriteStat($"Поподание {hitting} Промохи {slips}");
        }
        public int hitting { get; private set; }
        public int slips { get; private set; }
        private void Field_StatisticsEvent(StatisticsEventEnum arg1) {
            if(arg1 == StatisticsEventEnum.hitting) {
                hitting++;
            } else {
                slips++;
            }
            Log.WriteStat($"Поподание {hitting} Промохи {slips}");
        }

       

    }
}
