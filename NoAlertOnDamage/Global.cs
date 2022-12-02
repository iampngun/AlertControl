using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertControl
{
    internal class Global
    {
        public static PLShipInfo PLShipInfoInstance;
        public static PLVirus PLVirusInstance;
        public static PLShipComponent PLShipComponentInstance;

        public static bool toggleByDamage = false;
        public static int alertLevelBeforeDamage = 0;

        public static bool toggleByIntruderAlarm = false;
        public static int alertLevelBeforeIntruderAlarm = 0;

        public static bool toggleByVirusInfection = false;
    }
}
