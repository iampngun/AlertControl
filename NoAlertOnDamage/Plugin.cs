using PulsarModLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PulsarModLoader.PulsarMod;

namespace AlertControl
{
    public class Plugin : PulsarMod
    {
        public override string HarmonyIdentifier()
        {
            return "pngun.AlertControl";
        }
        public override string Author => "pngun";
        public override string ShortDescription => "Controls Alert triggering.";
        public override string LongDescription 
            => "Allows Host to disable/enable Red Alert triggering by getting Damage to Ship, Virus Infection, Intruder Alarm. All disabled by default.";
        public override string Name => "AlertControl";
        public override string Version => "0.0.2";
    }
}
