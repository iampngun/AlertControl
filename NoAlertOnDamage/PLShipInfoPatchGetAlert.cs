using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertControl
{
	[HarmonyPatch(typeof(PLShipInfo), "CheckForIntruders")]
	internal class PLShipInfoPatchGetAlert
	{
		public static void Prefix(PLShipInfoBase __instance)
		{
			Global.alertLevelBeforeIntruderAlarm = __instance.AlertLevel;
		}
	}
}
