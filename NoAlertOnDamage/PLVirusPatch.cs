using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace AlertControl
{
	[HarmonyPatch(typeof(PLVirus), "EquipToShip_AsVirus")]
	internal class GetPLShipComponentInstance
	{
		public static void Prefix(PLShipComponent __instance)
		{
			Global.PLShipComponentInstance = __instance;
		}
	}

	[HarmonyPatch(typeof(PLVirus), "EquipToShip_AsVirus")]
	internal class GetPLVirusInstance
	{
		public static void Prefix(PLVirus __instance)
		{
			Global.PLVirusInstance = __instance;
		}
	}

	[HarmonyPatch(typeof(PLVirus), "EquipToShip_AsVirus")]
    internal class PLVirusPatch
    {
        public static bool Prefix(PLShipInfoBase __instance)
        {
			if(Global.toggleByVirusInfection || !PhotonNetwork.isMasterClient)
            {
				return true;
            }

			if (Global.PLVirusInstance != null && Global.PLShipComponentInstance != null && __instance != null)
			{
				if (Global.PLVirusInstance.InitialInfectionTime == -2147483648)
				{
					if (PhotonNetwork.isMasterClient)
					{
						Global.PLVirusInstance.InitialInfectionTime = PLServer.Instance.GetEstimatedServerMs();
						Debug.Log("PLVirus::Equip");
					}
					else if (PLServer.Instance != null)
					{
						PLServer.Instance.photonView.RPC("AskServerForVirusSetupInfo", PhotonTargets.MasterClient, new object[]
						{
					__instance.ShipID,
					Global.PLShipComponentInstance.NetID
						});
					}
				}
				if (PhotonNetwork.isMasterClient)
				{
					
				}
			}

			return false;
		}
    }
}
