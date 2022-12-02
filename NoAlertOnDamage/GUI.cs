using System;
using PulsarModLoader.CustomGUI;
using UnityEngine;

namespace AlertControl
{
    internal class GUI : ModSettingsMenu
    {
        public override void Draw()
        {
            string text = "Toggle by Damage is now " + (Global.toggleByDamage ? "Enabled" : "Disabled");
            bool flag = GUILayout.Button(text, Array.Empty<GUILayoutOption>());
            if (flag)
            {
                Global.toggleByDamage = !Global.toggleByDamage;
            }

            text = "Toggle by Intruder Alarm is now " + (Global.toggleByIntruderAlarm ? "Enabled" : "Disabled");
            flag = GUILayout.Button(text, Array.Empty<GUILayoutOption>());
            if (flag)
            {
                Global.toggleByIntruderAlarm = !Global.toggleByIntruderAlarm;
            }

            text = "Toggle by Virus Infection is now " + (Global.toggleByVirusInfection ? "Enabled" : "Disabled");
            flag = GUILayout.Button(text, Array.Empty<GUILayoutOption>());
            if (flag)
            {
                Global.toggleByVirusInfection = !Global.toggleByVirusInfection;
            }
        }

        public override string Name()
        {
            return "AlertControl";
        }
    }
}
