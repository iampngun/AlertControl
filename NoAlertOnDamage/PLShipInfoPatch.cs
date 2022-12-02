using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AlertControl
{
    [HarmonyPatch(typeof(PLShipInfo), "CheckForIntruders")]
    internal class PLShipInfoPatch
    {
        public static void Prefix(PLShipInfo __instance)
        {
            Global.PLShipInfoInstance = __instance;
        }

        public static void Postfix(PLShipInfoBase __instance)
        {
			if (__instance.IsAuxSystemActive(6) && !Global.toggleByIntruderAlarm)
			{
				if(Global.PLShipInfoInstance != null)
                {
					bool flag = false;
					foreach (PLPlayer plplayer in PLServer.Instance.AllPlayers)
					{
						if (plplayer != null && plplayer.StartingShip != Global.PLShipInfoInstance && plplayer.PlayerLifeTime > 5f && plplayer.GetPawn() != null && plplayer.GetPawn().CurrentShip == Global.PLShipInfoInstance)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						__instance.AlertLevel = Global.alertLevelBeforeIntruderAlarm;
					}
				}
			}
		}
    }

	[HarmonyPatch(typeof(PLShipInfo), "CheckForIntruders")]
	internal class PLShipInfoPatchGetAlert
	{
		public static void Prefix(PLShipInfoBase __instance)
		{
			Global.alertLevelBeforeIntruderAlarm = __instance.AlertLevel;
		}
	}
}
