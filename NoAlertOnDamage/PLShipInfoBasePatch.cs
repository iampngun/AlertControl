using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertControl
{
    [HarmonyPatch(typeof(PLShipInfoBase), "TakeDamage")]
    internal class PLShipInfoBasePatch
    {
        public static void Prefix(PLShipInfoBase __instance)
        {
            Global.alertLevelBeforeDamage = __instance.AlertLevel;
        }

        public static void Postfix(PLShipInfoBase __instance)
        {
            if (!Global.toggleByDamage && PhotonNetwork.isMasterClient)
            {
                __instance.AlertLevel = Global.alertLevelBeforeDamage;
            }
        }
    }
}
