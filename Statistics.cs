using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    public class Statistics {
       public Statistics(Field field){
            field.StatisticsEvent += Field_StatisticsEvent;
            Log.WriteStat($"Поподание {Hitting} Промохи {Slips}");
        }
        public int Hitting { get; private set; }
        public int Slips { get; private set; }
        private void Field_StatisticsEvent(StatisticsEventEnum arg1) {
            if(arg1 == StatisticsEventEnum.hitting) {
                Hitting++;
            } else {
                Slips++;
            }
            Log.WriteStat($"Поподание {Hitting} Промохи {Slips}");
        }

       

    }
}
